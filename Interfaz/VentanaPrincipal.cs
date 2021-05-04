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
    public partial class VentanaPrincipal : Form
    {

        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public VentanaPrincipal()
        {
            this._administrador = new AdminContras();

            Usuario usuarioPrueba = new Usuario();
            usuarioPrueba.Nombre = "Roberto";
            usuarioPrueba.ContraMaestra = "12345ABCD";
            this._administrador.AgregarUsuario(usuarioPrueba);


            Categoria trabajo = new Categoria() 
            {
                   Nombre = "Trabajo"
            };

            Categoria personal = new Categoria()
            {
                Nombre = "Personal"
            };

            usuarioPrueba.AgregarCategoria(trabajo);
            usuarioPrueba.AgregarCategoria(personal);

            Tarjeta tarjetaPrueba1 = new Tarjeta()
            {
                Nombre = "Itau",
                Tipo = "Visa",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta tarjetaPrueba2 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "2222567890876543",
                Codigo = "8904",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            usuarioPrueba.AgregarTarjeta(tarjetaPrueba1, trabajo);

            usuarioPrueba.AgregarTarjeta(tarjetaPrueba2, personal);

            this._usuarioActual = usuarioPrueba;
            InitializeComponent();

        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            UserControl listaTarjetas = new ListaTarjetas(this._usuarioActual, this._administrador);
            panelForm.Controls.Add(listaTarjetas);
        }
    }
}
