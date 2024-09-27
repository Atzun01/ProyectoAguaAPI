using ProyectoAgua.EN;
using ProyectoAgua.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL
{
    public class MechaBL
    {
        public  async Task<int> GuardarAsync(Mecha pMecha)
        {
            return await MechaDAL.CrearAsync(pMecha);
        }

        public  async Task<int> ModificarAsync(Mecha pMecha)
        {
            return await MechaDAL.ModificarAsync(pMecha);
        }

        public  async Task<int> EliminarAsync(Mecha pMecha)
        {
            return await MechaDAL.DeleteAsync(pMecha);
        }

        public  async Task<Mecha> ObtenerPorIdAsync(Mecha pMecha)
        {
            return await MechaDAL.ObtenerPorIdAsync(pMecha);
        }

        public  async Task<List<Mecha>> ObtenerTodosAsync()
        {
            return await MechaDAL.ObtenerTodosAsync();
        }

        public  async Task<List<Mecha>> BuscarAsync(Mecha pMecha)
        {
            return await MechaDAL.BuscarAsync(pMecha);
        }
    }
}

