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
            Clave contra = new Clave()
            {
                UsuarioClave = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", contra.UsuarioClave);
        }

        [TestMethod]
        public void ContraGetUsuarioCambiado()
        {
            Clave contra = new Clave()
            {
                UsuarioClave = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", contra.UsuarioClave);
            contra.UsuarioClave = "pedro@gmail.com";
            Assert.AreEqual("pedro@gmail.com", contra.UsuarioClave);
        }

        [TestMethod]
        public void ContraLargoUsuarioMenorA5()
        {
            Clave contra = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.UsuarioClave = "A");
        }

        [TestMethod]
        public void ContraLargoUsuarioMayorA25()
        {
            Clave contra = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.UsuarioClave = "12345678901234567890123456");
        }

        [TestMethod]
        public void ContraGetClaveCorrecta()
        {
            Clave contra = new Clave()
            {
                Codigo = "123456"
            };
            Assert.AreEqual("123456", contra.Codigo);
        }

        [TestMethod]
        public void ContraGetClaveCambiada()
        {
            Clave contra = new Clave()
            {
                Codigo = "123456"
            };
            Assert.AreEqual("123456", contra.Codigo);
            contra.Codigo = "claveNueva";
            Assert.AreEqual("claveNueva", contra.Codigo);
        }

        [TestMethod]
        public void ContraLargoClaveMenorA5()
        {
            Clave contra = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Codigo = "A");
        }

        [TestMethod]
        public void ContraLargoClaveMayorA25()
        {
            Clave contra = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Codigo = "12345678901234567890123456");
        }

        [TestMethod]
        public void ContraGetSitioCorrecto()
        {
            Clave contra = new Clave()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", contra.Sitio);
        }

        [TestMethod]
        public void ContraGetSitioCambiado()
        {
            Clave contra = new Clave()
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
            Clave contra = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Sitio = "A");
        }

        [TestMethod]
        public void ContraLargoSitioMayorA25()
        {
            Clave contra = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Sitio = "sitioconmasde25caracteres.com");
        }

        [TestMethod]
        public void ContraGetNotaCorrecta()
        {
            Clave contra = new Clave()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", contra.Nota);
        }

        [TestMethod]
        public void ContraGetNotaCambiada()
        {
            Clave contra = new Clave()
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
            Clave contra = new Clave();
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "C";
            Assert.ThrowsException<LargoIncorrectoException>(() => contra.Nota = notaDemasiadoLarga);
        }

        [TestMethod]
        public void ContraNivelSeguridadMenorOchoChars()
        {
            Clave contra = new Clave
            {
                Codigo = "clave1"
            };
            Assert.AreEqual("rojo", contra.GetNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadEntreOchoYCatorceChars()
        {
            Clave contra = new Clave
            {
                Codigo = "clave212345"
            };
            Assert.AreEqual("naranja", contra.GetNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceSoloMay()
        {
            Clave contra = new Clave
            {
                Codigo = "CLAVESOLOMAYUSCULAS"
            };
            Assert.AreEqual("amarillo", contra.GetNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceSoloMin()
        {
            Clave contra = new Clave
            {
                Codigo = "clavesolominusculas"
            };
            Assert.AreEqual("amarillo", contra.GetNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayYMin()
        {
            Clave contra = new Clave
            {
                Codigo = "ClaveConMayYMin"
            };
            Assert.AreEqual("verde claro", contra.GetNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayMinNumYSim()
        {
            Clave contra = new Clave
            {
                Codigo = "ClaveConMayYMin14@#"
            };
            Assert.AreEqual("verde oscuro", contra.GetNivelSeguridad());
        }

        [TestMethod]
        public void ContraNivelSeguridadMayorACatorceConMayMinNumYSimEnUltimoChar()
        {
            Clave contra = new Clave
            {
                Codigo = "claveconmayymiN14@"
            };
            Assert.AreEqual("verde oscuro", contra.GetNivelSeguridad());
        }

        [TestMethod]
        public void ContraEqualsMismoSitioYUsuario()
        {
            Clave contra1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Clave contra2 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Assert.AreEqual(contra1, contra2);
        }

        [TestMethod]
        public void ContraEqualsDiferenteSitioYMismoUsuario()
        {
            Clave contra1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Clave contra2 = new Clave()
            {
                Sitio = "aulas.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Assert.AreNotEqual(contra1, contra2);
        }

        [TestMethod]
        public void ContraEqualsMismoSitioYDiferenteUsuario()
        {
            Clave contra1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario123"
            };
            Clave contra2 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario789" 
            };
            Assert.AreNotEqual(contra1, contra2);
        }

        [TestMethod]
        public void ContraEqualsConNull()
        {
            Clave contra1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario123"
            };
            Clave contra2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => contra1.Equals(contra2)) ;
        }

        [TestMethod]
        public void ContraEqualsConString()
        {
            Clave contra = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario123"
            };
            String falsaContra = "falsaContra"; 
            Assert.ThrowsException<ObjetoIncorrectoException>(() => contra.Equals(falsaContra));
        }

        [TestMethod]
        public void ContraEqualsConMayYMin()
        {
            Clave contra1 = new Clave()
            {
                Sitio = "Ort.Edu.Uy",
                UsuarioClave = "UsuarioORT"
            };
            Clave contra2 = new Clave()
            {
                Sitio = "oRt.eDu.uY",
                UsuarioClave = "UsuarioORT"
            };
            Assert.AreEqual(contra1, contra2);
        }

        [TestMethod]
        public void ContraGetFechaModificacionNuevaContra() {

            Clave evaluar = new Clave();

            DateTime actual = new System.DateTime().Date;
            Assert.AreEqual(actual, evaluar.FechaModificacion);
        }

        [TestMethod]
        public void ContraGetFechaModificacionContraVieja()
        {

            Clave evaluar = new Clave() {
                Codigo = "12345ABCD"
            };
            evaluar.FechaModificacion = new DateTime(2000, 1, 1);

            evaluar.Codigo = "ContraNueva";
            DateTime actual = System.DateTime.Now.Date;
            Assert.AreEqual(actual, evaluar.FechaModificacion);
        }

    }

    [TestClass]
    public class TestClaveGenerada
    {
        [TestMethod]
        public void ClaveGeneradaVacia()
        {
            ClaveAGenerar parametros = new ClaveAGenerar()
            {
                Largo = 10,
                IncluirMayusculas = false,
                IncluirMinusculas = false,
                IncluirNumeros = false,
                IncluirSimbolos = false
            };

            Clave random = new Clave();
            Assert.ThrowsException<ClaveGeneradaVaciaException>(() => random.GenerarClave(parametros));
        }

        [TestMethod]
        public void ClaveGeneradaSoloMayusculas()
        {
            ClaveAGenerar parametros = new ClaveAGenerar()
            {
                Largo = 5,
                IncluirMayusculas = true,
                IncluirMinusculas = false,
                IncluirNumeros = false,
                IncluirSimbolos = false
            };

            Clave random = new Clave();
            random.GenerarClave(parametros);
            string resultado = random.Codigo;
            bool esSoloMayuscula = resultado.All(caracter => VerificadoraString.EsMayuscula(caracter));
            Assert.IsTrue(esSoloMayuscula);
        }

        [TestMethod]
        public void ClaveGeneradaLargoCorrecto()
        {
            ClaveAGenerar parametros = new ClaveAGenerar()
            {
                Largo = 10,
                IncluirMayusculas = true,
                IncluirMinusculas = false,
                IncluirNumeros = false,
                IncluirSimbolos = false
            };

            Clave random = new Clave();
            random.GenerarClave(parametros);
            string resultado = random.Codigo;
            Assert.AreEqual(10, resultado.Length);
        }

        [TestMethod]
        public void ClaveGeneradaIncluyendoTodo()
        {
            ClaveAGenerar parametros = new ClaveAGenerar()
            {
                Largo = 10,
                IncluirMayusculas = true,
                IncluirMinusculas = true,
                IncluirNumeros = true,
                IncluirSimbolos = true
            };

            Clave random = new Clave();
            random.GenerarClave(parametros);
            string resultado = random.Codigo;
            bool contieneMayusculas = resultado.Any(caracter => VerificadoraString.EsMayuscula(caracter));
            bool contieneMinusculas = resultado.Any(caracter => VerificadoraString.EsMinuscula(caracter));
            bool contieneNumeros = resultado.Any(caracter => VerificadoraString.EsNumero(caracter));
            bool contieneSimbolos = resultado.Any(caracter => VerificadoraString.EsSimbolo(caracter));

            Assert.IsTrue(contieneMayusculas && contieneMinusculas && contieneNumeros && contieneSimbolos);
        }

        [TestMethod]
        public void ClaveGeneradaIncluyendoSimbolosMinusculas()
        {
            ClaveAGenerar parametros = new ClaveAGenerar()
            {
                Largo = 15,
                IncluirMayusculas = false,
                IncluirMinusculas = true,
                IncluirNumeros = false,
                IncluirSimbolos = true
            };

            Clave random = new Clave();
            random.GenerarClave(parametros);
            string resultado = random.Codigo;
            bool contieneMayusculas = resultado.Any(caracter => VerificadoraString.EsMayuscula(caracter));
            bool contieneMinusculas = resultado.Any(caracter => VerificadoraString.EsMinuscula(caracter));
            bool contieneNumeros = resultado.Any(caracter => VerificadoraString.EsNumero(caracter));
            bool contieneSimbolos = resultado.Any(caracter => VerificadoraString.EsSimbolo(caracter));

            Assert.IsTrue(!contieneMayusculas && contieneMinusculas && !contieneNumeros && contieneSimbolos);
        }
    }

}
