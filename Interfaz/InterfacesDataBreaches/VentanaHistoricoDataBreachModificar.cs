using Interfaz.InterfacesClaves;
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
    public partial class VentanaHistoricoDataBreachModificar : Form
    {
        private Usuario _usuarioAModificar;
        private Clave _claveAModificar;
        public VentanaHistoricoDataBreachModificar(Usuario usuario, Clave clave)
        {
            InitializeComponent();
            this._usuarioAModificar = usuario;
            this._claveAModificar = clave;
        }

        private void VentanaHistoricoDataBreachModificar_Load(object sender, EventArgs e)
        {
            ModificarClave modificarClave = new ModificarClave(this._usuarioAModificar, this._claveAModificar);
            this.panel.Controls.Add(modificarClave);
        }
    }
}
