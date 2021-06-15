using Interfaz.InterfacesDataBreaches;
using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Interfaz.InterfacesClaves
{
    public partial class IngresoYListaDataBreach : UserControl
    {
        private ControladoraAdministrador _controladoraAdministrador;
        private ControladoraUsuario _controladoraUsuario;
        private ControladoraDataBreach _controladoraDataBreach;
        private Usuario _usuarioActual;
        private DataBreach _dataBreach;

        public IngresoYListaDataBreach(Usuario actual, bool cargarUltimoDataBreach)
        {
            InitializeComponent();
            this._controladoraAdministrador = new ControladoraAdministrador();
            this._controladoraUsuario = new ControladoraUsuario();
            this._controladoraDataBreach = new ControladoraDataBreach();
            this._usuarioActual = actual;
            if (cargarUltimoDataBreach)
            {
                this._dataBreach = this._controladoraUsuario.GetUltimoDataBreach(actual);
            }
            else {
                this._dataBreach = null;
            }
            this.labelErrores.Text = "";
        }

        private void IngresoYListaDataBreach_Load(object sender, EventArgs e)
        {
            if (this._dataBreach != null) {
                this.CargarInputDataBreach(this._dataBreach.Filtradas);
                this.procesarDataBreach();
            }
        }


        private void CargarInputDataBreach(List<Filtrada> filtradas) {
            string mostrar = "";

            foreach (Filtrada linea in filtradas) {
                mostrar += linea.Texto + Environment.NewLine;
            }
            this.inputDatos.Text = mostrar;
        }

        private void CargarTablaClaves()
        {
            string formatoFecha = "dd'/'MM'/'yyyy";
            this.tablaClaves.Rows.Clear();

            foreach (Clave claveActual in this._dataBreach.Claves)
            {
                Clave enCategoria = this._controladoraUsuario.GetClave(claveActual, _usuarioActual);
                if (enCategoria.FechaModificacion < this._dataBreach.Fecha)
                {
                    Categoria categoriaActual = this._controladoraUsuario.GetCategoriaClave(enCategoria, this._usuarioActual);
                    string nombreCategoria = categoriaActual.Nombre;
                    string sitio = enCategoria.Sitio;
                    string usuario = enCategoria.UsuarioClave;
                    string ultimaModificacion = enCategoria.FechaModificacion.ToString(formatoFecha);
                    this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, ultimaModificacion);
                }
            }
        }

        private void CargarTablaTarjetas()
        {
            string formatoFecha = "MM'/'yyyy";
            this.tablaTarjetas.Rows.Clear();


            foreach (Tarjeta tarjetaActual in this._dataBreach.Tarjetas)
            {
                Categoria categoriaActual = this._controladoraUsuario.GetCategoriaTarjeta(tarjetaActual, this._usuarioActual);
                string nombreCategoria = categoriaActual.Nombre;
                string nombre = tarjetaActual.Nombre;
                string tipo = tarjetaActual.Tipo;
                string numeroCompleto = tarjetaActual.Numero;
                string numeroOculto = OcultarTarjeta(tarjetaActual);
                string vencimiento = tarjetaActual.Vencimiento.ToString(formatoFecha);

                this.tablaTarjetas.Rows.Add(nombreCategoria, nombre, tipo, numeroOculto, numeroCompleto, vencimiento);
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
            this.procesarDataBreach();
        }

        private void procesarDataBreach() {
            IngresoDataBreachUI ingresoDataBreachUI = new IngresoDataBreachUI();
            this._dataBreach = new DataBreach();
            List<Filtrada> filtradas = ingresoDataBreachUI.DevolverFiltradas(this.inputDatos.Text);
            this._controladoraDataBreach.AgregarDataBreach(filtradas, DateTime.Now, this._usuarioActual);
            this._dataBreach = this._controladoraUsuario.GetUltimoDataBreach(this._usuarioActual);
            this.CargarTablaClaves();
            this.CargarTablaTarjetas();
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

                Clave buscadora = new Clave()
                {
                    Sitio = sitioClave,
                    UsuarioClave = usuarioClave
                };
                Clave aModificar = this._controladoraUsuario.GetClave(buscadora, this._usuarioActual);
                VentanaModificarClave ventanaModificar = new VentanaModificarClave(this._usuarioActual, aModificar);
                if (ventanaModificar.ShowDialog() == DialogResult.OK) 
                {
                    this.labelErrores.Text = "Modifico una clave";
                    this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
                    this.CargarTablaClaves();
                }
                else
                {
                    this.labelErrores.Text = "Cancelo la modificacion";
                }
            }
        }

        private void botonCargar_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog buscadorArchivo = new OpenFileDialog())
            {
                buscadorArchivo.Filter = "Text|*.txt|All|*.*";
                if (buscadorArchivo.ShowDialog() == DialogResult.OK)
                {
                    string direccion = buscadorArchivo.FileName;
                    IngresoDataBreachTxt ingresoDataBreachTxt = new IngresoDataBreachTxt();
                    try
                    {   
                        List<Filtrada> aMostrar = ingresoDataBreachTxt.DevolverFiltradas(direccion);
                        this.CargarInputDataBreach(aMostrar);
                    }
                    catch (Exception)
                    {
                        this.labelErrores.Text = "Error: No se logro cargar el archivo";
                    }
                }
            }
        }
    }
}
