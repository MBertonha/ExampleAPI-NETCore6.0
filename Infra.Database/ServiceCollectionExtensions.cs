using ExempleAPI.Infra.Contexto;
using ExempleAPI.Infra.Database.Contexto;
using ExemploAPI.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleAPI.Infra.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCoreSqlServer(this IServiceCollection services, string conString)
        {
            services.AddEfCore();

            services.AddTnfDbContext<ExemploAPIContexto, PostgresContext>(config =>
            {
                config.DbContextOptions.UseSqlServer(conString);
            });

            return services;
        }
    }
}
