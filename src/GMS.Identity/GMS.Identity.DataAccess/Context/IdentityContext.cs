using GMS.Identity.Core.Domain.Administration;
using GMS.Identity.DataAccess.ContextConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.DataAccess.Context
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("identity");
            //modelBuilder.UseSerialColumns();
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
