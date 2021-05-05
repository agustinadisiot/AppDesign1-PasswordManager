
namespace Interfaz
{
    partial class IniciarSesion
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
            this.botonIniciar = new System.Windows.Forms.Button();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelContra = new System.Windows.Forms.Label();
            this.inputContra = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.botonCrearUsuario = new System.Windows.Forms.Button();
            this.labelErrores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botonIniciar
            // 
            this.botonIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonIniciar.Location = new System.Drawing.Point(105, 302);
            this.botonIniciar.Margin = new System.Windows.Forms.Padding(2);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(149, 32);
            this.botonIniciar.TabIndex = 0;
            this.botonIniciar.Text = "Iniciar Sesion";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
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
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelUsuario.Location = new System.Drawing.Point(4, 137);
            this.labelUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(147, 24);
            this.labelUsuario.TabIndex = 2;
            this.labelUsuario.Text = "Ingresar Usuario";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContra.Location = new System.Drawing.Point(4, 220);
            this.labelContra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(179, 24);
            this.labelContra.TabIndex = 4;
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
            this.inputContra.TabIndex = 3;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.Location = new System.Drawing.Point(2, 28);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(307, 36);
            this.labelTitulo.TabIndex = 5;
            this.labelTitulo.Text = "Iniciar Sesion Usuario";
            // 
            // botonCrearUsuario
            // 
            this.botonCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCrearUsuario.Location = new System.Drawing.Point(250, 383);
            this.botonCrearUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.botonCrearUsuario.Name = "botonCrearUsuario";
            this.botonCrearUsuario.Size = new System.Drawing.Size(144, 37);
            this.botonCrearUsuario.TabIndex = 6;
            this.botonCrearUsuario.Text = "Crear Usuario";
            this.botonCrearUsuario.UseVisualStyleBackColor = true;
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(5, 397);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(64, 13);
            this.labelErrores.TabIndex = 16;
            this.labelErrores.Text = "MostrarError";
            // 
            // IniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.botonCrearUsuario);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.inputContra);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.botonIniciar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IniciarSesion";
            this.Size = new System.Drawing.Size(1075, 681);
            this.Load += new System.EventHandler(this.IniciarSesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelContra;
        private System.Windows.Forms.TextBox inputContra;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button botonCrearUsuario;
        private System.Windows.Forms.Label labelErrores;
    }
}
