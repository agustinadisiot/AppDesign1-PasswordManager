using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


//Confirmar separacion de tests, y nombre de TestsClases.cs


namespace TestsObligatorio
{
   
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
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "C";
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


        //Prueba si al ingresar un numero a una tarjeta con largo mayor a 16, devuelve un error.
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


        //Prueba si devuelve el codigo correcto de la tarjeta.
        [TestMethod]
        public void testTarjetaGetCodigoTarjeta()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Codigo = "123"
            };
            Assert.AreEqual("123", t1.Codigo);
        }


        //Prueba si al cambiar el codigo a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void testTarjetaGetCodigoCambio()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Codigo = "123"
            };
            Assert.AreEqual("123", t1.Codigo);
            t1.Codigo = "3241";
            Assert.AreEqual("3241", t1.Codigo);
        }

        //Prueba si al ingresar un codigo a una tarjeta con largo menor a 3, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoCodigoMenorA3()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Codigo = "12");
        }

        //Prueba si al ingresar un codigo a una tarjeta con largo mayor a 4, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoCodigoMayorA4()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Codigo = "12345");
        }


        //Prueba si al ingresar un numero a una tarjeta con letras, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoCodigoConLetras()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => t1.Codigo = "12B");
        }


        //Prueba si al ingresar un numero a una tarjeta con simbolos, devuelve un error.
        [TestMethod]
        public void testTarjetaLargoCodigoConSimbolos()
        {
            Tarjeta t1 = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => t1.Codigo = "12**");
        }


        //Prueba si devuelve la fecha de vencimiento correcto de la tarjeta.
        [TestMethod]
        public void testTarjetaGetVencimientoTarjeta()
        {
            Tarjeta t1 = new Tarjeta();
            DateTime date1 = new DateTime(2025, 7, 1);
            t1.Vencimiento = date1;
            Assert.AreEqual("07/2025", t1.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }


        //Prueba si devuelve la fecha de vencimiento correcto de la tarjeta.
        [TestMethod]
        public void testTarjetaGetVencimientoCambio()
        {
            Tarjeta t1 = new Tarjeta();
            DateTime date1 = new DateTime(2025, 7, 1);
            t1.Vencimiento = date1;
            Assert.AreEqual("07/2025", t1.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
            DateTime date2 = new DateTime(2023, 8, 1);
            t1.Vencimiento = date2;
            Assert.AreEqual("08/2023", t1.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }


        //Prueba si devuelve la nota correcta de la tarjeta.
        [TestMethod]
        public void testTarjetaGetNotaTarjeta()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Nota = "Limite 400k UYU"
            };
            Assert.AreEqual("Limite 400k UYU", t1.Nota);
        }


        //Prueba si al cambiar la nota a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void testTarjetaGetNotaCambio()
        {
            Tarjeta t1 = new Tarjeta()
            {
                Nota = "Limite 400k UYU"
            };
            Assert.AreEqual("Limite 400k UYU", t1.Nota);
            t1.Nota = "Nota nueva";
            Assert.AreEqual("Nota nueva", t1.Nota);
        }

        //Prueba si al ingresar una nota a una tarjeta con largo mayor a 250, devuelve un error.
        [TestMethod]
        public void testContraLargoNotaMayorA250()
        {
            Tarjeta t1 = new Tarjeta();
            string notaDemasiadoLarga="";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "T";
            Assert.ThrowsException<LargoIncorrectoException>(() => t1.Nota = notaDemasiadoLarga);
        }
    }
}
