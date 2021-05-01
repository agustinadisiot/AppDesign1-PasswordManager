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
        public void CategoriaAgregarContraSinUsuario()
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
        public void CategoriaYaExisteTarjetaDiferenteVencimiento()
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
                Codigo = "321"
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
                Codigo = "321"
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
                Codigo = "321"
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
                Numero = "3456567890876543"
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

    }
}
