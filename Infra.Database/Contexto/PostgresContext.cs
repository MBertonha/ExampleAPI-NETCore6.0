using ExempleAPI.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.Runtime.Session;

namespace ExempleAPI.Infra.Database.Contexto
{
    internal class PostgresContext : ExemploAPIContexto
    {
        public PostgresContext(DbContextOptions<ExemploAPIContexto> options, ITnfSession session) : base(options, session)
        {
        }
    }
}
