using LogicaDeNegocio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class VerClave : UserControl
    {
        private ControladoraClave _claveAMostrar;
        private ControladoraUsuario _usuarioActual;

        public VerClave(ControladoraClave claveAMostrar, ControladoraUsuario usuarioActual)
        {
            InitializeComponent();
            _claveAMostrar = claveAMostrar;
            _usuarioActual = usuarioActual;
            this.CargarDatos();
        }

        private void CargarDatos()
        {
            ControladoraCategoria categoriaAMostrar = _usuarioActual.GetCategoriaClave(_claveAMostrar);
            string nombreCateogiraAMostrar = categoriaAMostrar.Nombre;
            string sitioAMostrar = _claveAMostrar.VerificarSitio;
            string usuarioAMostrar = _claveAMostrar.verificarUsuarioClave;
            string codigoAMostrar = _claveAMostrar.Codigo;
            string notaAMostrar = _claveAMostrar.VerificarNota;

            this.labelCategoriaAMostrar.Text = nombreCateogiraAMostrar;
            this.labelSitioAMostrar.Text = sitioAMostrar;
            this.labelUsuarioAMostrar.Text = usuarioAMostrar;
            this.labelClaveAMostrar.Text = codigoAMostrar;
            this.inputNota.Text = notaAMostrar;

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            VolverAListaClaves();
        }

        public delegate void SalirDeVerClave_Delegate();
        public event SalirDeVerClave_Delegate SalirDeVerClave_Event;
        public void VolverAListaClaves()
        {
            if (this.SalirDeVerClave_Event != null)
                this.SalirDeVerClave_Event();
        }

    }
}
