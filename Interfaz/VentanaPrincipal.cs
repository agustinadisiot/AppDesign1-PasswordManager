using Interfaz.InterfacesClaves;
using Interfaz.InterfacesCompartirClave;
using Interfaz.InterfacesSeguridad;
using Interfaz.InterfacesTarjetas;
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
        private Type _panelAVolverVerClave;
        private Type _panelAVolverModificarClave;
        private List<string> _ultimoDataBreach;

        public VentanaPrincipal()
        {
            this._administrador = new AdminContras();

            this._usuarioActual = null;
            Usuario usuarioPrueba = new Usuario();
            usuarioPrueba.Nombre = "Roberto";
            usuarioPrueba.ContraMaestra = "12345ABCD";

            Usuario usuarioPrueba2 = new Usuario();
            usuarioPrueba2.Nombre = "Santiago";
            usuarioPrueba2.ContraMaestra = "12345SD";


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

            clavePrueba1.FechaModificacion = new DateTime(2000, 1, 1);
            clavePrueba2.FechaModificacion = new DateTime(2000, 1, 1);

            usuarioPrueba.AgregarContra(clavePrueba1, trabajo);
            usuarioPrueba.AgregarContra(clavePrueba2, personal);

            ClaveCompartida claveACompartir1 = new ClaveCompartida()
            {
                Usuario = usuarioPrueba2,
                Clave = clavePrueba1
            };

            usuarioPrueba.CompartirClave(claveACompartir1);

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

        private void botonListaCategorias_Click(object sender, EventArgs e)
        {
            this.AbrirListaCategorias_Handler();
        }

        private void botonListaClaves_Click(object sender, EventArgs e)
        {
            this.AbrirListaClaves_Handler();

        }

        private void botonListaTarjetas_Click(object sender, EventArgs e)
        {
            this.AbrirListaTarjetas_Handler();
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            string texto = "¿Estas seguro que quieres cerrar la sesión?";
            VentanaConfirmaciones ventanaConfirmar = new VentanaConfirmaciones(texto);
            ventanaConfirmar.CerrarConfirmacion_Event += CerrarConfirmacion_Handler;
            ventanaConfirmar.ShowDialog();

        }

        private void botonClavesQueMeComparten_Click(object sender, EventArgs e)
        {
            AbrirListaClavesCompartidasConmigo_Handler();
        }

        private void botonClavesQueComparto_Click(object sender, EventArgs e)
        {
            AbrirListaClavesCompartidasPorMi_Handler();
        }

        private void botonReporteFortaleza_Click(object sender, EventArgs e)
        {
            AbrirReporteFortaleza_Handler();
        }

        private void botonDataBreaches_Click(object sender, EventArgs e)
        {
            this.AbrirDataBreaches_Handler(null);
        }


        private void CerrarConfirmacion_Handler(bool acepto)
        {
            if (acepto)
            {
                IniciarSesion iniciarSesion = new IniciarSesion(this._administrador);
                iniciarSesion.IniciarSesion_Event += IniciarSesion_Handler;
                iniciarSesion.AbrirCrearUsuario_Event += this.AbrirCrearUsuario_Handler;
                this.panelDrawer.Visible = false;

                this.panelPrincipal.Controls.Clear();
                panelPrincipal.Controls.Add(iniciarSesion);
            }
            else
            {

            }
        }

        private void IniciarSesion_Handler(Usuario aIngresar)
        {
            this._usuarioActual = aIngresar;
            ListaCategorias listaCategorias = new ListaCategorias(this._usuarioActual, this._administrador);
            listaCategorias.AbrirAgregarCategorias_Event += AbrirAgregarCategorias_Handler;
            listaCategorias.AbrirModificarCategorias_Event += AbrirModificarCategorias_Handler;

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

        protected void AbrirListaTarjetas_Handler()
        {
            this.panelPrincipal.Controls.Clear();

            ListaTarjetas listaTarjetas = new ListaTarjetas(this._usuarioActual, this._administrador);
            listaTarjetas.AbrirCrearTarjeta_Event += this.AbrirCrearTarjeta_Handler;
            listaTarjetas.AbrirModificarTarjeta_Event += this.AbrirModificarTarjeta_Handler;
            listaTarjetas.AbrirVerTarjeta_Event += this.AbrirVerTarjeta_Handler;
            this.panelPrincipal.Controls.Add(listaTarjetas);
        }

        protected void AbrirVerClave_Handler(Contra buscadora, Usuario usuarioABuscar)
        {
            foreach (Control p in this.panelPrincipal.Controls)
            {
                this._panelAVolverVerClave = p.GetType();
            }

            Usuario usuarioAMostrar = this._administrador.GetUsuario(usuarioABuscar);
            Contra claveAMostrar = usuarioAMostrar.GetContra(buscadora);
            VerClave verClaveSeleccionada = new VerClave(claveAMostrar, usuarioAMostrar);
            verClaveSeleccionada.SalirDeVerClave_Event += this.SalirDeVerClave_Handler;
            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(verClaveSeleccionada);
        }

        private void ModificarClaveDataBreach_Event(Contra buscadora, List<string> dataBreach) {
            this._ultimoDataBreach = dataBreach;
            this.AbrirModificarClave_Event(buscadora);
        }

        private void AbrirModificarClave_Event(Contra buscadora)
        {

            foreach (Control p in this.panelPrincipal.Controls)
            {
                this._panelAVolverModificarClave = p.GetType();
            }

            Contra modificar = this._usuarioActual.GetContra(buscadora);
            ModificarClave modificarClave = new ModificarClave(this._usuarioActual, modificar);
            modificarClave.CerrarModificarClave_Event += CerrarModificarClave_Event;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(modificarClave);
        }

        protected void CerrarModificarClave_Event() {
            switch (this._panelAVolverModificarClave.Name)
            {
                case "IngresoYListaDataBreach":
                    this.AbrirDataBreaches_Handler(this._ultimoDataBreach);
                    break;
                case "ReporteDeFortaleza":
                    this.AbrirReporteFortaleza_Handler();
                    break;
                default:
                    this.AbrirListaClaves_Handler();
                    break;
            }
        }

        protected void AbrirCrearClave_Handler()
        {
            CrearClave crearClave = new CrearClave(this._usuarioActual, this._administrador);
            crearClave.AbrirListaClaves_Event += this.AbrirListaClaves_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(crearClave);
        }

        protected void AbrirCompartirClave_Handler(ClaveCompartida aCompartir)
        {
            CompartirClave compartirClave = new CompartirClave(aCompartir, this._administrador);
            compartirClave.AbrirListaClaves_Event += this.AbrirListaClaves_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(compartirClave);
        }

        protected void SalirDeVerClave_Handler()
        {
            switch (this._panelAVolverVerClave.Name)
            {
                case "ListaClavesCompartidasPorMi":
                    AbrirListaClavesCompartidasPorMi_Handler();
                    break;

                case "ListaClavesCompartidasConmigo":
                    AbrirListaClavesCompartidasConmigo_Handler();
                    break;

                case "ListaClaves":
                    AbrirListaClaves_Handler();
                    break;
                case "ReporteDeFortaleza":
                    AbrirReporteFortaleza_Handler();
                    break;
                default:
                    AbrirListaCategorias_Handler();
                    break;
            }
        }

        protected void AbrirListaClaves_Handler()
        {
            ListaClaves listaClaves = new ListaClaves(this._usuarioActual, this._administrador);
            listaClaves.AbrirCrearClave_Event += this.AbrirCrearClave_Handler;
            listaClaves.AbrirModificarClave_Event += this.AbrirModificarClave_Event;
            listaClaves.AbrirCompartirClave_Event += this.AbrirCompartirClave_Handler;
            listaClaves.AbrirVerClave_Event += this.AbrirVerClave_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(listaClaves);
        }

        protected void AbrirListaClavesCompartidasConmigo_Handler()
        {

            ListaClavesCompartidasConmigo listaClavesCompartidasConmigo = new ListaClavesCompartidasConmigo(this._usuarioActual, this._administrador);
            listaClavesCompartidasConmigo.AbrirVerClave_Event += this.AbrirVerClave_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaClavesCompartidasConmigo);
        }

        protected void AbrirListaClavesCompartidasPorMi_Handler()
        {

            ListaClavesCompartidasPorMi listaClavesCompartidasPorMi = new ListaClavesCompartidasPorMi(this._usuarioActual, this._administrador);
            listaClavesCompartidasPorMi.AbrirVerClave_Event += this.AbrirVerClave_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaClavesCompartidasPorMi);
        }

        protected void AbrirCrearTarjeta_Handler()
        {
            this.panelPrincipal.Controls.Clear();
            CrearTarjeta crearTarjetas = new CrearTarjeta(this._usuarioActual);
            crearTarjetas.AbrirListaTarjetas_Event += this.AbrirListaTarjetas_Handler;
            this.panelPrincipal.Controls.Add(crearTarjetas);
        }

        protected void AbrirModificarTarjeta_Handler(Tarjeta buscadora)
        {
            Tarjeta modificar = this._usuarioActual.GetTarjeta(buscadora);
            ModificarTarjeta modificarTarjeta = new ModificarTarjeta(this._usuarioActual, modificar);
            modificarTarjeta.AbrirListaTarjetas_Event += this.AbrirListaTarjetas_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(modificarTarjeta);
        }

        private void AbrirVerTarjeta_Handler(Tarjeta buscadora)
        {
            Tarjeta ver = this._usuarioActual.GetTarjeta(buscadora);
            VerTarjeta verTarjeta = new VerTarjeta(ver, this._usuarioActual);
            verTarjeta.AbrirListaTarjetas_Event += this.AbrirListaTarjetas_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(verTarjeta);
        }

        private void AbrirDataBreaches_Handler(List<string> dataBreach) {
            IngresoYListaDataBreach panelDataBreach = new IngresoYListaDataBreach(this._usuarioActual, dataBreach);
            panelDataBreach.ModificarClaveDataBreach_Event += this.ModificarClaveDataBreach_Event;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(panelDataBreach);
        }

        private void AbrirGrafica_Handler()
        {
            GraficaSeguridad grafica = new GraficaSeguridad(this._usuarioActual);
            grafica.AbrirReporteFortaleza_Event += AbrirReporteFortaleza_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(grafica);
        }

        private void AbrirReporteFortaleza_Handler()
        {
            ReporteDeFortaleza reporteFortaleza = new ReporteDeFortaleza(this._usuarioActual);
            reporteFortaleza.AbrirGrafica_Event += AbrirGrafica_Handler;
            reporteFortaleza.AbrirVerClave_Event += AbrirVerClave_Handler;
            reporteFortaleza.AbrirModificarClave_Event += AbrirModificarClave_Event;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(reporteFortaleza);

        }
    }
}
