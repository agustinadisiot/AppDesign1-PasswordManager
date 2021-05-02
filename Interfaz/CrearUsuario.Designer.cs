
namespace Interfaz
{
    partial class CrearUsuario
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelContra = new System.Windows.Forms.Label();
            this.inputContra = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.botonCrear = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.Location = new System.Drawing.Point(3, 34);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(250, 42);
            this.labelTitulo.TabIndex = 11;
            this.labelTitulo.Text = "Crear Usuario";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContra.Location = new System.Drawing.Point(5, 271);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(230, 29);
            this.labelContra.TabIndex = 10;
            this.labelContra.Text = "Ingresar Contraseña";
            // 
            // inputContra
            // 
            this.inputContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputContra.Location = new System.Drawing.Point(10, 312);
            this.inputContra.MaxLength = 25;
            this.inputContra.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputContra.Name = "inputContra";
            this.inputContra.Size = new System.Drawing.Size(329, 34);
            this.inputContra.TabIndex = 9;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelUsuario.Location = new System.Drawing.Point(5, 169);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(190, 29);
            this.labelUsuario.TabIndex = 8;
            this.labelUsuario.Text = "Ingresar Usuario";
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputUsuario.Location = new System.Drawing.Point(10, 210);
            this.inputUsuario.MaxLength = 25;
            this.inputUsuario.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(329, 34);
            this.inputUsuario.TabIndex = 7;
            // 
            // botonCrear
            // 
            this.botonCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCrear.Location = new System.Drawing.Point(140, 372);
            this.botonCrear.Name = "botonCrear";
            this.botonCrear.Size = new System.Drawing.Size(199, 39);
            this.botonCrear.TabIndex = 6;
            this.botonCrear.Text = "Crear Usuario";
            this.botonCrear.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCancelar.Location = new System.Drawing.Point(334, 471);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(192, 45);
            this.botonCancelar.TabIndex = 12;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // CrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.inputContra);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.botonCrear);
            this.Name = "CrearUsuario";
            this.Size = new System.Drawing.Size(700, 554);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelContra;
        private System.Windows.Forms.TextBox inputContra;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Button botonCrear;
        private System.Windows.Forms.Button botonCancelar;
    }
}
