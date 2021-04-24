using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        //Prueba de comparar dos Contras con mismo Sitio y Usuario da true el equals
        [TestMethod]
        public void testContraEqualsMismoSitioYUsuario()
        {
            Contra c1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Contra c2 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Assert.AreEqual(c1, c2);
        }

        //Prueba de comparar dos Contras con diferente Sitio y mismo Usuario da false el equals
        [TestMethod]
        public void testContraEqualsDiferenteSitioYMismoUsuario()
        {
            Contra c1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Contra c2 = new Contra()
            {
                Sitio = "aulas.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Assert.AreNotEqual(c1, c2);
        }

        //Prueba de comparar dos Contras con mismo Sitio y diferente Usuario da false el equals
        [TestMethod]
        public void testContraEqualsMismoSitioYDiferenteUsuario()
        {
            Contra c1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario123"
            };
            Contra c2 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario789" 
            };
            Assert.AreNotEqual(c1, c2);
        }

        //Prueba de comparar dos Contras donde una es null
        [TestMethod]
        public void testContraEqualsConNull()
        {
            Contra c1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario123"
            };
            Contra c2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => c1.Equals(c2)) ;
        }

        //Prueba de comparar dos Contras
        [TestMethod]
        public void testContraEqualsConString()
        {
            Contra c1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario123"
            };
            String falsaContra = "falsaContra"; 
            Assert.ThrowsException<ObjetoIncorrectoException>(() => c1.Equals(falsaContra));
        }
    }

}
