using LogicaDeNegocio;
using Negocio;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class AgregarCategoria : UserControl
    {
        private Usuario _usuarioActual;
        private ControladoraUsuario _controladoraUsuario;

        public AgregarCategoria(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._controladoraUsuario = new ControladoraUsuario();
            this._usuarioActual = usuarioAgregar;
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
                this._controladoraUsuario.AgregarCategoria(nuevaCategoria, _usuarioActual);
                var confirmResult = MessageBox.Show("Categoria creada correctamente.",
                                 "Categoria Agregado.",
                                 MessageBoxButtons.OK);
                VolverAListaCategorias();
            }
            catch(ObjetoYaExistenteException)
            {
                this.labelErrores.Text = "Error: Ya existe una categoría con el mismo nombre.";
            }
            catch(LargoIncorrectoException)
            {
                this.labelErrores.Text = "Error: El largo del nombre de la categoría no puede ser menor a 3 ni mayor a 15.";
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
