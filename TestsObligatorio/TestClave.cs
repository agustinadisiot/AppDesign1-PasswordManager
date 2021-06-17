using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaDeNegocio;
using System;
using System.Linq;
using Negocio;

namespace TestsObligatorio
{
    [TestClass]
    public class TestClave
    {
        private ControladoraAdministrador controladoraAdministrador;
        private ControladoraClave controladora;
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
            controladoraAdministrador = new ControladoraAdministrador();
            controladoraAdministrador.BorrarTodo();
            controladora = new ControladoraClave();

            

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
            clave1.UsuarioClave = menorA5;
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarUsuarioClave(clave1));
        }

        [TestMethod]
        public void ClaveLargoUsuarioMayorA25()
        {
            clave1.UsuarioClave = mayorA25;
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarUsuarioClave(clave1));
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
            clave1.Codigo = menorA5;
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarCodigo(clave1));
        }

        [TestMethod]
        public void ClaveLargoClaveMayorA25()
        {
            clave1.Codigo = mayorA25;
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarCodigo(clave1));
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
            clave1.Sitio = "a";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarSitio(clave1));
        }

        [TestMethod]
        public void ClaveLargoSitioMayorA25()
        {
            clave1.Sitio = mayorA25;
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarSitio(clave1));
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
            clave1.Nota = notaMayorA250;
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNota(clave1));
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
            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto",
                Nota = "",
                FechaModificacion = DateTime.Now
            };

            Usuario usuario = new Usuario()
            {
                Nombre = "usuario",
                ClaveMaestra = "12345ABCD"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            ControladoraAdministrador controladoraAdministrador = new ControladoraAdministrador();
            controladoraAdministrador.AgregarUsuario(usuario);

            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            controladoraUsuario.AgregarCategoria(categoria, usuario);


            controladoraUsuario.AgregarClave(clave1, categoria, usuario);

            Clave aModificar = new Clave()
            {
                Codigo = "CodigoModificado",
                Nota = "",
                UsuarioClave = "usuario",
                Sitio = "Sitio",
                FechaModificacion = new DateTime(2000, 1, 1),
                Id = clave1.Id
            };

            /*ClaveAModificar claveAModificar = new ClaveAModificar()
            {
                CategoriaNueva = categoria,
                CategoriaVieja = categoria,
                ClaveVieja = aAgregar,
                ClaveNueva = aModificar
            };*/

            controladora.Modificar(aModificar);



            Assert.AreEqual(tiempoActual, aModificar.FechaModificacion);
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
        private GeneradoraClaves generadora;

        [TestInitialize]
        public void Setup()
        {
            generadora = new GeneradoraClaves()
            {
                IncluirMayusculas = false,
                IncluirMinusculas = false,
                IncluirNumeros = false,
                IncluirSimbolos = false,
                Largo = 10
            };
        }

        [TestMethod]
        public void ClaveGeneradaVacia()
        {
            Assert.ThrowsException<ClaveGeneradaVaciaException>(() => generadora.Generar());
        }

        [TestMethod]
        public void ClaveGeneradaSoloMayusculas()
        {
            generadora.Largo = 5;
            generadora.IncluirMayusculas = true;

            string resultado = generadora.Generar();
            bool esSoloMayuscula = resultado.All(caracter => VerificadoraString.EsMayuscula(caracter));
            Assert.IsTrue(esSoloMayuscula);
        }

        [TestMethod]
        public void ClaveGeneradaLargoCorrecto()
        {
            generadora.IncluirMayusculas = true;

            string resultado = generadora.Generar();
            Assert.AreEqual(10, resultado.Length);
        }

        [TestMethod]
        public void ClaveGeneradaIncluyendoTodo()
        {
            generadora.IncluirMayusculas = true;
            generadora.IncluirMinusculas = true;
            generadora.IncluirNumeros = true;
            generadora.IncluirSimbolos = true;


            string resultado = generadora.Generar();
            bool contieneMayusculas = resultado.Any(caracter => VerificadoraString.EsMayuscula(caracter));
            bool contieneMinusculas = resultado.Any(caracter => VerificadoraString.EsMinuscula(caracter));
            bool contieneNumeros = resultado.Any(caracter => VerificadoraString.EsNumero(caracter));
            bool contieneSimbolos = resultado.Any(caracter => VerificadoraString.EsSimbolo(caracter));

            Assert.IsTrue(contieneMayusculas && contieneMinusculas && contieneNumeros && contieneSimbolos);
        }

        [TestMethod]
        public void ClaveGeneradaIncluyendoSimbolosMinusculas()
        {
            generadora.Largo = 15;
            generadora.IncluirMinusculas = true;
            generadora.IncluirSimbolos = true;

            string resultado = generadora.Generar();
            bool contieneMayusculas = resultado.Any(caracter => VerificadoraString.EsMayuscula(caracter));
            bool contieneMinusculas = resultado.Any(caracter => VerificadoraString.EsMinuscula(caracter));
            bool contieneNumeros = resultado.Any(caracter => VerificadoraString.EsNumero(caracter));
            bool contieneSimbolos = resultado.Any(caracter => VerificadoraString.EsSimbolo(caracter));

            Assert.IsTrue(!contieneMayusculas && contieneMinusculas && !contieneNumeros && contieneSimbolos);
        }
    }

}
