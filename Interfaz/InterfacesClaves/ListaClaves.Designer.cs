
namespace Interfaz
{
    partial class ListaClaves
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
            this.tablaClaves = new System.Windows.Forms.DataGridView();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.botonVer = new System.Windows.Forms.Button();
            this.botonCompartir = new System.Windows.Forms.Button();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaClaves
            // 
            this.tablaClaves.AllowUserToAddRows = false;
            this.tablaClaves.AllowUserToDeleteRows = false;
            this.tablaClaves.AllowUserToResizeColumns = false;
            this.tablaClaves.AllowUserToResizeRows = false;
            this.tablaClaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categoria,
            this.Sitio,
            this.Usuario,
            this.UltimaModificacion});
            this.tablaClaves.Location = new System.Drawing.Point(100, 78);
            this.tablaClaves.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClaves.Name = "tablaClaves";
            this.tablaClaves.ReadOnly = true;
            this.tablaClaves.RowHeadersVisible = false;
            this.tablaClaves.RowHeadersWidth = 51;
            this.tablaClaves.RowTemplate.Height = 24;
            this.tablaClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClaves.Size = new System.Drawing.Size(608, 369);
            this.tablaClaves.TabIndex = 0;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Categoria.Width = 125;
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio";
            this.Sitio.MinimumWidth = 6;
            this.Sitio.Name = "Sitio";
            this.Sitio.ReadOnly = true;
            this.Sitio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sitio.Width = 125;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Usuario.Width = 125;
            // 
            // UltimaModificacion
            // 
            this.UltimaModificacion.HeaderText = "Ultima Modificacion";
            this.UltimaModificacion.MinimumWidth = 6;
            this.UltimaModificacion.Name = "UltimaModificacion";
            this.UltimaModificacion.ReadOnly = true;
            this.UltimaModificacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UltimaModificacion.Width = 125;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelTitulo.Location = new System.Drawing.Point(93, 43);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(240, 25);
            this.labelTitulo.TabIndex = 17;
            this.labelTitulo.Text = "Listado de Contraseñas";
            // 
            // botonAgregar
            // 
            this.botonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonAgregar.Location = new System.Drawing.Point(519, 467);
            this.botonAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(100, 28);
            this.botonAgregar.TabIndex = 19;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // botonVer
            // 
            this.botonVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonVer.Location = new System.Drawing.Point(248, 467);
            this.botonVer.Margin = new System.Windows.Forms.Padding(4);
            this.botonVer.Name = "botonVer";
            this.botonVer.Size = new System.Drawing.Size(100, 28);
            this.botonVer.TabIndex = 20;
            this.botonVer.Text = "Ver";
            this.botonVer.UseVisualStyleBackColor = true;
            // 
            // botonCompartir
            // 
            this.botonCompartir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonCompartir.Location = new System.Drawing.Point(386, 467);
            this.botonCompartir.Margin = new System.Windows.Forms.Padding(4);
            this.botonCompartir.Name = "botonCompartir";
            this.botonCompartir.Size = new System.Drawing.Size(100, 28);
            this.botonCompartir.TabIndex = 21;
            this.botonCompartir.Text = "Compartir";
            this.botonCompartir.UseVisualStyleBackColor = true;
            this.botonCompartir.Click += new System.EventHandler(this.botonCompartir_Click);
            // 
            // botonEliminar
            // 
            this.botonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonEliminar.Location = new System.Drawing.Point(657, 467);
            this.botonEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(100, 28);
            this.botonEliminar.TabIndex = 22;
            this.botonEliminar.Text = "Eliminar";
            this.botonEliminar.UseVisualStyleBackColor = true;
            // 
            // botonModificar
            // 
            this.botonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonModificar.Location = new System.Drawing.Point(795, 467);
            this.botonModificar.Margin = new System.Windows.Forms.Padding(4);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(100, 28);
            this.botonModificar.TabIndex = 23;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            // 
            // ListaClaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.botonCompartir);
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.tablaClaves);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListaClaves";
            this.Size = new System.Drawing.Size(1071, 677);
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaClaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaModificacion;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Button botonVer;
        private System.Windows.Forms.Button botonCompartir;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonModificar;
    }
}
