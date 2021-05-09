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

namespace Interfaz.InterfacesDataBreaches
{
    public partial class IngresosDataBreaches : UserControl
    {
        private Usuario _actual;

        public IngresosDataBreaches(Usuario actual)
        {
            this._actual = actual;
            InitializeComponent();
        }

        private void botonVerificar_Click(object sender, EventArgs e)
        {
            string ingreso = this.inputDatos.Text;

            List<string> verificar = new List<string>(ingreso.Split(new string[] { "\\n" }, StringSplitOptions.None));
        }

        
    }
}
