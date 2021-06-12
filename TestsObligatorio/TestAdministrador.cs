using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace TestsObligatorio
{

    [TestClass]
    public class TestAdministrador
    {
        private ControladoraAdministrador administrador;
        private ControladoraUsuario usuario1;
        private ControladoraUsuario usuario2;
        private ControladoraUsuario usuario3;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            administrador = new ControladoraAdministrador();

            usuario1 = new ControladoraUsuario
            {
                Nombre = "Roberto"
            };

            usuario2 = new ControladoraUsuario
            {
                Nombre = "Pedro"
            };

            usuario3 = new ControladoraUsuario();
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaAlPrincipio()
        {
            Assert.IsTrue(administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConUsuarios()
        {
            administrador.AgregarUsuario(usuario1);
            Assert.IsFalse(administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioSinNombre()
        {
            Assert.ThrowsException<ObjetoIncompletoException>(() => administrador.AgregarUsuario(usuario3));
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioYaExistente()
        {
            administrador.AgregarUsuario(usuario1);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => administrador.AgregarUsuario(usuario1));
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            administrador.AgregarUsuario(usuario1);
            administrador.AgregarUsuario(usuario2);
            Assert.IsFalse(administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorPedirNombreUsuarioCorrecto()
        {
            administrador.AgregarUsuario(usuario1);

            ControladoraUsuario aBuscar = new ControladoraUsuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual(usuario1, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            administrador.AgregarUsuario(usuario1);
            administrador.AgregarUsuario(usuario2);

            ControladoraUsuario aBuscar = new ControladoraUsuario
            {
                Nombre = "Roberto"
            };

            Assert.AreEqual(usuario1, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSegundoConDosAgregados()
        {
            administrador.AgregarUsuario(usuario1);
            administrador.AgregarUsuario(usuario2);

            ControladoraUsuario aBuscar = new ControladoraUsuario
            {
                Nombre = "Pedro"
            };
            Assert.AreEqual(usuario2, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSinMayuscula()
        {
            administrador.AgregarUsuario(usuario1);

            ControladoraUsuario aBuscar = new ControladoraUsuario
            {
                Nombre = "roberto"
            };
            Assert.AreEqual(usuario1, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioInexistente()
        {
            administrador.AgregarUsuario(usuario1);
            administrador.AgregarUsuario(usuario2);

            ControladoraUsuario inexistente = new ControladoraUsuario
            {
                Nombre = "Ernesto"
            };
            Assert.ThrowsException<ObjetoInexistenteException>(() => administrador.GetUsuario(inexistente));
        }

        [TestMethod]
        public void AdministradorVacioYaExisteUsuario()
        {
            Assert.IsFalse(administrador.YaExisteUsuario(usuario1));
        }

        [TestMethod]
        public void AdministradorYaExisteUsuarioExistente()
        {
            administrador.AgregarUsuario(usuario1);
            ControladoraUsuario buscador = new ControladoraUsuario
            {
                Nombre = "Roberto"
            };

            Assert.IsTrue(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorNoVacioYaExisteUsuarioNoExistente()
        {
            administrador.AgregarUsuario(usuario1);
            ControladoraUsuario buscador = new ControladoraUsuario
            {
                Nombre = "Buscador"
            };

            Assert.IsFalse(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosVacia()
        {
            Assert.IsNull(administrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosNoVacia()
        {
            administrador.AgregarUsuario(usuario1);
            Assert.IsNotNull(administrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosEsIgual()
        {
            administrador.AgregarUsuario(usuario1);
            administrador.AgregarUsuario(usuario2);

            List<ControladoraUsuario> usuariosComparar = new List<ControladoraUsuario>
            {
                usuario1,
                usuario2
            };
            Assert.AreEqual(true, usuariosComparar.SequenceEqual(administrador.GetListaUsuarios())); ;
        }
    }
}
