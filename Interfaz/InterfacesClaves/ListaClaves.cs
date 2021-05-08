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

            List<Categoria> listaCategorias = this._usuarioActual.GetListaCategorias();

            foreach (Categoria categoriaActual in listaCategorias)
            {

                string nombreCategoria = categoriaActual.Nombre;
                List<Contra> listaContras = categoriaActual.GetListaContras();
                CargarFila(nombreCategoria, listaContras);
            }
        }


        private void CargarFila(string categoriaActual, List<Contra> listaContras)
        {

            foreach (Contra contraActual in listaContras)
            {

                string sitio = contraActual.Sitio;
                string usuario = contraActual.UsuarioContra;
                string ultimaModificacion = "";

                this.tablaClaves.Rows.Add(categoriaActual, sitio, usuario, ultimaModificacion);
            }
        }

        public delegate void irAVerClave_Handler(Usuario actual);

        public event irAVerClave_Handler AbrirVerClave_Event;
        public void irAVerClave(Usuario usuarioClaves)
        {
            if (this.AbrirVerClave_Event != null)
                this.AbrirVerClave_Event(usuarioClaves);
        }

        public event EventHandler AbrirCompartirClave_Event;
        public void irACompartirClave(EventArgs e)
        {
            if (this.AbrirCompartirClave_Event != null)
                this.AbrirCompartirClave_Event(this, e);
        }

        public event EventHandler AbrirAgregarClave_Event;
        public void irAAgregarClave(EventArgs e)
        {
            if (this.AbrirAgregarClave_Event != null)
                this.AbrirAgregarClave_Event(this, e);
        }

        public event EventHandler AbrirEliminarClave_Event;
        public void irAEliminarClave(EventArgs e)
        {
            if (this.AbrirEliminarClave_Event != null)
                this.AbrirEliminarClave_Event(this, e);
        }

        public event EventHandler AbrirModificarClave_Event;
        public void irAModificarClave(EventArgs e)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(this, e);
        }


        private void botonVer_Click(object sender, EventArgs e)
        {

        }

        private void botonCompartir_Click(object sender, EventArgs e)
        {
            irACompartirClave(e);
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            irAAgregarClave(e);
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            irAEliminarClave(e);
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            irAModificarClave(e);
        }

    }
}
