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

            Categoria categoria1 = new Categoria()
            {
                Nombre = "Personal"
            };

            Categoria categoria2 = new Categoria()
            {
                Nombre = "Trabajo"
            };

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



            foreach (Tarjeta tarjeta in tarjetas)
            {
                daTarjeta.Borrar(tarjeta);
            }

            categoria1.AgregarTarjeta(tarjeta1);
            categoria2.AgregarTarjeta(tarjeta2);

            daTarjeta.Agregar(tarjeta1);
            daTarjeta.Agregar(tarjeta2);

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

            categoria1.AgregarClave(clave1);

            DataAccessClave daClave = new DataAccessClave();
            List<Clave> claves = (List<Clave>)daClave.GetTodos();

            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();

            foreach (Clave clave in claves)
            {
                daClave.Borrar(clave);
            }

            daClave.Agregar(clave1);
            daClave.Agregar(clave2);

            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();


            //Filtradas
            List<string> datosString = new List<string>
            {
                "clave1",
                "EstoEsUnaClave1",
                "claveDeNetflix"
            };

            DataAccessFiltrada daFiltrada = new DataAccessFiltrada();

            List<Filtrada> borrarFiltradas = (List<Filtrada>)daFiltrada.GetTodos();

            foreach (Filtrada filtrada in borrarFiltradas)
            {
                daFiltrada.Borrar(filtrada);
            }

            Filtrada noAgregada = new Filtrada("noAgregada");
            daFiltrada.Agregar(noAgregada);

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
                daClave.Get(clave1.Id)
            };

            List<Tarjeta> tarjetasFiltradas = new List<Tarjeta>()
            {
                daTarjeta.Get(tarjeta2.Id)
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

            daDataBreach.Agregar(dataBreach);

            dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();

            DataBreach dataBreach2 = daDataBreach.Get(dataBreach.Id);
            //new DataBreach() { Id = dataBreach.Id};

            List<Tarjeta> tarjetasModificar = new List<Tarjeta>()
            {
                daTarjeta.Get(tarjeta1.Id)
            };


            //dataBreach2.Tarjetas.Add(tarjeta1);
            dataBreach2.Filtradas.Add(new Filtrada(clave2.Codigo));
            dataBreach2.Filtradas.Add(noAgregada);

            dataBreach2.Tarjetas = tarjetasModificar;
            dataBreach2.Fecha = new DateTime(2000,1,1);

            dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();

            daDataBreach.Modificar(dataBreach2);
            DataBreach dataBreachDespues = daDataBreach.Get(dataBreach.Id);

            dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();

            Tarjeta aModificar = daTarjeta.Get(tarjeta2.Id);
            aModificar.Nombre = "Agustina";
            aModificar.Numero = "5555555555555555";
            aModificar.Tipo = "cambio";
            aModificar.Nota = "Colorin Colorado, esta tarjeta se ha cambiado.";
            aModificar.Codigo = "333";
            aModificar.Vencimiento = DateTime.Now;

            daTarjeta.Modificar(aModificar);
            Tarjeta tarjetaDespues = daTarjeta.Get(tarjeta2.Id);
            dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();


            DataAccessCategoria daCategoria = new DataAccessCategoria();
            List<Categoria> categorias;

            List<Categoria> borrarCategoria = (List<Categoria>)daCategoria.GetTodos();

            foreach (Categoria categoria in borrarCategoria)
            {
                daCategoria.Borrar(categoria);
            }

            daCategoria.Agregar(categoria1);


            dataBreaches = (List<DataBreach>)daDataBreach.GetTodos();
            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();
            categorias = (List<Categoria>)daCategoria.GetTodos();

            Categoria categoriaAModificar = daCategoria.Get(categoria1.Id);

            Clave clave3 = new Clave()
            {
                Sitio = "Clave3",
                Codigo = "Clave3",
                UsuarioClave = "Clave3",
                Nota = "Nota de una clave3"
            };

            categoriaAModificar.BorrarClave(clave1);
            daCategoria.Modificar(categoriaAModificar);

            categoriaAModificar.AgregarClave(clave3);
            daCategoria.Modificar(categoriaAModificar);

            claves = (List<Clave>)daClave.GetTodos();
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            filtradas = (List<Filtrada>)daFiltrada.GetTodos();
            categorias = (List<Categoria>)daCategoria.GetTodos();

            Console.ReadLine();

        }
    }
}
