using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsObligatorio
{
    [TestClass]
    class TestDataBreach
    {
        [TestInitialize]
        public void testInit() {

        }

        [TestCleanup]
        public void testClean() {
            
        }

    }


    [TestClass]
    public class TestUsuarioDataBreaches
    {
        private Usuario usuario;
        private Clave clave1;
        private Clave clave2;
        private Clave clave3;
        private Clave clave4;
        private Tarjeta tarjeta1;
        private Tarjeta tarjeta2;
        private Tarjeta tarjeta3;
        private DateTime tiempoActual;
        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            tiempoActual = DateTime.Now;

            usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria1);

            Categoria categoria2 = new Categoria()
            {
                Nombre = "Estudio"
            };

            usuario.AgregarCategoria(categoria2);

            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);
            clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);
            
            tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta1, categoria1);

            tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta2, categoria2);

            tarjeta3 = new Tarjeta()
            {
                Numero = "3333333333333333",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta3, categoria1);

        }



        [TestMethod]
        public void UsuarioGetUltimoDataBreachVacioRetornaListaVacia()
        {
            List<string> filtradas = new List<string>();

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach ultimo = usuario.GetUltimoDataBreach();

            Assert.IsTrue(ultimo.Claves.Count == 0 && ultimo.Tarjetas.Count == 0);
        }


        [TestMethod]
        public void UsuarioGetDataBreachNoVacioClaves()
        {
            List<string> filtradas = new List<string>() {
                "EstaEsUnaClave1",
                "EstaEsUnaClave4"
            };

            List<Clave> esperadas = new List<Clave>() {
                clave1,
                clave4
            };

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultadoBreach = usuario.GetUltimoDataBreach();

            bool esperadasContieneRetorno = resultadoBreach.Claves.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultadoBreach.Claves.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetDataBreachClavesNoExistentes()
        {
            List<string> filtradas = new List<string>() {
                "ClaveNoContenida",
                "ClaveTampocoContenida",
                "EstaEsUnaClave3"
            };

            List<Clave> esperadas = new List<Clave>() {
                clave3
            };

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultado = usuario.GetUltimoDataBreach();

            bool esperadasContieneRetorno = resultado.Claves.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Claves.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetTarjetasDataBreachVacio()
        {
            List<string> filtradas = new List<string>();

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultado = usuario.GetUltimoDataBreach();


            Assert.IsTrue(resultado.Tarjetas.Count == 0);
        }

        [TestMethod]
        public void UsuarioGetTarjetasDataBreachNoVacio()
        {
            List<string> filtradas = new List<string>() {
                "1111111111111111",
                "UnaClave",
                "3333 3333 3333 3333",
                "4444 4444 4444 4444"
            };

            List<Tarjeta> esperadas = new List<Tarjeta>() {
                tarjeta1,
                tarjeta3
            };

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultado = usuario.GetUltimoDataBreach();

            bool esperadasContieneRetorno = resultado.Tarjetas.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Tarjetas.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }

        [TestMethod]
        public void UsuarioGetFechaHoraDataBreach()
        {
            List<string> primerasFiltradas = new List<string>() {
                "2222222222222222",
                "OtraClave"
            };

            List<Tarjeta> esperadas = new List<Tarjeta>() {
                tarjeta2
            };
            usuario.agregarDataBreach(primerasFiltradas, tiempoActual);
            DataBreach resultado = usuario.GetUltimoDataBreach();
            bool mismoTiempo = (resultado.Fecha == tiempoActual);

            Assert.IsTrue(mismoTiempo);
        }

        [TestMethod]
        public void UsuarioGetDataBreachViejo()
        {
            List<string> primerasFiltradas = new List<string>() {
                "2222222222222222",
                "OtraClave"
            };

            List<string> segundasFiltradas = new List<string>() {
                "1111111111111111",
                "UnaClave",
                "3333 3333 3333 3333",
                "4444 4444 4444 4444"
            };

            List<Tarjeta> esperadas = new List<Tarjeta>() {
                tarjeta2
            };

            DateTime tiempoViejo = new DateTime(2000, 1, 1, 1, 0, 0);
            DateTime tiempoNuevo = new DateTime(2000, 1, 1, 2, 0, 0);
            usuario.agregarDataBreach(primerasFiltradas, tiempoViejo);
            usuario.agregarDataBreach(segundasFiltradas, tiempoNuevo);

            DataBreach resultado = usuario.GetDataBreach(tiempoViejo);

            bool esperadasContieneRetorno = resultado.Tarjetas.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Tarjetas.Contains);
            Assert.IsTrue(esperadasContieneRetorno&& retornoContieneEsperadas);
        }

    }
}
