using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Estado>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Tarea>()
                .HasOne(e => e.Estado)
                .WithMany()
                .HasForeignKey(p=>p.FkIdEstado);

            base.OnModelCreating(modelBuilder);
        }
    }
}
