﻿
namespace Interfaz.InterfacesClaves
{
    partial class IngresoYListaDataBreach
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
            this.botonModificarClave = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.tablaTarjetas = new System.Windows.Forms.DataGridView();
            this.botonVerificar = new System.Windows.Forms.Button();
            this.inputDatos = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Catregoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarjetaMostrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarjetaCompleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDatos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTarjetas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tablaClaves.Location = new System.Drawing.Point(324, 107);
            this.tablaClaves.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClaves.Name = "tablaClaves";
            this.tablaClaves.ReadOnly = true;
            this.tablaClaves.RowHeadersVisible = false;
            this.tablaClaves.RowHeadersWidth = 51;
            this.tablaClaves.RowTemplate.Height = 24;
            this.tablaClaves.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClaves.Size = new System.Drawing.Size(529, 233);
            this.tablaClaves.TabIndex = 3;
            // 
            // botonModificarClave
            // 
            this.botonModificarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.botonModificarClave.Location = new System.Drawing.Point(861, 312);
            this.botonModificarClave.Margin = new System.Windows.Forms.Padding(4);
            this.botonModificarClave.Name = "botonModificarClave";
            this.botonModificarClave.Size = new System.Drawing.Size(115, 28);
            this.botonModificarClave.TabIndex = 4;
            this.botonModificarClave.Text = "Modificar Contraseña";
            this.botonModificarClave.UseVisualStyleBackColor = true;
            this.botonModificarClave.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(339, 32);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(324, 36);
            this.labelTitulo.TabIndex = 25;
            this.labelTitulo.Text = "Listado de Data Breach";
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
            this.tablaTarjetas.Location = new System.Drawing.Point(324, 356);
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
            this.tablaTarjetas.TabIndex = 5;
            // 
            // botonVerificar
            // 
            this.botonVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonVerificar.Location = new System.Drawing.Point(149, 607);
            this.botonVerificar.Margin = new System.Windows.Forms.Padding(2);
            this.botonVerificar.Name = "botonVerificar";
            this.botonVerificar.Size = new System.Drawing.Size(144, 37);
            this.botonVerificar.TabIndex = 2;
            this.botonVerificar.Text = "Verificar";
            this.botonVerificar.UseVisualStyleBackColor = true;
            this.botonVerificar.Click += new System.EventHandler(this.botonVerificar_Click);
            // 
            // inputDatos
            // 
            this.inputDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputDatos.Location = new System.Drawing.Point(27, 144);
            this.inputDatos.Multiline = true;
            this.inputDatos.Name = "inputDatos";
            this.inputDatos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputDatos.Size = new System.Drawing.Size(266, 437);
            this.inputDatos.TabIndex = 1;
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
            // Catregoria
            // 
            this.Catregoria.HeaderText = "Categoria";
            this.Catregoria.MinimumWidth = 6;
            this.Catregoria.Name = "Catregoria";
            this.Catregoria.ReadOnly = true;
            this.Catregoria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Catregoria.Width = 133;
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
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tipo.Width = 133;
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
            // TarjetaCompleta
            // 
            this.TarjetaCompleta.HeaderText = "TarjetaCompleta";
            this.TarjetaCompleta.Name = "TarjetaCompleta";
            this.TarjetaCompleta.ReadOnly = true;
            this.TarjetaCompleta.Visible = false;
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
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
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
            // UltimaModificacion
            // 
            this.UltimaModificacion.HeaderText = "Ultima Modificacion";
            this.UltimaModificacion.MinimumWidth = 6;
            this.UltimaModificacion.Name = "UltimaModificacion";
            this.UltimaModificacion.ReadOnly = true;
            this.UltimaModificacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UltimaModificacion.Width = 133;
            // 
            // labelDatos
            // 
            this.labelDatos.AutoSize = true;
            this.labelDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelDatos.Location = new System.Drawing.Point(22, 107);
            this.labelDatos.Name = "labelDatos";
            this.labelDatos.Size = new System.Drawing.Size(248, 25);
            this.labelDatos.TabIndex = 27;
            this.labelDatos.Text = "Ingrese los datos a verificar";
            // 
            // IngresoYListaDataBreach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonVerificar);
            this.Controls.Add(this.inputDatos);
            this.Controls.Add(this.tablaTarjetas);
            this.Controls.Add(this.tablaClaves);
            this.Controls.Add(this.botonModificarClave);
            this.Name = "IngresoYListaDataBreach";
            this.Size = new System.Drawing.Size(1002, 681);
            this.Load += new System.EventHandler(this.IngresoYListaDataBreach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaClaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTarjetas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaClaves;
        private System.Windows.Forms.Button botonModificarClave;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView tablaTarjetas;
        private System.Windows.Forms.Button botonVerificar;
        private System.Windows.Forms.TextBox inputDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catregoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarjetaMostrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarjetaCompleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimiento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDatos;
    }
}
