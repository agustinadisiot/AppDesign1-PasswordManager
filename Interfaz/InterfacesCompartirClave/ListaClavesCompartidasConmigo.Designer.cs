
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
            this.botonVer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.CompartidaPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesCompartidas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablaClavesCompartidas
            // 
            this.tablaClavesCompartidas.AllowUserToAddRows = false;
            this.tablaClavesCompartidas.AllowUserToDeleteRows = false;
            this.tablaClavesCompartidas.AllowUserToResizeColumns = false;
            this.tablaClavesCompartidas.AllowUserToResizeRows = false;
            this.tablaClavesCompartidas.BackgroundColor = System.Drawing.Color.White;
            this.tablaClavesCompartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClavesCompartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompartidaPor,
            this.Sitio,
            this.Usuario});
            this.tablaClavesCompartidas.Location = new System.Drawing.Point(218, 131);
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
            this.tablaClavesCompartidas.Size = new System.Drawing.Size(604, 337);
            this.tablaClavesCompartidas.TabIndex = 1;
            // 
            // botonVer
            // 
            this.botonVer.Location = new System.Drawing.Point(678, 498);
            this.botonVer.Name = "botonVer";
            this.botonVer.Size = new System.Drawing.Size(144, 37);
            this.botonVer.TabIndex = 2;
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
            this.panel1.TabIndex = 3;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(259, 32);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(485, 36);
            this.labelTitulo.TabIndex = 19;
            this.labelTitulo.Text = "Contraseñas Compartidas Conmigo";
            // 
            // CompartidaPor
            // 
            this.CompartidaPor.HeaderText = "Compartida por:";
            this.CompartidaPor.MinimumWidth = 6;
            this.CompartidaPor.Name = "CompartidaPor";
            this.CompartidaPor.ReadOnly = true;
            this.CompartidaPor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CompartidaPor.Width = 200;
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio";
            this.Sitio.MinimumWidth = 6;
            this.Sitio.Name = "Sitio";
            this.Sitio.ReadOnly = true;
            this.Sitio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sitio.Width = 200;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Usuario.Width = 200;
            // 
            // ListaClavesCompartidasConmigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.tablaClavesCompartidas);
            this.Name = "ListaClavesCompartidasConmigo";
            this.Size = new System.Drawing.Size(1002, 681);
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesCompartidas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaClavesCompartidas;
        private System.Windows.Forms.Button botonVer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompartidaPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.Label labelTitulo;
    }
}
