using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.DAL
{
    public class EmpleadoDAL
    {
        public static async Task<int> CrearAsync(Empleado pEmpleado)
        {
            // Se agarra un rol en la base de datos y lo almacena.
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pEmpleado);
                result = await dbContexto.SaveChangesAsync();
            }

            return result;

        }
        public static async Task<int> ModificarAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var empleado = await dbContexto.Empleado.FirstOrDefaultAsync(s => s.Id == pEmpleado.Id);
                empleado.Nombre = pEmpleado.Nombre;
                empleado.Direccion = pEmpleado.Direccion;
                empleado.Entrada = pEmpleado.Entrada;
                dbContexto.Update(empleado);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Empleado pEmpleado)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var empleado = await dbContexto.Empleado.FirstOrDefaultAsync(x => x.Id == pEmpleado.Id);
                //Borrar por medio de cambio de estado
                //Rol.Top_Aux = 2;  // Se coloca el campo de Estado que coloca en su clase
                //dbContexto.Update(rol);
                //resul = await dbContexto.SaveChangesAsync();
                //fin de codigo para eliminar por cambio de estado
                dbContexto.Empleado.Remove(empleado);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Empleado> ObtenerPorIdAsync(Empleado pEmpleado)
        /// Obtenemos los damos por Id
        {
            Empleado empleado = new Empleado();
            using (var dbContexto = new DBContexto())
            {
                empleado = await dbContexto.Empleado.FirstOrDefaultAsync(x => x.Id == pEmpleado.Id);

            }
            return empleado;
        }

        public static async Task<List<Empleado>> ObtenerTodosAsync()
        /// Obtenemos todos los datos de la base de datos.
        {
            List<Empleado> empleados = new List<Empleado>();
            using (var dbContexto = new DBContexto())
            {
                empleados = await dbContexto.Empleado.ToListAsync();
            }
            return empleados;
        }
        internal static IQueryable<Empleado> QuerySelect(IQueryable<Empleado> pQuery, Empleado pEmpleado)
        /// Este metodo permite filtar y ordenar una secuencia de objetos segun los objetos espesificados de un objeto "Rol"
        {
            if (pEmpleado.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEmpleado.Id);
            if (!string.IsNullOrWhiteSpace(pEmpleado.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEmpleado.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pEmpleado.Direccion))
                pQuery = pQuery.Where(s => s.Direccion.Contains(pEmpleado.Direccion));
            if (!string.IsNullOrWhiteSpace(pEmpleado.Entrada))
                pQuery = pQuery.Where(s => s.Entrada.Contains(pEmpleado.Entrada));
            if (pEmpleado.Top_Aux > 0)
                pQuery = pQuery.Take(pEmpleado.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            var empleados = new List<Empleado>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Empleado.AsQueryable();
                select = QuerySelect(select, pEmpleado);
                empleados = await select.ToListAsync();
            }
            return empleados;
        }
    }
}
