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

namespace Interfaz.InterfacesClaves
{
    public partial class ModificarClave : UserControl
    {
        private Usuario _actual;
        private Contra _vieja;

        public ModificarClave(Usuario usuario, Contra contra)
        {
            this._actual = usuario;
            this._vieja = contra;
            InitializeComponent();
        }

        private void ModificarClave_Load(object sender, EventArgs e)
        {
            this.CargarComboBox();
            this.CargarInputsConClave();
        }

        private void CargarInputsConClave() {
            this.inputContra.Text = this._vieja.Clave;
            this.inputNota.Text = this._vieja.Nota;
            this.inputSitio.Text = this._vieja.Sitio;
            this.inputUsuario.Text = this._vieja.UsuarioContra;
        }

        private void CargarComboBox()
        {
            this.comboBoxCategorias.Items.Clear();
            List<Categoria> lista = this._actual.GetListaCategorias();

            foreach (Categoria actual in lista)
            {
                string nombre = actual.Nombre;
                this.comboBoxCategorias.Items.Add(nombre);

            }

            Categoria pertence = this._actual.GetCategoriaClave(this._vieja);

            this.comboBoxCategorias.SelectedItem = pertence.Nombre;


        }

        private string LeerComboBox()
        {
            string nombre = (string)this.comboBoxCategorias.SelectedItem;

            return nombre;
        }

        public delegate void AbrirListaClaves_Handler();
        public event AbrirListaClaves_Handler AbrirListaClaves_Event;
        private void AbrirListaClaves()
        {
            if (this.AbrirListaClaves_Event != null)
                this.AbrirListaClaves_Event();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.AbrirListaClaves();
        }
    }
}
