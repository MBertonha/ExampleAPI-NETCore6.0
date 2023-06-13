using Dominio.Dto;
using ExemploAPI.Dominio.Modelos.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;
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
        [ProducesResponseType(typeof(IListaBaseDto<ExemploDTO>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> BuscarTodos([FromQuery] BuscarTodosExemploDTO model)
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExemploDTO), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] ExemploDTO model)
        {
            return null;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ExemploDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] ExemploDTO model)
        {
            return null;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return null;
        }
    }
}
