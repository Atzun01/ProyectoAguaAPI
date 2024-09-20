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
    }
}
