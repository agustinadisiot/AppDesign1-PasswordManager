﻿using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz.InterfacesClaves
{
    public partial class ModificarClave : UserControl
    {
        private Usuario _actual;
        private Clave _vieja;
        private ControladoraUsuario _controladoraUsuario;

        public ModificarClave(Usuario usuario, Clave clave)
        {
            this._actual = usuario;
            this._vieja = clave;
            this._controladoraUsuario = new ControladoraUsuario();
            InitializeComponent();
        }

        private void ModificarClave_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.CargarInputsConClave();
            this.labelErrores.Text = "";
        }

        private void CargarInputsConClave() {
            this.inputContra.Text = this._vieja.Codigo;
            this.inputNota.Text = this._vieja.Nota;
            this.inputSitio.Text = this._vieja.Sitio;
            this.inputUsuario.Text = this._vieja.UsuarioClave;
        }

        private void CargarComboBox()
        {
            this.comboBoxCategorias.Items.Clear();
            List<Categoria> lista = this._controladoraUsuario.GetListaCategorias(this._actual);

            foreach (Categoria actual in lista)
            {
                string nombre = actual.Nombre;
                this.comboBoxCategorias.Items.Add(nombre);
            }

            Categoria pertence = this._controladoraUsuario.GetCategoriaClave(this._vieja, this._actual);

            this.comboBoxCategorias.SelectedItem = pertence.Nombre;


        }

        private string LeerComboBox()
        {
            string nombre = (string)this.comboBoxCategorias.SelectedItem;

            return nombre;
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria()
            {
                Nombre = this.LeerComboBox()
            };


            try
            {
                DateTime modificacion = (this._vieja.Codigo == this.inputContra.Text) ? this._vieja.FechaModificacion : System.DateTime.Now.Date;

                Clave nueva = new Clave()
                {
                    UsuarioClave = this.inputUsuario.Text,
                    Sitio = this.inputSitio.Text,
                    Codigo = this.inputContra.Text,
                    Nota = this.inputNota.Text,
                    FechaModificacion = modificacion
                };
                try
                {
                    ClaveAModificar aModificar = new ClaveAModificar()
                    {
                        ClaveVieja = this._vieja,
                        ClaveNueva = nueva,
                        CategoriaVieja = this._controladoraUsuario.GetCategoriaClave(this._vieja, this._actual),
                        CategoriaNueva = categoria
                    };
                    this._controladoraUsuario.ModificarClave(aModificar, this._actual);
                    this.CerrarModificarClave();
                }
                catch (ObjetoYaExistenteException)
                {
                    this.labelErrores.Text = "Error: Ya existe la contraseña a la que se intentó modificar.";
                }
                catch (CategoriaInexistenteException)
                {
                    this.labelErrores.Text = "Error: No existe la categoría a la que se intentó cambiar.";
                }
                catch (ObjetoInexistenteException)
                {
                    this.labelErrores.Text = "Error: No existe la contraseña original.";
                }
            }
            catch (Exception)
            {
                this.labelErrores.Text = "Error: Datos ingresados incorrectos.";
            }

        }

        private void botonGenerar_Click(object sender, EventArgs e)
        {
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

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.CerrarModificarClave();
        }
        

        public delegate void CerrarModificarClave_Delegate();
        public event CerrarModificarClave_Delegate CerrarModificarClave_Event;
        private void CerrarModificarClave()
        {
            if (this.CerrarModificarClave_Event != null)
                this.CerrarModificarClave_Event();
        }

        
    }
}
