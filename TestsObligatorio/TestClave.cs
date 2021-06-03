using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestClave
    {
        [TestMethod]
        public void ClaveGetUsuarioCorrecto()
        {
            Clave clave = new Clave()
            {
                UsuarioClave = "juan@gmail.com"
            };
            Assert.AreEqual("juan@gmail.com", clave.UsuarioClave);
        }

        [TestMethod]
        public void ClaveGetUsuarioCambiado()
        {
            Clave clave = new Clave()
            {
                UsuarioClave = "juan@gmail.com"
            };
            clave.UsuarioClave = "pedro@gmail.com";
            Assert.AreEqual("pedro@gmail.com", clave.UsuarioClave);
        }

        [TestMethod]
        public void ClaveLargoUsuarioMenorA5()
        {
            Clave clave = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => clave.UsuarioClave = "A");
        }

        [TestMethod]
        public void ClaveLargoUsuarioMayorA25()
        {
            Clave clave = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => clave.UsuarioClave = "12345678901234567890123456");
        }

        [TestMethod]
        public void ClaveGetClaveCorrecta()
        {
            Clave clave = new Clave()
            {
                Codigo = "123456"
            };
            Assert.AreEqual("123456", clave.Codigo);
        }

        [TestMethod]
        public void ClaveGetClaveCambiada()
        {
            Clave clave = new Clave()
            {
                Codigo = "123456"
            };
            clave.Codigo = "claveNueva";
            Assert.AreEqual("claveNueva", clave.Codigo);
        }

        [TestMethod]
        public void ClaveLargoClaveMenorA5()
        {
            Clave clave = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => clave.Codigo = "A");
        }

        [TestMethod]
        public void ClaveLargoClaveMayorA25()
        {
            Clave clave = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => clave.Codigo = "12345678901234567890123456");
        }

        [TestMethod]
        public void ClaveGetSitioCorrecto()
        {
            Clave clave = new Clave()
            {
                Sitio = "Netflix.com"
            };
            Assert.AreEqual("Netflix.com", clave.Sitio);
        }

        [TestMethod]
        public void ClaveGetSitioCambiado()
        {
            Clave clave = new Clave()
            {
                Sitio = "Netflix.com"
            };
            clave.Sitio = "youtube.com";
            Assert.AreEqual("youtube.com", clave.Sitio);
        }

        [TestMethod]
        public void ClaveLargoSitioMenorA3()
        {
            Clave clave = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => clave.Sitio = "A");
        }

        [TestMethod]
        public void ClaveLargoSitioMayorA25()
        {
            Clave clave = new Clave();
            Assert.ThrowsException<LargoIncorrectoException>(() => clave.Sitio = "sitioconmasde25caracteres.com");
        }

        [TestMethod]
        public void ClaveGetNotaCorrecta()
        {
            Clave clave = new Clave()
            {
                Nota = "Hola"
            };
            Assert.AreEqual("Hola", clave.Nota);
        }

        [TestMethod]
        public void ClaveGetNotaCambiada()
        {
            Clave clave = new Clave()
            {
                Nota = "Hola"
            };
            clave.Nota = "notaNueva";
            Assert.AreEqual("notaNueva", clave.Nota);
        }

        [TestMethod]
        public void ClaveLargoNotaMayorA250()
        {
            Clave clave = new Clave();
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "C";
            Assert.ThrowsException<LargoIncorrectoException>(() => clave.Nota = notaDemasiadoLarga);
        }

        [TestMethod]
        public void ClaveNivelSeguridadMenorOchoChars()
        {
            Clave clave = new Clave
            {
                Codigo = "clave1"
            };

            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            Assert.AreEqual(color.Rojo, nivelSeguridad.GetNivelSeguridad(clave.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadEntreOchoYCatorceChars()
        {
            Clave clave = new Clave
            {
                Codigo = "clave212345"
            };

            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            Assert.AreEqual(color.Naranja, nivelSeguridad.GetNivelSeguridad(clave.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceSoloMay()
        {
            Clave clave = new Clave
            {
                Codigo = "CLAVESOLOMAYUSCULAS"
            };

            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            Assert.AreEqual(color.Amarillo, nivelSeguridad.GetNivelSeguridad(clave.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceSoloMin()
        {
            Clave clave = new Clave
            {
                Codigo = "clavesolominusculas"
            };

            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            Assert.AreEqual(color.Amarillo, nivelSeguridad.GetNivelSeguridad(clave.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceConMayYMin()
        {
            Clave clave = new Clave
            {
                Codigo = "ClaveConMayYMin"
            };

            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            Assert.AreEqual(color.VerdeClaro, nivelSeguridad.GetNivelSeguridad(clave.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceConMayMinNumYSim()
        {
            Clave clave = new Clave
            {
                Codigo = "ClaveConMayYMin14@#"
            };

            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            Assert.AreEqual(color.VerdeOscuro, nivelSeguridad.GetNivelSeguridad(clave.Codigo));
        }

        [TestMethod]
        public void ClaveNivelSeguridadMayorACatorceConMayMinNumYSimEnUltimoChar()
        {
            Clave clave = new Clave
            {
                Codigo = "claveconmayymiN14@"
            };

            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            Assert.AreEqual(color.VerdeOscuro, nivelSeguridad.GetNivelSeguridad(clave.Codigo)
);
        }

        [TestMethod]
        public void ClaveEqualsMismoSitioYUsuario()
        {
            Clave clave1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Clave clave2 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Assert.AreEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveEqualsDiferenteSitioYMismoUsuario()
        {
            Clave clave1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Clave clave2 = new Clave()
            {
                Sitio = "aulas.edu.uy",
                UsuarioClave = "UsuarioORT"
            };
            Assert.AreNotEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveEqualsMismoSitioYDiferenteUsuario()
        {
            Clave clave1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario123"
            };
            Clave clave2 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario789" 
            };
            Assert.AreNotEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveEqualsConNull()
        {
            Clave clave1 = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario123"
            };
            Clave clave2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => clave1.Equals(clave2)) ;
        }

        [TestMethod]
        public void ClaveEqualsConString()
        {
            Clave clave = new Clave()
            {
                Sitio = "ort.edu.uy",
                UsuarioClave = "Usuario123"
            };
            String falsaClave = "falsaClave"; 
            Assert.ThrowsException<ObjetoIncorrectoException>(() => clave.Equals(falsaClave));
        }

        [TestMethod]
        public void ClaveEqualsConMayYMin()
        {
            Clave clave1 = new Clave()
            {
                Sitio = "Ort.Edu.Uy",
                UsuarioClave = "UsuarioORT"
            };
            Clave clave2 = new Clave()
            {
                Sitio = "oRt.eDu.uY",
                UsuarioClave = "UsuarioORT"
            };
            Assert.AreEqual(clave1, clave2);
        }

        [TestMethod]
        public void ClaveGetFechaModificacionNuevaClave() {

            Clave evaluar = new Clave();

            DateTime actual = new System.DateTime().Date;
            Assert.AreEqual(actual, evaluar.FechaModificacion);
        }

        [TestMethod]
        public void ClaveGetFechaModificacionClaveVieja()
        {

            Clave evaluar = new Clave() {
                Codigo = "12345ABCD"
            };
            evaluar.FechaModificacion = new DateTime(2000, 1, 1);

            evaluar.Codigo = "ClaveNueva";
            DateTime actual = System.DateTime.Now.Date;
            Assert.AreEqual(actual, evaluar.FechaModificacion);
        }


        [TestMethod]
        public void ClaveUsuarioInsensitive() {
            Clave mayusculas = new Clave()
            {
                UsuarioClave = "AAAAA",
                Sitio = "ORT.EDU.UY"
            };
            Clave minusculas = new Clave()
            {
                UsuarioClave = "aaaaa",
                Sitio = "ort.edu.uy"
            };
            Assert.AreEqual(minusculas, mayusculas);
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
