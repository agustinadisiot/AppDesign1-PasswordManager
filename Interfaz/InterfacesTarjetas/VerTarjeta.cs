using LogicaDeNegocio;
using System;
using System.Windows.Forms;

namespace Interfaz.InterfacesTarjetas
{
    public partial class VerTarjeta : UserControl
    {
        private ControladoraTarjeta _mostrar;
        private ControladoraUsuario _usuario;

        public VerTarjeta(ControladoraTarjeta ingreso, ControladoraUsuario actual)
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
            string formatoFecha = "MM '/' yyyy";
            ControladoraCategoria categoria = this._usuario.GetCategoriaTarjeta(this._mostrar);

            this.labelMostrarCategoria.Text = categoria.Nombre;
            this.labelMostrarCodigo.Text = this._mostrar.Codigo;
            this.labelMostrarNombre.Text = this._mostrar.Nombre;
            this.inputNota.Text = this._mostrar.Nota;
            this.labelMostrarNumero.Text = this._mostrar.Numero;
            this.labelMostrarTipo.Text = this._mostrar.Tipo;
            this.labelMostrarVencimiento.Text = this._mostrar.Vencimiento.ToString(formatoFecha);


        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.VolverAListaTarjetas();
        }


        public delegate void AbrirListaTarjetas_Delegate();
        public event AbrirListaTarjetas_Delegate AbrirListaTarjetas_Event;
        private void VolverAListaTarjetas()
        {
            if (this.AbrirListaTarjetas_Event != null)
                this.AbrirListaTarjetas_Event();
        }

    }
}
