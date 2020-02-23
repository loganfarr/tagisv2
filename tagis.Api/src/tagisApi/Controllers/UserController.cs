using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using tagisApi.Authentication;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;
using tagisApi.Models.ResourceModels;

namespace tagisApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase, IUserControllerInterface
    {
        private readonly TagisDbContext _context;
        private readonly TokenManager _tokenManager;
        private readonly IConfiguration _config;

        public UserController(
            TagisDbContext context, 
            IConfiguration config, 
            IOptions<TokenManager> tokenManager)
        {
            _context = context;
            _config = config;
            _tokenManager = tokenManager.Value;
        }

        [HttpPost("authenticate")]
        public APIGatewayProxyResponse Authenticate([FromBody] UserAuthenticationResource user)
        {
            User loadedUser = _context.Users.SingleOrDefault(u => u.Email == user.Email);

            MD5 md5Hash = MD5.Create();

            string hash = GetMd5Hash(md5Hash, user.Password);

            if (!VerifyMd5Hash(md5Hash, user.Password, hash))
                return new APIGatewayProxyResponse {StatusCode = 500, Body = null};
            

            if (loadedUser != null && (hash != loadedUser.Password || loadedUser.Active == 0))
                return new APIGatewayProxyResponse {StatusCode = 401};
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManager.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var userClaims = new Claim[] {
                new Claim("FirstName", loadedUser.FirstName),
                new Claim("LastName", loadedUser.LastName), 
                new Claim("Email", loadedUser.Email),
                new Claim("Role", loadedUser.Role.ToString()),
                new Claim("LastLogin", loadedUser.lastLogin.ToString()),
                new Claim("UserId", loadedUser._uid.ToString()), 
                new Claim("IsActive", loadedUser.Active.ToString()), 
            };

            var jwtToken = new JwtSecurityToken(
                _tokenManager.Issuer,
                _tokenManager.Audience,
                userClaims,
                expires:DateTime.Now.AddMinutes(_tokenManager.AccessExpiration),
                signingCredentials: credentials
            );
            
            var TagisToken = new TagisToken(){Authenticated = new JwtSecurityTokenHandler().WriteToken(jwtToken)};

            return new TypedAPIGatewayProxyResponse<TagisToken>(200, TagisToken);
        }
        
        private static string GetMd5Hash(HashAlgorithm md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }

        
        [HttpGet]
        [Authorize]
        public APIGatewayProxyResponse GetUsers()
        {
            List<User> userList = _context.Users.ToList();
            return new TypedAPIGatewayProxyResponse<List<User>>(200, userList);
        }

        [HttpPost]
        [Authorize]
        public APIGatewayProxyResponse PostUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            CreatedAtActionResult newUser = CreatedAtAction(nameof(GetUser), new {id = user._uid}, user);
            return new TypedAPIGatewayProxyResponse<CreatedAtActionResult>(200, newUser);
        }

        [HttpGet("{id}")]
        public APIGatewayProxyResponse GetUser(int uid)
        {
            User user = _context.Users.SingleOrDefault(u => u._uid == uid);
            return new TypedAPIGatewayProxyResponse<User>(200, user);
        }
        
        [HttpPut("{id}")]
        [Authorize]
        public APIGatewayProxyResponse UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return new TypedAPIGatewayProxyResponse<User>(200, user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public APIGatewayProxyResponse DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return new APIGatewayProxyResponse {StatusCode = 200};
        }
    }
}