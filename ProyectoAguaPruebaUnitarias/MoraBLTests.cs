using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAgua.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAgua.EN;
using ProyectoAgua.DAL;


namespace ProyectoAgua.BL.Tests
{
    [TestClass()]
    public class MoraBLTests
    {
        private Mora moraInicial = new Mora {Id = 2, IdDerechoAgua = 1 , CantidadMora = 2 };
        private MoraBL moraBL = new MoraBL();
        [TestMethod()]
        public async Task  T1GuardarAsyncTest()
        {
            Mora mora = new Mora();
            mora.IdDerechoAgua = 1;
            mora.CantidadMora = 2;
            int result = await moraBL.GuardarAsync(mora);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            Mora mora = new Mora();
            mora.Id = 1;
            mora.IdDerechoAgua = 1;
            mora.CantidadMora = 1;
            var result = await moraBL.ModificarAsync(mora);
            Assert.IsTrue(result == 1);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            Mora mora = new Mora();
            mora.Id = moraInicial.Id;
            var result = await moraBL.ObtenerPorIdAsync(mora);
            Assert.IsNull(result);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var result = await moraBL.ObtenerTodosAsync();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            Mora mora = new Mora();
            mora.IdDerechoAgua = 2;
            mora.CantidadMora = 2;
            var result = await moraBL.BuscarAsync(mora);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {

            var mora = new Mora();
            mora.Id = moraInicial.Id;
            var result = await moraBL.EliminarAsync(mora);
            Assert.AreNotEqual(0, result);

        }
    }
  
}