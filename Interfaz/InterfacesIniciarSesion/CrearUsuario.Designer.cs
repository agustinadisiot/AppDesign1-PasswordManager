
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
            this.labelErrores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.Location = new System.Drawing.Point(2, 28);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(200, 36);
            this.labelTitulo.TabIndex = 11;
            this.labelTitulo.Text = "Crear Usuario";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContra.Location = new System.Drawing.Point(4, 220);
            this.labelContra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(179, 24);
            this.labelContra.TabIndex = 10;
            this.labelContra.Text = "Ingresar Contraseña";
            // 
            // inputContra
            // 
            this.inputContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputContra.Location = new System.Drawing.Point(8, 254);
            this.inputContra.Margin = new System.Windows.Forms.Padding(2);
            this.inputContra.MaxLength = 25;
            this.inputContra.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputContra.Name = "inputContra";
            this.inputContra.Size = new System.Drawing.Size(248, 29);
            this.inputContra.TabIndex = 2;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelUsuario.Location = new System.Drawing.Point(4, 137);
            this.labelUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(147, 24);
            this.labelUsuario.TabIndex = 8;
            this.labelUsuario.Text = "Ingresar Usuario";
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputUsuario.Location = new System.Drawing.Point(8, 171);
            this.inputUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.inputUsuario.MaxLength = 25;
            this.inputUsuario.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(248, 29);
            this.inputUsuario.TabIndex = 1;
            // 
            // botonCrear
            // 
            this.botonCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCrear.Location = new System.Drawing.Point(105, 302);
            this.botonCrear.Margin = new System.Windows.Forms.Padding(2);
            this.botonCrear.Name = "botonCrear";
            this.botonCrear.Size = new System.Drawing.Size(149, 32);
            this.botonCrear.TabIndex = 3;
            this.botonCrear.Text = "Crear Usuario";
            this.botonCrear.UseVisualStyleBackColor = true;
            this.botonCrear.Click += new System.EventHandler(this.botonCrear_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCancelar.Location = new System.Drawing.Point(250, 383);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(144, 37);
            this.botonCancelar.TabIndex = 4;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(3, 397);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(64, 13);
            this.labelErrores.TabIndex = 17;
            this.labelErrores.Text = "MostrarError";
            // 
            // CrearUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.inputContra);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.botonCrear);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CrearUsuario";
            this.Size = new System.Drawing.Size(1075, 681);
            this.Load += new System.EventHandler(this.CrearUsuario_Load);
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
        private System.Windows.Forms.Label labelErrores;
    }
}
