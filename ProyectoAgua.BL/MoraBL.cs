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
        public static async Task<int> GuardarAsync(Mora  pMora)
        {
            return await MoraDAL.CrearAsync(pMora);
        }

        public static async Task<int> ModificarAsync(Mora pMora)
        {
            return await MoraDAL.ModificarAsync(pMora);
        }

        public static async Task<int> EliminarAsync(Mora pMora)
        {
            return await MoraDAL.DeleteAsync(pMora);
        }

        public static async Task<Mora> ObtenerPorIdAsync(Mora pMora)
        {
            return await MoraDAL.ObtenerPorIdAsync(pMora);
        }

        public static async Task<List<Mora>> ObtenerTodosAsync()
        {
            return await MoraDAL.ObtenerTodosAsync();
        }

        public static async Task<List<Mora>> BuscarAsync(Mora pMora)
        {
            return await MoraDAL.BuscarAsync(pMora);
        }
    }

}
