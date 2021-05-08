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

namespace Interfaz.InterfacesCompartirClave
{
    public partial class ListaClavesCompartidasPorMi : UserControl
    {
        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public ListaClavesCompartidasPorMi(Usuario usuarioAgregar, AdminContras administradorAgregar)
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
                Contra claveQueSeComparte = claveCompartidaActual.Clave;
                Usuario usuarioQueComparte = claveCompartidaActual.Usuario;

                string nombreUsuarioAQuienSeComparte = usuarioQueComparte.Nombre;
                string sitioClaveQueSeComparte = claveQueSeComparte.Sitio;
                string usuarioClaveQueSeComparte = claveQueSeComparte.UsuarioContra;

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

                Contra claveBuscadora = new Contra
                {
                    Sitio = sitioClaveDejarDeCompartir,
                    UsuarioContra = usuarioClaveDejarDeCompartir
                };

                Usuario usuarioBuscador = new Usuario
                {
                    Nombre = nombreUsuarioDejarDeCompartir
                };

                ClaveCompartida buscadora = new ClaveCompartida
                {
                    Clave = claveBuscadora,
                    Usuario = usuarioBuscador
                };

                ClaveCompartida aEliminar = this._usuarioActual.GetClaveCompartidaPorMi(buscadora);

                this._usuarioActual.DejarDeCompartir(aEliminar);
                this.CargarTabla();
            }
        }

    }
}
