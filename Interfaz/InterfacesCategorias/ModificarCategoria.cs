using LogicaDeNegocio;
using Negocio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ModificarCategoria : UserControl
    {
        private Categoria _categoriaActual;
        private Usuario _usuarioActual;
        private ControladoraUsuario _controladoraUsuario;

        public ModificarCategoria(Categoria categoriaAModificar, Usuario usuarioActual)
        {
            InitializeComponent();
            this._usuarioActual = usuarioActual;
            this._categoriaActual = categoriaAModificar;
            this._controladoraUsuario = new ControladoraUsuario();
            this.textNombreCategoria.Text = _categoriaActual.Nombre;
            this.labelErrores.Text = ""; 
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            VolverAListaCategorias();
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            try 
            {
                Categoria categoriaModificada = new Categoria()
                {
                    Nombre = this.textNombreCategoria.Text
                };

                try
                {
                    this._controladoraUsuario.ModificarNombreCategoria(this._categoriaActual, categoriaModificada, this._usuarioActual);

                    VolverAListaCategorias();
                }
                catch
                {
                    this.labelErrores.Text = "Error: Ya existe una categoría con el mismo nombre.";
                }
                

            }
            catch (Exception)
            {
                this.labelErrores.Text = "Error: El largo del nombre de la categoría no puede ser menor a 3 ni mayor a 15.";
            }
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
