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
    public partial class ModificarCategoria : UserControl
    {
        private Categoria _actual;

        public ModificarCategoria(Categoria categoriaAModificar)
        {
            InitializeComponent();
            _actual = categoriaAModificar;
            this.textNombreCategoria.Text = _actual.Nombre;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            _actual.Nombre = this.textNombreCategoria.Text;
        }

    }
}
