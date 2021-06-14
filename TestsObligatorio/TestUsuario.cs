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
        private ControladoraUsuario controladoraUsuario;
        private ControladoraAdministrador controladoraAdministrador;

        private Usuario usuario;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            controladoraUsuario = new ControladoraUsuario();
            controladoraAdministrador = new ControladoraAdministrador();
            controladoraAdministrador.BorrarTodo();

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

            Assert.ThrowsException<LargoIncorrectoException>(() => controladoraUsuario.VerificarNombre(usuario));
        }

        [TestMethod]
        public void UsuarioLargoNombreMayorA25()
        {
            usuario.Nombre = "12345678901234567890123456";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladoraUsuario.VerificarNombre(usuario));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestra()
        {
            Usuario igualClave = new Usuario() {
                ClaveMaestra = usuario.ClaveMaestra
            };
            Assert.AreEqual(true, controladoraUsuario.EsIgualClaveMaestra(usuario, igualClave));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestraDiferente()
        {
            Usuario diferenteClave = new Usuario()
            {
                ClaveMaestra = "Diferente"
            };
            Assert.AreEqual(false, controladoraUsuario.EsIgualClaveMaestra(usuario, diferenteClave));
        }

        [TestMethod]
        public void UsuarioValidarClaveMaestraCambiada()
        {
            Usuario igualClave = new Usuario()
            {
                ClaveMaestra = usuario.ClaveMaestra
            };
            usuario.ClaveMaestra = "Chau109876";
            Assert.AreEqual(false, controladoraUsuario.EsIgualClaveMaestra(usuario, igualClave));
        }

        [TestMethod]
        public void UsuarioLargoClaveMaestraMenorA5()
        {
            usuario.ClaveMaestra = "A";
            Assert.ThrowsException<LargoIncorrectoException>(() =>controladoraUsuario.VerificarClaveMaestra(usuario));
        }

        [TestMethod]
        public void UsuarioLargoClaveMaestraMayorA25()
        {
            usuario.ClaveMaestra = "12345678901234567890123456";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladoraUsuario.VerificarClaveMaestra(usuario));
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
        private ControladoraUsuario controladoraUsuario;
        private ControladoraAdministrador controladoraAdministrador;

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
            controladoraAdministrador = new ControladoraAdministrador();
            controladoraUsuario = new ControladoraUsuario();
            controladoraAdministrador.BorrarTodo();

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

            controladoraAdministrador.AgregarUsuario(usuario);
        }

        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaSinCategorias()
        {

            Assert.AreEqual(true, controladoraUsuario.EsListaCategoriasVacia(usuario));
        }

        [TestMethod]
        public void UsuarioEsListaConCategoriasVaciaConUnaCategoria()
        {
            controladoraUsuario.AgregarCategoria(categoria1,usuario);
            Assert.AreEqual(false, controladoraUsuario.EsListaCategoriasVacia(usuario));
        }

        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaConDosCategorias()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);
            Assert.AreEqual(false, controladoraUsuario.EsListaCategoriasVacia(usuario));
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaVacia()
        {
            Categoria vacia = new Categoria();
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarCategoria(vacia, usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaCorrecta()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Assert.AreEqual(categoria1, controladoraUsuario.GetCategoria(buscadora,usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaPrimeraConDos()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Assert.AreEqual(categoria1, controladoraUsuario.GetCategoria(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaSegundaConDos()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria2.Nombre
            };

            Assert.AreEqual(categoria2, controladoraUsuario.GetCategoria(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaYaExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria categoria2 = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            
            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraUsuario.AgregarCategoria(categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaSiExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria categoria2 = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteCategoria(categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaNoExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.AreEqual(false, controladoraUsuario.YaExisteCategoria(categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaAgregada()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria copia = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            categoria2.Nombre = "Trabajo";
            controladoraUsuario.ModificarNombreCategoria(copia, categoria2, usuario);
            Categoria resultado = controladoraUsuario.GetCategoria(categoria2, usuario);
            Assert.AreEqual("Trabajo", resultado.Nombre);
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaNoExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria categoriaNoAgregada = new Categoria()
            {
                Nombre = "Facultad"
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => controladoraUsuario.ModificarNombreCategoria(categoriaNoAgregada, categoria2, usuario));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaANombreExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            Categoria modificarVieja = new Categoria()
            {
                Nombre = categoria1.Nombre
            };
            Categoria modificarNueva = new Categoria()
            {
                Nombre = categoria2.Nombre
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraUsuario.ModificarNombreCategoria(modificarVieja, modificarNueva, usuario));
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasVacia()
        {
            int cantCategorias = controladoraUsuario.GetListaCategorias(usuario).Count();

            Assert.IsTrue(cantCategorias == 0);
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasNoVacia()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.IsNotNull(controladoraUsuario.GetListaCategorias(usuario));
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasNoVaciaCantidad()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            int cantCategorias = controladoraUsuario.GetListaCategorias(usuario).Count();
            Assert.IsTrue(cantCategorias>0);
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasEsIgual()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            List<Categoria> categorias = new List<Categoria>
            {
                categoria1,
                categoria2
            };

            List<Categoria> resultado = controladoraUsuario.GetListaCategorias(usuario);

            Assert.AreEqual(true, categorias.All(resultado.Contains)); ;
        }
    }
}
