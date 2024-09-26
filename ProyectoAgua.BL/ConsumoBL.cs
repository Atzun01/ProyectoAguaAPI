using ProyectoAgua.DAL;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL
{
    public class ConsumoBL
    {
        // Método para crear un nuevo registro de Consumo
        public async Task<int> CrearAsync(Consumo pConsumo)
        {
            return await ConsumoDAL.CrearAsync(pConsumo);
        }

        // Método para modificar un registro de Consumo
        public async Task<int> ModificarAsync(Consumo pConsumo)
        {
            return await ConsumoDAL.ModificarAsync(pConsumo);
        }

        // Método para eliminar un registro de Consumo
        public async Task<int> EliminarAsync(Consumo pConsumo)
        {
            return await ConsumoDAL.DeleteAsync(pConsumo);
        }

        // Método para obtener un registro de Consumo por su ID
        public async Task<Consumo> ObtenerPorIdAsync(Consumo pConsumo)
        {
            return await ConsumoDAL.ObtenerPorIdAsync(pConsumo);
        }

        // Método para obtener todos los registros de Consumo
        public async Task<List<Consumo>> ObtenerTodosAsync()
        {
            return await ConsumoDAL.ObtenerTodosAsync();
        }

        // Método para buscar registros de Consumo basados en criterios
        public async Task<List<Consumo>> BuscarAsync(Consumo pConsumo)
        {
            return await ConsumoDAL.BuscarAsync(pConsumo);
        }

        // Método para buscar registros de Consumo e incluir información de la tabla relacionada DerechoAgua
        public async Task<List<Consumo>> BuscarIncluirDerechoAguaAsync(Consumo pConsumo)
        {
            return await ConsumoDAL.BuscarIncluirDerechoAguaAsync(pConsumo);
        }

    }
}
