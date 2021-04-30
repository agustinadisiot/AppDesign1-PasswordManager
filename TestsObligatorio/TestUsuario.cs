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

        //Prueba si al pedir el nombre a un usuario devuelve el nombre correcto.
        [TestMethod]
        public void UsuarioGetNombreRoberto()
        {
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", usuario.Nombre);
        }

        //Prueba si al cambiar el nombre, cambia lo que devuelve.
        [TestMethod]
        public void UsuarioGetNombreCambio()
        {
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", usuario.Nombre);
            usuario.Nombre = "Hernesto";
            Assert.AreEqual("Hernesto", usuario.Nombre);
        }

        //Prueba si al ingresar un nombre con largo menor a 5, devuelve un error.
        [TestMethod]
        public void UsuarioLargoNombreMenorA5()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "A");
        }

        //Prueba si al ingresar un nombre con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void UsuarioLargoNombreMayorA25()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "12345678901234567890123456");
        }

        //Prueba de darle una constraseña maestra y luego valida con true si el usuario tiene la misma.
        [TestMethod]
        public void UsuarioValidarContraMaestra()
        {
            Usuario usuario = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(true, usuario.validarIgualContraMaestra("Hola12345"));
        }

        //Prueba de darle una constraseña maestra y luego validar que una distinta de false.
        [TestMethod]
        public void UsuarioValidarContraMaestraDiferente()
        {
            Usuario u1 = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(false, u1.validarIgualContraMaestra("Diferente"));
        }

        //Prueba de validar una contraseña maestra, validarla, luego cambiarla y validarla de nuevo con la vieja y nueva contraseña. 
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

        //Prueba si al ingresar una contraMaestra con largo menor a 5, devuelve un error.
        [TestMethod]
        public void UsuarioLargoContraMaestraMenorA5()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ContraMaestra = "A");
        }

        //Prueba si al ingresar una contraMaestra con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void UsuarioLargoContraMaestraMayorA25()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ContraMaestra = "12345678901234567890123456");
        }

        //Prueba si al comenzar el Usuario tiene una lista vacía de categorias guardadas. 
        [TestMethod]
        public void UsuarioEsListaCategoriasVacia()
        {
            Usuario usuario = new Usuario();
            Assert.AreEqual(true, usuario.esListaCategoriasVacia());
        }

        //Prueba si al agregar una categoria, esListaCategoriasVacia da false.
        [TestMethod]
        public void UsuarioEsListaConCategorias()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Assert.AreEqual(false, usuario.esListaCategoriasVacia());
        }

        //Prueba si al agregar dos categorias, esListaCategoriasVacia sigue dando false.
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

        //Prueba si al ingresar una categoria vacia tire una excepcion.
        [TestMethod]
        public void UsuarioAgregarCategoriaVacia()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria();
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.agregarCategoria(categoria));
        }

        //Prueba si al agregar una categoria y despues pedirla devuelve la misma.
        [TestMethod]
        public void UsuarioGetCategoria()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.agregarCategoria(categoria);
            Assert.AreEqual(categoria, usuario.getCategoria("Personal"));
        }

        //Prueba si al agregar dos categorias y despues pedirle la primera devuelve la misma.
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

        //Prueba si al agregar dos categorias y despues pedirle la segunda devuelve la correcta.
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

        //Prueba si al agregar una categoria y despues intenta agregar otra categoria con el mismo nombre tira una excepcion.
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

        //Prueba si al agregar una categoria y despues pregunta si ya existe, devuelve true.
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

        //Prueba si al agregar una categoria y despues pregunta si ya existe, devuelve true.
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

        //Prueba de comparar dos Usuarios con mismo Nombre  da true el equals.
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

        //Prueba de comparar dos Usuarios con diferente Nombre da flase el equals.
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

        //Prueba de comparar dos Usuarios donde uno es null
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

        //Prueba de comparar dos Usuarios donde uno es de tipo incorrecto
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

        //Prueba si al agregar una categoria y luego modificar el nombre, efectivamente lo modifique.
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

        //Prueba si al agregar una categoria y luego intentar modificar el nombre de otra categoria, que tire una excepcion.
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

        //Prueba si al agregar una categoria y luego intentar modificar el nombre de otra categoria, que tire una excepcion.
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

        //Prueba que agrega una Contra y despues pregunta si ya existe, devuelve true.
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

        //Prueba que agrega una Contra y despues pregunta si ya existe una con diferente sitio, devuelve false.
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

        //Prueba que agrega una Contra y despues pregunta si ya existe una con mismo sitio y diferente usuario, devuelve false.
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

        //Prueba que agrega una Contra y despues pregunta si ya existe una con mismo sitio y usuario, devuelve true a pesar de tener diferentes claves.
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

        //Prueba que agrega una Contra en una categoria y despues pregunta si ya existe en el usuario en otra categoria, devuelve true.
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

        //Prueba si al agregar una contraseña a una categoria en usuario, yaExisteContra da true
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

        //Prueba si al ingresar una Contra a la categoria en usuario sin sitio o aplicacion, devuelve un error.
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

        //Prueba si al ingresar una Contra a la categoria en un usuario sin clave, devuelve un error.
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

        //Prueba si al ingresar una Contra a la categoria en usuario sin UsuarioContra, devuelve un error.
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

        //Prueba si al ingresar una Contra repetida a una categoria en el usuario, devuelve un error 
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

        //Prueba si al ingresar una Contra a una categoria en el usuario, confirma que esa categoria tiene una contra. 
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

        //Prueba de borrar una Contra a un usuario sin categoria, y deberia tirar una excepcion.
        [TestMethod]
        public void UsuarioBorrarContraSinCategorias()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.borrarContra(paginaContra, usuarioContra));
        }

        //Prueba de borrar una Contra a un usuario sin contras, y deberia tirar una excepcion.
        [TestMethod]
        public void UsuarioBorrarContraSinContras()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.agregarCategoria(categoria);

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.borrarContra(paginaContra, usuarioContra));
        }

        [TestMethod]
        public void UsuarioYaExisteContraBorrada()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.agregarCategoria(categoria);

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";

            Contra contraABorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
                Sitio = paginaContra,
                Clave = "12345AbC$"
            };

            usuario.agregarContra(contraABorrar, "Categoria1");
            usuario.borrarContra(paginaContra, usuarioContra);
            Assert.IsFalse(usuario.yaExisteContra(contraABorrar));
        }

        [TestMethod]
        public void UsuarioBorrarContraYYaExisteContraRestante()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.agregarCategoria(categoria);

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";

            Contra contraABorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
                Sitio = paginaContra,
                Clave = "12345AbC$"
            };


            Contra contraADejar = new Contra()
            {
                UsuarioContra = "OtraContra",
                Sitio = "sitioContraADejar.com",
                Clave = "12345AbC$"
            };

            usuario.agregarContra(contraABorrar, "Categoria1");
            usuario.agregarContra(contraADejar, "Categoria1");
            usuario.borrarContra(paginaContra, usuarioContra);
            Assert.IsTrue(usuario.yaExisteContra(contraADejar));
        }
    }
   
    [TestClass]
    public class TestUsuarioTarjeta
    {
        //Prueba que agrega una Tarjeta a una categoria en el usurio y despues pregunta si ya existe, devuelve true.
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

        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente numero e igual nombre, vencimiento, tipo y codigo, devuelve false.
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

        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente nombre e igual numero, vencimiento, tipo y codigo, devuelve true.
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

        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente tipo e igual nombre, vencimiento, numero y codigo, devuelve true.
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

        //Prueba que agrega una Tarjeta a una categoria en el usuario y despues pregunta si ya existe una con diferente codigo e igual nombre, vencimiento, numero y tipo, devuelve true.
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

        //Prueba que agrega una Tarjeta y despues pregunta si ya existe una con diferente vencimiento e igual nombre, numero, codigo y tipo, devuelve true.
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

        //Prueba que agrega una Tarjeta en una categoria y despues pregunta si ya existe en el usuario en otra categoria, devuelve true.
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

        //Prueba si al agregar una Tarjeta a una categoria en usuario, yaExisteContra da true.
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

        //Prueba si al agregar una Tarjeta sin nombre a una categoria en usuario, devuelve un error.
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

        //Prueba si al agregar una Tarjeta sin tipo a una categoria en usuario, devuelve un error.
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

        //Prueba si al agregar una Tarjeta sin numero a una categoria en usuario, devuelve un error.
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

        //Prueba si al agregar una Tarjeta sin codigo a una categoria en usuario, devuelve un error.
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

        //Prueba si al agregar una Tarjeta repetida a una categoria en usuario, devuelve un error.
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

        //Prueba si al ingresar una tarjeta a una categoria en el usuario, confirma que esa categoria tiene una tarjeta.
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
