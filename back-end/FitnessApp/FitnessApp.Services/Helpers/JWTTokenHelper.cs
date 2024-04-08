using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessApp.Service.Helpers
{
    public static class JWTTokenHelper
    {
        public static JwtSecurityToken GenerateToken(IConfiguration _config, string username, string email)
        {
            try
            {
                int expiryInMinutes = Convert.ToInt32(_config["Jwt:ExpiryInMinutes"]);
                string securityKey = _config["Jwt:SecurityKey"];
                string issuer = _config["Jwt:Issuer"];
                string audience = _config["Jwt:Audience"];

                var expiresIn = DateTime.UtcNow.AddMinutes(expiryInMinutes);
  
                var claim = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Name, username),
                    new Claim(JwtRegisteredClaimNames.Email,email),
                    new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.FromUnixTimeSeconds((long)expiresIn.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString()), //expiration time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.FromUnixTimeSeconds((long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString()), //issued at
                    new Claim(JwtRegisteredClaimNames.UniqueName, username),

                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    expires: expiresIn,
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                    claims: claim
                );

                return token;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception from GenerateToken method in JWTTokenHelper", ex);
            }
           
        }
    }
}
