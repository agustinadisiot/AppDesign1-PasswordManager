using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace TestsObligatorio
{

    [TestClass]
    public class TestAdministrador
    {

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaAlPrincipio()
        {
            Administrador administrador = new Administrador();
            Assert.IsTrue(administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConUsuarios()
        {
            Administrador administrador = new Administrador();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);
            Assert.IsFalse(administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioSinNombre()
        {
            Administrador administrador = new Administrador();
            Usuario usuario = new Usuario();
            Assert.ThrowsException<ObjetoIncompletoException>(() => administrador.AgregarUsuario(usuario));
        }

        [TestMethod]
        public void AdministradorAgregarUsuarioYaExistente()
        {
            Administrador administrador = new Administrador();
            Usuario usuario = new Usuario()
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => administrador.AgregarUsuario(usuario));
        }

        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            Administrador administrador = new Administrador();
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
            Assert.IsFalse(administrador.EsListaUsuariosVacia());
        }

        [TestMethod]
        public void AdministradorPedirNombreUsuarioCorrecto()
        {
            Administrador administrador = new Administrador();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);

            Usuario aBuscar = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual(usuario, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            Administrador administrador = new Administrador();
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

            Usuario aBuscar = new Usuario
            {
                Nombre = "Roberto"
            };

            Assert.AreEqual(usuario, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSegundoConDosAgregados()
        {
            Administrador administrador = new Administrador();
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

            Usuario aBuscar = new Usuario
            {
                Nombre = "Pedro"
            };
            Assert.AreEqual(usuario2, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioSinMayuscula()
        {
            Administrador administrador = new Administrador();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.AgregarUsuario(usuario);

            Usuario aBuscar = new Usuario
            {
                Nombre = "roberto"
            };
            Assert.AreEqual(usuario, administrador.GetUsuario(aBuscar));
        }

        [TestMethod]
        public void AdministradorPedirUsuarioInexistente()
        {
            Administrador administrador = new Administrador();
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

            Usuario inexistente = new Usuario
            {
                Nombre = "Ernesto"
            };
            Assert.ThrowsException<ObjetoInexistenteException>(() => administrador.GetUsuario(inexistente));
        }

        [TestMethod]
        public void AdministradorVacioYaExisteUsuario()
        {
            Administrador administrador = new Administrador();
            Usuario buscador = new Usuario
            {
                Nombre = "Roberto"
            };

            Assert.IsFalse(administrador.YaExisteUsuario(buscador));
        }

        [TestMethod]
        public void AdministradorYaExisteUsuarioExistente()
        {
            Administrador administrador = new Administrador();

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
            Administrador administrador = new Administrador();

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
            Administrador administrador = new Administrador();

            Assert.IsNull(administrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosNoVacia()
        {
            Administrador administrador = new Administrador();
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };
            administrador.AgregarUsuario(usuario);

            Assert.IsNotNull(administrador.GetListaUsuarios());
        }

        [TestMethod]
        public void AdministradorGetListaUsuariosEsIgual()
        {
            Administrador administrador = new Administrador();
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            administrador.AgregarUsuario(usuario1);
            administrador.AgregarUsuario(usuario2);

            List<Usuario> usuariosComparar = new List<Usuario>
            {
                usuario1,
                usuario2
            };
            Assert.AreEqual(true, usuariosComparar.SequenceEqual(administrador.GetListaUsuarios())); ;
        }
    }

}
