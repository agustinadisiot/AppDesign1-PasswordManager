using LogicaDeNegocio;
using Negocio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class CrearUsuario : UserControl
    {
        private ControladoraAdministrador _administrador;

        public CrearUsuario()
        {
            InitializeComponent();
            this._administrador = new ControladoraAdministrador();
        }

        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            this.labelErrores.Text = "";
        }

        private void botonCrear_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario agregar = new Usuario()
                {
                    Nombre = this.inputUsuario.Text,
                    ClaveMaestra = this.inputContra.Text
                };

                try {
                    this._administrador.AgregarUsuario(agregar);
                    var confirmResult = MessageBox.Show("Usuario creado correctamente.",
                                     "Usuario Agregado.",
                                     MessageBoxButtons.OK);
                    this.EnviarSalirCrearUsuario();
                }
                catch (Exception) {
                    this.labelErrores.Text = "Error: Ya existe el Usuario";
                }

            }
            catch (Exception) {
                this.labelErrores.Text = "Error: Datos ingresados incorrectos.";
            }

        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.EnviarSalirCrearUsuario();
        }

        public delegate void SalirCrearUsuario_Delegate();
        public event SalirCrearUsuario_Delegate AbrirIniciarSesion_Event;
        private void EnviarSalirCrearUsuario()
        {
            if (this.AbrirIniciarSesion_Event != null)
                this.AbrirIniciarSesion_Event();
        }

        
    }
}
