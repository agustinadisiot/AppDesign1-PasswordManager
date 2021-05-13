using Interfaz.InterfacesClaves;
using Interfaz.InterfacesCompartirClave;
using Interfaz.InterfacesSeguridad;
using Interfaz.InterfacesTarjetas;
using Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Interfaz
{
    public partial class VentanaPrincipal : Form
    {

        private Administrador _administrador;
        private Usuario _usuarioActual;
        private Type _panelAVolverVerClave;
        private Type _panelAVolverModificarClave;
        private List<string> _ultimoDataBreach;

        public VentanaPrincipal()
        {
            this._administrador = new Administrador();

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
            this.ResetearColoresBotonesDrawer();
        }

        private void ResetearColoresBotonesDrawer() {
            this.botonListaCategorias.BackColor = Color.FromArgb(51, 51, 51);
            this.botonListaClaves.BackColor = Color.FromArgb(51, 51, 51);
            this.botonClavesQueComparto.BackColor = Color.FromArgb(51, 51, 51);
            this.botonClavesQueMeComparten.BackColor = Color.FromArgb(51, 51, 51);
            this.botonListaTarjetas.BackColor = Color.FromArgb(51, 51, 51);
            this.botonReporteFortaleza.BackColor = Color.FromArgb(51, 51, 51);
            this.botonDataBreaches.BackColor = Color.FromArgb(51, 51, 51);
        }

        private void botonListaCategorias_Click(object sender, EventArgs e)
        {
            this.ResetearColoresBotonesDrawer();
            this.botonListaCategorias.BackColor = Color.FromArgb(138, 138, 138);

            this.AbrirListaCategorias_Handler();
        }

        private void botonListaClaves_Click(object sender, EventArgs e)
        {
            this.ResetearColoresBotonesDrawer();
            this.botonListaClaves.BackColor = Color.FromArgb(138, 138, 138);
            
            this.AbrirListaClaves_Handler();
        }

        private void botonListaTarjetas_Click(object sender, EventArgs e)
        {
            this.ResetearColoresBotonesDrawer();
            this.botonListaTarjetas.BackColor = Color.FromArgb(138, 138, 138);
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
            this.ResetearColoresBotonesDrawer();
            this.botonClavesQueMeComparten.BackColor = Color.FromArgb(138, 138, 138);
            AbrirListaClavesCompartidasConmigo_Handler();
        }

        private void botonClavesQueComparto_Click(object sender, EventArgs e)
        {
            this.ResetearColoresBotonesDrawer();
            this.botonClavesQueComparto.BackColor = Color.FromArgb(138, 138, 138);
            AbrirListaClavesCompartidasPorMi_Handler();
        }

        private void botonReporteFortaleza_Click(object sender, EventArgs e)
        {
            this.ResetearColoresBotonesDrawer();
            this.botonReporteFortaleza.BackColor = Color.FromArgb(138, 138, 138);
            AbrirReporteFortaleza_Handler();
        }

        private void botonDataBreaches_Click(object sender, EventArgs e)
        {
            this.ResetearColoresBotonesDrawer();
            this.botonDataBreaches.BackColor = Color.FromArgb(138, 138, 138);
            this.AbrirDataBreaches_Handler(null);
        }


        private void CerrarConfirmacion_Handler(bool acepto)
        {
            if (acepto)
            {
                this.ResetearColoresBotonesDrawer();
                IniciarSesion iniciarSesion = new IniciarSesion(this._administrador);
                iniciarSesion.IniciarSesion_Event += IniciarSesion_Handler;
                iniciarSesion.AbrirCrearUsuario_Event += this.AbrirCrearUsuario_Handler;
                this.panelDrawer.Visible = false;

                this.panelPrincipal.Controls.Clear();
                panelPrincipal.Controls.Add(iniciarSesion);
            }
        }

        private void IniciarSesion_Handler(Usuario aIngresar)
        {
            this._usuarioActual = aIngresar;
            ListaCategorias listaCategorias = new ListaCategorias(this._usuarioActual);
            listaCategorias.AbrirAgregarCategorias_Event += AbrirAgregarCategorias_Handler;
            listaCategorias.AbrirModificarCategorias_Event += AbrirModificarCategorias_Handler;

            this.panelDrawer.Visible = true;

            this.labelUsuarioActual.Text = _usuarioActual.Nombre;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(listaCategorias);
            this.botonListaCategorias.BackColor = Color.FromArgb(137, 137, 137);
            
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

            ListaCategorias listaCategorias = new ListaCategorias(this._usuarioActual);
            listaCategorias.AbrirAgregarCategorias_Event += AbrirAgregarCategorias_Handler;
            listaCategorias.AbrirModificarCategorias_Event += AbrirModificarCategorias_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaCategorias);
        }

        protected void AbrirAgregarCategorias_Handler()
        {

            AgregarCategoria agregarCategoria = new AgregarCategoria(this._usuarioActual);
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

            ListaTarjetas listaTarjetas = new ListaTarjetas(this._usuarioActual);
            listaTarjetas.AbrirCrearTarjeta_Event += this.AbrirCrearTarjeta_Handler;
            listaTarjetas.AbrirModificarTarjeta_Event += this.AbrirModificarTarjeta_Handler;
            listaTarjetas.AbrirVerTarjeta_Event += this.AbrirVerTarjeta_Handler;
            this.panelPrincipal.Controls.Add(listaTarjetas);
        }

        protected void AbrirVerClave_Handler(Clave buscadora, Usuario usuarioABuscar)
        {
            foreach (Control p in this.panelPrincipal.Controls)
            {
                this._panelAVolverVerClave = p.GetType();
            }

            Usuario usuarioAMostrar = this._administrador.GetUsuario(usuarioABuscar);
            Clave claveAMostrar = usuarioAMostrar.GetClave(buscadora);
            VerClave verClaveSeleccionada = new VerClave(claveAMostrar, usuarioAMostrar);
            verClaveSeleccionada.SalirDeVerClave_Event += this.SalirDeVerClave_Handler;
            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(verClaveSeleccionada);
        }

        private void ModificarClaveDataBreach_Event(Clave buscadora, List<string> dataBreach) {
            this._ultimoDataBreach = dataBreach;
            this.AbrirModificarClave_Event(buscadora);
        }

        private void AbrirModificarClave_Event(Clave buscadora)
        {

            foreach (Control p in this.panelPrincipal.Controls)
            {
                this._panelAVolverModificarClave = p.GetType();
            }

            Clave modificar = this._usuarioActual.GetClave(buscadora);
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
            CrearClave crearClave = new CrearClave(this._usuarioActual);
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
            ListaClaves listaClaves = new ListaClaves(this._usuarioActual);
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
