using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ModificarTarjeta : UserControl
    {
        private ControladoraUsuario _actual;
        private ControladoraTarjeta _vieja;

        public ModificarTarjeta(ControladoraUsuario usuario, ControladoraTarjeta tarjeta )
        {
            this._actual = usuario;
            this._vieja = tarjeta;
            InitializeComponent();
        }

        private void ModificarTarjeta_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.CargarInputsConTarjeta();
            this.labelErrores.Text = "";
            this.datePickerVencimiento.CustomFormat = "MM '/' yyyy";
        }

        private void CargarInputsConTarjeta() {

            this.inputNombre.Text = this._vieja.Nombre;
            this.inputTipo.Text = this._vieja.Tipo;
            this.inputNumero.Text = this._vieja.Numero;
            this.inputCodigo.Text = this._vieja.Codigo;
            this.datePickerVencimiento.Value = this._vieja.Vencimiento;
            this.inputNota.Text = this._vieja.Nota;
        }

        private void CargarComboBox()
        {

            this.comboBoxCategorias.Items.Clear();
            List<ControladoraCategoria> lista = this._actual.GetListaCategorias();

            foreach (ControladoraCategoria actual in lista)
            {

                string nombre = actual.Nombre;
                this.comboBoxCategorias.Items.Add(nombre);
            }

            ControladoraCategoria pertence = this._actual.GetCategoriaTarjeta(this._vieja);

            this.comboBoxCategorias.SelectedItem = pertence.Nombre;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.VolverAListaTarjetas();
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            ControladoraCategoria categoria = new ControladoraCategoria()
            {
                Nombre = this.LeerComboBox()
            };

            try
            {
                ControladoraTarjeta nueva = new ControladoraTarjeta()
                {
                    Nombre = this.inputNombre.Text,
                    Tipo = this.inputTipo.Text,
                    Numero = this.inputNumero.Text,
                    Codigo = this.inputCodigo.Text,
                    Vencimiento = this.datePickerVencimiento.Value,
                    Nota = this.inputNota.Text
                };
                try
                {
                    TarjetaAModificar aModificar = new TarjetaAModificar()
                    {
                        TarjetaVieja = this._vieja,
                        TarjetaNueva = nueva,
                        CategoriaVieja = this._actual.GetCategoriaTarjeta(this._vieja),
                        CategoriaNueva = categoria
                    };
                    this._actual.ModificarTarjeta(aModificar);
                    this.VolverAListaTarjetas();
                }
                catch (ObjetoYaExistenteException)
                {
                    this.labelErrores.Text = "Error: Ya existe la Tarjeta a la que se intentó modificar.";
                }
                catch (CategoriaInexistenteException)
                {
                    this.labelErrores.Text = "Error: No existe la categoria a la que se intentó cambiar.";
                }
                catch (ObjetoInexistenteException)
                {
                    this.labelErrores.Text = "Error: No existe la tarjeta original.";
                }
            }
            catch (Exception)
            {
                this.labelErrores.Text = "Error: Datos ingresados incorrectos.";
            }

        }

        private string LeerComboBox()
        {
            string nombre = (string)this.comboBoxCategorias.SelectedItem;

            return nombre;
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
