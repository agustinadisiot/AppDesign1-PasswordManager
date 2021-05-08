using Interfaz.InterfacesCompartirClave;
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

            this._usuarioActual = null;
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
                Numero = "1111111111111111",
                Codigo = "111",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            Tarjeta tarjetaPrueba2 = new Tarjeta()
            {
                Nombre = "Prex",
                Tipo = "Mastercard",
                Numero = "2222222222222222",
                Codigo = "2222",
                Vencimiento = new DateTime(2025, 7, 1)
            };

            usuarioPrueba.AgregarTarjeta(tarjetaPrueba1, trabajo);

            usuarioPrueba.AgregarTarjeta(tarjetaPrueba2, personal);

            Contra clavePrueba1 = new Contra()
            {
                Sitio = "www.ort.edu.uy",
                UsuarioContra = "usuarioClave1",
                Clave = "12345678"
            };

            Contra clavePrueba2 = new Contra()
            {
                Sitio = "www.netflix.com",
                UsuarioContra = "usuarioClave2",
                Clave = "12345678"
            };

            usuarioPrueba.AgregarContra(clavePrueba1, trabajo);
            usuarioPrueba.AgregarContra(clavePrueba2, personal);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuarioPrueba2,
                Clave = clavePrueba1
            };

            ClaveCompartida claveACompartir2 = new ClaveCompartida()
            {
                Usuario = usuarioPrueba2,
                Clave = clavePrueba2
            };

            usuarioPrueba.CompartirClave(claveACompartir1);

            usuarioPrueba.CompartirClave(claveACompartir2);

            InitializeComponent();

        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion(this._administrador);

            this.panelDrawer.Visible = false;

            iniciarSesion.IniciarSesion_Event += IniciarSesion_Handler;
            iniciarSesion.AbrirCrearUsuario_Event += AbrirCrearUsuario_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(iniciarSesion);
        }
        
        private void IniciarSesion_Handler(Usuario aIngresar)
        {
            this._usuarioActual = aIngresar;
            ListaCategorias listaCategorias = new ListaCategorias(this._usuarioActual, this._administrador);
            listaCategorias.AbrirAgregarCategorias_Event += AbrirAgregarCategorias_Handler;
            listaCategorias.AbrirModificarCategorias_Event +=AbrirModificarCategorias_Handler;

            this.panelDrawer.Visible = true;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaCategorias);
        }

        private void AbrirCrearUsuario_Handler()
        {
            CrearUsuario crearUsuario = new CrearUsuario(this._administrador);
            crearUsuario.AbrirIniciarSesion_Event += AbrirIniciarSesion_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(crearUsuario);
        }


        private void AbrirIniciarSesion_Handler()
        {
            IniciarSesion iniciarSesion = new IniciarSesion(this._administrador);

            iniciarSesion.IniciarSesion_Event += IniciarSesion_Handler;
            iniciarSesion.AbrirCrearUsuario_Event += AbrirCrearUsuario_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(iniciarSesion);
        }

        protected void AbrirListaCategorias_Handler()
        {

            ListaCategorias listaCategorias = new ListaCategorias(this._usuarioActual, this._administrador);
            listaCategorias.AbrirAgregarCategorias_Event += AbrirAgregarCategorias_Handler;
            listaCategorias.AbrirModificarCategorias_Event += AbrirModificarCategorias_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaCategorias);
        }

        protected void AbrirAgregarCategorias_Handler()
        {

            AgregarCategoria agregarCategoria = new AgregarCategoria(this._usuarioActual, this._administrador);
            agregarCategoria.AbrirListaCategorias_Event += AbrirListaCategorias_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(agregarCategoria);
        }

        protected void AbrirModificarCategorias_Handler(Categoria aModificar)
        {

            ModificarCategoria modificarCategoria = new ModificarCategoria(aModificar, this._usuarioActual);
            modificarCategoria.AbrirListaCategorias_Event += AbrirListaCategorias_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(modificarCategoria);
        }

        protected void AbrirCrearTarjeta_Handler(object sender, EventArgs e)
        {
            this.panelPrincipal.Controls.Clear();
            CrearTarjeta crearTarjetas = new CrearTarjeta(this._usuarioActual);
            crearTarjetas.AbrirListaTarjetas_Event += new EventHandler(this.AbrirListaTarjetas_Handler);
            this.panelPrincipal.Controls.Add(crearTarjetas);
        }

        protected void AbrirModificarTarjeta_Handler(Tarjeta buscadora)
        {
            Tarjeta modificar = this._usuarioActual.GetTarjeta(buscadora);
            ModificarTarjeta modificarTarjeta = new ModificarTarjeta(this._usuarioActual, modificar);
            modificarTarjeta.AbrirListaTarjetas_Event += new EventHandler(this.AbrirListaTarjetas_Handler);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(modificarTarjeta);
        }

        protected void AbrirListaTarjetas_Handler(object sender, EventArgs e) {
            this.panelPrincipal.Controls.Clear();

            ListaTarjetas listaTarjetas = new ListaTarjetas(this._usuarioActual, this._administrador);
            listaTarjetas.AbrirCrearTarjeta_Event += new EventHandler(this.AbrirCrearTarjeta_Handler);
            listaTarjetas.AbrirModificarTarjeta_Event += this.AbrirModificarTarjeta_Handler;
            this.panelPrincipal.Controls.Add(listaTarjetas);
        }

        private void botonListaCategorias_Click(object sender, EventArgs e)
        {
            ListaCategorias listaCategorias = new ListaCategorias(this._usuarioActual, this._administrador);
            listaCategorias.AbrirAgregarCategorias_Event += AbrirAgregarCategorias_Handler;
            listaCategorias.AbrirModificarCategorias_Event += AbrirModificarCategorias_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaCategorias);
        }

        private void botonListaClaves_Click(object sender, EventArgs e)
        {
            ListaClaves listaClaves = new ListaClaves(this._usuarioActual, this._administrador);

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaClaves);

        }

        private void botonListaTarjetas_Click(object sender, EventArgs e)
        {
            ListaTarjetas listaTarjetas = new ListaTarjetas(this._usuarioActual, this._administrador);
            listaTarjetas.AbrirCrearTarjeta_Event += new EventHandler(this.AbrirCrearTarjeta_Handler);
            listaTarjetas.AbrirModificarTarjeta_Event += this.AbrirModificarTarjeta_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaTarjetas);
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion(this._administrador);
            iniciarSesion.IniciarSesion_Event += IniciarSesion_Handler;

            this.panelDrawer.Visible = false;

            this.panelPrincipal.Controls.Clear();

            panelPrincipal.Controls.Add(iniciarSesion);

        }

        private void botonClavesQueMeComparten_Click(object sender, EventArgs e)
        {
            ListaClavesCompartidasConmigo listaClavesCompartidasConmigo = new ListaClavesCompartidasConmigo(this._usuarioActual, this._administrador);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(listaClavesCompartidasConmigo);
        }

        private void botonClavesQueComparto_Click(object sender, EventArgs e)
        {
            ListaClavesCompartidasPorMi listaClavesCompartidasPorMi = new ListaClavesCompartidasPorMi(this._usuarioActual, this._administrador);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(listaClavesCompartidasPorMi);
        }



    }
}
