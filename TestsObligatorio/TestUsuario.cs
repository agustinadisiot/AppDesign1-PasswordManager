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
            String falsoUsuario = "Usuario123";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => usuario.Equals(falsoUsuario));
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
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.ModificarNombreCategoria(modificarVieja, modificarNueva));
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            usuario.AgregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            usuario.AgregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "111111",
                Clave = "12345678"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            usuario.AgregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "222222",
                Clave = "12345678"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria.AgregarContra(contra);
            usuario.AgregarCategoria(categoria);
            Contra contraIgual = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
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
            Contra contra1 = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            categoria1.AgregarContra(contra1);
            usuario.AgregarCategoria(categoria1);
            Categoria categoria2 = new Categoria()
            {
                Nombre = "Personal"
            };
            Contra contra2 = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "usuarioYoutube",
                Clave = "contra1234"
            };
            categoria2.AgregarContra(contra2);
            usuario.AgregarCategoria(categoria2);

            Contra contraIgual = new Contra()
            {
                Sitio = "www.youtube.com",
                UsuarioContra = "usuarioYoutube",
                Clave = "contra1234"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.AgregarContra(contra, categoria));
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
            Contra contra = new Contra()
            {
                UsuarioContra = "111111",
                Clave = "12345678"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                Clave = "12345678"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
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
            Contra contra = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "111111",
                Clave = "12345678"
            };
            usuario.AgregarCategoria(categoria);

            Categoria buscadora = new Categoria()
            {
                Nombre = "Trabajo"
            };

            usuario.AgregarContra(contra, buscadora);
            Assert.AreEqual(true, usuario.GetCategoria(buscadora).YaExisteContra(contra));
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

            Contra aBorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
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

            Contra aBorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
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

            Contra contraABorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
                Sitio = paginaContra,
                Clave = "12345AbC$"
            };

            Categoria buscadora = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarContra(contraABorrar, buscadora);

            Contra aBorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
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

            Contra contraABorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
                Sitio = paginaContra,
                Clave = "12345AbC$"
            };


            Contra contraADejar = new Contra()
            {
                UsuarioContra = "OtraContra",
                Sitio = "sitioContraADejar.com",
                Clave = "12345AbC$"
            };

            Categoria buscadora = new Categoria()
            {
                Nombre = "Categoria1"
            };

            usuario.AgregarContra(contraABorrar, buscadora);
            usuario.AgregarContra(contraADejar, buscadora);

            Contra aBorrar = new Contra()
            {
                UsuarioContra = usuarioContra,
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

            Contra contraAGuardar = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };

            usuario.AgregarContra(contraAGuardar, categoria);

            Contra contraBuscadora = new Contra()
            {
                Sitio = "web.whatsapp.com",
                UsuarioContra = "Roberto"
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

            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            usuario.AgregarContra(contra1, categoria);

            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            usuario.AgregarContra(contra2, categoria);

            Contra contraBuscadora = new Contra()
            {
                Sitio = "web.whatsapp.com",
                UsuarioContra = "Roberto"
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

            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            usuario.AgregarContra(contra1, categoria);

            Contra contra2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            usuario.AgregarContra(contra2, categoria);

            Contra contraBuscadora = new Contra()
            {
                Sitio = "web.whatsapp.com",
                UsuarioContra = "Luis88"
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

            Contra contra1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            usuario.AgregarContra(contra1, categoria);

            Contra contraBuscadora = new Contra()
            {
                Sitio = "web.whatsapp.com",
                UsuarioContra = "Roberto"
            };

            Assert.AreEqual(contra1.Clave, usuario.GetContra(contraBuscadora).Clave);
        }

        [TestMethod]
        public void UsuarioaGetContraInexistente()
        {

            Usuario usuario = new Usuario()
            {
                Nombre = "Usuario1"
            };

            Contra contraBuscadora = new Contra()
            {
                Sitio = "web.whatsapp.com",
                UsuarioContra = "Luis123"
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

            Contra contra = new Contra()
            {
                UsuarioContra = usuarioContraModificar,
                Sitio = paginaContraModificar,
                Clave = claveContraModificar
            };

            string usuarioContraInexistente = "12345@";
            string paginaContraInexistente = "www.ort.edu.uy";

            Contra buscadora = new Contra()
            {
                UsuarioContra = usuarioContraInexistente,
                Sitio = paginaContraInexistente
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.ModificarContra(buscadora, contra));
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

            Contra contraVieja = new Contra()
            {
                UsuarioContra = usuarioContraModificar,
                Sitio = paginaContraModificar,
                Clave = claveContraModificar,
                Nota = ""
            };
            categoria.AgregarContra(contraVieja);

            string usuarioContraNueva = "user543";
            string paginaContraNueva = "aulas.edu.uy";
            string claveContraNueva = "1234A@C$";

            Contra contraNueva = new Contra()
            {
                UsuarioContra = usuarioContraNueva,
                Sitio = paginaContraNueva,
                Clave = claveContraNueva,
                Nota = ""
            };

            Contra buscadora = new Contra()
            {
                UsuarioContra = usuarioContraModificar,
                Sitio = paginaContraModificar
            };

            usuario.ModificarContra(contraVieja, contraNueva);
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

            string usuarioContra1 = "Usuario23";
            string paginaContra1 = "www.ort.edu.uy";
            string claveContra1 = "1234AbC$";

            Contra contra1 = new Contra()
            {
                UsuarioContra = usuarioContra1,
                Sitio = paginaContra1,
                Clave = claveContra1
            };

            categoria.AgregarContra(contra1);

            string usuarioContra2 = "user23";
            string paginaContra2 = "aulas.edu.uy";
            string claveContra2 = "1234AbC$";

            Contra contra2 = new Contra()
            {
                UsuarioContra = usuarioContra2,
                Sitio = paginaContra2,
                Clave = claveContra2
            };

            categoria.AgregarContra(contra2);

            Contra duplicada = new Contra()
            {
                UsuarioContra = usuarioContra2,
                Sitio = paginaContra2,
                Clave = claveContra2
            };

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarContra(contra1, duplicada));
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria1.AgregarContra(clave1);
            Contra clave2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.AgregarContra(clave2);

            List<Contra> claves = new List<Contra>
            {
                clave1,
                clave2
            };

            List<Contra> getListaClaves = usuario.GetListaClaves();

            bool getListaClavesContieneLasClaves = getListaClaves.All(claves.Contains);
            bool lasClavesContieneGetListaClaves = claves.All(getListaClaves.Contains);

            Assert.AreEqual(getListaClavesContieneLasClaves, lasClavesContieneGetListaClaves);
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            categoria1.AgregarContra(clave1);
            Contra clave2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Luis88"
            };
            categoria1.AgregarContra(clave2);

            Contra clave3 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave3",
                UsuarioContra = "Hernesto"
            };
            categoria2.AgregarContra(clave3);
            Contra clave4 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Peepo"
            };
            categoria2.AgregarContra(clave4);

            List<Contra> claves = new List<Contra>
            {
                clave1,
                clave2,
                clave3,
                clave4
            };

            List<Contra> getListaClaves = usuario.GetListaClaves();

            bool getListaClavesContieneLasClaves = getListaClaves.All(claves.Contains);
            bool lasClavesContieneGetListaClaves = claves.All(getListaClaves.Contains);

            Assert.AreEqual(getListaClavesContieneLasClaves, lasClavesContieneGetListaClaves);
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            Contra clave2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave2",
                UsuarioContra = "Hernesto"
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
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

            Contra clave1 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave1",
                UsuarioContra = "Roberto"
            };
            Contra clave2 = new Contra()
            {
                Sitio = "web.whatsapp.com",
                Clave = "EstaEsUnaClave2",
                UsuarioContra = "Hernesto"
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

            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.AgregarTarjeta(tarjeta, categoria));
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
        public void UsuarioModificarTarjetaCategoriaNoExistente()
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

            string numeroTarjeta = "3456567890876543";
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
                Numero = "1234567890876543"
            };
            Tarjeta tarjetaNueva = new Tarjeta()
            {
                Numero = "1987654321345678"
            };
            Assert.ThrowsException<ObjetoInexistenteException>(() => usuario.ModificarTarjetaCategoria(tarjetaVieja, tarjetaNueva));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaCategoriaATarjetaYaExistente()
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

            Assert.ThrowsException<ObjetoYaExistenteException>(() => usuario.ModificarTarjetaCategoria(tarjetaVieja, tarjetaNueva));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaCategoriaAgregada()
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
            usuario.ModificarTarjetaCategoria(tarjetaVieja, tarjetaNueva);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = numeroTarjetaNueva
            };
            Assert.AreEqual(tarjetaNueva, usuario.GetTarjeta(buscadora));
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
            Assert.AreEqual(tarjetasContieneGetTarjetas, getTarjetasContieneTarjetas); 
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
            Assert.AreEqual(tarjetasContieneGetTarjetas, getTarjetasContieneTarjetas);
        }
    }
}
