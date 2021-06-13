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
    public class TestUsuario
    {
        private ControladoraUsuario controladora;
        private DataAccessUsuario acceso;

        private Usuario usuario;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            List<Usuario> aBorrar = (List<Usuario>)acceso.GetTodos();
            foreach (Usuario actual in aBorrar) {
                acceso.Borrar(actual);
            }

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
            usuario.Nombre = "A";

            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNombre(usuario));
        }

        [TestMethod]
        public void UsuarioLargoNombreMayorA25()
        {
            usuario.Nombre = "12345678901234567890123456";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNombre(usuario));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestra()
        {
            Usuario igualClave = new Usuario() {
                ClaveMaestra = usuario.ClaveMaestra
            };
            Assert.AreEqual(true, controladora.EsIgualClaveMaestra(usuario, igualClave));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestraDiferente()
        {
            Usuario diferenteClave = new Usuario()
            {
                ClaveMaestra = "Diferente"
            };
            Assert.AreEqual(true, controladora.EsIgualClaveMaestra(usuario, diferenteClave));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestraCambiada()
        {
            Usuario igualClave = new Usuario()
            {
                ClaveMaestra = usuario.ClaveMaestra
            };
            usuario.ClaveMaestra = "Chau109876";
            Assert.AreEqual(true, controladora.EsIgualClaveMaestra(usuario, igualClave));
        }

        [TestMethod]
        public void UsuarioLargoClaveMaestraMenorA5()
        {
            usuario.ClaveMaestra = "A";
            Assert.ThrowsException<LargoIncorrectoException>(() =>controladora.VerificarClaveMaestra(usuario));
        }

        [TestMethod]
        public void UsuarioLargoClaveMaestraMayorA25()
        {
            usuario.ClaveMaestra = "12345678901234567890123456";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarClaveMaestra(usuario));
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
            usuario.Nombre = "usuario1";
            Usuario usuario2 = new Usuario()
            {
                Nombre = "uSUARio1"
            };
            Assert.AreEqual(usuario, usuario2);
        }
    }

    [TestClass]
    public class TestUsuarioCategoria
    {
        private ControladoraUsuario controladora;
        private DataAccessUsuario acceso;
        private DataAccessCategoria accesoCategoria;

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
            List<Usuario> usuariosABorrar = (List<Usuario>)acceso.GetTodos();
            foreach (Usuario actual in usuariosABorrar)
            {
                acceso.Borrar(actual);
            }

            List<Categoria> categoriasABorrar = (List<Categoria>)accesoCategoria.GetTodos();
            foreach (Categoria actual in categoriasABorrar)
            {
                accesoCategoria.Borrar(actual);
            }

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

            Assert.AreEqual(true, controladora.EsListaCategoriasVacia(usuario));
        }

        [TestMethod]
        public void UsuarioEsListaConCategoriasVaciaConUnaCategoria()
        {
            controladora.AgregarCategoria(categoria1,usuario);
            Assert.AreEqual(false, controladora.EsListaCategoriasVacia(usuario));
        }

        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaConDosCategorias()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            controladora.AgregarCategoria(categoria2, usuario);
            Assert.AreEqual(false, controladora.EsListaCategoriasVacia(usuario));
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaVacia()
        {
            Categoria vacia = new Categoria();
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladora.AgregarCategoria(vacia, usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaCorrecta()
        {
            controladora.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Assert.AreEqual(categoria1, controladora.GetCategoria(buscadora,usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaPrimeraConDos()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            controladora.AgregarCategoria(categoria2, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.AreEqual(categoria1, controladora.GetCategoria(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaSegundaConDos()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            controladora.AgregarCategoria(categoria2, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria2.Nombre
            };

            Assert.AreEqual(categoria2, controladora.GetCategoria(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaYaExistente()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            Categoria categoria2 = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            
            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladora.AgregarCategoria(categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaSiExistente()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            Categoria categoria2 = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Assert.AreEqual(true, controladora.YaExisteCategoria(categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaNoExistente()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            Assert.AreEqual(false, controladora.YaExisteCategoria(categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaAgregada()
        {
            controladora.AgregarCategoria(categoria1, usuario);

            Categoria copia = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            categoria2.Nombre = "Trabajo";
            controladora.ModificarNombreCategoria(copia, categoria2, usuario);
            Categoria resultado = controladora.GetCategoria(categoria2, usuario);
            Assert.AreEqual("Trabajo", resultado);
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaNoExistente()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            Categoria categoriaNoAgregada = new Categoria()
            {
                Nombre = "Facultad"
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => controladora.ModificarNombreCategoria(categoriaNoAgregada, categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaANombreExistente()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            controladora.AgregarCategoria(categoria2, usuario);

            Categoria modificarVieja = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Categoria modificarNueva = new Categoria()
            {
                Nombre = categoria2.Nombre
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladora.ModificarNombreCategoria(modificarVieja, modificarNueva, usuario));
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasVacia()
        {
            int cantCategorias = controladora.GetListaCategorias(usuario).Count();

            Assert.IsTrue(cantCategorias == 0);
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasNoVacia()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            Assert.IsNotNull(controladora.GetListaCategorias(usuario));
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasNoVaciaCantidad()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            int cantCategorias = controladora.GetListaCategorias(usuario).Count();
            Assert.IsTrue(cantCategorias>0);
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasEsIgual()
        {
            controladora.AgregarCategoria(categoria1, usuario);
            controladora.AgregarCategoria(categoria2, usuario);

            List<Categoria> categorias = new List<Categoria>
            {
                categoria1,
                categoria2
            };

            List<Categoria> resultado = controladora.GetListaCategorias(usuario);

            Assert.AreEqual(true, categorias.All(resultado.Contains)); ;
        }
    }

    [TestClass]
    public class TestUsuarioClave
    {
        private ControladoraUsuario usuario;
        private ControladoraUsuario usuario2;
        private ControladoraUsuario usuario3;
        private ControladoraCategoria categoria1;
        private ControladoraCategoria categoria2;
        private ControladoraClave clave1;
        private ControladoraClave clave2;
        private ControladoraClave clave3;
        private ControladoraClave clave4;
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
            usuario = new ControladoraUsuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "Hola12345"
            };

            usuario2 = new ControladoraUsuario()
            {
                Nombre = "Usuario2",
                ClaveMaestra = "Chau12345"
            };

            usuario3 = new ControladoraUsuario()
            {
                Nombre = "Usuario3"
            };

            categoria1 = new ControladoraCategoria()
            {
                Nombre = "Personal"
            };

            categoria2 = new ControladoraCategoria()
            {
                Nombre = "Trabajo"
            };

            clave1 = new ControladoraClave()
            {
                VerificarSitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                verificarUsuarioClave = "Roberto",
                VerificarNota = ""
            };

            clave2 = new ControladoraClave()
            {
                VerificarSitio = "Netflix.com",
                Codigo = "EstaEsUnaClave2",
                verificarUsuarioClave = "Luis88",
                VerificarNota = "Nota de una clave"
            };

            clave3 = new ControladoraClave()
            {
                VerificarSitio = "youtube.com",
                Codigo = "codrojo",
                verificarUsuarioClave = "Hernesto"
            };

            clave4 = new ControladoraClave()
            {
                VerificarSitio = "www.hbo.com",
                Codigo = "EstaEsUnaClave4",
                verificarUsuarioClave = "Peepo"
            };

            claveCompartida = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            claveCompartida2 = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
                Clave = clave2
            };

            claveCompartida3 = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario3,
                Clave = clave1
            };
        }

        [TestMethod]
        public void UsuarioYaExisteClaveUnaCategoriaSiExistente()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            ControladoraClave claveIgual = new ControladoraClave()
            {
                VerificarSitio = clave1.VerificarSitio,
                verificarUsuarioClave = clave1.verificarUsuarioClave,
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(true, usuario.YaExisteClave(claveIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveMismoUsuarioDiferenteSitio()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            ControladoraClave claveDiferenteSitio = new ControladoraClave()
            {
                VerificarSitio = "www.youtube.com",
                verificarUsuarioClave = clave1.verificarUsuarioClave,
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(false, usuario.YaExisteClave(claveDiferenteSitio));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveMismoSitioDiferenteUsuario()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            ControladoraClave claveDiferenteUsuario = new ControladoraClave()
            {
                VerificarSitio = clave1.VerificarSitio,
                verificarUsuarioClave = "222222",
                Codigo = clave1.Codigo
            };
            Assert.AreEqual(false, usuario.YaExisteClave(claveDiferenteUsuario));
        }

        [TestMethod]
        public void UsuarioYaExisteClaveDiferentesCodigos()
        {
            categoria1.AgregarClave(clave1);
            usuario.AgregarCategoria(categoria1);
            ControladoraClave claveDiferenteCodigo = new ControladoraClave()
            {
                VerificarSitio = clave1.VerificarSitio,
                verificarUsuarioClave = clave1.verificarUsuarioClave,
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

            ControladoraClave claveIgual = new ControladoraClave()
            {
                VerificarSitio = clave2.VerificarSitio,
                verificarUsuarioClave = clave2.verificarUsuarioClave,
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
            ControladoraClave claveSinSitio = new ControladoraClave()
            {
                verificarUsuarioClave = "111111",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria1);

            ControladoraCategoria buscadora = new ControladoraCategoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarClave(claveSinSitio, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinCodigo()
        {
            ControladoraClave claveSinCodigo = new ControladoraClave()
            {
                VerificarSitio = "www.ort.edu.uy",
                verificarUsuarioClave = "111111"
            };

            usuario.AgregarCategoria(categoria1);

            ControladoraCategoria buscadora = new ControladoraCategoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarClave(claveSinCodigo, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarClaveSinUsuario()
        {
            ControladoraClave claveSinUsuario = new ControladoraClave()
            {
                VerificarSitio = "www.ort.edu.uy",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria1);

            ControladoraCategoria buscadora = new ControladoraCategoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarClave(claveSinUsuario, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarClaveRepetida()
        {
            usuario.AgregarCategoria(categoria1);

            ControladoraCategoria buscadora = new ControladoraCategoria()
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

            ControladoraCategoria buscadora = new ControladoraCategoria()
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

            ControladoraClave aBorrar = new ControladoraClave()
            {
                verificarUsuarioClave = clave1.verificarUsuarioClave,
                VerificarSitio = clave1.VerificarSitio
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

            ControladoraClave aBorrar = new ControladoraClave()
            {
                verificarUsuarioClave = clave1.verificarUsuarioClave,
                VerificarSitio = clave1.VerificarSitio
            };
            usuario.BorrarClave(aBorrar);
            Assert.IsTrue(usuario.YaExisteClave(clave2));
        }

        [TestMethod]
        public void UsuarioGetClaveCorrecta()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            ControladoraClave claveBuscadora = new ControladoraClave()
            {
                VerificarSitio = clave1.VerificarSitio,
                verificarUsuarioClave = clave1.verificarUsuarioClave
            };

            Assert.AreEqual(clave1, usuario.GetClave(claveBuscadora));
        }

        [TestMethod]
        public void UsuarioaGetClavePrimeraConDosClaves()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            ControladoraClave claveBuscadora = new ControladoraClave()
            {
                VerificarSitio = clave1.VerificarSitio,
                verificarUsuarioClave = clave1.verificarUsuarioClave
            };

            Assert.AreEqual(clave1, usuario.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void UsuarioaGetClaveSegundaConDosClaves()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);
            usuario.AgregarClave(clave2, categoria1);

            ControladoraClave claveBuscadora = new ControladoraClave()
            {
                VerificarSitio = clave2.VerificarSitio,
                verificarUsuarioClave = clave2.verificarUsuarioClave
            };

            Assert.AreEqual(clave2, usuario.GetClave(claveBuscadora)); ;
        }

        [TestMethod]
        public void UsuarioaGetClaveATravesDeClaveSinCodigo()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarClave(clave1, categoria1);

            ControladoraClave claveBuscadora = new ControladoraClave()
            {
                VerificarSitio = clave1.VerificarSitio,
                verificarUsuarioClave = clave1.verificarUsuarioClave
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

            ControladoraClave buscadora = new ControladoraClave()
            {
                verificarUsuarioClave = clave1.verificarUsuarioClave,
                VerificarSitio = clave1.VerificarSitio
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

            ControladoraClave duplicada = new ControladoraClave()
            {
                verificarUsuarioClave = clave2.verificarUsuarioClave,
                VerificarSitio = clave2.VerificarSitio,
                Codigo = "33333333",
                VerificarNota = "Otra Nota"
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

            ControladoraClave buscadora = new ControladoraClave()
            {
                verificarUsuarioClave = clave2.verificarUsuarioClave,
                VerificarSitio = clave2.VerificarSitio
            };

            ControladoraClave resultado = usuario.GetClave(buscadora);

            ControladoraCategoria categoriaFinal = usuario.GetCategoriaClave(buscadora);

            bool igualSitio = resultado.VerificarSitio == clave2.VerificarSitio;
            bool igualUsuario = resultado.verificarUsuarioClave == clave2.verificarUsuarioClave;
            bool igualNota = resultado.VerificarNota == clave2.VerificarNota;
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

            List<ControladoraClave> claves = new List<ControladoraClave>
            {
                clave1,
                clave2
            };

            List<ControladoraClave> getListaClaves = usuario.GetListaClaves();

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

            List<ControladoraClave> claves = new List<ControladoraClave>
            {
                clave1,
                clave2,
                clave3,
                clave4
            };

            List<ControladoraClave> getListaClaves = usuario.GetListaClaves();

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

            List<ControladoraClave> getListaClaves = usuario.GetListaClaves();
            int cantidadRojas = 0;
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            ColorNivelSeguridad color = new ColorNivelSeguridad();
            foreach (ControladoraClave clave in getListaClaves)
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


            List<ControladoraClave> getListaClaves = usuario.GetListaClaves();
            ColorNivelSeguridad colores = new ColorNivelSeguridad();
            NivelSeguridad nivelSeguridad = new NivelSeguridad();
            string color = colores.VerdeClaro;
            int cantidadColor = 0;
            foreach (ControladoraClave clave in getListaClaves)
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

            Assert.AreEqual(usuario2.CompartidasConmigo[0].Original, usuario);
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
                Original = usuario,
                Destino = usuario2,
                Clave = clave1
            };

            ClaveCompartida claveCompartidaAUsuario2_2 = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuario2,
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
                Original = usuario,
                Destino = usuario2,
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

            List<ControladoraClave> clavesVerdes = new List<ControladoraClave>
            {
                clave1
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<ControladoraClave> getListaClavesVerdes = usuario.GetListaClavesColor(color.VerdeOscuro);

            bool getListaClavesContieneLasClavesVerdes = getListaClavesVerdes.All(clavesVerdes.Contains);
            bool clavesVerdesContieneListaClavesVerdes = clavesVerdes.All(getListaClavesVerdes.Contains);

            Assert.IsTrue(getListaClavesContieneLasClavesVerdes && clavesVerdesContieneListaClavesVerdes);
        }

        [TestMethod]
        public void UsuarioGetListaClavesColorNoVaciaDosCategoria()
        {
            usuario.AgregarCategoria(categoria1);
            usuario.AgregarCategoria(categoria2);

            ControladoraClave clave1 = new ControladoraClave()
            {
                VerificarSitio = "web.whatsapp.com",
                Codigo = "estaesunaclave",
                verificarUsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);

            ControladoraClave clave2 = new ControladoraClave()
            {
                VerificarSitio = "web.whatsapp.com",
                Codigo = "ESTAESUNACLAVE",
                verificarUsuarioClave = "Luis88"
            };
            categoria2.AgregarClave(clave2);

            List<ControladoraClave> clavesAmarillas = new List<ControladoraClave>
            {
                clave1,
                clave2
            };

            ColorNivelSeguridad color = new ColorNivelSeguridad();
            List<ControladoraClave> getListaClavesAmarillas = usuario.GetListaClavesColor(color.Amarillo);

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

            ControladoraClave buscadora = new ControladoraClave()
            {
                VerificarSitio = clave1.VerificarSitio,
                Codigo = clave1.Codigo,
                verificarUsuarioClave = clave1.verificarUsuarioClave
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
                Original = usuario,
                Destino = usuario2,
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
                Original = usuario,
                Destino = usuario2,
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

            ControladoraUsuario usuarioBuscador = new ControladoraUsuario
            {
                Nombre = "Usuario2",
                ClaveMaestra = "ClaveDiferente"
            };

            ControladoraClave claveBuscadora = new ControladoraClave
            {
                VerificarSitio = clave2.VerificarSitio,
                Codigo = "EstaEsUnaDiferente",
                verificarUsuarioClave = clave2.verificarUsuarioClave
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Original = usuario,
                Destino = usuarioBuscador,
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
                Original = usuario,
                Destino = usuario2,
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
                Original = usuario,
                Destino = usuario2,
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

            ControladoraUsuario usuarioBuscador = new ControladoraUsuario
            {
                Nombre = usuario.Nombre,
                ClaveMaestra = "ClaveDiferente"
            };

            ControladoraClave claveBuscadora = new ControladoraClave
            {
                VerificarSitio = clave2.VerificarSitio,
                Codigo = "EstaEsUnaDiferente",
                verificarUsuarioClave = clave2.verificarUsuarioClave
            };

            ClaveCompartida buscadora = new ClaveCompartida()
            {
                Destino = usuario2,
                Original = usuarioBuscador,
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
        private ControladoraUsuario usuario;
        private ControladoraCategoria categoria1;
        private ControladoraCategoria categoria2;
        private ControladoraTarjeta tarjeta1;
        private ControladoraTarjeta tarjeta2;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {

            usuario = new ControladoraUsuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "Hola12345"
            };

            categoria1 = new ControladoraCategoria()
            {
                Nombre = "Personal"
            };

            categoria2 = new ControladoraCategoria()
            {
                Nombre = "Trabajo"
            };

            tarjeta1 = new ControladoraTarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };

            tarjeta2 = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjetaIgual = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjetaDistintoNumero = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjetaDistintoNombre = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjetaDistintoTipo = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjetaDistintoTipo = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjetaDistintoTipo = new ControladoraTarjeta()
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

            ControladoraTarjeta tarjetaIgual = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjeta = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjeta = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjeta = new ControladoraTarjeta()
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
            ControladoraTarjeta tarjeta = new ControladoraTarjeta()
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


            ControladoraCategoria buscadora = new ControladoraCategoria()
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

            ControladoraTarjeta buscadora = new ControladoraTarjeta()
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

            ControladoraTarjeta buscadora = new ControladoraTarjeta()
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
            ControladoraCategoria buscadora = new ControladoraCategoria()
            {
                Nombre = categoria1.Nombre
            };

            usuario.AgregarTarjeta(tarjeta1, buscadora);

            ControladoraTarjeta aBorrar = new ControladoraTarjeta()
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

            ControladoraCategoria buscadora = new ControladoraCategoria()
            {
                Nombre = categoria1.Nombre
            };

            usuario.AgregarTarjeta(tarjeta1, buscadora);
            usuario.AgregarTarjeta(tarjeta2, buscadora);

            ControladoraTarjeta buscadoraBorrar = new ControladoraTarjeta()
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


            ControladoraTarjeta tarjetaVieja = new ControladoraTarjeta()
            {
                Numero = "2222222222222222"
            };
            ControladoraTarjeta tarjetaNueva = new ControladoraTarjeta()
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


            ControladoraTarjeta tarjetaVieja = new ControladoraTarjeta()
            {
                Numero = tarjeta1.Numero
            };
            ControladoraTarjeta tarjetaNueva = new ControladoraTarjeta()
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

            ControladoraTarjeta buscadora = new ControladoraTarjeta()
            {
                Numero = tarjeta2.Numero
            };

            ControladoraTarjeta resultado = usuario.GetTarjeta(buscadora);

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
            
            ControladoraTarjeta tarjeta1 = new ControladoraTarjeta()
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

            ControladoraTarjeta buscadora = new ControladoraTarjeta()
            {
                Numero = tarjeta2.Numero
            };

            ControladoraTarjeta resultado = usuario.GetTarjeta(buscadora);

            ControladoraCategoria categoriaFinal = usuario.GetCategoriaTarjeta(buscadora);

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

            List<ControladoraTarjeta> tarjetas = new List<ControladoraTarjeta>
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

            List<ControladoraTarjeta> tarjetas = new List<ControladoraTarjeta>
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

           
            ControladoraTarjeta buscadora = new ControladoraTarjeta()
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

            ControladoraTarjeta buscadora = new ControladoraTarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.AreEqual(categoria1, usuario.GetCategoriaTarjeta(buscadora));
        }

        
    }

}
