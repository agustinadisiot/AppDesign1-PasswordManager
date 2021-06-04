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
                Nombre = categoria1.Nombre
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
                Nombre = categoria1.Nombre
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
                Nombre = categoria2.Nombre
            };

            Assert.AreEqual(categoria2, usuario.GetCategoria(buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaYaExistente()
        {
            usuario.AgregarCategoria(categoria1);
            Categoria categoria2 = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.AgregarCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaSiExistente()
        {
            usuario.AgregarCategoria(categoria1);
            Categoria categoria2 = new Categoria()
            {
                Nombre = categoria1.Nombre
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
                Nombre = usuario.Nombre
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
        private Usuario usuario2;
        private Usuario usuario3;
        private Categoria categoria1;
        private Categoria categoria2;
        private Clave clave1;
        private Clave clave2;
        private Clave clave3;
        private Clave clave4;
        private ClaveCompartida claveCompartida;
        private ClaveCompartida claveCompartida2;
        private ClaveCompartida claveCompartida3;

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

            usuario2 = new Usuario()
            {
                Nombre = "Usuario2",
                ClaveMaestra = "Chau12345"
            };

            usuario3 = new Usuario()
            {
                Nombre = "Usuario3"
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
                Sitio = "Netflix.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = "Nota de una clave"
            };

            clave3 = new Clave()
            {
                Sitio = "youtube.com",
                Codigo = "codrojo",
                UsuarioClave = "Hernesto"
            };

            clave4 = new Clave()
            {
                Sitio = "www.hbo.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };

            claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            claveCompartida2 = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            claveCompartida3 = new ClaveCompartida()
            {
                Usuario = usuario3,
                Clave = clave1
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
            categoria1.AgregarClave(clave3);

            List<Clave> getListaClaves = usuario.GetListaClaves();
            int cantidadRojas = 0;
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            foreach (Clave clave in getListaClaves)
            {
                if (nivelSeguridad.GetNivelSeguridad(clave.Codigo).Equals(color.Rojo)) cantidadRojas ++;
            }

            Assert.AreEqual(cantidadRojas, usuario.GetCantidadColor(color.Rojo));
        }

        [TestMethod]
        public void UsuarioGetCantidadColor()
        {
            usuario.AgregarCategoria(categoria1);
            categoria1.AgregarClave(clave1);
            categoria1.AgregarClave(clave2);


            List<Clave> getListaClaves = usuario.GetListaClaves();
            ColorNivelSeguridad colores = new ColorNivelSeguridad();
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            string color = colores.VerdeClaro;
            int cantidadColor = 0;
            foreach (Clave clave in getListaClaves)
            {
                if (nivelSeguridad.GetNivelSeguridad(clave.Codigo) == color) cantidadColor++;
            }

            Assert.AreEqual(cantidadColor, usuario.GetCantidadColor(color));
        }

        [TestMethod]
        public void UsuarioCompartirUnaClave_ConfirmarClavesIguales()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Clave, clave1);
        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveYaCompartida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.CompartirClave(claveCompartida));
        }

        [TestMethod]
        public void UsuarioCompartirUnaClave_ConfirmarUsuariosIguales()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Usuario, usuario);
        }

        [TestMethod]
        public void UsuarioCompartirDosClaves()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida2);

            ClaveCompartida claveCompartidaAUsuario2_1 = new ClaveCompartida()
            {
                Usuario = usuario,
                Clave = clave1
            };

            ClaveCompartida claveCompartidaAUsuario2_2 = new ClaveCompartida()
            {
                Usuario = usuario,
                Clave = clave2
            };

            Assert.IsTrue(usuario2.CompartidasConmigo.Contains(claveCompartidaAUsuario2_1) && usuario2.CompartidasConmigo.Contains(claveCompartidaAUsuario2_2));
        }

        [TestMethod]
        public void UsuarioCompartirClaveInexistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.CompartirClave(claveCompartida));

        }

        [TestMethod]
        public void UsuarioCompartirClaveEsCompartida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            Assert.IsFalse(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioCompartirUnaClaveEsCompartida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            Assert.IsTrue(clave1.EsCompartida);
        }
        
        [TestMethod]
        public void UsuarioCompartirDosClaves_listaClavesQueComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida2);

            Assert.IsTrue(usuario.CompartidasPorMi.Contains(claveCompartida) && usuario.CompartidasPorMi.Contains(claveCompartida2));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveQueNoComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.DejarDeCompartir(claveCompartida2));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaQueComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsFalse(usuario.CompartidasPorMi.Contains(claveCompartida));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_EliminaDeListaDeQuienComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave2, categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            ClaveCompartida claveQueCompartieron = new ClaveCompartida()
            {
                Usuario = usuario,
                Clave = clave1
            };

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsFalse(usuario2.CompartidasConmigo.Contains(claveQueCompartieron));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAUnUsuarioAQuienNoLeComparto()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario3.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.DejarDeCompartir(claveCompartida3));
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaAFalse()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.CompartirClave(claveCompartida);

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsFalse(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClave_CambiarClaveEsCompartidaATrue()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario3.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida3);

            usuario.DejarDeCompartir(claveCompartida);

            Assert.IsTrue(clave1.EsCompartida);
        }

        [TestMethod]
        public void UsuarioDejarDeCompartirUnaClaveAlBorrarLaClave()
        {
            usuario.AgregarCategoria(categoria1);
            usuario2.AgregarCategoria(categoria1);
            usuario3.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            usuario.CompartirClave(claveCompartida);

            usuario.CompartirClave(claveCompartida3);

            usuario.BorrarClave(clave1);

            Assert.IsFalse(usuario2.CompartidasConmigo.Contains(claveCompartida) || usuario3.CompartidasConmigo.Contains(claveCompartida));
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorEsVacia()
        {
            int cantidadRojas = 0;
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            Assert.AreEqual(cantidadRojas, usuario.GetListaClavesColor(color.Rojo).Count);
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorNoVaciaUnaCategoria()
        {
            usuario.AgregarCategoria(categoria1);
            clave1.Codigo = "EstaEsUnaClave12@";
            categoria1.AgregarClave(clave1);
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
            usuario.AgregarCategoria(categoria1);
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
            usuario.AgregarCategoria(categoria1);

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetCategoriaClave(clave1));
        }

        [TestMethod]
        public void UsuarioGetCategoriaClaveDosCategorias()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);
            usuario.AgregarClave(clave1, categoria2);

            Clave buscadora = new Clave()
            {
                Sitio = clave1.Sitio,
                Codigo = clave1.Codigo,
                UsuarioClave = clave1.UsuarioClave
            };

            Assert.AreEqual(categoria2, usuario.GetCategoriaClave(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorMiCorrecta()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(claveCompartida, usuario.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorMiInexistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);
            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave2
            };

            usuario.CompartirClave(claveCompartida);


            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaPorDosCompartidasConParametrosDiferentes()
        {
            usuario.AgregarCategoria(categoria1);

            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            usuario.CompartirClave(claveCompartida);
            usuario.CompartirClave(claveCompartida2);

            Usuario usuarioBuscador = new Usuario
            {
                Nombre = "Usuario2",
                ClaveMaestra = "ClaveDiferente"
            };

            Clave claveBuscadora = new Clave
            {
                Sitio = clave2.Sitio,
                Codigo = "EstaEsUnaDiferente",
                UsuarioClave = clave2.UsuarioClave
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuarioBuscador,
                Clave = claveBuscadora
            };

            Assert.AreEqual(claveCompartida2, usuario.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCorrecta()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario,
                Clave = clave1
            };

            usuario.CompartirClave(claveCompartida);

            Assert.AreEqual(buscadora, usuario2.GetClaveCompartidaConmigo(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoInexistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuario,
                Clave = clave2
            };

            usuario.CompartirClave(claveCompartida);

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario2.GetClaveCompartidaPorMi(buscadora));
        }

        [TestMethod]
        public void UsuarioGetClaveCompartidaConmigoCompartidasConParametrosDiferentes()
        {
            usuario.AgregarCategoria(categoria1);

            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            usuario.CompartirClave(claveCompartida);
            usuario.CompartirClave(claveCompartida2);

            Usuario usuarioBuscador = new Usuario
            {
                Nombre = "Usuario1",
                ClaveMaestra = "ClaveDiferente"
            };

            Clave claveBuscadora = new Clave
            {
                Sitio = clave2.Sitio,
                Codigo = "EstaEsUnaDiferente",
                UsuarioClave = clave2.UsuarioClave
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Usuario = usuarioBuscador,
                Clave = claveBuscadora
            };

            Assert.AreEqual(buscadora, usuario2.GetClaveCompartidaConmigo(buscadora));
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaNoRepetida()
        {
            usuario.AgregarCategoria(categoria1);
            string aVerificar = "ClaveNoRepetida";

            usuario.AgregarClave(clave1, categoria1);

            Assert.AreEqual(false, usuario.EsClaveRepetida(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaSiRepetida()
        {
            usuario.AgregarCategoria(categoria1);
            string aVerificar = clave1.Codigo;

            usuario.AgregarClave(clave1, categoria1);

            Assert.AreEqual(true, usuario.EsClaveRepetida(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveRepetidaVariasClavesDiferentesCategoriasSiRepetida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            string aVerificar = clave2.Codigo;

            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria2);

            Assert.AreEqual(true, usuario.EsClaveRepetida(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveSeguraSeguraVerdeClaro()
        {
            string aVerificar = "ClaveVerdeClaro";

            Assert.AreEqual(true, usuario.EsClaveSegura(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveSeguraNoSegura()
        {
            string aVerificar = "clavenosegura";

            Assert.AreEqual(false, usuario.EsClaveSegura(aVerificar));
        }

        [TestMethod]
        public void UsuarioEsClaveSeguraSeguraVerdeOscuro()
        {
            string aVerificar = "claveVerdeOscuroN14@";

            Assert.AreEqual(true, usuario.EsClaveSegura(aVerificar));
        }

        [TestMethod]
        public void UsuarioClaveCumpleRequerimientosNoCumplePorClaveDuplicada()
        {
            usuario.AgregarCategoria(categoria1);

            string aVerificar = "EstaEsUnaClave1";

            usuario.AgregarClave(clave1, categoria1);

            Assert.ThrowsException<ClaveDuplicadaException>(() => usuario.ClaveCumpleRequerimientos(aVerificar));
        }
        [TestMethod]
        public void UsuarioClaveCumpleRequerimientosNoCumplePorNivelSeguridad()
        {
            usuario.AgregarCategoria(categoria1);

            string aVerificar = "clavenosegura";

            usuario.AgregarClave(clave1, categoria1);

            Assert.ThrowsException<ClaveNoSeguraException>(() => usuario.ClaveCumpleRequerimientos(aVerificar));
        }
    }

    [TestClass]
    public class TestUsuarioTarjeta
    {
        private Usuario usuario;
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
        public void UsuarioYaExisteTarjetaUnaCategoriaSiExistente()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);
            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNumero()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);
            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento,
                Numero = "1234567812345678"
            };
            Assert.AreEqual(false, usuario.YaExisteTarjeta(tarjetaDistintoNumero));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNombre()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);
            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoNombre));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoTipo()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento,
                Tipo = "Mastercard Gold"
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoCodigo()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Vencimiento = tarjeta1.Vencimiento,
                Codigo = "123"
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDiferenteVencimiento()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = new DateTime(2026, 9, 2)
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaDistintoTipo));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDosCategoriasSiExistente()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);
            categoria1.AgregarTarjeta(tarjeta2);
            usuario.AgregarCategoria(categoria2);

            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = tarjeta2.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta2.Numero,
                Codigo = tarjeta2.Codigo,
                Vencimiento = tarjeta2.Vencimiento
            };
            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjetaIgual));
        }

        [TestMethod]
        public void UsuarioAgregarTarjeta()
        {
            usuario.AgregarCategoria(categoria1);

            usuario.AgregarTarjeta(tarjeta1, categoria1);

            Assert.AreEqual(true, usuario.YaExisteTarjeta(tarjeta1));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinCategoria()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.AgregarTarjeta(tarjeta1, categoria1));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinNombre()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };
            usuario.AgregarCategoria(categoria1);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria1));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinTipo()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };
            usuario.AgregarCategoria(categoria1);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria1));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinNumero()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };
            usuario.AgregarCategoria(categoria1);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria1));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinCodigo()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Vencimiento = tarjeta1.Vencimiento
            };
            usuario.AgregarCategoria(categoria1);
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarTarjeta(tarjeta, categoria1));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaRepetida()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarTarjeta(tarjeta1, categoria1);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.AgregarTarjeta(tarjeta1, categoria1));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaCategoriaConTarjeta()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarTarjeta(tarjeta1, categoria1);


            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Assert.AreEqual(true, usuario.GetCategoria(buscadora).YaExisteTarjeta(tarjeta1));
        }

        [TestMethod]
        public void UsuarioGetTarjetaCorrecta()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(tarjeta1, usuario.GetTarjeta(buscadora));
        }

        [TestMethod]
        public void UsuarioGetTarjetaInexistente()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetTarjeta(tarjeta1));
        }

        [TestMethod]
        public void UsuarioGetTarjetaATravesDeClaveSinCodigo()
        {
            categoria1.AgregarTarjeta(tarjeta1);
            usuario.AgregarCategoria(categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(tarjeta1.Codigo, usuario.GetTarjeta(buscadora).Codigo);
        }


        [TestMethod]
        public void UsuarioBorrarTarjetaSinCategorias()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.BorrarTarjeta(tarjeta1));
        }


        [TestMethod]
        public void UsuarioBorrarTarjetaSinTarjetas()
        {
            usuario.AgregarCategoria(categoria1);
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.BorrarTarjeta(tarjeta1));
        }


        [TestMethod]
        public void UsuarioYaExisteTarjetaBorrada()
        {
            usuario.AgregarCategoria(categoria1);
            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            usuario.AgregarTarjeta(tarjeta1, buscadora);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            usuario.BorrarTarjeta(aBorrar);

            Assert.IsFalse(usuario.YaExisteTarjeta(aBorrar));
        }

        [TestMethod]
        public void UsuarioBorrarTarjetaYaExisteTarjetaRestante()
        {
            usuario.AgregarCategoria(categoria1);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            usuario.AgregarTarjeta(tarjeta1, buscadora);
            usuario.AgregarTarjeta(tarjeta2, buscadora);

            Tarjeta buscadoraBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };
            usuario.BorrarTarjeta(buscadoraBorrar);
            Assert.IsTrue(usuario.YaExisteTarjeta(tarjeta2));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaNoExistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarTarjeta(tarjeta1, categoria1);


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
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1

            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.ModificarTarjeta(parametros));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaTarjetaYaExistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarTarjeta(tarjeta1, categoria1);
            usuario.AgregarTarjeta(tarjeta2, categoria1);


            Tarjeta tarjetaVieja = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjetaVieja,
                TarjetaNueva = tarjetaNueva,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1

            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarTarjeta(parametros));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaTodosLosDatos()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarTarjeta(tarjeta1, categoria1);

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjeta1,
                TarjetaNueva = tarjeta2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1

            };

            usuario.ModificarTarjeta(parametros);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            Tarjeta resultado = usuario.GetTarjeta(buscadora);

            bool igualNumero = tarjeta2.Numero == resultado.Numero;
            bool igualNombre = tarjeta2.Nombre == resultado.Nombre;
            bool igualTipo = tarjeta2.Tipo == resultado.Tipo;
            bool igualCodigo = tarjeta2.Codigo == resultado.Codigo;
            bool igualNota = tarjeta2.Nota == resultado.Nota;
            bool igualVencimiento = tarjeta2.Vencimiento == resultado.Vencimiento;

            Assert.IsTrue(igualNumero&&igualNombre&&igualTipo&&igualCodigo&&igualNota&&igualVencimiento);
        }

        [TestMethod]
        public void UsuarioModificarTarjetaMoverACategoriaNoExistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarTarjeta(tarjeta1, categoria1);

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjeta1,
                TarjetaNueva = tarjeta1,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            Assert.ThrowsException<CategoriaInexistenteException>(()=> usuario.ModificarTarjeta(parametros));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaMoverACategoriaExistente()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);
            
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "111",
                Nota = "AAAAA",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            usuario.AgregarTarjeta(tarjeta1, categoria1);

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjeta1,
                TarjetaNueva = tarjeta2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            usuario.ModificarTarjeta(parametros);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            Tarjeta resultado = usuario.GetTarjeta(buscadora);

            Categoria categoriaFinal = usuario.GetCategoriaTarjeta(buscadora);

            bool igualNumero = tarjeta2.Numero == resultado.Numero;
            bool igualNombre = tarjeta2.Nombre == resultado.Nombre;
            bool igualTipo = tarjeta2.Tipo == resultado.Tipo;
            bool igualCodigo = tarjeta2.Codigo == resultado.Codigo;
            bool igualNota = tarjeta2.Nota == resultado.Nota;
            bool igualVencimiento = tarjeta2.Vencimiento == resultado.Vencimiento;
            

            bool igualesDatos = igualNumero && igualNombre && igualTipo && igualCodigo && igualNota && igualVencimiento;
            bool igualCategoria = categoria2 == categoriaFinal;

            Assert.IsTrue(igualesDatos && igualCategoria);
        }

        [TestMethod]
        public void UsuarioGetListaTarjetasVacia()
        {
            int cantidadTarjetas = usuario.GetListaTarjetas().Count();

            Assert.IsTrue(cantidadTarjetas == 0);
        }

        [TestMethod]
        public void UsuarioGetListaTarjetasEsIgualConUnaCategoria()
        {
            usuario.AgregarCategoria(categoria1);
            categoria1.AgregarTarjeta(tarjeta1);
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
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);
            categoria1.AgregarTarjeta(tarjeta1);
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
            usuario.AgregarCategoria(categoria1);

           
            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetCategoriaTarjeta(buscadora));
        }

        [TestMethod]
        public void UsuarioGetCategoriaTarjetaDosCategorias()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            usuario.AgregarTarjeta(tarjeta1, categoria1);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.AreEqual(categoria1, usuario.GetCategoriaTarjeta(buscadora));
        }

        
    }

}
