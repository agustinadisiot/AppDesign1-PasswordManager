using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaClavesCompartidasConmigo : UserControl
    {
        private Usuario _usuarioActual;

        public ListaClavesCompartidasConmigo(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this.CargarTabla();
        }

        private void CargarTabla()
        {

            List<ClaveCompartida> listaClavesCompartidasConmigo = this._usuarioActual.CompartidasConmigo;

            foreach (ClaveCompartida claveCompartidaActual in listaClavesCompartidasConmigo)
            {
                Clave claveQueSeComparte = claveCompartidaActual.Clave;
                Usuario usuarioQueComparte = claveCompartidaActual.Original;

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

                Clave claveBuscadora = new Clave
                {
                    Sitio = sitioClaveAMostrar,
                    UsuarioClave = usuarioClaveAMostrar
                };

                Usuario usuarioBuscador = new Usuario()
                {
                    Nombre = usuarioAMostrar
                };

                AbrirVerClave(claveBuscadora, usuarioBuscador);
            }
        }

        public delegate void AbrirVerClave_Delegate(Clave buscadora, Usuario usuarioActual);
        public event AbrirVerClave_Delegate AbrirVerClave_Event;
        private void AbrirVerClave(Clave buscadora, Usuario usuarioActual)
        {
            if (this.AbrirVerClave_Event != null)
                this.AbrirVerClave_Event(buscadora, usuarioActual);
        }

    }
}
