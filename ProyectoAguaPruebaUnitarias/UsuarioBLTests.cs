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
    public class UsuarioBLTests
    {
        private Usuario usuarioInicial = new Usuario { Id = 4, IdRol = 2, Login = "RGonzales", Password = "1234" };
        private UsuarioBL usuarioBL = new UsuarioBL();
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Robertito";
            usuario.Apellido = "Gonzalez";
            usuario.Login = "RGonzales";
            usuario.Password = "123456";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            int result = await usuarioBL.CrearAsync(usuario);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Roberto";
            usuario.Apellido = "Gonzales";
            usuario.Login = "RGonzales";
            usuario.Password = "123456";
            usuario.Estatus = (byte)Estatus_Usuario.INACTIVO;
            var result = await usuarioBL.ModificarAsync(usuario);
            Assert.IsTrue(result == 1);
        }

        [TestMethod()]
        public async void T3DeleteAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            int result = await usuarioBL.DeleteAsync(usuario);
            Assert.AreEqual(0, result);
           
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            var result = await usuarioBL.ObtenerPorIdAsync(usuario);
            Assert.IsTrue(result.Id == usuario.Id);
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            var resul = await usuarioBL.ObtenerTodosAsync();
            Assert.IsTrue(resul.Count > 0);
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "a";
            usuario.Apellido = "a";
            usuario.Login = "a";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var resul = await usuarioBL.BuscarAsync(usuario);
            Assert.AreNotEqual(0, resul.Count);
        }

        [TestMethod()]
        public async Task T7BuscarIncluirRolAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.Id = 2;
            usuario.IdRol = 2;
            usuario.Nombre = "Laura";
            usuario.Apellido = "Ramirez";
            usuario.Login = "Iramirez";
            usuario.FechaRegistro = new DateTime(2024,01,02);
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var resulUsuarios = await usuarioBL.BuscarIncluirRolAsync(usuario);
            var ultimoUsuario = resulUsuarios.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.Rol != null && usuario.IdRol == ultimoUsuario.Rol.Id);
           
        }

        [TestMethod()]
        public async Task T8LoginAsyncTest()
        {

            Usuario usuario = new Usuario();
            usuario.Apellido = "ViDuran";
            usuario.Password = "123456";
            var resul = await usuarioBL.LoginAsync(usuario);
            Assert.AreEqual(usuario.Login,"ViDuran");
        }

        [TestMethod()]
        public async void T9CambiarPasswordAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            string passwordNuevo = "1234567";
            usuario.Password = passwordNuevo;
            var result = await usuarioBL.CambiarPasswordAsync(usuario, usuarioInicial.Password);
            Assert.AreEqual(0, result);
            usuarioInicial.Password = passwordNuevo;

            Assert.Fail();
        }


    }
}