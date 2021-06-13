using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Repositorio;
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

    [TestClass]
    public class TestClavesCompartidas {

        private ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
        private ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
        private DataAccessUsuario accesoUsuario;
        private DataAccessCategoria accesoCategoria;
        private DataAccessClave accesoClave;

        private Usuario usuario;
        private Usuario usuario2;
        private Usuario usuario3;
        private Categoria categoria1;
        private Categoria categoria2;
        private Clave clave1;
        private Clave clave2;
        private Clave clave3;
        private Clave clave4;
        private ClaveCompartida claveCompartida;
        private ClaveCompartida claveCompartida2;
        private ClaveCompartida claveCompartida3;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {

            accesoUsuario = new DataAccessUsuario();
            List<Usuario> usuariosABorrar = (List<Usuario>)accesoUsuario.GetTodos();
            foreach (Usuario actual in usuariosABorrar)
            {
                accesoUsuario.Borrar(actual);
            }

            accesoCategoria = new DataAccessCategoria();
            List<Categoria> categoriasABorrar = (List<Categoria>)accesoCategoria.GetTodos();
            foreach (Categoria actual in categoriasABorrar)
            {
                accesoCategoria.Borrar(actual);
            }


            accesoClave = new DataAccessClave();
            List<Clave> clavesABorrar = (List<Clave>)accesoClave.GetTodos();
            foreach (Clave actual in clavesABorrar)
            {
                accesoClave.Borrar(actual);
            }

            usuario = new Usuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "Hola12345"
            };

            usuario2 = new Usuario()
            {
                Nombre = "Usuario2",
                ClaveMaestra = "Chau12345"
            };

            usuario3 = new Usuario()
            {
                Nombre = "Usuario3"
            };

            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };

            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto",
                Nota = ""
            };

            clave2 = new Clave()
            {
                Sitio = "Netflix.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = "Nota de una clave"
            };

            clave3 = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "codrojo",
                UsuarioClave = "Hernesto"
            };

            clave4 = new Clave()
            {
                Sitio = "www.hbo.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };

            claveCompartida = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            claveCompartida2 = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave2
            };

            claveCompartida3 = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario3,
                Clave = clave1
            };
        }

        [TestMethod]
        public void UsuarioCompartirUnaClave_ConfirmarClavesIguales()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Clave, clave1);
        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveYaCompartida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.CompartirClave(claveCompartida));
        }

        [TestMethod]
        public void UsuarioCompartirUnaClave_ConfirmarUsuariosIguales()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Original, usuario);
        }

        [TestMethod]
        public void UsuarioCompartirDosClaves()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida2);

            ClaveCompartida claveCompartidaAUsuario2_1 = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveCompartidaAUsuario2_2 = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave2
            };

            Assert.IsTrue(usuario2.CompartidasConmigo.Contains(claveCompartidaAUsuario2_1) && usuario2.CompartidasConmigo.Contains(claveCompartidaAUsuario2_2));
        }

        [TestMethod]
        public void UsuarioCompartirClaveInexistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.CompartirClave(claveCompartida));

        }

        [TestMethod]
        public void UsuarioCompartirClaveEsCompartida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            Assert.IsFalse(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveEsCompartida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            Assert.IsTrue(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioCompartirDosClaves_listaClavesQueComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida2);

            Assert.IsTrue(usuario.CompartidasPorMi.Contains(claveCompartida) && usuario.CompartidasPorMi.Contains(claveCompartida2));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveQueNoComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.DejarDeCompartir(claveCompartida2));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaQueComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsFalse(usuario.CompartidasPorMi.Contains(claveCompartida));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaDeQuienComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            ClaveCompartida claveQueCompartieron = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsFalse(usuario2.CompartidasConmigo.Contains(claveQueCompartieron));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAUnUsuarioAQuienNoLeComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario3.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.DejarDeCompartir(claveCompartida3));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaAFalse()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsFalse(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaATrue()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario3.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida3);

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsTrue(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAlBorrarLaClave()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario3.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida3);

            usuario.BorrarClave(clave1);

            Assert.IsFalse(usuario2.CompartidasConmigo.Contains(claveCompartida) || usuario3.CompartidasConmigo.Contains(claveCompartida));
        }


        [TestMethod]
        public void UsuarioGetClaveCompartidaPorMiCorrecta()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(claveCompartida, usuario.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorMiInexistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);
            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave2
            };

            usuario.CompartirClave(claveCompartida);


            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorDosCompartidasConParametrosDiferentes()
        {
            usuario.AgregarCategoria(categoria1);

            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            usuario.CompartirClave(claveCompartida);
            usuario.CompartirClave(claveCompartida2);

            Usuario usuarioBuscador = new Usuario
            {
                Nombre = "Usuario2",
                ClaveMaestra = "ClaveDiferente"
            };

            Clave claveBuscadora = new Clave
            {
                Sitio = clave2.Sitio,
                Codigo = "EstaEsUnaDiferente",
                UsuarioClave = clave2.UsuarioClave
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuarioBuscador,
                Clave = claveBuscadora
            };

            Assert.AreEqual(claveCompartida2, usuario.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCorrecta()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(buscadora, usuario2.GetClaveCompartidaConmigo(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoInexistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave2
            };

            usuario.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario2.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCompartidasConParametrosDiferentes()
        {
            usuario.AgregarCategoria(categoria1);

            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            usuario.CompartirClave(claveCompartida);
            usuario.CompartirClave(claveCompartida2);

            Usuario usuarioBuscador = new Usuario
            {
                Nombre = usuario.Nombre,
                ClaveMaestra = "ClaveDiferente"
            };

            Clave claveBuscadora = new Clave
            {
                Sitio = clave2.Sitio,
                Codigo = "EstaEsUnaDiferente",
                UsuarioClave = clave2.UsuarioClave
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Destino = usuario2,
                Original = usuarioBuscador,
                Clave = claveBuscadora
            };

            Assert.AreEqual(buscadora, usuario2.GetClaveCompartidaConmigo(buscadora));
        }
    }
}
