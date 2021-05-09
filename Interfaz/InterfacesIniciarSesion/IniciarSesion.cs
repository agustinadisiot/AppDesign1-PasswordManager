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
    public partial class IniciarSesion : UserControl
    {
        private AdminContras _administrador;

        public IniciarSesion(AdminContras administrador)
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


                Usuario iniciar = new Usuario()
                {
                    Nombre = this.inputUsuario.Text,
                    ContraMaestra = this.inputContra.Text
                };

                try {
                    
                    Usuario verdadero = this._administrador.GetUsuario(iniciar.Nombre);
                    if (verdadero.ContraMaestra == iniciar.ContraMaestra)
                    {
                       
                        this.EnviarIniciarSesion(verdadero);
                    }
                    else {
                        this.labelErrores.Text = "La contraseña es incorrecta.";
                    }

                }
                catch (Exception) {
                    this.labelErrores.Text = "No existe el Usuario.";
                }

            }
            catch (Exception) {
                this.labelErrores.Text = "Los datos ingresados contienen un error.";
            }
        }


        public delegate void IniciarSesion_Handler(Usuario actual);

        public event IniciarSesion_Handler IniciarSesion_Event;

        private void EnviarIniciarSesion(Usuario aIniciar) {
            if (this.IniciarSesion_Event != null)
                this.IniciarSesion_Event(aIniciar);
        }



        private void botonCrearUsuario_Click(object sender, EventArgs e)
        {
            this.EnviarAbrirCrearUsuario();
        }

        public delegate void AbrirCrearUsuario_Handler();
        public event AbrirCrearUsuario_Handler AbrirCrearUsuario_Event;
        private void EnviarAbrirCrearUsuario() {
            if (this.AbrirCrearUsuario_Event != null)
                this.AbrirCrearUsuario_Event();
        }

        
    }
}
