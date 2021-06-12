using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz.InterfacesSeguridad
{
    public partial class ReporteDeFortaleza : UserControl
    {
        private ControladoraUsuario _usuarioActual;

        public ReporteDeFortaleza(ControladoraUsuario actual)
        {
            InitializeComponent();
            _usuarioActual = actual;
        }

        private void ReporteDeFortaleza_Load(object sender, EventArgs e)
        {
            this.CargarTablaReporte();
            this.TablaReporte.SelectionChanged += TablaReporte_SelectionChanged;
        }

        private void TablaReporte_SelectionChanged(object sender, EventArgs e)
        {
            var rowsCount = this.TablaReporte.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;

            var row = this.TablaReporte.SelectedRows[0];
            if (row == null) return;
           CargarTablaClaves();
        }

        private void CargarTablaClaves()
        {
            string formatoFecha = "dd'/'MM'/'yyyy";
            this.tablaClaves.Rows.Clear();
            if (this.TablaReporte.SelectedCells.Count > 0)
            {
                int selectedrowindex = TablaReporte.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = TablaReporte.Rows[selectedrowindex];
                string color = Convert.ToString(selectedRow.Cells["Color"].Value);

                List<ControladoraClave> listaClaves = this._usuarioActual.GetListaClavesColor(color);

                foreach (ControladoraClave claveActual in listaClaves)
                {
                    string nombreCategoria = this._usuarioActual.GetCategoriaClave(claveActual).Nombre;
                    string sitio = claveActual.Sitio;
                    string usuario = claveActual.UsuarioClave;
                    string ultimaModificacion = claveActual.FechaModificacion.ToString(formatoFecha);
                    this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
                }
            }
        }

        private void CargarTablaReporte()
        {
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            int cantidadRojos = _usuarioActual.GetCantidadColor(color.Rojo);
            int cantidadNaranja = _usuarioActual.GetCantidadColor(color.Naranja);
            int cantidadAmarillo = _usuarioActual.GetCantidadColor(color.Amarillo);
            int cantidadVerdeClaro = _usuarioActual.GetCantidadColor(color.VerdeClaro);
            int cantidadVerdeOscuro = _usuarioActual.GetCantidadColor(color.VerdeOscuro);

            this.TablaReporte.Rows.Add(color.Rojo, cantidadRojos);
            this.TablaReporte.Rows.Add(color.Naranja, cantidadNaranja);
            this.TablaReporte.Rows.Add(color.Amarillo, cantidadAmarillo);
            this.TablaReporte.Rows.Add(color.VerdeClaro, cantidadVerdeClaro);
            this.TablaReporte.Rows.Add(color.VerdeOscuro, cantidadVerdeOscuro);

        }

        private void botonGrafica_Click(object sender, EventArgs e)
        {
            AbrirGrafica();
        }

        public delegate void AbrirGrafica_Delegate();
        public event AbrirGrafica_Delegate AbrirGrafica_Event;
        public void AbrirGrafica()
        {
            if (this.AbrirGrafica_Event != null)
                this.AbrirGrafica_Event();
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
                    Sitio = sitioClaveAMostrar,
                    UsuarioClave = usuarioClaveAMostrar
                };

                AbrirVerClave(buscadora, _usuarioActual);
            }
        }

        public delegate void AbrirVerClave_Delegate(ControladoraClave buscadora, ControladoraUsuario usuarioActual);
        public event AbrirVerClave_Delegate AbrirVerClave_Event;
        private void AbrirVerClave(ControladoraClave buscadora, ControladoraUsuario usuarioActual)
        {
            if (this.AbrirVerClave_Event != null)
                this.AbrirVerClave_Event(buscadora, usuarioActual);
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
                    Sitio = sitioClave,
                    UsuarioClave = usuarioClave
                };

                IrAModificarClave(aModificar);
            }
        }

        public delegate void AbrirModificarClave_Delegate(ControladoraClave claveAModificar);
        public event AbrirModificarClave_Delegate AbrirModificarClave_Event;
        public void IrAModificarClave(ControladoraClave claveAModificar)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(claveAModificar);
        }
    }
}
