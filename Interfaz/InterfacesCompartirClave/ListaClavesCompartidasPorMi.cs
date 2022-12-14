using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz.InterfacesCompartirClave
{
    public partial class ListaClavesCompartidasPorMi : UserControl
    {
        private Usuario _usuarioActual;
        private ControladoraUsuario _controladoraUsuario;
        private ControladoraAdministrador _controladoraAdministrador;

        public ListaClavesCompartidasPorMi(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._controladoraUsuario = new ControladoraUsuario();
            this._controladoraAdministrador = new ControladoraAdministrador();
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.tablaClavesCompartidas.Rows.Clear();

            List<ClaveCompartida> listaClavesCompartidasPorMi = this._usuarioActual.CompartidasPorMi;

            foreach (ClaveCompartida claveCompartidaActual in listaClavesCompartidasPorMi)
            {
                Clave claveQueSeComparte = claveCompartidaActual.Clave;
                Usuario usuarioQueComparte = claveCompartidaActual.Destino;

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

                Clave claveBuscadora = new Clave
                {
                    Sitio = sitioClaveDejarDeCompartir,
                    UsuarioClave = usuarioClaveDejarDeCompartir
                };

                Usuario usuarioBuscador = new Usuario
                {
                    Nombre = nombreUsuarioDejarDeCompartir
                };

                ClaveCompartida buscadora = new ClaveCompartida
                {
                    Original = this._usuarioActual,
                    Clave = claveBuscadora,
                    Destino = usuarioBuscador
                };

                ClaveCompartida aEliminar = this._controladoraUsuario.GetClaveCompartidaPorMi(buscadora, this._usuarioActual);

                this._controladoraAdministrador.DejarDeCompartir(aEliminar);
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

                Clave buscadora = new Clave
                {
                    Sitio = sitioClaveAMostrar,
                    UsuarioClave = usuarioClaveAMostrar
                };

                AbrirVerClave(buscadora, _usuarioActual);
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
