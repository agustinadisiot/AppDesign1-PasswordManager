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
            ListaTarjetas listaTarjetas = new ListaTarjetas(this._usuarioActual, this._administrador);
            ListaCategorias listaCategotias = new ListaCategorias(this._usuarioActual, this._administrador);

            AgregarCategoria agregarCategoria = new AgregarCategoria(this._usuarioActual, this._administrador);
            agregarCategoria.AbrirListaCategorias_Event += new EventHandler(this.AbrirListaCategorias_Handler);

            ModificarCategoria modificarCategoria = new ModificarCategoria(this._usuarioActual.GetListaCategorias()[0], this._usuarioActual);
            modificarCategoria.AbrirListaCategorias_Event += new EventHandler(this.AbrirListaCategorias_Handler);

            panelForm.Controls.Add(agregarCategoria);
        }

        protected void AbrirListaCategorias_Handler(object sender, EventArgs e)
        {
            this.panelForm.Controls.Clear();

            ListaCategorias listarCategorias = new ListaCategorias(this._usuarioActual, this._administrador);

            this.panelForm.Controls.Add(listarCategorias);
        }

    }
}
