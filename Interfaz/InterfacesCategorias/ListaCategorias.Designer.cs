
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
            this.Categorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablaCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // TablaCategorias
            // 
            this.TablaCategorias.AllowUserToAddRows = false;
            this.TablaCategorias.AllowUserToDeleteRows = false;
            this.TablaCategorias.AllowUserToResizeColumns = false;
            this.TablaCategorias.AllowUserToResizeRows = false;
            this.TablaCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categorias});
            this.TablaCategorias.Location = new System.Drawing.Point(100, 78);
            this.TablaCategorias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TablaCategorias.Name = "TablaCategorias";
            this.TablaCategorias.ReadOnly = true;
            this.TablaCategorias.RowHeadersVisible = false;
            this.TablaCategorias.RowHeadersWidth = 22;
            this.TablaCategorias.Size = new System.Drawing.Size(484, 369);
            this.TablaCategorias.TabIndex = 0;
            this.TablaCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(484, 454);
            this.botonModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(100, 28);
            this.botonModificar.TabIndex = 2;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(376, 454);
            this.botonAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(100, 28);
            this.botonAgregar.TabIndex = 3;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // labelListadoCategorias
            // 
            this.labelListadoCategorias.AutoSize = true;
            this.labelListadoCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListadoCategorias.Location = new System.Drawing.Point(93, 43);
            this.labelListadoCategorias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelListadoCategorias.Name = "labelListadoCategorias";
            this.labelListadoCategorias.Size = new System.Drawing.Size(278, 31);
            this.labelListadoCategorias.TabIndex = 4;
            this.labelListadoCategorias.Text = "Listado de Categorias";
            // 
            // Categorias
            // 
            this.Categorias.HeaderText = "Categorias";
            this.Categorias.MinimumWidth = 6;
            this.Categorias.Name = "Categorias";
            this.Categorias.ReadOnly = true;
            this.Categorias.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Categorias.Width = 125;
            // 
            // ListaCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelListadoCategorias);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.TablaCategorias);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListaCategorias";
            this.Size = new System.Drawing.Size(1428, 833);
            this.Load += new System.EventHandler(this.ListaCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaCategorias;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Label labelListadoCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categorias;
    }
}
