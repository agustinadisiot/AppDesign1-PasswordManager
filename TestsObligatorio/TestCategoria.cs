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
        //Prueba si devuelve el nombre correcto de la categoria.
        [TestMethod]
        public void testUsuarioGetNombreTrabajo()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", c1.Nombre);
        }


        //Prueba si al cambiar el nombre de categoria, cambia lo que devuelve.
        [TestMethod]
        public void testCategoriaGetNombreCambio()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", c1.Nombre);
            c1.Nombre = "Facultad";
            Assert.AreEqual("Facultad", c1.Nombre);
        }


        //Prueba si al ingresar un nombre a la categoria con largo menor a 3, devuelve un error.
        [TestMethod]
        public void testCategoriaLargoNombreMenorA3()
        {
            Categoria c1 = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.Nombre = "A");
        }


        //Prueba si al ingresar un nombre con largo mayor a 15, devuelve un error.
        [TestMethod]
        public void testCategoriaLargoNombreMayorA15()
        {
            Categoria c1 = new Categoria();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.Nombre = "1234567890123456");
        }


        //Prueba si al comenzar la Categoria tiene una lista vacía de contraseñas guardadas. 
        [TestMethod]
        public void testCategoriaEsListaContrasVacia()
        {
            Categoria c1 = new Categoria();
            Assert.AreEqual(true, c1.esListaContrasVacia());
        }


        //Prueba si al agregar una contraseña, esListaContrasVacia da false
        [TestMethod]
        public void testCategoriaEsListaContrasConContras()
        {
            Categoria c1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            c1.agregarContra(contra1);
            Assert.AreEqual(false, c1.esListaContrasVacia());
        }


        //Prueba si al agregar dos contraseñas a una categoria, esListaContrasVacia sigue dando false
        [TestMethod]
        public void testCategoriaEsListaUsuariosContrasVaciaConDosContras()
        {
            Categoria c1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Juan Perez"

            };
            c1.agregarContra(contra1);
            Assert.AreEqual(false, c1.esListaContrasVacia());
            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            c1.agregarContra(contra2);
            Assert.AreEqual(false, c1.esListaContrasVacia());
        }


        //Prueba si al ingresar una Contra a la categoria sin sitio o aplicacion, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarContraSinSitioOAplicacion()
        {
            Categoria c1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.agregarContra(contra1));
        }

        //Prueba si al ingresar una Contra a la categoria sin clave, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarContraSinClave()
        {
            Categoria c1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                UsuarioContra = "Roberto"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.agregarContra(contra1));
        }

        //Prueba si al ingresar una Contra a la categoria sin usuario, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarContraSinUsuario()
        {
            Categoria c1 = new Categoria();
            Contra contra1 = new Contra()
            {
                Sitio = "youtube.com",
                Clave = "EstaEsUnaClave1"
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.agregarContra(contra1));
        }

        //Prueba si al ingresar una Contra a la categoria devuelve la correcta al usar el get.
        [TestMethod]
        public void testCategoriaGetContra()
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
        public void testCategoriaGetContraPrimeraConDos()
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
        public void testCategoriaGetContraSegundaConDos()
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
        public void testCategoriaGetListaContras()
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

            List<Contra> contras = new List<Contra>();
            contras.Add(contra1);
            contras.Add(contra2);

            Assert.AreEqual(true, contras.SequenceEqual(categoria1.getListaContras())); ;
        }

        //Prueba de comparar dos Categorias con el mismo nombre da true el equals
        [TestMethod]
        public void testCategoriaEqualsMismoNombre()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria c2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(c1, c2);
        }

        //Prueba de comparar dos Categorias con diferente nombre da true el equals
        [TestMethod]
        public void testCategoriaEqualsDiferenteNombre()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria c2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreNotEqual(c1, c2);
        }

        //Prueba de comparar dos Categorias con mismo nombre con mayusculas y minusculas
        [TestMethod]
        public void testCategoriaEqualsMismoNombreConMayYMin()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria c2 = new Categoria()
            {
                Nombre = "personal"
            };
            Assert.AreEqual(c1, c2);
        }

        //Prueba de comparar dos Categorias donde una es null
        [TestMethod]
        public void testCategoriaEqualsConNull()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria c2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.Equals(c2));
        }

        //Prueba de comparar dos Categorias donde una es de tipo incorrecto
        [TestMethod]
        public void testCategoriaEqualsConString()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            String falsaCategoria = "Personal";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => c1.Equals(falsaCategoria));
        }

        //Prueba que agregrega una Contra y despues pregunta si ya existe, devuelve true.
        [TestMethod]
        public void testCategoriaYaExisteContraSiExistente()
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
        public void testCategoriaYaExisteContraMismoUsuarioDiferenteSitio()
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
        public void testCategoriaYaExisteContraMismoSitioDiferenteUsuario()
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
        public void testCategoriaYaExisteContraDiferentesClaves()
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
    }

    [TestClass]
    public class TestCategoriaTarjeta
    {
        //Prueba si al comenzar la Categoria tiene una lista vacía de tarjetas guardadas. 
        [TestMethod]
        public void testCategoriaEsListaTarjetasVacia()
        {
            Categoria c1 = new Categoria();
            Assert.AreEqual(true, c1.esListaTarjetasVacia());
        }


        //Prueba si al agregar una tarjeta, esListaTarjetasVacia da false
        [TestMethod]
        public void testCategoriaEsListaContrasConContras()
        {
            Categoria c1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = ""
            };
            c1.agregarTarjeta(tarjeta1);
            Assert.AreEqual(false, c1.esListaTarjetasVacia());
        }


        //Prueba si al agregar dos tarjetas a una categoria, esListaTarjetasVacia sigue dando false
        [TestMethod]
        public void testCategoriaEsListaUsuariosTarjetasVaciaConDosTarjetas()
        {
            Categoria c1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Codigo = "567",
                Nota = ""

            };
            c1.agregarTarjeta(tarjeta1);
            Assert.AreEqual(false, c1.esListaTarjetasVacia());
            Tarjeta tarjeta2= new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = ""
            };
            c1.agregarTarjeta(tarjeta2);
            Assert.AreEqual(false, c1.esListaTarjetasVacia());
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Nombre, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarTarjetaSinNombre()
        {
            Categoria c1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = ""
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Tipo, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarTarjetaSinTipo()
        {
            Categoria c1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Nota = ""
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Numero, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarTarjetaSinNumero()
        {
            Categoria c1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "321",
                Nota = ""
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria sin Codigo, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarTarjetaSinCodigo()
        {
            Categoria c1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876543",
                Nota = ""
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.agregarTarjeta(tarjeta1));
        }

        //Prueba si al ingresar una Tarjeta a la categoria devuelve la correcta al usar el get.
        [TestMethod]
        public void testCategoriaGetTarjeta()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria1.agregarTarjeta(tarjeta1);
            Assert.AreEqual(tarjeta1, categoria1.getTarjeta("3456567890876543")); 
        }

        //Prueba si al ingresar dos Tarjetas a la categoria devuelve la correcta al usar el get para la primera.
        [TestMethod]
        public void testCategoriaGetTarjetaPrimeraConDos()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria1.agregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789"
            };
            categoria1.agregarTarjeta(tarjeta2);

            Assert.AreEqual(tarjeta1, categoria1.getTarjeta("3456567890876543")); 
        }

        //Prueba si al ingresar dos Tarjetas a la categoria devuelve la correcta al usar el get para la segunda.
        [TestMethod]
        public void testCategoriaGetTarjetaSegundaConDos()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria1.agregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789"
            };
            categoria1.agregarTarjeta(tarjeta2);

            Assert.AreEqual(tarjeta2, categoria1.getTarjeta("1234567890876553"));
        }

        //Prueba si al ingresar dos Tarjetas a la categoria devuelve una lista de las tarjetas agregadas.
        [TestMethod]
        public void testCategoriaGetListaTarjetas()
        {
            Categoria categoria1 = new Categoria();
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria1.agregarTarjeta(tarjeta1);
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = "1234567890876553",
                Codigo = "789"
            };
            categoria1.agregarTarjeta(tarjeta2);

            List<Tarjeta> tarjetas = new List<Tarjeta>();
            tarjetas.Add(tarjeta1);
            tarjetas.Add(tarjeta2);

            Assert.AreEqual(true, tarjetas.SequenceEqual(categoria1.getListaTarjetas())); ;
        }


        //Prueba que agregrega una tarjeta y despues pregunta si ya existe, devuelve true.
        [TestMethod]
        public void testCategoriaYaExisteTarjetaSiExistente()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaIgual));
        }


        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente numero e igual nombre, tipo y codigo, devuelve false.
        [TestMethod]
        public void testCategoriaYaExisteTarjetaDiferenteNumero()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1234567812345678",
                Codigo = "321"
            };
            Assert.AreEqual(false, categoria.yaExisteTarjeta(tarjetaDistintoNumero));
        }


        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente nombre e igual numero, tipo y codigo, devuelve true.
        [TestMethod]
        public void testCategoriaYaExisteTarjetaDiferenteNombre()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaDistintoNombre));
        }


        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente tipo e igual nombre, numero y codigo, devuelve true.
        [TestMethod]
        public void testCategoriaYaExisteTarjetaDiferenteTipo()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard Gold",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaDistintoTipo));
        }


        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente codigo e igual nombre, numero y tipo, devuelve true.
        [TestMethod]
        public void testCategoriaYaExisteTarjetaDiferenteCodigo()
        {

            Categoria categoria = new Categoria();
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123"
            };
            Assert.AreEqual(true, categoria.yaExisteTarjeta(tarjetaDistintoTipo));
        }

        //Prueba de borrar una tarjeta de una Categoria vacia
        [TestMethod]
        public void testCategoriaBorrarTarjetaCategoriaVacia()
        {
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };

            String nroTarjeta = "1234567890876543";
            Assert.ThrowsException<ObjetoInexistenteException>(() => c1.borrarTarjeta(nroTarjeta));
        }

    }
}
