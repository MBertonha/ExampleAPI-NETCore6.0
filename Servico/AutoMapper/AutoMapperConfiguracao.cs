using Microsoft.Extensions.DependencyInjection;
using Servico.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAPI.Servico.AutoMapper
{
    public static class AutoMapperConfiguracao
    {
        public static void AddAutoMapperTnf(this IServiceCollection services)
        {
            services.AddTnfAutoMapper(config =>
            {
                config.AddProfile<SystemLinqProfile>();
            });
        }
    }
}
