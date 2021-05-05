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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaCategorias_Load(object sender, EventArgs e)
        {
            this.CargarTabla();
        }

        public event EventHandler AbrirModificarCategorias_Event;
        public void irAModificarCategoria(EventArgs e)
        {
            if (this.AbrirModificarCategorias_Event != null)
                this.AbrirModificarCategorias_Event(this, e);
        }

        public event EventHandler AbrirAgregarCategorias_Event;
        public void irAAgregarCategoria(EventArgs e)
        {
            if (this.AbrirAgregarCategorias_Event != null)
                this.AbrirAgregarCategorias_Event(this, e);
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            irAModificarCategoria(e);
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            irAAgregarCategoria(e);
        }
    }
}
