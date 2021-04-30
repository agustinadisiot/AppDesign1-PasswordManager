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
        [TestMethod]
        public void ContraGetUsuarioCorrecto()
        {
            Contra contra = new Contra()
            {
                UsuarioContra = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", contra.UsuarioContra);
        }

        [TestMethod]
        public void ContraGetUsuarioCambiado()
        {
            Contra contra = new Contra()
            {
                UsuarioContra = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", contra.UsuarioContra);
            contra.UsuarioContra = "pedro@gmail.com";
            Assert.AreEqual("pedro@gmail.com", contra.UsuarioContra);
        }

        [TestMethod]
        public void ContraLargoUsuarioMenorA5()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.UsuarioContra = "A");
        }

        [TestMethod]
        public void ContraLargoUsuarioMayorA25()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.UsuarioContra = "12345678901234567890123456");
        }

        [TestMethod]
        public void ContraGetClaveCorrecta()
        {
            Contra contra = new Contra()
            {
                Clave = "123456"
            };
            Assert.AreEqual("123456", contra.Clave);
        }

        [TestMethod]
        public void ContraGetClaveCambiada()
        {
            Contra contra = new Contra()
            {
                Clave = "123456"
            };
            Assert.AreEqual("123456", contra.Clave);
            contra.Clave = "claveNueva";
            Assert.AreEqual("claveNueva", contra.Clave);
        }

        [TestMethod]
        public void ContraLargoClaveMenorA5()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Clave = "A");
        }

        [TestMethod]
        public void ContraLargoClaveMayorA25()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Clave = "12345678901234567890123456");
        }

        [TestMethod]
        public void ContraGetSitioCorrecto()
        {
            Contra contra = new Contra()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", contra.Sitio);
        }

        [TestMethod]
        public void ContraGetSitioCambiado()
        {
            Contra contra = new Contra()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", contra.Sitio);
            contra.Sitio = "youtube.com";
            Assert.AreEqual("youtube.com", contra.Sitio);
        }

        [TestMethod]
        public void ContraLargoSitioMenorA3()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Sitio = "A");
        }

        [TestMethod]
        public void ContraLargoSitioMayorA25()
        {
            Contra contra = new Contra();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Sitio = "sitioconmasde25caracteres.com");
        }

        [TestMethod]
        public void ContraGetNotaCorrecta()
        {
            Contra contra = new Contra()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", contra.Nota);
        }

        [TestMethod]
        public void ContraGetNotaCambiada()
        {
            Contra contra = new Contra()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", contra.Nota);
            contra.Nota = "notaNueva";
            Assert.AreEqual("notaNueva", contra.Nota);
        }

        [TestMethod]
        public void ContraLargoNotaMayorA250()
        {
            Contra contra = new Contra();
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "C";
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Nota = notaDemasiadoLarga);
        }

        [TestMethod]
        public void ContraNivelSeguridadMenorOchoChars()
        {
            Contra contra = new Contra
            {
                Clave = "clave1"
            };
            Assert.AreEqual("rojo", contra.getNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadEntreOchoYCatorceChars()
        {
            Contra contra = new Contra
            {
                Clave = "clave212345"
            };
            Assert.AreEqual("naranja", contra.getNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceSoloMay()
        {
            Contra contra = new Contra
            {
                Clave = "CLAVESOLOMAYUSCULAS"
            };
            Assert.AreEqual("amarillo", contra.getNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceSoloMin()
        {
            Contra contra = new Contra
            {
                Clave = "clavesolominusculas"
            };
            Assert.AreEqual("amarillo", contra.getNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayYMin()
        {
            Contra contra = new Contra
            {
                Clave = "ClaveConMayYMin"
            };
            Assert.AreEqual("verde claro", contra.getNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayMinNumYSim()
        {
            Contra contra = new Contra
            {
                Clave = "ClaveConMayYMin14@#"
            };
            Assert.AreEqual("verde oscuro", contra.getNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayMinNumYSimEnUltimoChar()
        {
            Contra contra = new Contra
            {
                Clave = "claveconmayymiN14@"
            };
            Assert.AreEqual("verde oscuro", contra.getNivelSeguridad());
        }

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
