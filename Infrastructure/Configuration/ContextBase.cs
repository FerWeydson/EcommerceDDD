using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base (options)
        {
        }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }
        private string  GetConnectionString()
        {
            string ConexaoPadrao = "Server=localhost\\sqlexpress; Initial Catalog=EcommerceDDD; Integrated Security=true; TrustServerCertificate=True";
            return ConexaoPadrao;
        }
    }
}
