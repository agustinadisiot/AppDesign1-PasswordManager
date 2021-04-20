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
        public void testCategoriaEsListaUsuariosContrasVaciaConDosContras()
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

    [TestClass]
    public class TestContra
    {
        //Prueba si devuelve el usuario correcto de la contraseña.
        [TestMethod]
        public void testContraGetUsuarioDeJuan()
        {
            Contra c1 = new Contra()
            {
                UsuarioContra = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", c1.UsuarioContra);
        }


        //Prueba si al cambiar el usuario a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void testContraGetUsuarioCambio()
        {
            Contra c1 = new Contra()
            {
                UsuarioContra = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", c1.UsuarioContra);
            c1.UsuarioContra = "pedro@gmail.com";
            Assert.AreEqual("pedro@gmail.com", c1.UsuarioContra);
        }


        //Prueba si al ingresar un usuario a una contraseña con largo menor a 5, devuelve un error.
        [TestMethod]
        public void testContraLargoUsuarioMenorA5()
        {
            Contra c1 = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.UsuarioContra = "A");
        }


        //Prueba si al ingresar un usuario a una contraseña con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void testContraLargoUsuarioMayorA25()
        {
            Contra c1 = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.UsuarioContra = "12345678901234567890123456");
        }


        //Prueba si devuelve la clave correcta de la contraseña.
        [TestMethod]
        public void testContraGetClave123456()
        {
            Contra c1 = new Contra()
            {
                Clave = "123456"
            };
            Assert.AreEqual("123456", c1.Clave);
        }


        //Prueba si al cambiar la clave a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void testContraGetClaveCambio()
        {
            Contra c1 = new Contra()
            {
                Clave = "123456"
            };
            Assert.AreEqual("123456", c1.Clave);
            c1.Clave = "claveNueva";
            Assert.AreEqual("claveNueva", c1.Clave);
        }


        //Prueba si al ingresar una clave a una contraseña con largo menor a 5, devuelve un error.
        [TestMethod]
        public void testContraLargoClaveMenorA5()
        {
            Contra c1 = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.Clave = "A");
        }


        //Prueba si al ingresar una clave a una contraseña con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void testContraLargoClaveMayorA25()
        {
            Contra c1 = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.Clave = "12345678901234567890123456");
        }

        //Prueba si devuelve el sitio correcto de la contraseña.
        [TestMethod]
        public void testContraGetSitioNetflix()
        {
            Contra c1 = new Contra()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", c1.Sitio);
        }


        //Prueba si al cambiar el sitio a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void testContraGetSitioCambio()
        {
            Contra c1 = new Contra()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", c1.Sitio);
            c1.Sitio = "youtube.com";
            Assert.AreEqual("youtube.com", c1.Sitio);
        }


        //Prueba si al ingresar un sitio a una contraseña con largo menor a 3, devuelve un error.
        [TestMethod]
        public void testContraLargoSitioMenorA3()
        {
            Contra c1 = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.Sitio = "A");
        }


        //Prueba si al ingresar un sitio a una contraseña con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void testContraLargoSitioMayorA25()
        {
            Contra c1 = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.Sitio = "sitioconmasde25caracteres.com");
        }

        //Prueba si devuelve la nota correcta de la contraseña.
        [TestMethod]
        public void testContraGetNotaHola()
        {
            Contra c1 = new Contra()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", c1.Nota);
        }


        //Prueba si al cambiar la nota a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void testContraGetNotaCambio()
        {
            Contra c1 = new Contra()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", c1.Nota);
            c1.Nota = "notaNueva";
            Assert.AreEqual("notaNueva", c1.Nota);
        }

        //Prueba si al ingresar una nota a una contraseña con largo mayor a 250, devuelve un error.
        [TestMethod]
        public void testContraLargoNotaMayorA250()
        {
            Contra c1 = new Contra();
            string notaDemasiadoLarga = "esta es una nota con mas de 250 caracteres lo cual no deberia estar permitido, se podria hacer un string en otro lado y luego exportarlo para que visualmente no quede tan feo pero es literalmente lo mismo y no varia mas que en vez de tener esta linea larguisima aca la tendrias en otro archivo lo cual pienso yo que no necesario. -Santiago Diaz";
            Assert.ThrowsException<LargoIncorrectoException>(() => c1.Nota = notaDemasiadoLarga);
        }

        //Prueba de nivel de seguridad para una Contra color rojo (menor a 8 caracteres)
        [TestMethod]
        public void testContraNivelSeguridadMenorOchoChars()
        {
            Contra c1 = new Contra();
            c1.Clave = "clave1";
            Assert.AreEqual("rojo", c1.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color naranja (largo entre 8 y 14)
        [TestMethod]
        public void testContraNivelSeguridadEntreOchoYCatorceChars()
        {
            Contra c1 = new Contra();
            c1.Clave = "clave212345";
            Assert.AreEqual("naranja", c1.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color amarillo (mayor a 14 solo mayusculas)
        [TestMethod]
        public void testContraNivelSeguridadMayorACatorceSoloMay()
        {
            Contra c1 = new Contra();
            c1.Clave = "CLAVESOLOMAYUSCULAS";
            Assert.AreEqual("amarillo", c1.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color amarillo (mayor a 14 solo minusculas)
        [TestMethod]
        public void testContraNivelSeguridadMayorACatorceSoloMin()
        {
            Contra c1 = new Contra();
            c1.Clave = "clavesolominusculas";
            Assert.AreEqual("amarillo", c1.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color verde claro (mayor a 14 con mayusculas y minusculas)
        [TestMethod]
        public void testContraNivelSeguridadMayorACatorceConMayYMin()
        {
            Contra c1 = new Contra();
            c1.Clave = "ClaveConMayYMin";
            Assert.AreEqual("verde claro", c1.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color verde oscuro (mayor a 14 con mayusculas, minusculas, numeros y simbolos)
        [TestMethod]
        public void testContraNivelSeguridadMayorACatorceConMayYSim()
        {
            Contra c1 = new Contra();
            c1.Clave = "ClaveConMayYMin14@#";
            Assert.AreEqual("verde oscuro", c1.getNivelSeguridad());
        }
    }

    [TestClass]
    public class TestTarjeta
    {
        //Prueba si devuelve el nombre correcto de la tarjeta.
        [TestMethod]
        public void testTarjetaGetNombreVisaGold()
        {
            Tarjeta t1 = new Tarjeta() 
            {
                Nombre = "Visa Gold"
            };
            Assert.AreEqual("Visa Gold", t1.Nombre);
        }


        //Prueba si al cambiar el nombre a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void testTarjetaGetNombreCambio()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Nombre = "Visa Gold"
            };
            Assert.AreEqual("Visa Gold", t1.Nombre);
            t1.Nombre = "American";
            Assert.AreEqual("American", t1.Nombre);
        }


        //Prueba si al ingresar un nombre a una tarjeta con largo menor a 3, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoNombreMenorA3()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Nombre = "A");
        }


        //Prueba si al ingresar un nombre a una tarjeta con largo meyor a 25, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoNombreMayorA25()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Nombre = "NombreDeTarjetaDemasiadoLargo");
        }


        //Prueba si devuelve el tipo correcto de la tarjeta.
        [TestMethod]
        public void testTarjetaGetTipoVisa()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Tipo = "Visa"
            };
            Assert.AreEqual("Visa", t1.Tipo);
        }


        //Prueba si al cambiar el tipo a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void testTarjetaGetTipoCambio()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Tipo = "Visa"
            };
            Assert.AreEqual("Visa", t1.Tipo);
            t1.Tipo = "MasterCard";
            Assert.AreEqual("MasterCard", t1.Tipo);
        }


        //Prueba si al ingresar un tipo a una tarjeta con largo menor a 3, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoTipoMenorA3()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Tipo = "A");
        }


        //Prueba si al ingresar un tipo a una tarjeta con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoTipoMayorA25()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Tipo = "TipoDemasiadoLargoNoPermitido");
        }


        //Prueba si devuelve el numero correcto de la tarjeta.
        [TestMethod]
        public void testTarjetaGetNumeroTarjeta()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Numero = "1234567812345678"
            };
            Assert.AreEqual("1234567812345678", t1.Numero);
        }



        //Prueba si al cambiar el numero a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void testTarjetaGetNumeroCambio()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Numero = "1234567812345678"
            };
            Assert.AreEqual("1234567812345678", t1.Numero);
            t1.Numero = "8765432187654321";
            Assert.AreEqual("8765432187654321", t1.Numero);
        }


        //Prueba si al ingresar un numero a una tarjeta con largo menor a 16, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoNumeroMenorA16()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Numero = "1215412");
        }


        //Prueba si al ingresar un numero a una tarjeta con largo menor a 16, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoNumeroMayorA16()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Numero = "123456781223456781234");
        }


        //Prueba si al ingresar un numero a una tarjeta con letras, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoNumeroConLetras()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => t1.Numero = "12345BCdA2345678");
        }


        //Prueba si al ingresar un numero a una tarjeta con simbolos, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoNumeroConSimbolos()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => t1.Numero = "12345#$%@2345678");
        }
    }
}
