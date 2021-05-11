
namespace Interfaz
{
    partial class ListaCategorias
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
            this.TablaCategorias = new System.Windows.Forms.DataGridView();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.labelListadoCategorias = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Categorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablaCategorias)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablaCategorias
            // 
            this.TablaCategorias.AllowUserToAddRows = false;
            this.TablaCategorias.AllowUserToDeleteRows = false;
            this.TablaCategorias.AllowUserToResizeColumns = false;
            this.TablaCategorias.AllowUserToResizeRows = false;
            this.TablaCategorias.BackgroundColor = System.Drawing.Color.White;
            this.TablaCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categorias});
            this.TablaCategorias.Location = new System.Drawing.Point(355, 144);
            this.TablaCategorias.Name = "TablaCategorias";
            this.TablaCategorias.ReadOnly = true;
            this.TablaCategorias.RowHeadersVisible = false;
            this.TablaCategorias.RowHeadersWidth = 22;
            this.TablaCategorias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TablaCategorias.Size = new System.Drawing.Size(204, 300);
            this.TablaCategorias.TabIndex = 0;
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(619, 410);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(123, 34);
            this.botonModificar.TabIndex = 2;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(619, 367);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(123, 34);
            this.botonAgregar.TabIndex = 3;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // labelListadoCategorias
            // 
            this.labelListadoCategorias.AutoSize = true;
            this.labelListadoCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelListadoCategorias.ForeColor = System.Drawing.Color.White;
            this.labelListadoCategorias.Location = new System.Drawing.Point(349, 32);
            this.labelListadoCategorias.Name = "labelListadoCategorias";
            this.labelListadoCategorias.Size = new System.Drawing.Size(304, 36);
            this.labelListadoCategorias.TabIndex = 4;
            this.labelListadoCategorias.Text = "Listado de Categorias";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelListadoCategorias);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 100);
            this.panel1.TabIndex = 5;
            // 
            // Categorias
            // 
            this.Categorias.HeaderText = "Categorias";
            this.Categorias.MinimumWidth = 6;
            this.Categorias.Name = "Categorias";
            this.Categorias.ReadOnly = true;
            this.Categorias.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Categorias.Width = 200;
            // 
            // ListaCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.TablaCategorias);
            this.Name = "ListaCategorias";
            this.Size = new System.Drawing.Size(1002, 681);
            this.Load += new System.EventHandler(this.ListaCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaCategorias)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaCategorias;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Label labelListadoCategorias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categorias;
    }
}
