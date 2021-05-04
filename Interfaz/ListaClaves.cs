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

        public ListaClaves(Usuario usuarioAgregar)
        {
            InitializeComponent();
            this._usuarioActual = usuarioAgregar;
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
