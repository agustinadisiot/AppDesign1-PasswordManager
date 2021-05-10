using Obligatorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.InterfacesSeguridad
{
    public partial class ReporteDeFortaleza : UserControl
    {
        private Usuario _usuarioActual;

        public ReporteDeFortaleza(Usuario actual)
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
            
            this.tablaClaves.Rows.Clear();
            if (this.TablaReporte.SelectedCells.Count > 0)
            {
                int selectedrowindex = TablaReporte.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = TablaReporte.Rows[selectedrowindex];
                string color = Convert.ToString(selectedRow.Cells["Color"].Value);

                List<Contra> listaClaves = this._usuarioActual.GetListaClavesColor(color);

                foreach (Contra claveActual in listaClaves)
                {
                    string nombreCategoria = this._usuarioActual.GetCategoriaClave(claveActual).Nombre;
                    string sitio = claveActual.Sitio;
                    string usuario = claveActual.UsuarioContra;
                    DateTime ultimaModificacion = claveActual.FechaModificacion;
                    this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
                }
            }
        }

        private void CargarTablaReporte()
        {
            const string rojo = "rojo",
                naranja = "naranja",
                amarillo = "amarillo",
                verdeClaro = "verde claro",
                verdeOscuro = "verde oscuro";

            int cantidadRojos = _usuarioActual.GetCantidadColor(rojo);
            int cantidadNaranja = _usuarioActual.GetCantidadColor(naranja);
            int cantidadAmarillo = _usuarioActual.GetCantidadColor(amarillo);
            int cantidadVerdeClaro = _usuarioActual.GetCantidadColor(verdeClaro);
            int cantidadVerdeOscuro = _usuarioActual.GetCantidadColor(verdeOscuro);

            this.TablaReporte.Rows.Add(rojo, cantidadRojos);
            this.TablaReporte.Rows.Add(naranja, cantidadNaranja);
            this.TablaReporte.Rows.Add(amarillo, cantidadAmarillo);
            this.TablaReporte.Rows.Add(verdeClaro, cantidadVerdeClaro);
            this.TablaReporte.Rows.Add(verdeOscuro, cantidadVerdeOscuro);

        }

        private void botonGrafica_Click(object sender, EventArgs e)
        {
            AbrirGrafica();
        }

        public delegate void AbrirGrafica_Handler();
        public event AbrirGrafica_Handler AbrirGrafica_Event;
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

                Contra buscadora = new Contra
                {
                    Sitio = sitioClaveAMostrar,
                    UsuarioContra = usuarioClaveAMostrar
                };

                AbrirVerClave(buscadora, _usuarioActual);
            }
        }

        public delegate void AbrirVerClave_Handler(Contra buscadora, Usuario usuarioActual);
        public event AbrirVerClave_Handler AbrirVerClave_Event;
        private void AbrirVerClave(Contra buscadora, Usuario usuarioActual)
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

                Contra aModificar = new Contra()
                {
                    Sitio = sitioClave,
                    UsuarioContra = usuarioClave
                };

                irAModificarClave(aModificar);
            }
        }

        public delegate void AbrirModificarClave_Handler(Contra claveAModificar);
        public event AbrirModificarClave_Handler AbrirModificarClave_Event;
        public void irAModificarClave(Contra claveAModificar)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(claveAModificar);
        }
    }
}
