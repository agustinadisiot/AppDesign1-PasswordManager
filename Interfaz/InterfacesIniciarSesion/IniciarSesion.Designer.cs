
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
            this.inputContra = new System.Windows.Forms.TextBox();
            this.labelContra = new System.Windows.Forms.Label();
            this.botonCrearUsuario = new System.Windows.Forms.Button();
            this.labelErrores = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonIniciar
            // 
            this.botonIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonIniciar.Location = new System.Drawing.Point(781, 447);
            this.botonIniciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(199, 39);
            this.botonIniciar.TabIndex = 3;
            this.botonIniciar.Text = "Iniciar Sesión";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputUsuario.Location = new System.Drawing.Point(649, 246);
            this.inputUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputUsuario.MaxLength = 25;
            this.inputUsuario.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(329, 34);
            this.inputUsuario.TabIndex = 1;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelUsuario.Location = new System.Drawing.Point(644, 204);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(190, 29);
            this.labelUsuario.TabIndex = 6;
            this.labelUsuario.Text = "Ingresar Usuario";
            // 
            // inputContra
            // 
            this.inputContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputContra.Location = new System.Drawing.Point(649, 347);
            this.inputContra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputContra.MaxLength = 25;
            this.inputContra.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputContra.Name = "inputContra";
            this.inputContra.PasswordChar = '*';
            this.inputContra.Size = new System.Drawing.Size(329, 34);
            this.inputContra.TabIndex = 2;
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContra.Location = new System.Drawing.Point(644, 305);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(230, 29);
            this.labelContra.TabIndex = 4;
            this.labelContra.Text = "Ingresar Contraseña";
            // 
            // botonCrearUsuario
            // 
            this.botonCrearUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCrearUsuario.Location = new System.Drawing.Point(1063, 581);
            this.botonCrearUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonCrearUsuario.Name = "botonCrearUsuario";
            this.botonCrearUsuario.Size = new System.Drawing.Size(192, 46);
            this.botonCrearUsuario.TabIndex = 4;
            this.botonCrearUsuario.Text = "Crear Usuario";
            this.botonCrearUsuario.UseVisualStyleBackColor = true;
            this.botonCrearUsuario.Click += new System.EventHandler(this.botonCrearUsuario_Click);
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(1039, 462);
            this.labelErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrores.MaximumSize = new System.Drawing.Size(296, 111);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(88, 17);
            this.labelErrores.TabIndex = 16;
            this.labelErrores.Text = "MostrarError";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1625, 123);
            this.panel1.TabIndex = 17;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(608, 39);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(380, 42);
            this.labelTitulo.TabIndex = 6;
            this.labelTitulo.Text = "Iniciar Sesión Usuario";
            // 
            // IniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.botonCrearUsuario);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.inputContra);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.botonIniciar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IniciarSesion";
            this.Size = new System.Drawing.Size(1625, 886);
            this.Load += new System.EventHandler(this.IniciarSesion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox inputContra;
        private System.Windows.Forms.Label labelContra;
        private System.Windows.Forms.Button botonCrearUsuario;
        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitulo;
    }
}
