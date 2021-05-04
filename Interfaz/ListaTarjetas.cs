﻿using Obligatorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaTarjetas : UserControl
    {
        private Usuario _usuarioActual;
        private AdminContras _administrador;

        public ListaTarjetas(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            this.CargarTabla();
        }

        private void CargarTabla() {
           
            List<Categoria> listaCategorias = this._usuarioActual.GetListaCategorias();

            foreach (Categoria categoriaActual in listaCategorias) {

                string nombreCategoria = categoriaActual.Nombre;
                List<Tarjeta> listaTarjetas = categoriaActual.GetListaTarjetas();
                CargarFila(nombreCategoria, listaTarjetas);
            }
        }


        private void CargarFila(string categoriaActual, List<Tarjeta> listaTarjetas) {

            foreach (Tarjeta tarjetaActual in listaTarjetas) {

                string nombre = tarjetaActual.Nombre;
                string tipo = tarjetaActual.Tipo;
                string numero = tarjetaActual.Numero;
                string vencimiento = tarjetaActual.Vencimiento.ToString();

                this.tablaTarjetas.Rows.Add(categoriaActual, nombre, tipo, numero, vencimiento);
            }
        }
    }
}
