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

namespace Interfaz.InterfacesTarjetas
{
    public partial class VerTarjeta : UserControl
    {
        private Tarjeta _mostrar;
        private Usuario _usuario;

        public VerTarjeta(Tarjeta ingreso, Usuario actual)
        {
            this._mostrar = ingreso;
            this._usuario = actual;
            InitializeComponent();
        }

        private void VerTarjeta_Load(object sender, EventArgs e)
        {
            this.labelErrores.Text = "";
            this.CargarDatos();
        }

        private void CargarDatos() {
            Categoria categoria = this._usuario.GetCategoriaTarjeta(this._mostrar);

            this.labelMostrarCategoria.Text = categoria.Nombre;
            this.labelMostrarCodigo.Text = this._mostrar.Codigo;
            this.labelMostrarNombre.Text = this._mostrar.Nombre;
            this.labelMostrarNotas.Text = this._mostrar.Nota;
            this.labelMostrarNumero.Text = this._mostrar.Numero;
            this.labelMostrarTipo.Text = this._mostrar.Tipo;
            this.labelMostrarVencimiento.Text = this._mostrar.Vencimiento.ToString();


        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.VolverAListaTarjetas();
        }


        public delegate void AbrirListaTarjetas_Handler();
        public event AbrirListaTarjetas_Handler AbrirListaTarjetas_Event;
        private void VolverAListaTarjetas()
        {
            if (this.AbrirListaTarjetas_Event != null)
                this.AbrirListaTarjetas_Event();
        }
    }
}
