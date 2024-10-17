using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL.Tests
{
    [TestClass()]
    public class ConsumoBLTests
    {
        private Consumo consumoinicial = new Consumo { Id = 8, IdDerechoAgua = 1, Mora = "80" };
        private ConsumoBL consumoBL = new ConsumoBL();
        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            Consumo consumo = new Consumo();
            consumo.IdDerechoAgua = consumoinicial.IdDerechoAgua;
            consumo.Mora = "80";
            int result = await consumoBL.CrearAsync(consumo);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            Consumo consumo = new Consumo();
            consumo.Id = consumoinicial.Id;
            consumo.IdDerechoAgua = consumoinicial.IdDerechoAgua;
            consumo.Mora = "200";
            var result = await consumoBL.ModificarAsync(consumo);
            Assert.IsTrue(result == 1);
        }


        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            Consumo consumo = new Consumo();
            consumo.Id = consumoinicial.Id;
            var result = await consumoBL.ObtenerPorIdAsync(consumo);
            Assert.IsTrue(result.Id == consumo.Id);
        }

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            var result = await consumoBL.ObtenerTodosAsync();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            Consumo consumo = new Consumo();
            consumo.IdDerechoAgua = consumoinicial.IdDerechoAgua;
            consumo.Mora = "700";
            consumo.Top_Aux = 10;
            var result = await consumoBL.BuscarAsync(consumo);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task BuscarIncluirDerechoAguaAsyncTest()
        {
            Consumo consumo = new Consumo();
            consumo.IdDerechoAgua = consumoinicial.IdDerechoAgua;
            consumo.Mora = "200";
            consumo.Top_Aux = 10;
            var resultConsumos = await consumoBL.BuscarIncluirDerechoAguaAsync(consumo);
            var ultimoConsumo = resultConsumos.FirstOrDefault();
            Assert.IsTrue(ultimoConsumo.DerechoAgua != null && consumo.IdDerechoAgua == ultimoConsumo.DerechoAgua.Id);
        }


        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            var consumo = new Consumo();
            consumo.Id = consumoinicial.Id;
            int result = await consumoBL.EliminarAsync(consumo);
            Assert.AreNotEqual(0, result);
        }
    }
}