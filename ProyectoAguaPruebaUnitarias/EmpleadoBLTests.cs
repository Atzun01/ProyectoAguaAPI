using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAgua.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoAgua.EN;

namespace ProyectoAgua.BL.Tests
{
    [TestClass()]
    public class EmpleadoBLTests
    {
        private static Empleado empleadoInical = new Empleado {Id = 5};//Empleado eistente 
        private EmpleadoBL empleadoBL = new EmpleadoBL();
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Nombre = "Mario"; 
            empleado.Direccion = "Sonsonate"; 
            empleado.Entrada = "2"; 
            int result = await empleadoBL.CrearAsync(empleado);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInical.Id;
            empleado.Nombre = "Mario";
            empleado.Direccion = "Santa Ana";
            empleado.Entrada = "5";
            int result = await empleadoBL.ModificarAsync(empleado);
            Assert.AreEqual(1,result);
        }

        [TestMethod()]
        public async Task T3EliminarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInical.Id;
            empleado.Nombre = "Mario";
            empleado.Direccion = "Santa Ana";
            empleado.Entrada = "5";
            int result = await empleadoBL.ModificarAsync(empleado);
            Assert.AreEqual(1,result);
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Id = empleadoInical.Id;
            var result = await empleadoBL.ObtenerPorIdAsync(empleado);
            Assert.AreEqual(empleado.Id, result.Id);
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var result = await empleadoBL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            var empleado = new Empleado();
            empleado.Nombre = "Mario";
            empleado.Direccion = "Santa Ana";
            empleado.Entrada = "5";
            empleado.Top_Aux = 1;
            var result = await empleadoBL.BuscarAsync(empleado);
            Assert.AreEqual(1, result.Count);
        }
    }
}