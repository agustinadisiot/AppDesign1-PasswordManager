using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz.InterfacesCompartirClave
{
    public partial class ListaClavesCompartidasPorMi : UserControl
    {
        private ControladoraAdministrador _administrador;
        private ControladoraUsuario _usuarioActual;

        public ListaClavesCompartidasPorMi(ControladoraUsuario usuarioAgregar, ControladoraAdministrador administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.tablaClavesCompartidas.Rows.Clear();

            List<ClaveCompartida> listaClavesCompartidasPorMi = this._usuarioActual.CompartidasPorMi;

            foreach (ClaveCompartida claveCompartidaActual in listaClavesCompartidasPorMi)
            {
                ControladoraClave claveQueSeComparte = claveCompartidaActual.Clave;
                ControladoraUsuario usuarioQueComparte = claveCompartidaActual.Destino;

                string nombreUsuarioAQuienSeComparte = usuarioQueComparte.Nombre;
                string sitioClaveQueSeComparte = claveQueSeComparte.Sitio;
                string usuarioClaveQueSeComparte = claveQueSeComparte.UsuarioClave;

                this.tablaClavesCompartidas.Rows.Add(nombreUsuarioAQuienSeComparte, sitioClaveQueSeComparte, usuarioClaveQueSeComparte);
            }
        }

        private void botonDejarDeCompartir_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaClavesCompartidas.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                string texto = "¿Estas seguro que quieres dejar de compartir esta contraseña?";
                VentanaConfirmaciones ventanaConfirmar = new VentanaConfirmaciones(texto);
                ventanaConfirmar.CerrarConfirmacion_Event += CerrarConfirmacion_Handler;
                ventanaConfirmar.ShowDialog();
            }
        }

        private void CerrarConfirmacion_Handler(bool acepto)
        {
            bool haySeleccionada = this.tablaClavesCompartidas.SelectedCells.Count > 0;
            if (haySeleccionada && acepto)
            {
                int posSeleccionada = this.tablaClavesCompartidas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaClavesCompartidas.Rows[posSeleccionada];

                string nombreUsuarioDejarDeCompartir = Convert.ToString(selectedRow.Cells["CompartidaA"].Value);
                string sitioClaveDejarDeCompartir = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                string usuarioClaveDejarDeCompartir = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                ControladoraClave claveBuscadora = new ControladoraClave
                {
                    Sitio = sitioClaveDejarDeCompartir,
                    UsuarioClave = usuarioClaveDejarDeCompartir
                };

                ControladoraUsuario usuarioBuscador = new ControladoraUsuario
                {
                    Nombre = nombreUsuarioDejarDeCompartir
                };

                ClaveCompartida buscadora = new ClaveCompartida
                {
                    Original = this._usuarioActual,
                    Clave = claveBuscadora,
                    Destino = usuarioBuscador
                };

                ClaveCompartida aEliminar = this._usuarioActual.GetClaveCompartidaPorMi(buscadora);

                this._usuarioActual.DejarDeCompartir(aEliminar);
                this.CargarTabla();
            }
        }

        private void botonVer_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaClavesCompartidas.SelectedCells.Count > 0;
            if (haySeleccionada )
            {
                int posSeleccionada = this.tablaClavesCompartidas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaClavesCompartidas.Rows[posSeleccionada];

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

    }
}
