using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Endorblast.Backend.Tokens
{
    public class VerifyToken
    {
        public Tuple<string, bool> Validate(string address, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes($"{address}-{TokenSettings.TokenSecret}");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "id").Value;
                var savedAddress = jwtToken.Claims.First(x => x.Type == "address").Value;
                

                if (address == savedAddress)
                {
                    return Tuple.Create(accountId, true);
                }
                
                
                return Tuple.Create("", false);
            }
            catch
            {
                // return null if validation fails
                return Tuple.Create("", false);
            }
        }
    }
}