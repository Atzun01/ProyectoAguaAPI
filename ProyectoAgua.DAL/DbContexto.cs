using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;




namespace ProyectoAgua.DAL
{
    internal class DBContexto:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=hotplaterestaurant;User=root;Password=password;",
                new MySqlServerVersion(new Version(8, 0, 0)));
        }
        /*
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<DerechoAgua> DerechoAguas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Mecha> Mechas { get; set; }
        public DbSet<Mora> Moras { get; set; }
        public DbSet<RegistroAgua> RegistroAguas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        */

    }

}
