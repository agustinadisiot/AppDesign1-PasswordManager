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
    public partial class ListaTarjetas : UserControl
    {
        private Usuario _usuarioActual;
        private AdminContras _administrador;

        public ListaTarjetas(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            this.CargarTabla();
        }

        private void CargarTabla() {

            this.tablaTarjetas.Rows.Clear();

            List<Categoria> listaCategorias = this._usuarioActual.GetListaCategorias();

            foreach (Categoria categoriaActual in listaCategorias) {

                string nombreCategoria = categoriaActual.Nombre;
                List<Tarjeta> listaTarjetas = categoriaActual.GetListaTarjetas();
                CargarFila(nombreCategoria, listaTarjetas);
            }
        }


        private void CargarFila(string categoriaActual, List<Tarjeta> listaTarjetas) {

            foreach (Tarjeta tarjetaActual in listaTarjetas) {

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
                this._usuarioActual.BorrarTarjeta(buscadora);
                this.CargarTabla();
            }
        }


        public delegate void AbrirCrearTarjeta_Handler();
        public event AbrirCrearTarjeta_Handler AbrirCrearTarjeta_Event;
        private void AbrirCrearTarjeta(EventArgs e)
        {
            if (this.AbrirCrearTarjeta_Event != null)
                this.AbrirCrearTarjeta_Event();
        }

        public delegate void AbrirModificarTarjeta_Handler(Tarjeta modificar);
        public event AbrirModificarTarjeta_Handler AbrirModificarTarjeta_Event;
        private void AbrirModificarTarjeta(Tarjeta modificar)
        {
            if (this.AbrirModificarTarjeta_Event != null)
                this.AbrirModificarTarjeta_Event(modificar);
        }

        public delegate void AbrirVerTarjeta_Handler(Tarjeta modificar);
        public event AbrirVerTarjeta_Handler AbrirVerTarjeta_Event;
        private void AbrirVerTarjeta(Tarjeta ver)
        {
            if (this.AbrirVerTarjeta_Event != null)
                this.AbrirVerTarjeta_Event(ver);
        }

    }
}
