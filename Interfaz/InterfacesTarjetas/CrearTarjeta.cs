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
    public partial class CrearTarjeta : UserControl
    {
        private Usuario _actual;

        public CrearTarjeta(Usuario aAgregar)
        {
            InitializeComponent();

            this._actual = aAgregar;
        }

        private void CrearTarjeta_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.labelErrores.Text = "";


        }


        private void CargarComboBox() {
            this.comboBoxCategorias.Items.Clear();
            List<Categoria> lista = this._actual.GetListaCategorias();

            foreach (Categoria actual in lista) {

                string nombre = actual.Nombre;
                this.comboBoxCategorias.Items.Add(nombre);
            }
            this.comboBoxCategorias.SelectedIndex = 0;
        }

        private void botonCrear_Click(object sender, EventArgs e)
        {
            bool agrego = false;
            Categoria categoria = new Categoria()
            {
                Nombre = this.LeerComboBox()
            };

            string nombre = this.inputNombre.Text;
            string tipo = this.inputTipo.Text;
            string numero = this.inputNumero.Text;
            string codigo = this.inputCodigo.Text;
            DateTime vencimiento = this.datePickerVencimiento.Value;
            string nota = this.inputNota.Text;

            Tarjeta nueva = null;

            try
            {
                nueva = new Tarjeta()
                {
                    Nombre = nombre,
                    Tipo = tipo,
                    Numero = numero,
                    Codigo = codigo,
                    Vencimiento = vencimiento,
                    Nota = nota
                };

                try
                {
                    this._actual.AgregarTarjeta(nueva, categoria);
                    agrego = true;
                }
                catch (Exception)
                {

                    this.labelErrores.Text = "Ya existe la Tarjeta que se intento agregar.";

                }
            }
            catch (Exception) {
                this.labelErrores.Text = "Hay un error en los datos ingresados";
            }

            if (agrego) {

                this.volverAListaTarjetas(e);

            }

        }


        private string LeerComboBox() {
            string nombre = (string) this.comboBoxCategorias.SelectedItem;

            return nombre;
        }


        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.volverAListaTarjetas(e);
        }


        public event EventHandler AbrirListaTarjetas_Event;
        private void volverAListaTarjetas(EventArgs e) {
            if (this.AbrirListaTarjetas_Event != null)
                this.AbrirListaTarjetas_Event(this,e);
        }

    }
}
