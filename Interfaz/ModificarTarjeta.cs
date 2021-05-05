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
    public partial class ModificarTarjeta : UserControl
    {
        private Usuario _actual;
        private Tarjeta _modificar;

        public ModificarTarjeta(Usuario usuario, Tarjeta tarjeta )
        {
            this._actual = usuario;
            this._modificar = tarjeta;
            InitializeComponent();
        }

        private void ModificarTarjeta_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.labelErrores.Text = "";
        }

        private void CargarInputsConTarjeta() {

            this.inputNombre.Text = this._modificar.Nombre;
            this.inputTipo.Text = this._modificar.Tipo;
            this.inputNumero.Text = this._modificar.Numero;
            this.datePickerVencimiento.Value = this._modificar.Vencimiento;
            this.inputNota.Text = this._modificar.Nota;
        }


        private void CargarComboBox()
        {
            this.comboBoxCategorias.Items.Clear();
            List<Categoria> lista = this._actual.GetListaCategorias();

            foreach (Categoria actual in lista)
            {

                string nombre = actual.Nombre;
                this.comboBoxCategorias.Items.Add(nombre);
            }

        }

        private string LeerComboBox()
        {
            string nombre = (string)this.comboBoxCategorias.SelectedItem;

            return nombre;
        }


        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.volverAListaTarjetas(e);
        }


        public event EventHandler AbrirListaTarjetas_Event;
        private void volverAListaTarjetas(EventArgs e)
        {
            if (this.AbrirListaTarjetas_Event != null)
                this.AbrirListaTarjetas_Event(this, e);
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            this.volverAListaTarjetas(e);
        }

        
    }
}
