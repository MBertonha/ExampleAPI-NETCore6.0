using ExemploAPI.Dominio.Modelos.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ExemploEntidade : Entidade<ExemploEntidade>
    {
        #region Variaveis

        #endregion

        public ExemploEntidade()
        {
            
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
