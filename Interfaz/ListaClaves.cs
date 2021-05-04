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
    public partial class ListaClaves : UserControl
    {
        private Usuario _usuarioActual;
        private AdminContras _administrador;

        public ListaClaves(Usuario usuarioAgregar, AdminContras administradorAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
            this._administrador = administradorAgregar;
            CargarTabla();
        }

        private void CargarTabla()
        {

            List<Categoria> listaCategorias = this._usuarioActual.GetListaCategorias();

            foreach (Categoria categoriaActual in listaCategorias)
            {

                string nombreCategoria = categoriaActual.Nombre;
                List<Contra> listaContras = categoriaActual.GetListaContras();
                CargarFila(nombreCategoria, listaContras);
            }
        }


        private void CargarFila(string categoriaActual, List<Contra> listaContras)
        {

            foreach (Contra contraActual in listaContras)
            {

                string sitio = contraActual.Sitio;
                string usuario = contraActual.UsuarioContra;
                string ultimaModificacion = "";

                this.tablaClaves.Rows.Add(categoriaActual, sitio, usuario, ultimaModificacion);
            }
        }
    }
}
