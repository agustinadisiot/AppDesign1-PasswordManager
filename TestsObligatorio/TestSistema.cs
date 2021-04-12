using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;

namespace TestsObligatorio
{
    [TestClass]
    public class TestSistema
    {
        [TestMethod]
        public void testNoHayUsuario()
        {
            Sistema sistema = new Sistema();
            //Prueba si al comenzar el sistema esta vacío.
            Assert.AreEqual(true, sistema.noHayUsuarios());
        }

        [TestMethod]
        public void testSistemaConUsuarios()
        {
            Sistema sistema = new Sistema();
            Sistema
            //Prueba si al comenzar el sistema esta vacío.
            Assert.AreEqual(true, sistema.noHayUsuarios());
        }

    }
}
