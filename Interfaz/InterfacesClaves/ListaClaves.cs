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
    public partial class ListaClaves : UserControl
    {
        private Usuario _usuarioActual;
        private AdminContras _administrador;

        public ListaClaves(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            CargarTabla();
        }

        private void CargarTabla()
        {

            List<Contra> listaClaves = this._usuarioActual.GetListaClaves();

            foreach (Contra claveActual in listaClaves)
            {
                string nombreCategoria = usuarioActual.GetCategoriaClave(claveActual);
                string sitio = claveActual.Sitio;
                string usuario = claveActual.UsuarioContra;
                DateTime ultimaModificacion = claveActual.FechaModificacion;
                this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
            }
        }



        public delegate void irAVerClave_Handler(Usuario actual);

        public event irAVerClave_Handler AbrirVerClave_Event;
        public void irAVerClave(Usuario usuarioClaves)
        {
            if (this.AbrirVerClave_Event != null)
                this.AbrirVerClave_Event(usuarioClaves);
        }

        public delegate void irACompartirClave_Handler(Usuario actual);

        public event irACompartirClave_Handler AbrirCompartirClave_Event;
        public void irACompartirClave(Usuario usuarioClaves)
        {
            if (this.AbrirCompartirClave_Event != null)
                this.AbrirCompartirClave_Event(usuarioClaves);
        }

        public delegate void irAAgregarClave_Handler(Usuario actual);

        public event irAAgregarClave_Handler AbrirAgregarClave_Event;
        public void irAAgregarClave(Usuario usuarioClaves)
        {
            if (this.AbrirAgregarClave_Event != null)
                this.AbrirAgregarClave_Event(usuarioClaves);
        }

        public delegate void irAEliminarClave_Handler(Usuario actual);

        public event irAEliminarClave_Handler AbrirEliminarClave_Event;
        public void irAEliminarClave(Usuario usuarioClaves)
        {
            if (this.AbrirEliminarClave_Event != null)
                this.AbrirEliminarClave_Event(usuarioClaves);
        }

        public delegate void irAModificarClave_Handler(Usuario actual);

        public event irAModificarClave_Handler AbrirModificarClave_Event;
        public void irAModificarClave(Usuario usuarioClaves)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(usuarioClaves);
        }


        private void botonVer_Click(object sender, EventArgs e)
        {

        }

        private void botonCompartir_Click(object sender, EventArgs e)
        {

        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
        }

    }
}
