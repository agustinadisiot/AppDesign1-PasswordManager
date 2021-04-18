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
            Usuario u1 = new Usuario();
            administrador.agregarUsuario(u1);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
        }


        //Prueba si al agregar dos usuarios, esListaUsuariosVacia sigue dando false
        [TestMethod]
        public void testAdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            AdminContras administrador = new AdminContras();
            Usuario u1 = new Usuario();
            administrador.agregarUsuario(u1);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
            Usuario u2 = new Usuario();
            administrador.agregarUsuario(u2);
            Assert.AreEqual(false, administrador.esListaUsuariosVacia());
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
            Categoria c1 = new Categoria();
            u1.agregarCategoria(c1);
            Assert.AreEqual(false, u1.esListaCategoriasVacia());
        }

        //Prueba si al agregar dos categorias, esListaCategoriasVacia sigue dando false
        [TestMethod]
        public void testUsuarioEsListaCategoriasVaciaConDosCategorias()
        {
            Usuario u1 = new Usuario();
            Categoria c1 = new Categoria();
            u1.agregarCategoria(c1);
            Assert.AreEqual(false, u1.esListaCategoriasVacia());
            Categoria c2 = new Categoria();
            u1.agregarCategoria(c2);
            Assert.AreEqual(false, u1.esListaCategoriasVacia());
        }

    }

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
            Contra contra1 = new Contra();
            c1.agregarContra(contra1);
            Assert.AreEqual(false, c1.esListaContrasVacia());
        }


        //Prueba si al agregar dos contraseñas a una categoria, esListaContrasVacia sigue dando false
        [TestMethod]
        public void testAdministradorEsListaUsuariosVaciaConDosUsuarios()
        {
            Categoria c1 = new Categoria();
            Contra contra1 = new Contra();
            c1.agregarContra(contra1);
            Assert.AreEqual(false, c1.esListaContrasVacia());
            Usuario u2 = new Usuario();
            Contra contra2 = new Contra();
            c1.agregarContra(contra2);
            Assert.AreEqual(false, c1.esListaContrasVacia());
        }

    }


}
