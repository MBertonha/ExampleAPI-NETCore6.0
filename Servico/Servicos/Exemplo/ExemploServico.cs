using Dominio.Dto;
using Dominio.Dto.Exemplo.Interface;
using Dominio.Entidades;
using ExempleAPI.Servico.Modelos;
using ExempleAPI.Servico.Utilitarios;
using ExemploAPI.Dominio.Modelos.Dto;
using Servico.Servicos.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.Notifications;
using Tnf.Repositories.Uow;

namespace Servico.Servicos
{
    public class ExemploServico : ServicoBase<ExemploEntidade>, IExemploServico
    {
        private readonly INotificationHandler _controleNotificacao;
        private readonly IUnitOfWorkManager _controleTransacao;
        private readonly IExemploRepositorio _Repositorio;
        private readonly IExemploLeituraRepositorio _LeituraRepositorio;
        private readonly IValidacaoExemplo _Validacao;

        public ExemploServico(
           INotificationHandler controleNotificacao,
           IUnitOfWorkManager controleTransacao,
           IExemploRepositorio repositorio,
           IExemploLeituraRepositorio leituraRepositorio,
           IValidacaoExemplo validacao
       ) : base(controleNotificacao, controleTransacao)
        {
            _controleTransacao = controleTransacao;
            _controleNotificacao = controleNotificacao;
            _Repositorio = repositorio;
            _LeituraRepositorio = leituraRepositorio;
            _Validacao = validacao;
        }

       

        protected override async Task<bool> VerificaInconsistencias(ExemploEntidade obj, int operacao)
        {

            return true;
        }
    }
}
