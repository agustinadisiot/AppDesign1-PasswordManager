using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaClaves : UserControl
    {
        private Usuario _usuarioActual;
        private ControladoraUsuario _controladoraUsuario;

        public ListaClaves(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._controladoraUsuario = new ControladoraUsuario();
            this._usuarioActual = usuarioAgregar;
        }

        private void ListaClaves_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void CargarTabla()
        {
            string formatoFecha = "dd'/'MM'/'yyyy";
            this.tablaClaves.Rows.Clear();
            List<Clave> listaClaves = this._controladoraUsuario.GetListaClaves(this._usuarioActual);

            foreach (Clave claveActual in listaClaves)
            {
                string nombreCategoria = this._controladoraUsuario.GetCategoriaClave(claveActual, this._usuarioActual).Nombre;
                string sitio = claveActual.Sitio;
                string usuario = claveActual.UsuarioClave;
                string ultimaModificacion = claveActual.FechaModificacion.ToString(formatoFecha);
                this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
            }
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

                Clave buscadora = new Clave()
                {
                    UsuarioClave = usuarioClaveBorrar,
                    Sitio = sitioClaveBorrar
                };

                this._controladoraUsuario.BorrarClave(buscadora, this._usuarioActual);
                this.CargarTabla();
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            IrACrearClave();
        }

        private void botonCompartir_Click(object sender, EventArgs e)
        {
            bool haySeleccionado = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionado)
            {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                string sitioClave = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                string usuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                Clave claveACompartir = new Clave()
                {
                    Sitio = sitioClave,
                    UsuarioClave = usuarioClave
                };

                Usuario compartidor = this._usuarioActual;

                ClaveCompartida aCompartir = new ClaveCompartida()
                {
                    Original= compartidor,
                    Clave = claveACompartir
                };

                IrACompartirClave(aCompartir);
            }

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

                Clave aModificar = new Clave()
                {
                    Sitio = sitioClave,
                    UsuarioClave = usuarioClave
                };

                IrAModificarClave(aModificar);
            }
        }

        private void botonVer_Click(object sender, EventArgs e)
        {

            bool haySeleccionada = this.tablaClaves.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                int posSeleccionada = this.tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaClaves.Rows[posSeleccionada];

                string sitioClaveAMostrar = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                string usuarioClaveAMostrar = Convert.ToString(selectedRow.Cells["Usuario"].Value);

                Clave buscadora = new Clave
                {
                    Sitio = sitioClaveAMostrar,
                    UsuarioClave = usuarioClaveAMostrar
                };

                AbrirVerClave(buscadora, _usuarioActual);
            }
        }

        public delegate void AbrirModificarClave_Delegate(Clave claveAModificar);
        public event AbrirModificarClave_Delegate AbrirModificarClave_Event;
        public void IrAModificarClave(Clave claveAModificar)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(claveAModificar);
        }

        public delegate void AbrirCrearClave_Delegate();
        public event AbrirCrearClave_Delegate AbrirCrearClave_Event;
        public void IrACrearClave()
        {
            if (this.AbrirCrearClave_Event != null)
                this.AbrirCrearClave_Event();
        }

        public delegate void AbrirCompartirClave_Delegate(ClaveCompartida aCompartir);
        public event AbrirCompartirClave_Delegate AbrirCompartirClave_Event;
        public void IrACompartirClave(ClaveCompartida aCompartir)
        {
            if (this.AbrirCompartirClave_Event != null)
                this.AbrirCompartirClave_Event(aCompartir);
        }


        public delegate void AbrirVerClave_Delegate(Clave buscadora, Usuario usuarioActual);
        public event AbrirVerClave_Delegate AbrirVerClave_Event;
        private void AbrirVerClave(Clave buscadora, Usuario usuarioActual)
        {
            if (this.AbrirVerClave_Event != null)
                this.AbrirVerClave_Event(buscadora, usuarioActual);
        }
    }
}
