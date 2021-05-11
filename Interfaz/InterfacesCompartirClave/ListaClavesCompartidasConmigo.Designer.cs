
namespace Interfaz
{
    partial class ListaClavesCompartidasConmigo
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
            this.tablaClavesCompartidas = new System.Windows.Forms.DataGridView();
            this.CompartidaPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesCompartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaClavesCompartidas
            // 
            this.tablaClavesCompartidas.AllowUserToAddRows = false;
            this.tablaClavesCompartidas.AllowUserToDeleteRows = false;
            this.tablaClavesCompartidas.AllowUserToResizeColumns = false;
            this.tablaClavesCompartidas.AllowUserToResizeRows = false;
            this.tablaClavesCompartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClavesCompartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompartidaPor,
            this.Sitio,
            this.Usuario});
            this.tablaClavesCompartidas.Location = new System.Drawing.Point(68, 23);
            this.tablaClavesCompartidas.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClavesCompartidas.MultiSelect = false;
            this.tablaClavesCompartidas.Name = "tablaClavesCompartidas";
            this.tablaClavesCompartidas.ReadOnly = true;
            this.tablaClavesCompartidas.RowHeadersVisible = false;
            this.tablaClavesCompartidas.RowHeadersWidth = 51;
            this.tablaClavesCompartidas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaClavesCompartidas.RowTemplate.Height = 24;
            this.tablaClavesCompartidas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tablaClavesCompartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClavesCompartidas.Size = new System.Drawing.Size(380, 337);
            this.tablaClavesCompartidas.TabIndex = 1;
            // 
            // CompartidaPor
            // 
            this.CompartidaPor.HeaderText = "Compartida por:";
            this.CompartidaPor.MinimumWidth = 6;
            this.CompartidaPor.Name = "CompartidaPor";
            this.CompartidaPor.ReadOnly = true;
            this.CompartidaPor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CompartidaPor.Width = 125;
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
            // botonVer
            // 
            this.botonVer.Location = new System.Drawing.Point(497, 337);
            this.botonVer.Name = "botonVer";
            this.botonVer.Size = new System.Drawing.Size(75, 23);
            this.botonVer.TabIndex = 2;
            this.botonVer.Text = "Ver";
            this.botonVer.UseVisualStyleBackColor = true;
            this.botonVer.Click += new System.EventHandler(this.botonVer_Click);
            // 
            // ListaClavesCompartidasConmigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.tablaClavesCompartidas);
            this.Name = "ListaClavesCompartidasConmigo";
            this.Size = new System.Drawing.Size(673, 430);
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesCompartidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaClavesCompartidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompartidaPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.Button botonVer;
    }
}
