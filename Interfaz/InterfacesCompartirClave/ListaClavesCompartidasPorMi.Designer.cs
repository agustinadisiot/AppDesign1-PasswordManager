
namespace Interfaz.InterfacesCompartirClave
{
    partial class ListaClavesCompartidasPorMi
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
            this.botonVer = new System.Windows.Forms.Button();
            this.tablaClavesCompartidas = new System.Windows.Forms.DataGridView();
            this.CompartidaA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonDejarDeCompartir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesCompartidas)).BeginInit();
            this.SuspendLayout();
            // 
            // botonVer
            // 
            this.botonVer.Location = new System.Drawing.Point(491, 339);
            this.botonVer.Name = "botonVer";
            this.botonVer.Size = new System.Drawing.Size(75, 23);
            this.botonVer.TabIndex = 4;
            this.botonVer.Text = "Ver";
            this.botonVer.UseVisualStyleBackColor = true;
            // 
            // tablaClavesCompartidas
            // 
            this.tablaClavesCompartidas.AllowUserToAddRows = false;
            this.tablaClavesCompartidas.AllowUserToDeleteRows = false;
            this.tablaClavesCompartidas.AllowUserToResizeColumns = false;
            this.tablaClavesCompartidas.AllowUserToResizeRows = false;
            this.tablaClavesCompartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaClavesCompartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompartidaA,
            this.Sitio,
            this.Usuario});
            this.tablaClavesCompartidas.Location = new System.Drawing.Point(70, 25);
            this.tablaClavesCompartidas.Margin = new System.Windows.Forms.Padding(4);
            this.tablaClavesCompartidas.MultiSelect = false;
            this.tablaClavesCompartidas.Name = "tablaClavesCompartidas";
            this.tablaClavesCompartidas.ReadOnly = true;
            this.tablaClavesCompartidas.RowHeadersVisible = false;
            this.tablaClavesCompartidas.RowHeadersWidth = 51;
            this.tablaClavesCompartidas.RowTemplate.Height = 24;
            this.tablaClavesCompartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaClavesCompartidas.Size = new System.Drawing.Size(380, 337);
            this.tablaClavesCompartidas.TabIndex = 3;
            // 
            // CompartidaA
            // 
            this.CompartidaA.HeaderText = "Compartida a:";
            this.CompartidaA.MinimumWidth = 6;
            this.CompartidaA.Name = "CompartidaA";
            this.CompartidaA.ReadOnly = true;
            this.CompartidaA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CompartidaA.Width = 125;
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
            // botonDejarDeCompartir
            // 
            this.botonDejarDeCompartir.Location = new System.Drawing.Point(491, 287);
            this.botonDejarDeCompartir.Name = "botonDejarDeCompartir";
            this.botonDejarDeCompartir.Size = new System.Drawing.Size(75, 35);
            this.botonDejarDeCompartir.TabIndex = 5;
            this.botonDejarDeCompartir.Text = "Dejar De Compartir";
            this.botonDejarDeCompartir.UseVisualStyleBackColor = true;
            this.botonDejarDeCompartir.Click += new System.EventHandler(this.botonDejarDeCompartir_Click);
            // 
            // ListaClavesCompartidasPorMi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonDejarDeCompartir);
            this.Controls.Add(this.botonVer);
            this.Controls.Add(this.tablaClavesCompartidas);
            this.Name = "ListaClavesCompartidasPorMi";
            this.Size = new System.Drawing.Size(674, 432);
            ((System.ComponentModel.ISupportInitialize)(this.tablaClavesCompartidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonVer;
        private System.Windows.Forms.DataGridView tablaClavesCompartidas;
        private System.Windows.Forms.Button botonDejarDeCompartir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompartidaA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
    }
}
