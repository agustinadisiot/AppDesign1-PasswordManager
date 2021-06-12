using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaTarjetas : UserControl
    {
        private ControladoraUsuario _usuarioActual;

        public ListaTarjetas(ControladoraUsuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this.CargarTabla();
        }

        private void CargarTabla() {

            string formatoTarjeta = "MM'/'yyyy";
            this.tablaTarjetas.Rows.Clear();

            List<ControladoraTarjeta> listaTarjeta = this._usuarioActual.GetListaTarjetas();

            foreach (ControladoraTarjeta tarjetaActual in listaTarjeta) {
                string categoriaActual = this._usuarioActual.GetCategoriaTarjeta(tarjetaActual).Nombre;
                string nombre = tarjetaActual.Nombre;
                string tipo = tarjetaActual.Tipo;
                string numeroCompleto = tarjetaActual.Numero;
                string numeroOculto = OcultarTarjeta(tarjetaActual);
                string vencimiento = tarjetaActual.Vencimiento.ToString(formatoTarjeta);

                this.tablaTarjetas.Rows.Add(categoriaActual, nombre, tipo, numeroOculto, numeroCompleto, vencimiento);
            }
        }

        private string OcultarTarjeta(ControladoraTarjeta actual)
        {

            string numero = actual.Numero;
            string tarjetaAMostrar = "XXXX XXXX XXXX ";

            const int posicionPrimerDigitoAMostrar = 12;

            string digitosFinales = numero.Substring(posicionPrimerDigitoAMostrar);

            tarjetaAMostrar += digitosFinales;

            return tarjetaAMostrar;

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            this.AbrirCrearTarjeta(e);
        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaTarjetas.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                int posSeleccionada = this.tablaTarjetas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaTarjetas.Rows[posSeleccionada];
                string numero = Convert.ToString(selectedRow.Cells["TarjetaCompleta"].Value);


                ControladoraTarjeta buscadora = new ControladoraTarjeta()
                {
                    Numero = numero
                };
                this.AbrirVerTarjeta(buscadora);
            }
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaTarjetas.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                int posSeleccionada = this.tablaTarjetas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaTarjetas.Rows[posSeleccionada];
                string numero = Convert.ToString(selectedRow.Cells["TarjetaCompleta"].Value);
                
                
                ControladoraTarjeta buscadora = new ControladoraTarjeta()
                {
                    Numero = numero
                };
                this.AbrirModificarTarjeta(buscadora);
            }
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaTarjetas.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                string texto = "¿Estas seguro que quieres eliminar esta tarjeta?";
                VentanaConfirmaciones ventanaConfirmar = new VentanaConfirmaciones(texto);
                ventanaConfirmar.CerrarConfirmacion_Event += CerrarConfirmacion_Handler;
                ventanaConfirmar.ShowDialog();
            }
        }

        private void CerrarConfirmacion_Handler(bool acepto)
        {
            bool haySeleccionada = this.tablaTarjetas.SelectedCells.Count > 0;
            if (haySeleccionada && acepto)
            {
                int posSeleccionada = this.tablaTarjetas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaTarjetas.Rows[posSeleccionada];

                string numeroTarjetaBorrar = Convert.ToString(selectedRow.Cells["TarjetaCompleta"].Value);

                ControladoraTarjeta buscadora = new ControladoraTarjeta()
                {
                    Numero = numeroTarjetaBorrar
                };
                this._usuarioActual.BorrarTarjeta(buscadora);
                this.CargarTabla();
            }
        }


        public delegate void AbrirCrearTarjeta_Delegate();
        public event AbrirCrearTarjeta_Delegate AbrirCrearTarjeta_Event;
        private void AbrirCrearTarjeta(EventArgs e)
        {
            if (this.AbrirCrearTarjeta_Event != null)
                this.AbrirCrearTarjeta_Event();
        }

        public delegate void AbrirModificarTarjeta_Delegate(ControladoraTarjeta modificar);
        public event AbrirModificarTarjeta_Delegate AbrirModificarTarjeta_Event;
        private void AbrirModificarTarjeta(ControladoraTarjeta modificar)
        {
            if (this.AbrirModificarTarjeta_Event != null)
                this.AbrirModificarTarjeta_Event(modificar);
        }

        public delegate void AbrirVerTarjeta_Delegate(ControladoraTarjeta modificar);
        public event AbrirVerTarjeta_Delegate AbrirVerTarjeta_Event;
        private void AbrirVerTarjeta(ControladoraTarjeta ver)
        {
            if (this.AbrirVerTarjeta_Event != null)
                this.AbrirVerTarjeta_Event(ver);
        }

    }
}
