using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
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
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VentanaPrincipal());
            /*
            Tarjeta tarjeta1 = new Tarjeta()
            {
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
            AdministradorClavesDBContext contexto = new AdministradorClavesDBContext();

            DataAccessTarjeta daTarjeta = new DataAccessTarjeta();
            List<Tarjeta> tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();

            foreach (Tarjeta tarjeta in tarjetas) {
                daTarjeta.Borrar(tarjeta);
            }

            daTarjeta.Agregar(tarjeta1);
            tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
            Console.ReadLine();*/
        }
    }
}
