using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Maestra.Models
{
    public class CurriculumnContext : DbContext
    {
        public DbSet<Cv> Cvs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["curriculumn"].ToString();
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cv>().ToTable("cv");
            modelBuilder.Entity<Cv>().HasKey(p => p.Id);
        }
    }
}