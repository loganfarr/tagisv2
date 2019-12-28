using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using tagisApi.Authentication;
using tagisApi.Controllers.Interfaces;
using tagisApi.Controllers.Resources;
using tagisApi.Models;

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
        public async Task<ActionResult<TagisToken>> Authenticate([FromBody] UserAuthenticationResource user)
        {
            User loadedUser = await _context.Users
                .Where(u => u.Email == user.Email)
                .SingleOrDefaultAsync();

            MD5 md5Hash = MD5.Create();

            string hash = GetMd5Hash(md5Hash, user.Password);

            if (!VerifyMd5Hash(md5Hash, user.Password, hash))
            {
                Response.StatusCode = 500;
                return new TagisToken();
            }

            if (hash != loadedUser.Password || loadedUser.Active == 0)
            {
                Response.StatusCode = 401;
                return new TagisToken();
            }

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
            
            
            
            return new TagisToken(){Authenticated = new JwtSecurityTokenHandler().WriteToken(jwtToken)};
        }
        
        static string GetMd5Hash(HashAlgorithm md5Hash, string input)
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
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }

        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new {id = user._uid}, user);
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<User>> GetUser(int uid)
        {
            return await _context.Users.Where(u => u._uid == uid).SingleOrDefaultAsync();
        }
        
        [HttpPut]
        [Authorize]
        public Task<ActionResult<User>> UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<int>> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }
    }
}