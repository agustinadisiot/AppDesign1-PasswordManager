using Dominio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Interfaz.InterfacesClaves
{
    public partial class IngresoYListaDataBreach : UserControl
    {
        private Usuario _usuarioActual;
        private List<Clave> _claves;
        private List<Tarjeta> _tarjetas;
        private List<string> _dataBreach;

        public IngresoYListaDataBreach(Usuario actual, List<string> dataBreach)
        {
            InitializeComponent();
            this._usuarioActual = actual;
            if (dataBreach != null)
            {
                this._dataBreach = dataBreach;
            }
            else {
                this._dataBreach = new List<string>();
            }
        }

        private void IngresoYListaDataBreach_Load(object sender, EventArgs e)
        {
            if (this._dataBreach.Count>0) {
                this.CargarInputDataBreach();
                this.AnalizarDataBreach();
                this.CargarTablaClaves();
                this.CargarTablaTarjetas();
            }
        }

        private void AnalizarDataBreach()
        {
            this._claves = this._usuarioActual.GetClavesDataBreach(this._dataBreach);
            this._tarjetas = this._usuarioActual.GetTarjetasDataBreach(this._dataBreach);
        }

        private void CargarInputDataBreach() {
            string mostrar = "";

            foreach (string linea in this._dataBreach) {
                mostrar += linea + Environment.NewLine;
            }
            this.inputDatos.Text = mostrar;
        }

        private void CargarTablaClaves()
        {
            string formatoFecha = "dd'/'MM'/'yyyy";
            this.tablaClaves.Rows.Clear();

            foreach (Clave claveActual in this._claves)
            {
                string nombreCategoria = this._usuarioActual.GetCategoriaClave(claveActual).Nombre;
                string sitio = claveActual.Sitio;
                string usuario = claveActual.UsuarioClave;
                string ultimaModificacion = claveActual.FechaModificacion.ToString(formatoFecha);
                this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
            }
        }

        private void CargarTablaTarjetas()
        {
            string formatoFecha = "dd'/'MM'/'yyyy";
            this.tablaTarjetas.Rows.Clear();


            foreach (Tarjeta tarjetaActual in this._tarjetas)
            {
                string categoriaActual = this._usuarioActual.GetCategoriaTarjeta(tarjetaActual).Nombre;
                string nombre = tarjetaActual.Nombre;
                string tipo = tarjetaActual.Tipo;
                string numeroCompleto = tarjetaActual.Numero;
                string numeroOculto = OcultarTarjeta(tarjetaActual);
                string vencimiento = tarjetaActual.Vencimiento.ToString(formatoFecha);

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

        private void botonVerificar_Click(object sender, EventArgs e)
        {
            this.ProcesarIngresos();
            this.AnalizarDataBreach();
            this.CargarTablaClaves();
            this.CargarTablaTarjetas();
        }

        private void ProcesarIngresos()
        {
            string ingreso = this.inputDatos.Text;

            List<string> verificar = new List<string>(Regex.Split(ingreso, Environment.NewLine));

            this._dataBreach = verificar;
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

                this.ProcesarIngresos();

                IrAModificarClave(aModificar);
            }
        }

        public delegate void ModificarClaveDataBreach_Delegate(Clave claveAModificar, List<string> dataBreach);
        public event ModificarClaveDataBreach_Delegate ModificarClaveDataBreach_Event;
        public void IrAModificarClave(Clave claveAModificar)
        {
            if (this.ModificarClaveDataBreach_Event != null)
                this.ModificarClaveDataBreach_Event(claveAModificar, this._dataBreach);
        }

        
    }
}
