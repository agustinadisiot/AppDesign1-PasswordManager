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
            Usuario u2 = new Usuario();
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
            Assert.AreEqual(contra1, categoria1.getContra("web.whatsapp.com", "Roberto")); ;
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

        //Prueba si al agregar una Contra y despues pregunta si ya existe, devuelve true.
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

        //Prueba si al agregar una Contra y despues pregunta si ya existe una con diferente sitio, devuelve false.
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
            Contra contraIgual = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(false, categoria.yaExisteContra(contraIgual));
        }

        //Prueba si al agregar una Contra y despues pregunta si ya existe una con mismo sitio y diferente usuario, devuelve false.
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
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "222222",
                Clave = "12345678"
            };
            Assert.AreEqual(false, categoria.yaExisteContra(contraIgual));
        }

        //Prueba si al agregar una Contra y despues pregunta si ya existe una con mismo sitio y usuario, devuelve true a pesar de tener diferentes claves.
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
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            Assert.AreEqual(true, categoria.yaExisteContra(contraIgual));
        }
    }

}
