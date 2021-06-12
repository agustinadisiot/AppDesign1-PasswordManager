using LogicaDeNegocio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class IniciarSesion : UserControl
    {
        private ControladoraAdministrador _administrador;

        public IniciarSesion(ControladoraAdministrador administrador)
        {
            this._administrador = administrador;
            InitializeComponent();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            this.labelErrores.Text = "";
        }

        private void botonIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                ControladoraUsuario iniciar = new ControladoraUsuario()
                {
                    Nombre = this.inputUsuario.Text,
                    ClaveMaestra = this.inputContra.Text
                };

                try {
                    
                    ControladoraUsuario verdadero = this._administrador.GetUsuario(iniciar);
                    if (verdadero.ClaveMaestra == iniciar.ClaveMaestra)
                    {
                       
                        this.EnviarIniciarSesion(verdadero);
                    }
                    else {
                        this.labelErrores.Text = "Error: La contraseña es incorrecta.";
                    }

                }
                catch (Exception) {
                    this.labelErrores.Text = "Error: No existe el Usuario.";
                }

            }
            catch (Exception) {
                this.labelErrores.Text = "Error: Datos ingresados incorrectos.";
            }
        }

        private void botonCrearUsuario_Click(object sender, EventArgs e)
        {
            this.EnviarAbrirCrearUsuario();
        }


        public delegate void IniciarSesion_Delegate(ControladoraUsuario actual);
        public event IniciarSesion_Delegate IniciarSesion_Event;
        private void EnviarIniciarSesion(ControladoraUsuario aIniciar) {
            if (this.IniciarSesion_Event != null)
                this.IniciarSesion_Event(aIniciar);
        }

        public delegate void AbrirCrearUsuario_Delegate();
        public event AbrirCrearUsuario_Delegate AbrirCrearUsuario_Event;
        private void EnviarAbrirCrearUsuario() {
            if (this.AbrirCrearUsuario_Event != null)
                this.AbrirCrearUsuario_Event();
        }

        
    }
}
