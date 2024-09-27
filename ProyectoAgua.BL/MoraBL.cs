using ProyectoAgua.EN;
using ProyectoAgua.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL
{
    public class MoraBL
    {
        public  async Task<int> GuardarAsync(Mora  pMora)
        {
            return await MoraDAL.CrearAsync(pMora);
        }

        public  async Task<int> ModificarAsync(Mora pMora)
        {
            return await MoraDAL.ModificarAsync(pMora);
        }

        public  async Task<int> EliminarAsync(Mora pMora)
        {
            return await MoraDAL.DeleteAsync(pMora);
        }

        public  async Task<Mora> ObtenerPorIdAsync(Mora pMora)
        {
            return await MoraDAL.ObtenerPorIdAsync(pMora);
        }

        public  async Task<List<Mora>> ObtenerTodosAsync()
        {
            return await MoraDAL.ObtenerTodosAsync();
        }

        public  async Task<List<Mora>> BuscarAsync(Mora pMora)
        {
            return await MoraDAL.BuscarAsync(pMora);
        }
    }

}
