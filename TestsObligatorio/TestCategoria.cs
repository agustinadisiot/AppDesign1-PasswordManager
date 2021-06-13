using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using Negocio;
using Repositorio;

namespace TestsObligatorio
{
    [TestClass]
    public class TestCategoria
    {
        private Categoria categoria1;
        private Categoria categoria2;
        private DataAccessCategoria acceso;
        private ControladoraCategoria controladora;
        private ControladoraAdministrador controladoraAdministrador;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            controladoraAdministrador = new ControladoraAdministrador();
            controladoraAdministrador.BorrarTodo();

            acceso = new DataAccessCategoria();

            controladora = new ControladoraCategoria();

            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };

        }

        [TestMethod]
        public void CategoriaGetNombreCorrecto()
        {
            Assert.AreEqual("Personal", categoria1.Nombre);
        }

        [TestMethod]
        public void CategoriaGetNombreCambiado()
        {
            categoria1.Nombre = "Facultad";
            Assert.AreEqual("Facultad", categoria1.Nombre);
        }

        [TestMethod]
        public void CategoriaLargoNombreMenorA3()
        {
            categoria1.Nombre = "A";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNombre(categoria1));
        }

        [TestMethod]
        public void CategoriaLargoNombreMayorA15()
        {
            categoria1.Nombre = "1234567890123456";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNombre(categoria1));
        }

        [TestMethod]
        public void CategoriaEqualsMismoNombre()
        {
            Categoria categoriaIgualNombre = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Assert.AreEqual(categoria1, categoriaIgualNombre);
        }

        [TestMethod]
        public void CategoriaEqualsDiferenteNombre()
        {
            Assert.AreNotEqual(categoria1, categoria2);
        }

        [TestMethod]
        public void CategoriaEqualsMismoNombreConMayYMin()
        {
            Categoria categoriaIgualNombreConMayYMin = new Categoria()
            {
                Nombre = "personal"
            };
            Assert.AreEqual(categoria1, categoriaIgualNombreConMayYMin);
        }

        [TestMethod]
        public void CategoriaEqualsConNull()
        {
            ControladoraCategoria categoriaNull = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria1.Equals(categoriaNull));
        }

        [TestMethod]
        public void CategoriaEqualsConString()
        {
            String falsaCategoria = "Personal";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => categoria1.Equals(falsaCategoria));
        }

    }

    [TestClass]
    public class TestCategoriaClaves
    {
        private Categoria categoria1;
        private Clave clave1;
        private Clave clave2;
        private DataAccessCategoria accesoCategoria;
        private DataAccessClave accesoClave;
        private ControladoraCategoria controladoraCategoria;
        private ControladoraAdministrador controladoraAdministrador;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            accesoCategoria = new DataAccessCategoria();
            accesoClave = new DataAccessClave();
            controladoraAdministrador = new ControladoraAdministrador();
            controladoraAdministrador.BorrarTodo();

            controladoraCategoria = new ControladoraCategoria();


            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto",
                Nota = "",
                FechaModificacion = DateTime.Now
            };

            clave2 = new Clave()
            {
                Sitio = "Netflix.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = "Nota de una clave",
                FechaModificacion = DateTime.Now
            };

            Usuario usuario = new Usuario()
            {
                Nombre = "usuario",
                ClaveMaestra = "12345ABCD"
            };

            controladoraAdministrador.AgregarUsuario(usuario);

            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaSinClaves()
        {
            Assert.AreEqual(true, controladoraCategoria.EsListaClavesVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaEsListaClavesConClaves()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            Assert.AreEqual(false, controladoraCategoria.EsListaClavesVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaConDosClaves()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            Assert.AreEqual(false, controladoraCategoria.EsListaClavesVacia(categoria1));
            controladoraCategoria.AgregarClave(clave2, categoria1);
            Assert.AreEqual(false, controladoraCategoria.EsListaClavesVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarClaveSinSitioOAplicacion()
        {
            Clave claveSinSitio = new Clave()
            {
                Codigo = clave1.Codigo,
                UsuarioClave = clave1.UsuarioClave,
                Nota = clave1.Nota
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarClave(claveSinSitio, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarClaveSinCodigo()
        {
            Clave claveSinCodigo = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Nota = clave1.Nota
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarClave(claveSinCodigo, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarClaveSinUsuario()
        {
            Clave claveSinUsuario = new Clave()
            {
                Sitio = clave1.Sitio,
                Codigo = clave1.Codigo,
                Nota = clave1.Nota
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarClave(claveSinUsuario, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarClaveYaExistente()
        {
            

            controladoraCategoria.AgregarClave(clave1, categoria1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraCategoria.AgregarClave(clave1, categoria1));
        }

        [TestMethod]
        public void CategoriaGetClaveCorrecta()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, controladoraCategoria.GetClave(claveBuscadora, categoria1));
        }

        [TestMethod]
        public void CategoriaGetClavePrimeraConDos()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.AgregarClave(clave2, categoria1);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, controladoraCategoria.GetClave(claveBuscadora, categoria1)); ;
        }

        [TestMethod]
        public void CategoriaGetClaveSegundaConDos()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.AgregarClave(clave2, categoria1);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave2.Sitio,
                UsuarioClave = clave2.UsuarioClave
            };

            Assert.AreEqual(clave2, controladoraCategoria.GetClave(claveBuscadora, categoria1)); ;
        }

        [TestMethod]
        public void CategoriaGetListaClaves()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.AgregarClave(clave2, categoria1);

            List<Clave> claves = new List<Clave>
            {
                clave1,
                clave2
            };

            List<Clave> retorno = controladoraCategoria.GetListaClaves(categoria1);

            Assert.AreEqual(true, claves.All(retorno.Contains));
        }
        [TestMethod]
        public void CategoriaYaExisteClaveSiExistente()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            Clave claveIgual = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo,
                Nota = clave1.Nota
            };
            Assert.AreEqual(true, controladoraCategoria.YaExisteClave(claveIgual, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveMismoUsuarioDiferenteSitio()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            Clave claveDiferenteSitio = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo,
                Nota = clave1.Nota
            };
            Assert.AreEqual(false, controladoraCategoria.YaExisteClave(claveDiferenteSitio, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveMismoSitioDiferenteUsuario()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            Clave claveDiferenteUsuario = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = "222222",
                Codigo = clave1.Codigo,
                Nota = clave1.Nota
            };
            Assert.AreEqual(false, controladoraCategoria.YaExisteClave(claveDiferenteUsuario, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveDiferentesCodigo()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            Clave claveDiferenteCodigo = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = "87654321",
                Nota = clave1.Nota
            };
            Assert.AreEqual(true, controladoraCategoria.YaExisteClave(claveDiferenteCodigo, categoria1));
        }

        [TestMethod]
        public void CategoriaBorrarClaveCategoriaVacia()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.BorrarClave(clave1, categoria1));
        }

        [TestMethod]
        public void CategoriaBorrarClaveExistenteCategoria()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.BorrarClave(clave1, categoria1);

            Assert.IsFalse(controladoraCategoria.YaExisteClave(clave1, categoria1));
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaDespuesDeBorrar()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.BorrarClave(clave1, categoria1);

            Assert.IsTrue(controladoraCategoria.EsListaClavesVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaDespuesDeBorrarAgregar()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.BorrarClave(clave1, categoria1);
            controladoraCategoria.AgregarClave(clave1, categoria1);

            Assert.IsFalse(controladoraCategoria.EsListaClavesVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaGetClaveBorrada()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.BorrarClave(clave1, categoria1);

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.GetClave(clave1, categoria1));
        }

        [TestMethod]
        public void CategoriaDosClavesGetClaveBorrada()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.AgregarClave(clave2, categoria1);
            controladoraCategoria.BorrarClave(clave1, categoria1);


            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.GetClave(clave1, categoria1));
        }

        [TestMethod]
        public void CategoriaBorrarClaveNoExistenteNoVacio()
        {
            controladoraCategoria.AgregarClave(clave2, categoria1);
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.BorrarClave(clave1, categoria1));
        }

        [TestMethod]
        public void CategoriaModificarClaveNoExistente()
        {
            string usuarioClaveInexistente = "12345@";
            string paginaClaveInexistente = "www.ort.edu.uy";

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioClaveInexistente,
                Sitio = paginaClaveInexistente
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.ModificarClave(buscadora, clave1, categoria1));
        }

        [TestMethod]
        public void CategoriaAlModificarClaveAgregadaLaClaveViejaDejaDeExistir()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);

            Clave buscadora = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };
            controladoraCategoria.ModificarClave(buscadora, clave2, categoria1);


            Assert.IsFalse(controladoraCategoria.YaExisteClave(buscadora, categoria1));
        }

        [TestMethod]
        public void CategoriaModificarClaveYaExistente()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.AgregarClave(clave2, categoria1);

            Clave duplicada = new Clave()
            {
                UsuarioClave = clave2.UsuarioClave,
                Sitio = clave2.Sitio,
                Codigo = clave2.Codigo
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraCategoria.ModificarClave(clave1, duplicada, categoria1));
        }

        [TestMethod]
        public void CategoriaModificarClaveAgregada()
        {

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            string usuarioClaveVieja = "Usuario23";
            string paginaClaveVieja = "www.ort.edu.uy";
            string claveClaveVieja = "1234AbC$";

            Clave clave1 = new Clave()
            {
                UsuarioClave = usuarioClaveVieja,
                Sitio = paginaClaveVieja,
                Codigo = claveClaveVieja,
                Nota = ""
            };

            controladoraCategoria.AgregarClave(clave1, categoria1);

            string usuarioClaveNueva = "user23";
            string paginaClaveNueva = "aulas.edu.uy";
            string claveClaveNueva = "1234AbC$";

            Clave claveNueva = new Clave()
            {
                UsuarioClave = usuarioClaveNueva,
                Sitio = paginaClaveNueva,
                Codigo = claveClaveNueva,
                Nota = ""
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioClaveNueva,
                Sitio = paginaClaveNueva
            };

            controladoraCategoria.ModificarClave(clave1, claveNueva, categoria1);

            Assert.AreEqual(controladoraCategoria.GetClave(clave1, categoria1), buscadora);
        }

        [TestMethod]
        public void CategoriaModificarClaveCambiarNotaYClave()
        {
            controladoraCategoria.AgregarClave(clave1, categoria1);

            Clave claveNueva = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio,
                Codigo = "CodigoNuevo",
                Nota = "NotaNueva"
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };

            controladoraCategoria.ModificarClave(buscadora, claveNueva, categoria1);

            clave1 = controladoraCategoria.GetClave(clave1, categoria1);

            bool igualSitioYUsuario = clave1.Equals(claveNueva);
            bool igualNota = clave1.Nota == claveNueva.Nota;
            bool igualCodigo = clave1.Codigo == claveNueva.Codigo;  

            Assert.IsTrue(igualSitioYUsuario && igualNota && igualCodigo);
        }

        [TestMethod]
        public void CategoriaModificarClaveCambiaFechaModificacion()
        {
            clave1.FechaModificacion = new DateTime(2000, 1, 1);

            controladoraCategoria.AgregarClave(clave1, categoria1);

            Clave claveNueva = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio,
                Codigo = "CodigoNuevo",
                Nota = "NotaNueva"
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };

            controladoraCategoria.ModificarClave(buscadora, claveNueva, categoria1);

            clave1 = controladoraCategoria.GetClave(buscadora, categoria1);

            bool igualSitioYUsuario = clave1.Equals(claveNueva);
            bool igualNota = clave1.Nota == claveNueva.Nota;
            bool igualClave = clave1.Codigo == claveNueva.Codigo;
            bool distintaFecha = clave1.FechaModificacion == System.DateTime.Now.Date;
            Assert.IsTrue(igualSitioYUsuario && igualNota && igualClave && distintaFecha);
        }

        [TestMethod]
        public void CategoriaGetClavesColorEsVacia()
        {
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            int cantidadRojas = 0;
            Assert.AreEqual(cantidadRojas, controladoraCategoria.GetListaClavesColor(color.Rojo, categoria1).Count);
        }

        [TestMethod]
        public void CategoriaGetListaClavesColorNoVacia()
        {
            clave1.Codigo = "ClaveVerdeOscuro12@";
            controladoraCategoria.AgregarClave(clave1, categoria1);
            controladoraCategoria.AgregarClave(clave2, categoria1);

            List<Clave> clavesVerdes = new List<Clave>
            {
                clave1
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<Clave> getListaClavesVerdes = controladoraCategoria.GetListaClavesColor(color.VerdeOscuro, categoria1);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesVerdes.All(clavesVerdes.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesVerdes.All(getListaClavesVerdes.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }
    }

    [TestClass]
    public class TestCategoriaTarjeta
    {
        private Categoria categoria1;
        private Tarjeta tarjeta1;
        private Tarjeta tarjeta2;
        private DataAccessCategoria accesoCategoria;
        private DataAccessTarjeta accesoTarjeta;
        private ControladoraCategoria controladoraCategoria;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            List<Categoria> categoriasABorrar = (List<Categoria>)accesoCategoria.GetTodos();
            foreach (Categoria actual in categoriasABorrar)
            {
                accesoCategoria.Borrar(actual);
            }

            controladoraCategoria = new ControladoraCategoria();

            List<Tarjeta> clavesABorrar = (List<Tarjeta>)accesoTarjeta.GetTodos();
            foreach (Tarjeta actual in clavesABorrar)
            {
                accesoTarjeta.Borrar(actual);
            }

            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };

            tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };

        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaSinTarjetas()
        {
            Assert.AreEqual(true, controladoraCategoria.EsListaTarjetasVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConTarjetas()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            Assert.AreEqual(false, controladoraCategoria.EsListaTarjetasVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConDosTarjetas()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria1);

            Assert.AreEqual(false, controladoraCategoria.EsListaTarjetasVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNombre()
        {
            Tarjeta tarjetaSinNombre = new Tarjeta()
            {
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarTarjeta(tarjetaSinNombre, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinTipo()
        {
            Tarjeta tarjetaSinTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarTarjeta(tarjetaSinTipo, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNumero()
        {
            Tarjeta tarjetaSinNumero = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarTarjeta(tarjetaSinNumero, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinCodigo()
        {
            Tarjeta tarjetaSinCodigo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarTarjeta(tarjetaSinCodigo, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinVencimiento()
        {
            Tarjeta tarjetaSinVencimiento = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraCategoria.AgregarTarjeta(tarjetaSinVencimiento, categoria1));
        }

        [TestMethod]
        public void CategoriaGetTarjetaCorrecta()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta buscadora = new Tarjeta() 
            { 
                Numero = tarjeta1.Numero
            };

            Assert.AreEqual(tarjeta1, controladoraCategoria.GetTarjeta(buscadora, categoria1)); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaPrimeraConDos()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.AreEqual(tarjeta1, controladoraCategoria.GetTarjeta(buscadora, categoria1)); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaSegundaConDos()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            Assert.AreEqual(tarjeta1, controladoraCategoria.GetTarjeta(buscadora, categoria1));
        }

        [TestMethod]
        public void CategoriaGetListaTarjetas()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria1);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            Assert.AreEqual(true, tarjetas.SequenceEqual(controladoraCategoria.GetListaTarjetas(categoria1)));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaSiExistente()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(true, controladoraCategoria.YaExisteTarjeta(tarjetaIgual, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNumero()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta2.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(false, controladoraCategoria.YaExisteTarjeta(tarjetaDistintoNumero, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNombre()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = tarjeta2.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(true, controladoraCategoria.YaExisteTarjeta(tarjetaDistintoNombre, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteTipo()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(true, controladoraCategoria.YaExisteTarjeta(tarjetaDistintoTipo, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteCodigo()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            Tarjeta tarjetaDistintoCodigo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta2.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(true, controladoraCategoria.YaExisteTarjeta(tarjetaDistintoCodigo, categoria1));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaYaExistente()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaVacia()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.BorrarTarjeta(tarjeta1, categoria1));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaConUnaTarjeta()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            controladoraCategoria.BorrarTarjeta(tarjeta1, categoria1);

            Assert.IsFalse(controladoraCategoria.YaExisteTarjeta(tarjeta1, categoria1));
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaDespuesDeBorrar()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            controladoraCategoria.BorrarTarjeta(tarjeta1, categoria1);

            Assert.IsTrue(controladoraCategoria.EsListaTarjetasVacia(categoria1));
        }

        [TestMethod]
        public void CategoriaGetTarjetaBorrada()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            controladoraCategoria.BorrarTarjeta(aBorrar, categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() =>controladoraCategoria.GetTarjeta(buscadora, categoria1));
        }

        [TestMethod]
        public void CategoriaDosTarjetasGetTarjetaBorrada()
        {
            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria1);
            controladoraCategoria.BorrarTarjeta(aBorrar, categoria1);

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.GetTarjeta(buscadora, categoria1));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaQueNoExiste()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            string numeroTarjeta = "1234567890876543";

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.BorrarTarjeta(aBorrar, categoria1));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteVencimiento()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(true, controladoraCategoria.YaExisteTarjeta(tarjetaDistintoTipo, categoria1));
        }

        [TestMethod]
        public void CategoriaAlModificarTarjetaAgregadaLaTarjetaViejaDejaDeExistir()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            controladoraCategoria.ModificarTarjeta(tarjeta1, tarjeta2, categoria1);

            Assert.IsFalse(controladoraCategoria.YaExisteTarjeta(buscadora, categoria1));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaNoExistente()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            string numeroTarjetaInexistente = "1234567890876543";

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaInexistente
            };

            Tarjeta aBuscar = controladoraCategoria.GetTarjeta(buscadora, categoria1);

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraCategoria.ModificarTarjeta(aBuscar, tarjeta1, categoria1));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaYaExistente()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria1);

            Tarjeta duplicada = new Tarjeta()
            {
                Nombre = tarjeta2.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta2.Numero,
                Codigo = tarjeta2.Codigo,
                Nota = tarjeta2.Nota,
                Vencimiento = tarjeta2.Vencimiento
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraCategoria.ModificarTarjeta(tarjeta1, duplicada, categoria1));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaAgregada()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            controladoraCategoria.ModificarTarjeta(tarjeta1, tarjeta2, categoria1);

            tarjeta1 = controladoraCategoria.GetTarjeta(buscadora, categoria1);

            Assert.AreEqual(tarjeta1, buscadora);
        }

        [TestMethod]
        public void CategoriaModificarTarjetaCambiarTodoMenosNumero()
        {
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = this.tarjeta1.Numero
            };

            controladoraCategoria.ModificarTarjeta(tarjeta1, tarjeta2, categoria1);

            tarjeta1 = controladoraCategoria.GetTarjeta(buscadora, categoria1);

            bool igualNumero = tarjeta1.Numero == tarjeta2.Numero;
            bool igualNombre = tarjeta1.Nombre == tarjeta2.Nombre;
            bool igualTipo = tarjeta1.Tipo == tarjeta2.Tipo;
            bool igualNota = tarjeta1.Nota == tarjeta2.Nota;
            bool igualCodigo = tarjeta1.Codigo == tarjeta2.Codigo;
            bool igualVencimiento = tarjeta1.Vencimiento == tarjeta2.Vencimiento;

            bool modificoCorrecto = igualNumero && igualNombre && igualTipo && igualNota && igualCodigo && igualVencimiento;

            Assert.IsTrue(modificoCorrecto);
        }
    }
}
