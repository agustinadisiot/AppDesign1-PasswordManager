
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
            this.labelListadoCategorias = new System.Windows.Forms.Label();
            this.botonVer = new System.Windows.Forms.Button();
            this.botonGrafica = new System.Windows.Forms.Button();
            this.TablaReporte = new System.Windows.Forms.DataGridView();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadClaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // labelListadoCategorias
            // 
            this.labelListadoCategorias.AutoSize = true;
            this.labelListadoCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListadoCategorias.Location = new System.Drawing.Point(79, 34);
            this.labelListadoCategorias.Name = "labelListadoCategorias";
            this.labelListadoCategorias.Size = new System.Drawing.Size(222, 25);
            this.labelListadoCategorias.TabIndex = 8;
            this.labelListadoCategorias.Text = "Listado de Categorias";
            // 
            // botonVer
            // 
            this.botonVer.Location = new System.Drawing.Point(372, 368);
            this.botonVer.Name = "botonVer";
            this.botonVer.Size = new System.Drawing.Size(75, 23);
            this.botonVer.TabIndex = 7;
            this.botonVer.Text = "Ver";
            this.botonVer.UseVisualStyleBackColor = true;
            // 
            // botonGrafica
            // 
            this.botonGrafica.Location = new System.Drawing.Point(84, 368);
            this.botonGrafica.Name = "botonGrafica";
            this.botonGrafica.Size = new System.Drawing.Size(75, 23);
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
            this.Grupo,
            this.cantidadClaves});
            this.TablaReporte.Location = new System.Drawing.Point(84, 62);
            this.TablaReporte.MultiSelect = false;
            this.TablaReporte.Name = "TablaReporte";
            this.TablaReporte.ReadOnly = true;
            this.TablaReporte.RowHeadersVisible = false;
            this.TablaReporte.RowHeadersWidth = 22;
            this.TablaReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaReporte.Size = new System.Drawing.Size(363, 300);
            this.TablaReporte.TabIndex = 5;
            // 
            // Grupo
            // 
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.MinimumWidth = 6;
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            this.Grupo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Grupo.Width = 125;
            // 
            // cantidadClaves
            // 
            this.cantidadClaves.HeaderText = "Cantidad de Contraseñas";
            this.cantidadClaves.Name = "cantidadClaves";
            this.cantidadClaves.ReadOnly = true;
            // 
            // ReporteDeFortaleza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelListadoCategorias);
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.botonGrafica);
            this.Controls.Add(this.TablaReporte);
            this.Name = "ReporteDeFortaleza";
            this.Size = new System.Drawing.Size(884, 603);
            this.Load += new System.EventHandler(this.ReporteDeFortaleza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TablaReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelListadoCategorias;
        private System.Windows.Forms.Button botonVer;
        private System.Windows.Forms.Button botonGrafica;
        private System.Windows.Forms.DataGridView TablaReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadClaves;
    }
}
