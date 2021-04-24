﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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


        //Prueba de comparar dos Usuarios con mismo Nombre y ContraMaestra da true el equals
        [TestMethod]
        public void testUsuarioEqualsMismoNombreYContra()
        {
            Usuario u1 = new Usuario()
            {
                Nombre = "Usuario12",
                ContraMaestra = "UsuarioORT"
            };
            Usuario u2 = new Usuario()
            {
                Nombre = "Usuario12",
                ContraMaestra = "UsuarioORT"   
            };
            Assert.AreEqual(u1, u2);
        }

        //Prueba de comparar dos Usuarios con diferente Nombre y mismaContraMaestra da flase el equals
        [TestMethod]
        public void testUsuarioEqualsMismoNombreYDiferenteContra()
        {
            Usuario u1 = new Usuario()
            {
                Nombre = "Usuario123",
                ContraMaestra = "UsuarioORT"
            };
            Usuario u2 = new Usuario()
            {
                Nombre = "Usuario789",
                ContraMaestra = "UsuarioORT"
            };
            Assert.AreNotEqual(u1, u2);
        }
    }

}