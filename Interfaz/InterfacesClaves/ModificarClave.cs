﻿using Obligatorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.InterfacesClaves
{
    public partial class ModificarClave : UserControl
    {
        private Usuario _actual;
        private Contra _vieja;

        public ModificarClave(Usuario usuario, Contra contra)
        {
            this._actual = usuario;
            this._vieja = contra;
            InitializeComponent();
        }

        private void ModificarClave_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.CargarInputsConClave();
            this.labelErrores.Text = "";
        }

        private void CargarInputsConClave() {
            this.inputContra.Text = this._vieja.Clave;
            this.inputNota.Text = this._vieja.Nota;
            this.inputSitio.Text = this._vieja.Sitio;
            this.inputUsuario.Text = this._vieja.UsuarioContra;
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

            Categoria pertence = this._actual.GetCategoriaClave(this._vieja);

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
                DateTime modificacion = (this._vieja.Clave == this.inputContra.Text) ? this._vieja.FechaModificacion : System.DateTime.Now.Date;

                Contra nueva = new Contra()
                {
                    UsuarioContra = this.inputUsuario.Text,
                    Sitio = this.inputSitio.Text,
                    Clave = this.inputContra.Text,
                    Nota = this.inputNota.Text,
                    FechaModificacion = modificacion
                };
                try
                {
                    ClaveAModificar aModificar = new ClaveAModificar()
                    {
                        ClaveVieja = this._vieja,
                        ClaveNueva = nueva,
                        CategoriaVieja = this._actual.GetCategoriaClave(this._vieja),
                        CategoriaNueva = categoria
                    };
                    this._actual.ModificarContra(aModificar);
                    this.AbrirListaClaves();
                }
                catch (ObjetoYaExistenteException)
                {
                    this.labelErrores.Text = "Ya existe la contraseña a la que se intento modificar.";
                }
                catch (CategoriaInexistenteException)
                {
                    this.labelErrores.Text = "No existe la categoria a la que se intento cambiar.";
                }
                catch (ObjetoInexistenteException)
                {
                    this.labelErrores.Text = "No existe la contraseña original.";
                }
            }
            catch (Exception)
            {
                this.labelErrores.Text = "Hay un error en los datos ingresados.";
            }

        }

        private void botonGenerar_Click(object sender, EventArgs e)
        {
            Contra generador = new Contra();
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
            catch (ClaveGeneradaVaciaException)
            {
                this.labelErrores.Text = "Por lo menos un tipo de caracter debe ser elegido.";
            };
            this.inputContra.Text = generador.Clave;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.AbrirListaClaves();
        }


        public delegate void AbrirListaClaves_Handler();
        public event AbrirListaClaves_Handler AbrirListaClaves_Event;
        private void AbrirListaClaves()
        {
            if (this.AbrirListaClaves_Event != null)
                this.AbrirListaClaves_Event();
        }

        
    }
}