using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsObligatorio
{

    [TestClass]
    public class TestUsuario
    {

        private Usuario usuario;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "Hola12345"
            };
        }

        [TestMethod]
        public void UsuarioGetNombreCorrecto()
        {
            Assert.AreEqual("Usuario1", usuario.Nombre);
        }

        [TestMethod]
        public void UsuarioGetNombreCambiado()
        {
            usuario.Nombre = "Hernesto";
            Assert.AreEqual("Hernesto", usuario.Nombre);
        }

        [TestMethod]
        public void UsuarioLargoNombreMenorA5()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "A");
        }

        [TestMethod]
        public void UsuarioLargoNombreMayorA25()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "12345678901234567890123456");
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestra()
        {
            Assert.AreEqual(true, usuario.ValidarIgualClaveMaestra("Hola12345"));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestraDiferente()
        {
            Assert.AreEqual(false, usuario.ValidarIgualClaveMaestra("Diferente"));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestraCambiada()
        {
            usuario.ClaveMaestra = "Chau109876";
            Assert.AreEqual(true, usuario.ValidarIgualClaveMaestra("Chau109876"));
        }

        [TestMethod]
        public void UsuarioLargoClaveMaestraMenorA5()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ClaveMaestra = "A");
        }

        [TestMethod]
        public void UsuarioLargoClaveMaestraMayorA25()
        {
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ClaveMaestra = "12345678901234567890123456");
        }
    }

    [TestClass]
    public class TestUsuarioCategoria
    {
        private Usuario usuario;
        private Categoria categoria1;
        private Categoria categoria2;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {

            usuario = new Usuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "Hola12345"
            };

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
        public void UsuarioEsListaCategoriasVaciaSinCategorias()
        {
            Assert.AreEqual(true, usuario.EsListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioEsListaConCategoriasVaciaConUnaCategoria()
        {
            usuario.AgregarCategoria(categoria1);
            Assert.AreEqual(false, usuario.EsListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaConDosCategorias()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);
            Assert.AreEqual(false, usuario.EsListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaVacia()
        {
            Categoria categoria = new Categoria();
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarCategoria(categoria));
        }

        [TestMethod]
        public void UsuarioGetCategoriaCorrecta()
        {
            usuario.AgregarCategoria(categoria1);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(categoria1, usuario.GetCategoria(buscadora));
        }

        [TestMethod]
        public void UsuarioGetCategoriaPrimeraConDos()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Personal"
            };

            Assert.AreEqual(categoria1, usuario.GetCategoria(buscadora));
        }

        [TestMethod]
        public void UsuarioGetCategoriaSegundaConDos()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Assert.AreEqual(categoria2, usuario.GetCategoria(buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaYaExistente()
        {
            usuario.AgregarCategoria(categoria1);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.AgregarCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaSiExistente()
        {
            usuario.AgregarCategoria(categoria1);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(true, usuario.YaExisteCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaNoExistente()
        {
            Usuario usuario = new Usuario();
            usuario.AgregarCategoria(categoria1);
            Assert.AreEqual(false, usuario.YaExisteCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioEqualsMismoNombreYClave()
        {
            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario1"
            };
            Assert.AreEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioEqualsDiferenteNombreYMismaClave()
        {
            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario789"
            };
            Assert.AreNotEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioEqualsConNull()
        {
            Usuario usuario2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.Equals(usuario2));
        }

        [TestMethod]
        public void UsuarioEqualsConString()
        {
            string falsoUsuario = "Usuario123";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => usuario.Equals(falsoUsuario));
        }

        [TestMethod]
        public void UsuarioEqualsMismoNombreMayusculaYMinusucula()
        {
            Usuario usuario2 = new Usuario()
            {
                Nombre = "uSUARio1"
            };
            Assert.AreEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaAgregada()
        {
            usuario.AgregarCategoria(categoria1);

            Categoria copia = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            usuario.ModificarNombreCategoria(copia, categoria2);

            Assert.AreEqual("Trabajo", categoria1.Nombre);
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaNoExistente()
        {
            usuario.AgregarCategoria(categoria1);

            Categoria categoriaNoAgregada = new Categoria()
            {
                Nombre = "Facultad"
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.ModificarNombreCategoria(categoriaNoAgregada, categoria2));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaANombreExistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            Categoria modificarVieja = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Categoria modificarNueva = new Categoria()
            {
                Nombre = categoria2.Nombre
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarNombreCategoria(modificarVieja, modificarNueva));
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasVacia()
        {
            int cantCategorias = usuario.GetListaCategorias().Count();

            Assert.IsTrue(cantCategorias == 0);
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasNoVacia()
        {
            usuario.AgregarCategoria(categoria1);
            Assert.IsNotNull(usuario.GetListaCategorias());
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasEsIgual()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            List<Categoria> categorias = new List<Categoria>
            {
                categoria1,
                categoria2
            };

            List<Categoria> resultado = usuario.GetListaCategorias();

            Assert.AreEqual(true, categorias.All(resultado.Contains)); ;
        }

    }

    [TestClass]
    public class TestUsuarioClave
    {
        private Usuario usuario;
        private Categoria categoria1;
        private Categoria categoria2;
        private Clave clave1;
        private Clave clave2;
        private Clave clave3;
        private Clave clave4;
        private Tarjeta tarjeta1;
        private Tarjeta tarjeta2;
        private Tarjeta tarjeta3;
        private DateTime tiempoActual;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            tiempoActual = DateTime.Now;

            usuario = new Usuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "Hola12345"
            };

            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
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
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = "Nota de una clave"
            };

            clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };

            clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
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

            tarjeta3 = new Tarjeta()
            {
                Numero = "3333333333333333",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };

        }

        [TestMethod]
        public void UsuarioYaExisteClaveUnaCategoriaSiExistente()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            Clave claveIgual = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(true, usuario.YaExisteClave(claveIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveMismoUsuarioDiferenteSitio()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            Clave claveDiferenteSitio = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = clave1.UsuarioClave,
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(false, usuario.YaExisteClave(claveDiferenteSitio));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveMismoSitioDiferenteUsuario()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            Clave claveDiferenteUsuario = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = "222222",
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(false, usuario.YaExisteClave(claveDiferenteUsuario));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveDiferentesCodigos()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            Clave claveDiferenteCodigo = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave,
                Codigo = "12345678"
            };
            Assert.AreEqual(true, usuario.YaExisteClave(claveDiferenteCodigo));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveDosCategoriasSiExistente()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            categoria2.AgregarClave(clave2);
            usuario.AgregarCategoria(categoria2);

            Clave claveIgual = new Clave()
            {
                Sitio = clave2.Sitio,
                UsuarioClave = clave2.UsuarioClave,
                Codigo = clave2.Codigo
            };
            Assert.AreEqual(true, usuario.YaExisteClave(claveIgual));
        }

        [TestMethod]
        public void UsuarioAgregarClave()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            Assert.AreEqual(true, usuario.YaExisteClave(clave1));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinCategoria()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.AgregarClave(clave1, categoria1));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinSitioOAplicacion()
        {
            Clave claveSinSitio = new Clave()
            {
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria1);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarClave(claveSinSitio, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinCodigo()
        {
            Clave claveSinCodigo = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111"
            };

            usuario.AgregarCategoria(categoria1);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarClave(claveSinCodigo, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinUsuario()
        {
            Clave claveSinUsuario = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria1);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarClave(claveSinUsuario, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarClaveRepetida()
        {
            usuario.AgregarCategoria(categoria1);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            usuario.AgregarClave(clave1, buscadora);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.AgregarClave(clave1, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarClaveCategoriaConClave()
        {
            usuario.AgregarCategoria(categoria1);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            usuario.AgregarClave(clave1, buscadora);
            Assert.AreEqual(true, usuario.GetCategoria(buscadora).YaExisteClave(clave1));
        }

        [TestMethod]
        public void UsuarioBorrarClaveSinCategorias()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.BorrarClave(clave1));
        }

        [TestMethod]
        public void UsuarioBorrarClaveSinClaves()
        {
            usuario.AgregarCategoria(categoria1);

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.BorrarClave(clave1));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveBorrada()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            Clave aBorrar = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };

            usuario.BorrarClave(aBorrar);
            Assert.IsFalse(usuario.YaExisteClave(clave1));
        }

        [TestMethod]
        public void UsuarioBorrarClaveYYaExisteClaveRestante()
        {
            usuario.AgregarCategoria(categoria1);

            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            Clave aBorrar = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };
            usuario.BorrarClave(aBorrar);
            Assert.IsTrue(usuario.YaExisteClave(clave2));
        }

        [TestMethod]
        public void UsuarioGetClaveCorrecta()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, usuario.GetClave(claveBuscadora));
        }

        [TestMethod]
        public void UsuarioaGetClavePrimeraConDosClaves()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1, usuario.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void UsuarioaGetClaveSegundaConDosClaves()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave2.Sitio,
                UsuarioClave = clave2.UsuarioClave
            };

            Assert.AreEqual(clave2, usuario.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void UsuarioaGetClaveATravesDeClaveSinCodigo()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            Clave claveBuscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(clave1.Codigo, usuario.GetClave(claveBuscadora).Codigo);
        }

        [TestMethod]
        public void UsuarioaGetClaveInexistente()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetClave(clave1));
        }
        
        [TestMethod]
        public void UsuarioModificarClaveNoExistente()
        {
            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = clave1,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.ModificarClave(parametros));
        }

        [TestMethod]
        public void UsuarioAlModificarClaveAgregadaLaClaveViejaDejaDeExistir()
        {
            usuario.AgregarCategoria(categoria1);
            categoria1.AgregarClave(clave1);

            Clave buscadora = new Clave()
            {
                UsuarioClave = clave1.UsuarioClave,
                Sitio = clave1.Sitio
            };


            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = buscadora,
                ClaveNueva = clave2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1
            };

            usuario.ModificarClave(parametros);
            Assert.IsFalse(usuario.YaExisteClave(buscadora));
        }

        [TestMethod]
        public void UsuarioModificarClaveYaExistente()
        {
            usuario.AgregarCategoria(categoria1);
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);

            Clave duplicada = new Clave()
            {
                UsuarioClave = clave2.UsuarioClave,
                Sitio = clave2.Sitio,
                Codigo = "33333333",
                Nota = "Otra Nota"
            };

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = duplicada,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarClave(parametros));
        }

        [TestMethod]
        public void UsuarioModificarClaveMoverACategoriaNoExistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1,categoria1);

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = clave1,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.ModificarClave(parametros));
        }

        [TestMethod]
        public void UsuarioModificarClaveMoverACategoriaExistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);
            usuario.AgregarClave(clave1, categoria1);

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = clave1,
                ClaveNueva = clave2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            usuario.ModificarClave(parametros);

            Clave buscadora = new Clave()
            {
                UsuarioClave = clave2.UsuarioClave,
                Sitio = clave2.Sitio
            };

            Clave resultado = usuario.GetClave(buscadora);

            Categoria categoriaFinal = usuario.GetCategoriaClave(buscadora);

            bool igualSitio = resultado.Sitio == clave2.Sitio;
            bool igualUsuario = resultado.UsuarioClave == clave2.UsuarioClave;
            bool igualNota = resultado.Nota == clave2.Nota;
            bool igualClave = resultado.Codigo == clave2.Codigo;

            bool igualesDatos = igualSitio && igualUsuario && igualNota && igualClave;
            bool igualCategoria = categoria2 == categoriaFinal;

            Assert.IsTrue(igualesDatos && igualCategoria);
        }

        [TestMethod]
        public void UsuarioGetListaClavesUnaCategoria()
        {
            usuario.AgregarCategoria(categoria1);
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);

            List<Clave> claves = new List<Clave>
            {
                clave1,
                clave2
            };

            List<Clave> getListaClaves = usuario.GetListaClaves();

            bool getListaClavesContieneLasClaves = getListaClaves.All(claves.Contains);
            bool lasClavesContieneGetListaClaves = claves.All(getListaClaves.Contains);

            Assert.IsTrue(getListaClavesContieneLasClaves && lasClavesContieneGetListaClaves);
        }

        [TestMethod]
        public void UsuarioGetListaClavesDosCategorias()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);
            categoria2.AgregarClave(clave3);
            categoria2.AgregarClave(clave4);

            List<Clave> claves = new List<Clave>
            {
                clave1,
                clave2,
                clave3,
                clave4
            };

            List<Clave> getListaClaves = usuario.GetListaClaves();

            bool getListaClavesContieneLasClaves = getListaClaves.All(claves.Contains);
            bool lasClavesContieneGetListaClaves = claves.All(getListaClaves.Contains);

            Assert.IsTrue(getListaClavesContieneLasClaves && lasClavesContieneGetListaClaves);
        }

        [TestMethod]
        public void UsuarioGetCantidadColorRojo()
        {
            usuario.AgregarCategoria(categoria1);
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);


            List<Clave> getListaClaves = usuario.GetListaClaves();
            int cantidadRojas = 0;
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            foreach (Clave clave in getListaClaves)
            {
                if (clave.GetNivelSeguridad() == color.Rojo) cantidadRojas ++;
            }

            Assert.AreEqual(cantidadRojas, usuario.GetCantidadColor(color.Rojo));
        }

        [TestMethod]
        public void UsuarioGetCantidadColor()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);


            List<Clave> getListaClaves = usuario.GetListaClaves();
            ColorNivelSeguridad colores = new ColorNivelSeguridad();
            string color = colores.VerdeClaro;
            int cantidadColor = 0;
            foreach (Clave clave in getListaClaves)
            {
                if (clave.GetNivelSeguridad() == color) cantidadColor++;
            }

            Assert.AreEqual(cantidadColor, usuario.GetCantidadColor(color));
        }

        [TestMethod]
        public void UsuarioCompartirUnaClave_ConfirmarClavesIguales()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Clave, clave1);
        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveYaCompartida()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario1.CompartirClave(claveACompartir));
        }


        [TestMethod]
        public void UsuarioCompartirUnaClave_ConfirmarUsuariosIguales()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Usuario, usuario1);
        }

        [TestMethod]
        public void UsuarioCompartirDosClaves()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(clave1, categoria1);
            usuario1.AgregarClave(clave2, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveCompartir2 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            usuario1.CompartirClave(claveACompartir1);

            usuario1.CompartirClave(claveCompartir2);

            ClaveCompartida claveCompartidaAUsuario2_1 = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave1
            };

            ClaveCompartida claveCompartidaAUsuario2_2 = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave2
            };

            Assert.IsTrue(usuario2.CompartidasConmigo.Contains(claveCompartidaAUsuario2_1) && usuario2.CompartidasConmigo.Contains(claveCompartidaAUsuario2_2));
        }

        [TestMethod]
        public void UsuarioCompartirClaveInexistente()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario1.CompartirClave(claveACompartir1));

        }

        [TestMethod]
        public void UsuarioCompartirClaveEsCompartida()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario1.AgregarClave(clave1, categoria1);

            Assert.IsFalse(clave1.EsCompartida);

        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveEsCompartida()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveCompartida);

            Assert.IsTrue(clave1.EsCompartida);
        }
        
        [TestMethod]
        public void UsuarioCompartirDosClaves_listaClavesQueComparto()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(clave1, categoria1);
            usuario1.AgregarClave(clave2, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveCompartir2 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            usuario1.CompartirClave(claveACompartir1);

            usuario1.CompartirClave(claveCompartir2);

            Assert.IsTrue(usuario1.CompartidasPorMi.Contains(claveACompartir1) && usuario1.CompartidasPorMi.Contains(claveACompartir1));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveQueNoComparto()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            Clave claveNoCompartida = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(claveNoCompartida, categoria1);
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir1);

            ClaveCompartida claveQueNoComparto = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = claveNoCompartida
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario1.DejarDeCompartir(claveQueNoComparto));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaQueComparto()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            Clave claveNoCompartida = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(claveNoCompartida, categoria1);
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir1);

            usuario1.DejarDeCompartir(claveACompartir1);

            Assert.IsFalse(usuario1.CompartidasPorMi.Contains(claveACompartir1));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaDeQuienComparto()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            Clave claveNoCompartida = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(claveNoCompartida, categoria1);
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir1);

            ClaveCompartida claveQueCompartieron = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave1
            };

            usuario1.DejarDeCompartir(claveACompartir1);

            Assert.IsFalse(usuario2.CompartidasConmigo.Contains(claveQueCompartieron));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAUnUsuarioAQuienNoLeComparto()
        {

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Usuario usuario3 = new Usuario()
            {
                Nombre = "Usuario3"
            };
            usuario3.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir1);

            ClaveCompartida claveQueNoComparto = new ClaveCompartida()
            {
                Usuario = usuario3,
                Clave = clave1
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario1.DejarDeCompartir(claveQueNoComparto));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaAFalse()
        {

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir1);

            usuario1.DejarDeCompartir(claveACompartir1);

            Assert.IsFalse(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaATrue()
        {

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Usuario usuario3 = new Usuario()
            {
                Nombre = "Usuario3"
            };
            usuario3.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveACompartir2 = new ClaveCompartida()
            {
                Usuario = usuario3,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir1);

            usuario1.CompartirClave(claveACompartir2);

            usuario1.DejarDeCompartir(claveACompartir1);

            Assert.IsTrue(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAlBorrarLaClave()
        {

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };
            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };
            usuario2.AgregarCategoria(categoria1);

            Usuario usuario3 = new Usuario()
            {
                Nombre = "Usuario3"
            };
            usuario3.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveACompartir2 = new ClaveCompartida()
            {
                Usuario = usuario3,
                Clave = clave1
            };

            usuario1.CompartirClave(claveACompartir1);

            usuario1.CompartirClave(claveACompartir2);

            ClaveCompartida claveQueCompartieron = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave1
            };

            usuario1.BorrarClave(clave1);

            Assert.IsFalse(usuario2.CompartidasConmigo.Contains(claveQueCompartieron) || usuario3.CompartidasConmigo.Contains(claveQueCompartieron));
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorEsVacia()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            int cantidadRojas = 0;
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            Assert.AreEqual(cantidadRojas, usuario.GetListaClavesColor(color.Rojo).Count);
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorNoVaciaUnaCategoria()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria1);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave12@",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "clave",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            List<Clave> clavesVerdes = new List<Clave>
            {
                clave1
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<Clave> getListaClavesVerdes = usuario.GetListaClavesColor(color.VerdeOscuro);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesVerdes.All(clavesVerdes.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesVerdes.All(getListaClavesVerdes.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorNoVaciaDosCategoria()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria1);

            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarCategoria(categoria2);

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "estaesunaclave",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "ESTAESUNACLAVE",
                UsuarioClave = "Luis88"
            };
            categoria2.AgregarClave(clave2);

            List<Clave> clavesAmarillas = new List<Clave>
            {
                clave1,
                clave2
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<Clave> getListaClavesAmarillas = usuario.GetListaClavesColor(color.Amarillo);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesAmarillas.All(clavesAmarillas.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesAmarillas.All(getListaClavesAmarillas.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }

        [TestMethod]
        public void UsuarioGetCategoriaClaveSinClaves()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarCategoria(categoria1);


            Clave buscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "estaesunaclave",
                UsuarioClave = "Roberto"
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetCategoriaClave(buscadora));
        }

        [TestMethod]
        public void UsuarioGetCategoriaClaveDosCategorias()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria trabajo = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarCategoria(trabajo);

            Categoria facultad = new Categoria()
            {
                Nombre = "Facultad"
            };

            usuario.AgregarCategoria(facultad);

            Clave agregar = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "estaesunaclave",
                UsuarioClave = "Roberto"

            };

            usuario.AgregarClave(agregar, facultad);

            Clave buscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "estaesunaclave",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(facultad, usuario.GetCategoriaClave(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorMiCorrecta()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveCompartida);

            Assert.AreEqual(claveCompartida, usuario1.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorMiInexistente()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(clave1, categoria1);
            usuario1.AgregarClave(clave2, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            usuario1.CompartirClave(claveCompartida);


            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario1.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorDosCompartidasConParametrosDiferentes()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2",
                ClaveMaestra = "123456789"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(clave1, categoria1);
            usuario1.AgregarClave(clave2, categoria1);

            ClaveCompartida claveCompartida1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveCompartida2 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            usuario1.CompartirClave(claveCompartida1);
            usuario1.CompartirClave(claveCompartida2);

            Usuario usuarioBuscador = new Usuario
            {
                Nombre = "Usuario2",
                ClaveMaestra = "ClaveDiferente"
            };

            Clave claveBuscadora = new Clave
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaDiferente",
                UsuarioClave = "Hernesto"
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuarioBuscador,
                Clave = claveBuscadora
            };

            Assert.AreEqual(claveCompartida2, usuario1.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCorrecta()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario1.AgregarClave(clave1, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave1
            };

            usuario1.CompartirClave(claveCompartida);

            Assert.AreEqual(buscadora, usuario2.GetClaveCompartidaConmigo(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoInexistente()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2"
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(clave1, categoria1);
            usuario1.AgregarClave(clave2, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave2
            };

            usuario1.CompartirClave(claveCompartida);


            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario2.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCompartidasConParametrosDiferentes()
        {
            Usuario usuario1 = new Usuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "123456789"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario1.AgregarCategoria(categoria1);

            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario2",
            };

            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            Clave clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Hernesto"
            };

            usuario1.AgregarClave(clave1, categoria1);
            usuario1.AgregarClave(clave2, categoria1);

            ClaveCompartida claveCompartida1 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveCompartida2 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            usuario1.CompartirClave(claveCompartida1);
            usuario1.CompartirClave(claveCompartida2);

            Usuario usuarioBuscador = new Usuario
            {
                Nombre = "Usuario1",
                ClaveMaestra = "ClaveDiferente"
            };

            Clave claveBuscadora = new Clave
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaDiferente",
                UsuarioClave = "Hernesto"
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuarioBuscador,
                Clave = claveBuscadora
            };

            Assert.AreEqual(buscadora, usuario2.GetClaveCompartidaConmigo(buscadora));
        }

    }

    [TestClass]
    public class TestUsuarioTarjeta
    {
        [TestMethod]
        public void UsuarioYaExisteTarjetaUnaCategoriaSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            usuario.AgregarCategoria(categoria);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNumero()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            usuario.AgregarCategoria(categoria);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1234567812345678",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(false, usuario.YaExisteTarjeta(tarjetaDistintoNumero));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNombre()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            usuario.AgregarCategoria(categoria);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoNombre));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoTipo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            usuario.AgregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard Gold",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoCodigo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            usuario.AgregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDiferenteVencimiento()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            usuario.AgregarCategoria(categoria);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "123",
                Vencimiento = new DateTime(2026, 9, 2)
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDosCategoriasSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta);
            usuario.AgregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Visa Gold",
                Numero = "7894561234567895",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta2);
            usuario.AgregarCategoria(categoria2);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = "Visa Gold",
                Numero = "7894561234567895",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void UsuarioAgregarTarjeta()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarCategoria(categoria);



            usuario.AgregarTarjeta(tarjeta, categoria);
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjeta));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinCategoria()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.AgregarTarjeta(tarjeta, categoria));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinNombre()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinTipo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinNumero()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinCodigo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarCategoria(categoria);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaRepetida()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarCategoria(categoria);
            usuario.AgregarTarjeta(tarjeta, categoria);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.AgregarTarjeta(tarjeta, categoria));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaCategoriaConTarjeta()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarCategoria(categoria);
            usuario.AgregarTarjeta(tarjeta, categoria);


            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual(true, usuario.GetCategoria(buscadora).YaExisteTarjeta(tarjeta));
        }

        [TestMethod]
        public void UsuarioGetTarjetaCorrecta()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };

            string numeroTarjeta = "3456567890876543";
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria);

            Tarjeta buscadora = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Assert.AreEqual(tarjeta1, usuario.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void UsuarioGetTarjetaInexistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };

            string numeroTarjeta = "3456567890876543";
            Tarjeta buscadora = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void UsuarioGetTarjetaATravesDeClaveSinCodigo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };

            string numeroTarjeta = "3456567890876543";
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            categoria.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria);

            Tarjeta buscadora = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Assert.AreEqual(tarjeta1.Codigo, usuario.GetTarjeta(buscadora).Codigo);
        }


        [TestMethod]
        public void UsuarioBorrarTarjetaSinCategorias()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };


            string numeroTarjeta = "3456567890876543";

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.BorrarTarjeta(aBorrar));
        }


        [TestMethod]
        public void UsuarioBorrarTarjetaSinTarjetas()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarCategoria(categoria);

            string numeroTarjeta = "3456567890876543";

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.BorrarTarjeta(aBorrar));
        }


        [TestMethod]
        public void UsuarioYaExisteTarjetaBorrada()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarCategoria(categoria);

            string numeroTarjeta = "3456567890876543";

            Tarjeta aAgregar = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)

            };

            Categoria buscadora = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarTarjeta(aAgregar, buscadora);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };

            usuario.BorrarTarjeta(aBorrar);
            Assert.IsFalse(usuario.YaExisteTarjeta(aBorrar));
        }


        [TestMethod]
        public void UsuarioBorrarTarjetaYaExisteTarjetaRestante()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarCategoria(categoria);

            string numeroTarjeta = "3456567890876543";

            Tarjeta aBorrar = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)

            };

            Tarjeta aDejar = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "1111111111111111",
                Codigo = "111",
                Vencimiento = new DateTime(2025, 7, 1)

            };

            Categoria buscadora = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarTarjeta(aBorrar, buscadora);
            usuario.AgregarTarjeta(aDejar, buscadora);

            Tarjeta buscadoraBorrar = new Tarjeta()
            {
                Numero = numeroTarjeta
            };
            usuario.BorrarTarjeta(buscadoraBorrar);
            Assert.IsTrue(usuario.YaExisteTarjeta(aDejar));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaNoExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ClaveMaestra = "clave123"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.AgregarCategoria(categoria);

            string numeroTarjeta = "1111111111111111";
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarTarjeta(tarjeta1, categoria);


            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Numero = "2222222222222222"
            };
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Numero = "3333333333333333"
            };

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjetaVieja,
                TarjetaNueva = tarjetaNueva,
                CategoriaVieja = categoria,
                CategoriaNueva = categoria

            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.ModificarTarjeta(parametros));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaTarjetaYaExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);

            string numeroTarjeta1 = "3456567890876543";
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = numeroTarjeta1,
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarTarjeta(tarjeta1, categoria);

            string numeroTarjeta2 = "1234567890876532";
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Numero = numeroTarjeta2,
                Codigo = "456",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarTarjeta(tarjeta2, categoria);


            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Numero = numeroTarjeta1
            };
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Numero = numeroTarjeta2
            };

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjetaVieja,
                TarjetaNueva = tarjetaNueva,
                CategoriaVieja = categoria,
                CategoriaNueva = categoria

            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarTarjeta(parametros));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaTodosLosDatos()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);

            string numeroTarjetaVieja = "3456567890876543";
            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Numero = numeroTarjetaVieja,
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarTarjeta(tarjetaVieja, categoria);

            string numeroTarjetaNueva = "1234098765433456";
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Numero = numeroTarjetaNueva,
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "456",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };


            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjetaVieja,
                TarjetaNueva = tarjetaNueva,
                CategoriaVieja = categoria,
                CategoriaNueva = categoria

            };

            usuario.ModificarTarjeta(parametros);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaNueva
            };

            Tarjeta resultado = usuario.GetTarjeta(buscadora);

            bool igualNumero = tarjetaNueva.Numero == resultado.Numero;
            bool igualNombre = tarjetaNueva.Nombre == resultado.Nombre;
            bool igualTipo = tarjetaNueva.Tipo == resultado.Tipo;
            bool igualCodigo = tarjetaNueva.Codigo == resultado.Codigo;
            bool igualNota = tarjetaNueva.Nota == resultado.Nota;
            bool igualVencimiento = tarjetaNueva.Vencimiento == resultado.Vencimiento;

            Assert.IsTrue(igualNumero&&igualNombre&&igualTipo&&igualCodigo&&igualNota&&igualVencimiento);
        }

        [TestMethod]
        public void UsuarioModificarTarjetaMoverACategoriaNoExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);

            string numeroTarjeta = "3456567890876543";
            Tarjeta aMover= new Tarjeta()
            {
                Numero = numeroTarjeta,
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarTarjeta(aMover, categoria);

            Categoria noAgregada = new Categoria()
            {
                Nombre = "NoAgregada"

            };

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = aMover,
                TarjetaNueva = aMover,
                CategoriaVieja = categoria,
                CategoriaNueva = noAgregada
            };

            Assert.ThrowsException<CategoriaInexistenteException>(()=> usuario.ModificarTarjeta(parametros));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaMoverACategoriaExistente()
        {
            Usuario usuario = new Usuario();
            Categoria personal = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(personal);

            Categoria trabajo = new Categoria()
            {
                Nombre = "Trabajo"

            };
            usuario.AgregarCategoria(trabajo);
            
            Tarjeta vieja = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "111",
                Nota = "AAAAA",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarTarjeta(vieja, personal);

            string numeroTarjetaNueva = "2222222222222222";

            Tarjeta nueva = new Tarjeta()
            {
                Numero = numeroTarjetaNueva,
                Nombre = "Otro",
                Tipo = "Visa",
                Codigo = "222",
                Nota = "BBBB",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = vieja,
                TarjetaNueva = nueva,
                CategoriaVieja = personal,
                CategoriaNueva = trabajo
            };

            usuario.ModificarTarjeta(parametros);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaNueva
            };

            Tarjeta resultado = usuario.GetTarjeta(buscadora);

            Categoria categoriaFinal = usuario.GetCategoriaTarjeta(buscadora);

            bool igualNumero = nueva.Numero == resultado.Numero;
            bool igualNombre = nueva.Nombre == resultado.Nombre;
            bool igualTipo = nueva.Tipo == resultado.Tipo;
            bool igualCodigo = nueva.Codigo == resultado.Codigo;
            bool igualNota = nueva.Nota == resultado.Nota;
            bool igualVencimiento = nueva.Vencimiento == resultado.Vencimiento;
            

            bool igualesDatos = igualNumero && igualNombre && igualTipo && igualCodigo && igualNota && igualVencimiento;
            bool igualCategoria = trabajo == categoriaFinal;

            Assert.IsTrue(igualesDatos && igualCategoria);
        }

        [TestMethod]
        public void UsuarioGetListaTarjetasVacia()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };
            int cantidadTarjetas = usuario.GetListaTarjetas().Count();

            Assert.IsTrue(cantidadTarjetas == 0);
        }

        [TestMethod]
        public void UsuarioGetListaTarjetasEsIgualConUnaCategoria()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarCategoria(categoria1);

            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1234123412341234",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Numero = "1234567890876543",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            categoria1.AgregarTarjeta(tarjeta2);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            bool tarjetasContieneGetTarjetas = usuario.GetListaTarjetas().All(tarjetas.Contains);
            bool getTarjetasContieneTarjetas = tarjetas.All(usuario.GetListaTarjetas().Contains);
           
            Assert.IsTrue(tarjetasContieneGetTarjetas && getTarjetasContieneTarjetas); 
        }

        [TestMethod]
        public void UsuarioGetListaTarjetasEsIgualConDosCategorias()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarCategoria(categoria1);

            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria2);

            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1234123412341234",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            categoria1.AgregarTarjeta(tarjeta1);

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Numero = "1234567890876543",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            categoria2.AgregarTarjeta(tarjeta2);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            bool tarjetasContieneGetTarjetas = usuario.GetListaTarjetas().All(tarjetas.Contains);
            bool getTarjetasContieneTarjetas = tarjetas.All(usuario.GetListaTarjetas().Contains);
            Assert.IsTrue(tarjetasContieneGetTarjetas && getTarjetasContieneTarjetas);
        }

        [TestMethod]
        public void UsuarioGetCategoriaTarjetaSinTarjetas()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarCategoria(categoria1);

           
            Tarjeta buscadora = new Tarjeta()
            {
                Numero = "2222222222222222",
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetCategoriaTarjeta(buscadora));
        }

        [TestMethod]
        public void UsuarioGetCategoriaTarjetaDosCategorias()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria trabajo = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarCategoria(trabajo);

            Categoria facultad = new Categoria()
            {
                Nombre = "Facultad"
            };

            usuario.AgregarCategoria(facultad);

            Tarjeta agregar = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "222",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };

            usuario.AgregarTarjeta(agregar, trabajo);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = "2222222222222222",
            };

            Assert.AreEqual(trabajo, usuario.GetCategoriaTarjeta(buscadora));
        }

        
    }

}
