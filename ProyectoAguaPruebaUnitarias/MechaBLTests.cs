using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAgua.BL;
using ProyectoAgua.DAL;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgua.BL.Tests
{
    [TestClass()]
    public class MechaBLTests
    {
        private Mecha mechaInicial = new Mecha { Id = 5, IdDerechoAgua = 1, CantidadMecha =  2};
        private MechaBL mechaBL = new MechaBL();
        [TestMethod()]
        public async Task T1GuardarAsyncTest()
        {
            Mecha mecha = new Mecha();
            mecha.IdDerechoAgua = 1;
            mecha.CantidadMecha = 2;
            int result = await mechaBL.GuardarAsync(mecha);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            Mecha mecha = new Mecha();
            mecha.Id = 1;
            mecha.IdDerechoAgua = 1;
            mecha.CantidadMecha = 1;
            var result = await mechaBL.ModificarAsync(mecha);
            Assert.IsTrue(result == 1);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            Mecha mecha = new Mecha();
            mecha.Id = mechaInicial.Id;
            var result = await mechaBL.ObtenerPorIdAsync(mecha);
            Assert.IsNull(result);
        }

        [TestMethod()]
        public async Task  T4ObtenerTodosAsyncTest()
        {
            var result = await mechaBL.ObtenerTodosAsync();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            Mecha mecha = new Mecha();
            mecha.IdDerechoAgua = 5;
            mecha.CantidadMecha = 2;
            var result = await mechaBL.BuscarAsync(mecha);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var mecha = new Mecha();
            mecha.Id = mechaInicial.Id;
            var result = await mechaBL.EliminarAsync(mecha);
            Assert.AreNotEqual(0, result);
        }
    }
}