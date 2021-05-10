
namespace Interfaz.InterfacesSeguridad
{
    partial class ReporteDeFortaleza
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
            this.botonGrafica = new System.Windows.Forms.Button();
            this.TablaReporte = new System.Windows.Forms.DataGridView();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadClaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonModificar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.tablaClaves = new System.Windows.Forms.DataGridView();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).BeginInit();
            this.SuspendLayout();
            // 
            // botonGrafica
            // 
            this.botonGrafica.Location = new System.Drawing.Point(47, 431);
            this.botonGrafica.Name = "botonGrafica";
            this.botonGrafica.Size = new System.Drawing.Size(123, 50);
            this.botonGrafica.TabIndex = 6;
            this.botonGrafica.Text = "Grafica";
            this.botonGrafica.UseVisualStyleBackColor = true;
            this.botonGrafica.Click += new System.EventHandler(this.botonGrafica_Click);
            // 
            // TablaReporte
            // 
            this.TablaReporte.AllowUserToAddRows = false;
            this.TablaReporte.AllowUserToDeleteRows = false;
            this.TablaReporte.AllowUserToResizeColumns = false;
            this.TablaReporte.AllowUserToResizeRows = false;
            this.TablaReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Color,
            this.CantidadClaves});
            this.TablaReporte.Location = new System.Drawing.Point(47, 112);
            this.TablaReporte.MultiSelect = false;
            this.TablaReporte.Name = "TablaReporte";
            this.TablaReporte.ReadOnly = true;
            this.TablaReporte.RowHeadersVisible = false;
            this.TablaReporte.RowHeadersWidth = 22;
            this.TablaReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaReporte.Size = new System.Drawing.Size(228, 190);
            this.TablaReporte.TabIndex = 5;
            // 
            // Color
            // 
            this.Color.HeaderText = "Grupo";
            this.Color.MinimumWidth = 6;
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Color.Width = 125;
            // 
            // CantidadClaves
            // 
            this.CantidadClaves.HeaderText = "Cantidad de Contraseñas";
            this.CantidadClaves.Name = "CantidadClaves";
            this.CantidadClaves.ReadOnly = true;
            this.CantidadClaves.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // botonModificar
            // 
            this.botonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonModificar.Location = new System.Drawing.Point(747, 489);
            this.botonModificar.Margin = new System.Windows.Forms.Padding(4);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(100, 26);
            this.botonModificar.TabIndex = 26;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelTitulo.Location = new System.Drawing.Point(39, 34);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(217, 25);
            this.labelTitulo.TabIndex = 25;
            this.labelTitulo.Text = "Reporte De Fortaleza";
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
            this.tablaClaves.Location = new System.Drawing.Point(344, 112);
            this.tablaClaves.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClaves.Name = "tablaClaves";
            this.tablaClaves.ReadOnly = true;
            this.tablaClaves.RowHeadersVisible = false;
            this.tablaClaves.RowHeadersWidth = 51;
            this.tablaClaves.RowTemplate.Height = 24;
            this.tablaClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClaves.Size = new System.Drawing.Size(503, 369);
            this.tablaClaves.TabIndex = 24;
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
            // botonVer
            // 
            this.botonVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonVer.Location = new System.Drawing.Point(639, 489);
            this.botonVer.Margin = new System.Windows.Forms.Padding(4);
            this.botonVer.Name = "botonVer";
            this.botonVer.Size = new System.Drawing.Size(100, 28);
            this.botonVer.TabIndex = 27;
            this.botonVer.Text = "Ver";
            this.botonVer.UseVisualStyleBackColor = true;
            this.botonVer.Click += new System.EventHandler(this.botonVer_Click);
            // 
            // ReporteDeFortaleza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.tablaClaves);
            this.Controls.Add(this.botonGrafica);
            this.Controls.Add(this.TablaReporte);
            this.Name = "ReporteDeFortaleza";
            this.Size = new System.Drawing.Size(884, 603);
            this.Load += new System.EventHandler(this.ReporteDeFortaleza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button botonGrafica;
        private System.Windows.Forms.DataGridView TablaReporte;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView tablaClaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadClaves;
        private System.Windows.Forms.Button botonVer;
    }
}
