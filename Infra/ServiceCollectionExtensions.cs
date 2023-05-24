using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {

            return services;
        }
    }
}
