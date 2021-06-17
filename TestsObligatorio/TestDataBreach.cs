using LogicaDeNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestsObligatorio
{
    [TestClass]
    public class TestDataBreach
    {
        private IngresoDataBreachTxt ingresoDataBreachTxt;
        private IngresoDataBreachUI ingresoDataBreachUI;

        [TestCleanup]
        public void TearDown() { }

        [TestInitialize]
        public void Setup()
        {
            ingresoDataBreachTxt = new IngresoDataBreachTxt();
            ingresoDataBreachUI = new IngresoDataBreachUI();
        }

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
            string separador = Environment.NewLine;
            string linea = "clave1" + separador + "EstoEsUnaClave" + separador + "1234567890987634" + separador + "claveDeNetflix";
            List<string> datosString = new List<string>
            {
                "clave1",
                "EstoEsUnaClave",
                "1234567890987634",
                "claveDeNetflix"
            };

            List<Filtrada> datos = datosString.Select(s => new Filtrada(s)).ToList();
            List<Filtrada> resultado = ingresoDataBreachUI.DevolverFiltradas(linea);
            bool secuencia = datos.SequenceEqual(resultado);
            Assert.IsTrue(secuencia);
        }

        [TestMethod]
        public void LogicaDataBreachLeerArchivoNoExistente()
        {
            string direccion = "direccionNoExistente.txt"; 

            Assert.ThrowsException<ArchivoNoExistenteException>(() => ingresoDataBreachTxt.DevolverFiltradas(direccion));
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

            List<Filtrada> archivoLeido = ingresoDataBreachTxt.DevolverFiltradas(nombreArchivo);

            Assert.IsTrue(datos.SequenceEqual(archivoLeido));
        }
    }


    [TestClass]
    public class TestUsuarioDataBreaches
    {
        private ControladoraAdministrador controladoraAdministrador;
        private ControladoraDataBreach controladoraDataBreach;
        private ControladoraUsuario controladoraUsuario;
        private ControladoraCategoria controladoraCategoria;
        private Usuario usuario;
        private Clave clave1;
        private Clave clave2;
        private Clave clave3;
        private Clave clave4;
        private Categoria categoria1;
        private Categoria categoria2;
        private Tarjeta tarjeta1;
        private Tarjeta tarjeta2;
        private Tarjeta tarjeta3;
        private DateTime tiempoActual;

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            controladoraAdministrador = new ControladoraAdministrador();
            controladoraDataBreach = new ControladoraDataBreach();
            controladoraUsuario = new ControladoraUsuario();
            controladoraCategoria = new ControladoraCategoria();

            controladoraAdministrador.BorrarTodo();
            
            tiempoActual = DateTime.Now;

            usuario = new Usuario()
            {
                Nombre = "Usuario1",
                ClaveMaestra = "ClaveMaestra"
            };

            categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };
            controladoraAdministrador.AgregarUsuario(usuario);
            controladoraUsuario.AgregarCategoria(categoria1,usuario);

            categoria2 = new Categoria()
            {
                Nombre = "Estudio"
            };

            controladoraUsuario.AgregarCategoria(categoria2, usuario);

            clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto",
                Nota = ""
            };

            controladoraCategoria.AgregarClave(clave1, categoria1);

            clave2 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = ""
            };

            controladoraCategoria.AgregarClave(clave2, categoria1);

            clave3 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave3",
                UsuarioClave = "Hernesto",
                Nota = ""
            };

            controladoraCategoria.AgregarClave(clave3, categoria2);

            clave4 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave4",
                UsuarioClave = "Peepo",
                Nota = ""
            };
            controladoraCategoria.AgregarClave(clave4, categoria2);
            
            tarjeta1 = new Tarjeta()
            {
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            controladoraUsuario.AgregarTarjeta(tarjeta1, categoria1, usuario);

            tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            controladoraUsuario.AgregarTarjeta(tarjeta2, categoria2, usuario);

            tarjeta3 = new Tarjeta()
            {
                Numero = "3333333333333333",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            controladoraUsuario.AgregarTarjeta(tarjeta3, categoria1, usuario);

        }


        [TestMethod]
        public void UsuarioGetUltimoDataBreachVacioRetornaListaVacia()
        {
            List<Filtrada> filtradas = new List<Filtrada>();

            controladoraDataBreach.AgregarDataBreach(filtradas, tiempoActual, usuario);

            DataBreach ultimo = controladoraUsuario.GetUltimoDataBreach(usuario);

            Assert.IsTrue(ultimo.Claves.Count == 0 && ultimo.Tarjetas.Count == 0);
        }


        [TestMethod]
        public void UsuarioGetDataBreachNoVacioClaves()
        {
            List<string> filtradasString = new List<string>() {
                "EstaEsUnaClave1",
                "EstaEsUnaClave4"
            };

            List<Clave> esperadas = new List<Clave>() {
                clave1,
                clave4
            };

            List<Filtrada> filtradas = filtradasString.Select(s => new Filtrada(s)).ToList();

            controladoraDataBreach.AgregarDataBreach(filtradas, tiempoActual, usuario);

            DataBreach resultadoBreach = controladoraUsuario.GetUltimoDataBreach(usuario);

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

            List<Clave> esperadas = new List<Clave>() {
                clave3
            };

            controladoraDataBreach.AgregarDataBreach(filtradas, tiempoActual, usuario);

            DataBreach resultado = controladoraUsuario.GetUltimoDataBreach(usuario);

            bool esperadasContieneRetorno = resultado.Claves.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Claves.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }


        [TestMethod]
        public void UsuarioGetTarjetasDataBreachVacio()
        {
            List<string> filtradasString = new List<string>();
            List<Filtrada> filtradas = filtradasString.Select(s => new Filtrada(s)).ToList();

            controladoraDataBreach.AgregarDataBreach(filtradas, tiempoActual, usuario);

            DataBreach resultado = controladoraUsuario.GetUltimoDataBreach(usuario);


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

            List<Tarjeta> esperadas = new List<Tarjeta>() {
                tarjeta1,
                tarjeta3
            };

            controladoraDataBreach.AgregarDataBreach(filtradas, tiempoActual, usuario);

            DataBreach resultado = controladoraUsuario.GetUltimoDataBreach(usuario);

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

            controladoraDataBreach.AgregarDataBreach(primerasFiltradas, tiempoActual, usuario);
            DataBreach resultado = controladoraUsuario.GetUltimoDataBreach(usuario);
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

            List<Tarjeta> esperadas = new List<Tarjeta>() {
                tarjeta2
            };

            DateTime tiempoViejo = new DateTime(2000, 1, 1, 1, 0, 0);
            DateTime tiempoNuevo = new DateTime(2000, 1, 1, 2, 0, 0);
            controladoraDataBreach.AgregarDataBreach(primerasFiltradas, tiempoViejo, usuario);
            controladoraDataBreach.AgregarDataBreach(segundasFiltradas, tiempoNuevo, usuario);

            DataBreach resultado = controladoraUsuario.GetDataBreach(tiempoViejo, usuario);

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

            controladoraDataBreach.AgregarDataBreach(filtradas, tiempoActual, usuario);
            DataBreach resultado = controladoraUsuario.GetUltimoDataBreach(usuario);

            bool esperadasContieneRetorno = resultado.Filtradas.All(esperadas.Contains);
            bool retornoContieneEsperadas = esperadas.All(resultado.Filtradas.Contains);
            Assert.IsTrue(esperadasContieneRetorno && retornoContieneEsperadas);
        }
    }
}
