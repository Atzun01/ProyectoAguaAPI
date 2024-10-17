
using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.DAL
{
    public class ConsumoDAL
    {
        public static async Task<int> CrearAsync(Consumo pConsumo)
        {
            // Se agarra un rol en la base de datos y lo almacena.
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pConsumo);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;

        }
        public static async Task<int> ModificarAsync(Consumo pConsumo)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var consumo = await dbContexto.Consumo.FirstOrDefaultAsync(s => s.Id == pConsumo.Id);
                consumo.Mora = pConsumo.Mora;
                dbContexto.Update(consumo);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Consumo pConsumo)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var consumo = await dbContexto.Consumo.FirstOrDefaultAsync(x => x.Id == pConsumo.Id);
                //Borrar por medio de cambio de estado
                //Rol.Top_Aux = 2;  // Se coloca el campo de Estado que coloca en su clase
                //dbContexto.Update(rol);
                //resul = await dbContexto.SaveChangesAsync();
                //fin de codigo para eliminar por cambio de estado
                dbContexto.Consumo.Remove(consumo);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Consumo> ObtenerPorIdAsync(Consumo pConsumo)
        /// Obtenemos los damos por Id
        {
            Consumo consumo = new Consumo();
            using (var dbContexto = new DBContexto())
            {
                consumo = await dbContexto.Consumo.FirstOrDefaultAsync(s => s.Id == pConsumo.Id);

            }
            return consumo;
        }

        public static async Task<List<Consumo>> ObtenerTodosAsync()
        /// Obtenemos todos los datos de la base de datos.
        {
            List<Consumo> consumos = new List<Consumo>();
            using (var dbContexto = new DBContexto())
            {
                consumos = await dbContexto.Consumo.ToListAsync();
            }
            return consumos;
        }
        internal static IQueryable<Consumo> QuerySelect(IQueryable<Consumo> pQuery, Consumo pConsumo)
        /// Este metodo permite filtar y ordenar una secuencia de objetos segun los objetos espesificados de un objeto "Rol"
        {
            if (pConsumo.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pConsumo.Id);
            if (pConsumo.IdDerechoAgua > 0)
                pQuery = pQuery.Where(s => s.Id == pConsumo.IdDerechoAgua);
            if (!string.IsNullOrWhiteSpace(pConsumo.Mora))
                pQuery = pQuery.Where(s => s.Mora == pConsumo.Mora);
            return pQuery;
        }
        public static async Task<List<Consumo>> BuscarAsync(Consumo pConsumo)
        {
            var consumos = new List<Consumo>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Consumo.AsQueryable();
                select = QuerySelect(select, pConsumo);
                consumos = await select.ToListAsync();
            }
            return consumos;
        }
        public static async Task<List<Consumo>> BuscarIncluirDerechoAguaAsync(Consumo pConsumo)
        {
            var consumos = new List<Consumo>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Consumo.AsQueryable();
                select = QuerySelect(select, pConsumo).Include(s => s.DerechoAgua).AsQueryable();
                consumos = await select.ToListAsync();
            }
            return consumos;
        }
    }
}
