using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;
using System.Globalization;

namespace TestsObligatorio
{

    [TestClass]
    public class TestTarjeta
    {
        [TestMethod]
        public void TarjetaGetNombreCorrecto()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold"
            };
            Assert.AreEqual("Visa Gold", tarjeta.Nombre);
        }

        [TestMethod]
        public void TarjetaGetNombreCambiado()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold"
            };
            tarjeta.Nombre = "American";
            Assert.AreEqual("American", tarjeta.Nombre);
        }

        [TestMethod]
        public void TarjetaLargoNombreMenorA3()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Nombre = "A");
        }

        [TestMethod]
        public void TarjetaLargoNombreMayorA25()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Nombre = "NombreDeTarjetaDemasiadoLargo");
        }

        [TestMethod]
        public void TarjetaGetTipoCorrecto()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Tipo = "Visa"
            };
            Assert.AreEqual("Visa", tarjeta.Tipo);
        }

        [TestMethod]
        public void TarjetaGetTipoCambiado()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Tipo = "Visa"
            };
            tarjeta.Tipo = "MasterCard";
            Assert.AreEqual("MasterCard", tarjeta.Tipo);
        }

        [TestMethod]
        public void TarjetaLargoTipoMenorA3()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Tipo = "A");
        }

        [TestMethod]
        public void TarjetaLargoTipoMayorA25()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Tipo = "TipoDemasiadoLargoNoPermitido");
        }

        [TestMethod]
        public void TarjetaGetNumeroCorrecto()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Numero = "1234567812345678"
            };
            Assert.AreEqual("1234567812345678", tarjeta.Numero);
        }

        [TestMethod]
        public void TarjetaGetNumeroCambiado()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Numero = "1234567812345678"
            };
            tarjeta.Numero = "8765432187654321";
            Assert.AreEqual("8765432187654321", tarjeta.Numero);
        }

        [TestMethod]
        public void TarjetaLargoNumeroMenorA16()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Numero = "1215412");
        }

        [TestMethod]
        public void TarjetaLargoNumeroMayorA16()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Numero = "123456781223456781234");
        }

        [TestMethod]
        public void TarjetaLargoNumeroConLetras()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Numero = "12345BCdA2345678");
        }

        [TestMethod]
        public void TarjetaLargoNumeroConSimbolos()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Numero = "12345#$%@2345678");
        }

        [TestMethod]
        public void TarjetaGetCodigoCorrecto()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Codigo = "123"
            };
            Assert.AreEqual("123", tarjeta.Codigo);
        }

        [TestMethod]
        public void TarjetaGetCodigoCambiado()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Codigo = "123"
            };
            tarjeta.Codigo = "3241";
            Assert.AreEqual("3241", tarjeta.Codigo);
        }

        [TestMethod]
        public void TarjetaLargoCodigoMenorA3()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Codigo = "12");
        }

        [TestMethod]
        public void TarjetaLargoCodigoMayorA4()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Codigo = "12345");
        }

        [TestMethod]
        public void TarjetaLargoCodigoConLetras()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Codigo = "12B");
        }

        [TestMethod]
        public void TarjetaLargoCodigoConSimbolos()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Codigo = "12**");
        }

        [TestMethod]
        public void TarjetaGetVencimientoCorrecto()
        {
            Tarjeta tarjeta = new Tarjeta();
            DateTime date1 = new DateTime(2025, 7, 1);
            tarjeta.Vencimiento = date1;
            Assert.AreEqual("07/2025", tarjeta.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TarjetaGetVencimientoCambiado()
        {
            Tarjeta tarjeta = new Tarjeta();
            DateTime date1 = new DateTime(2025, 7, 1);
            tarjeta.Vencimiento = date1;
            DateTime date2 = new DateTime(2023, 8, 1);
            tarjeta.Vencimiento = date2;
            Assert.AreEqual("08/2023", tarjeta.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TarjetaGetNotaTarjetaCorrecta()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nota = "Limite 400k UYU"
            };
            Assert.AreEqual("Limite 400k UYU", tarjeta.Nota);
        }

        [TestMethod]
        public void TarjetaGetNotaCambiada()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nota = "Limite 400k UYU"
            };
            tarjeta.Nota = "Nota nueva";
            Assert.AreEqual("Nota nueva", tarjeta.Nota);
        }

        [TestMethod]
        public void TarjetaLargoNotaMayorA250()
        {
            Tarjeta tarjeta = new Tarjeta();
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "T";
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Nota = notaDemasiadoLarga);
        }

        [TestMethod]
        public void TarjetaEqualsMismoNumero()
        {
            Tarjeta tarjeta1 = new Tarjeta
            {
                Numero = "1234567890123456"
            };
            Tarjeta tarjeta2 = new Tarjeta
            {
                Numero = "1234567890123456"
            };
            Assert.AreEqual(tarjeta1, tarjeta2);
        }

        [TestMethod]
        public void TarjetaNotEqualsDiferenteNumero()
        {
            Tarjeta tarjeta1 = new Tarjeta
            {
                Numero = "1234567890123456"
            };
            Tarjeta tarjeta2 = new Tarjeta
            {
                Numero = "6543210987654321"
            };
            Assert.AreNotEqual(tarjeta1, tarjeta2);
        }

        [TestMethod]
        public void TarjetaEqualsNull()
        {
            Tarjeta tarjeta1 = new Tarjeta
            {
                Numero = "1234567890123456"
            };
            Tarjeta tarjeta2 = null;
            Assert.ThrowsException<ObjetoIncompletoException>(() => tarjeta1.Equals(tarjeta2));
        }

        [TestMethod]
        public void TarjetaEqualsConString()
        {
            Tarjeta tarjeta = new Tarjeta
            {
                Numero = "1234567890123456"
            };
            String noEsTarjeta = "1234567890123456";
            Assert.ThrowsException<ObjetoIncorrectoException>(() => tarjeta.Equals(noEsTarjeta));
        }

    }
}
