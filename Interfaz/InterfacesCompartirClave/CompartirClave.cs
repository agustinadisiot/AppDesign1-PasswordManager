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
    public partial class CompartirClave : UserControl
    {
        private Usuario _usuarioActual;
        private AdminContras _administrador;

        public CompartirClave(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            this.CargarComboBox();
        }

        private void CargarComboBox()
        {
            this.comboCompartir.Items.Clear();
            List<Usuario> lista = this._administrador.GetListaUsuarios();

            foreach (Usuario actual in lista)
            {
                if (!_usuarioActual.Equals(actual)) { 
                string nombre = actual.Nombre;
                this.comboCompartir.Items.Add(nombre);
                }
            }

        }

        public delegate void AbrirListaClaves_Handler();
        public event AbrirListaClaves_Handler AbrirListaClaves_Event;
        public void VolverAListaClaves()
        {
            if (this.AbrirListaClaves_Event != null)
                this.AbrirListaClaves_Event();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.VolverAListaClaves();
        }
    }
}
