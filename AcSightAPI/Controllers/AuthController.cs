using Business.Abstract;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AcSightAPI.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoggerManager _loggerManager;
        public AuthController(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }
        string signingKey = "thisismyaudiencevalueforacsightcompanydemotestproject";

        [HttpGet]
        public string Get(string username, string password)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Email, username)
            };

            var signinkey = "thisismyaudiencevalueforacsightcompanydemotestproject";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinkey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                
                issuer: "https://localhost",
                audience: "thisismyaudiencevalueforacsightcompanydemotestproject",
                claims: claims,
                expires: DateTime.Now.AddDays(15),
                notBefore: DateTime.Now,
                signingCredentials: credentials
                
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            _loggerManager.LogInfo(username + " Name User is Validate!");
            return token;

        }

        [HttpGet("validatetoken")]
        public bool ValidateToken(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false 
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = jwtToken.Claims.ToList();
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
