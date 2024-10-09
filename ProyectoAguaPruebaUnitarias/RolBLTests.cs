using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAgua.BL;
using ProyectoAgua.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ProyectoAgua.BL.Tests
//{
//    [TestClass()]
//    public class RolBLTests
//    {
//        private static Rol rolinicial = new Rol { Id = 24 }; // Rol existente
//        private RolBL rolBL = new RolBL();

//        public async Task T1CrearAsyncTest()
//        {
//            var rol = new Rol();
//            rol.Nombre = "Admin 3";
//            int result = await rolBL.CrearRolAsync(rol);
//            Assert.AreNotEqual(0, result);
//        }

//        [TestMethod()]
//        public async Task T2ModificarRolAsyncTest()
//        {
//            var rol = new Rol();
//            rol.Id = rolinicial.Id;
//            rol.Nombre = "Admin33";
//            int result = await rolBL.ModificarRolAsync(rol);
//            Assert.AreEqual(1, result);

//        }

//        [TestMethod()]
//        //public void EliminarRolAsyncTest()
//        //{
        //    var rol = Rol();
        //    rol.Id = rolInicil.Id
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public async void ObtenerRolPorIdAsyncTest()
        //{
        //    var rol = Rol();
        //    rol.Id = rolinicial.Id;
        //    var result = await rolBL.ModificarAsync(rol);
        //    Assert.AreEqual(rol.Id, result.Id);
        //}

        //[TestMethod()]
        //public void ObtenerTodosRolesAsyncTest()
        //{
        //    var result =
        //    Assert.Fail();
        //}

    //    //[TestMethod()]
    //    //public void BuscarRolesAsyncTest()
    //    //{
    //    //    Assert.Fail();
    //    //}
    //}

//}