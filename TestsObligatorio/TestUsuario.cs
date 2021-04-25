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

        //Prueba si devuelve el nombre correcto.
        [TestMethod]
        public void testUsuarioGetNombreRoberto()
        {
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", u1.Nombre);
        }


        //Prueba si al cambiar el nombre, cambia lo que devuelve.
        [TestMethod]
        public void testUsuarioGetNombreCambio()
        {
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", u1.Nombre);
            u1.Nombre = "Hernesto";
            Assert.AreEqual("Hernesto", u1.Nombre);
        }


        //Prueba si al ingresar un nombre con largo menor a 5, devuelve un error.
        [TestMethod]
        public void testUsuarioLargoNombreMenorA5()
        {
            Usuario u1 = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => u1.Nombre = "A");
        }


        //Prueba si al ingresar un nombre con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void testUsuarioLargoNombreMayorA25()
        {
            Usuario u1 = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => u1.Nombre = "12345678901234567890123456");
        }


        //Prueba de darle una constraseña maestra y luego valida con true si el usuario tiene la misma.
        [TestMethod]
        public void testUsuarioValidarContraMaestra()
        {
            Usuario u1 = new Usuario();
            u1.ContraMaestra = "Hola12345";
            Assert.AreEqual(true, u1.validarIgualContraMaestra("Hola12345"));
        }


        //Prueba de darle una constraseña maestra y luego validar que una distinta de false.
        [TestMethod]
        public void testUsuarioValidarContraMaestraDiferente()
        {
            Usuario u1 = new Usuario();
            u1.ContraMaestra = "Hola12345";
            Assert.AreEqual(false, u1.validarIgualContraMaestra("Diferente"));
        }


        //Prueba de validar una contraseña maestra, validarla, luego cambiarla y validarla de nuevo con la vieja y nueva contraseña. 
        [TestMethod]
        public void testUsuarioValidarContraMaestraCambiada()
        {
            Usuario u1 = new Usuario();
            u1.ContraMaestra = "Hola12345";
            Assert.AreEqual(true, u1.validarIgualContraMaestra("Hola12345"));

            u1.ContraMaestra = "Chau109876";
            Assert.AreEqual(false, u1.validarIgualContraMaestra("Hola12345"));
            Assert.AreEqual(true, u1.validarIgualContraMaestra("Chau109876"));
        }


        //Prueba si al ingresar una contraMaestra con largo menor a 5, devuelve un error.
        [TestMethod]
        public void testUsuarioLargoContraMaestraMenorA5()
        {
            Usuario u1 = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => u1.ContraMaestra = "A");
        }


        //Prueba si al ingresar una contraMaestra con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void testUsuarioLargoContraMaestraMayorA25()
        {
            Usuario u1 = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => u1.ContraMaestra = "12345678901234567890123456");
        }


        //Prueba si al comenzar el Usuario tiene una lista vacía de categorias guardadas. 
        [TestMethod]
        public void testUsuarioEsListaCategoriasVacia()
        {
            Usuario u1 = new Usuario();
            Assert.AreEqual(true, u1.esListaCategoriasVacia());
        }


        //Prueba si al agregar una categoria, esListaCategoriasVacia da false
        [TestMethod]
        public void testUsuarioEsListaConCategorias()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Assert.AreEqual(false, u1.esListaCategoriasVacia());
        }

        //Prueba si al agregar dos categorias, esListaCategoriasVacia sigue dando false
        [TestMethod]
        public void testUsuarioEsListaCategoriasVaciaConDosCategorias()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            u1.agregarCategoria(c1);
            Assert.AreEqual(false, u1.esListaCategoriasVacia());
            Categoria c2 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c2);
            Assert.AreEqual(false, u1.esListaCategoriasVacia());
        }

        //Prueba si al ingresar una categoria vacia tire una excepcion
        [TestMethod]
        public void testUsuarioAgregarCategoriaVacia()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria();
            Assert.ThrowsException<ObjetoIncompletoException>(() => u1.agregarCategoria(c1));
        }

        //Prueba si al agregar una categoria y despues pedirla devuelve la misma
        [TestMethod]
        public void testUsuarioGetCategoria()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Assert.AreEqual(c1, u1.getCategoria("Personal"));
        }

        //Prueba si al agregar dos categorias y despues pedirle la primera devuelve la misma
        [TestMethod]
        public void testUsuarioGetCategoriaPrimeraConDos()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Categoria c2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            u1.agregarCategoria(c2);
            Assert.AreEqual(c1, u1.getCategoria("Personal"));
        }

        //Prueba si al agregar dos categorias y despues pedirle la segunda devuelve la correcta
        [TestMethod]
        public void testUsuarioGetCategoriaSegundaConDos()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Categoria c2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            u1.agregarCategoria(c2);
            Assert.AreEqual(c2, u1.getCategoria("Trabajo"));
        }


        //Prueba si al agregar una categoria y despues intenta agregar otra categoria con el mismo nombre tira una excepcion.
        [TestMethod]
        public void testUsuarioAgregarCategoriaYaExistente()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Categoria c2 = new Categoria()
            {
                Nombre = "Personal"
            };
            
            Assert.ThrowsException<ObjetoYaExistenteException>(() => u1.agregarCategoria(c2));
        }


        //Prueba si al agregar una categoria y despues pregunta si ya existe, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteCategoriaSiExistente()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Categoria c2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(true, u1.yaExisteCategoria(c2));
        }

        //Prueba si al agregar una categoria y despues pregunta si ya existe, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteCategoriaNoExistente()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Categoria c2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual(false, u1.yaExisteCategoria(c2));
        }

        //Prueba de comparar dos Usuarios con mismo Nombre  da true el equals
        [TestMethod]
        public void testUsuarioEqualsMismoNombreYContra()
        {
            Usuario u1 = new Usuario()
            {
                Nombre = "Usuario12"
            };
            Usuario u2 = new Usuario()
            {
                Nombre = "Usuario12" 
            };
            Assert.AreEqual(u1, u2);
        }

        //Prueba de comparar dos Usuarios con diferente Nombre da flase el equals
        [TestMethod]
        public void testUsuarioEqualsDiferenteNombreYMismaContra()
        {
            Usuario u1 = new Usuario()
            {
                Nombre = "Usuario123"
            };
            Usuario u2 = new Usuario()
            {
                Nombre = "Usuario789"
            };
            Assert.AreNotEqual(u1, u2);
        }

        //Prueba de comparar dos Usuarios donde uno es null
        [TestMethod]
        public void testUsuarioEqualsConNull()
        {
            Usuario u1 = new Usuario()
            {
                Nombre = "Usuario123"
            };
            Usuario u2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => u1.Equals(u2));
        }

        //Prueba de comparar dos Usuarios donde uno es de tipo incorrecto
        [TestMethod]
        public void testUsuarioEqualsConString()
        {
            Usuario u1 = new Usuario()
            {
                Nombre = "Usuario123"
            };
            String falsoUsuario = "Usuario123";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => u1.Equals(falsoUsuario));
        }


        //Prueba si al agregar una categoria y luego modificar el nombre, efectivamente lo modifique.
        [TestMethod]
        public void testUsuarioModificarNombreCategoriaAgregada()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);

            u1.modificarNombreCategoria("Personal", "Trabajo");


            Assert.AreEqual("Trabajo", u1.getCategoria("Trabajo").Nombre);
        }


        //Prueba si al agregar una categoria y luego intentar modificar el nombre de otra categoria, que tire una excepcion.
        [TestMethod]
        public void testUsuarioModificarNombreCategoriaNoExistente()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Assert.ThrowsException<ObjetoInexistenteException>(() => u1.modificarNombreCategoria("Facultad", "Trabajo"));
        }

        //Prueba si al agregar una categoria y luego intentar modificar el nombre de otra categoria, que tire una excepcion.
        [TestMethod]
        public void testUsuarioModificarNombreCategoriaANombreExistente()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria()
            {
                Nombre = "Personal"
            };
            u1.agregarCategoria(c1);
            Categoria c2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            u1.agregarCategoria(c2);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => u1.modificarNombreCategoria("Personal", "Trabajo"));
        }
    }


    [TestClass]
    public class TestUsuarioContra
    {

        //Prueba que agrega una Contra y despues pregunta si ya existe, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteContraUnaCategoriaSiExistente()
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

        //Prueba que agrega una Contra y despues pregunta si ya existe una con diferente sitio, devuelve false.
        [TestMethod]
        public void testUsuarioYaExisteContraMismoUsuarioDiferenteSitio()
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

        //Prueba que agrega una Contra y despues pregunta si ya existe una con mismo sitio y diferente usuario, devuelve false.
        [TestMethod]
        public void testUsuarioYaExisteContraMismoSitioDiferenteUsuario()
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

        //Prueba que agrega una Contra y despues pregunta si ya existe una con mismo sitio y usuario, devuelve true a pesar de tener diferentes claves.
        [TestMethod]
        public void testUsuarioYaExisteContraDiferentesClaves()
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


        //Prueba que agrega una Contra en una categoria y despues pregunta si ya existe en el usuario en otra categoria, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteContraDosCategoriasSiExistente()
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


        //Prueba si al agregar una contraseña a una categoria en usuario, yaExisteContra da true
        [TestMethod]
        public void testUsuarioAgregarContra()
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


        //Prueba si al ingresar una Contra a la categoria en usuario sin sitio o aplicacion, devuelve un error.
        [TestMethod]
        public void testUsuarioAgregarContraSinSitioOAplicacion()
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


        //Prueba si al ingresar una Contra a la categoria en un usuario sin clave, devuelve un error.
        [TestMethod]
        public void testUsuarioAgregarContraSinClave()
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


        //Prueba si al ingresar una Contra a la categoria en usuario sin UsuarioContra, devuelve un error.
        [TestMethod]
        public void testCategoriaAgregarContraSinUsuario()
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

        //Prueba si al ingresar una Contra repetida a una categoria en el usuario, devuelve un error 
        [TestMethod]
        public void testUsuarioAgregarContraRepetida()
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


        //Prueba si al ingresar una Contra a una categoria en el usuario, confirma que sa categoria tiene una contra. 
        [TestMethod]
        public void testUsuarioAgregarContraCategoriaConContra()
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
        //Prueba que agrega una Tarjeta a una categoria en el usurio y despues pregunta si ya existe, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteTarjetaUnaCategoriaSiExistente()
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
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaIgual));
        }


        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente numero e igual nombre, tipo y codigo, devuelve false.
        [TestMethod]
        public void testUsuarioYaExisteTarjetaDistintoNumero()
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
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1234567812345678",
                Codigo = "321"
            };
            Assert.AreEqual(false, usuario.yaExisteTarjeta(tarjetaDistintoNumero));
        }


        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente nombre e igual numero, tipo y codigo, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteTarjetaDistintoNombre()
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
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaDistintoNombre));
        }


        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente tipo e igual nombre, numero y codigo, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteTarjetaDistintoTipo()
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
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard Gold",
                Numero = "3456567890876543",
                Codigo = "321"
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaDistintoTipo));
        }


        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente codigo e igual nombre, numero y tipo, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteTarjetaDistintoCodigo()
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
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta);
            usuario.agregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123"
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaDistintoTipo));
        }


        //Prueba que agrega una Tarjeta en una categoria y despues pregunta si ya existe en el usuario en otra categoria, devuelve true.
        [TestMethod]
        public void testUsuarioYaExisteTarjetaDosCategoriasSiExistente()
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
                Codigo = "321"
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
                Codigo = "321"
            };
            categoria.agregarTarjeta(tarjeta2);
            usuario.agregarCategoria(categoria2);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Visa Gold",
                Numero = "7894561234567895",
                Codigo = "321"
            };
            Assert.AreEqual(true, usuario.yaExisteTarjeta(tarjetaIgual));
        }


    }
}
