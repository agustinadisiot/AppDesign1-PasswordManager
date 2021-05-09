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
            const string rojo = "rojo",
                   naranja = "naranja",
                   amarillo = "amarillo",
                   verdeClaro = "verde claro",
                   verdeOscuro = "verde oscuro";


            grafica.Series.Add(rojo);
            grafica.Series[rojo].Color = Color.Red;
            grafica.Series.Add(naranja);
            grafica.Series[naranja].Color = Color.Orange;
            grafica.Series.Add(amarillo);
            grafica.Series[amarillo].Color = Color.Yellow;
            grafica.Series.Add(verdeClaro);
            grafica.Series[verdeClaro].Color = Color.LightGreen;
            grafica.Series.Add(verdeOscuro);
            grafica.Series[verdeOscuro].Color = Color.DarkGreen;



            List<Categoria> listaCategorias = this._actual.GetListaCategorias();

            foreach (Categoria categoria in listaCategorias) {
                int cantidadRojo = 0;
                int cantidadNaranja = 0;
                int cantidadAmarillo = 0;
                int cantidadVerdeClaro = 0;
                int cantidadVerdeOscuro = 0;

                List<Contra> listaContra = categoria.GetListaContras();

                foreach (Contra clave in listaContra) {
                    switch (clave.GetNivelSeguridad()) {
                        case rojo:
                            cantidadRojo++;
                            break;
                        case naranja:
                            cantidadNaranja++;
                            break;
                        case amarillo:
                            cantidadAmarillo++;
                            break;
                        case verdeClaro:
                            cantidadVerdeClaro++;
                            break;
                        case verdeOscuro:
                            cantidadVerdeOscuro++;
                            break;
                    }
                }

                grafica.Series[rojo].Points.AddXY(categoria.Nombre, cantidadRojo);
                grafica.Series[naranja].Points.AddXY(categoria.Nombre, cantidadNaranja);
                grafica.Series[amarillo].Points.AddXY(categoria.Nombre, cantidadAmarillo);
                grafica.Series[verdeClaro].Points.AddXY(categoria.Nombre, cantidadVerdeClaro);
                grafica.Series[verdeOscuro].Points.AddXY(categoria.Nombre, cantidadVerdeOscuro);
            }
        }
    }
}
