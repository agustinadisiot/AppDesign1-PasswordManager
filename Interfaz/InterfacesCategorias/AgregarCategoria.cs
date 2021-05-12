using Dominio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class AgregarCategoria : UserControl
    {
        private Administrador _administrador;
        private Usuario _usuarioActual;

        public AgregarCategoria(Usuario usuarioAgregar, Administrador administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            this.labelErrores.Text = "";
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            string nombreCategoria = this.textNombreCategoria.Text;
            try
            {
                Categoria nuevaCategoria = new Categoria
                {
                    Nombre = nombreCategoria
                };

                this.textNombreCategoria.Clear();
                try
                {
                    _usuarioActual.AgregarCategoria(nuevaCategoria);

                    VolverAListaCategorias();
                }
                catch
                {
                    this.labelErrores.Text = "Error: Ya existe una categoria con el mismo nombre.";
                }

            }
            catch
            {
                this.labelErrores.Text = "Error: El largo del nombre de la categoria no puede ser menor a 3 ni mayor a 15.";
            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            VolverAListaCategorias();
        }

        public delegate void AbrirListaCategorias_Delegate();
        public event AbrirListaCategorias_Delegate AbrirListaCategorias_Event;
        public void VolverAListaCategorias()
        {
            if (this.AbrirListaCategorias_Event != null)
                this.AbrirListaCategorias_Event();
        }
    }
}
