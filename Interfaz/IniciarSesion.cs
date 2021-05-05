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
    public partial class IniciarSesion : UserControl
    {
        private AdminContras _administrador;

        public IniciarSesion(AdminContras administrador)
        {
            this._administrador = administrador;
            InitializeComponent();


        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            this.labelErrores.Text = "";
        }

        private void botonIniciar_Click(object sender, EventArgs e)
        {
            try
            {


                Usuario nuevo = new Usuario()
                {
                    Nombre = this.inputUsuario.Text,
                    ContraMaestra = this.inputContra.Text
                };

                try {
                    this._administrador.AgregarUsuario(nuevo);
                    this.EnviarIniciarSesion(nuevo);

                }
                catch (Exception) {
                    this.labelErrores.Text = "Ya existe el Usuario";
                }

            }
            catch (Exception) {
                this.labelErrores.Text = "Los datos ingresados contienen un error.";
            }
        }


        public delegate void IniciarSesion_Handler(Usuario actual);

        public event IniciarSesion_Handler IniciarSesion_Event;

        private void EnviarIniciarSesion(Usuario aIniciar) {
            if (this.IniciarSesion_Event != null)
                this.IniciarSesion_Event(aIniciar);
        }

        
    }
}
