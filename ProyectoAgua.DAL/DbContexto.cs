using ProyectoAgua.EN;
using Microsoft.EntityFrameworkCore;

namespace ProyectoAgua.DAL
{
    public class DBContexto:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=proyectoagua_api;User=root;Password=123456;",
                new MySqlServerVersion(new Version(8, 0, 0)));
        }

        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<DerechoAgua> DerechoAgua { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Mecha> Mecha { get; set; }
        public DbSet<Mora> Mora { get; set; }
        public DbSet<RegistroAgua> RegistroAgua { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DerechoAgua>()
        //        .HasOne(d => d.Consumos)
        //        .WithMany()
        //        .HasForeignKey(d => d.Id);

        //    modelBuilder.Entity<DerechoAgua>()
        //        .HasOne(d => d.Mechas)
        //        .WithMany()
        //        .HasForeignKey(d => d.Id);

        //    modelBuilder.Entity<DerechoAgua>()
        //        .HasOne(d => d.Moras)
        //        .WithMany()
        //        .HasForeignKey(d => d.Id);

        //    modelBuilder.Entity<DerechoAgua>()
        //        .HasOne(d => d.RegistroAguas)
        //        .WithMany()
        //        .HasForeignKey(d => d.Id);
        //}


    }

}
