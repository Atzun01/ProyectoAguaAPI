//**************************
using Microsoft.EntityFrameworkCore;
using ProyectoAgua.DAL;
using ProyectoAgua.EN;

namespace WaterProject.DAL
{
    public class RegistroAguaDAL
    {
        public static async Task<int> CrearAsync(RegistroAgua pRegistroAgua)
        {
            // Se agarra un rol en la base de datos y lo almacena.
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pRegistroAgua);
                result = await dbContexto.SaveChangesAsync();
            }

            return result;

        }
        public static async Task<int> ModificarAsync(RegistroAgua pRegistroAgua)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var registroAgua = await dbContexto.RegistroAgua.FirstOrDefaultAsync(s => s.Id == pRegistroAgua.Id);
                registroAgua.IdDerechoAgua = pRegistroAgua.IdDerechoAgua;
                registroAgua.Pago = pRegistroAgua.Pago;
                registroAgua.FechaPago = pRegistroAgua.FechaPago;
                dbContexto.Update(pRegistroAgua);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(RegistroAgua pRegistroAgua)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var registroAgua = await dbContexto.RegistroAgua.FirstOrDefaultAsync(x => x.Id == pRegistroAgua.Id);
                //Borrar por medio de cambio de estado
                //Rol.Top_Aux = 2;  // Se coloca el campo de Estado que coloca en su clase
                //dbContexto.Update(rol);
                //resul = await dbContexto.SaveChangesAsync();
                //fin de codigo para eliminar por cambio de estado
                dbContexto.RegistroAgua.Remove(registroAgua);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<RegistroAgua> ObtenerPorIdAsync(RegistroAgua pRegistroAgua)
        /// Obtenemos los datos por Id
        {
            RegistroAgua registroAgua = new RegistroAgua();
            using (var dbContexto = new DBContexto())
            {
                registroAgua = await dbContexto.RegistroAgua.FirstOrDefaultAsync(s => s.Id == pRegistroAgua.Id);

            }
            return registroAgua;
        }

        public static async Task<List<RegistroAgua>> ObtenerTodosAsync()
        /// Obtenemos todos los datos de la base de datos.
        {
            List<RegistroAgua> registroAguas = new List<RegistroAgua>();
            using (var dbContexto = new DBContexto())
            {
                registroAguas = await dbContexto.RegistroAgua.ToListAsync();
            }
            return registroAguas;
        }
        internal static IQueryable<RegistroAgua> QuerySelect(IQueryable<RegistroAgua> pQuery, RegistroAgua pRegistroAgua)
        /// Este metodo permite filtar y ordenar una secuencia de objetos segun los objetos espesificados de un objeto "Rol"
        {
            if (pRegistroAgua.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRegistroAgua.Id);
            if (pRegistroAgua.IdDerechoAgua > 0)
                pQuery = pQuery.Where(s => s.IdDerechoAgua == pRegistroAgua.IdDerechoAgua);
            if (pRegistroAgua.Pago > 0)
                pQuery = pQuery.Where(s => s.Pago == pRegistroAgua.Pago);
            if (pRegistroAgua.FechaPago.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pRegistroAgua.FechaPago.Year, pRegistroAgua.FechaPago.Month, pRegistroAgua.FechaPago.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(1);
                pQuery = pQuery.Where(s => s.FechaPago <= fechaFinal && s.FechaPago <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            return pQuery;
        }
        public static async Task<List<RegistroAgua>> BuscarAsync(RegistroAgua pRegistroAgua)
        {
            var registroAgua = new List<RegistroAgua>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.RegistroAgua.AsQueryable();
                select = QuerySelect(select, pRegistroAgua);
                registroAgua = await select.ToListAsync();
            }
            return registroAgua;
        }
        public static async Task<List<RegistroAgua>> BuscarIncluirDerechoAguaAsync(RegistroAgua pRegistroAgua)
        {
            var registroAguas = new List<RegistroAgua>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.RegistroAgua.AsQueryable();
                select = QuerySelect(select, pRegistroAgua).Include(s => s.DerechoAgua).AsQueryable();
                registroAguas = await select.ToListAsync();
            }
            return registroAguas;
        }
    }
}