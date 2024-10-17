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
    public class DerechoAguaBLTests
    {
        private static DerechoAgua derechoAguainicial = new DerechoAgua { Id = 5 };
        private DerechoAguaBL derechoAguaBL = new DerechoAguaBL();

        [TestMethod()]
        public async Task T1GuardarAsyncTest()
        {
            var derechoAgua = new DerechoAgua();
            derechoAgua.Nombre = "Mario";
            derechoAgua.Pasaje = "2";
            derechoAgua.Casa = "8y";
            int result = await derechoAguaBL.CrearAsync(derechoAgua);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var derechoAgua = new DerechoAgua();
            derechoAgua.Id = derechoAguainicial.Id;
            derechoAgua.Nombre = "Susana";
            derechoAgua.Pasaje = "3";
            derechoAgua.Casa = "5r";
            int result = await derechoAguaBL.ModificarAsync(derechoAgua);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public async Task T3EliminarAsyncTest()
        {
            var derechoAgua = new DerechoAgua();
            derechoAgua.Id = derechoAguainicial.Id;
            int result = await derechoAguaBL.EliminarAsync(derechoAgua);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var derechoAgua = new DerechoAgua();
            derechoAgua.Id = derechoAguainicial.Id;
            var result = await derechoAguaBL.ObtenerPorIdAsync(derechoAgua);
            Assert.AreEqual(derechoAgua.Id, result.Id);

        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var result = await derechoAguaBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            var derechoAgua = new DerechoAgua();
            derechoAgua.Nombre = "Kevin";
            derechoAgua.Pasaje = "11";
            derechoAgua.Casa = "2t";
            derechoAgua.Top_Aux = 2;
            var resultDerechoAgua = await derechoAguaBL.BuscarAsync(derechoAgua);
            Assert.AreEqual(2, resultDerechoAgua.Count);
        }
    }
}