using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestUsuario
    {
        [TestMethod]
        public void UsuarioGetNombreCorrecto()
        {
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", usuario.Nombre);
        }

        [TestMethod]
        public void UsuarioGetNombreCambiado()
        {
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", usuario.Nombre);
            usuario.Nombre = "Hernesto";
            Assert.AreEqual("Hernesto", usuario.Nombre);
        }

        [TestMethod]
        public void UsuarioLargoNombreMenorA5()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "A");
        }

        [TestMethod]
        public void UsuarioLargoNombreMayorA25()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "12345678901234567890123456");
        }

        [TestMethod]
        public void UsuarioValidarContraMaestra()
        {
            Usuario usuario = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(true, usuario.validarIgualContraMaestra("Hola12345"));
        }

        [TestMethod]
        public void UsuarioValidarContraMaestraDiferente()
        {
            Usuario u1 = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(false, u1.validarIgualContraMaestra("Diferente"));
        }

        [TestMethod]
        public void UsuarioValidarContraMaestraCambiada()
        {
            Usuario usuario = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(true, usuario.validarIgualContraMaestra("Hola12345"));

            usuario.ContraMaestra = "Chau109876";
            Assert.AreEqual(false, usuario.validarIgualContraMaestra("Hola12345"));
            Assert.AreEqual(true, usuario.validarIgualContraMaestra("Chau109876"));
        }

        [TestMethod]
        public void UsuarioLargoContraMaestraMenorA5()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ContraMaestra = "A");
        }

        [TestMethod]
        public void UsuarioLargoContraMaestraMayorA25()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ContraMaestra = "12345678901234567890123456");
        }
    }

    [TestClass]
    public class TestUsuarioCategoria
    {
        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaSinCategorias()
        {
            Usuario usuario = new Usuario();
            Assert.AreEqual(true, usuario.esListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioEsListaConCategoriasVaciaConUnaCategoria()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Assert.AreEqual(false, usuario.esListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaConDosCategorias()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.agregarCategoria(categoria);
            Assert.AreEqual(false, usuario.esListaCategoriasVacia());
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria2);
            Assert.AreEqual(false, usuario.esListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaVacia()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria();
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarCategoria(categoria));
        }

        [TestMethod]
        public void UsuarioGetCategoriaCorrecta()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Assert.AreEqual(categoria, usuario.getCategoria("Personal"));
        }

        [TestMethod]
        public void UsuarioGetCategoriaPrimeraConDos()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.agregarCategoria(categoria2);
            Assert.AreEqual(categoria, usuario.getCategoria("Personal"));
        }

        [TestMethod]
        public void UsuarioGetCategoriaSegundaConDos()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.agregarCategoria(categoria2);
            Assert.AreEqual(categoria2, usuario.getCategoria("Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaYaExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.agregarCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaSiExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(true, usuario.yaExisteCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaNoExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual(false, usuario.yaExisteCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioEqualsMismoNombreYContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario12"
            };
            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario12" 
            };
            Assert.AreEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioEqualsDiferenteNombreYMismaContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario123"
            };
            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario789"
            };
            Assert.AreNotEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioEqualsConNull()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario123"
            };
            Usuario usuario2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.Equals(usuario2));
        }

        [TestMethod]
        public void UsuarioEqualsConString()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario123"
            };
            String falsoUsuario = "Usuario123";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => usuario.Equals(falsoUsuario));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaAgregada()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);

            usuario.modificarNombreCategoria("Personal", "Trabajo");


            Assert.AreEqual("Trabajo", usuario.getCategoria("Trabajo").Nombre);
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaNoExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.modificarNombreCategoria("Facultad", "Trabajo"));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaANombreExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.agregarCategoria(categoria2);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.modificarNombreCategoria("Personal", "Trabajo"));
        }
    }


    [TestClass]
    public class TestUsuarioContra
    {

        [TestMethod]
        public void UsuarioYaExisteContraUnaCategoriaSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            { 
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.agregarContra(contra);
            usuario.agregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(true, usuario.yaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraMismoUsuarioDiferenteSitio()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.agregarContra(contra);
            usuario.agregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(false, usuario.yaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraMismoSitioDiferenteUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.agregarContra(contra);
            usuario.agregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "222222",
                Clave = "12345678"
            };
            Assert.AreEqual(false, usuario.yaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraDiferentesClaves()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.agregarContra(contra);
            usuario.agregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(true, usuario.yaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraDosCategoriasSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra1 = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria1.agregarContra(contra1);
            usuario.agregarCategoria(categoria1);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Contra contra2 = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "usuarioYoutube",
                Clave = "contra1234"
            };
            categoria2.agregarContra(contra2);
            usuario.agregarCategoria(categoria2);

            Contra contraIgual = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "usuarioYoutube",
                Clave = "contra1234"
            };
            Assert.AreEqual(true, usuario.yaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioAgregarContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            usuario.agregarCategoria(categoria);
            usuario.agregarContra(contra, "Trabajo");
            Assert.AreEqual(true, usuario.yaExisteContra(contra));
        }

        [TestMethod]
        public void UsuarioAgregarContraSinSitioOAplicacion()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarContra(contra, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarContraSinClave()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarContra(contra, "Trabajo"));
        }

        [TestMethod]
        public void CategoriaAgregarContraSinUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                Clave = "12345678"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarContra(contra, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarContraRepetida()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            usuario.agregarCategoria(categoria);
            usuario.agregarContra(contra, "Trabajo");
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.agregarContra(contra, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarContraCategoriaConContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            usuario.agregarCategoria(categoria);
            usuario.agregarContra(contra, "Trabajo");
            Assert.AreEqual(true, usuario.getCategoria("Trabajo").yaExisteContra(contra));
        }

    }
   
    [TestClass]
    public class TestUsuarioTarjeta
    {
        [TestMethod]
        public void UsuarioYaExisteTarjetaUnaCategoriaSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNumero()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1234567812345678",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(false, usuario.yaExisteTarjeta(tarjetaDistintoNumero));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNombre()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaDistintoNombre));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoTipo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoCodigo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteVencimiento()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2026, 9, 2)
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDosCategoriasSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Visa Gold",
                Numero = "7894561234567895",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta2);
            usuario.agregarCategoria(categoria2);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Visa Gold",
                Numero = "7894561234567895",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void UsuarioAgregarTarjeta()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.agregarCategoria(categoria);
            usuario.agregarTarjeta(tarjeta, "Trabajo");
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjeta));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinNombre()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarTarjeta(tarjeta, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinTipo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarTarjeta(tarjeta, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinNumero()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarTarjeta(tarjeta, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinCodigo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543"
            };
            usuario.agregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarTarjeta(tarjeta, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaRepetida()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.agregarCategoria(categoria);
            usuario.agregarTarjeta(tarjeta, "Trabajo");
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.agregarTarjeta(tarjeta, "Trabajo"));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaCategoriaConTarjeta()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.agregarCategoria(categoria);
            usuario.agregarTarjeta(tarjeta, "Trabajo");
            Assert.AreEqual(true, usuario.getCategoria("Trabajo").yaExisteTarjeta(tarjeta));
        }

    }
}
