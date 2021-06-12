using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsObligatorio
{
    [TestClass]
    public class TestDataBreach {
        [TestMethod]
        public void DataBreachValoresNull() {
            DataBreach nuevo = new DataBreach();

            bool fechaNull = nuevo.Fecha == null;
            bool tarjetasNull = nuevo.Tarjetas == null;
            bool clavesNull = nuevo.Claves == null;
            bool filtradasNull = nuevo.Filtradas == null;
            Assert.IsFalse(fechaNull || tarjetasNull || clavesNull || filtradasNull);

        }

        [TestMethod]
        public void LogicaDataBreachSepararPorLineas()
        {
            string linea = "clave1\tEstoEsUnaClave\t1234567890987634\tclaveDeNetflix";
            List<string> datosString = new List<string>
            {
                "clave1",
                "EstoEsUnaClave",
                "1234567890987634",
                "claveDeNetflix"
            };

            List<Filtrada> datos = datosString.Select(s => new Filtrada(s)).ToList();

            ControladoraDataBreach logicaDataBreach = new ControladoraDataBreach();
            Assert.IsTrue(datos.SequenceEqual(logicaDataBreach.SepararPorLineas(linea)));
        }

        [TestMethod]
        public void LogicaDataBreachLeerArchivoNoExistente()
        {
            string direccion = "direccionNoExistente.txt"; 

            ControladoraDataBreach logicaDataBreach = new ControladoraDataBreach();
            Assert.ThrowsException<ArchivoNoExistenteException>(() => logicaDataBreach.LeerArchivo(direccion));
        }

        [TestMethod]
        public void LogicaDataBreachLeerArchivo()
        {
            string nombreArchivo = "test.txt";
            using (StreamWriter streamWriter = new StreamWriter(nombreArchivo))
            {
                string linea = "clave1\tEstoEsUnaClave\t1234567890987634\tclaveDeNetflix";
                streamWriter.WriteLine(linea);
                streamWriter.Close();
            }
    
            List<string> datosString = new List<string>
            {
                "clave1",
                "EstoEsUnaClave",
                "1234567890987634",
                "claveDeNetflix"
            };

            List<Filtrada> datos = datosString.Select(s => new Filtrada(s)).ToList();

            ControladoraDataBreach logicaDataBreach = new ControladoraDataBreach();

            List<Filtrada> archivoLeido = logicaDataBreach.LeerArchivo(nombreArchivo);

            Assert.IsTrue(datos.SequenceEqual(archivoLeido));
        }
    }


    [TestClass]
    public class TestUsuarioDataBreaches
    {
        private ControladoraUsuario usuario;
        private ControladoraClave clave1;
        private ControladoraClave clave2;
        private ControladoraClave clave3;
        private ControladoraClave clave4;
        private ControladoraTarjeta tarjeta1;
        private ControladoraTarjeta tarjeta2;
        private ControladoraTarjeta tarjeta3;
        private DateTime tiempoActual;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            tiempoActual = DateTime.Now;

            usuario = new ControladoraUsuario()
            {
                Nombre = "Usuario1"
            };

            ControladoraCategoria categoria1 = new ControladoraCategoria()
            {
                Nombre = "Personal"
            };

            usuario.AgregarCategoria(categoria1);

            ControladoraCategoria categoria2 = new ControladoraCategoria()
            {
                Nombre = "Estudio"
            };

            usuario.AgregarCategoria(categoria2);

            clave1 = new ControladoraClave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto"
            };
            categoria1.AgregarClave(clave1);
            clave2 = new ControladoraClave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88"
            };
            categoria1.AgregarClave(clave2);

            clave3 = new ControladoraClave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto"
            };
            categoria2.AgregarClave(clave3);
            clave4 = new ControladoraClave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo"
            };
            categoria2.AgregarClave(clave4);
            
            tarjeta1 = new ControladoraTarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta1, categoria1);

            tarjeta2 = new ControladoraTarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta2, categoria2);

            tarjeta3 = new ControladoraTarjeta()
            {
                Numero = "3333333333333333",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            usuario.AgregarTarjeta(tarjeta3, categoria1);

        }



        [TestMethod]
        public void UsuarioGetUltimoDataBreachVacioRetornaListaVacia()
        {
            List<Filtrada> filtradas = new List<Filtrada>();

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach ultimo = usuario.GetUltimoDataBreach();

            Assert.IsTrue(ultimo.Claves.Count == 0 && ultimo.Tarjetas.Count == 0);
        }


        [TestMethod]
        public void UsuarioGetDataBreachNoVacioClaves()
        {
            List<string> filtradasString = new List<string>() {
                "EstaEsUnaClave1",
                "EstaEsUnaClave4"
            };

            List<ControladoraClave> esperadas = new List<ControladoraClave>() {
                clave1,
                clave4
            };

            List<Filtrada> filtradas = filtradasString.Select(s => new Filtrada(s)).ToList();

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultadoBreach = usuario.GetUltimoDataBreach();

            bool esperadasContieneRetorno = resultadoBreach.Claves.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultadoBreach.Claves.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetDataBreachClavesNoExistentes()
        {
            List<string> filtradasString = new List<string>() {
                "ClaveNoContenida",
                "ClaveTampocoContenida",
                "EstaEsUnaClave3"
            };

            List<Filtrada> filtradas = filtradasString.Select(s => new Filtrada(s)).ToList();

            List<ControladoraClave> esperadas = new List<ControladoraClave>() {
                clave3
            };

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultado = usuario.GetUltimoDataBreach();

            bool esperadasContieneRetorno = resultado.Claves.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Claves.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetTarjetasDataBreachVacio()
        {
            List<string> filtradasString = new List<string>();
            List<Filtrada> filtradas = filtradasString.Select(s => new Filtrada(s)).ToList();

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultado = usuario.GetUltimoDataBreach();


            Assert.IsTrue(resultado.Tarjetas.Count == 0);
        }

        [TestMethod]
        public void UsuarioGetTarjetasDataBreachNoVacio()
        {

            List<string> filtradasString = new List<string>() {
                "1111111111111111",
                "UnaClave",
                "3333 3333 3333 3333",
                "4444 4444 4444 4444"
            };

            List<Filtrada> filtradas = filtradasString.Select(s => new Filtrada(s)).ToList();

            List<ControladoraTarjeta> esperadas = new List<ControladoraTarjeta>() {
                tarjeta1,
                tarjeta3
            };

            usuario.agregarDataBreach(filtradas, tiempoActual);

            DataBreach resultado = usuario.GetUltimoDataBreach();

            bool esperadasContieneRetorno = resultado.Tarjetas.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Tarjetas.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }

        [TestMethod]
        public void UsuarioGetFechaHoraDataBreach()
        {
            Filtrada tarjetaFiltrada2 = new Filtrada
            {
                Texto = "2222222222222222"
            };
            Filtrada claveFiltrada2 = new Filtrada
            {
                Texto = "ClaveContenida2"
            };

            List<Filtrada> primerasFiltradas = new List<Filtrada>() {
                tarjetaFiltrada2,
                claveFiltrada2
            };

            usuario.agregarDataBreach(primerasFiltradas, tiempoActual);
            DataBreach resultado = usuario.GetUltimoDataBreach();
            bool mismoTiempo = (resultado.Fecha == tiempoActual);

            Assert.IsTrue(mismoTiempo);
        }

        [TestMethod]
        public void UsuarioGetDataBreachViejo()
        {

            Filtrada tarjetaFiltrada1 = new Filtrada()
            {
                Texto = "1111111111111111"
            };
            Filtrada tarjetaFiltrada2 = new Filtrada
            {
                Texto = "2222222222222222"
            };
            Filtrada tarjetaFiltrada3 = new Filtrada
            {
                Texto = "3333 3333 3333 3333"
            };
            Filtrada tarjetaFiltrada4 = new Filtrada
            {
                Texto = "4444 4444 4444 4444"
            };
            Filtrada claveFiltrada2 = new Filtrada
            {
                Texto = "ClaveContenida2"
            };
            Filtrada claveFiltrada3 = new Filtrada
            {
                Texto = "EstaEsUnaClave3"
            };

            List<Filtrada> primerasFiltradas = new List<Filtrada>() {
                tarjetaFiltrada2,
                claveFiltrada2
            };

            List<Filtrada> segundasFiltradas = new List<Filtrada>() {
                tarjetaFiltrada1,
                claveFiltrada3,
                tarjetaFiltrada3,
                tarjetaFiltrada4
            };

            List<ControladoraTarjeta> esperadas = new List<ControladoraTarjeta>() {
                tarjeta2
            };

            DateTime tiempoViejo = new DateTime(2000, 1, 1, 1, 0, 0);
            DateTime tiempoNuevo = new DateTime(2000, 1, 1, 2, 0, 0);
            usuario.agregarDataBreach(primerasFiltradas, tiempoViejo);
            usuario.agregarDataBreach(segundasFiltradas, tiempoNuevo);

            DataBreach resultado = usuario.GetDataBreach(tiempoViejo);

            bool esperadasContieneRetorno = resultado.Tarjetas.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Tarjetas.Contains);
            Assert.IsTrue(esperadasContieneRetorno&& retornoContieneEsperadas);
        }

        [TestMethod]
        public void GetFiltradasDataBreachViejo()
        {
            Filtrada claveFiltrada1 = new Filtrada
            {
                Texto = "ClaveContenida1"
            };
            Filtrada claveFiltrada2 = new Filtrada
            {
                Texto = "ClaveContenida2"
            };
            Filtrada claveFiltrada3 = new Filtrada
            {
                Texto = "EstaEsUnaClave3"
            };

            List<Filtrada> filtradas = new List<Filtrada>() {
                claveFiltrada1,
                claveFiltrada2,
                claveFiltrada3
            };

            List<Filtrada> esperadas = new List<Filtrada>() {
                claveFiltrada1,
                claveFiltrada2,
                claveFiltrada3
            };

            usuario.agregarDataBreach(filtradas, tiempoActual);
            DataBreach resultado = usuario.GetUltimoDataBreach();

            bool esperadasContieneRetorno = resultado.Filtradas.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Filtradas.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }
    }
}
