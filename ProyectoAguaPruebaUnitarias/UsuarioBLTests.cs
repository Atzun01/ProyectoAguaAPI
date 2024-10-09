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
        private Usuario usuarioInicial = new Usuario { Id = 4, IdRol = 2, Login = "RGonzales", Password = "123456" };
        private UsuarioBL usuarioBL = new UsuarioBL();
        [TestMethod()]
        public async Task CrearAsyncTest()
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
        public async void DeleteAsyncTest()
        {
           
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            var result = await usuarioBL.ObtenerPorIdAsync(usuario);
            Assert.IsTrue(result.Id == usuario.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resul = await usuarioBL.ObtenerTodosAsync();
            Assert.IsTrue(resul.Count > 0);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
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
        public async Task BuscarIncluirRolAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "a";
            usuario.Apellido = "ViDuran";
            usuario.Login = "a";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var resulUsuarios = await usuarioBL.BuscarIncluirRolAsync(usuario);
            var ultimoUsuario = resulUsuarios.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.Rol != null && usuario.IdRol == ultimoUsuario.Rol.Id);
           
        }

        [TestMethod()]
        public async Task LoginAsyncTest()
        {

            Usuario usuario = new Usuario();
            usuario.Apellido = "ViDuran";
            usuario.Password = "123456";
            var resul = await usuarioBL.LoginAsync(usuario);
            Assert.AreEqual(usuario.Login,"ViDuran");
        }

        [TestMethod()]
        public void CambiarPasswordAsyncTest()
        {
            Assert.Fail();
        }
    }
}