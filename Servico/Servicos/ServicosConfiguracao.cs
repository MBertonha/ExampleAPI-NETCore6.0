using Microsoft.Extensions.DependencyInjection;
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
            //services.AddTransient<IJpvServico, JpvServico>();
            //services.AddTransient<IValidacaoJpv, ValidacaoJpv>();
        }
    }
}
