
namespace Interfaz
{
    partial class ListaTarjetas
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
            this.tablaTarjetas = new System.Windows.Forms.DataGridView();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.buttonVer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Catregoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarjetaMostrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarjetaCompleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaTarjetas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tablaTarjetas.Location = new System.Drawing.Point(3, 129);
            this.tablaTarjetas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablaTarjetas.MultiSelect = false;
            this.tablaTarjetas.Name = "tablaTarjetas";
            this.tablaTarjetas.ReadOnly = true;
            this.tablaTarjetas.RowHeadersVisible = false;
            this.tablaTarjetas.RowHeadersWidth = 51;
            this.tablaTarjetas.RowTemplate.Height = 24;
            this.tablaTarjetas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaTarjetas.Size = new System.Drawing.Size(1329, 614);
            this.tablaTarjetas.TabIndex = 0;
            // 
            // botonEliminar
            // 
            this.botonEliminar.Location = new System.Drawing.Point(1188, 762);
            this.botonEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(144, 37);
            this.botonEliminar.TabIndex = 3;
            this.botonEliminar.Text = "Eliminar";
            this.botonEliminar.UseVisualStyleBackColor = true;
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(1036, 762);
            this.botonModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(144, 37);
            this.botonModificar.TabIndex = 4;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(884, 762);
            this.buttonAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(144, 37);
            this.buttonAgregar.TabIndex = 2;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(540, 39);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(242, 42);
            this.labelTitulo.TabIndex = 4;
            this.labelTitulo.Text = "Lista Tarjetas";
            // 
            // buttonVer
            // 
            this.buttonVer.Location = new System.Drawing.Point(732, 762);
            this.buttonVer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonVer.Name = "buttonVer";
            this.buttonVer.Size = new System.Drawing.Size(144, 37);
            this.buttonVer.TabIndex = 1;
            this.buttonVer.Text = "Ver";
            this.buttonVer.UseVisualStyleBackColor = true;
            this.buttonVer.Click += new System.EventHandler(this.buttonVer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 123);
            this.panel1.TabIndex = 5;
            // 
            // Catregoria
            // 
            this.Catregoria.HeaderText = "Categoría";
            this.Catregoria.MinimumWidth = 6;
            this.Catregoria.Name = "Catregoria";
            this.Catregoria.ReadOnly = true;
            this.Catregoria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Catregoria.Width = 200;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nombre.Width = 200;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tipo.Width = 200;
            // 
            // TarjetaMostrada
            // 
            this.TarjetaMostrada.HeaderText = "Tarjeta";
            this.TarjetaMostrada.MinimumWidth = 6;
            this.TarjetaMostrada.Name = "TarjetaMostrada";
            this.TarjetaMostrada.ReadOnly = true;
            this.TarjetaMostrada.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TarjetaMostrada.Width = 200;
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
            // Vencimiento
            // 
            this.Vencimiento.HeaderText = "Vencimiento";
            this.Vencimiento.MinimumWidth = 6;
            this.Vencimiento.Name = "Vencimiento";
            this.Vencimiento.ReadOnly = true;
            this.Vencimiento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Vencimiento.Width = 200;
            // 
            // ListaTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonVer);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.tablaTarjetas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListaTarjetas";
            this.Size = new System.Drawing.Size(1336, 838);
            ((System.ComponentModel.ISupportInitialize)(this.tablaTarjetas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaTarjetas;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonVer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catregoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarjetaMostrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarjetaCompleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimiento;
    }
}
