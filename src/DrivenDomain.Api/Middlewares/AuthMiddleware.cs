using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using DrivenDomain.Api.Config;
using Microsoft.IdentityModel.Tokens;

namespace DrivenDomain.Api.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;


        public AuthMiddleware(RequestDelegate next, IConfiguration config)
        {
            _config = config;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check for authentication token in request
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? "";
            var secret = _config?.GetSection("Jwt").Get<JwtConfig>()?.Secret ?? "";

            if(context.Request.Path.Value == null || context.Request.Path.Value.Equals("/")){
                context.Response.StatusCode = 405;
                await context.Response.WriteAsync("Method Not Allowed");
                return;
            }


            if (context.Request.Path.Value.Contains("GenerateToken"))
            {
                await _next(context);
                return;
            }

            if (token != null)
            {
                // Validate token
                if (ValidateToken(token, secret))
                {
                    // Token is valid, proceed with the request
                    await _next(context);
                    return;
                }
            }

            // Authentication failed, return unauthorized
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
        }

        private bool ValidateToken(string token, string secret)
        {
            // Implement token validation logic
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                // Cast the validated token to a JwtSecurityToken and check if it's expired
                var jwtToken = validatedToken as JwtSecurityToken;
                return jwtToken != null && jwtToken.ValidTo > DateTime.UtcNow;
            }
            catch
            {
                // Token is invalid if any exception is thrown during validation
                return false;
            }
        }
    }


}