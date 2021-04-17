using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;

namespace TestsObligatorio
{
    [TestClass]
    public class TestAdministrador
    {
        [TestMethod]
        public void testNoHayUsuario()
        {
            AdminContras administrador = new AdminContras();
            //Prueba si al comenzar el administrador esta vacío.
            Assert.AreEqual(true, administrador.noHayUsuarios());
        }

        [TestMethod]
        public void testAdministradorConUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario();
            administrador.agregarUsuario(u1);
            //Prueba si al comenzar el administrador esta vacío.
            Assert.AreEqual(false, administrador.noHayUsuarios());
        }

    }
}
