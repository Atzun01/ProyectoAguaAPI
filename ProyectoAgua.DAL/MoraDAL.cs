using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.DAL
{
    internal class MoraDAL
    {
        public static async Task<int> CrearAsync(Mora pMora)
        {
            // Se agarra un rol en la base de datos y lo almacena.
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pMora);
                result = await dbContexto.SaveChangesAsync();
            }

            return result;

        }
        public static async Task<int> ModificarAsync(Mora pMora)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var mora = await dbContexto.Mora.FirstOrDefaultAsync(s => s.Id == pMora.Id);
                mora.CantidadMora = pMora.CantidadMora;
                dbContexto.Update(pMora);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Mora pMora)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var mora = await dbContexto.Mora.FirstOrDefaultAsync(x => x.Id == pMora.Id);
                //Borrar por medio de cambio de estado
                //Rol.Top_Aux = 2;  // Se coloca el campo de Estado que coloca en su clase
                //dbContexto.Update(rol);
                //resul = await dbContexto.SaveChangesAsync();
                //fin de codigo para eliminar por cambio de estado
                dbContexto.Mora.Remove(mora);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Mora> ObtenerPorIdAsync(Mora pMora)
        /// Obtenemos los damos por Id
        {
            Mora mora = new Mora();
            using (var dbContexto = new DBContexto())
            {
                mora = await dbContexto.Mora.FirstOrDefaultAsync(s => s.Id == pMora.Id);

            }
            return mora;
        }

        public static async Task<List<Mora>> ObtenerTodosAsync()
        /// Obtenemos todos los datos de la base de datos.
        {
            List<Mora> moras = new List<Mora>();
            using (var dbContexto = new DBContexto())
            {
                moras = await dbContexto.Mora.ToListAsync();
            }
            return moras;
        }
        internal static IQueryable<Mora> QuerySelect(IQueryable<Mora> pQuery, Mora pMora)
        /// Este metodo permite filtar y ordenar una secuencia de objetos segun los objetos espesificados de un objeto "Rol"
        {
            if (pMora.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMora.Id);
            if (pMora.IdDerechoAgua > 0)
                pQuery = pQuery.Where(s => s.Id == pMora.IdDerechoAgua);
            if (pMora.CantidadMora > 0)
                pQuery = pQuery.Where(s => s.Id == pMora.CantidadMora);
            return pQuery;
        }
        public static async Task<List<Mora>> BuscarAsync(Mora pMora)
        {
            var moras = new List<Mora>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Mora.AsQueryable();
                select = QuerySelect(select, pMora);
                moras = await select.ToListAsync();
            }
            return moras;
        }
        public static async Task<List<Mora>> BuscarIncluirDerechoAguaAsync(Mora pMora)
        {
            var moras = new List<Mora>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Mora.AsQueryable();
                select = QuerySelect(select, pMora).Include(s => s.DerechoAgua).AsQueryable();
                moras = await select.ToListAsync();
            }
            return moras;
        }
    }
}
