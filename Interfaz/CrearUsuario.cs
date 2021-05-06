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
    public partial class CrearUsuario : UserControl
    {
        private AdminContras _administrador;

        public CrearUsuario(AdminContras administradorActual)
        {
            InitializeComponent();
            this._administrador = administradorActual;
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
                    ContraMaestra = this.inputContra.Text
                };

                try {
                    this._administrador.AgregarUsuario(agregar);
                    this.EnviarSalirCrearUsuario();
                }
                catch (Exception) {
                    this.labelErrores.Text = "Ya existe el Usuario";
                }

            }
            catch (Exception) {
                this.labelErrores.Text = "El nombre o contraseña no cumplen las restricciones.";
            }

        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.EnviarSalirCrearUsuario();
        }

        public delegate void SalirCrearUsuario_Handler();

        public event SalirCrearUsuario_Handler AbrirIniciarSesion_Event;

        private void EnviarSalirCrearUsuario()
        {
            if (this.AbrirIniciarSesion_Event != null)
                this.AbrirIniciarSesion_Event();
        }

        
    }
}
