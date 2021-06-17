using LogicaDeNegocio;
using Negocio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class IniciarSesion : UserControl
    {
        private ControladoraAdministrador _administrador;

        public IniciarSesion()
        {
            this._administrador = new ControladoraAdministrador();
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
                Usuario iniciar = new Usuario()
                {
                    Nombre = this.inputUsuario.Text,
                    ClaveMaestra = this.inputContra.Text
                };

                try {
                    
                    Usuario verdadero = this._administrador.GetUsuario(iniciar);

                    Clave claveAEncriptar = new Clave()
                    {
                        Codigo = iniciar.ClaveMaestra
                    };
                    ControladoraEncriptador controladoraEncriptador = new ControladoraEncriptador();
                    claveAEncriptar = controladoraEncriptador.Encriptar(claveAEncriptar);
                    iniciar.ClaveMaestra = claveAEncriptar.Codigo;

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


        public delegate void IniciarSesion_Delegate(Usuario actual);
        public event IniciarSesion_Delegate IniciarSesion_Event;
        private void EnviarIniciarSesion(Usuario aIniciar) {
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
