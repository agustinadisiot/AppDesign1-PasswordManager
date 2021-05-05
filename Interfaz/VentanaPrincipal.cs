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
    public partial class VentanaPrincipal : Form
    {

        private AdminContras _administrador;
        private Usuario _usuarioActual;

        public VentanaPrincipal()
        {
            this._administrador = new AdminContras();

            Usuario usuarioPrueba = new Usuario();
            usuarioPrueba.Nombre = "Roberto";
            usuarioPrueba.ContraMaestra = "12345ABCD";

            Usuario usuarioPrueba2 = new Usuario();
            usuarioPrueba2.Nombre = "Santiago";
            usuarioPrueba2.ContraMaestra = "ClaveUsuario123";

            this._administrador.AgregarUsuario(usuarioPrueba);
            this._administrador.AgregarUsuario(usuarioPrueba2);


            Categoria trabajo = new Categoria() 
            {
                   Nombre = "Trabajo"
            };

            Categoria personal = new Categoria()
            {
                Nombre = "Personal"
            };

            usuarioPrueba.AgregarCategoria(trabajo);
            usuarioPrueba.AgregarCategoria(personal);

            Tarjeta tarjetaPrueba1 = new Tarjeta()
            {
                Nombre = "Itau",
                Tipo = "Visa",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta tarjetaPrueba2 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "2222567890876543",
                Codigo = "8904",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            usuarioPrueba.AgregarTarjeta(tarjetaPrueba1, trabajo);

            usuarioPrueba.AgregarTarjeta(tarjetaPrueba2, personal);

            this._usuarioActual = usuarioPrueba;
            InitializeComponent();

        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            ListaTarjetas listaTarjetas = new ListaTarjetas(this._usuarioActual,this._administrador);

            listaTarjetas.AbrirCrearTarjeta_Event += new EventHandler(this.AbrirCrearTarjeta_Handler);
            listaTarjetas.AbrirModificarTarjeta_Event += new EventHandler(this.AbrirModificarTarjeta_Handler);
            this.panelPrincipal.Controls.Add(listaTarjetas);
        }

        protected void AbrirCrearTarjeta_Handler(object sender, EventArgs e)
        {
            this.panelPrincipal.Controls.Clear();
            CrearTarjeta crearTarjetas = new CrearTarjeta(this._usuarioActual);
            crearTarjetas.AbrirListaTarjetas_Event += new EventHandler(this.AbrirListaTarjetas_Handler);
            this.panelPrincipal.Controls.Add(crearTarjetas);
        }

        protected void AbrirModificarTarjeta_Handler(object sender, EventArgs e)
        {
            this.panelPrincipal.Controls.Clear();
            Tarjeta tarjetaPrueba1 = new Tarjeta()
            {
                Nombre = "Itau",
                Tipo = "Visa",
                Numero = "3456567890876543",
                Codigo = "321",
                Vencimiento = new DateTime(2025, 7, 1)
            };
            ModificarTarjeta modificarTarjeta = new ModificarTarjeta(this._usuarioActual, tarjetaPrueba1);
            modificarTarjeta.AbrirListaTarjetas_Event += new EventHandler(this.AbrirListaTarjetas_Handler);
            this.panelPrincipal.Controls.Add(modificarTarjeta);
        }

        protected void AbrirListaTarjetas_Handler(object sender, EventArgs e) {
            this.panelPrincipal.Controls.Clear();

            ListaTarjetas listaTarjetas = new ListaTarjetas(this._usuarioActual, this._administrador);
            listaTarjetas.AbrirCrearTarjeta_Event += new EventHandler(this.AbrirCrearTarjeta_Handler);
            listaTarjetas.AbrirModificarTarjeta_Event += new EventHandler(this.AbrirModificarTarjeta_Handler);
            this.panelPrincipal.Controls.Add(listaTarjetas);
        }

    }
}
