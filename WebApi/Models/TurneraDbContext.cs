using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Models;

#nullable disable

namespace WebApi.Models
{
    public partial class TurneraDbContext : DbContext
    {
        public DbSet<Sector> Sectores {get;set;}
        public DbSet<Turno> Turnos {get;set;}

        public DbSet<Usuario> Usuarios {get;set;}


        public TurneraDbContext()
        {
        }

        public TurneraDbContext(DbContextOptions<TurneraDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=192.168.99.100;Database=Turnera;user=sa;password=Password_123; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<WebApi.Models.Hospital> Hospital { get; set; }

        public DbSet<WebApi.Models.Patient> Patient { get; set; }

        public DbSet<WebApi.Models.Doctor> Doctor { get; set; }

        public DbSet<WebApi.Models.WorkDay> WorkDay { get; set; }

        public DbSet<WebApi.Models.WaitingList> WaitingList { get; set; }

        public DbSet<WebApi.Models.Specialization> Specialization { get; set; }
    }
}
