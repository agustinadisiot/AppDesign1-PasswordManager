
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
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonIniciar
            // 
            this.botonIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonIniciar.Location = new System.Drawing.Point(466, 461);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(192, 45);
            this.botonIniciar.TabIndex = 0;
            this.botonIniciar.Text = "Iniciar Sesion";
            this.botonIniciar.UseVisualStyleBackColor = true;
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputUsuario.Location = new System.Drawing.Point(150, 214);
            this.inputUsuario.MaxLength = 25;
            this.inputUsuario.MinimumSize = new System.Drawing.Size(0, 5);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(329, 34);
            this.inputUsuario.TabIndex = 1;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelUsuario.Location = new System.Drawing.Point(145, 173);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(190, 29);
            this.labelUsuario.TabIndex = 2;
            this.labelUsuario.Text = "Ingresar Usuario";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContra.Location = new System.Drawing.Point(145, 275);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(230, 29);
            this.labelContra.TabIndex = 4;
            this.labelContra.Text = "Ingresar Contraseña";
            // 
            // inputContra
            // 
            this.inputContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputContra.Location = new System.Drawing.Point(150, 316);
            this.inputContra.MaxLength = 25;
            this.inputContra.MinimumSize = new System.Drawing.Size(0, 5);
            this.inputContra.Name = "inputContra";
            this.inputContra.Size = new System.Drawing.Size(329, 34);
            this.inputContra.TabIndex = 3;
            this.inputContra.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.Location = new System.Drawing.Point(143, 38);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(380, 42);
            this.labelTitulo.TabIndex = 5;
            this.labelTitulo.Text = "Iniciar Sesion Usuario";
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnCrearUsuario.Location = new System.Drawing.Point(239, 461);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(192, 45);
            this.btnCrearUsuario.TabIndex = 6;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            // 
            // IniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.inputContra);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.botonIniciar);
            this.Name = "IniciarSesion";
            this.Size = new System.Drawing.Size(700, 554);
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
        private System.Windows.Forms.Button btnCrearUsuario;
    }
}
