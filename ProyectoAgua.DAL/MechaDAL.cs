using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.DAL
{
    public class MechaDAL
    {
        public static async Task<int> CrearAsync(Mecha pMecha)
        {
            // Se agarra un rol en la base de datos y lo almacena.
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pMecha);
                result = await dbContexto.SaveChangesAsync();
            }

            return result;

        }
        public static async Task<int> ModificarAsync(Mecha pMecha)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var mecha = await dbContexto.Mecha.FirstOrDefaultAsync(s => s.Id == pMecha.Id);
                mecha.CantidadMecha = pMecha.CantidadMecha;
                dbContexto.Update(mecha);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Mecha pMecha)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var mecha = await dbContexto.Mecha.FirstOrDefaultAsync(x => x.Id == pMecha.Id);
                //Borrar por medio de cambio de estado
                //Rol.Top_Aux = 2;  // Se coloca el campo de Estado que coloca en su clase
                //dbContexto.Update(rol);
                //resul = await dbContexto.SaveChangesAsync();
                //fin de codigo para eliminar por cambio de estado
                dbContexto.Mecha.Remove(mecha);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Mecha> ObtenerPorIdAsync(Mecha pMecha)
        /// Obtenemos los damos por Id
        {
            Mecha mecha = new Mecha();
            using (var dbContexto = new DBContexto())
            {
                mecha = await dbContexto.Mecha.FirstOrDefaultAsync(s => s.Id == pMecha.Id);

            }
            return mecha;
        }

        public static async Task<List<Mecha>> ObtenerTodosAsync()
        /// Obtenemos todos los datos de la base de datos.
        {
            List<Mecha> mechas = new List<Mecha>();
            using (var dbContexto = new DBContexto())
            {
                mechas = await dbContexto.Mecha.ToListAsync();
            }
            return mechas;
        }
        internal static IQueryable<Mecha> QuerySelect(IQueryable<Mecha> pQuery, Mecha pMecha)
        /// Este metodo permite filtar y ordenar una secuencia de objetos segun los objetos espesificados de un objeto "Rol"
        {
            if (pMecha.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMecha.Id);
            if (pMecha.IdDerechoAgua > 0)
                pQuery = pQuery.Where(s => s.Id == pMecha.IdDerechoAgua);
            if (pMecha.CantidadMecha > 0)
                pQuery = pQuery.Where(s => s.Id == pMecha.CantidadMecha);
            return pQuery;
        }
        public static async Task<List<Mecha>> BuscarAsync(Mecha pMecha)
        {
            var mechas = new List<Mecha>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Mecha.AsQueryable();
                select = QuerySelect(select, pMecha);
                mechas = await select.ToListAsync();
            }
            return mechas;
        }
        public static async Task<List<Mecha>> BuscarIncluirDerechoAguaAsync(Mecha pMecha)
        {
            var mechas = new List<Mecha>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Mecha.AsQueryable();
                select = QuerySelect(select, pMecha).Include(s => s.DerechoAgua).AsQueryable();
                mechas = await select.ToListAsync();
            }
            return mechas;
        }
    }
}
