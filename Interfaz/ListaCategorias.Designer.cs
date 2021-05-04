
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
            this.Catergorias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.labelListadoCategorias = new System.Windows.Forms.Label();
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
            this.Catergorias});
            this.TablaCategorias.Location = new System.Drawing.Point(75, 63);
            this.TablaCategorias.Name = "TablaCategorias";
            this.TablaCategorias.ReadOnly = true;
            this.TablaCategorias.RowHeadersVisible = false;
            this.TablaCategorias.RowHeadersWidth = 22;
            this.TablaCategorias.Size = new System.Drawing.Size(363, 300);
            this.TablaCategorias.TabIndex = 0;
            this.TablaCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Catergorias
            // 
            this.Catergorias.HeaderText = "Categorias";
            this.Catergorias.Name = "Catergorias";
            this.Catergorias.ReadOnly = true;
            this.Catergorias.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Catergorias.Width = 125;
            // 
            // botonEliminar
            // 
            this.botonEliminar.Location = new System.Drawing.Point(282, 369);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(75, 23);
            this.botonEliminar.TabIndex = 1;
            this.botonEliminar.Text = "Eliminar";
            this.botonEliminar.UseVisualStyleBackColor = true;
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(363, 369);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(75, 23);
            this.botonModificar.TabIndex = 2;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(201, 369);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(75, 23);
            this.botonAgregar.TabIndex = 3;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            // 
            // labelListadoCategorias
            // 
            this.labelListadoCategorias.AutoSize = true;
            this.labelListadoCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListadoCategorias.Location = new System.Drawing.Point(70, 35);
            this.labelListadoCategorias.Name = "labelListadoCategorias";
            this.labelListadoCategorias.Size = new System.Drawing.Size(222, 25);
            this.labelListadoCategorias.TabIndex = 4;
            this.labelListadoCategorias.Text = "Listado de Categorias";
            // 
            // ListaCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelListadoCategorias);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.TablaCategorias);
            this.Name = "ListaCategorias";
            this.Size = new System.Drawing.Size(1071, 677);
            this.Load += new System.EventHandler(this.ListaCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TablaCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catergorias;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Label labelListadoCategorias;
    }
}
