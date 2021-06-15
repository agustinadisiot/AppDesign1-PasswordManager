
namespace Interfaz.InterfacesDataBreaches
{
    partial class VentanaFiltradas
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaFiltradas));
            this.filtradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablaFiltradas = new System.Windows.Forms.DataGridView();
            this.filtradaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Filtradas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.filtradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaFiltradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtradaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // filtradaBindingSource
            // 
            this.filtradaBindingSource.DataSource = typeof(Negocio.Filtrada);
            // 
            // tablaFiltradas
            // 
            this.tablaFiltradas.AllowUserToAddRows = false;
            this.tablaFiltradas.AllowUserToDeleteRows = false;
            this.tablaFiltradas.AllowUserToResizeColumns = false;
            this.tablaFiltradas.AllowUserToResizeRows = false;
            this.tablaFiltradas.BackgroundColor = System.Drawing.Color.White;
            this.tablaFiltradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaFiltradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filtradas});
            this.tablaFiltradas.Location = new System.Drawing.Point(0, 1);
            this.tablaFiltradas.Margin = new System.Windows.Forms.Padding(4);
            this.tablaFiltradas.Name = "tablaFiltradas";
            this.tablaFiltradas.ReadOnly = true;
            this.tablaFiltradas.RowHeadersVisible = false;
            this.tablaFiltradas.RowHeadersWidth = 51;
            this.tablaFiltradas.RowTemplate.Height = 24;
            this.tablaFiltradas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaFiltradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaFiltradas.Size = new System.Drawing.Size(277, 444);
            this.tablaFiltradas.TabIndex = 40;
            // 
            // filtradaBindingSource1
            // 
            this.filtradaBindingSource1.DataSource = typeof(Negocio.Filtrada);
            // 
            // Filtradas
            // 
            this.Filtradas.HeaderText = "Filtradas";
            this.Filtradas.Name = "Filtradas";
            this.Filtradas.ReadOnly = true;
            this.Filtradas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Filtradas.Width = 280;
            // 
            // VentanaFiltradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 446);
            this.Controls.Add(this.tablaFiltradas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentanaFiltradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filtradas";
            this.Load += new System.EventHandler(this.VentanaFiltradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.filtradaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaFiltradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtradaBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource filtradaBindingSource;
        private System.Windows.Forms.DataGridView tablaFiltradas;
        private System.Windows.Forms.BindingSource filtradaBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filtradas;
    }
}