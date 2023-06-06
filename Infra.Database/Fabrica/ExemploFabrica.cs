using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.Drivers.DevartPostgreSQL;
using Tnf.Runtime.Session;
using ExempleAPI.Infra.Contexto;

namespace Infra.Database.Fabrica
{
    internal class ExemploFabrica : IDesignTimeDbContextFactory<ExemploAPIContexto>
    {
        public ExemploAPIContexto CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExemploAPIContexto>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);
            PostgreSqlLicense.Validate(connectionString);

            return new ExemploAPIContexto(builder.Options, NullTnfSession.Instance);
        }
    }
}
