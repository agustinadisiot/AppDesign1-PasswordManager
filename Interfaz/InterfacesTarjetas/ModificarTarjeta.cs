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

namespace Interfaz
{
    public partial class ModificarTarjeta : UserControl
    {
        private Usuario _actual;
        private Tarjeta _vieja;

        public ModificarTarjeta(Usuario usuario, Tarjeta tarjeta )
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
            List<Categoria> lista = this._actual.GetListaCategorias();

            foreach (Categoria actual in lista)
            {

                string nombre = actual.Nombre;
                this.comboBoxCategorias.Items.Add(nombre);
            }

            Categoria pertence = this._actual.GetCategoriaTarjeta(this._vieja);

            this.comboBoxCategorias.SelectedItem = pertence.Nombre;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.volverAListaTarjetas(e);
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria()
            {
                Nombre = this.LeerComboBox()
            };

            try
            {
                Tarjeta nueva = new Tarjeta()
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
                    this.volverAListaTarjetas(e);
                }
                catch (ObjetoYaExistenteException)
                {
                    this.labelErrores.Text = "Ya existe la Tarjeta a la que se intento modificar.";
                }
                catch (CategoriaInexistenteException)
                {
                    this.labelErrores.Text = "No existe la categoria a la que se intento cambiar.";
                }
                catch (ObjetoInexistenteException)
                {
                    this.labelErrores.Text = "No existe la tarjeta original.";
                }
            }
            catch (Exception)
            {
                this.labelErrores.Text = "Hay un error en los datos ingresados.";
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
