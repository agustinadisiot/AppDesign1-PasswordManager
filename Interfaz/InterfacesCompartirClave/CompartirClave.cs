using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class CompartirClave : UserControl
    {
        private Usuario _usuarioActual;
        private Clave _claveACompartir;
        private Administrador _administrador;

        public CompartirClave(ClaveCompartida aCompartir, Administrador administrador)
        {
            InitializeComponent();
            this._usuarioActual = aCompartir.Usuario;
            this._claveACompartir = aCompartir.Clave;
            this._administrador = administrador;
            
        }

        private void CompartirClave_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.labelErrores.Text = "";
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
            string usuarioClaveACompartir = _claveACompartir.UsuarioClave;

            this.labelSitioAMostrar.Text = sitioClaveACompartir;
            this.labelUsuarioAMostrar.Text = usuarioClaveACompartir;

        }

        public delegate void AbrirListaClaves_Delegate();
        public event AbrirListaClaves_Delegate AbrirListaClaves_Event;
        public void VolverAListaClaves()
        {
            if (this.AbrirListaClaves_Event != null)
                this.AbrirListaClaves_Event();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.VolverAListaClaves();
        }

        private string LeerComboBox()
        {
            string nombre = (string)this.comboCompartir.SelectedItem;

            return nombre;
        }
        private void botonAceptar_Click(object sender, EventArgs e)
        {
            string nombreUsuarioACompartir = LeerComboBox();
            if (nombreUsuarioACompartir != null)
            {
                try
                {
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
                catch (Exception)
                {
                    this.labelErrores.Text = "Contraseña ya compartida.";
                }
            }
            else {
                this.labelErrores.Text = "Debe elegir un usuario al cual compartir.";
            }
        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
