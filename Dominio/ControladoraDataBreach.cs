using Negocio;
using Repositorio;
using System;
using System.Collections.Generic;

namespace LogicaDeNegocio
{
    public class ControladoraDataBreach
    {
        public void AgregarDataBreach(List<Filtrada> filtradas, DateTime tiempoBreach, Usuario contenedor)
        {
            ControladoraFiltradas filtradora = new ControladoraFiltradas();
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            DataBreach nuevoBreach = new DataBreach()
            {
                Tarjetas = filtradora.FiltrarTarjetas(filtradas, controladoraUsuario.GetListaTarjetas(contenedor)),
                Claves = filtradora.FiltrarClaves(filtradas, controladoraUsuario.GetListaTarjetas(contenedor)),
                Filtradas = filtradas,
                Fecha = tiempoBreach
            };
            contenedor.DataBreaches.Add(nuevoBreach);

            DataAccessUsuario acceso = new DataAccessUsuario();
            acceso.Modificar(contenedor);
        }
    }
}