using Microsoft.EntityFrameworkCore;
using Otiva.DataAccess.EntityConfiguration.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataBase
{
    public class UareNotAloneContext : DbContext
    {
        public UareNotAloneContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActionConfiguraration());

        }
    }
}
