using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ExempleAPI.Configuracoes.Security
{
    public class JwtTokenValidate
    {
        private readonly IConfiguration _configuration;

        public JwtTokenValidate(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool ValidateJwtToken(string token)
        {
           
            var config = _configuration.GetSection("AppSettings");
            var secretKey = config.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // opcional: ajuste o tempo de expiração do token
                }, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
