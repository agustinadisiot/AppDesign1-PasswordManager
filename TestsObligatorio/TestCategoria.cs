﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        //Prueba si devuelve el nombre correcto de la categoria.
        [TestMethod]
        public void UsuarioGetNombreTrabajo()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", categoria.Nombre);
        }

        //Prueba si al cambiar el nombre de categoria, cambia lo que devuelve.
        [TestMethod]
        public void CategoriaGetNombreCambio()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", categoria.Nombre);
            categoria.Nombre = "Facultad";
            Assert.AreEqual("Facultad", categoria.Nombre);
        }

        //Prueba si al ingresar un nombre a la categoria con largo menor a 3, devuelve un error.
        [TestMethod]
        public void CategoriaLargoNombreMenorA3()
        {
            Categoria categoria = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria.Nombre = "A");
        }

        //Prueba si al ingresar un nombre con largo mayor a 15, devuelve un error.
        [TestMethod]
        public void CategoriaLargoNombreMayorA15()
        {
            Categoria categoria = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria.Nombre = "1234567890123456");
        }

        //Prueba si al comenzar la Categoria tiene una lista vacía de contraseñas guardadas. 
        [TestMethod]
        public void CategoriaEsListaContrasVacia()
        {
            Categoria categoria = new Categoria();
            Assert.AreEqual(true, categoria.esListaContrasVacia());
        }

        //Prueba si al agregar una contraseña, esListaContrasVacia da false
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
            categoria.agregarContra(contra);
            Assert.AreEqual(false, categoria.esListaContrasVacia());
        }

        //Prueba si al agregar dos contraseñas a una categoria, esListaContrasVacia sigue dando false
        [TestMethod]
        public void CategoriaEsListaUsuariosContrasVaciaConDosContras()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Juan Perez"

            };
            categoria.agregarContra(contra1);
            Assert.AreEqual(false, categoria.esListaContrasVacia());
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria.agregarContra(contra2);
            Assert.AreEqual(false, categoria.esListaContrasVacia());
        }

        //Prueba si al ingresar una Contra a la categoria sin sitio o aplicacion, devuelve un error.
        [TestMethod]
        public void CategoriaAgregarContraSinSitioOAplicacion()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarContra(contra1));
        }

        //Prueba si al ingresar una Contra a la categoria sin clave, devuelve un error.
        [TestMethod]
        public void CategoriaAgregarContraSinClave()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                UsuarioContra = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarContra(contra1));
        }

        //Prueba si al ingresar una Contra a la categoria sin usuario, devuelve un error.
        [TestMethod]
        public void CategoriaAgregarContraSinUsuario()
        {
            Categoria categoria = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarContra(contra1));
        }

        //Prueba si al ingresar una Contra ya existente a la categoria tira una excepcion.
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
            categoria.agregarContra(contra1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.agregarContra(contra1));
        }

        //Prueba si al ingresar una Contra a la categoria devuelve la correcta al usar el get.
        [TestMethod]
        public void CategoriaGetContra()
        {
            Categoria categoria1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria1.agregarContra(contra1);
            Assert.AreEqual(contra1, categoria1.getContra("web.whatsapp.com", "Roberto"));
        }

        //Prueba si al ingresar dos Contras a la categoria devuelve la correcta al usar el get para la primera.
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
            categoria1.agregarContra(contra1);
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.agregarContra(contra2);

            Assert.AreEqual(contra1, categoria1.getContra("web.whatsapp.com", "Roberto")); ;
        }

        //Prueba si al ingresar dos Contras a la categoria devuelve la correcta al usar el get para la segunda.
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
            categoria1.agregarContra(contra1);
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.agregarContra(contra2);

            Assert.AreEqual(contra2, categoria1.getContra("web.whatsapp.com", "Luis88")); ;
        }

        //Prueba si al ingresar dos Contras a la categoria devuelve una lista de las contras agregadas.
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
            categoria1.agregarContra(contra1);
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.agregarContra(contra2);

            List<Contra> contras = new List<Contra>
            {
                contra1,
                contra2
            };

            Assert.AreEqual(true, contras.SequenceEqual(categoria1.getListaContras())); ;
        }

        //Prueba de comparar dos Categorias con el mismo nombre da true el equals.
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

        //Prueba de comparar dos Categorias con diferente nombre da true el equals.
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

        //Prueba de comparar dos Categorias con mismo nombre con mayusculas y minusculas.
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

        //Prueba de comparar dos Categorias donde una es null.
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

        //Prueba de comparar dos Categorias donde una es de tipo incorrecto.
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

        //Prueba que agregrega una Contra y despues pregunta si ya existe, devuelve true.
        [TestMethod]
        public void CategoriaYaExisteContraSiExistente()
        {
            Categoria categoria = new Categoria();
            Contra contra = new Contra() {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.agregarContra(contra);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(true, categoria.yaExisteContra(contraIgual));
        }

        //Prueba que agregrega una Contra y despues pregunta si ya existe una con diferente sitio, devuelve false.
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
            categoria.agregarContra(contra);
            Contra contraDiferenteSitio = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(false, categoria.yaExisteContra(contraDiferenteSitio));
        }

        //Prueba que agregrega una Contra y despues pregunta si ya existe una con mismo sitio y diferente usuario, devuelve false.
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
            categoria.agregarContra(contra);
            Contra contraDiferenteUsuario = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "222222",
                Clave = "12345678"
            };
            Assert.AreEqual(false, categoria.yaExisteContra(contraDiferenteUsuario));
        }

        //Prueba que agregrega una Contra y despues pregunta si ya existe una con mismo sitio y usuario, devuelve true a pesar de tener diferentes claves.
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
            categoria.agregarContra(contra);
            Contra contraDiferenteClave = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "87654321"
            };
            Assert.AreEqual(true, categoria.yaExisteContra(contraDiferenteClave));
        }

        //Prueba de borrar una Contra a una Categoria vacia, y deberia tirar una excepcion.
        [TestMethod]
        public void CategoriaBorrarContraCategoriaVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.borrarContra(paginaContra, usuarioContra));
        }

        //Prueba de borrar una Contra a una Categoria que acaba de agregar, la primera vez que pregunta si existe deberia ser true y la segunda false.
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

            categoria.agregarContra(contra);
            Assert.IsTrue(categoria.yaExisteContra(contra));
            categoria.borrarContra(paginaContra, usuarioContra);
            Assert.IsFalse(categoria.yaExisteContra(contra));
        }

        //Prueba de borrar una Contra a una Categoria y se fija si esListaContraVacia da true.
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

            categoria.agregarContra(contra);
            categoria.borrarContra(paginaContra, usuarioContra);
            Assert.IsTrue(categoria.esListaContrasVacia());
        }

        //Prueba de borrar una Contra a una Categoria, luego agregar otra, y que deje de estar vacia la lista de Contras.
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

            categoria.agregarContra(contra);
            categoria.borrarContra(paginaContra, usuarioContra);
            categoria.agregarContra(contra);
            Assert.IsFalse(categoria.esListaContrasVacia());
        }

        //Prueba de borrar una Contra a una Categoria y luego pedirla. Deberia tirar exception.
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

            categoria.agregarContra(contraBorrar);
            categoria.borrarContra(paginaContraBorrar, usuarioContraBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.getContra(paginaContraBorrar, usuarioContraBorrar));
        }

        //Prueba de agregar dos contras a una categoria, borrar una Contra y luego pedir la borrada.
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


            categoria.agregarContra(contraBorrar);
            categoria.agregarContra(contraOtra);
            categoria.borrarContra(paginaContraBorrar, usuarioContraBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.getContra(paginaContraBorrar, usuarioContraBorrar));
        }

    }

    [TestClass]
    public class TestCategoriaTarjeta
    {
        //Prueba si al comenzar la Categoria tiene una lista vacía de tarjetas guardadas. 
        [TestMethod]
        public void CategoriaEsListaTarjetasVacia()
        {
            Categoria categoria = new Categoria();
            Assert.AreEqual(true, categoria.esListaTarjetasVacia());
        }

        //Prueba si al agregar una tarjeta, esListaTarjetasVacia da false.
        [TestMethod]
        public void CategoriaEsListaTarjetasConTarjetas()
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
            categoria.agregarTarjeta(tarjeta1);
            Assert.AreEqual(false, categoria.esListaTarjetasVacia());
        }

        //Prueba si al agregar dos tarjetas a una categoria, esListaTarjetasVacia sigue dando false.
        [TestMethod]
        public void CategoriaEsListaUsuariosTarjetasVaciaConDosTarjetas()
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
            categoria.agregarTarjeta(tarjeta1);
            Assert.AreEqual(false, categoria.esListaTarjetasVacia());
            Tarjeta tarjeta2= new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.agregarTarjeta(tarjeta2);
            Assert.AreEqual(false, categoria.esListaTarjetasVacia());
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Nombre, devuelve un error.
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Tipo, devuelve un error.
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Numero, devuelve un error.
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Codigo, devuelve un error.
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Vencimiento, devuelve un error.
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria devuelve la correcta al usar el get.
        [TestMethod]
        public void CategoriaGetTarjeta()
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
            categoria1.agregarTarjeta(tarjeta1);
            Assert.AreEqual(tarjeta1, categoria1.getTarjeta("3456567890876543")); 
        }

        //Prueba si al ingresar dos Tarjetas a la categoria devuelve la correcta al usar el get para la primera.
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
            categoria1.agregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.agregarTarjeta(tarjeta2);

            Assert.AreEqual(tarjeta1, categoria1.getTarjeta("3456567890876543")); 
        }

        //Prueba si al ingresar dos Tarjetas a la categoria devuelve la correcta al usar el get para la segunda.
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
            categoria1.agregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.agregarTarjeta(tarjeta2);

            Assert.AreEqual(tarjeta2, categoria1.getTarjeta("1234567890876553"));
        }

        //Prueba si al ingresar dos Tarjetas a la categoria devuelve una lista de las tarjetas agregadas.
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
            categoria1.agregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria1.agregarTarjeta(tarjeta2);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            Assert.AreEqual(true, tarjetas.SequenceEqual(categoria1.getListaTarjetas()));
        }

        //Prueba que agregrega una tarjeta y despues pregunta si ya existe, devuelve true.
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
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaIgual));
        }

        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente numero e igual nombre, tipo, vencimiento y codigo, devuelve false.
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
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1234567812345678",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(false, categoria.yaExisteTarjeta(tarjetaDistintoNumero));
        }

        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente nombre e igual numero, tipo, vencimiento y codigo, devuelve true.
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
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaDistintoNombre));
        }

        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente tipo e igual nombre, numero, vencimiento y codigo, devuelve true.
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
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaDistintoTipo));
        }

        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente codigo e igual nombre, numero, vencimiento y tipo, devuelve true.
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
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaDistintoTipo));
        }

        //Prueba si al ingresar una Tarjeta ya existente a la categoria tira una excepcion.
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
            categoria.agregarTarjeta(tarjeta);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria.agregarTarjeta(tarjeta));
        }

        //Prueba de borrar una tarjeta de una Categoria vacia
        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaVacia()
        {
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            string nroTarjeta = "1234567890876543";
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.borrarTarjeta(nroTarjeta));
        }


        //Prueba de borrar una tarjeta de una Categoria con una tarjeta
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
            categoria.agregarTarjeta(tarjeta);
            Assert.IsTrue(categoria.yaExisteTarjeta(tarjeta));
            categoria.borrarTarjeta(nroTarjeta);
            Assert.IsFalse(categoria.yaExisteTarjeta(tarjeta));
        }

        //Prueba de borrar una tarjeta haya quedado vacia la lista de tarjetas
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
            categoria.agregarTarjeta(tarjeta);
            Assert.IsTrue(categoria.yaExisteTarjeta(tarjeta));
            categoria.borrarTarjeta(nroTarjeta);
            Assert.IsTrue(categoria.esListaTarjetasVacia());
        }

        //Prueba de borrar una Tarjeta a una Categoria y luego pedirla. Deberia tirar exception.
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

            categoria.agregarTarjeta(tarjeta);
            categoria.borrarTarjeta(nroTarjeta);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.getTarjeta(nroTarjeta));
        }


        //Prueba de agregar dos tarjetas a una categoria, borrar una tarjeta y luego pedir la borrada.
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


            categoria.agregarTarjeta(tarjeta1);
            categoria.agregarTarjeta(tarjeta2);
            categoria.borrarTarjeta(nroTarjeta);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.getTarjeta(nroTarjeta));
        }


        //Prueba de intentar borrar una Tarjeta que nunca fue agregada a la categoria
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
            categoria.agregarTarjeta(tarjeta);
            string nroTarjeta = "1234567890876543";

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria.borrarTarjeta(nroTarjeta));
        }
        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente vencimiento e igual nombre, numero, codigo y tipo, devuelve true.
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
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2026, 9, 2)
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaDistintoTipo));
        }
    }
}
