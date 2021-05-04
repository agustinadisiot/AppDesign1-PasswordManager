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
    public partial class VentanaPrincipal : Form
    {

        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public VentanaPrincipal()
        {
            this._administrador = new AdminContras();
            this._usuarioActual = null;
            InitializeComponent();

        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            UserControl listaTarjetas = new ListaTarjetas(this._usuarioActual, this._administrador);
            panelForm.Controls.Add(listaTarjetas);
        }
    }
}
