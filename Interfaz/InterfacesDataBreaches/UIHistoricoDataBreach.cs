using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz.InterfacesDataBreaches
{
    public partial class UIHistoricoDataBreach : UserControl
    {
        private ControladoraAdministrador _controladoraAdministrador;
        private ControladoraUsuario _controladoraUsuario;
        private ControladoraCategoria _controladoraCategoria;
        private Usuario _usuarioActual;
        private DataBreach _dataBreach;

        public UIHistoricoDataBreach(Usuario usuario)
        {
            this._controladoraAdministrador = new ControladoraAdministrador();
            this._controladoraUsuario = new ControladoraUsuario();
            this._controladoraCategoria = new ControladoraCategoria();
            InitializeComponent();
            this._usuarioActual = usuario;
            this._dataBreach = null;
        }

        private void UIHistoricoDataBreach_Load(object sender, EventArgs e)
        {
            this.CargarTablaDataBreaches();
            this.labelMensajes.Text = "";
        }

        private void CargarTablaDataBreaches() {
            string formatoFecha = "yyyy'/'MMM'/'dd' 'HH':'mm':'ss";
            this.tablaDataBreaches.Rows.Clear();
            foreach (DataBreach actual in this._usuarioActual.DataBreaches) {
                string fecha = actual.Fecha.ToString(formatoFecha);
                this.tablaDataBreaches.Rows.Add(fecha);
            }
        }

        private void CargarTablaClaves()
        {
            this.tablaClaves.Rows.Clear();

            foreach (Clave claveActual in this._dataBreach.Claves)
            {
                Categoria categoriaActual = this._controladoraUsuario.GetCategoriaClave(claveActual, this._usuarioActual);
                Clave enCategoria = this._controladoraCategoria.GetClave(claveActual, categoriaActual);
                string nombreCategoria = categoriaActual.Nombre;
                string sitio = enCategoria.Sitio;
                string usuario = enCategoria.UsuarioClave;
                string fueModificado = "No";
                if (enCategoria.FechaModificacion > this._dataBreach.Fecha) {
                    fueModificado = "Si";
                }
                this.tablaClaves.Rows.Add(nombreCategoria, sitio, usuario, fueModificado);
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

        private void tablaClaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tablaClaves.Columns[e.ColumnIndex].Name == "Modificar") {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                bool fueModificado = Convert.ToString(selectedRow.Cells["FueModificado"].Value) == "Si";
                if (fueModificado) {
                    this.labelMensajes.Text = "Esta clave ya fue modificada.";
                }
                else {
                    Clave buscadora = new Clave() {
                        Sitio = Convert.ToString(selectedRow.Cells["Sitio"].Value),
                        UsuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value)
                    };
                    Clave aModificar = this._controladoraUsuario.GetClave(buscadora, this._usuarioActual);
                    VentanaModificarClave ventanaModificar = new VentanaModificarClave(this._usuarioActual, aModificar );
                    if (ventanaModificar.ShowDialog() == DialogResult.OK)
                    {
                        this.labelMensajes.Text = "Modifico";
                        this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
                    }
                    else
                    {
                        this.labelMensajes.Text = "Cancelo";
                    }
                }
            }
        }

        private void tablaDataBreaches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tablaDataBreaches.SelectedCells.Count > 0) {
                int selectedrowindex = tablaDataBreaches.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaDataBreaches.Rows[selectedrowindex];
                DateTime fecha = DateTime.Parse(selectedRow.Cells["Fecha"].Value.ToString());

                this._dataBreach = this._controladoraUsuario.GetDataBreach(fecha, this._usuarioActual);
                this.CargarTablaClaves();
                this.CargarTablaTarjetas();
            }
        }

        private void botonVerFiltradas_Click(object sender, EventArgs e)
        {
            if (this._dataBreach != null) {
                List<Filtrada> filtradas = this._dataBreach.Filtradas;
                VentanaFiltradas ventana = new VentanaFiltradas(filtradas);
                ventana.ShowDialog();
            }
        }

        private void botonModificarClave_Click(object sender, EventArgs e)
        {
            if (this.tablaClaves.SelectedCells.Count > 0)
            {
                int selectedrowindex = tablaClaves.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = tablaClaves.Rows[selectedrowindex];
                string sitioClave = Convert.ToString(selectedRow.Cells["Sitio"].Value);
                string usuarioClave = Convert.ToString(selectedRow.Cells["Usuario"].Value);
                bool fueModificado = Convert.ToString(selectedRow.Cells["FueModificado"].Value) == "Si";
                if (fueModificado)
                {
                    this.labelMensajes.Text = "Esta clave ya fue modificada.";
                }
                else {
                    Clave buscadora = new Clave()
                    {
                        Sitio = sitioClave,
                        UsuarioClave = usuarioClave
                    };
                    Clave aModificar = this._controladoraUsuario.GetClave(buscadora, this._usuarioActual);
                    VentanaModificarClave ventanaModificar = new VentanaModificarClave(this._usuarioActual, aModificar);
                    if (ventanaModificar.ShowDialog() == DialogResult.OK)
                    {
                        this.labelMensajes.Text = "Modifico";
                        this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
                        this.CargarTablaClaves();
                    }
                    else
                    {
                        this.labelMensajes.Text = "Cancelo";
                    }
                }
            }
        }
    }
}
