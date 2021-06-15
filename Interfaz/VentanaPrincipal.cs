using Interfaz.InterfacesClaves;
using Interfaz.InterfacesCompartirClave;
using Interfaz.InterfacesSeguridad;
using Interfaz.InterfacesTarjetas;
using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Negocio;
using Interfaz.InterfacesDataBreaches;

namespace Interfaz
{
    public partial class VentanaPrincipal : Form
    {

        private ControladoraAdministrador _controladoraAdministrador;
        private ControladoraUsuario _controladoraUsuario;
        private Usuario _usuarioActual;
        private Type _panelAVolverVerClave;
        private Type _panelAVolverModificarClave;

        public VentanaPrincipal()
        {
            this._controladoraAdministrador = new ControladoraAdministrador();
            this._controladoraUsuario = new ControladoraUsuario();
            InitializeComponent();

        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();

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
            this.botonHistoricoDataBreaches.BackColor = Color.FromArgb(51, 51, 51);
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
            this.AbrirDataBreaches_Handler(false);
        }


        private void CerrarConfirmacion_Handler(bool acepto)
        {
            if (acepto)
            {
                this.ResetearColoresBotonesDrawer();
                IniciarSesion iniciarSesion = new IniciarSesion();
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
            CrearUsuario crearUsuario = new CrearUsuario();
            crearUsuario.AbrirIniciarSesion_Event += AbrirIniciarSesion_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(crearUsuario);
        }

        private void AbrirIniciarSesion_Handler()
        {
            IniciarSesion iniciarSesion = new IniciarSesion();

            iniciarSesion.IniciarSesion_Event += IniciarSesion_Handler;
            iniciarSesion.AbrirCrearUsuario_Event += AbrirCrearUsuario_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(iniciarSesion);
        }

        protected void AbrirListaCategorias_Handler()
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            ListaCategorias listaCategorias = new ListaCategorias(this._usuarioActual);
            listaCategorias.AbrirAgregarCategorias_Event += AbrirAgregarCategorias_Handler;
            listaCategorias.AbrirModificarCategorias_Event += AbrirModificarCategorias_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaCategorias);
        }

        protected void AbrirAgregarCategorias_Handler()
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            AgregarCategoria agregarCategoria = new AgregarCategoria(this._usuarioActual);
            agregarCategoria.AbrirListaCategorias_Event += AbrirListaCategorias_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(agregarCategoria);
        }

        protected void AbrirModificarCategorias_Handler(Categoria aModificar)
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            ModificarCategoria modificarCategoria = new ModificarCategoria(aModificar, this._usuarioActual);
            modificarCategoria.AbrirListaCategorias_Event += AbrirListaCategorias_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(modificarCategoria);
        }

        protected void AbrirListaTarjetas_Handler()
        {
            this.panelPrincipal.Controls.Clear();
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
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

            Usuario usuarioAMostrar = this._controladoraAdministrador.GetUsuario(usuarioABuscar);
            Clave claveAMostrar = this._controladoraUsuario.GetClave(buscadora, usuarioAMostrar);
            VerClave verClaveSeleccionada = new VerClave(claveAMostrar, usuarioAMostrar);
            verClaveSeleccionada.SalirDeVerClave_Event += this.SalirDeVerClave_Handler;
            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(verClaveSeleccionada);
        }

        private void ModificarClaveDataBreach_Event(Clave buscadora) {
            this.AbrirModificarClave_Event(buscadora);
        }

        private void AbrirModificarClave_Event(Clave buscadora)
        {

            foreach (Control p in this.panelPrincipal.Controls)
            {
                this._panelAVolverModificarClave = p.GetType();
            }
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            Clave modificar = this._controladoraUsuario.GetClave(buscadora, this._usuarioActual);
            ModificarClave modificarClave = new ModificarClave(this._usuarioActual, modificar);
            modificarClave.CerrarModificarClave_Event += CerrarModificarClave_Event;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(modificarClave);
        }

        protected void CerrarModificarClave_Event(bool modifico) {
            switch (this._panelAVolverModificarClave.Name)
            {
                case "IngresoYListaDataBreach":
                    this.AbrirDataBreaches_Handler(true);
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
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            CrearClave crearClave = new CrearClave(this._usuarioActual);
            crearClave.AbrirListaClaves_Event += this.AbrirListaClaves_Handler;

            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(crearClave);
        }

        protected void AbrirCompartirClave_Handler(ClaveCompartida aCompartir)
        {
            CompartirClave compartirClave = new CompartirClave(aCompartir);
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
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
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
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            ListaClavesCompartidasConmigo listaClavesCompartidasConmigo = new ListaClavesCompartidasConmigo(this._usuarioActual);
            listaClavesCompartidasConmigo.AbrirVerClave_Event += this.AbrirVerClave_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaClavesCompartidasConmigo);
        }

        protected void AbrirListaClavesCompartidasPorMi_Handler()
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            ListaClavesCompartidasPorMi listaClavesCompartidasPorMi = new ListaClavesCompartidasPorMi(this._usuarioActual);
            listaClavesCompartidasPorMi.AbrirVerClave_Event += this.AbrirVerClave_Handler;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(listaClavesCompartidasPorMi);
        }

        protected void AbrirCrearTarjeta_Handler()
        {
            this.panelPrincipal.Controls.Clear();
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            CrearTarjeta crearTarjetas = new CrearTarjeta(this._usuarioActual);
            crearTarjetas.AbrirListaTarjetas_Event += this.AbrirListaTarjetas_Handler;
            this.panelPrincipal.Controls.Add(crearTarjetas);
        }

        protected void AbrirModificarTarjeta_Handler(Tarjeta buscadora)
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            Tarjeta modificar = this._controladoraUsuario.GetTarjeta(buscadora, this._usuarioActual);
            ModificarTarjeta modificarTarjeta = new ModificarTarjeta(this._usuarioActual, modificar);
            modificarTarjeta.AbrirListaTarjetas_Event += this.AbrirListaTarjetas_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(modificarTarjeta);
        }

        private void AbrirVerTarjeta_Handler(Tarjeta buscadora)
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            Tarjeta ver = this._controladoraUsuario.GetTarjeta(buscadora, this._usuarioActual);
            VerTarjeta verTarjeta = new VerTarjeta(ver, this._usuarioActual);
            verTarjeta.AbrirListaTarjetas_Event += this.AbrirListaTarjetas_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(verTarjeta);
        }

        private void AbrirDataBreaches_Handler(bool cargarUltimo) 
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            IngresoYListaDataBreach panelDataBreach = new IngresoYListaDataBreach(this._usuarioActual, cargarUltimo);
            panelDataBreach.ModificarClaveDataBreach_Event += this.ModificarClaveDataBreach_Event;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(panelDataBreach);
        }

        private void AbrirGrafica_Handler()
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            GraficaSeguridad grafica = new GraficaSeguridad(this._usuarioActual);
            grafica.AbrirReporteFortaleza_Event += AbrirReporteFortaleza_Handler;
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(grafica);
        }

        private void AbrirReporteFortaleza_Handler()
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            ReporteDeFortaleza reporteFortaleza = new ReporteDeFortaleza(this._usuarioActual);
            reporteFortaleza.AbrirGrafica_Event += AbrirGrafica_Handler;
            reporteFortaleza.AbrirVerClave_Event += AbrirVerClave_Handler;
            reporteFortaleza.AbrirModificarClave_Event += AbrirModificarClave_Event;

            this.panelPrincipal.Controls.Clear();

            this.panelPrincipal.Controls.Add(reporteFortaleza);

        }

        private void botonHistoricoDataBreaches_Click(object sender, EventArgs e)
        {
            this._usuarioActual = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            Usuario aPasar = this._controladoraAdministrador.GetUsuario(this._usuarioActual);
            UIHistoricoDataBreach historico = new UIHistoricoDataBreach(aPasar);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(historico);
        }
    }
}
