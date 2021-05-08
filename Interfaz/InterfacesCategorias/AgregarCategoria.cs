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
    public partial class AgregarCategoria : UserControl
    {
        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public AgregarCategoria(Usuario usuarioAgregar, AdminContras administradorAgregar)
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

                    volverAListaCategorias();
                }
                catch
                {
                    this.labelErrores.Text = "Error: Ya existe una categoria con el mismo nombre";
                }

            }
            catch
            {
                this.labelErrores.Text = "Error: El largo del nombre de la categoria no puede ser menor a 3 ni mayor a 15";
            }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            volverAListaCategorias();
        }

        public delegate void AbrirListaCategorias_Handler();
        public event AbrirListaCategorias_Handler AbrirListaCategorias_Event;
        public void volverAListaCategorias()
        {
            if (this.AbrirListaCategorias_Event != null)
                this.AbrirListaCategorias_Event();
        }
    }
}
