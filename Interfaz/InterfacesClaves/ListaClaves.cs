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
            this.CargarTabla();
        }

        private void ListaCategorias_Load(object sender, EventArgs e)
        {
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.tablaClaves.Rows.Clear();
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
        

        private void botonVer_Click(object sender, EventArgs e)
        {

        }
        
        

        private void CerrarConfirmacion_Handler(bool acepto)
        {
            bool haySeleccionada = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionada && acepto)
            {
                int posSeleccionada = this.tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaClaves.Rows[posSeleccionada];

                string usuarioClaveBorrar = Convert.ToString(selectedRow.Cells["Usuario"].Value);
                string sitioClaveBorrar = Convert.ToString(selectedRow.Cells["Sitio"].Value);

                Contra buscadora = new Contra()
                {
                    UsuarioContra = usuarioClaveBorrar,
                    Sitio = sitioClaveBorrar
                };
                this._usuarioActual.BorrarContra(buscadora);
                this.CargarTabla();
            }
        }


        private void botonAgregar_Click(object sender, EventArgs e)
        {
            irACrearClave();
        }

        private void botonCompartir_Click(object sender, EventArgs e)
        {
            string sitioClave = "";
            string usuarioClave = "";
            if (this.tablaClaves.SelectedCells.Count > 0)
            {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                sitioClave = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                usuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                Contra aCompartir = new Contra()
                {
                    Sitio = sitioClave,
                    UsuarioContra = usuarioClave
                };

                irACompartirClave(aCompartir);
            }

        }



        public delegate void AbrirModificarClave_Handler(Contra claveAModificar);
        public event AbrirModificarClave_Handler AbrirModificarClave_Event;
        public void irAModificarClave(Contra claveAModificar)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(claveAModificar);
        }

        public delegate void AbrirCrearClave_Handler();
        public event AbrirCrearClave_Handler AbrirCrearClave_Event;
        public void irACrearClave()
        {
            if (this.AbrirCrearClave_Event != null)
                this.AbrirCrearClave_Event();
        }


        public delegate void AbrirVerClave_Handler(Usuario actual);
        public event AbrirVerClave_Handler AbrirVerClave_Event;
        public void irAVerClave(Usuario usuarioClaves)
        {
            if (this.AbrirVerClave_Event != null)
                this.AbrirVerClave_Event(usuarioClaves);
        }

        public delegate void AbrirCompartirClave_Handler(Contra compartir);
        public event AbrirCompartirClave_Handler AbrirCompartirClave_Event;
        public void irACompartirClave(Contra compartir)
        {
            if (this.AbrirCompartirClave_Event != null)
                this.AbrirCompartirClave_Event(compartir);
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                string texto = "¿Estas seguro que quieres eliminar esta contraseña?";
                VentanaConfirmaciones ventanaConfirmar = new VentanaConfirmaciones(texto);
                ventanaConfirmar.CerrarConfirmacion_Event += CerrarConfirmacion_Handler;
                ventanaConfirmar.ShowDialog();
            }
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

                Contra aModificar = new Contra()
                {
                    Sitio = sitioClave,
                    UsuarioContra = usuarioClave
                };

                irAModificarClave(aModificar);
            }
        }
    }
}
