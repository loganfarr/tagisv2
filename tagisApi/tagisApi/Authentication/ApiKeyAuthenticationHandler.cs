using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using tagisApi.Authentication.Interfaces;

namespace tagisApi.Authentication
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private const string ProblemDetailsContentType = "application/problem+json";
        private readonly IGetAllApiKeysQuery _getAllApiKeysQuery;
        private const string ApiKeyHeaderName = "X-API-KEY";

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IGetAllApiKeysQuery getAllApiKeysQuery) : base(options, logger, encoder, clock)
        {
            _getAllApiKeysQuery = getAllApiKeysQuery ?? throw new ArgumentNullException(nameof(getAllApiKeysQuery));
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // If the request has no API key, return no result
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValues))
                return AuthenticateResult.NoResult();
            
            // Get the first API key provided
            var providedApiKey = apiKeyHeaderValues.FirstOrDefault();

            // If no key value, return no result
            if (apiKeyHeaderValues.Count == 0 || string.IsNullOrWhiteSpace(providedApiKey))
                return AuthenticateResult.NoResult();

            // Get the existing API keys in the system
            var existingApiKeys = await _getAllApiKeysQuery.ExecuteAsync();
            
            if (!existingApiKeys.ContainsKey(providedApiKey))
                return AuthenticateResult.Fail("Invalid API key provided");
            
            var apiKey = existingApiKeys[providedApiKey];

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, apiKey.Owner)
            };
                
            claims.AddRange(apiKey.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
                
            // Create new claims identity
            var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
            
            // Add identity to list
            var identities = new List<ClaimsIdentity> { identity };
            
            // Create new claims principal that represents the security context of the user
            var principal = new ClaimsPrincipal(identities);
            
            // Create new ticket to hold user identity information
            var ticket = new AuthenticationTicket(principal, Options.Scheme);
            
            return AuthenticateResult.Success(ticket);
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 401;
            Response.ContentType = ProblemDetailsContentType;
            var problemDetails = new UnauthenticatedProblemDetails();

            await Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 403;
            Response.ContentType = ProblemDetailsContentType;
            var problemDetails = new ForbiddenProblemDetails();

            await Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}