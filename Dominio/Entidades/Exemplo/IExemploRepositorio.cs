using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.Repositories;

namespace Dominio.Entidades.Exemplo
{
    public interface IExemploRepositorio : IRepository
    {
        Task<ExemploEntidade> InsertAsync(ExemploEntidade exemplo);
        Task<ExemploEntidade> UpdateAsync(ExemploEntidade exemplo);
        Task RemoverExemplo(int id);
    }
}
