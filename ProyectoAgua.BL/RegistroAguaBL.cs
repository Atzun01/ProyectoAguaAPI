using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterProject.DAL;

namespace ProyectoAgua.BL
{
    public class RegistroAguaBL
    {
        // Método para crear un nuevo registro de agua
        public async Task<int> CrearRegistroAguaAsync(RegistroAgua pRegistroAgua)
        {
            return await RegistroAguaDAL.CrearAsync(pRegistroAgua);
        }

        // Método para modificar un registro existente de agua
        public async Task<int> ModificarRegistroAguaAsync(RegistroAgua pRegistroAgua)
        {
            return await RegistroAguaDAL.ModificarAsync(pRegistroAgua);
        }

        // Método para eliminar un registro de agua
        public async Task<int> EliminarRegistroAguaAsync(RegistroAgua pRegistroAgua)
        {
            return await RegistroAguaDAL.DeleteAsync(pRegistroAgua);
        }

        // Método para obtener un registro de agua por ID
        public async Task<RegistroAgua> ObtenerRegistroAguaPorIdAsync(int id)
        {
            var registroAgua = new RegistroAgua { Id = id };
            return await RegistroAguaDAL.ObtenerPorIdAsync(registroAgua);
        }

        // Método para obtener todos los registros de agua
        public async Task<List<RegistroAgua>> ObtenerTodosRegistrosAguaAsync()
        {
            return await RegistroAguaDAL.ObtenerTodosAsync();
        }

        // Método para buscar registros de agua con filtros
        public async Task<List<RegistroAgua>> BuscarRegistrosAguaAsync(RegistroAgua pRegistroAgua)
        {
            return await RegistroAguaDAL.BuscarAsync(pRegistroAgua);
        }

        // Método para buscar registros de agua e incluir datos de DerechoAgua
        public async Task<List<RegistroAgua>> BuscarIncluirDerechoAguaAsync(RegistroAgua pRegistroAgua)
        {
            return await RegistroAguaDAL.BuscarIncluirDerechoAguaAsync(pRegistroAgua);
        }
    }

}
