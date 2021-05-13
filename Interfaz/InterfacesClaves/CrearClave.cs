using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class CrearClave : UserControl
    {
        private Usuario _usuarioActual;

        public CrearClave(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
        }

        private void CrearClave_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.labelErrores.Text = "";
        }

        private void CargarComboBox()
        {
            this.comboBoxCategorias.Items.Clear();
            List<Categoria> lista = this._usuarioActual.GetListaCategorias();

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
            VolverAListaClaves();
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            string categoriaElegida = this.LeerComboBox();
            if (categoriaElegida != null)
            {
                Categoria categoria = new Categoria()
                {
                    Nombre = this.LeerComboBox()
                };



                try
                {
                    Clave nueva = new Clave()
                    {
                        UsuarioClave = this.inputUsuario.Text,
                        Codigo = this.inputContra.Text,
                        Nota = this.inputNota.Text,
                        Sitio = this.inputSitio.Text,
                        FechaModificacion = System.DateTime.Now.Date
                    };

                    try
                    {
                        this._usuarioActual.AgregarClave(nueva, categoria);
                        this.VolverAListaClaves();
                    }
                    catch (ObjetoYaExistenteException)
                    {

                        this.labelErrores.Text = "Error: Ya existe la contraseña que se intentó agregar.";

                    }
                }
                catch (Exception)
                {
                    this.labelErrores.Text = "Error: Datos ingresados incorrectos.";
                }
            }
            else {
                this.labelErrores.Text = "Error: Debe elegir una categoría.";
            }
        }

        private void botonGenerar_Click(object sender, EventArgs e)
        {
            try {
                GeneradoraClaves generadora = new GeneradoraClaves()
                {
                    Largo = (int)this.spinnerLargo.Value,
                    IncluirMayusculas = this.checkBoxMayusculas.Checked,
                    IncluirMinusculas = this.checkBoxMinusculas.Checked,
                    IncluirNumeros = this.checkBoxNumeros.Checked,
                    IncluirSimbolos = this.checkBoxSimbolos.Checked
                };

                this.inputContra.Text = "";

                try
                {
                    string resultado = generadora.Generar();
                    this.inputContra.Text = resultado;
                }
                catch (ClaveGeneradaVaciaException)
                {
                    this.labelErrores.Text = "Error: Se debe elegir por lo menos un tipo de carácter.";
                };
            }
            catch (LargoIncorrectoException) {
                this.labelErrores.Text = "Error: El largo de una clave debe ser entre 5 a 25 caracteres.";
            }
        }


        public delegate void AbrirListaClaves_Delegate();
        public event AbrirListaClaves_Delegate AbrirListaClaves_Event;
        public void VolverAListaClaves()
        {
            if (this.AbrirListaClaves_Event != null)
                this.AbrirListaClaves_Event();
        }
    }
}
