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
    public partial class VerClave : UserControl
    {
        private Contra _claveAMostrar;
        private Usuario _usuarioActual;

        public VerClave(Contra claveAMostrar, Usuario usuarioActual)
        {
            InitializeComponent();
            _claveAMostrar = claveAMostrar;
            _usuarioActual = usuarioActual;
            this.CargarDatos();
        }

        private void CargarDatos()
        {
            Categoria categoriaAMostrar = _usuarioActual.GetCategoriaClave(_claveAMostrar);
            string nombreCateogiraAMostrar = categoriaAMostrar.Nombre;
            string sitioAMostrar = _claveAMostrar.Sitio;
            string usuarioAMostrar = _claveAMostrar.UsuarioContra;
            string codigoAMostrar = _claveAMostrar.Clave;
            string notaAMostrar = _claveAMostrar.Nota;

            this.labelCategoriaAMostrar.Text = nombreCateogiraAMostrar;
            this.labelSitioAMostrar.Text = sitioAMostrar;
            this.labelUsuarioAMostrar.Text = usuarioAMostrar;
            this.labelClaveAMostrar.Text = codigoAMostrar;
            this.labelNotasAMostrar.Text = notaAMostrar;

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            VolverAListaClaves();
        }

        public delegate void SalirDeVerClave_Handler();
        public event SalirDeVerClave_Handler SalirDeVerClave_Event;
        public void VolverAListaClaves()
        {
            if (this.SalirDeVerClave_Event != null)
                this.SalirDeVerClave_Event();
        }
    }
}