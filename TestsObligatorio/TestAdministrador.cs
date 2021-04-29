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

        //Prueba si al comenzar el administrador la lista de usuarios esta vacía.
        [TestMethod]
        public void EsListaUsuariosVaciaAlPrincipio()
        {
            AdminContras administrador = new AdminContras();
            Assert.AreEqual(true, administrador.esListaUsuariosVacia());
        }

        //Prueba si al agregar un usuario, esListaUsuariosVacia da false
        [TestMethod]
        public void AdministradorConUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
        }

        //Prueba si al agregar un usuario sin nombre, de una exception.
        [TestMethod]
        public void AdministradorAgregarUsuarioSinNombre()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario();
            Assert.ThrowsException<ObjetoIncompletoException>(() => administrador.agregarUsuario(usuario));
        }


        //Prueba si al agregar dos usuarios, esListaUsuariosVacia sigue dando false
        [TestMethod]
        public void AdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
        }

        //Prueba si al pedir el usuario, devuelve el mismo.
        [TestMethod]
        public void AdministradorPedirUsuario()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Assert.AreEqual(usuario, administrador.getUsuario("Roberto"));
        }

        //Prueba si al agregar dos usuarios, y pedir el primer usuario agregado, por nombre, devuelve el correcto.
        [TestMethod]
        public void AdministradorPedirUsuarioPrimeroConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.AreEqual(usuario, administrador.getUsuario("Roberto"));
        }


        //Prueba si al agregar dos usuarios, y pedir el segundo usuario agregado por nombre, devuelve el correcto.
        [TestMethod]
        public void AdministradorPedirUsuarioSegundoConDosAgregados()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.AreEqual(usuario2, administrador.getUsuario("Pedro"));
        }


        //Prueba si al agregar dos usuarios, y pedir un usuario con un nombre no agregado, devuelve un error.
        [TestMethod]
        public void AdministradorPedirUsuarioInexistente()
        {
            AdminContras administrador = new AdminContras();
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            administrador.agregarUsuario(usuario);
            Usuario usuario2 = new Usuario
            {
                Nombre = "Pedro"
            };
            administrador.agregarUsuario(usuario2);
            Assert.ThrowsException<ObjetoInexistenteException>(() => administrador.getUsuario("Hernesto"));
        }

    }

}
