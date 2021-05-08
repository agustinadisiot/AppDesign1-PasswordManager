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
                string numeroOculto = "XXXX XXXX XXXX " + numeroCompleto.Substring(12, 4);
                string vencimiento = tarjetaActual.Vencimiento.ToString();

                this.tablaTarjetas.Rows.Add(categoriaActual, nombre, tipo, numeroOculto, numeroCompleto, vencimiento);
            }
        }


        private string FormatearTarjeta(Tarjeta actual)
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

        public event EventHandler AbrirCrearTarjeta_Event;
        private void AbrirCrearTarjeta(EventArgs e)
        {
            if (this.AbrirCrearTarjeta_Event != null)
                this.AbrirCrearTarjeta_Event(this, e);
        }

        public delegate void AbrirModificarTarjeta_Handler(Tarjeta modificar);
        public event AbrirModificarTarjeta_Handler AbrirModificarTarjeta_Event;
        private void AbrirModificarTarjeta(Tarjeta modificar)
        {
            if (this.AbrirModificarTarjeta_Event != null)
                this.AbrirModificarTarjeta_Event(modificar);
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
    }
}
