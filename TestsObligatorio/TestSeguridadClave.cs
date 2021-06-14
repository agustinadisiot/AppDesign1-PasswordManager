using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestSeguridadClave
    {
        private ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
        private NivelSeguridad nivelSeguridad = new NivelSeguridad();
        private Usuario usuario;
        private Categoria categoria1;
        private Categoria categoria2;
        private Clave clave1;
        private Clave clave2;
        private ControladoraDataBreach controladoraDataBreach;
        private List<Filtrada> datos1;
        private List<Filtrada> datos2;
        private ControladoraAdministrador controladoraAdministrador;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {

            controladoraAdministrador = new ControladoraAdministrador();
            controladoraAdministrador.BorrarTodo();

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

            List<string> datosString1 = new List<string>
            {
                "EstaEsUnaClave1",
                "1234567890987634",
                "claveDeNetflix"
            };

            datos1 = datosString1.Select(s => new Filtrada(s)).ToList();

            List<string> datosString2 = new List<string>
            {
                "1234567890987634",
                "EstaEsUnaClave2"
            };

            datos2 = datosString2.Select(s => new Filtrada(s)).ToList();

            controladoraDataBreach = new ControladoraDataBreach();

            controladoraAdministrador.AgregarUsuario(usuario);

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

        [TestMethod]
        public void UsuarioEstaClaveContenidaEnDataBrechNoContenida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);

            controladoraDataBreach.AgregarDataBreach(datos1, DateTime.Now, usuario);
            string aVerificar = "ClaveNoContenida";

            Assert.AreEqual(false, nivelSeguridad.EstaClaveContenidaEnDataBrech(aVerificar, usuario));
        }

        [TestMethod]
        public void UsuarioEstaClaveContenidaEnDataBrechSiContenida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraDataBreach.AgregarDataBreach(datos1, DateTime.Now, usuario);
            string aVerificar = clave1.Codigo;

            Assert.AreEqual(true, nivelSeguridad.EstaClaveContenidaEnDataBrech(aVerificar, usuario));
        }

        [TestMethod]
        public void UsuarioEstaClaveContenidaEnDataBrechSiContenidaConMasDeUnaDataBreach()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave2, categoria1, usuario);
            controladoraDataBreach.AgregarDataBreach(datos1, DateTime.Now, usuario);
            controladoraDataBreach.AgregarDataBreach(datos2, DateTime.Now, usuario);

            string aVerificar = clave2.Codigo;

            Assert.AreEqual(true, nivelSeguridad.EstaClaveContenidaEnDataBrech(aVerificar, usuario));
        }

        [TestMethod]
        public void UsuarioClaveCumpleRequerimientosNoCumplePorEstarEnDataBreach()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarClave(clave1, categoria1, usuario);
            controladoraDataBreach.AgregarDataBreach(datos1, DateTime.Now, usuario);
            controladoraDataBreach.AgregarDataBreach(datos2, DateTime.Now, usuario);

            string aVerificar = clave2.Codigo;

            Assert.ThrowsException<ClaveEstaEnDataBreachException>(() => nivelSeguridad.ClaveCumpleRequerimientos(aVerificar, usuario));
        }
    }
}
