﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestClave
    {
        private Clave clave1;
        private Clave clave2;
        private string menorA5;
        private string mayorA25;
        private NivelSeguridad nivelSeguridad;
        private ColorNivelSeguridad color;
        private DateTime tiempoActual;

        [TestInitialize]
        public void Setup()
        {
            clave1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "UsuarioORT"
            };

            clave2 = new Clave()
            {
                Sitio = "youtube.com",
                UsuarioClave = "UsuarioYoutube"
            };

            menorA5 = "a";

            mayorA25 = "";

            for (int i = 0; i <= 25; i++)
            {
                mayorA25 = mayorA25 + "a";
            }

            nivelSeguridad = new NivelSeguridad();
            color = new ColorNivelSeguridad();

            tiempoActual = System.DateTime.Now.Date;

        }

        [TestMethod]
        public void ClaveGetUsuarioCorrecto()
        {
            clave1.UsuarioClave = "juan@gmail.com";
            Assert.AreEqual("juan@gmail.com", clave1.UsuarioClave);
        }

        [TestMethod]
        public void ClaveGetUsuarioCambiado()
        {
            clave1.UsuarioClave = "pedro@gmail.com";
            Assert.AreEqual("pedro@gmail.com", clave1.UsuarioClave);
        }

        [TestMethod]
        public void ClaveLargoUsuarioMenorA5()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => clave1.UsuarioClave = menorA5);
        }

        [TestMethod]
        public void ClaveLargoUsuarioMayorA25()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => clave1.UsuarioClave = mayorA25);
        }

        [TestMethod]
        public void ClaveGetClaveCorrecta()
        {
            clave1.Codigo = "123456";
            Assert.AreEqual("123456", clave1.Codigo);
        }

        [TestMethod]
        public void ClaveGetClaveCambiada()
        {
            clave1.Codigo = "123456";
            clave1.Codigo = "claveNueva";
            Assert.AreEqual("claveNueva", clave1.Codigo);
        }

        [TestMethod]
        public void ClaveLargoClaveMenorA5()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => clave1.Codigo = menorA5);
        }

        [TestMethod]
        public void ClaveLargoClaveMayorA25()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => clave1.Codigo = mayorA25);
        }

        [TestMethod]
        public void ClaveGetSitioCorrecto()
        {
            clave1.Sitio = "Netflix.com";
            Assert.AreEqual("Netflix.com", clave1.Sitio);
        }

        [TestMethod]
        public void ClaveGetSitioCambiado()
        {
            clave1.Sitio = "Netflix.com";
            clave1.Sitio = "youtube.com";
            Assert.AreEqual("youtube.com", clave1.Sitio);
        }

        [TestMethod]
        public void ClaveLargoSitioMenorA3()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => clave1.Sitio = "a");
        }

        [TestMethod]
        public void ClaveLargoSitioMayorA25()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => clave1.Sitio = mayorA25);
        }

        [TestMethod]
        public void ClaveGetNotaCorrecta()
        {
            clave1.Nota = "Hola";
            Assert.AreEqual("Hola", clave1.Nota);
        }

        [TestMethod]
        public void ClaveGetNotaCambiada()
        {
            clave1.Nota = "Hola";
            clave1.Nota = "notaNueva";
            Assert.AreEqual("notaNueva", clave1.Nota);
        }

        [TestMethod]
        public void ClaveLargoNotaMayorA250()
        {
            string notaMayorA250 = "";
            for (int i = 0; i < 251; i++) notaMayorA250 += "C";
            Assert.ThrowsException<LargoIncorrectoException>(() => clave1.Nota = notaMayorA250);
        }

        [TestMethod]
        public void ClaveNivelSeguridadMenorOchoChars()
        {
            clave1.Codigo = "clave1";
            Assert.AreEqual(color.Rojo, nivelSeguridad.GetNivelSeguridad(clave1.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadEntreOchoYCatorceChars()
        {
            clave1.Codigo = "clave212345";
            Assert.AreEqual(color.Naranja, nivelSeguridad.GetNivelSeguridad(clave1.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceSoloMay()
        {
            clave1.Codigo = "CLAVESOLOMAYUSCULAS";
            Assert.AreEqual(color.Amarillo, nivelSeguridad.GetNivelSeguridad(clave1.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceSoloMin()
        {
            clave1.Codigo = "clavesolominusculas";
            Assert.AreEqual(color.Amarillo, nivelSeguridad.GetNivelSeguridad(clave1.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceConMayYMin()
        {
            clave1.Codigo = "ClaveConMayYMin";
            Assert.AreEqual(color.VerdeClaro, nivelSeguridad.GetNivelSeguridad(clave1.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceConMayMinNumYSim()
        {
            clave1.Codigo = "ClaveConMayYMin14@#";
            Assert.AreEqual(color.VerdeOscuro, nivelSeguridad.GetNivelSeguridad(clave1.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceConMayMinNumYSimEnUltimoChar()
        {
            clave1.Codigo = "claveconmayymiN14@";
            Assert.AreEqual(color.VerdeOscuro, nivelSeguridad.GetNivelSeguridad(clave1.Codigo)
);
        }

        [TestMethod]
        public void ClaveEqualsMismoSitioYUsuario()
        {
            clave2.Sitio = clave1.Sitio;
            clave2.UsuarioClave = clave1.UsuarioClave;
            Assert.AreEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveEqualsDiferenteSitioYMismoUsuario()
        {
            clave2.UsuarioClave = clave1.UsuarioClave;
            Assert.AreNotEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveEqualsMismoSitioYDiferenteUsuario()
        {
            clave2.Sitio = clave1.Sitio;
            Assert.AreNotEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveEqualsConNull()
        {
            clave2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => clave1.Equals(clave2)) ;
        }

        [TestMethod]
        public void ClaveEqualsConString()
        {
            String falsaClave = "falsaClave"; 
            Assert.ThrowsException<ObjetoIncorrectoException>(() => clave1.Equals(falsaClave));
        }

        [TestMethod]
        public void ClaveEqualsConMayYMin()
        {

            clave2.Sitio = clave1.Sitio.ToUpper();
            clave2.UsuarioClave = clave1.UsuarioClave.ToUpper();
            Assert.AreEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveGetFechaModificacionNuevaClave() {
            Assert.AreEqual(tiempoActual, clave1.FechaModificacion);
        }

        [TestMethod]
        public void ClaveGetFechaModificacionClaveVieja()
        {
            clave1.FechaModificacion = new DateTime(2000, 1, 1);
            clave1.Codigo = "ClaveNueva";
            Assert.AreEqual(tiempoActual, clave1.FechaModificacion);
        }


        [TestMethod]
        public void ClaveUsuarioClaveInsensitive() {
            clave2.UsuarioClave = clave1.UsuarioClave.ToUpper();
            clave2.Sitio = clave1.Sitio;
            clave1.UsuarioClave = clave1.UsuarioClave.ToLower();
            Assert.AreEqual(clave1, clave2);
        }
    }

    [TestClass]
    public class TestClaveGenerada
    {
        [TestMethod]
        public void ClaveGeneradaVacia()
        {
            GeneradoraClaves generadora = new GeneradoraClaves() 
            {
                IncluirMayusculas = false,
                IncluirMinusculas = false,
                IncluirNumeros = false,
                IncluirSimbolos = false,
                Largo = 10
            };

            Assert.ThrowsException<ClaveGeneradaVaciaException>(() => generadora.Generar());
        }

        [TestMethod]
        public void ClaveGeneradaSoloMayusculas()
        {
            GeneradoraClaves generadora = new GeneradoraClaves()
            {
                Largo = 5,
                IncluirMayusculas = true,
                IncluirMinusculas = false,
                IncluirNumeros = false,
                IncluirSimbolos = false
            };

            Clave random = new Clave()
            {
                Codigo = generadora.Generar()
            };
            string resultado = random.Codigo;
            bool esSoloMayuscula = resultado.All(caracter => VerificadoraString.EsMayuscula(caracter));
            Assert.IsTrue(esSoloMayuscula);
        }

        [TestMethod]
        public void ClaveGeneradaLargoCorrecto()
        {
            GeneradoraClaves generadora = new GeneradoraClaves()
            {
                Largo = 10,
                IncluirMayusculas = true,
                IncluirMinusculas = false,
                IncluirNumeros = false,
                IncluirSimbolos = false
            };

            Clave random = new Clave() {
                Codigo = generadora.Generar()
            };
            string resultado = random.Codigo;
            Assert.AreEqual(10, resultado.Length);
        }

        [TestMethod]
        public void ClaveGeneradaIncluyendoTodo()
        {
            GeneradoraClaves generadora = new GeneradoraClaves()
            {
                Largo = 10,
                IncluirMayusculas = true,
                IncluirMinusculas = true,
                IncluirNumeros = true,
                IncluirSimbolos = true
            };

            Clave random = new Clave()
            {
                Codigo = generadora.Generar()
            };
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
            GeneradoraClaves generadora = new GeneradoraClaves()
            {
                Largo = 15,
                IncluirMayusculas = false,
                IncluirMinusculas = true,
                IncluirNumeros = false,
                IncluirSimbolos = true
            };

            Clave random = new Clave()
            {
                Codigo = generadora.Generar()
            };
            string resultado = random.Codigo;
            bool contieneMayusculas = resultado.Any(caracter => VerificadoraString.EsMayuscula(caracter));
            bool contieneMinusculas = resultado.Any(caracter => VerificadoraString.EsMinuscula(caracter));
            bool contieneNumeros = resultado.Any(caracter => VerificadoraString.EsNumero(caracter));
            bool contieneSimbolos = resultado.Any(caracter => VerificadoraString.EsSimbolo(caracter));

            Assert.IsTrue(!contieneMayusculas && contieneMinusculas && !contieneNumeros && contieneSimbolos);
        }
    }

}
