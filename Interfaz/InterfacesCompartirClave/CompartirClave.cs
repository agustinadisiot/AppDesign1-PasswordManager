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
    public partial class CompartirClave : UserControl
    {
        private Usuario _usuarioActual;
        private Contra _claveACompartir;
        private AdminContras _administrador;

        public CompartirClave(ClaveCompartida aCompartir, AdminContras administrador)
        {
            InitializeComponent();
            this._usuarioActual = aCompartir.Usuario;
            this._claveACompartir = aCompartir.Clave;
            this._administrador = administrador;
            this.CargarComboBox();
        }

        private void CargarComboBox()
        {
            this.comboCompartir.Items.Clear();
            List<Usuario> lista = this._administrador.GetListaUsuarios();

            foreach (Usuario actual in lista)
            {
                if (!_usuarioActual.Equals(actual)) { 
                    string nombre = actual.Nombre;
                    this.comboCompartir.Items.Add(nombre);
                }
            }

            string sitioClaveACompartir = _claveACompartir.Sitio;
            string usuarioClaveACompartir = _claveACompartir.UsuarioContra;

            this.labelSitioAMostrar.Text = sitioClaveACompartir;
            this.labelUsuarioAMostrar.Text = usuarioClaveACompartir;

        }

        public delegate void AbrirListaClaves_Handler();
        public event AbrirListaClaves_Handler AbrirListaClaves_Event;
        public void VolverAListaClaves()
        {
            if (this.AbrirListaClaves_Event != null)
                this.AbrirListaClaves_Event();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.VolverAListaClaves();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            string nombreUsuarioACompartir = this.comboCompartir.Text;

            Usuario buscador = new Usuario()
            {
                Nombre = nombreUsuarioACompartir
            };

            Usuario usuarioACompartir = this._administrador.GetUsuario(buscador);

            ClaveCompartida claveACompartir = new ClaveCompartida()
            {
                Usuario = usuarioACompartir,
                Clave = _claveACompartir
            };

            this._usuarioActual.CompartirClave(claveACompartir);
            this.VolverAListaClaves();

        }
    }
}
