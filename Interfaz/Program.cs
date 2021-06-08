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
           AdministradorClavesDBContext contexto = new AdministradorClavesDBContext();


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

           DataAccessTarjeta daTarjeta = new DataAccessTarjeta();
           List<Tarjeta> tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();

           foreach (Tarjeta tarjeta in tarjetas) {
               daTarjeta.Borrar(tarjeta);
           }

           daTarjeta.Agregar(tarjeta1);
           tarjetas = (List<Tarjeta>)daTarjeta.GetTodos();
           Console.ReadLine();

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
           daClave.Agregar(clave1);
           claves = (List<Clave>)daClave.GetTodos();

           Console.ReadLine();
           */
        }
    }
}
