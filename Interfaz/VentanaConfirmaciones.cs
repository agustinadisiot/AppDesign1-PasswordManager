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
    public partial class VentanaConfirmaciones : Form
    {
        public VentanaConfirmaciones(string texto)
        {
            InitializeComponent();
            this.labelTextoDeConfirmacion.Text = texto;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            bool aceptar = true;
            CerrarConfirmacion(aceptar);
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            bool aceptar = false;
            CerrarConfirmacion(aceptar);
        }

        public delegate void cerrarConfirmacion_Delegate(bool acepto);
        public event cerrarConfirmacion_Delegate CerrarConfirmacion_Event;
        public void CerrarConfirmacion(bool acepto)
        {
            if (this.CerrarConfirmacion_Event != null)
                this.CerrarConfirmacion_Event(acepto);
            this.Close();
        }
    }
}
