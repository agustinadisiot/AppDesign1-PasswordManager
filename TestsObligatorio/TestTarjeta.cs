using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaDeNegocio;
using System;
using System.Globalization;
using Repositorio;
using Negocio;
using System.Collections.Generic;

namespace TestsObligatorio
{

    [TestClass]
    public class TestTarjeta
    {
        private Tarjeta tarjeta1;
        private Tarjeta tarjeta2;
        private DateTime fecha1;
        private DataAccessTarjeta acceso;
        private ControladoraTarjeta controladora;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            List<Tarjeta> tarjetasABorrar = (List<Tarjeta>)acceso.GetTodos();
            foreach (Tarjeta actual in tarjetasABorrar)
            {
                acceso.Borrar(actual);
            }

            controladora = new ControladoraTarjeta();

            fecha1 = new DateTime(2022, 5, 9);

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
        public void TarjetaGetNombreCorrecto()
        {
            Assert.AreEqual("Visa Gold", tarjeta2.Nombre);
        }

        [TestMethod]
        public void TarjetaGetNombreCambiado()
        {
            tarjeta1.Nombre = "American";
            Assert.AreEqual("American", tarjeta1.Nombre);
        }

        [TestMethod]
        public void TarjetaLargoNombreMenorA3()
        {
            tarjeta1.Nombre = "A";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNombre(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoNombreMayorA25()
        {
            tarjeta1.Nombre = "NombreDeTarjetaDemasiadoLargo";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNombre(tarjeta1));
        }

        [TestMethod]
        public void TarjetaGetTipoCorrecto()
        {
            Assert.AreEqual("Visa", tarjeta2.Tipo);
        }

        [TestMethod]
        public void TarjetaGetTipoCambiado()
        {
            tarjeta2.Tipo = "MasterCard";
            Assert.AreEqual("MasterCard", tarjeta2.Tipo);
        }

        [TestMethod]
        public void TarjetaLargoTipoMenorA3()
        {
            tarjeta1.Tipo = "A";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarTipo(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoTipoMayorA25()
        {
            tarjeta1.Tipo = "TipoDemasiadoLargoNoPermitido";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarTipo(tarjeta1));
        }

        [TestMethod]
        public void TarjetaGetNumeroCorrecto()
        {
            Assert.AreEqual("1111111111111111", tarjeta1.Numero);
        }

        [TestMethod]
        public void TarjetaGetNumeroCambiado()
        {
            tarjeta1.Numero = "8765432187654321";
            Assert.AreEqual("8765432187654321", tarjeta1.Numero);
        }

        [TestMethod]
        public void TarjetaLargoNumeroMenorA16()
        {
            tarjeta1.Numero = "1215412";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNumero(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoNumeroMayorA16()
        {
            tarjeta1.Numero = "123456781223456781234";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNumero(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoNumeroConLetras()
        {
            tarjeta1.Numero = "12345BCdA2345678";
            Assert.ThrowsException<CaracterInesperadoException>(() => controladora.VerificarNumero(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoNumeroConSimbolos()
        {
            tarjeta1.Numero = "12345#$%@2345678";
            Assert.ThrowsException<CaracterInesperadoException>(() => controladora.VerificarNumero(tarjeta1));
        }

        [TestMethod]
        public void TarjetaGetCodigoCorrecto()
        {
            Assert.AreEqual("321", tarjeta1.Codigo);
        }

        [TestMethod]
        public void TarjetaGetCodigoCambiado()
        {
            tarjeta1.Codigo = "3241";
            Assert.AreEqual("3241", tarjeta1.Codigo);
        }

        [TestMethod]
        public void TarjetaLargoCodigoMenorA3()
        {
            tarjeta1.Codigo = "12";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarCodigo(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoCodigoMayorA4()
        {
            tarjeta1.Codigo = "12345";
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarCodigo(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoCodigoConLetras()
        {
            tarjeta1.Codigo = "12B";
            Assert.ThrowsException<CaracterInesperadoException>(() => controladora.VerificarCodigo(tarjeta1));
        }

        [TestMethod]
        public void TarjetaLargoCodigoConSimbolos()
        {
            tarjeta1.Codigo = "12**";
            Assert.ThrowsException<CaracterInesperadoException>(() => controladora.VerificarCodigo(tarjeta1));
        }

        [TestMethod]
        public void TarjetaGetVencimientoCorrecto()
        {
            Assert.AreEqual("07/2025", tarjeta1.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TarjetaGetVencimientoCambiado()
        {
            tarjeta1.Vencimiento = fecha1;
            Assert.AreEqual("05/2022", tarjeta1.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TarjetaGetNotaTarjetaCorrecta()
        {
            tarjeta1.Nota = "Limite 400k UYU";
            Assert.AreEqual("Limite 400k UYU", tarjeta1.Nota);
        }

        [TestMethod]
        public void TarjetaGetNotaCambiada()
        {
            tarjeta1.Nota = "Nota nueva";
            Assert.AreEqual("Nota nueva", tarjeta1.Nota);
        }

        [TestMethod]
        public void TarjetaLargoNotaMayorA250()
        {
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "T";
            tarjeta1.Nota = notaDemasiadoLarga;
            Assert.ThrowsException<LargoIncorrectoException>(() => controladora.VerificarNota(tarjeta1));
        }

        [TestMethod]
        public void TarjetaEqualsMismoNumero()
        {
            Tarjeta tarjetaMismoNumero = new Tarjeta
            {
                Numero = tarjeta1.Numero
            };
            Assert.AreEqual(tarjeta1, tarjetaMismoNumero);
        }

        [TestMethod]
        public void TarjetaNotEqualsDiferenteNumero()
        {
            Tarjeta tarjeta2 = new Tarjeta
            {
                Numero = "6543210987654321"
            };
            Assert.AreNotEqual(tarjeta1, tarjeta2);
        }

        [TestMethod]
        public void TarjetaEqualsNull()
        {
            Tarjeta tarjetaNULL = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => tarjeta1.Equals(tarjetaNULL));
        }

        [TestMethod]
        public void TarjetaEqualsConString()
        {
            String noEsTarjeta = "1234567890123456";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => tarjeta1.Equals(noEsTarjeta));
        }

    }
}
