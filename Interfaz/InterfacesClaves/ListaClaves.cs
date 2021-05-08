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
        }

        private void CargarTabla()
        {

            List<Contra> listaClaves = this._usuarioActual.GetListaClaves();

            foreach (Contra claveActual in listaClaves)
            {
                string nombreCategoria = this._usuarioActual.GetCategoriaClave(claveActual).Nombre;
                string sitio = claveActual.Sitio;
                string usuario = claveActual.UsuarioContra;
                DateTime ultimaModificacion = claveActual.FechaModificacion;
                this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
            }
        }

        private void ListaCategorias_Load(object sender, EventArgs e)
        {
            this.CargarTabla();
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



        public event EventHandler AbrirCrearClave_Event;
        public void AbrirCrearClave(EventArgs e)
        {
            if (this.AbrirCrearClave_Event != null)
                this.AbrirCrearClave_Event(this,e);
        }

        public delegate void AbrirEliminarClave_Handler(Contra claveABorrar);
        public event AbrirEliminarClave_Handler AbrirEliminarClave_Event;
        public void irAEliminarClave(Contra claveABorrar)
        {
            if (this.AbrirEliminarClave_Event != null)
                this.AbrirEliminarClave_Event(claveABorrar);
        }

        public delegate void AbrirModificarClave_Handler(Contra claveAModificar);
        public event AbrirModificarClave_Handler AbrirModificarClave_Event;
        public void irAModificarClave(Contra claveAModificar)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(claveAModificar);
        }


        private void botonVer_Click(object sender, EventArgs e)
        {

        }

        private void botonCompartir_Click(object sender, EventArgs e)
        {
            
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            AbrirCrearClave(e);
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            string sitioClave = "";
            string usuarioClave = "";
            if (this.tablaClaves.SelectedCells.Count > 0)
            {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                sitioClave = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                usuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value);
            }

            Contra aBorrar = new Contra()
            {
                Sitio = sitioClave,
                UsuarioContra = usuarioClave
            };

            //Pop up de confirmacion para eliminar(?
            _usuarioActual.BorrarContra(aBorrar);
            this.CargarTabla();
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            string sitioClave = "";
            string usuarioClave = "";
            if (this.tablaClaves.SelectedCells.Count > 0)
            {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                sitioClave = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                usuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value);
            }

            Contra aModificar = new Contra()
            {
                Sitio = sitioClave,
                UsuarioContra = usuarioClave
            };

            irAModificarClave(aModificar);
        }

    }
}
