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

namespace Interfaz
{
    public partial class ListaClavesCompartidasConmigo : UserControl
    {
        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public ListaClavesCompartidasConmigo(Usuario usuarioAgregar, AdminContras administradorAgregar)
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
                Contra claveQueSeComparte = claveCompartidaActual.Clave;
                Usuario usuarioQueComparte = claveCompartidaActual.Usuario;

                string nombreUsuarioQueComparte = usuarioQueComparte.Nombre;
                string sitioClaveQueSeComparte = claveQueSeComparte.Sitio;
                string usuarioClaveQueSeComparte = claveQueSeComparte.UsuarioContra;

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

                Contra claveBuscadora = new Contra
                {
                    Sitio = sitioClaveAMostrar,
                    UsuarioContra = usuarioClaveAMostrar
                };

                Usuario usuarioBuscador = new Usuario()
                {
                    Nombre = usuarioAMostrar
                };

                AbrirVerClave(claveBuscadora, usuarioBuscador);
            }
        }

        public delegate void AbrirVerClave_Handler(Contra buscadora, Usuario usuarioActual);
        public event AbrirVerClave_Handler AbrirVerClaveEvent;
        private void AbrirVerClave(Contra buscadora, Usuario usuarioActual)
        {
            if (this.AbrirVerClaveEvent != null)
                this.AbrirVerClaveEvent(buscadora, usuarioActual);
        }

    }
}
