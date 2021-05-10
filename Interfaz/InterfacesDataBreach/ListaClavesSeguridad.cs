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

namespace Interfaz.InterfacesClaves
{
    public partial class ListaClavesSeguridad : UserControl
    {
        private Usuario _usuarioActual;
        private List<Contra> _claves;
        private List<Tarjeta> _tarjetas;
        private List<string> _dataBreach;

        public ListaClavesSeguridad(Usuario actual, List<string> dataBreach)
        {
            InitializeComponent();
            this._dataBreach = dataBreach;
            this.AnalizarDataBreach();
        }

        private void ListaClavesSeguridad_Load(object sender, EventArgs e)
        {
            this.CargarTablaClaves();
            this.CargarTablaTarjetas();
        }

        private void AnalizarDataBreach() {
            this._claves = this._usuarioActual.GetContrasDataBreach(this._dataBreach);
            this._tarjetas = this._usuarioActual.GetTarjetasDataBreach(this._dataBreach);
        }


        private void CargarTablaClaves()
        {
            this.tablaClaves.Rows.Clear();

            foreach (Contra claveActual in this._claves)
            {
                string nombreCategoria = this._usuarioActual.GetCategoriaClave(claveActual).Nombre;
                string sitio = claveActual.Sitio;
                string usuario = claveActual.UsuarioContra;
                DateTime ultimaModificacion = claveActual.FechaModificacion;
                this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
            }
        }

        private void CargarTablaTarjetas()
        {

            this.tablaTarjetas.Rows.Clear();


            foreach (Tarjeta tarjetaActual in this._tarjetas)
            {
                string categoriaActual = this._usuarioActual.GetCategoriaTarjeta(tarjetaActual).Nombre;
                string nombre = tarjetaActual.Nombre;
                string tipo = tarjetaActual.Tipo;
                string numeroCompleto = tarjetaActual.Numero;
                string numeroOculto = OcultarTarjeta(tarjetaActual);
                string vencimiento = tarjetaActual.Vencimiento.ToString();

                this.tablaTarjetas.Rows.Add(categoriaActual, nombre, tipo, numeroOculto, numeroCompleto, vencimiento);
            }
        }
        private string OcultarTarjeta(Tarjeta actual)
        {

            string numero = actual.Numero;
            string tarjetaAMostrar = "XXXX XXXX XXXX ";

            const int posicionPrimerDigitoAMostrar = 12;

            string digitosFinales = numero.Substring(posicionPrimerDigitoAMostrar);

            tarjetaAMostrar += digitosFinales;

            return tarjetaAMostrar;

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
                //this.CargarTabla();
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


        public delegate void AbrirModificarClave_Handler(Contra claveAModificar);
        public event AbrirModificarClave_Handler AbrirModificarClave_Event;
        public void irAModificarClave(Contra claveAModificar)
        {
            if (this.AbrirModificarClave_Event != null)
                this.AbrirModificarClave_Event(claveAModificar);
        }

        
    }


}
