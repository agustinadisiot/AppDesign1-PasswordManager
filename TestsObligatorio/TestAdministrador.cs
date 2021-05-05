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
            Assert.AreEqual(true, administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Assert.AreEqual(false, administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioSinNombre()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario();
            Assert.ThrowsException<ObjetoIncompletoException>(() => administrador.AgregarUsuario(usuario));
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Assert.AreEqual(false, administrador.EsListaUsuariosVacia());
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);
            Assert.AreEqual(false, administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorPedirNombreUsuarioCorrecto()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Assert.AreEqual(usuario, administrador.GetUsuario("Roberto"));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);
            Assert.AreEqual(usuario, administrador.GetUsuario("Roberto"));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSegundoConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);
            Assert.AreEqual(usuario2, administrador.GetUsuario("Pedro"));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioInexistente()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.AgregarUsuario(usuario2);
            Assert.ThrowsException<ObjetoInexistenteException>(() => administrador.GetUsuario("Hernesto"));
        }

        [TestMethod]
        public void AdministradorVacioYaExisteUsuario()
        {
            AdminContras administrador = new AdminContras();
            Usuario buscador = new Usuario
            {
                Nombre = "Roberto"
            };

            Assert.IsFalse(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorYaExisteUsuarioExistente()
        {
            AdminContras administrador = new AdminContras();

            Usuario agregar = new Usuario()
            {
                Nombre = "Roberto"
            };
            
            Usuario buscador = new Usuario
            {
                Nombre = "Roberto"
            };

            administrador.AgregarUsuario(agregar);

            Assert.IsTrue(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorNoVacioYaExisteUsuarioNoExistente()
        {
            AdminContras administrador = new AdminContras();

            Usuario agregar = new Usuario()
            {
                Nombre = "Agregar"
            };

            Usuario buscador = new Usuario
            {
                Nombre = "Buscador"
            };

            administrador.AgregarUsuario(agregar);

            Assert.IsFalse(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosVacia()
        {
            AdminContras administrador = new AdminContras();

            Assert.IsNull(administrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosNoVacia()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };
            administrador.AgregarUsuario(usuario);

            Assert.IsNotNull(administrador.GetListaUsuarios());
        }
    }

}
