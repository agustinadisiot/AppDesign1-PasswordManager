using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;


//Confirmar separacion de tests, y nombre de TestsClases.cs


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
    }
}
