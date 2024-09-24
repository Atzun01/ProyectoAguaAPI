using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.DAL
{
    internal class DerechoAguaDAL
    {
        public static async Task<int> CrearAsync(DerechoAgua pDerechoAgua)
        {
            // Se agarra un rol en la base de datos y lo almacena.
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pDerechoAgua);
                result = await dbContexto.SaveChangesAsync();
            }

            return result;

        }
        public static async Task<int> ModificarAsync(DerechoAgua pDerechoAgua)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var derechoAgua = await dbContexto.DerechoAgua.FirstOrDefaultAsync(s => s.Id == pDerechoAgua.Id);
                derechoAgua.Nombre = pDerechoAgua.Nombre;
                derechoAgua.Casa = pDerechoAgua.Casa;
                derechoAgua.Pasaje = pDerechoAgua.Pasaje;
                dbContexto.Update(derechoAgua);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(DerechoAgua pDerechoAgua)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var derechoAgua = await dbContexto.DerechoAgua.FirstOrDefaultAsync(x => x.Id == pDerechoAgua.Id);
                //Borrar por medio de cambio de estado
                //Rol.Top_Aux = 2;  // Se coloca el campo de Estado que coloca en su clase
                //dbContexto.Update(rol);
                //resul = await dbContexto.SaveChangesAsync();
                //fin de codigo para eliminar por cambio de estado
                dbContexto.DerechoAgua.Remove(derechoAgua);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<DerechoAgua> ObtenerPorIdAsync(DerechoAgua pDerechoAgua)
        /// Obtenemos los damos por Id
        {
            DerechoAgua derechoAgua = new DerechoAgua();
            using (var dbContexto = new DBContexto())
            {
                derechoAgua = await dbContexto.DerechoAgua.FirstOrDefaultAsync(x => x.Id == pDerechoAgua.Id);

            }
            return derechoAgua;
        }

        public static async Task<List<DerechoAgua>> ObtenerTodosAsync()
        /// Obtenemos todos los datos de la base de datos.
        {
            List<DerechoAgua> derechoAguas = new List<DerechoAgua>();
            using (var dbContexto = new DBContexto())
            {
                derechoAguas = await dbContexto.DerechoAgua.ToListAsync();
            }
            return derechoAguas;
        }
        internal static IQueryable<DerechoAgua> QuerySelect(IQueryable<DerechoAgua> pQuery, DerechoAgua pDerechoAgua)
        /// Este metodo permite filtar y ordenar una secuencia de objetos segun los objetos espesificados de un objeto "Rol"
        {
            if (pDerechoAgua.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pDerechoAgua.Id);
            if (!string.IsNullOrWhiteSpace(pDerechoAgua.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pDerechoAgua.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pDerechoAgua.Pasaje))
                pQuery = pQuery.Where(s => s.Pasaje.Contains(pDerechoAgua.Pasaje));
            if (!string.IsNullOrWhiteSpace(pDerechoAgua.Casa))
                pQuery = pQuery.Where(s => s.Casa.Contains(pDerechoAgua.Casa));
            if (pDerechoAgua.Top_Aux > 0)
                pQuery = pQuery.Take(pDerechoAgua.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<DerechoAgua>> BuscarAsync(DerechoAgua pDerechoAgua)
        {
            var derechoAguas = new List<DerechoAgua>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.DerechoAgua.AsQueryable();
                select = QuerySelect(select, pDerechoAgua);
                derechoAguas = await select.ToListAsync();
            }
            return derechoAguas;
        }
    }
}
