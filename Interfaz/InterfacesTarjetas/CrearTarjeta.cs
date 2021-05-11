using Dominio;
using System;
using System.Collections.Generic;
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
            this.datePickerVencimiento.CustomFormat = "MM '/' yyyy";

        }

        private void CargarComboBox() {
            this.comboBoxCategorias.Items.Clear();
            List<Categoria> lista = this._actual.GetListaCategorias();

            foreach (Categoria actual in lista) {

                string nombre = actual.Nombre;
                this.comboBoxCategorias.Items.Add(nombre);
            }
        }

        private void botonCrear_Click(object sender, EventArgs e)
        {
            string valorComboBox = this.LeerComboBox();

            if (valorComboBox != null)
            {
                Categoria categoria = new Categoria()
                {
                    Nombre = valorComboBox
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
                        this.VolverAListaTarjetas();
                    }
                    catch (Exception)
                    {

                        this.labelErrores.Text = "Ya existe la Tarjeta que se intento agregar.";

                    }
                }
                catch (Exception)
                {
                    this.labelErrores.Text = "Hay un error en los datos ingresados";
                }
            }
            else {
                this.labelErrores.Text = "Debe elegir una categoria";
            }

            
        }

        private string LeerComboBox() {
            string nombre = (string) this.comboBoxCategorias.SelectedItem;

            return nombre;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.VolverAListaTarjetas();
        }

        public delegate void AbrirListaTarjetas_Delegate();
        public event AbrirListaTarjetas_Delegate AbrirListaTarjetas_Event;
        private void VolverAListaTarjetas()
        {
            if (this.AbrirListaTarjetas_Event != null)
                this.AbrirListaTarjetas_Event();
        }

    }
}
