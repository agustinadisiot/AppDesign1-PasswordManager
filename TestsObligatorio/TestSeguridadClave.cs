using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsObligatorio
{
    [TestClass]
    class TestSeguridadClave
    {
        private ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
        private ControladoraCategoria controladoraCategoria = new ControladoraCategoria();
        private DataAccessUsuario accesoUsuario;
        private DataAccessCategoria accesoCategoria;
        private DataAccessClave accesoClave;
        private NivelSeguridad nivelSeguridad = new NivelSeguridad();

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
        public void UsuarioEsClaveRepetidaNoRepetida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            string aVerificar = "ClaveNoRepetida";


            Assert.AreEqual(false, usuario.EsClaveRepetida(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaSiRepetida()
        {
            usuario.AgregarCategoria(categoria1);
            string aVerificar = clave1.Codigo;

            usuario.AgregarClave(clave1, categoria1);

            Assert.AreEqual(true, usuario.EsClaveRepetida(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaVariasClavesDiferentesCategoriasSiRepetida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            string aVerificar = clave2.Codigo;

            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria2);

            Assert.AreEqual(true, usuario.EsClaveRepetida(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveSeguraSeguraVerdeClaro()
        {
            string aVerificar = "ClaveVerdeClaro";

            Assert.AreEqual(true, usuario.EsClaveSegura(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveSeguraNoSegura()
        {
            string aVerificar = "clavenosegura";

            Assert.AreEqual(false, usuario.EsClaveSegura(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveSeguraSeguraVerdeOscuro()
        {
            string aVerificar = "claveVerdeOscuroN14@";

            Assert.AreEqual(true, usuario.EsClaveSegura(aVerificar));
        }

        [TestMethod]
        public void UsuarioClaveCumpleRequerimientosNoCumplePorClaveDuplicada()
        {
            usuario.AgregarCategoria(categoria1);

            string aVerificar = "EstaEsUnaClave1";

            usuario.AgregarClave(clave1, categoria1);

            Assert.ThrowsException<ClaveDuplicadaException>(() => usuario.ClaveCumpleRequerimientos(aVerificar));
        }
        [TestMethod]
        public void UsuarioClaveCumpleRequerimientosNoCumplePorNivelSeguridad()
        {
            usuario.AgregarCategoria(categoria1);

            string aVerificar = "clavenosegura";

            usuario.AgregarClave(clave1, categoria1);

            Assert.ThrowsException<ClaveNoSeguraException>(() => usuario.ClaveCumpleRequerimientos(aVerificar));
        }
    }
}
