using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ListaTarjetas : UserControl
    {
        private Usuario _usuarioActual;

        public ListaTarjetas(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this.CargarTabla();
        }

        private void CargarTabla() {
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            string formatoTarjeta = "MM'/'yyyy";
            this.tablaTarjetas.Rows.Clear();

            List<Tarjeta> listaTarjeta = controladoraUsuario.GetListaTarjetas(this._usuarioActual);

            foreach (Tarjeta tarjetaActual in listaTarjeta) {
                string categoriaActual = controladoraUsuario.GetCategoriaTarjeta(tarjetaActual, this._usuarioActual).Nombre;
                string nombre = tarjetaActual.Nombre;
                string tipo = tarjetaActual.Tipo;
                string numeroCompleto = tarjetaActual.Numero;
                string numeroOculto = OcultarTarjeta(tarjetaActual);
                string vencimiento = tarjetaActual.Vencimiento.ToString(formatoTarjeta);

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

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            this.AbrirCrearTarjeta();
        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            bool haySeleccionada = this.tablaTarjetas.SelectedCells.Count > 0;
            if (haySeleccionada)
            {
                int posSeleccionada = this.tablaTarjetas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaTarjetas.Rows[posSeleccionada];
                string numero = Convert.ToString(selectedRow.Cells["TarjetaCompleta"].Value);


                Tarjeta buscadora = new Tarjeta()
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
                
                
                Tarjeta buscadora = new Tarjeta()
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
            ControladoraUsuario controladoraUsuario = new ControladoraUsuario();
            bool haySeleccionada = this.tablaTarjetas.SelectedCells.Count > 0;
            if (haySeleccionada && acepto)
            {
                int posSeleccionada = this.tablaTarjetas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = this.tablaTarjetas.Rows[posSeleccionada];

                string numeroTarjetaBorrar = Convert.ToString(selectedRow.Cells["TarjetaCompleta"].Value);

                Tarjeta buscadora = new Tarjeta()
                {
                    Numero = numeroTarjetaBorrar
                };
                controladoraUsuario.BorrarTarjeta(buscadora, this._usuarioActual);
                this.CargarTabla();
            }
        }


        public delegate void AbrirCrearTarjeta_Delegate();
        public event AbrirCrearTarjeta_Delegate AbrirCrearTarjeta_Event;
        private void AbrirCrearTarjeta()
        {
            if (this.AbrirCrearTarjeta_Event != null)
                this.AbrirCrearTarjeta_Event();
        }

        public delegate void AbrirModificarTarjeta_Delegate(Tarjeta modificar);
        public event AbrirModificarTarjeta_Delegate AbrirModificarTarjeta_Event;
        private void AbrirModificarTarjeta(Tarjeta modificar)
        {
            if (this.AbrirModificarTarjeta_Event != null)
                this.AbrirModificarTarjeta_Event(modificar);
        }

        public delegate void AbrirVerTarjeta_Delegate(Tarjeta modificar);
        public event AbrirVerTarjeta_Delegate AbrirVerTarjeta_Event;
        private void AbrirVerTarjeta(Tarjeta ver)
        {
            if (this.AbrirVerTarjeta_Event != null)
                this.AbrirVerTarjeta_Event(ver);
        }

    }
}
