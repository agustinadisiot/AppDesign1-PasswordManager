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

            List<ClaveCompartida> listaClavesCompartidasConmigo = this._usuarioActual.CompartidasConmigo;

            foreach (ClaveCompartida claveCompartidaActual in listaClavesCompartidasConmigo)
            {
                Contra claveQueSeComparte = claveCompartidaActual.Clave;
                Usuario usuarioQueComparte = claveCompartidaActual.Usuario;

                string nombreUsuarioAQuienSeComparte = usuarioQueComparte.Nombre;
                string sitioClaveQueSeComparte = claveQueSeComparte.Sitio;
                string usuarioClaveQueSeComparte = claveQueSeComparte.UsuarioContra;

                this.tablaClavesComparidas.Rows.Add(nombreUsuarioAQuienSeComparte, sitioClaveQueSeComparte, usuarioClaveQueSeComparte);
            }
        }

        private void botonDejarDeCompartir_Click(object sender, EventArgs e)
        {
            string texto = "¿Estas seguro que quieres dejar de compartir esta coontraseña?";
            VentanaConfirmaciones ventanaConfirmar = new VentanaConfirmaciones(texto);
            ventanaConfirmar.CerrarConfirmacion_Event += CerrarConfirmacion_Handler;
            Application.Run(new VentanaConfirmaciones(texto));
            

        }

        private void CerrarConfirmacion_Handler(bool acepto)
        {
           
        }

    }
}
