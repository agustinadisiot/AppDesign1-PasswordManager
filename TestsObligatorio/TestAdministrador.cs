using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace TestsObligatorio
{

    [TestClass]
    public class TestAdministrador
    {

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaAlPrincipio()
        {
            AdminContras administrador = new AdminContras();
            Assert.AreEqual(true, administrador.esListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioSinNombre()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario();
            Assert.ThrowsException<ObjetoIncompletoException>(() => administrador.agregarUsuario(usuario));
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorPedirNombreUsuarioCorrecto()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Assert.AreEqual(usuario, administrador.getUsuario("Roberto"));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.AreEqual(usuario, administrador.getUsuario("Roberto"));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSegundoConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.AreEqual(usuario2, administrador.getUsuario("Pedro"));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioInexistente()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.ThrowsException<ObjetoInexistenteException>(() => administrador.getUsuario("Hernesto"));
        }

    }

}
