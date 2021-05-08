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
            this.CargarInputsConTarjeta();
            this.labelErrores.Text = "";
        }

        private void CargarInputsConTarjeta() {

            this.inputNombre.Text = this._modificar.Nombre;
            this.inputTipo.Text = this._modificar.Tipo;
            this.inputNumero.Text = this._modificar.Numero;
            this.inputCodigo.Text = this._modificar.Codigo;
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
            this.comboBoxCategorias.SelectedIndex = 0;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.volverAListaTarjetas(e);
        }

        private void botonModificar_Click(object sender, EventArgs e)
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
                    this._actual.ModificarTarjetaCategoria(this._modificar, nueva);
                    this.volverAListaTarjetas(e);
                }
                catch (ObjetoYaExistenteException)
                {

                    this.labelErrores.Text = "Ya existe la Tarjeta a la que se intento modificar.";

                }
                catch (ObjetoInexistenteException)
                {

                    this.labelErrores.Text = "No existe la tarjeta original.";

                }
            }
            catch (Exception)
            {
                this.labelErrores.Text = "Hay un error en los datos ingresados";
            }

        }

        private string LeerComboBox()
        {
            string nombre = (string)this.comboBoxCategorias.SelectedItem;

            return nombre;
        }

        public event EventHandler AbrirListaTarjetas_Event;
        private void volverAListaTarjetas(EventArgs e)
        {
            if (this.AbrirListaTarjetas_Event != null)
                this.AbrirListaTarjetas_Event(this, e);
        }
    }
}
