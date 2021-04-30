using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestCategoria
    {

        [TestMethod]
        public void CategoriaGetNombreCorrecto()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", categoria.Nombre);
        }

        [TestMethod]
        public void CategoriaGetNombreCambiado()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", categoria.Nombre);
            categoria.Nombre = "Facultad";
            Assert.AreEqual("Facultad", categoria.Nombre);
        }

        [TestMethod]
        public void CategoriaLargoNombreMenorA3()
        {
            Categoria categoria = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria.Nombre = "A");
        }

        [TestMethod]
        public void CategoriaLargoNombreMayorA15()
        {
            Categoria categoria = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria.Nombre = "1234567890123456");
        }
    }

    [TestClass]
    public class TestCategoriaContras
    {
        [TestMethod]
        public void CategoriaEsListaContrasVaciaSinContras()
        {
            Categoria categoria = new Categoria();
            Assert.AreEqual(true, categoria.EsListaContrasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaContrasConContras()
        {
            Categoria categoria = new Categoria();
            Contra contra = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria.AgregarContra(contra);
            Assert.AreEqual(false, categoria.EsListaContrasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaContrasVaciaConDosContras()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Juan Perez"

            };
            categoria.AgregarContra(contra1);
            Assert.AreEqual(false, categoria.EsListaContrasVacia());
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria.AgregarContra(contra2);
            Assert.AreEqual(false, categoria.EsListaContrasVacia());
        }

        [TestMethod]
        public void CategoriaAgregarContraSinSitioOAplicacion()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarContra(contra1));
        }

        [TestMethod]
        public void CategoriaAgregarContraSinClave()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                UsuarioContra = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarContra(contra1));
        }

        [TestMethod]
        public void CategoriaAgregarContraSinUsuario()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarContra(contra1));
        }

        [TestMethod]
        public void testCategoriaAgregarContraYaExistente()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                UsuarioContra = "Roberto",
                Clave = "EstaEsUnaClave1"
            };
            categoria.AgregarContra(contra1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.AgregarContra(contra1));
        }

        [TestMethod]
        public void CategoriaGetContraCorrecta()
        {
            Categoria categoria1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria1.AgregarContra(contra1);
            Assert.AreEqual(contra1, categoria1.GetContra("web.whatsapp.com", "Roberto"));
        }

        [TestMethod]
        public void CategoriaGetContraPrimeraConDos()
        {
            Categoria categoria1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria1.AgregarContra(contra1);
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.AgregarContra(contra2);

            Assert.AreEqual(contra1, categoria1.GetContra("web.whatsapp.com", "Roberto")); ;
        }

        [TestMethod]
        public void CategoriaGetContraSegundaConDos()
        {
            Categoria categoria1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria1.AgregarContra(contra1);
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.AgregarContra(contra2);

            Assert.AreEqual(contra2, categoria1.GetContra("web.whatsapp.com", "Luis88")); ;
        }

        [TestMethod]
        public void CategoriaGetListaContras()
        {
            Categoria categoria1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria1.AgregarContra(contra1);
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.AgregarContra(contra2);

            List<Contra> contras = new List<Contra>
            {
                contra1,
                contra2
            };

            Assert.AreEqual(true, contras.SequenceEqual(categoria1.GetListaContras())); ;
        }

        [TestMethod]
        public void CategoriaEqualsMismoNombre()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(categoria1, categoria2);
        }

        [TestMethod]
        public void CategoriaEqualsDiferenteNombre()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreNotEqual(categoria1, categoria2);
        }

        [TestMethod]
        public void CategoriaEqualsMismoNombreConMayYMin()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = new Categoria()
            {
                Nombre = "personal"
            };
            Assert.AreEqual(categoria1, categoria2);
        }

        [TestMethod]
        public void CategoriaEqualsConNull()
        {
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria categoria2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria1.Equals(categoria2));
        }

        [TestMethod]
        public void CategoriaEqualsConString()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            String falsaCategoria = "Personal";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => categoria.Equals(falsaCategoria));
        }

        [TestMethod]
        public void CategoriaYaExisteContraSiExistente()
        {
            Categoria categoria = new Categoria();
            Contra contra = new Contra() {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(true, categoria.YaExisteContra(contraIgual));
        }

        [TestMethod]
        public void CategoriaYaExisteContraMismoUsuarioDiferenteSitio()
        {
            Categoria categoria = new Categoria();
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            Contra contraDiferenteSitio = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(false, categoria.YaExisteContra(contraDiferenteSitio));
        }

        [TestMethod]
        public void CategoriaYaExisteContraMismoSitioDiferenteUsuario()
        {
            Categoria categoria = new Categoria();
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            Contra contraDiferenteUsuario = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "222222",
                Clave = "12345678"
            };
            Assert.AreEqual(false, categoria.YaExisteContra(contraDiferenteUsuario));
        }

        [TestMethod]
        public void CategoriaYaExisteContraDiferentesClaves()
        {
            Categoria categoria = new Categoria();
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            Contra contraDiferenteClave = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "87654321"
            };
            Assert.AreEqual(true, categoria.YaExisteContra(contraDiferenteClave));
        }

        [TestMethod]
        public void CategoriaBorrarContraCategoriaVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarContra(paginaContra, usuarioContra));
        }

        [TestMethod]
        public void CategoriaBorrarContraExistenteCategoria()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Contra contra = new Contra()
            {
                UsuarioContra = usuarioContra,
                Sitio = paginaContra,
                Clave = "1234AbC$"
            };

            categoria.AgregarContra(contra);
            Assert.IsTrue(categoria.YaExisteContra(contra));
            categoria.BorrarContra(paginaContra, usuarioContra);
            Assert.IsFalse(categoria.YaExisteContra(contra));
        }

        [TestMethod]
        public void CategoriaEsListaContrasVaciaDespuesDeBorrar()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Contra contra = new Contra()
            {
                UsuarioContra = usuarioContra,
                Sitio = paginaContra,
                Clave = "1234AbC$"
            };

            categoria.AgregarContra(contra);
            categoria.BorrarContra(paginaContra, usuarioContra);
            Assert.IsTrue(categoria.EsListaContrasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaContrasVaciaDespuesDeBorrarAgregar()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Contra contra = new Contra()
            {
                UsuarioContra = usuarioContra,
                Sitio = paginaContra,
                Clave = "1234AbC$"
            };

            categoria.AgregarContra(contra);
            categoria.BorrarContra(paginaContra, usuarioContra);
            categoria.AgregarContra(contra);
            Assert.IsFalse(categoria.EsListaContrasVacia());
        }

        [TestMethod]
        public void CategoriaGetContraBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContraBorrar = "222222";
            String paginaContraBorrar = "www.ort.edu.uy";

            Contra contraBorrar = new Contra()
            {
                UsuarioContra = usuarioContraBorrar,
                Sitio = paginaContraBorrar,
                Clave = "1234AbC$"
            };

            categoria.AgregarContra(contraBorrar);
            categoria.BorrarContra(paginaContraBorrar, usuarioContraBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetContra(paginaContraBorrar, usuarioContraBorrar));
        }

        [TestMethod]
        public void CategoriaDosContrasGetContraBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContraBorrar = "222222";
            String paginaContraBorrar = "www.ort.edu.uy";

            Contra contraBorrar = new Contra()
            {
                UsuarioContra = usuarioContraBorrar,
                Sitio = paginaContraBorrar,
                Clave = "1234AbC$"
            };

            Contra contraOtra = new Contra()
            {
                UsuarioContra = "OtraContra",
                Sitio = "otroSitio.com",
                Clave = "1234AbC$"
            };


            categoria.AgregarContra(contraBorrar);
            categoria.AgregarContra(contraOtra);
            categoria.BorrarContra(paginaContraBorrar, usuarioContraBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetContra(paginaContraBorrar, usuarioContraBorrar));
        }


        //Prueba de agregar una contra y borrar otra que no existe en una categoria. Deberia tirar error.
        [TestMethod]
        public void CategoriaBorrarContraNoExistenteNoVacio()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContraBorrar = "222222";
            String paginaContraBorrar = "www.ort.edu.uy";


            Contra contraOtra = new Contra()
            {
                UsuarioContra = "OtraContra",
                Sitio = "otroSitio.com",
                Clave = "1234AbC$"
            };

            categoria.AgregarContra(contraOtra);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarContra(paginaContraBorrar, usuarioContraBorrar));
        }
    }

    [TestClass]
    public class TestCategoriaTarjeta
    {
        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaSinTarjetas()
        {
            Categoria categoria = new Categoria();
            Assert.AreEqual(true, categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConTarjetas()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);
            Assert.AreEqual(false, categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConDosTarjetas()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);
            Assert.AreEqual(false, categoria.EsListaTarjetasVacia());
            Tarjeta tarjeta2= new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta2);
            Assert.AreEqual(false, categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNombre()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinTipo()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNumero()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinCodigo()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinVencimiento()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = ""
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaGetTarjetaCorrecta()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);
            Assert.AreEqual(tarjeta1, categoria1.GetTarjeta("3456567890876543")); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaPrimeraConDos()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta2);

            Assert.AreEqual(tarjeta1, categoria1.GetTarjeta("3456567890876543")); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaSegundaConDos()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta2);

            Assert.AreEqual(tarjeta2, categoria1.GetTarjeta("1234567890876553"));
        }

        [TestMethod]
        public void CategoriaGetListaTarjetas()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.AgregarTarjeta(tarjeta2);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            Assert.AreEqual(true, tarjetas.SequenceEqual(categoria1.GetListaTarjetas()));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaSiExistente()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
        };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNumero()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1234567812345678",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(false, categoria.YaExisteTarjeta(tarjetaDistintoNumero));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNombre()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoNombre));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteTipo()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteCodigo()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void testCategoriaAgregarTarjetaYaExistente()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "345",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.AgregarTarjeta(tarjeta));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            string nroTarjeta = "1234567890876543";
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarTarjeta(nroTarjeta));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaConUnaTarjeta()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            string nroTarjeta = "1234567890876543";
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = nroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Assert.IsTrue(categoria.YaExisteTarjeta(tarjeta));
            categoria.BorrarTarjeta(nroTarjeta);
            Assert.IsFalse(categoria.YaExisteTarjeta(tarjeta));
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaDespuesDeBorrar()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            string nroTarjeta = "1234567890876543";
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = nroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Assert.IsTrue(categoria.YaExisteTarjeta(tarjeta));
            categoria.BorrarTarjeta(nroTarjeta);
            Assert.IsTrue(categoria.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaGetTarjetaBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string nroTarjeta = "1234567890876543";

            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = nroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            categoria.AgregarTarjeta(tarjeta);
            categoria.BorrarTarjeta(nroTarjeta);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetTarjeta(nroTarjeta));
        }

        [TestMethod]
        public void CategoriaDosTarjetasGetTarjetaBorrada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string nroTarjeta = "1234567890876543";

            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = nroTarjeta,
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "4254567490876549",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };


            categoria.AgregarTarjeta(tarjeta1);
            categoria.AgregarTarjeta(tarjeta2);
            categoria.BorrarTarjeta(nroTarjeta);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.GetTarjeta(nroTarjeta));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaQueNoExiste()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "4254567490876549",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            string nroTarjeta = "1234567890876543";

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.BorrarTarjeta(nroTarjeta));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteVencimiento()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2026, 9, 2)
            };
            Assert.AreEqual(true, categoria.YaExisteTarjeta(tarjetaDistintoTipo));
        }


        [TestMethod]
        public void CategoriaAlModificarTarjetaAgregadaLaTarjetaViejaDejaDeExistir()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjetaVieja = "4254567490876549";
            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjetaVieja,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjetaVieja);

            string numeroTarjetaNueva = "1234567890876543";
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjetaNueva,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaVieja
            };
            categoria.ModificarTarjeta(tarjetaVieja, tarjetaNueva);
            Assert.IsFalse(categoria.YaExisteTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaNoExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjeta = "4254567490876549";
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);

            string numeroTarjetaInexistente = "1234567890876543";

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.ModificarTarjeta(categoria.GetTarjeta(numeroTarjetaInexistente), tarjeta));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaYaExistente()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjeta = "4254567490876549";
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);

            string numeroTarjeta2 = "1234567890876543";
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Master",
                Tipo = "Mastercard",
                Numero = numeroTarjeta2,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 4, 1)
            };
            categoria.AgregarTarjeta(tarjeta2);

            Tarjeta duplicada = new Tarjeta()
            {
                Nombre = "Master",
                Tipo = "Mastercard",
                Numero = numeroTarjeta2,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 4, 1)
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.ModificarTarjeta(tarjeta1, duplicada));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaAgregada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string numeroTarjetaVieja = "4254567490876549";
            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjetaVieja,
                Codigo = "123",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjetaVieja);

            string numeroTarjetaNueva = "1234567890876543";
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjetaNueva,
                Nota = "",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            categoria.ModificarTarjeta(tarjetaVieja, tarjetaNueva);
            Assert.AreEqual(tarjetaNueva, categoria.GetTarjeta(numeroTarjetaNueva));
        }
    }
}
