
namespace Interfaz.InterfacesDataBreaches
{
    partial class IngresosDataBreaches
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
            this.inputDatos = new System.Windows.Forms.TextBox();
            this.botonVerificar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputDatos
            // 
            this.inputDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputDatos.Location = new System.Drawing.Point(227, 100);
            this.inputDatos.Multiline = true;
            this.inputDatos.Name = "inputDatos";
            this.inputDatos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputDatos.Size = new System.Drawing.Size(560, 444);
            this.inputDatos.TabIndex = 31;
            // 
            // botonVerificar
            // 
            this.botonVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonVerificar.Location = new System.Drawing.Point(643, 582);
            this.botonVerificar.Margin = new System.Windows.Forms.Padding(2);
            this.botonVerificar.Name = "botonVerificar";
            this.botonVerificar.Size = new System.Drawing.Size(144, 37);
            this.botonVerificar.TabIndex = 32;
            this.botonVerificar.Text = "Verificar";
            this.botonVerificar.UseVisualStyleBackColor = true;
            this.botonVerificar.Click += new System.EventHandler(this.botonVerificar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelTitulo.Location = new System.Drawing.Point(430, 63);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(154, 25);
            this.labelTitulo.TabIndex = 33;
            this.labelTitulo.Text = "Data Breaches";
            // 
            // IngresosDataBreaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.botonVerificar);
            this.Controls.Add(this.inputDatos);
            this.Name = "IngresosDataBreaches";
            this.Size = new System.Drawing.Size(1014, 681);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputDatos;
        private System.Windows.Forms.Button botonVerificar;
        private System.Windows.Forms.Label labelTitulo;
    }
}
