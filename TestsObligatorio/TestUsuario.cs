using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsObligatorio
{

    [TestClass]
    public class TestUsuario
    {
        private ControladoraUsuario controladora = new ControladoraUsuario();
        private DataAccessUsuario acceso;

        private Usuario usuario;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            acceso = new DataAccessUsuario();
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
        private ControladoraUsuario controladora = new ControladoraUsuario();
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
            acceso = new DataAccessUsuario();
            List<Usuario> usuariosABorrar = (List<Usuario>)acceso.GetTodos();
            foreach (Usuario actual in usuariosABorrar)
            {
                acceso.Borrar(actual);
            }

            accesoCategoria = new DataAccessCategoria();
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
}
