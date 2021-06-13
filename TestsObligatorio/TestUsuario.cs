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
