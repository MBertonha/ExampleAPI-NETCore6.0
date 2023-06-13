using ExempleAPI.Configuracoes.Security;
using Microsoft.AspNetCore.Mvc;

namespace ExempleAPI.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly JwtTokenGenerator _tokenGenerator;

        public TokenController(JwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpGet]
        public IActionResult GetToken(string name)
        {
            string username = name;
            string token = _tokenGenerator.GenerateJwtToken(username);
            return Ok(token);
        }
    }
}
