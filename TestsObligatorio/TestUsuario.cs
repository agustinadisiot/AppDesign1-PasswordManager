using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestUsuario
    {
        [TestMethod]
        public void UsuarioGetNombreCorrecto()
        {
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", usuario.Nombre);
        }

        [TestMethod]
        public void UsuarioGetNombreCambiado()
        {
            Usuario usuario = new Usuario
            {
                Nombre = "Roberto"
            };
            Assert.AreEqual("Roberto", usuario.Nombre);
            usuario.Nombre = "Hernesto";
            Assert.AreEqual("Hernesto", usuario.Nombre);
        }

        [TestMethod]
        public void UsuarioLargoNombreMenorA5()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "A");
        }

        [TestMethod]
        public void UsuarioLargoNombreMayorA25()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.Nombre = "12345678901234567890123456");
        }

        [TestMethod]
        public void UsuarioValidarContraMaestra()
        {
            Usuario usuario = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(true, usuario.ValidarIgualContraMaestra("Hola12345"));
        }

        [TestMethod]
        public void UsuarioValidarContraMaestraDiferente()
        {
            Usuario u1 = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(false, u1.ValidarIgualContraMaestra("Diferente"));
        }

        [TestMethod]
        public void UsuarioValidarContraMaestraCambiada()
        {
            Usuario usuario = new Usuario
            {
                ContraMaestra = "Hola12345"
            };
            Assert.AreEqual(true, usuario.ValidarIgualContraMaestra("Hola12345"));

            usuario.ContraMaestra = "Chau109876";
            Assert.AreEqual(false, usuario.ValidarIgualContraMaestra("Hola12345"));
            Assert.AreEqual(true, usuario.ValidarIgualContraMaestra("Chau109876"));
        }

        [TestMethod]
        public void UsuarioLargoContraMaestraMenorA5()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ContraMaestra = "A");
        }

        [TestMethod]
        public void UsuarioLargoContraMaestraMayorA25()
        {
            Usuario usuario = new Usuario();
            Assert.ThrowsException<LargoIncorrectoException>(() => usuario.ContraMaestra = "12345678901234567890123456");
        }
    }

    [TestClass]
    public class TestUsuarioCategoria
    {
        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaSinCategorias()
        {
            Usuario usuario = new Usuario();
            Assert.AreEqual(true, usuario.EsListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioEsListaConCategoriasVaciaConUnaCategoria()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);
            Assert.AreEqual(false, usuario.EsListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioEsListaCategoriasVaciaConDosCategorias()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.AgregarCategoria(categoria);
            Assert.AreEqual(false, usuario.EsListaCategoriasVacia());
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria2);
            Assert.AreEqual(false, usuario.EsListaCategoriasVacia());
        }

        [TestMethod]
        public void UsuarioAgregarCategoriaVacia()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria();
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarCategoria(categoria));
        }

        [TestMethod]
        public void UsuarioGetCategoriaCorrecta()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Personal"
            };
            Assert.AreEqual(categoria, usuario.GetCategoria(buscadora));
        }

        [TestMethod]
        public void UsuarioGetCategoriaPrimeraConDos()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.AgregarCategoria(categoria2);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Personal"
            };

            Assert.AreEqual(categoria, usuario.GetCategoria(buscadora));
        }

        [TestMethod]
        public void UsuarioGetCategoriaSegundaConDos()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
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
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.AgregarCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioYaExisteCategoriaSiExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);
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
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual(false, usuario.YaExisteCategoria(categoria2));
        }

        [TestMethod]
        public void UsuarioEqualsMismoNombreYContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario12"
            };
            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario12" 
            };
            Assert.AreEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioEqualsDiferenteNombreYMismaContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario123"
            };
            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario789"
            };
            Assert.AreNotEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioEqualsConNull()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario123"
            };
            Usuario usuario2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.Equals(usuario2));
        }

        [TestMethod]
        public void UsuarioEqualsConString()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario123"
            };
            string falsoUsuario = "Usuario123";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => usuario.Equals(falsoUsuario));
        }

        [TestMethod]
        public void UsuarioEqualsMismoNombreMayusculaYMinusucula()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "usuario12"
            };
            Usuario usuario2 = new Usuario()
            {
                Nombre = "Usuario12"
            };
            Assert.AreEqual(usuario, usuario2);
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaAgregada()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);

            Categoria vieja = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria nueva = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.ModificarNombreCategoria(vieja, nueva);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.AreEqual("Trabajo", usuario.GetCategoria(buscadora).Nombre);
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaNoExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);


            Categoria modificarVieja = new Categoria()
            {
                Nombre = "Facultad"
            };
            Categoria modificarNueva = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.ModificarNombreCategoria(modificarVieja, modificarNueva));
        }

        [TestMethod]
        public void UsuarioModificarNombreCategoriaANombreExistente()
        {
            Usuario usuario = new Usuario();
            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };
            usuario.AgregarCategoria(categoria);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            usuario.AgregarCategoria(categoria2);

            Categoria modificarVieja = new Categoria()
            {
                Nombre = "Personal"
            };
            Categoria modificarNueva = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarNombreCategoria(modificarVieja, modificarNueva));
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasVacia()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };
            int cantCategorias = usuario.GetListaCategorias().Count();

            Assert.IsTrue(cantCategorias == 0);
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasNoVacia()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria"
            };

            usuario.AgregarCategoria(categoria);
            Assert.IsNotNull(usuario.GetListaCategorias());
        }

        [TestMethod]
        public void UsuarioGetListaCategoriasEsIgual()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria primera = new Categoria()
            {
                Nombre = "Primera"
            };
            Categoria segunda = new Categoria()
            {
                Nombre="Segunda"
            };

            usuario.AgregarCategoria(primera);
            usuario.AgregarCategoria(segunda);

            List<Categoria> categorias = new List<Categoria>
            {
                primera,
                segunda
            };
            Assert.AreEqual(true, categorias.SequenceEqual(usuario.GetListaCategorias())); ;
        }

    }

    [TestClass]
    public class TestUsuarioContra
    {
        [TestMethod]
        public void UsuarioYaExisteContraUnaCategoriaSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            { 
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            usuario.AgregarCategoria(categoria);
            Clave contraIgual = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            Assert.AreEqual(true, usuario.YaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraMismoUsuarioDiferenteSitio()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            usuario.AgregarCategoria(categoria);
            Clave contraIgual = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            Assert.AreEqual(false, usuario.YaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraMismoSitioDiferenteUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            usuario.AgregarCategoria(categoria);
            Clave contraIgual = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "222222",
                Codigo = "12345678"
            };
            Assert.AreEqual(false, usuario.YaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraDiferentesClaves()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria.AgregarClave(contra);
            usuario.AgregarCategoria(categoria);
            Clave contraIgual = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            Assert.AreEqual(true, usuario.YaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioYaExisteContraDosCategoriasSiExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria1 = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra1 = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            categoria1.AgregarClave(contra1);
            usuario.AgregarCategoria(categoria1);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Clave contra2 = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = "usuarioYoutube",
                Codigo = "contra1234"
            };
            categoria2.AgregarClave(contra2);
            usuario.AgregarCategoria(categoria2);

            Clave contraIgual = new Clave()
            {
                Sitio = "www.youtube.com",
                UsuarioClave = "usuarioYoutube",
                Codigo = "contra1234"
            };
            Assert.AreEqual(true, usuario.YaExisteContra(contraIgual));
        }

        [TestMethod]
        public void UsuarioAgregarContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarContra(contra, buscadora);
            Assert.AreEqual(true, usuario.YaExisteContra(contra));
        }

        [TestMethod]
        public void UsuarioAgregarContraSinCategoria()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.AgregarContra(contra, categoria));
        }

        [TestMethod]
        public void UsuarioAgregarContraSinSitioOAplicacion()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarContra(contra, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarContraSinClave()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarContra(contra, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarContraSinUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Assert.ThrowsException<ObjetoIncompletoException>(() => usuario.AgregarContra(contra, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarContraRepetida()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarContra(contra, buscadora);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.AgregarContra(contra, buscadora));
        }

        [TestMethod]
        public void UsuarioAgregarContraCategoriaConContra()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "Trabajo"
            };
            Clave contra = new Clave()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioClave = "111111",
                Codigo = "12345678"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarContra(contra, buscadora);
            Assert.AreEqual(true, usuario.GetCategoria(buscadora).YaExisteClave(contra));
        }

        [TestMethod]
        public void UsuarioBorrarContraSinCategorias()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";

            Clave aBorrar = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.BorrarContra(aBorrar));
        }

        [TestMethod]
        public void UsuarioBorrarContraSinContras()
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

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";

            Clave aBorrar = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio =paginaContra
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.BorrarContra(aBorrar));
        }

        [TestMethod]
        public void UsuarioYaExisteContraBorrada()
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

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";

            Clave contraABorrar = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra,
                Codigo = "12345AbC$"
            };

            Categoria buscadora = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarContra(contraABorrar, buscadora);

            Clave aBorrar = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra
            };

            usuario.BorrarContra(aBorrar);
            Assert.IsFalse(usuario.YaExisteContra(contraABorrar));
        }

        [TestMethod]
        public void UsuarioBorrarContraYYaExisteContraRestante()
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

            String usuarioContra = "222222";
            String paginaContra = "www.ort.edu.uy";

            Clave contraABorrar = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra,
                Codigo = "12345AbC$"
            };


            Clave contraADejar = new Clave()
            {
                UsuarioClave = "OtraContra",
                Sitio = "sitioContraADejar.com",
                Codigo = "12345AbC$"
            };

            Categoria buscadora = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarContra(contraABorrar, buscadora);
            usuario.AgregarContra(contraADejar, buscadora);

            Clave aBorrar = new Clave()
            {
                UsuarioClave = usuarioContra,
                Sitio = paginaContra
            };
            usuario.BorrarContra(aBorrar);
            Assert.IsTrue(usuario.YaExisteContra(contraADejar));
        }

        [TestMethod]
        public void UsuarioGetContraCorrecta()
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

            Clave contraAGuardar = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };

            usuario.AgregarContra(contraAGuardar, categoria);

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(contraAGuardar, usuario.GetContra(contraBuscadora));
        }

        [TestMethod]
        public void UsuarioaGetContraPrimeraConDosContras()
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

            Clave contra1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario.AgregarContra(contra1, categoria);

            Clave contra2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            usuario.AgregarContra(contra2, categoria);

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(contra1, usuario.GetContra(contraBuscadora)); ;
        }

        [TestMethod]
        public void UsuarioaGetContraSegundaConDosContras()
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

            Clave contra1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario.AgregarContra(contra1, categoria);

            Clave contra2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Luis88"
            };
            usuario.AgregarContra(contra2, categoria);

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Luis88"
            };

            Assert.AreEqual(contra2, usuario.GetContra(contraBuscadora)); ;
        }

        [TestMethod]
        public void UsuarioaGetContraATravezDeContraSinClave()
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

            Clave contra1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            usuario.AgregarContra(contra1, categoria);

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Roberto"
            };

            Assert.AreEqual(contra1.Codigo, usuario.GetContra(contraBuscadora).Codigo);
        }

        [TestMethod]
        public void UsuarioaGetContraInexistente()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Clave contraBuscadora = new Clave()
            {
                Sitio = "web.whatsapp.com",
                UsuarioClave = "Luis123"
            };
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.GetContra(contraBuscadora));
        }
        
        [TestMethod]
        public void UsuarioModificarContraNoExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            string usuarioContraModificar = "Usuario23";
            string paginaContraModificar = "www.ort.edu.uy";
            string claveContraModificar = "1234AbC$";

            Clave contra = new Clave()
            {
                UsuarioClave = usuarioContraModificar,
                Sitio = paginaContraModificar,
                Codigo = claveContraModificar
            };

            string usuarioContraInexistente = "12345@";
            string paginaContraInexistente = "www.ort.edu.uy";

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioContraInexistente,
                Sitio = paginaContraInexistente
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Categoria"
            };

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = buscadora,
                ClaveNueva = buscadora,
                CategoriaVieja = categoria,
                CategoriaNueva = categoria
            };


            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.ModificarContra(parametros));
        }

        [TestMethod]
        public void UsuarioAlModificarContraAgregadaLaContraViejaDejaDeExistir()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria);

            string usuarioContraModificar = "Usuario23";
            string paginaContraModificar = "www.ort.edu.uy";
            string claveContraModificar = "1234AbC$";

            Clave contraVieja = new Clave()
            {
                UsuarioClave = usuarioContraModificar,
                Sitio = paginaContraModificar,
                Codigo = claveContraModificar,
                Nota = ""
            };
            categoria.AgregarClave(contraVieja);

            string usuarioContraNueva = "user543";
            string paginaContraNueva = "aulas.edu.uy";
            string claveContraNueva = "1234A@C$";

            Clave contraNueva = new Clave()
            {
                UsuarioClave = usuarioContraNueva,
                Sitio = paginaContraNueva,
                Codigo = claveContraNueva,
                Nota = ""
            };

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioContraModificar,
                Sitio = paginaContraModificar
            };


            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = buscadora,
                ClaveNueva = contraNueva,
                CategoriaVieja = categoria,
                CategoriaNueva = categoria
            };

            usuario.ModificarContra(parametros);
            Assert.IsFalse(usuario.YaExisteContra(buscadora));
        }

        [TestMethod]
        public void UsuarioModificarContraYaExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria);

            string usuarioContra1 = "11111111";
            string paginaContra1 = "www.ort.edu.uy";
            string claveContra1 = "11111111";

            Clave contra1 = new Clave()
            {
                UsuarioClave = usuarioContra1,
                Sitio = paginaContra1,
                Codigo = claveContra1,
                Nota = ""
            };

            categoria.AgregarClave(contra1);

            string usuarioContra2 = "22222222";
            string paginaContra2 = "aulas.edu.uy";
            string claveContra2 = "22222222";

            Clave contra2 = new Clave()
            {
                UsuarioClave = usuarioContra2,
                Sitio = paginaContra2,
                Codigo = claveContra2,
                Nota = "Tiene Nota"

            };

            categoria.AgregarClave(contra2);

            Clave duplicada = new Clave()
            {
                UsuarioClave = usuarioContra2,
                Sitio = paginaContra2,
                Codigo = "33333333",
                Nota = "Otra Nota"
            };


            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = contra1,
                ClaveNueva = duplicada,
                CategoriaVieja = categoria,
                CategoriaNueva = categoria
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarContra(parametros));
        }

        [TestMethod]
        public void UsuarioModificarContraMoverACategoriaNoExistente()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Categoria categoria = new Categoria()
            {
                Nombre = "Personal"
            };

            Categoria noAgregada = new Categoria()
            {
                Nombre = "No Agregada"
            };

            usuario.AgregarCategoria(categoria);

            string usuarioContra1 = "Usuario23";
            string paginaContra1 = "www.ort.edu.uy";
            string claveContra1 = "1234AbC$";

            Clave mover = new Clave()
            {
                UsuarioClave = usuarioContra1,
                Sitio = paginaContra1,
                Codigo = claveContra1
            };

            usuario.AgregarContra(mover,categoria);

            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = mover,
                ClaveNueva = mover,
                CategoriaVieja = categoria,
                CategoriaNueva = noAgregada
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => usuario.ModificarContra(parametros));
        }

        [TestMethod]
        public void UsuarioModificarContraMoverACategoriaExistente()
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


            Clave vieja = new Clave()
            {
                UsuarioClave = "11111111",
                Sitio = "ort.edu.uy",
                Codigo = "11111111",
                Nota = "1111"
            };

            usuario.AgregarContra(vieja, personal);

            string usuarioNueva = "22222222";
            string sitioNueva = "aulas.ort.edu.uy";

            Clave nueva = new Clave()
            {
                UsuarioClave = usuarioNueva,
                Sitio = sitioNueva,
                Codigo = "22222222",
                Nota = "2222"
            };


            ClaveAModificar parametros = new ClaveAModificar()
            {
                ClaveVieja = vieja,
                ClaveNueva = nueva,
                CategoriaVieja = personal,
                CategoriaNueva = trabajo
            };

            usuario.ModificarContra(parametros);

            Clave buscadora = new Clave()
            {
                UsuarioClave = usuarioNueva,
                Sitio = sitioNueva
            };

            Clave resultado = usuario.GetContra(buscadora);

            Categoria categoriaFinal = usuario.GetCategoriaClave(buscadora);

            bool igualSitio = resultado.Sitio == nueva.Sitio;
            bool igualUsuario = resultado.UsuarioClave == nueva.UsuarioClave;
            bool igualNota = resultado.Nota == nueva.Nota;
            bool igualClave = resultado.Codigo == nueva.Codigo;

            bool igualesDatos = igualSitio && igualUsuario && igualNota && igualClave;
            bool igualCategoria = trabajo == categoriaFinal;

            Assert.IsTrue(igualesDatos && igualCategoria);
        }

        [TestMethod]
        public void UsuarioGetListaClavesUnaCategoria()
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
                Nombre = "Estudio"
            };

            usuario.AgregarCategoria(categoria2);

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

            Clave clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            Clave clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Peepo"
            };
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
            int cantidadRojas = 0;
            foreach(Clave clave in getListaClaves)
            {
                if (clave.GetNivelSeguridad() == "rojo") cantidadRojas ++;
            }

            Assert.AreEqual(cantidadRojas, usuario.GetCantidadColor("rojo"));
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
            string color = "verde claro";
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
            usuario1.AgregarContra(clave1, categoria1);

            ClaveCompartida claveCompartida = new ClaveCompartida()
            {
                Usuario = usuario2,
                Clave = clave1
            };

            usuario1.CompartirClave(claveCompartida);

            ClaveCompartida claveCompartidaConmigo = new ClaveCompartida()
            {
                Usuario = usuario1,
                Clave = clave1
            };
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

            usuario1.AgregarContra(clave1, categoria1);

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
            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);
            usuario1.AgregarContra(clave2, categoria1);

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
            usuario1.AgregarContra(clave1, categoria1);

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
            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);
            usuario1.AgregarContra(clave2, categoria1);

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

            usuario1.AgregarContra(claveNoCompartida, categoria1);
            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(claveNoCompartida, categoria1);
            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(claveNoCompartida, categoria1);
            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.BorrarContra(clave1);

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
            const string rojo = "rojo";
            Assert.AreEqual(cantidadRojas, usuario.GetListaClavesColor(rojo).Count);
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

            const string verdeOscuro = "verde oscuro";
            List<Clave> getListaClavesVerdes = usuario.GetListaClavesColor(verdeOscuro);

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

            const string amarillo = "amarillo";
            List<Clave> getListaClavesAmarillas = usuario.GetListaClavesColor(amarillo);

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

            usuario.AgregarContra(agregar, facultad);

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
            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);
            usuario1.AgregarContra(clave2, categoria1);

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
                ContraMaestra = "123456789"
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

            usuario1.AgregarContra(clave1, categoria1);
            usuario1.AgregarContra(clave2, categoria1);

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
                ContraMaestra = "ClaveDiferente"
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
            usuario1.AgregarContra(clave1, categoria1);

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

            usuario1.AgregarContra(clave1, categoria1);
            usuario1.AgregarContra(clave2, categoria1);

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
                ContraMaestra = "123456789"
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

            usuario1.AgregarContra(clave1, categoria1);
            usuario1.AgregarContra(clave2, categoria1);

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
                ContraMaestra = "ClaveDiferente"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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
        public void UsuarioGetTarjetaATravezDeContraSinCodigo()
        {
            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario",
                ContraMaestra = "contra123"
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
                ContraMaestra = "contra123"
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

    [TestClass]
    public class TestUsuarioDataBreaches {

        [TestMethod]
        public void UsuarioGetDataBreachVacioRetornaListaVacia()
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
                Nombre = "Estudio"
            };

            usuario.AgregarCategoria(categoria2);

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

            Clave clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            Clave clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);

            List<string> dataBreach = new List<string>();


            Assert.AreEqual(0, usuario.GetContrasDataBreach(dataBreach).Count);
        }


        [TestMethod]
        public void UsuarioGetDataBreachNoVacio()
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
                Nombre = "Estudio"
            };

            usuario.AgregarCategoria(categoria2);

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
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            Clave clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            Clave clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);

            List<string> dataBreach = new List<string>() {
                "EstaEsUnaClave1",
                "EstaEsUnaClave4"
            };

            List<Clave> esperadas = new List<Clave>() {
                clave1,
                clave4
            };

            List<Clave> retorno = usuario.GetContrasDataBreach(dataBreach);

            bool esperadasContieneRetorno = retorno.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(retorno.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetDataBreachContrasNoExistentes()
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
                Nombre = "Estudio"
            };

            usuario.AgregarCategoria(categoria2);

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
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            Clave clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            Clave clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);

            List<string> dataBreach = new List<string>() {
                "ContraNoContenida",
                "ContraTampocoContenida",
                "EstaEsUnaClave3"
            };

            List<Clave> esperadas = new List<Clave>() {
                clave3
            };

            List<Clave> retorno = usuario.GetContrasDataBreach(dataBreach);

            bool esperadasContieneRetorno = retorno.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(retorno.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetTarjetasDataBreachVacio()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria trabajo = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Categoria facultad = new Categoria()
            {
                Nombre = "Facultad"
            };

            usuario.AgregarCategoria(trabajo);
            usuario.AgregarCategoria(facultad);



            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta1,trabajo);

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta2, facultad);


            List<string> dataBreach = new List<string>();

            Assert.AreEqual(0, usuario.GetTarjetasDataBreach(dataBreach).Count);
        }

        [TestMethod]
        public void UsuarioGetTarjetasDataBreachNoVacio()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario"
            };

            Categoria trabajo = new Categoria()
            {
                Nombre = "Trabajo"
            };

            Categoria facultad = new Categoria()
            {
                Nombre = "Facultad"
            };

            usuario.AgregarCategoria(trabajo);
            usuario.AgregarCategoria(facultad);



            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta1, trabajo);

            Tarjeta tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta2, facultad);

            Tarjeta tarjeta3 = new Tarjeta()
            {
                Numero = "3333333333333333",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta3, facultad);

            List<string> dataBreach = new List<string>() {
                "1111111111111111",
                "UnaClave",
                "3333 3333 3333 3333",
                "4444 4444 4444 4444"
            };

            List<Tarjeta> esperadas = new List<Tarjeta>() {
                tarjeta1,
                tarjeta3
            };

            List<Tarjeta> retorno = usuario.GetTarjetasDataBreach(dataBreach);

            bool esperadasContieneRetorno = retorno.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(retorno.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }
    }

}
