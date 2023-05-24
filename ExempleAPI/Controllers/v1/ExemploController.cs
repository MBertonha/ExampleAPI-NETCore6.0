using ExemploAPI.Dominio.Modelos.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tnf.AspNetCore.Mvc.Response;

namespace ExempleAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    public class ExemploController : TnfController
    {
        public ExemploController()
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IListaBaseDto<>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos()
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IListaBaseDto<>), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post()
        {
            return null;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IListaBaseDto<>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Atualizar()
        {
            return null;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Delete()
        {
            return null;
        }
    }
}
