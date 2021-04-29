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
        public void ContraGetUsuarioDeJuan()
        {
            Contra contra = new Contra()
            {
                UsuarioContra = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", contra.UsuarioContra);
        }

        //Prueba si al cambiar el usuario a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void ContraGetUsuarioCambio()
        {
            Contra contra = new Contra()
            {
                UsuarioContra = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", contra.UsuarioContra);
            contra.UsuarioContra = "pedro@gmail.com";
            Assert.AreEqual("pedro@gmail.com", contra.UsuarioContra);
        }

        //Prueba si al ingresar un usuario a una contraseña con largo menor a 5, devuelve un error.
        [TestMethod]
        public void ContraLargoUsuarioMenorA5()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.UsuarioContra = "A");
        }

        //Prueba si al ingresar un usuario a una contraseña con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void ContraLargoUsuarioMayorA25()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.UsuarioContra = "12345678901234567890123456");
        }

        //Prueba si devuelve la clave correcta de la contraseña.
        [TestMethod]
        public void ContraGetClave123456()
        {
            Contra contra = new Contra()
            {
                Clave = "123456"
            };
            Assert.AreEqual("123456", contra.Clave);
        }

        //Prueba si al cambiar la clave a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void ContraGetClaveCambio()
        {
            Contra contra = new Contra()
            {
                Clave = "123456"
            };
            Assert.AreEqual("123456", contra.Clave);
            contra.Clave = "claveNueva";
            Assert.AreEqual("claveNueva", contra.Clave);
        }

        //Prueba si al ingresar una clave a una contraseña con largo menor a 5, devuelve un error.
        [TestMethod]
        public void ContraLargoClaveMenorA5()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Clave = "A");
        }

        //Prueba si al ingresar una clave a una contraseña con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void ContraLargoClaveMayorA25()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Clave = "12345678901234567890123456");
        }

        //Prueba si devuelve el sitio correcto de la contraseña.
        [TestMethod]
        public void ContraGetSitioNetflix()
        {
            Contra contra = new Contra()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", contra.Sitio);
        }

        //Prueba si al cambiar el sitio a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void ContraGetSitioCambio()
        {
            Contra contra = new Contra()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", contra.Sitio);
            contra.Sitio = "youtube.com";
            Assert.AreEqual("youtube.com", contra.Sitio);
        }

        //Prueba si al ingresar un sitio a una contraseña con largo menor a 3, devuelve un error.
        [TestMethod]
        public void ContraLargoSitioMenorA3()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Sitio = "A");
        }

        //Prueba si al ingresar un sitio a una contraseña con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void ContraLargoSitioMayorA25()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Sitio = "sitioconmasde25caracteres.com");
        }

        //Prueba si devuelve la nota correcta de la contraseña.
        [TestMethod]
        public void ContraGetNotaHola()
        {
            Contra contra = new Contra()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", contra.Nota);
        }

        //Prueba si al cambiar la nota a la contraseña, cambia lo que devuelve.
        [TestMethod]
        public void ContraGetNotaCambio()
        {
            Contra contra = new Contra()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", contra.Nota);
            contra.Nota = "notaNueva";
            Assert.AreEqual("notaNueva", contra.Nota);
        }

        //Prueba si al ingresar una nota a una contraseña con largo mayor a 250, devuelve un error.
        [TestMethod]
        public void ContraLargoNotaMayorA250()
        {
            Contra contra = new Contra();
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "C";
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Nota = notaDemasiadoLarga);
        }

        //Prueba de nivel de seguridad para una Contra color rojo (menor a 8 caracteres).
        [TestMethod]
        public void ContraNivelSeguridadMenorOchoChars()
        {
            Contra contra = new Contra
            {
                Clave = "clave1"
            };
            Assert.AreEqual("rojo", contra.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color naranja (largo entre 8 y 14).
        [TestMethod]
        public void ContraNivelSeguridadEntreOchoYCatorceChars()
        {
            Contra contra = new Contra
            {
                Clave = "clave212345"
            };
            Assert.AreEqual("naranja", contra.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color amarillo (mayor a 14 solo mayusculas).
        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceSoloMay()
        {
            Contra contra = new Contra
            {
                Clave = "CLAVESOLOMAYUSCULAS"
            };
            Assert.AreEqual("amarillo", contra.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color amarillo (mayor a 14 solo minusculas).
        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceSoloMin()
        {
            Contra contra = new Contra
            {
                Clave = "clavesolominusculas"
            };
            Assert.AreEqual("amarillo", contra.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color verde claro (mayor a 14 con mayusculas y minusculas).
        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayYMin()
        {
            Contra contra = new Contra
            {
                Clave = "ClaveConMayYMin"
            };
            Assert.AreEqual("verde claro", contra.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color verde oscuro (mayor a 14 con mayusculas, minusculas, numeros y simbolos).
        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayMinNumYSim()
        {
            Contra contra = new Contra
            {
                Clave = "ClaveConMayYMin14@#"
            };
            Assert.AreEqual("verde oscuro", contra.getNivelSeguridad());
        }

        //Prueba de nivel de seguridad para una Contra color verde oscuro en su ultimo caracter. (mayor a 14 con mayusculas, minusculas, numeros y simbolos).
        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayMinNumYSimEnUltimoChar()
        {
            Contra contra = new Contra
            {
                Clave = "claveconmayymiN14@"
            };
            Assert.AreEqual("verde oscuro", contra.getNivelSeguridad());
        }

        //Prueba de comparar dos Contras con mismo Sitio y Usuario da true el equals.
        [TestMethod]
        public void ContraEqualsMismoSitioYUsuario()
        {
            Contra contra1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Contra contra2 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Assert.AreEqual(contra1, contra2);
        }

        //Prueba de comparar dos Contras con diferente Sitio y mismo Usuario da false el equals.
        [TestMethod]
        public void ContraEqualsDiferenteSitioYMismoUsuario()
        {
            Contra contra1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Contra contra2 = new Contra()
            {
                Sitio = "aulas.edu.uy",
                UsuarioContra = "UsuarioORT"
            };
            Assert.AreNotEqual(contra1, contra2);
        }

        //Prueba de comparar dos Contras con mismo Sitio y diferente Usuario da false el equals.
        [TestMethod]
        public void ContraEqualsMismoSitioYDiferenteUsuario()
        {
            Contra contra1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario123"
            };
            Contra contra2 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario789" 
            };
            Assert.AreNotEqual(contra1, contra2);
        }

        //Prueba de comparar dos Contras donde una es null.
        [TestMethod]
        public void ContraEqualsConNull()
        {
            Contra contra1 = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario123"
            };
            Contra contra2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => contra1.Equals(contra2)) ;
        }

        //Prueba de comparar dos Contras donde una es de tipo incorrecto.
        [TestMethod]
        public void ContraEqualsConString()
        {
            Contra contra = new Contra()
            {
                Sitio = "ort.edu.uy",
                UsuarioContra = "Usuario123"
            };
            String falsaContra = "falsaContra"; 
            Assert.ThrowsException<ObjetoIncorrectoException>(() => contra.Equals(falsaContra));
        }

        //Prueba de comparar dos Contras con mismo Sitio y Usuario con mayusculas y minusculas .
        [TestMethod]
        public void ContraEqualsConMayYMin()
        {
            Contra contra1 = new Contra()
            {
                Sitio = "Ort.Edu.Uy",
                UsuarioContra = "UsuarioORT"
            };
            Contra contra2 = new Contra()
            {
                Sitio = "oRt.eDu.uY",
                UsuarioContra = "UsuarioORT"
            };
            Assert.AreEqual(contra1, contra2);
        }
    }

}
