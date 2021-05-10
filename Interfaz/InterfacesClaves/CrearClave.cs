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
    public partial class CrearClave : UserControl
    {
        private Usuario _usuarioActual;
        private Administrador _administrador;

        public CrearClave(Usuario usuarioAgregar, Administrador administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
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
                        this._usuarioActual.AgregarContra(nueva, categoria);
                        this.VolverAListaClaves();
                    }
                    catch (ObjetoYaExistenteException)
                    {

                        this.labelErrores.Text = "Ya existe la Clave que se intento agregar.";

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

        private void botonGenerar_Click(object sender, EventArgs e)
        {

            Clave generador = new Clave();
            ClaveAGenerar parametros = new ClaveAGenerar()
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
                generador.GenerarClave(parametros);
            }
            catch (ClaveGeneradaVaciaException) {
                this.labelErrores.Text = "Por lo menos un tipo de caracter debe ser elegido.";
            };
            this.inputContra.Text = generador.Codigo;
        }


        public delegate void AbrirListaClaves_Handler();
        public event AbrirListaClaves_Handler AbrirListaClaves_Event;
        public void VolverAListaClaves()
        {
            if (this.AbrirListaClaves_Event != null)
                this.AbrirListaClaves_Event();
        }
    }
}
