using Dominio;
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
    public partial class GraficaSeguridad : UserControl
    {
        private Usuario _actual;
        public GraficaSeguridad(Usuario usuario)
        {
            this._actual = usuario;
            InitializeComponent();
        }

        private void GraficaSeguridad_Load(object sender, EventArgs e)
        {
            this.CargarGrafica();
        }

        public void CargarGrafica() 
        {
            ColorNivelSeguridad color = new ColorNivelSeguridad();

            grafica.Series.Add(color.Rojo);
            grafica.Series[color.Rojo].Color = Color.Red;
            grafica.Series.Add(color.Naranja);
            grafica.Series[color.Naranja].Color = Color.Orange;
            grafica.Series.Add(color.Amarillo);
            grafica.Series[color.Amarillo].Color = Color.Yellow;
            grafica.Series.Add(color.VerdeClaro);
            grafica.Series[color.VerdeClaro].Color = Color.LightGreen;
            grafica.Series.Add(color.VerdeOscuro);
            grafica.Series[color.VerdeOscuro].Color = Color.DarkGreen;

            List<Categoria> listaCategorias = this._actual.GetListaCategorias();

            foreach (Categoria categoria in listaCategorias) {
                int cantidadRojo = categoria.GetListaClavesColor(color.Rojo).Count;
                int cantidadNaranja = categoria.GetListaClavesColor(color.Naranja).Count;
                int cantidadAmarillo = categoria.GetListaClavesColor(color.Amarillo).Count;
                int cantidadVerdeClaro = categoria.GetListaClavesColor(color.VerdeClaro).Count;
                int cantidadVerdeOscuro = categoria.GetListaClavesColor(color.VerdeOscuro).Count;

                grafica.Series[color.Rojo].Points.AddXY(categoria.Nombre, cantidadRojo);
                grafica.Series[color.Naranja].Points.AddXY(categoria.Nombre, cantidadNaranja);
                grafica.Series[color.Amarillo].Points.AddXY(categoria.Nombre, cantidadAmarillo);
                grafica.Series[color.VerdeClaro].Points.AddXY(categoria.Nombre, cantidadVerdeClaro);
                grafica.Series[color.VerdeOscuro].Points.AddXY(categoria.Nombre, cantidadVerdeOscuro);
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.AbrirReporteFortaleza();
        }

        public delegate void AbrirReporteFortaleza_Delegate();
        public event AbrirReporteFortaleza_Delegate AbrirReporteFortaleza_Event;
        public void AbrirReporteFortaleza()
        {
            if (this.AbrirReporteFortaleza_Event != null)
                this.AbrirReporteFortaleza_Event();
        }
    }
}
