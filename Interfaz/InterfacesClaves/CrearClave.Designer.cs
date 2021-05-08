
namespace Interfaz
{
    partial class CrearClave
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
            this.comboCategorias = new System.Windows.Forms.ComboBox();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.labelSitio = new System.Windows.Forms.Label();
            this.inputSitio = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelLargo = new System.Windows.Forms.Label();
            this.labelContra = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.largoSpinner = new System.Windows.Forms.NumericUpDown();
            this.labelNota = new System.Windows.Forms.Label();
            this.inputNota = new System.Windows.Forms.TextBox();
            this.checkBoxMayusculas = new System.Windows.Forms.CheckBox();
            this.checkBoxMinusculas = new System.Windows.Forms.CheckBox();
            this.checkBoxNumeros = new System.Windows.Forms.CheckBox();
            this.checkBoxSimbolos = new System.Windows.Forms.CheckBox();
            this.botonGenerar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.groupBoxClave = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.largoSpinner)).BeginInit();
            this.groupBoxClave.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboCategorias
            // 
            this.comboCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboCategorias.FormattingEnabled = true;
            this.comboCategorias.Location = new System.Drawing.Point(243, 127);
            this.comboCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboCategorias.Name = "comboCategorias";
            this.comboCategorias.Size = new System.Drawing.Size(266, 28);
            this.comboCategorias.TabIndex = 35;
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCategoria.Location = new System.Drawing.Point(5, 130);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(81, 20);
            this.labelCategoria.TabIndex = 34;
            this.labelCategoria.Text = "Categoria";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelUsuario.Location = new System.Drawing.Point(6, 229);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(67, 20);
            this.labelUsuario.TabIndex = 32;
            this.labelUsuario.Text = "Usuario";
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inputUsuario.Location = new System.Drawing.Point(242, 226);
            this.inputUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputUsuario.MaxLength = 25;
            this.inputUsuario.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.ReadOnly = true;
            this.inputUsuario.Size = new System.Drawing.Size(267, 26);
            this.inputUsuario.TabIndex = 31;
            // 
            // labelSitio
            // 
            this.labelSitio.AutoSize = true;
            this.labelSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSitio.Location = new System.Drawing.Point(6, 179);
            this.labelSitio.Name = "labelSitio";
            this.labelSitio.Size = new System.Drawing.Size(42, 20);
            this.labelSitio.TabIndex = 30;
            this.labelSitio.Text = "Sitio";
            // 
            // inputSitio
            // 
            this.inputSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inputSitio.Location = new System.Drawing.Point(243, 176);
            this.inputSitio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputSitio.MaxLength = 25;
            this.inputSitio.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputSitio.Name = "inputSitio";
            this.inputSitio.ReadOnly = true;
            this.inputSitio.Size = new System.Drawing.Size(266, 26);
            this.inputSitio.TabIndex = 29;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelTitulo.Location = new System.Drawing.Point(4, 25);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(230, 31);
            this.labelTitulo.TabIndex = 28;
            this.labelTitulo.Text = "Crear Contraseña";
            // 
            // labelLargo
            // 
            this.labelLargo.AutoSize = true;
            this.labelLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelLargo.Location = new System.Drawing.Point(6, 85);
            this.labelLargo.Name = "labelLargo";
            this.labelLargo.Size = new System.Drawing.Size(52, 20);
            this.labelLargo.TabIndex = 40;
            this.labelLargo.Text = "Largo";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelContra.Location = new System.Drawing.Point(6, 316);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(95, 20);
            this.labelContra.TabIndex = 38;
            this.labelContra.Text = "Contraseña";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox2.Location = new System.Drawing.Point(6, 30);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.MaxLength = 25;
            this.textBox2.MinimumSize = new System.Drawing.Size(4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(267, 26);
            this.textBox2.TabIndex = 37;
            // 
            // largoSpinner
            // 
            this.largoSpinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.largoSpinner.Location = new System.Drawing.Point(183, 83);
            this.largoSpinner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.largoSpinner.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.largoSpinner.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.largoSpinner.Name = "largoSpinner";
            this.largoSpinner.Size = new System.Drawing.Size(90, 26);
            this.largoSpinner.TabIndex = 41;
            this.largoSpinner.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // labelNota
            // 
            this.labelNota.AutoSize = true;
            this.labelNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNota.Location = new System.Drawing.Point(6, 682);
            this.labelNota.Name = "labelNota";
            this.labelNota.Size = new System.Drawing.Size(53, 20);
            this.labelNota.TabIndex = 43;
            this.labelNota.Text = "Notas";
            // 
            // inputNota
            // 
            this.inputNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNota.Location = new System.Drawing.Point(243, 682);
            this.inputNota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNota.MaxLength = 25;
            this.inputNota.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNota.Multiline = true;
            this.inputNota.Name = "inputNota";
            this.inputNota.Size = new System.Drawing.Size(305, 134);
            this.inputNota.TabIndex = 44;
            // 
            // checkBoxMayusculas
            // 
            this.checkBoxMayusculas.AutoSize = true;
            this.checkBoxMayusculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxMayusculas.Location = new System.Drawing.Point(10, 137);
            this.checkBoxMayusculas.Name = "checkBoxMayusculas";
            this.checkBoxMayusculas.Size = new System.Drawing.Size(211, 24);
            this.checkBoxMayusculas.TabIndex = 46;
            this.checkBoxMayusculas.Text = "Mayúsculas (A, B, C, ...)";
            this.checkBoxMayusculas.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinusculas
            // 
            this.checkBoxMinusculas.AutoSize = true;
            this.checkBoxMinusculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxMinusculas.Location = new System.Drawing.Point(10, 178);
            this.checkBoxMinusculas.Name = "checkBoxMinusculas";
            this.checkBoxMinusculas.Size = new System.Drawing.Size(199, 24);
            this.checkBoxMinusculas.TabIndex = 47;
            this.checkBoxMinusculas.Text = "Minúsculas (a, b, c, ...)";
            this.checkBoxMinusculas.UseVisualStyleBackColor = true;
            // 
            // checkBoxNumeros
            // 
            this.checkBoxNumeros.AutoSize = true;
            this.checkBoxNumeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxNumeros.Location = new System.Drawing.Point(10, 219);
            this.checkBoxNumeros.Name = "checkBoxNumeros";
            this.checkBoxNumeros.Size = new System.Drawing.Size(182, 24);
            this.checkBoxNumeros.TabIndex = 48;
            this.checkBoxNumeros.Text = "Numeros (1, 2, 3, ...)";
            this.checkBoxNumeros.UseVisualStyleBackColor = true;
            // 
            // checkBoxSimbolos
            // 
            this.checkBoxSimbolos.AutoSize = true;
            this.checkBoxSimbolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxSimbolos.Location = new System.Drawing.Point(10, 259);
            this.checkBoxSimbolos.Name = "checkBoxSimbolos";
            this.checkBoxSimbolos.Size = new System.Drawing.Size(187, 24);
            this.checkBoxSimbolos.TabIndex = 49;
            this.checkBoxSimbolos.Text = "Símbolos (@, [, $, ...)";
            this.checkBoxSimbolos.UseVisualStyleBackColor = true;
            // 
            // botonGenerar
            // 
            this.botonGenerar.Location = new System.Drawing.Point(173, 316);
            this.botonGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.botonGenerar.Name = "botonGenerar";
            this.botonGenerar.Size = new System.Drawing.Size(100, 28);
            this.botonGenerar.TabIndex = 50;
            this.botonGenerar.Text = "Generar";
            this.botonGenerar.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(134, 878);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(100, 28);
            this.botonCancelar.TabIndex = 51;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(460, 878);
            this.botonAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(100, 28);
            this.botonAgregar.TabIndex = 52;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = true;
            // 
            // groupBoxClave
            // 
            this.groupBoxClave.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBoxClave.Controls.Add(this.labelLargo);
            this.groupBoxClave.Controls.Add(this.textBox2);
            this.groupBoxClave.Controls.Add(this.largoSpinner);
            this.groupBoxClave.Controls.Add(this.botonGenerar);
            this.groupBoxClave.Controls.Add(this.checkBoxMayusculas);
            this.groupBoxClave.Controls.Add(this.checkBoxSimbolos);
            this.groupBoxClave.Controls.Add(this.checkBoxMinusculas);
            this.groupBoxClave.Controls.Add(this.checkBoxNumeros);
            this.groupBoxClave.Location = new System.Drawing.Point(242, 283);
            this.groupBoxClave.Name = "groupBoxClave";
            this.groupBoxClave.Size = new System.Drawing.Size(306, 364);
            this.groupBoxClave.TabIndex = 53;
            this.groupBoxClave.TabStop = false;
            this.groupBoxClave.Text = "Contraseña";
            // 
            // CrearClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxClave);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.inputNota);
            this.Controls.Add(this.labelNota);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.comboCategorias);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.labelSitio);
            this.Controls.Add(this.inputSitio);
            this.Controls.Add(this.labelTitulo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CrearClave";
            this.Size = new System.Drawing.Size(1428, 833);
            ((System.ComponentModel.ISupportInitialize)(this.largoSpinner)).EndInit();
            this.groupBoxClave.ResumeLayout(false);
            this.groupBoxClave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboCategorias;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Label labelSitio;
        private System.Windows.Forms.TextBox inputSitio;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelLargo;
        private System.Windows.Forms.Label labelContra;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown largoSpinner;
        private System.Windows.Forms.Label labelNota;
        private System.Windows.Forms.TextBox inputNota;
        private System.Windows.Forms.CheckBox checkBoxMayusculas;
        private System.Windows.Forms.CheckBox checkBoxMinusculas;
        private System.Windows.Forms.CheckBox checkBoxNumeros;
        private System.Windows.Forms.CheckBox checkBoxSimbolos;
        private System.Windows.Forms.Button botonGenerar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.GroupBox groupBoxClave;
    }
}
