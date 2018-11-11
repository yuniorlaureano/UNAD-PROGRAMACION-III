using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Pagina_Maestra.Models
{
    public class ComentarioContext: DbContext
    {
        public DbSet<Contenido> Contenidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["comentario"].ToString();
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contenido>().ToTable("contenido");
            modelBuilder.Entity<Contenido>().Property(p => p.Content).HasColumnName("Contenido");
        }
    }
}