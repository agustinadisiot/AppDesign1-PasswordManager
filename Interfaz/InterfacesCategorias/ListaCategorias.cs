using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaCategorias : UserControl
    {
        private Usuario _usuarioActual;
        private ControladoraUsuario _controladoraUsuario;

        public ListaCategorias(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._controladoraUsuario = new ControladoraUsuario();
            this._usuarioActual = usuarioAgregar;
        }

        private void CargarTabla()
        {
            List<Categoria> listaCategorias = this._controladoraUsuario.GetListaCategorias(_usuarioActual);

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

        public delegate void AbrirModificarCategoria_Delegate(Categoria catActual);
        public event AbrirModificarCategoria_Delegate AbrirModificarCategorias_Event;
        public void IrAModificarCategoria(Categoria catActual)
        {
            if (this.AbrirModificarCategorias_Event != null)
                this.AbrirModificarCategorias_Event(catActual);
        }

        public delegate void AbrirAgregarCategorias_Delegate();
        public event AbrirAgregarCategorias_Delegate AbrirAgregarCategorias_Event;
        public void IrAAgregarCategoria()
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
                    nombreCat = Convert.ToString(selectedRow.Cells["Categorias"].Value);
                }

                Categoria aModificar = new Categoria
                {
                    Nombre = nombreCat
                };

                IrAModificarCategoria(aModificar);
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            IrAAgregarCategoria();
        }

    }
}
