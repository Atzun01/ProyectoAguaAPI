using Microsoft.EntityFrameworkCore;
using ProyectoAgua.EN;

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

                throw new Exception(ex.Message);
			}
            return result;
        }

        public static async Task<int> ModificarRolAsync(Rol pRol)
        {
            int result = 0;
            try
            {
                using (var dbContext = new DBContexto())
                {
                    var rol = await dbContext.Roles.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                    if (rol != null)
                    {
                        dbContext.Update(rol);
                        result = await dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error interno");
            }
            return result;
        }
    }
}
