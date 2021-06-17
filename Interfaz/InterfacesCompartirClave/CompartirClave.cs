using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class CompartirClave : UserControl
    {
        private Usuario _usuarioActual;
        private Clave _claveACompartir;
        private ControladoraAdministrador _controladoraAdministrador;

        public CompartirClave(ClaveCompartida aCompartir)
        {
            InitializeComponent();
            this._usuarioActual = aCompartir.Original;
            this._claveACompartir = aCompartir.Clave;
            this._controladoraAdministrador = new ControladoraAdministrador();
        }

        private void CompartirClave_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.labelErrores.Text = "";
        }


        private void CargarComboBox()
        {
            this.comboCompartir.Items.Clear();
            List<Usuario> lista = this._controladoraAdministrador.GetListaUsuarios();

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

                    Usuario usuarioACompartir = this._controladoraAdministrador.GetUsuario(buscador);

                    ClaveCompartida claveACompartir = new ClaveCompartida()
                    {
                        Original = this._usuarioActual,
                        Destino = usuarioACompartir,
                        Clave = _claveACompartir
                    };

                    this._controladoraAdministrador.CompartirClave(claveACompartir);
                    var confirmResult = MessageBox.Show("Contraseñá compartida correctamente.",
                                     "Contraseña Compartida.",
                                     MessageBoxButtons.OK);
                    this.VolverAListaClaves();
                }
                catch (Exception)
                {
                    this.labelErrores.Text = "Error: Contraseña ya compartida.";
                }
            }
            else {
                this.labelErrores.Text = "Error: Debe elegir un usuario al cual compartir.";
            }
        }
    }
}
