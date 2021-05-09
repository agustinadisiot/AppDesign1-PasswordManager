
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
            this.tablaClavesComparidas = new System.Windows.Forms.DataGridView();
            this.CompartidaPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesComparidas)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaClavesComparidas
            // 
            this.tablaClavesComparidas.AllowUserToAddRows = false;
            this.tablaClavesComparidas.AllowUserToDeleteRows = false;
            this.tablaClavesComparidas.AllowUserToResizeColumns = false;
            this.tablaClavesComparidas.AllowUserToResizeRows = false;
            this.tablaClavesComparidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClavesComparidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompartidaPor,
            this.Sitio,
            this.Usuario});
            this.tablaClavesComparidas.Location = new System.Drawing.Point(68, 23);
            this.tablaClavesComparidas.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClavesComparidas.MultiSelect = false;
            this.tablaClavesComparidas.Name = "tablaClavesComparidas";
            this.tablaClavesComparidas.ReadOnly = true;
            this.tablaClavesComparidas.RowHeadersVisible = false;
            this.tablaClavesComparidas.RowHeadersWidth = 51;
            this.tablaClavesComparidas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablaClavesComparidas.RowTemplate.Height = 24;
            this.tablaClavesComparidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClavesComparidas.Size = new System.Drawing.Size(380, 337);
            this.tablaClavesComparidas.TabIndex = 1;
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
            // 
            // ListaClavesCompartidasConmigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.tablaClavesComparidas);
            this.Name = "ListaClavesCompartidasConmigo";
            this.Size = new System.Drawing.Size(673, 430);
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesComparidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaClavesComparidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompartidaPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.Button botonVer;
    }
}
