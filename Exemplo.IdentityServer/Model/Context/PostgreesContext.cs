using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore;
using Tnf.EntityFrameworkCore;
using Tnf.Runtime.Session;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Exemplo.IdentityServer.Model.Context
{
    public class PostgreesContext : IdentityDbContext<ApplicationUser>
    {
        public PostgreesContext(DbContextOptions<PostgreesContext> options) : base(options)
        {

        }
    }
}
