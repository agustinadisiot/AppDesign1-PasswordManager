using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class CrearClave : UserControl
    {
        private Usuario _usuarioActual;
        private ControladoraUsuario _controladoraUsuario;
        private ControladoraEncriptador _controladoraEncriptador;

        public CrearClave(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._controladoraEncriptador = new ControladoraEncriptador();
            this._controladoraUsuario = new ControladoraUsuario();
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
            
            List<Categoria> lista = this._controladoraUsuario.GetListaCategorias(this._usuarioActual);

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

                    NivelSeguridad nivelSeguridad = new NivelSeguridad();
                    nivelSeguridad.ClaveCumpleRequerimientos(nueva.Codigo, _usuarioActual);


                    this._controladoraUsuario.AgregarClave(nueva, categoria, _usuarioActual);
                    this.VolverAListaClaves();
                }
                catch (Exception x)
                {
                    this.labelErrores.Text = x.Message;
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
