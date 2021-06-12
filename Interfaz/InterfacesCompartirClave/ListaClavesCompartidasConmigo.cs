using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaClavesCompartidasConmigo : UserControl
    {
        private ControladoraAdministrador _administrador;
        private ControladoraUsuario _usuarioActual;

        public ListaClavesCompartidasConmigo(ControladoraUsuario usuarioAgregar, ControladoraAdministrador administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            this.CargarTabla();
        }

        private void CargarTabla()
        {

            List<ClaveCompartida> listaClavesCompartidasConmigo = this._usuarioActual.CompartidasConmigo;

            foreach (ClaveCompartida claveCompartidaActual in listaClavesCompartidasConmigo)
            {
                ControladoraClave claveQueSeComparte = claveCompartidaActual.Clave;
                ControladoraUsuario usuarioQueComparte = claveCompartidaActual.Original;

                string nombreUsuarioQueComparte = usuarioQueComparte.Nombre;
                string sitioClaveQueSeComparte = claveQueSeComparte.Sitio;
                string usuarioClaveQueSeComparte = claveQueSeComparte.UsuarioClave;

                this.tablaClavesCompartidas.Rows.Add(nombreUsuarioQueComparte, sitioClaveQueSeComparte, usuarioClaveQueSeComparte);
            }
        }

        private void botonVer_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaClavesCompartidas.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                int posSeleccionada = this.tablaClavesCompartidas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaClavesCompartidas.Rows[posSeleccionada];

                string usuarioAMostrar = Convert.ToString(selectedRow.Cells["CompartidaPor"].Value);
                string sitioClaveAMostrar = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                string usuarioClaveAMostrar = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                ControladoraClave claveBuscadora = new ControladoraClave
                {
                    Sitio = sitioClaveAMostrar,
                    UsuarioClave = usuarioClaveAMostrar
                };

                ControladoraUsuario usuarioBuscador = new ControladoraUsuario()
                {
                    Nombre = usuarioAMostrar
                };

                AbrirVerClave(claveBuscadora, usuarioBuscador);
            }
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
