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
    public partial class AgregarCategoria : UserControl
    {
        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public AgregarCategoria(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            string nombreCategoria = this.textNombreCategoria.Text;

            Categoria nuevaCategoria = new Categoria
            {
                Nombre = nombreCategoria
            };

            this.textNombreCategoria.Clear();

            _usuarioActual.AgregarCategoria(nuevaCategoria);

        }
    }
}
