using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using System.Collections.Generic;
using System.Linq;


namespace TestsObligatorio
{

    [TestClass]
    public class TestAdministrador
    {
        private ControladoraAdministrador controladoraAdministrador;
        private Usuario usuario1;
        private Usuario usuario2;
        private Usuario usuario3;

        [TestCleanup]
        public void TearDown() { }

        [TestInitialize]
        public void Setup()
        {
            controladoraAdministrador = new ControladoraAdministrador();

            usuario1 = new Usuario
            {
                Nombre = "Roberto"
            };

            usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };

            usuario3 = new Usuario();
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaAlPrincipio()
        {
            Assert.IsTrue(controladoraAdministrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConUsuarios()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            Assert.IsFalse(controladoraAdministrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioSinNombre()
        {
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraAdministrador.AgregarUsuario(usuario3));
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioYaExistente()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraAdministrador.AgregarUsuario(usuario1));
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            controladoraAdministrador.AgregarUsuario(usuario2);
            Assert.IsFalse(controladoraAdministrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorPedirNombreUsuarioCorrecto()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);

            Usuario aBuscar = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual(usuario1, controladoraAdministrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            controladoraAdministrador.AgregarUsuario(usuario2);

            Usuario aBuscar = new Usuario
            {
                Nombre = "Roberto"
            };

            Assert.AreEqual(usuario1, controladoraAdministrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSegundoConDosAgregados()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            controladoraAdministrador.AgregarUsuario(usuario2);

            Usuario aBuscar = new Usuario
            {
                Nombre = "Pedro"
            };
            Assert.AreEqual(usuario2, controladoraAdministrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSinMayuscula()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);

            Usuario aBuscar = new Usuario
            {
                Nombre = "roberto"
            };
            Assert.AreEqual(usuario1, controladoraAdministrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioInexistente()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            controladoraAdministrador.AgregarUsuario(usuario2);

            Usuario inexistente = new Usuario
            {
                Nombre = "Ernesto"
            };
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraAdministrador.GetUsuario(inexistente));
        }

        [TestMethod]
        public void AdministradorVacioYaExisteUsuario()
        {
            Assert.IsFalse(controladoraAdministrador.YaExisteUsuario(usuario1));
        }

        [TestMethod]
        public void AdministradorYaExisteUsuarioExistente()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            Usuario buscador = new Usuario
            {
                Nombre = "Roberto"
            };

            Assert.IsTrue(controladoraAdministrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorNoVacioYaExisteUsuarioNoExistente()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            Usuario buscador = new Usuario
            {
                Nombre = "Buscador"
            };

            Assert.IsFalse(controladoraAdministrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosVacia()
        {
            Assert.IsNull(controladoraAdministrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosNoVacia()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            Assert.IsNotNull(controladoraAdministrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosEsIgual()
        {
            controladoraAdministrador.AgregarUsuario(usuario1);
            controladoraAdministrador.AgregarUsuario(usuario2);

            List<Usuario> usuariosComparar = new List<Usuario>
            {
                usuario1,
                usuario2
            };
            Assert.AreEqual(true, usuariosComparar.SequenceEqual(controladoraAdministrador.GetListaUsuarios())); 
        }
    }
}
