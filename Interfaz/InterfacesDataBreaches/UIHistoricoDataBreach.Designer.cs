
namespace Interfaz.InterfacesDataBreaches
{
    partial class UIHistoricoDataBreach
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelErrores = new System.Windows.Forms.Label();
            this.labelDatos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.botonModificarClave = new System.Windows.Forms.Button();
            this.botonVerificar = new System.Windows.Forms.Button();
            this.Vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarjetaCompleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarjetaMostrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catregoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablaTarjetas = new System.Windows.Forms.DataGridView();
            this.botonCargar = new System.Windows.Forms.Button();
            this.tablaClaves = new System.Windows.Forms.DataGridView();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FueModificado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tablaDataBreaches = new System.Windows.Forms.DataGridView();
            this.claveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBreachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Fecha = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTarjetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDataBreaches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBreachBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(150, 663);
            this.labelErrores.MaximumSize = new System.Drawing.Size(222, 90);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(64, 13);
            this.labelErrores.TabIndex = 38;
            this.labelErrores.Text = "MostrarError";
            // 
            // labelDatos
            // 
            this.labelDatos.AutoSize = true;
            this.labelDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelDatos.Location = new System.Drawing.Point(22, 112);
            this.labelDatos.Name = "labelDatos";
            this.labelDatos.Size = new System.Drawing.Size(161, 25);
            this.labelDatos.TabIndex = 36;
            this.labelDatos.Text = "Elija Data Breach";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Controls.Add(this.botonModificarClave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 100);
            this.panel1.TabIndex = 35;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(318, 31);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(375, 36);
            this.labelTitulo.TabIndex = 25;
            this.labelTitulo.Text = "Histórico de Data Breaches";
            // 
            // botonModificarClave
            // 
            this.botonModificarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonModificarClave.Location = new System.Drawing.Point(857, 48);
            this.botonModificarClave.Margin = new System.Windows.Forms.Padding(4);
            this.botonModificarClave.Name = "botonModificarClave";
            this.botonModificarClave.Size = new System.Drawing.Size(115, 28);
            this.botonModificarClave.TabIndex = 33;
            this.botonModificarClave.Text = "Modificar Contraseña";
            this.botonModificarClave.UseVisualStyleBackColor = true;
            // 
            // botonVerificar
            // 
            this.botonVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonVerificar.Location = new System.Drawing.Point(145, 612);
            this.botonVerificar.Margin = new System.Windows.Forms.Padding(2);
            this.botonVerificar.Name = "botonVerificar";
            this.botonVerificar.Size = new System.Drawing.Size(125, 37);
            this.botonVerificar.TabIndex = 31;
            this.botonVerificar.Text = "Verificar";
            this.botonVerificar.UseVisualStyleBackColor = true;
            // 
            // Vencimiento
            // 
            this.Vencimiento.HeaderText = "Vencimiento";
            this.Vencimiento.MinimumWidth = 6;
            this.Vencimiento.Name = "Vencimiento";
            this.Vencimiento.ReadOnly = true;
            this.Vencimiento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Vencimiento.Width = 133;
            // 
            // TarjetaCompleta
            // 
            this.TarjetaCompleta.HeaderText = "TarjetaCompleta";
            this.TarjetaCompleta.MinimumWidth = 6;
            this.TarjetaCompleta.Name = "TarjetaCompleta";
            this.TarjetaCompleta.ReadOnly = true;
            this.TarjetaCompleta.Visible = false;
            this.TarjetaCompleta.Width = 125;
            // 
            // TarjetaMostrada
            // 
            this.TarjetaMostrada.HeaderText = "Tarjeta";
            this.TarjetaMostrada.MinimumWidth = 6;
            this.TarjetaMostrada.Name = "TarjetaMostrada";
            this.TarjetaMostrada.ReadOnly = true;
            this.TarjetaMostrada.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TarjetaMostrada.Width = 160;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tipo.Width = 133;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nombre.Width = 133;
            // 
            // Catregoria
            // 
            this.Catregoria.HeaderText = "Categoría";
            this.Catregoria.MinimumWidth = 6;
            this.Catregoria.Name = "Catregoria";
            this.Catregoria.ReadOnly = true;
            this.Catregoria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Catregoria.Width = 133;
            // 
            // tablaTarjetas
            // 
            this.tablaTarjetas.AllowUserToAddRows = false;
            this.tablaTarjetas.AllowUserToDeleteRows = false;
            this.tablaTarjetas.AllowUserToResizeRows = false;
            this.tablaTarjetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaTarjetas.BackgroundColor = System.Drawing.Color.White;
            this.tablaTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaTarjetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Catregoria,
            this.Nombre,
            this.Tipo,
            this.TarjetaMostrada,
            this.TarjetaCompleta,
            this.Vencimiento});
            this.tablaTarjetas.Location = new System.Drawing.Point(291, 361);
            this.tablaTarjetas.Margin = new System.Windows.Forms.Padding(2);
            this.tablaTarjetas.MultiSelect = false;
            this.tablaTarjetas.Name = "tablaTarjetas";
            this.tablaTarjetas.ReadOnly = true;
            this.tablaTarjetas.RowHeadersVisible = false;
            this.tablaTarjetas.RowHeadersWidth = 51;
            this.tablaTarjetas.RowTemplate.Height = 24;
            this.tablaTarjetas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaTarjetas.Size = new System.Drawing.Size(652, 288);
            this.tablaTarjetas.TabIndex = 34;
            // 
            // botonCargar
            // 
            this.botonCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCargar.Location = new System.Drawing.Point(15, 612);
            this.botonCargar.Margin = new System.Windows.Forms.Padding(2);
            this.botonCargar.Name = "botonCargar";
            this.botonCargar.Size = new System.Drawing.Size(119, 37);
            this.botonCargar.TabIndex = 37;
            this.botonCargar.Text = "Cargar";
            this.botonCargar.UseVisualStyleBackColor = true;
            // 
            // tablaClaves
            // 
            this.tablaClaves.AllowUserToAddRows = false;
            this.tablaClaves.AllowUserToDeleteRows = false;
            this.tablaClaves.AllowUserToResizeColumns = false;
            this.tablaClaves.AllowUserToResizeRows = false;
            this.tablaClaves.BackgroundColor = System.Drawing.Color.White;
            this.tablaClaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categoria,
            this.Sitio,
            this.Usuario,
            this.FueModificado,
            this.Modificar});
            this.tablaClaves.Location = new System.Drawing.Point(291, 112);
            this.tablaClaves.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClaves.Name = "tablaClaves";
            this.tablaClaves.ReadOnly = true;
            this.tablaClaves.RowHeadersVisible = false;
            this.tablaClaves.RowHeadersWidth = 51;
            this.tablaClaves.RowTemplate.Height = 24;
            this.tablaClaves.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClaves.Size = new System.Drawing.Size(652, 233);
            this.tablaClaves.TabIndex = 32;
            this.tablaClaves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaClaves_CellContentClick);
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Categoria.Width = 133;
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio";
            this.Sitio.MinimumWidth = 6;
            this.Sitio.Name = "Sitio";
            this.Sitio.ReadOnly = true;
            this.Sitio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sitio.Width = 133;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Usuario.Width = 133;
            // 
            // FueModificado
            // 
            this.FueModificado.HeaderText = "Fue Modificado";
            this.FueModificado.MinimumWidth = 6;
            this.FueModificado.Name = "FueModificado";
            this.FueModificado.ReadOnly = true;
            this.FueModificado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FueModificado.Width = 133;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Width = 150;
            // 
            // tablaDataBreaches
            // 
            this.tablaDataBreaches.AllowUserToAddRows = false;
            this.tablaDataBreaches.AllowUserToDeleteRows = false;
            this.tablaDataBreaches.AllowUserToResizeColumns = false;
            this.tablaDataBreaches.AllowUserToResizeRows = false;
            this.tablaDataBreaches.BackgroundColor = System.Drawing.Color.White;
            this.tablaDataBreaches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDataBreaches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha});
            this.tablaDataBreaches.Location = new System.Drawing.Point(15, 160);
            this.tablaDataBreaches.Margin = new System.Windows.Forms.Padding(4);
            this.tablaDataBreaches.Name = "tablaDataBreaches";
            this.tablaDataBreaches.ReadOnly = true;
            this.tablaDataBreaches.RowHeadersVisible = false;
            this.tablaDataBreaches.RowHeadersWidth = 51;
            this.tablaDataBreaches.RowTemplate.Height = 24;
            this.tablaDataBreaches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaDataBreaches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaDataBreaches.Size = new System.Drawing.Size(248, 446);
            this.tablaDataBreaches.TabIndex = 39;
            this.tablaDataBreaches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDataBreaches_CellContentClick);
            // 
            // claveBindingSource
            // 
            this.claveBindingSource.DataSource = typeof(Negocio.Clave);
            // 
            // dataBreachBindingSource
            // 
            this.dataBreachBindingSource.DataSource = typeof(Negocio.DataBreach);
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Fecha.Width = 250;
            // 
            // UIHistoricoDataBreach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablaDataBreaches);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.labelDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonVerificar);
            this.Controls.Add(this.tablaTarjetas);
            this.Controls.Add(this.botonCargar);
            this.Controls.Add(this.tablaClaves);
            this.Name = "UIHistoricoDataBreach";
            this.Size = new System.Drawing.Size(1002, 681);
            this.Load += new System.EventHandler(this.UIHistoricoDataBreach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTarjetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDataBreaches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBreachBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.Label labelDatos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button botonVerificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarjetaCompleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarjetaMostrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catregoria;
        private System.Windows.Forms.DataGridView tablaTarjetas;
        private System.Windows.Forms.Button botonModificarClave;
        private System.Windows.Forms.Button botonCargar;
        private System.Windows.Forms.DataGridView tablaClaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn FueModificado;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridView tablaDataBreaches;
        private System.Windows.Forms.BindingSource claveBindingSource;
        private System.Windows.Forms.BindingSource dataBreachBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn Fecha;
    }
}
