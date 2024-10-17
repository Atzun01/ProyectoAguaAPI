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
    public class RegistroAguaBLTests
    {
        private RegistroAgua registroaguainicial = new RegistroAgua { Id = 1, IdDerechoAgua = 1,  Pago = 350 };
        private RegistroAguaBL registroAguaBL = new RegistroAguaBL();

        [TestMethod()]
        public async Task CrearRegistroAguaAsyncTest()
        {
            RegistroAgua registroAgua = new RegistroAgua();
            registroAgua.IdDerechoAgua = registroaguainicial.IdDerechoAgua;
            registroAgua.Pago = 30;
            registroAgua.FechaPago = new DateTime(2024, 10, 10); 
            int result = await registroAguaBL.CrearRegistroAguaAsync(registroAgua);
            Assert.AreEqual(1, result);
        }


        [TestMethod()]
        public async Task ModificarRegistroAguaAsyncTest()
        {
            RegistroAgua registroAgua = new RegistroAgua();
            registroAgua.Id = registroaguainicial.Id;
            registroAgua.IdDerechoAgua = registroaguainicial.IdDerechoAgua;
            registroAgua.Pago = 250;
            var result = await registroAguaBL.ModificarRegistroAguaAsync(registroAgua);
            Assert.IsTrue(result == 1);
        }


        [TestMethod()]
        public async Task ObtenerRegistroAguaPorIdAsyncTest()
        {
            RegistroAgua registroAgua = new RegistroAgua();
            registroAgua.Id = registroaguainicial.Id;
            var result = await registroAguaBL.ObtenerRegistroAguaPorIdAsync(registroAgua.Id);
            Assert.IsTrue(result.Id == registroAgua.Id);
        }

        [TestMethod()]
        public async Task ObtenerTodosRegistrosAguaAsyncTest()
        {
            var result = await registroAguaBL.ObtenerTodosRegistrosAguaAsync();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public async Task BuscarRegistrosAguaAsyncTest()
        {
            RegistroAgua registroAgua = new RegistroAgua();
            registroAgua.IdDerechoAgua = registroaguainicial.IdDerechoAgua;
            registroAgua.Pago = 240;
            registroAgua.FechaPago = new DateTime(2024, 10, 10);
            registroAgua.Top_Aux = 10;
            var result = await registroAguaBL.BuscarRegistrosAguaAsync(registroAgua);
            Assert.AreNotEqual(1, result.Count);
        }

        [TestMethod()]
        public async Task BuscarIncluirDerechoAguaAsyncTest()
        {
            RegistroAgua registroAgua = new RegistroAgua();
            registroAgua.IdDerechoAgua = registroaguainicial.IdDerechoAgua;
            registroAgua.Pago = 30;
            registroAgua.FechaPago = new DateTime(2024, 10, 10);
            registroAgua.Top_Aux = 10;
            var resultRegistroAgua = await registroAguaBL.BuscarIncluirDerechoAguaAsync(registroAgua);
            var ultimoRegistroAgua = resultRegistroAgua.FirstOrDefault();
            Assert.IsTrue(ultimoRegistroAgua.DerechoAgua != null && registroAgua.IdDerechoAgua == ultimoRegistroAgua.DerechoAgua.Id);
        }


        [TestMethod()]
        public async Task EliminarRegistroAguaAsyncTest()
        {
            var registroAgua = new RegistroAgua();
            registroAgua.Id = registroaguainicial.Id;
            int result = await registroAguaBL.EliminarRegistroAguaAsync(registroAgua);
            Assert.AreNotEqual(0, result);
        }
    }
}