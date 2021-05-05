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
    public partial class CrearClave : UserControl
    {
        private Usuario _usuarioActual;
        private AdminContras _administrador;

        public CrearClave(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            this.CargarComboBox();
        }

        private void CargarComboBox()
        {
            this.comboCategorias.Items.Clear();
            List<Categoria> lista = this._usuarioActual.GetListaCategorias();

            foreach (Categoria actual in lista)
            {
                string nombre = actual.Nombre;
                this.comboCategorias.Items.Add(nombre);
                
            }

        }
    }
}
