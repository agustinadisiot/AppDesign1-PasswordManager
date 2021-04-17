using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;

namespace TestsObligatorio
{
    [TestClass]
    public class TestAdministrador
    {

        //Prueba si al comenzar el administrador esta vacío.
        [TestMethod]
        public void testNoHayUsuario()
        {
            AdminContras administrador = new AdminContras();
            Assert.AreEqual(true, administrador.noHayUsuarios());
        }

        //Prueba si al agregar un usuario, noHayUsuarios da false
        [TestMethod]
        public void testAdministradorConUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario();
            administrador.agregarUsuario(u1);
            Assert.AreEqual(false, administrador.noHayUsuarios());
        }


        //Prueba si al agregar dos usuarios, noHayUsuarios sigue dando false
        [TestMethod]
        public void testAdministradorHayUsuariosCon2Usuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario();
            administrador.agregarUsuario(u1);
            Assert.AreEqual(false, administrador.noHayUsuarios());
            Usuario u2 = new Usuario();
            administrador.agregarUsuario(u2);
            Assert.AreEqual(false, administrador.noHayUsuarios());
        }

        //Prueba si al pedir el usuario, devuelve el mismo.
        [TestMethod]
        public void testAdministradorPedirUsuario() {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario();
            administrador.agregarUsuario(u1);
            Assert.AreEqual(u1, administrador.getUsuario());
        }


    }
}
