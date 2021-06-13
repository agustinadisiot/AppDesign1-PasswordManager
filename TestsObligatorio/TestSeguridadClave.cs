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
        private DataAccessUsuario accesoUsuario;
        private DataAccessCategoria accesoCategoria;
        private DataAccessClave accesoClave;
        private NivelSeguridad nivelSeguridad = new NivelSeguridad();

        private Usuario usuario;
        private Categoria categoria1;
        private Categoria categoria2;
        private Clave clave1;
        private Clave clave2;

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
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaNoRepetida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            string aVerificar = "ClaveNoRepetida";


            Assert.AreEqual(false, nivelSeguridad.EsClaveRepetida(aVerificar, usuario));
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaSiRepetida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            string aVerificar = clave1.Codigo;

            Assert.AreEqual(true, nivelSeguridad.EsClaveRepetida(aVerificar, usuario));
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaVariasClavesDiferentesCategoriasSiRepetida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            string aVerificar = clave2.Codigo;

            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria2, usuario);

            Assert.AreEqual(true, nivelSeguridad.EsClaveRepetida(aVerificar, usuario));
        }

        [TestMethod]
        public void UsuarioEsClaveNivelSeguroSeguraVerdeClaro()
        {
            string aVerificar = "ClaveVerdeClaro";

            Assert.AreEqual(true, nivelSeguridad.EsClaveNivelSeguro(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveNivelSeguroNoSegura()
        {
            string aVerificar = "clavenosegura";

            Assert.AreEqual(false, nivelSeguridad.EsClaveNivelSeguro(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveNivelSeguroSeguraVerdeOscuro()
        {
            string aVerificar = "claveVerdeOscuroN14@";

            Assert.AreEqual(true, nivelSeguridad.EsClaveNivelSeguro(aVerificar));
        }

        [TestMethod]
        public void UsuarioClaveCumpleRequerimientosNoCumplePorClaveDuplicada()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            string aVerificar = "EstaEsUnaClave1";

            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            Assert.ThrowsException<ClaveDuplicadaException>(() => nivelSeguridad.ClaveCumpleRequerimientos(aVerificar, usuario));
        }
        [TestMethod]
        public void UsuarioClaveCumpleRequerimientosNoCumplePorNivelSeguridad()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            string aVerificar = "clavenosegura";

            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);

            Assert.ThrowsException<ClaveNoSeguraException>(() => nivelSeguridad.ClaveCumpleRequerimientos(aVerificar, usuario));
        }
    }
}
