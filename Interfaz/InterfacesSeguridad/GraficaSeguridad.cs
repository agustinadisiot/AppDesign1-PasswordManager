using LogicaDeNegocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class GraficaSeguridad : UserControl
    {
        private Usuario _actual;
        private ControladoraCategoria _controladoraCategoria;
        private ControladoraUsuario _controladoraUsuario;
        public GraficaSeguridad(Usuario usuario)
        {
            this._actual = usuario;
            this._controladoraCategoria = new ControladoraCategoria();
            this._controladoraUsuario = new ControladoraUsuario();
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

            List<Categoria> listaCategorias = this._controladoraUsuario.GetListaCategorias(this._actual);

            foreach (Categoria categoria in listaCategorias) {
                int cantidadRojo = this._controladoraCategoria.GetListaClavesColor(color.Rojo, categoria).Count;
                int cantidadNaranja = this._controladoraCategoria.GetListaClavesColor(color.Naranja, categoria).Count;
                int cantidadAmarillo = this._controladoraCategoria.GetListaClavesColor(color.Amarillo, categoria).Count;
                int cantidadVerdeClaro = this._controladoraCategoria.GetListaClavesColor(color.VerdeClaro, categoria).Count;
                int cantidadVerdeOscuro = this._controladoraCategoria.GetListaClavesColor(color.VerdeOscuro, categoria).Count;

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
