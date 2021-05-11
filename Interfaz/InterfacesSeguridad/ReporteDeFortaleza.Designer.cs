
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.botonGrafica = new System.Windows.Forms.Button();
            this.TablaReporte = new System.Windows.Forms.DataGridView();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadClaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonModificar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.tablaClaves = new System.Windows.Forms.DataGridView();
            this.botonVer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonGrafica
            // 
            this.botonGrafica.Location = new System.Drawing.Point(22, 567);
            this.botonGrafica.Name = "botonGrafica";
            this.botonGrafica.Size = new System.Drawing.Size(143, 38);
            this.botonGrafica.TabIndex = 5;
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
            this.TablaReporte.BackgroundColor = System.Drawing.Color.White;
            this.TablaReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Color,
            this.CantidadClaves});
            this.TablaReporte.Location = new System.Drawing.Point(22, 123);
            this.TablaReporte.MultiSelect = false;
            this.TablaReporte.Name = "TablaReporte";
            this.TablaReporte.ReadOnly = true;
            this.TablaReporte.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaReporte.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TablaReporte.RowHeadersVisible = false;
            this.TablaReporte.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.TablaReporte.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TablaReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaReporte.Size = new System.Drawing.Size(228, 146);
            this.TablaReporte.TabIndex = 1;
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
            this.botonModificar.Location = new System.Drawing.Point(615, 567);
            this.botonModificar.Margin = new System.Windows.Forms.Padding(4);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(143, 38);
            this.botonModificar.TabIndex = 4;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(353, 32);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(297, 36);
            this.labelTitulo.TabIndex = 25;
            this.labelTitulo.Text = "Reporte De Fortaleza";
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
            this.UltimaModificacion});
            this.tablaClaves.Location = new System.Drawing.Point(286, 123);
            this.tablaClaves.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClaves.Name = "tablaClaves";
            this.tablaClaves.ReadOnly = true;
            this.tablaClaves.RowHeadersVisible = false;
            this.tablaClaves.RowHeadersWidth = 51;
            this.tablaClaves.RowTemplate.Height = 24;
            this.tablaClaves.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClaves.Size = new System.Drawing.Size(623, 424);
            this.tablaClaves.TabIndex = 2;
            // 
            // botonVer
            // 
            this.botonVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonVer.Location = new System.Drawing.Point(766, 567);
            this.botonVer.Margin = new System.Windows.Forms.Padding(4);
            this.botonVer.Name = "botonVer";
            this.botonVer.Size = new System.Drawing.Size(143, 38);
            this.botonVer.TabIndex = 3;
            this.botonVer.Text = "Ver";
            this.botonVer.UseVisualStyleBackColor = true;
            this.botonVer.Click += new System.EventHandler(this.botonVer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 100);
            this.panel1.TabIndex = 26;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Categoria.Width = 155;
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio";
            this.Sitio.MinimumWidth = 6;
            this.Sitio.Name = "Sitio";
            this.Sitio.ReadOnly = true;
            this.Sitio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sitio.Width = 155;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Usuario.Width = 155;
            // 
            // UltimaModificacion
            // 
            this.UltimaModificacion.HeaderText = "Ultima Modificacion";
            this.UltimaModificacion.MinimumWidth = 6;
            this.UltimaModificacion.Name = "UltimaModificacion";
            this.UltimaModificacion.ReadOnly = true;
            this.UltimaModificacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UltimaModificacion.Width = 155;
            // 
            // ReporteDeFortaleza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.tablaClaves);
            this.Controls.Add(this.botonGrafica);
            this.Controls.Add(this.TablaReporte);
            this.Name = "ReporteDeFortaleza";
            this.Size = new System.Drawing.Size(1002, 681);
            this.Load += new System.EventHandler(this.ReporteDeFortaleza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button botonGrafica;
        private System.Windows.Forms.DataGridView TablaReporte;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView tablaClaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadClaves;
        private System.Windows.Forms.Button botonVer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaModificacion;
    }
}
