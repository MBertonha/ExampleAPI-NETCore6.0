using ExemploAPI.Dominio.Modelos.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades.Exemplo
{
    public class ExemploEntidade : Entidade<ExemploEntidade>
    {
        #region Variaveis
        public string Nome { get; private set; }
        public string Email { get; private set; }
        #endregion

        public ExemploEntidade()
        {
            
        }

        public ExemploEntidade(string nome, string email)
        {
            Nome = nome;
            Email = email;

            Validar(this);
        }

        public override bool EstaValido()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
