using ExemploAPI.Dominio.Modelos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto.Exemplo.Interface
{
    public interface IExemploLeituraRepositorio
    {
        Task<IListaBaseDto<ExemploDTO>> BuscarTodos(BuscarTodosExemploDTO buscar);

        Task<ExemploDTO> BuscarPorId(int seaOs);
    }
}
