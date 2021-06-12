using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaCategorias : UserControl
    {
        private ControladoraUsuario _usuarioActual;

        public ListaCategorias(ControladoraUsuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
        }

        private void CargarTabla()
        {

            List<ControladoraCategoria> listaCategorias = this._usuarioActual.GetListaCategorias();

            foreach (ControladoraCategoria categoriaActual in listaCategorias)
            {
                string nombreCategoria = categoriaActual.Nombre;
                this.TablaCategorias.Rows.Add(nombreCategoria);
            }
        }

        private void ListaCategorias_Load(object sender, EventArgs e)
        {
            this.CargarTabla();
        }

        public delegate void AbrirModificarCategoria_Delegate(ControladoraCategoria catActual);
        public event AbrirModificarCategoria_Delegate AbrirModificarCategorias_Event;
        public void IrAModificarCategoria(ControladoraCategoria catActual)
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

                ControladoraCategoria aModificar = new ControladoraCategoria
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
