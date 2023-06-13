using Microsoft.Extensions.DependencyInjection;
using Servico.Servicos;
using Servico.Servicos.Validacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Servicos
{
    public static class ServicosConfiguracao
    {
        public static void AddServicosConfiguracao(this IServiceCollection services)
        {
            services.AddTransient<IExemploServico, ExemploServico>();
            services.AddTransient<IValidacaoExemplo, ValidacaoExemplo>();
        }
    }
}
