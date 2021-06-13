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
    public class TestUsuarioTarjeta
    {
        private ControladoraTarjeta controladoraTarjeta;
        private ControladoraUsuario controladoraUsuario;
        private ControladoraCategoria controladoraCategoria;
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
            controladoraTarjeta = new ControladoraTarjeta();
            controladoraUsuario = new ControladoraUsuario();
            controladoraCategoria = new ControladoraCategoria();

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
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteTarjeta(tarjetaIgual, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNumero()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            Tarjeta tarjetaDistintoNumero = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento,
                Numero = "1234567812345678"
            };
            Assert.AreEqual(false, controladoraUsuario.YaExisteTarjeta(tarjetaDistintoNumero, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoNombre()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            Tarjeta tarjetaDistintoNombre = new Tarjeta()
            {
                Nombre = "Visa",
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteTarjeta(tarjetaDistintoNombre, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoTipo()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento,
                Tipo = "Mastercard Gold"
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteTarjeta(tarjetaDistintoTipo, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDistintoCodigo()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Vencimiento = tarjeta1.Vencimiento,
                Codigo = "123"
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteTarjeta(tarjetaDistintoTipo, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDiferenteVencimiento()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);
            Tarjeta tarjetaDistintoTipo = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = new DateTime(2026, 9, 2)
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteTarjeta(tarjetaDistintoTipo, usuario));
        }

        [TestMethod]
        public void UsuarioYaExisteTarjetaDosCategoriasSiExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta2, categoria2, usuario);

            Tarjeta tarjetaIgual = new Tarjeta()
            {
                Nombre = tarjeta2.Nombre,
                Tipo = tarjeta2.Tipo,
                Numero = tarjeta2.Numero,
                Codigo = tarjeta2.Codigo,
                Vencimiento = tarjeta2.Vencimiento
            };
            Assert.AreEqual(true, controladoraUsuario.YaExisteTarjeta(tarjetaIgual, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarTarjeta()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            Assert.AreEqual(true, controladoraUsuario.YaExisteTarjeta(tarjeta1, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaSinCategoria()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario));
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
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarTarjeta(tarjeta, categoria1, usuario));
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
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarTarjeta(tarjeta, categoria1, usuario));
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
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarTarjeta(tarjeta, categoria1, usuario));
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
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.ThrowsException<ObjetoIncompletoException>(() => controladoraUsuario.AgregarTarjeta(tarjeta, categoria1, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaRepetida()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);
            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario));
        }

        [TestMethod]
        public void UsuarioAgregarTarjetaCategoriaConTarjeta()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);


            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            Categoria resultado = controladoraUsuario.GetCategoria(buscadora, usuario);
            Assert.AreEqual(true, controladoraCategoria.YaExisteTarjeta(tarjeta1, resultado));
        }

        [TestMethod]
        public void UsuarioGetTarjetaCorrecta()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            Tarjeta buscadora = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Codigo = tarjeta1.Codigo,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(tarjeta1, controladoraUsuario.GetTarjeta(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioGetTarjetaInexistente()
        {
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.GetTarjeta(tarjeta1, usuario));
        }

        [TestMethod]
        public void UsuarioGetTarjetaATravesDeClaveSinCodigo()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            Tarjeta buscadora = new Tarjeta()
            {
                Nombre = tarjeta1.Nombre,
                Tipo = tarjeta1.Tipo,
                Numero = tarjeta1.Numero,
                Vencimiento = tarjeta1.Vencimiento
            };

            Assert.AreEqual(tarjeta1.Codigo, controladoraUsuario.GetTarjeta(buscadora, usuario).Codigo);
        }


        [TestMethod]
        public void UsuarioBorrarTarjetaSinCategorias()
        {
            Assert.ThrowsException<CategoriaInexistenteException>(() => controladoraUsuario.BorrarTarjeta(tarjeta1, usuario));
        }


        [TestMethod]
        public void UsuarioBorrarTarjetaSinTarjetas()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.BorrarTarjeta(tarjeta1, usuario));
        }


        [TestMethod]
        public void UsuarioYaExisteTarjetaBorrada()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            controladoraUsuario.AgregarTarjeta(tarjeta1, buscadora, usuario);

            Tarjeta aBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            controladoraUsuario.BorrarTarjeta(aBorrar, usuario);

            Assert.IsFalse(controladoraUsuario.YaExisteTarjeta(aBorrar, usuario));
        }

        [TestMethod]
        public void UsuarioBorrarTarjetaYaExisteTarjetaRestante()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);

            Categoria buscadora = new Categoria()
            {
                Nombre = categoria1.Nombre
            };

            controladoraUsuario.AgregarTarjeta(tarjeta1, buscadora, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta2, buscadora, usuario);

            Tarjeta buscadoraBorrar = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };
            controladoraUsuario.BorrarTarjeta(buscadoraBorrar, usuario);
            Assert.IsTrue(controladoraUsuario.YaExisteTarjeta(tarjeta2, usuario));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaNoExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);


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

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.ModificarTarjeta(parametros, usuario));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaTarjetaYaExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta2, categoria1, usuario);


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

            Assert.ThrowsException<ObjetoYaExistenteException>(() => controladoraUsuario.ModificarTarjeta(parametros, usuario));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaTodosLosDatos()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjeta1,
                TarjetaNueva = tarjeta2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria1

            };

            controladoraUsuario.ModificarTarjeta(parametros, usuario);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            Tarjeta resultado = controladoraUsuario.GetTarjeta(buscadora, usuario);

            bool igualNumero = tarjeta2.Numero == resultado.Numero;
            bool igualNombre = tarjeta2.Nombre == resultado.Nombre;
            bool igualTipo = tarjeta2.Tipo == resultado.Tipo;
            bool igualCodigo = tarjeta2.Codigo == resultado.Codigo;
            bool igualNota = tarjeta2.Nota == resultado.Nota;
            bool igualVencimiento = tarjeta2.Vencimiento == resultado.Vencimiento;

            Assert.IsTrue(igualNumero && igualNombre && igualTipo && igualCodigo && igualNota && igualVencimiento);
        }

        [TestMethod]
        public void UsuarioModificarTarjetaMoverACategoriaNoExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjeta1,
                TarjetaNueva = tarjeta1,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            Assert.ThrowsException<CategoriaInexistenteException>(() => controladoraUsuario.ModificarTarjeta(parametros, usuario));
        }

        [TestMethod]
        public void UsuarioModificarTarjetaMoverACategoriaExistente()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            Tarjeta tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "111",
                Nota = "AAAAA",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            TarjetaAModificar parametros = new TarjetaAModificar()
            {
                TarjetaVieja = tarjeta1,
                TarjetaNueva = tarjeta2,
                CategoriaVieja = categoria1,
                CategoriaNueva = categoria2
            };

            controladoraUsuario.ModificarTarjeta(parametros, usuario);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta2.Numero
            };

            Tarjeta resultado = controladoraUsuario.GetTarjeta(buscadora, usuario);

            Categoria categoriaFinal = controladoraUsuario.GetCategoriaTarjeta(buscadora, usuario);

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
            int cantidadTarjetas = controladoraUsuario.GetListaTarjetas(usuario).Count();

            Assert.IsTrue(cantidadTarjetas == 0);
        }

        [TestMethod]
        public void UsuarioGetListaTarjetasEsIgualConUnaCategoria()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria1);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            bool tarjetasContieneGetTarjetas = controladoraUsuario.GetListaTarjetas(usuario).All(tarjetas.Contains);
            bool getTarjetasContieneTarjetas = tarjetas.All(controladoraUsuario.GetListaTarjetas(usuario).Contains);

            Assert.IsTrue(tarjetasContieneGetTarjetas && getTarjetasContieneTarjetas);
        }

        [TestMethod]
        public void UsuarioGetListaTarjetasEsIgualConDosCategorias()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);
            controladoraCategoria.AgregarTarjeta(tarjeta1, categoria1);
            controladoraCategoria.AgregarTarjeta(tarjeta2, categoria2);

            List<Tarjeta> tarjetas = new List<Tarjeta>
            {
                tarjeta1,
                tarjeta2
            };

            bool tarjetasContieneGetTarjetas = controladoraUsuario.GetListaTarjetas(usuario).All(tarjetas.Contains);
            bool getTarjetasContieneTarjetas = tarjetas.All(controladoraUsuario.GetListaTarjetas(usuario).Contains);
            Assert.IsTrue(tarjetasContieneGetTarjetas && getTarjetasContieneTarjetas);
        }

        [TestMethod]
        public void UsuarioGetCategoriaTarjetaSinTarjetas()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);


            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.ThrowsException<ObjetoInexistenteException>(() => controladoraUsuario.GetCategoriaTarjeta(buscadora, usuario));
        }

        [TestMethod]
        public void UsuarioGetCategoriaTarjetaDosCategorias()
        {
            controladoraUsuario.AgregarCategoria(categoria1, usuario);
            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            Tarjeta buscadora = new Tarjeta()
            {
                Numero = tarjeta1.Numero
            };

            Assert.AreEqual(categoria1, controladoraUsuario.GetCategoriaTarjeta(buscadora, usuario));
        }
    }
}
