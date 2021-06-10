using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

/*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VentanaPrincipal());
*/


            //Tarjetas
            Tarjeta tarjeta1 = new Tarjeta()
            {
                Id=100,
                Numero = "1111111111111111",
                Nombre = "Prex",
                Tipo = "Mastercard",
                Codigo = "321",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)

            };
            Tarjeta tarjeta2 = new Tarjeta()
            {
                Numero = "2222222222222222",
                Nombre = "Visa Gold",
                Tipo = "Visa",
                Codigo = "345",
                Nota = "",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            DataAccessTarjeta daTarjeta = new DataAccessTarjeta();
            List<Tarjeta> tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();


            /*Tarjeta tarjetaModificar = new Tarjeta()
            {
                Id = tarjetas.First().Id,
                Numero = "3333333333333333",
                Nombre = "MasterCard",
                Tipo = "Cambio",
                Codigo = "543",
                Nota = "Cambio",
                Vencimiento = new DateTime(2030, 7, 1)
            };*/

            foreach (Tarjeta tarjeta in tarjetas)
            {
                daTarjeta.Borrar(tarjeta);
            }

            daTarjeta.Agregar(tarjeta2);

            /*daTarjeta.Modificar(tarjetaModificar);*/


            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();


            //Claves
            Clave clave1 = new Clave()
            {
                Sitio = "web.whatsapp.com",
                Codigo = "EstaEsUnaClave1",
                UsuarioClave = "Roberto",
                Nota = ""
            };

            Clave clave2 = new Clave()
            {
                Sitio = "Netflix.com",
                Codigo = "EstaEsUnaClave2",
                UsuarioClave = "Luis88",
                Nota = "Nota de una clave"
            };

            DataAccessClave daClave = new DataAccessClave();
            List<Clave> claves = (List<Clave>)daClave.GetTodos();

            foreach (Clave clave in claves)
            {
                daClave.Borrar(clave);
            }

            daClave.Agregar(clave1);
            claves = (List<Clave>)daClave.GetTodos();

            //Filtradas
            List<string> datosString = new List<string>
            {
                "clave1",
                "EstoEsUnaClave1",
                "2222222222222222",
                "claveDeNetflix"
            };

            DataAccessFiltrada daFiltrada = new DataAccessFiltrada();

            List<Filtrada> borrarFiltradas = (List<Filtrada>)daFiltrada.GetTodos();

            foreach (Filtrada filtrada in borrarFiltradas)
            {
                daFiltrada.Borrar(filtrada);
            }

            List<Filtrada> datos = datosString.Select(s => new Filtrada(s)).ToList();

            LogicaDataBreach logicaDataBreach = new LogicaDataBreach();

            DataAccessDataBreach daDataBreach = new DataAccessDataBreach();
            List<DataBreach> dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();

            foreach (DataBreach db in dataBreaches)
            {
                daDataBreach.Borrar(db);
            }

            //DataBreach
            List<Clave> clavesFiltradas = new List<Clave>()
            {
                clave1
            };

            List<Tarjeta> tarjetasFiltradas = new List<Tarjeta>()
            {
                tarjeta2,
            };

            DataBreach dataBreach = new DataBreach()
            {
                Fecha = DateTime.Now,
                Claves = clavesFiltradas,
                Tarjetas = tarjetasFiltradas,
                Filtradas = datos
            };

            List<Filtrada> filtradas;

            dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();

            //0 DataBreaches
            //1 Clave
            //1 Tarjeta
            //0 Filtradas

            daDataBreach.Agregar(dataBreach);

            /* DataBreach dataBreach2 = daDataBreach.Get(dataBreach.Id);


             Clave clave12 = daClave.Get(clave1.Id);

             Tarjeta tarjeta22 = daTarjeta.Get(tarjeta2.Id);


             dataBreach2.Claves.Add(clave12);
             dataBreach2.Tarjetas.Add(tarjeta22);*/


            /*using (var contexto = new AdministradorClavesDBContext())
            {
                DataBreach dataBreach2 = daDataBreach.Get(dataBreach.Id);
                

                Clave clave12 = daClave.Get(clave1.Id);
                
                Tarjeta tarjeta22 = daTarjeta.Get(tarjeta2.Id);
                

                contexto.DataBreaches.Attach(dataBreach2);
                contexto.Claves.Attach(clave12);
                contexto.Tarjetas.Attach(tarjeta22);

                dataBreach2.Claves.Add(clave12);
                dataBreach2.Tarjetas.Add(tarjeta22);

                contexto.SaveChanges();
            }*/

            //1 DataBreaches
            //1 Clave
            //1 Tarjeta
            //4 Filtradas

            dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();
            Console.ReadLine();

        }
    }
}
