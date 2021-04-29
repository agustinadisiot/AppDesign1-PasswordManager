using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TestsObligatorio
{

    [TestClass]
    public class TestTarjeta
    {
        //Prueba si devuelve el nombre correcto de la tarjeta.
        [TestMethod]
        public void TarjetaGetNombreVisaGold()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold"
            };
            Assert.AreEqual("Visa Gold", tarjeta.Nombre);
        }

        //Prueba si al cambiar el nombre a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void TarjetaGetNombreCambio()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nombre = "Visa Gold"
            };
            Assert.AreEqual("Visa Gold", tarjeta.Nombre);
            tarjeta.Nombre = "American";
            Assert.AreEqual("American", tarjeta.Nombre);
        }

        //Prueba si al ingresar un nombre a una tarjeta con largo menor a 3, devuelve un error.
        [TestMethod]
        public void TarjetaLargoNombreMenorA3()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Nombre = "A");
        }

        //Prueba si al ingresar un nombre a una tarjeta con largo meyor a 25, devuelve un error.
        [TestMethod]
        public void TarjetaLargoNombreMayorA25()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Nombre = "NombreDeTarjetaDemasiadoLargo");
        }

        //Prueba si devuelve el tipo correcto de la tarjeta.
        [TestMethod]
        public void TarjetaGetTipoVisa()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Tipo = "Visa"
            };
            Assert.AreEqual("Visa", tarjeta.Tipo);
        }

        //Prueba si al cambiar el tipo a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void TarjetaGetTipoCambio()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Tipo = "Visa"
            };
            Assert.AreEqual("Visa", tarjeta.Tipo);
            tarjeta.Tipo = "MasterCard";
            Assert.AreEqual("MasterCard", tarjeta.Tipo);
        }

        //Prueba si al ingresar un tipo a una tarjeta con largo menor a 3, devuelve un error.
        [TestMethod]
        public void TarjetaLargoTipoMenorA3()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Tipo = "A");
        }

        //Prueba si al ingresar un tipo a una tarjeta con largo mayor a 25, devuelve un error.
        [TestMethod]
        public void TarjetaLargoTipoMayorA25()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Tipo = "TipoDemasiadoLargoNoPermitido");
        }

        //Prueba si devuelve el numero correcto de la tarjeta.
        [TestMethod]
        public void TarjetaGetNumeroTarjeta()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Numero = "1234567812345678"
            };
            Assert.AreEqual("1234567812345678", tarjeta.Numero);
        }

        //Prueba si al cambiar el numero a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void TarjetaGetNumeroCambio()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Numero = "1234567812345678"
            };
            Assert.AreEqual("1234567812345678", tarjeta.Numero);
            tarjeta.Numero = "8765432187654321";
            Assert.AreEqual("8765432187654321", tarjeta.Numero);
        }

        //Prueba si al ingresar un numero a una tarjeta con largo menor a 16, devuelve un error.
        [TestMethod]
        public void TarjetaLargoNumeroMenorA16()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Numero = "1215412");
        }

        //Prueba si al ingresar un numero a una tarjeta con largo mayor a 16, devuelve un error.
        [TestMethod]
        public void TarjetaLargoNumeroMayorA16()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Numero = "123456781223456781234");
        }

        //Prueba si al ingresar un numero a una tarjeta con letras, devuelve un error.
        [TestMethod]
        public void TarjetaLargoNumeroConLetras()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Numero = "12345BCdA2345678");
        }

        //Prueba si al ingresar un numero a una tarjeta con simbolos, devuelve un error.
        [TestMethod]
        public void TarjetaLargoNumeroConSimbolos()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Numero = "12345#$%@2345678");
        }

        //Prueba si devuelve el codigo correcto de la tarjeta.
        [TestMethod]
        public void TarjetaGetCodigoTarjeta()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Codigo = "123"
            };
            Assert.AreEqual("123", tarjeta.Codigo);
        }

        //Prueba si al cambiar el codigo a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void TarjetaGetCodigoCambio()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Codigo = "123"
            };
            Assert.AreEqual("123", tarjeta.Codigo);
            tarjeta.Codigo = "3241";
            Assert.AreEqual("3241", tarjeta.Codigo);
        }

        //Prueba si al ingresar un codigo a una tarjeta con largo menor a 3, devuelve un error.
        [TestMethod]
        public void TarjetaLargoCodigoMenorA3()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Codigo = "12");
        }

        //Prueba si al ingresar un codigo a una tarjeta con largo mayor a 4, devuelve un error.
        [TestMethod]
        public void TarjetaLargoCodigoMayorA4()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Codigo = "12345");
        }

        //Prueba si al ingresar un numero a una tarjeta con letras, devuelve un error.
        [TestMethod]
        public void TarjetaLargoCodigoConLetras()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Codigo = "12B");
        }

        //Prueba si al ingresar un numero a una tarjeta con simbolos, devuelve un error.
        [TestMethod]
        public void TarjetaLargoCodigoConSimbolos()
        {
            Tarjeta tarjeta = new Tarjeta();
            Assert.ThrowsException<CaracterInesperadoException>(() => tarjeta.Codigo = "12**");
        }

        //Prueba si devuelve la fecha de vencimiento correcto de la tarjeta.
        [TestMethod]
        public void TarjetaGetVencimientoTarjeta()
        {
            Tarjeta tarjeta = new Tarjeta();
            DateTime date1 = new DateTime(2025, 7, 1);
            tarjeta.Vencimiento = date1;
            Assert.AreEqual("07/2025", tarjeta.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }

        //Prueba si devuelve la fecha de vencimiento correcto de la tarjeta.
        [TestMethod]
        public void TarjetaGetVencimientoCambio()
        {
            Tarjeta tarjeta = new Tarjeta();
            DateTime date1 = new DateTime(2025, 7, 1);
            tarjeta.Vencimiento = date1;
            Assert.AreEqual("07/2025", tarjeta.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
            DateTime date2 = new DateTime(2023, 8, 1);
            tarjeta.Vencimiento = date2;
            Assert.AreEqual("08/2023", tarjeta.Vencimiento.ToString("MM/yyyy", CultureInfo.InvariantCulture));
        }

        //Prueba si devuelve la nota correcta de la tarjeta.
        [TestMethod]
        public void TarjetaGetNotaTarjeta()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nota = "Limite 400k UYU"
            };
            Assert.AreEqual("Limite 400k UYU", tarjeta.Nota);
        }

        //Prueba si al cambiar la nota a la tarjeta, cambia lo que devuelve.
        [TestMethod]
        public void TarjetaGetNotaCambio()
        {
            Tarjeta tarjeta = new Tarjeta()
            {
                Nota = "Limite 400k UYU"
            };
            Assert.AreEqual("Limite 400k UYU", tarjeta.Nota);
            tarjeta.Nota = "Nota nueva";
            Assert.AreEqual("Nota nueva", tarjeta.Nota);
        }

        //Prueba si al ingresar una nota a una tarjeta con largo mayor a 250, devuelve un error.
        [TestMethod]
        public void TarjetaLargoNotaMayorA250()
        {
            Tarjeta tarjeta = new Tarjeta();
            string notaDemasiadoLarga = "";
            for (int i = 0; i < 251; i++) notaDemasiadoLarga += "T";
            Assert.ThrowsException<LargoIncorrectoException>(() => tarjeta.Nota = notaDemasiadoLarga);
        }

        //Prueba de comparar dos Tarjetas con mismo numero el equals da true 
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

        //Prueba de comparar dos Tarjetas con diferente numero el equals da false 
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

        //Prueba de comparar una Tarjeta con un null
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

        //Prueba de comparar una Tarjeta con un string, para verificar que se controle el tipo recibido en el equals.
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
