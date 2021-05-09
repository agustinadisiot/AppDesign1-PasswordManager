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

namespace Interfaz.InterfacesSeguridad
{
    public partial class ReporteDeFortaleza : UserControl
    {
        private Usuario _usuarioActual;

        public ReporteDeFortaleza(Usuario actual)
        {
            InitializeComponent();
            _usuarioActual = actual;
        }

        private void ReporteDeFortaleza_Load(object sender, EventArgs e)
        {
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            const string rojo = "rojo",
                naranja = "naranja",
                amarillo = "amarillo",
                verdeClaro = "verde claro",
                verdeOscuro = "verde oscuro";

            int cantidadRojos = _usuarioActual.GetCantidadColor(rojo);
            int cantidadNaranja = _usuarioActual.GetCantidadColor(naranja);
            int cantidadAmarillo = _usuarioActual.GetCantidadColor(amarillo);
            int cantidadVerdeClaro = _usuarioActual.GetCantidadColor(verdeClaro);
            int cantidadVerdeOscuro = _usuarioActual.GetCantidadColor(verdeOscuro);

            this.TablaReporte.Rows.Add(rojo, cantidadRojos);
            this.TablaReporte.Rows.Add(naranja, cantidadNaranja);
            this.TablaReporte.Rows.Add(amarillo, cantidadAmarillo);
            this.TablaReporte.Rows.Add(verdeClaro, cantidadVerdeClaro);
            this.TablaReporte.Rows.Add(verdeOscuro, cantidadVerdeOscuro);

        }

        private void botonGrafica_Click(object sender, EventArgs e)
        {
            AbrirGrafica();
        }

        public delegate void AbrirGrafica_Handler();
        public event AbrirGrafica_Handler AbrirGrafica_Event;
        public void AbrirGrafica()
        {
            if (this.AbrirGrafica_Event != null)
                this.AbrirGrafica_Event();
        }
    }
}
