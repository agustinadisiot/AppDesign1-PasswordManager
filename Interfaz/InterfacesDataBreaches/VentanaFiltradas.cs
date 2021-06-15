using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.InterfacesDataBreaches
{
    public partial class VentanaFiltradas : Form
    {
        private List<Filtrada> _filtradas;

        public VentanaFiltradas(List<Filtrada> filtradas)
        {
            InitializeComponent();
            this._filtradas = filtradas;
        }

        private void VentanaFiltradas_Load(object sender, EventArgs e)
        {
            this.tablaFiltradas.Rows.Clear();
            foreach (Filtrada aMostrar in this._filtradas) {
                this.tablaFiltradas.Rows.Add(aMostrar.ToString());
            }
        }
    }
}
