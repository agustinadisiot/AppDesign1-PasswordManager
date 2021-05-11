
namespace Interfaz.InterfacesClaves
{
    partial class ModificarClave
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
            this.labelErrores = new System.Windows.Forms.Label();
            this.groupBoxClave = new System.Windows.Forms.GroupBox();
            this.labelLargo = new System.Windows.Forms.Label();
            this.inputContra = new System.Windows.Forms.TextBox();
            this.spinnerLargo = new System.Windows.Forms.NumericUpDown();
            this.botonGenerar = new System.Windows.Forms.Button();
            this.checkBoxMayusculas = new System.Windows.Forms.CheckBox();
            this.checkBoxSimbolos = new System.Windows.Forms.CheckBox();
            this.checkBoxMinusculas = new System.Windows.Forms.CheckBox();
            this.checkBoxNumeros = new System.Windows.Forms.CheckBox();
            this.botonModificar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.inputNota = new System.Windows.Forms.TextBox();
            this.labelNota = new System.Windows.Forms.Label();
            this.labelContra = new System.Windows.Forms.Label();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.labelSitio = new System.Windows.Forms.Label();
            this.inputSitio = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxClave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerLargo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(755, 642);
            this.labelErrores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(62, 13);
            this.labelErrores.TabIndex = 68;
            this.labelErrores.Text = "labelErrores";
            // 
            // groupBoxClave
            // 
            this.groupBoxClave.BackColor = System.Drawing.Color.White;
            this.groupBoxClave.Controls.Add(this.labelLargo);
            this.groupBoxClave.Controls.Add(this.inputContra);
            this.groupBoxClave.Controls.Add(this.spinnerLargo);
            this.groupBoxClave.Controls.Add(this.botonGenerar);
            this.groupBoxClave.Controls.Add(this.checkBoxMayusculas);
            this.groupBoxClave.Controls.Add(this.checkBoxSimbolos);
            this.groupBoxClave.Controls.Add(this.checkBoxMinusculas);
            this.groupBoxClave.Controls.Add(this.checkBoxNumeros);
            this.groupBoxClave.Location = new System.Drawing.Point(370, 222);
            this.groupBoxClave.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxClave.Name = "groupBoxClave";
            this.groupBoxClave.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxClave.Size = new System.Drawing.Size(359, 286);
            this.groupBoxClave.TabIndex = 4;
            this.groupBoxClave.TabStop = false;
            this.groupBoxClave.Text = "Contraseña";
            // 
            // labelLargo
            // 
            this.labelLargo.AutoSize = true;
            this.labelLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelLargo.Location = new System.Drawing.Point(4, 69);
            this.labelLargo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLargo.Name = "labelLargo";
            this.labelLargo.Size = new System.Drawing.Size(45, 17);
            this.labelLargo.TabIndex = 40;
            this.labelLargo.Text = "Largo";
            // 
            // inputContra
            // 
            this.inputContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inputContra.Location = new System.Drawing.Point(4, 24);
            this.inputContra.Margin = new System.Windows.Forms.Padding(2);
            this.inputContra.MaxLength = 25;
            this.inputContra.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputContra.Name = "inputContra";
            this.inputContra.Size = new System.Drawing.Size(351, 23);
            this.inputContra.TabIndex = 4;
            // 
            // spinnerLargo
            // 
            this.spinnerLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.spinnerLargo.Location = new System.Drawing.Point(53, 67);
            this.spinnerLargo.Margin = new System.Windows.Forms.Padding(2);
            this.spinnerLargo.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.spinnerLargo.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinnerLargo.Name = "spinnerLargo";
            this.spinnerLargo.Size = new System.Drawing.Size(68, 23);
            this.spinnerLargo.TabIndex = 41;
            this.spinnerLargo.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // botonGenerar
            // 
            this.botonGenerar.Location = new System.Drawing.Point(279, 258);
            this.botonGenerar.Name = "botonGenerar";
            this.botonGenerar.Size = new System.Drawing.Size(75, 23);
            this.botonGenerar.TabIndex = 50;
            this.botonGenerar.Text = "Generar";
            this.botonGenerar.UseVisualStyleBackColor = true;
            this.botonGenerar.Click += new System.EventHandler(this.botonGenerar_Click);
            // 
            // checkBoxMayusculas
            // 
            this.checkBoxMayusculas.AutoSize = true;
            this.checkBoxMayusculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxMayusculas.Location = new System.Drawing.Point(8, 111);
            this.checkBoxMayusculas.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMayusculas.Name = "checkBoxMayusculas";
            this.checkBoxMayusculas.Size = new System.Drawing.Size(178, 21);
            this.checkBoxMayusculas.TabIndex = 46;
            this.checkBoxMayusculas.Text = "Mayúsculas (A, B, C, ...)";
            this.checkBoxMayusculas.UseVisualStyleBackColor = true;
            // 
            // checkBoxSimbolos
            // 
            this.checkBoxSimbolos.AutoSize = true;
            this.checkBoxSimbolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxSimbolos.Location = new System.Drawing.Point(8, 210);
            this.checkBoxSimbolos.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSimbolos.Name = "checkBoxSimbolos";
            this.checkBoxSimbolos.Size = new System.Drawing.Size(160, 21);
            this.checkBoxSimbolos.TabIndex = 49;
            this.checkBoxSimbolos.Text = "Símbolos (@, [, $, ...)";
            this.checkBoxSimbolos.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinusculas
            // 
            this.checkBoxMinusculas.AutoSize = true;
            this.checkBoxMinusculas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxMinusculas.Location = new System.Drawing.Point(8, 145);
            this.checkBoxMinusculas.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMinusculas.Name = "checkBoxMinusculas";
            this.checkBoxMinusculas.Size = new System.Drawing.Size(170, 21);
            this.checkBoxMinusculas.TabIndex = 47;
            this.checkBoxMinusculas.Text = "Minúsculas (a, b, c, ...)";
            this.checkBoxMinusculas.UseVisualStyleBackColor = true;
            // 
            // checkBoxNumeros
            // 
            this.checkBoxNumeros.AutoSize = true;
            this.checkBoxNumeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxNumeros.Location = new System.Drawing.Point(8, 178);
            this.checkBoxNumeros.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxNumeros.Name = "checkBoxNumeros";
            this.checkBoxNumeros.Size = new System.Drawing.Size(158, 21);
            this.checkBoxNumeros.TabIndex = 48;
            this.checkBoxNumeros.Text = "Numeros (1, 2, 3, ...)";
            this.checkBoxNumeros.UseVisualStyleBackColor = true;
            // 
            // botonModificar
            // 
            this.botonModificar.Location = new System.Drawing.Point(654, 637);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(75, 23);
            this.botonModificar.TabIndex = 6;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(555, 637);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(75, 23);
            this.botonCancelar.TabIndex = 7;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // inputNota
            // 
            this.inputNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputNota.Location = new System.Drawing.Point(370, 522);
            this.inputNota.Margin = new System.Windows.Forms.Padding(2);
            this.inputNota.MaxLength = 250;
            this.inputNota.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNota.Multiline = true;
            this.inputNota.Name = "inputNota";
            this.inputNota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputNota.Size = new System.Drawing.Size(359, 110);
            this.inputNota.TabIndex = 5;
            // 
            // labelNota
            // 
            this.labelNota.AutoSize = true;
            this.labelNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNota.Location = new System.Drawing.Point(190, 522);
            this.labelNota.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNota.Name = "labelNota";
            this.labelNota.Size = new System.Drawing.Size(45, 17);
            this.labelNota.TabIndex = 63;
            this.labelNota.Text = "Notas";
            // 
            // labelContra
            // 
            this.labelContra.AutoSize = true;
            this.labelContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelContra.Location = new System.Drawing.Point(193, 222);
            this.labelContra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContra.Name = "labelContra";
            this.labelContra.Size = new System.Drawing.Size(81, 17);
            this.labelContra.TabIndex = 62;
            this.labelContra.Text = "Contraseña";
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(370, 115);
            this.comboBoxCategorias.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(201, 24);
            this.comboBoxCategorias.TabIndex = 1;
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCategoria.Location = new System.Drawing.Point(193, 118);
            this.labelCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(69, 17);
            this.labelCategoria.TabIndex = 60;
            this.labelCategoria.Text = "Categoria";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelUsuario.Location = new System.Drawing.Point(193, 189);
            this.labelUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(57, 17);
            this.labelUsuario.TabIndex = 59;
            this.labelUsuario.Text = "Usuario";
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inputUsuario.Location = new System.Drawing.Point(370, 186);
            this.inputUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.inputUsuario.MaxLength = 25;
            this.inputUsuario.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(201, 23);
            this.inputUsuario.TabIndex = 3;
            // 
            // labelSitio
            // 
            this.labelSitio.AutoSize = true;
            this.labelSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSitio.Location = new System.Drawing.Point(193, 154);
            this.labelSitio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSitio.Name = "labelSitio";
            this.labelSitio.Size = new System.Drawing.Size(35, 17);
            this.labelSitio.TabIndex = 57;
            this.labelSitio.Text = "Sitio";
            // 
            // inputSitio
            // 
            this.inputSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.inputSitio.Location = new System.Drawing.Point(370, 151);
            this.inputSitio.Margin = new System.Windows.Forms.Padding(2);
            this.inputSitio.MaxLength = 25;
            this.inputSitio.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputSitio.Name = "inputSitio";
            this.inputSitio.Size = new System.Drawing.Size(200, 23);
            this.inputSitio.TabIndex = 2;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.Location = new System.Drawing.Point(358, 32);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(298, 36);
            this.labelTitulo.TabIndex = 55;
            this.labelTitulo.Text = "Modificar Contraseña";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 100);
            this.panel1.TabIndex = 69;
            // 
            // ModificarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.groupBoxClave);
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.inputNota);
            this.Controls.Add(this.labelNota);
            this.Controls.Add(this.labelContra);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.labelSitio);
            this.Controls.Add(this.inputSitio);
            this.Name = "ModificarClave";
            this.Size = new System.Drawing.Size(1014, 681);
            this.Load += new System.EventHandler(this.ModificarClave_Load);
            this.groupBoxClave.ResumeLayout(false);
            this.groupBoxClave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerLargo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.GroupBox groupBoxClave;
        private System.Windows.Forms.Label labelLargo;
        private System.Windows.Forms.TextBox inputContra;
        private System.Windows.Forms.NumericUpDown spinnerLargo;
        private System.Windows.Forms.Button botonGenerar;
        private System.Windows.Forms.CheckBox checkBoxMayusculas;
        private System.Windows.Forms.CheckBox checkBoxSimbolos;
        private System.Windows.Forms.CheckBox checkBoxMinusculas;
        private System.Windows.Forms.CheckBox checkBoxNumeros;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.TextBox inputNota;
        private System.Windows.Forms.Label labelNota;
        private System.Windows.Forms.Label labelContra;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Label labelSitio;
        private System.Windows.Forms.TextBox inputSitio;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panel1;
    }
}
