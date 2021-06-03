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

        [TestMethod]
        public void UsuarioGetDataBreachVacioRetornaListaVacia()
        {
            Usuario usuario = new Usuario()
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

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            Clave clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            Clave clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);

            List<string> dataBreach = new List<string>();


            Assert.AreEqual(0, usuario.GetClavesDataBreach(dataBreach).Count);
        }


        [TestMethod]
        public void UsuarioGetDataBreachNoVacio()
        {
            Usuario usuario = new Usuario()
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

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            Clave clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            Clave clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);

            List<string> dataBreach = new List<string>() {
                "EstaEsUnaClave1",
                "EstaEsUnaClave4"
            };

            List<Clave> esperadas = new List<Clave>() {
                clave1,
                clave4
            };

            List<Clave> retorno = usuario.GetClavesDataBreach(dataBreach);

            bool esperadasContieneRetorno = retorno.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(retorno.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetDataBreachClavesNoExistentes()
        {
            Usuario usuario = new Usuario()
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

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            Clave clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            Clave clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);

            List<string> dataBreach = new List<string>() {
                "ClaveNoContenida",
                "ClaveTampocoContenida",
                "EstaEsUnaClave3"
            };

            List<Clave> esperadas = new List<Clave>() {
                clave3
            };

            List<Clave> retorno = usuario.GetClavesDataBreach(dataBreach);

            bool esperadasContieneRetorno = retorno.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(retorno.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetTarjetasDataBreachVacio()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria trabajo = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Categoria facultad = new Categoria()
            {
                Nombre = "Facultad"
            };

            usuario.AgregarCategoria(trabajo);
            usuario.AgregarCategoria(facultad);



            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta1, trabajo);

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta2, facultad);


            List<string> dataBreach = new List<string>();

            Assert.AreEqual(0, usuario.GetTarjetasDataBreach(dataBreach).Count);
        }

        [TestMethod]
        public void UsuarioGetTarjetasDataBreachNoVacio()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria trabajo = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Categoria facultad = new Categoria()
            {
                Nombre = "Facultad"
            };

            usuario.AgregarCategoria(trabajo);
            usuario.AgregarCategoria(facultad);



            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta1, trabajo);

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta2, facultad);

            Tarjeta tarjeta3 = new Tarjeta()
            {
                Numero = "3333333333333333",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta3, facultad);

            List<string> dataBreach = new List<string>() {
                "1111111111111111",
                "UnaClave",
                "3333 3333 3333 3333",
                "4444 4444 4444 4444"
            };

            List<Tarjeta> esperadas = new List<Tarjeta>() {
                tarjeta1,
                tarjeta3
            };

            List<Tarjeta> retorno = usuario.GetTarjetasDataBreach(dataBreach);

            bool esperadasContieneRetorno = retorno.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(retorno.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }
    }
}
