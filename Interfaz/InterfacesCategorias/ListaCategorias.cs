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
    public partial class ListaCategorias : UserControl
    {
        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public ListaCategorias(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
        }

        private void CargarTabla()
        {

            List<Categoria> listaCategorias = this._usuarioActual.GetListaCategorias();

            foreach (Categoria categoriaActual in listaCategorias)
            {
                string nombreCategoria = categoriaActual.Nombre;
                this.TablaCategorias.Rows.Add(nombreCategoria);
            }
        }

        private void ListaCategorias_Load(object sender, EventArgs e)
        {
            this.CargarTabla();
        }

        public delegate void AbrirModificarCategoria_Handler(Categoria catActual);
        public event AbrirModificarCategoria_Handler AbrirModificarCategorias_Event;
        public void irAModificarCategoria(Categoria catActual)
        {
            if (this.AbrirModificarCategorias_Event != null)
                this.AbrirModificarCategorias_Event(catActual);
        }

        public delegate void AbrirAgregarCategotias_Handler();
        public event AbrirAgregarCategotias_Handler AbrirAgregarCategorias_Event;
        public void irAAgregarCategoria()
        {
            if (this.AbrirAgregarCategorias_Event != null)
                this.AbrirAgregarCategorias_Event();
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.TablaCategorias.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                string nombreCat = "";
                if (this.TablaCategorias.SelectedCells.Count > 0)
                {
                    int selectedrowindex = TablaCategorias.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = TablaCategorias.Rows[selectedrowindex];
                    nombreCat = Convert.ToString(selectedRow.Cells["Catergorias"].Value);
                }

                Categoria aModificar = new Categoria
                {
                    Nombre = nombreCat
                };

                irAModificarCategoria(aModificar);
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            irAAgregarCategoria();
        }

    }
}
