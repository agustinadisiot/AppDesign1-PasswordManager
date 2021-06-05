using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestCategoria
    {
        private Categoria categoria1;
        private Categoria categoria2;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
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
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria1.Nombre = "A");
        }

        [TestMethod]
        public void CategoriaLargoNombreMayorA15()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => categoria1.Nombre = "1234567890123456");
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
            Categoria categoriaNull = null;
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

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto",
                Nota = ""
            };

            clave2 = new Clave()
            {
                Sitio = "Netflix.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = "Nota de una clave"
            };
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaSinClaves()
        {
            Assert.AreEqual(true, categoria1.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaClavesConClaves()
        {
            categoria1.AgregarClave(clave1);
            Assert.AreEqual(false, categoria1.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaConDosClaves()
        {
            categoria1.AgregarClave(clave1);
            Assert.AreEqual(false, categoria1.EsListaClavesVacia());
            categoria1.AgregarClave(clave2);
            Assert.AreEqual(false, categoria1.EsListaClavesVacia());
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria1.AgregarClave(claveSinSitio));
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria1.AgregarClave(claveSinCodigo));
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
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria1.AgregarClave(claveSinUsuario));
        }

        [TestMethod]
        public void CategoriaAgregarClaveYaExistente()
        {
            categoria1.AgregarClave(clave1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria1.AgregarClave(clave1));
        }

        [TestMethod]
        public void CategoriaGetClaveCorrecta()
        {
            categoria1.AgregarClave(clave1);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, categoria1.GetClave(claveBuscadora));
        }

        [TestMethod]
        public void CategoriaGetClavePrimeraConDos()
        {
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, categoria1.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void CategoriaGetClaveSegundaConDos()
        {
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave2.Sitio,
                UsuarioClave = clave2.UsuarioClave
            };

            Assert.AreEqual(clave2, categoria1.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void CategoriaGetListaClaves()
        {
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);

            List<Clave> claves = new List<Clave>
            {
                clave1,
                clave2
            };

            List<Clave> retorno = categoria1.GetListaClaves();

            Assert.AreEqual(true, claves.All(retorno.Contains)); ;
        }
        [TestMethod]
        public void CategoriaYaExisteClaveSiExistente()
        {
            categoria1.AgregarClave(clave1);
            Clave claveIgual = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo,
                Nota = clave1.Nota
            };
            Assert.AreEqual(true, categoria1.YaExisteClave(claveIgual));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveMismoUsuarioDiferenteSitio()
        {
            categoria1.AgregarClave(clave1);
            Clave claveDiferenteSitio = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo,
                Nota = clave1.Nota
            };
            Assert.AreEqual(false, categoria1.YaExisteClave(claveDiferenteSitio));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveMismoSitioDiferenteUsuario()
        {
            categoria1.AgregarClave(clave1);
            Clave claveDiferenteUsuario = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = "222222",
                Codigo = clave1.Codigo,
                Nota = clave1.Nota
            };
            Assert.AreEqual(false, categoria1.YaExisteClave(claveDiferenteUsuario));
        }

        [TestMethod]
        public void CategoriaYaExisteClaveDiferentesCodigo()
        {
            categoria1.AgregarClave(clave1);
            Clave claveDiferenteClave = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = "87654321",
                Nota = clave1.Nota
            };
            Assert.AreEqual(true, categoria1.YaExisteClave(claveDiferenteClave));
        }

        [TestMethod]
        public void CategoriaBorrarClaveCategoriaVacia()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.BorrarClave(clave1));
        }

        [TestMethod]
        public void CategoriaBorrarClaveExistenteCategoria()
        {
            categoria1.AgregarClave(clave1);

            categoria1.BorrarClave(clave1);
            Assert.IsFalse(categoria1.YaExisteClave(clave1));
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaDespuesDeBorrar()
        {
            categoria1.AgregarClave(clave1);
            categoria1.BorrarClave(clave1);
            Assert.IsTrue(categoria1.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaEsListaClavesVaciaDespuesDeBorrarAgregar()
        {
            categoria1.AgregarClave(clave1);
            categoria1.BorrarClave(clave1);
            categoria1.AgregarClave(clave1);
            Assert.IsFalse(categoria1.EsListaClavesVacia());
        }

        [TestMethod]
        public void CategoriaGetClaveBorrada()
        {
            categoria1.AgregarClave(clave1);
            categoria1.BorrarClave(clave1);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.GetClave(clave1));
        }

        [TestMethod]
        public void CategoriaDosClavesGetClaveBorrada()
        {
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);
            categoria1.BorrarClave(clave1);


            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.GetClave(clave1));
        }

        [TestMethod]
        public void CategoriaBorrarClaveNoExistenteNoVacio()
        {
            categoria1.AgregarClave(clave2);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.BorrarClave(clave1));
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

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.ModificarClave(buscadora, clave1));
        }

        [TestMethod]
        public void CategoriaAlModificarClaveAgregadaLaClaveViejaDejaDeExistir()
        {
            categoria1.AgregarClave(clave1);

            Clave buscadora = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };

            categoria1.ModificarClave(clave1, clave2);
            Assert.IsFalse(categoria1.YaExisteClave(buscadora));
        }

        [TestMethod]
        public void CategoriaModificarClaveYaExistente()
        {
            categoria1.AgregarClave(clave1);

            categoria1.AgregarClave(clave2);

            Clave duplicada = new Clave()
            {
                UsuarioClave = clave2.UsuarioClave,
                Sitio = clave2.Sitio,
                Codigo = clave2.Codigo
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria1.ModificarClave(clave1, duplicada));
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

            categoria.AgregarClave(clave1);

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

            categoria.ModificarClave(clave1, claveNueva);
            Assert.AreEqual(clave1, buscadora);
        }

        [TestMethod]
        public void CategoriaModificarClaveCambiarNotaYClave()
        {
            categoria1.AgregarClave(clave1);

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

            categoria1.ModificarClave(buscadora, claveNueva);

            bool igualSitioYUsuario = clave1.Equals(claveNueva);
            bool igualNota = clave1.Nota == claveNueva.Nota;
            bool igualCodigo = clave1.Codigo == claveNueva.Codigo;  

            Assert.IsTrue(igualSitioYUsuario && igualNota && igualCodigo);
        }

        [TestMethod]
        public void CategoriaModificarClaveCambiaFechaModificacion()
        {
            clave1.FechaModificacion = new DateTime(2000, 1, 1);

            categoria1.AgregarClave(clave1);

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

            categoria1.ModificarClave(buscadora, claveNueva);

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
            Assert.AreEqual(cantidadRojas, categoria1.GetListaClavesColor(color.Rojo).Count);
        }

        [TestMethod]
        public void CategoriaGetListaClavesColorNoVacia()
        {
            clave1.Codigo = "ClaveVerdeOscuro12@";
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);

            List<Clave> clavesVerdes = new List<Clave>
            {
                clave1
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<Clave> getListaClavesVerdes = categoria1.GetListaClavesColor(color.VerdeOscuro);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesVerdes.All(clavesVerdes.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesVerdes.All(getListaClavesVerdes.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }
    }

    [TestClass]
    public class TestCategoriaTarjeta
    {
        private Categoria categoria1;
        private Categoria categoria2;
        private Tarjeta tarjeta1;
        private Tarjeta tarjeta2;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
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
            Assert.AreEqual(true, categoria1.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConTarjetas()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Assert.AreEqual(false, categoria1.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaConDosTarjetas()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            categoria1.AgregarTarjeta(tarjeta2);
            Assert.AreEqual(false, categoria1.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNombre()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjetaSinNombre = new Tarjeta()
            {
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjetaSinNombre));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinTipo()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjetaSinTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjetaSinTipo));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinNumero()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjetaSinNumero = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjetaSinNumero));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinCodigo()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjetaSinCodigo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjetaSinCodigo));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaSinVencimiento()
        {
            Categoria categoria = new Categoria();
            Tarjeta tarjetaSinVencimiento = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota
            };
            Assert.ThrowsException<ObjetoIncompletoException>(() => categoria.AgregarTarjeta(tarjetaSinVencimiento));
        }

        [TestMethod]
        public void CategoriaGetTarjetaCorrecta()
        {
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta buscadora = new Tarjeta() 
            { 
                Numero = tarjeta1.Numero
            };

            Assert.AreEqual(tarjeta1, categoria1.GetTarjeta(buscadora)); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaPrimeraConDos()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            categoria1.AgregarTarjeta(tarjeta2);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.AreEqual(tarjeta1, categoria1.GetTarjeta(buscadora)); 
        }

        [TestMethod]
        public void CategoriaGetTarjetaSegundaConDos()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            categoria1.AgregarTarjeta(tarjeta2);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            Assert.AreEqual(tarjeta2, categoria1.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaGetListaTarjetas()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            categoria1.AgregarTarjeta(tarjeta2);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            Assert.AreEqual(true, tarjetas.SequenceEqual(categoria1.GetListaTarjetas()));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaSiExistente()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, categoria1.YaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNumero()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta2.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(false, categoria1.YaExisteTarjeta(tarjetaDistintoNumero));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteNombre()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = tarjeta2.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, categoria1.YaExisteTarjeta(tarjetaDistintoNombre));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteTipo()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, categoria1.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteCodigo()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, categoria1.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaAgregarTarjetaYaExistente()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria1.AgregarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaVacia()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.BorrarTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaCategoriaConUnaTarjeta()
        {
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            categoria1.BorrarTarjeta(aBorrar);
            Assert.IsFalse(categoria1.YaExisteTarjeta(tarjeta1));
        }

        [TestMethod]
        public void CategoriaEsListaTarjetasVaciaDespuesDeBorrar()
        {
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            categoria1.BorrarTarjeta(aBorrar);
            Assert.IsTrue(categoria1.EsListaTarjetasVacia());
        }

        [TestMethod]
        public void CategoriaGetTarjetaBorrada()
        {
            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            categoria1.AgregarTarjeta(tarjeta1);
            categoria1.BorrarTarjeta(aBorrar);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.GetTarjeta(buscadora));
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

            categoria1.AgregarTarjeta(tarjeta1);
            categoria1.AgregarTarjeta(tarjeta2);
            categoria1.BorrarTarjeta(aBorrar);
            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaBorrarTarjetaQueNoExiste()
        {
            categoria1.AgregarTarjeta(tarjeta1);

            string numeroTarjeta = "1234567890876543";

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.BorrarTarjeta(aBorrar));
        }

        [TestMethod]
        public void CategoriaYaExisteTarjetaDiferenteVencimiento()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Nota = tarjeta1.Nota,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, categoria1.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void CategoriaAlModificarTarjetaAgregadaLaTarjetaViejaDejaDeExistir()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };
            categoria1.ModificarTarjeta(tarjeta1, tarjeta2);
            Assert.IsFalse(categoria1.YaExisteTarjeta(buscadora));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaNoExistente()
        {
            categoria1.AgregarTarjeta(tarjeta1);

            string numeroTarjetaInexistente = "1234567890876543";

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaInexistente
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => categoria1.ModificarTarjeta(categoria1.GetTarjeta(buscadora), tarjeta1));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaYaExistente()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            categoria1.AgregarTarjeta(tarjeta2);

            Tarjeta duplicada = new Tarjeta()
            {
                Nombre = tarjeta2.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta2.Numero,
                Codigo = tarjeta2.Codigo,
                Nota = tarjeta2.Nota,
                Vencimiento = tarjeta2.Vencimiento
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => categoria1.ModificarTarjeta(tarjeta1, duplicada));
        }

        [TestMethod]
        public void CategoriaModificarTarjetaAgregada()
        {
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            categoria1.ModificarTarjeta(tarjeta1, tarjeta2);
            Assert.AreEqual(tarjeta1, buscadora);
        }

        [TestMethod]
        public void CategoriaModificarTarjetaCambiarTodoMenosNumero()
        {
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = this.tarjeta1.Numero
            };

            categoria1.ModificarTarjeta(buscadora, tarjeta2);

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
