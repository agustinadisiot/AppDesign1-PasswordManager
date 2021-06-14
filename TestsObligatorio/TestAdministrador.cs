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
            controladoraAdministrador.BorrarTodo();
            usuario1 = new Usuario
            {
                Nombre = "Roberto",
                ClaveMaestra = "ClaveMaestra"
            };

            usuario2 = new Usuario
            {
                Nombre = "Pedro",
                ClaveMaestra = "OtraClaveMaestra"
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
            Assert.AreEqual(0,controladoraAdministrador.GetListaUsuarios().Count());
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

    [TestClass]
    public class TestClavesCompartidas {
        private ControladoraAdministrador controladoraAdministrador = new ControladoraAdministrador();
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
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Clave, clave1);
        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveYaCompartida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            controladoraAdministrador.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraAdministrador.CompartirClave(claveCompartida));
        }

        [TestMethod]
        public void UsuarioCompartirUnaClave_ConfirmarUsuariosIguales()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            controladoraAdministrador.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Original, usuario);
        }

        [TestMethod]
        public void UsuarioCompartirDosClaves()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria igual = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            controladoraUsuario.AgregarCategoria(igual, usuario2);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            controladoraAdministrador.CompartirClave(claveCompartida);
            controladoraAdministrador.CompartirClave(claveCompartida2);

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
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria igual = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            controladoraUsuario.AgregarCategoria(igual, usuario2);
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraAdministrador.CompartirClave(claveCompartida));
        }

        [TestMethod]
        public void UsuarioCompartirClaveEsCompartida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria igual = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            controladoraUsuario.AgregarCategoria(igual, usuario2);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            Assert.IsFalse(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveEsCompartida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);
            Assert.IsTrue(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioCompartirDosClaves_listaClavesQueComparto()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria igual = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            controladoraUsuario.AgregarCategoria(igual, usuario2);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);

            controladoraAdministrador.CompartirClave(claveCompartida2);
            usuario = controladoraAdministrador.GetUsuario(usuario);
            Assert.IsTrue(usuario.CompartidasPorMi.Contains(claveCompartida) && usuario.CompartidasPorMi.Contains(claveCompartida2));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveQueNoComparto()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria igual = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            controladoraUsuario.AgregarCategoria(igual, usuario2);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraAdministrador.DejarDeCompartir(claveCompartida2));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaQueComparto()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria igual = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            controladoraUsuario.AgregarCategoria(igual, usuario2);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);
            controladoraAdministrador.DejarDeCompartir(claveCompartida);
            usuario = controladoraAdministrador.GetUsuario(usuario);
            Assert.IsFalse(usuario.CompartidasPorMi.Contains(claveCompartida));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaDeQuienComparto()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria igual = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            controladoraUsuario.AgregarCategoria(igual, usuario2);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);

            ClaveCompartida claveQueCompartieron = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            controladoraAdministrador.DejarDeCompartir(claveCompartida);
            usuario2 = controladoraAdministrador.GetUsuario(usuario2);
            Assert.IsFalse(usuario2.CompartidasConmigo.Contains(claveQueCompartieron));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAUnUsuarioAQuienNoLeComparto()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraAdministrador.DejarDeCompartir(claveCompartida3));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaAFalse()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraAdministrador.CompartirClave(claveCompartida);

            controladoraAdministrador.DejarDeCompartir(claveCompartida);
            Assert.IsFalse(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaATrue()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            controladoraAdministrador.CompartirClave(claveCompartida);

            controladoraAdministrador.CompartirClave(claveCompartida3);

            controladoraAdministrador.DejarDeCompartir(claveCompartida);

            Assert.IsTrue(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAlBorrarLaClave()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            controladoraAdministrador.CompartirClave(claveCompartida);

            controladoraAdministrador.CompartirClave(claveCompartida3);

            controladoraUsuario.BorrarClave(clave1, usuario);
            usuario2 = controladoraAdministrador.GetUsuario(usuario2);
            usuario3 = controladoraAdministrador.GetUsuario(usuario3);

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

            controladoraAdministrador.CompartirClave(claveCompartida);

            Assert.AreEqual(claveCompartida, controladoraUsuario.GetClaveCompartidaPorMi(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorMiInexistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);
            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave2
            };

            controladoraAdministrador.CompartirClave(claveCompartida);


            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.GetClaveCompartidaPorMi(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorDosCompartidasConParametrosDiferentes()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            controladoraAdministrador.CompartirClave(claveCompartida);
            controladoraAdministrador.CompartirClave(claveCompartida2);

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

            Assert.AreEqual(claveCompartida2, controladoraUsuario.GetClaveCompartidaPorMi(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCorrecta()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            controladoraAdministrador.CompartirClave(claveCompartida);

            Assert.AreEqual(buscadora, controladoraUsuario.GetClaveCompartidaPorMi(buscadora, usuario2));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoInexistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave2
            };

            controladoraAdministrador.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.GetClaveCompartidaPorMi(buscadora, usuario2));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCompartidasConParametrosDiferentes()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            controladoraAdministrador.CompartirClave(claveCompartida);
            controladoraAdministrador.CompartirClave(claveCompartida2);

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

            Assert.AreEqual(buscadora, controladoraUsuario.GetClaveCompartidaPorMi(buscadora, usuario2));
        }
    }
}
