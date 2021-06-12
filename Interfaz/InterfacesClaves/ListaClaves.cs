﻿using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaClaves : UserControl
    {
        private ControladoraUsuario _usuarioActual;

        public ListaClaves(ControladoraUsuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
        }

        private void ListaClaves_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void CargarTabla()
        {
            string formatoFecha = "dd'/'MM'/'yyyy";
            this.tablaClaves.Rows.Clear();
            List<ControladoraClave> listaClaves = this._usuarioActual.GetListaClaves();

            foreach (ControladoraClave claveActual in listaClaves)
            {
                string nombreCategoria = this._usuarioActual.GetCategoriaClave(claveActual).Nombre;
                string sitio = claveActual.VerificarSitio;
                string usuario = claveActual.verificarUsuarioClave;
                string ultimaModificacion = claveActual.FechaModificacion.ToString(formatoFecha);
                this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
            }
        }

        private void CerrarConfirmacion_Handler(bool acepto)
        {
            bool haySeleccionada = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionada && acepto)
            {
                int posSeleccionada = this.tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaClaves.Rows[posSeleccionada];

                string usuarioClaveBorrar = Convert.ToString(selectedRow.Cells["Usuario"].Value);
                string sitioClaveBorrar = Convert.ToString(selectedRow.Cells["Sitio"].Value);

                ControladoraClave buscadora = new ControladoraClave()
                {
                    verificarUsuarioClave = usuarioClaveBorrar,
                    VerificarSitio = sitioClaveBorrar
                };
                this._usuarioActual.BorrarClave(buscadora);
                this.CargarTabla();
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            IrACrearClave();
        }

        private void botonCompartir_Click(object sender, EventArgs e)
        {
            bool haySeleccionado = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionado)
            {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                string sitioClave = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                string usuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                ControladoraClave claveACompartir = new ControladoraClave()
                {
                    VerificarSitio = sitioClave,
                    verificarUsuarioClave = usuarioClave
                };

                ControladoraUsuario compartidor = this._usuarioActual;

                ClaveCompartida aCompartir = new ClaveCompartida()
                {
                    Original= compartidor,
                    Clave = claveACompartir
                };

                IrACompartirClave(aCompartir);
            }

        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                string texto = "¿Estas seguro que quieres eliminar esta contraseña?";
                VentanaConfirmaciones ventanaConfirmar = new VentanaConfirmaciones(texto);
                ventanaConfirmar.CerrarConfirmacion_Event += CerrarConfirmacion_Handler;
                ventanaConfirmar.ShowDialog();
            }
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            string sitioClave = "";
            string usuarioClave = "";
            if (this.tablaClaves.SelectedCells.Count > 0)
            {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                sitioClave = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                usuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                ControladoraClave aModificar = new ControladoraClave()
                {
                    VerificarSitio = sitioClave,
                    verificarUsuarioClave = usuarioClave
                };

                IrAModificarClave(aModificar);
            }
        }

        private void botonVer_Click(object sender, EventArgs e)
        {

            bool haySeleccionada = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                int posSeleccionada = this.tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaClaves.Rows[posSeleccionada];

                string sitioClaveAMostrar = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                string usuarioClaveAMostrar = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                ControladoraClave buscadora = new ControladoraClave
                {
                    VerificarSitio = sitioClaveAMostrar,
                    verificarUsuarioClave = usuarioClaveAMostrar
                };

                AbrirVerClave(buscadora, _usuarioActual);
            }
        }

        public delegate void AbrirModificarClave_Delegate(ControladoraClave claveAModificar);
        public event AbrirModificarClave_Delegate AbrirModificarClave_Event;
        public void IrAModificarClave(ControladoraClave claveAModificar)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(claveAModificar);
        }

        public delegate void AbrirCrearClave_Delegate();
        public event AbrirCrearClave_Delegate AbrirCrearClave_Event;
        public void IrACrearClave()
        {
            if (this.AbrirCrearClave_Event != null)
                this.AbrirCrearClave_Event();
        }

        public delegate void AbrirCompartirClave_Delegate(ClaveCompartida aCompartir);
        public event AbrirCompartirClave_Delegate AbrirCompartirClave_Event;
        public void IrACompartirClave(ClaveCompartida aCompartir)
        {
            if (this.AbrirCompartirClave_Event != null)
                this.AbrirCompartirClave_Event(aCompartir);
        }


        public delegate void AbrirVerClave_Delegate(ControladoraClave buscadora, ControladoraUsuario usuarioActual);
        public event AbrirVerClave_Delegate AbrirVerClave_Event;
        private void AbrirVerClave(ControladoraClave buscadora, ControladoraUsuario usuarioActual)
        {
            if (this.AbrirVerClave_Event != null)
                this.AbrirVerClave_Event(buscadora, usuarioActual);
        }
    }
}
