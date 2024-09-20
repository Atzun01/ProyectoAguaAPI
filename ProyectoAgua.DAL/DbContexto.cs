using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;




namespace ProyectoAgua.DAL
{
    internal class DBContexto:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=hotplaterestaurant;User=root;Password=password;",
                new MySqlServerVersion(new Version(8, 0, 0)));
        }
    
    }
}
