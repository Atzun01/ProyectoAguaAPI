using ProyectoAgua.EN;
using ProyectoAgua.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL
{
    public  class DerechoAguaBL
    {
        public  async Task<int> CrearAsync(DerechoAgua pDerechoAgua)
        {
            return await DerechoAguaDAL.CrearAsync(pDerechoAgua);
        }

        public  async Task<int> ModificarAsync(DerechoAgua pDerechoAgua)
        {
            return await DerechoAguaDAL.ModificarAsync(pDerechoAgua);
        }

        public  async Task<int> EliminarAsync(DerechoAgua pDerechoAgua)
        {
            return await DerechoAguaDAL.DeleteAsync(pDerechoAgua);
        }

        public  async Task<DerechoAgua> ObtenerPorIdAsync(DerechoAgua pDerechoAgua)
        {
            return await DerechoAguaDAL.ObtenerPorIdAsync(pDerechoAgua);
        }

        public  async Task<List<DerechoAgua>> ObtenerTodosAsync()
        {
            return await DerechoAguaDAL.ObtenerTodosAsync();
        }

        public  async Task<List<DerechoAgua>> BuscarAsync(DerechoAgua pDerechoAgua)
        {
            return await DerechoAguaDAL.BuscarAsync(pDerechoAgua);
        }
    }
}
