using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;
using WaterProject.EN;

namespace ProyectoAgua.DAL
{
    public class RolDAL
    {
        public static async Task<int> CrearRolAsync(Rol pRol)
        {
            int result = 0;
            try
            {
                using (var dbContext = new DBContexto())
                {
                    dbContext.Add(pRol);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //comente

                throw new Exception(ex.Message);
            }
            return result;
        }

        public static async Task<int> ModificarRolAsync(Rol pRol)
        {
            int result = 0;
            string error = "";
            try
            {
                using (var dbContext = new DBContexto())
                {
                    var rol = await dbContext.Rol.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                    if (rol != null)
                    {
                        rol.Nombre = pRol.Nombre;
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El rol no existe.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error interno", ex);
            }
            return result;
        }

        public static async Task<int> DeleteRolAsync(Rol pRol)
        {
            int result = 0;
            try
            {
                using (var dbContext = new DBContexto())
                {
                    var rol = await dbContext.Rol.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                    if (rol != null)
                    {
                        dbContext.Rol.Remove(rol);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El rol no existe.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error", ex);
            }
            return result;
        }

        public static async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        {

            try
            {
                Rol rol = new Rol();
                using (var dbContext = new DBContexto())
                {
                    rol = await dbContext.Rol.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                }
                return rol;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error interno", ex);
            }
        }

        public static async Task<List<Rol>> ObtenerTodosAsync()
        {
            try
            {
                List<Rol> rol = new List<Rol>();
                using (var dbContext = new DBContexto())
                {
                    rol = await dbContext.Rol.ToListAsync();
                }
                return rol;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error interno", ex);
            }
        }

        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery, Rol pRol)
        {
            if(pRol.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRol.Id);
            if (!string.IsNullOrWhiteSpace(pRol.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pRol.Nombre));
            return pQuery;
        }

        public static async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            try
            {
                List<Rol> rol = new List<Rol>();
                using(var dbContext = new DBContexto())
                {
                    var select =  dbContext.Rol.AsQueryable();
                    select = QuerySelect(select, pRol);
                    rol = await select.ToListAsync();
                }
                return rol;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error interno", ex);
            }
        }
    }
}
