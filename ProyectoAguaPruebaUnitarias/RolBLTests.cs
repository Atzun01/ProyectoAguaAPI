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
    public class RolBLTests
    {
        private static Rol rolinicial = new Rol { Id = 9 }; // Rol existente
        private RolBL rolBL = new RolBL();

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "AdminJose";
            int result = await rolBL.CrearRolAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarRolAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolinicial.Id;
            rol.Nombre = "AdminJose";
            int result = await rolBL.ModificarRolAsync(rol);
            Assert.AreEqual(1, result);

        }

        [TestMethod()]
        public async Task T3EliminarRolAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolinicial.Id;
            var result = await rolBL.EliminarRolAsync(rol);
        Assert.AreNotEqual(0, result);
    }

    [TestMethod()]
    public async Task T4ObtenerRolPorIdAsyncTest()
    {
        var rol = new Rol();
        rol.Id = rolinicial.Id;
        var result = await rolBL.ObtenerRolPorIdAsync(rol.Id);
        Assert.AreEqual(rol.Id, result.Id);
    }

    [TestMethod()]
    public async Task T5ObtenerTodosRolesAsyncTest()
    {
            var result = await rolBL.ObtenerTodosRolesAsync();
        Assert.AreNotEqual(0, result.Count);
    }

        [TestMethod()]
        public async Task T6BuscarRolesAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "a";
            rol.Top_Aux = 5;
            var resulRoles = await rolBL.BuscarRolesAsync(rol);
            Assert.AreEqual(5, resulRoles.Count);
        }
    }

}