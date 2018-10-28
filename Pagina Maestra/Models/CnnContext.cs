using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Maestra.Models
{
    public class CnnContext : DbContext
    {
        public DbSet<Noticia> Noticias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["noticias_cnn"].ToString();
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Noticia>().ToTable("Noticia");
            modelBuilder.Entity<Noticia>().HasKey(p => p.Id);
        }
    }
}