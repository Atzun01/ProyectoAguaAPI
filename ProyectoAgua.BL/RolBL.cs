using ProyectoAgua.DAL;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL
{
    public class RolBL
    {
        // Método para crear un nuevo rol
        public async Task<int> CrearRolAsync(Rol pRol)
        {
            return await RolDAL.CrearRolAsync(pRol);
        }

        public async Task<int> ModificarRolAsync(Rol pRol)
        {
            return await RolDAL.ModificarRolAsync(pRol);
        }

        public async Task<int> EliminarRolAsync(Rol pRol)
        {
            return await RolDAL.DeleteRolAsync(pRol);
        }

        public async Task<Rol> ObtenerRolPorIdAsync(int id)
        {
            var rol = new Rol { Id = id };
            return await RolDAL.ObtenerPorIdAsync(rol);
        }
        public async Task<List<Rol>> ObtenerTodosRolesAsync()
        {
            return await RolDAL.ObtenerTodosAsync();
        }

        public async Task<List<Rol>> BuscarRolesAsync(Rol pRol)
        {
            return await RolDAL.BuscarAsync(pRol);
        }
    }

}
