using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace TestsObligatorio
{

    [TestClass]
    public class TestAdministrador
    {

        //Prueba si al comenzar el administrador esta vacío.
        [TestMethod]
        public void testEsListaUsuariosVaciaAlPrincipio()
        {
            AdminContras administrador = new AdminContras();
            Assert.AreEqual(true, administrador.esListaUsuariosVacia());
        }

        //Prueba si al agregar un usuario, esListaUsuariosVacia da false
        [TestMethod]
        public void testAdministradorConUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(u1);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
        }

        //Prueba si al agregar un usuario sin nombre, de una exception.
        [TestMethod]
        public void testAdministradorAgregarUsuarioSinNombre()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario();
            Assert.ThrowsException<ObjetoIncompletoException>(() => administrador.agregarUsuario(u1));
        }


        //Prueba si al agregar dos usuarios, esListaUsuariosVacia sigue dando false
        [TestMethod]
        public void testAdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(u1);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
            Usuario u2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(u2);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
        }

        //Prueba si al pedir el usuario, devuelve el mismo.
        [TestMethod]
        public void testAdministradorPedirUsuario()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(u1);
            Assert.AreEqual(u1, administrador.getUsuario("Roberto"));
        }

        //Prueba si al agregar dos usuarios, y pedir el primer usuario agregado por nombre, devuelve el correcto.
        [TestMethod]
        public void testAdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(u1);
            Usuario u2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(u2);
            Assert.AreEqual(u1, administrador.getUsuario("Roberto"));
        }


        //Prueba si al agregar dos usuarios, y pedir el segundo usuario agregado por nombre, devuelve el correcto.
        [TestMethod]
        public void testAdministradorPedirUsuarioSegundoConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(u1);
            Usuario u2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(u2);
            Assert.AreEqual(u2, administrador.getUsuario("Pedro"));
        }


        //Prueba si al agregar dos usuarios, y pedir un usuario con un nombre no agregado, devuelve un error.
        [TestMethod]
        public void testAdministradorPedirUsuarioInexistente()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(u1);
            Usuario u2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(u2);
            Assert.ThrowsException<ObjetoInexistenteException>(() => administrador.getUsuario("Hernesto"));
        }

    }

}
