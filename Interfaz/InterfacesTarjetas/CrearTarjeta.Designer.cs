
namespace Interfaz
{
    partial class CrearTarjeta
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
            this.Titulo = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.labelTipo = new System.Windows.Forms.Label();
            this.inputTipo = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.botonCrear = new System.Windows.Forms.Button();
            this.ingresarCodigo = new System.Windows.Forms.Label();
            this.inputCodigo = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.inputNumero = new System.Windows.Forms.TextBox();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.datePickerVencimiento = new System.Windows.Forms.DateTimePicker();
            this.labelVencimiento = new System.Windows.Forms.Label();
            this.labelNotas = new System.Windows.Forms.Label();
            this.inputNota = new System.Windows.Forms.TextBox();
            this.labelErrores = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.Titulo.ForeColor = System.Drawing.Color.White;
            this.Titulo.Location = new System.Drawing.Point(544, 39);
            this.Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(237, 42);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "Crear Tarjeta";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCancelar.Location = new System.Drawing.Point(688, 693);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(192, 46);
            this.botonCancelar.TabIndex = 9;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTipo.Location = new System.Drawing.Point(211, 266);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(157, 29);
            this.labelTipo.TabIndex = 17;
            this.labelTipo.Text = "Ingresar Tipo";
            // 
            // inputTipo
            // 
            this.inputTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputTipo.Location = new System.Drawing.Point(549, 262);
            this.inputTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputTipo.MaxLength = 25;
            this.inputTipo.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputTipo.Name = "inputTipo";
            this.inputTipo.Size = new System.Drawing.Size(329, 34);
            this.inputTipo.TabIndex = 3;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNombre.Location = new System.Drawing.Point(211, 213);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(195, 29);
            this.labelNombre.TabIndex = 15;
            this.labelNombre.Text = "Ingresar Nombre";
            // 
            // inputNombre
            // 
            this.inputNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNombre.Location = new System.Drawing.Point(549, 209);
            this.inputNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNombre.MaxLength = 25;
            this.inputNombre.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(329, 34);
            this.inputNombre.TabIndex = 2;
            // 
            // botonCrear
            // 
            this.botonCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCrear.Location = new System.Drawing.Point(933, 693);
            this.botonCrear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botonCrear.Name = "botonCrear";
            this.botonCrear.Size = new System.Drawing.Size(192, 46);
            this.botonCrear.TabIndex = 8;
            this.botonCrear.Text = "Crear Tarjeta";
            this.botonCrear.UseVisualStyleBackColor = true;
            this.botonCrear.Click += new System.EventHandler(this.botonCrear_Click);
            // 
            // ingresarCodigo
            // 
            this.ingresarCodigo.AutoSize = true;
            this.ingresarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ingresarCodigo.Location = new System.Drawing.Point(211, 372);
            this.ingresarCodigo.Name = "ingresarCodigo";
            this.ingresarCodigo.Size = new System.Drawing.Size(186, 29);
            this.ingresarCodigo.TabIndex = 22;
            this.ingresarCodigo.Text = "Ingresar Código";
            // 
            // inputCodigo
            // 
            this.inputCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputCodigo.Location = new System.Drawing.Point(549, 368);
            this.inputCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputCodigo.MaxLength = 25;
            this.inputCodigo.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputCodigo.Name = "inputCodigo";
            this.inputCodigo.Size = new System.Drawing.Size(329, 34);
            this.inputCodigo.TabIndex = 5;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNumero.Location = new System.Drawing.Point(211, 319);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(194, 29);
            this.labelNumero.TabIndex = 20;
            this.labelNumero.Text = "Ingresar Número";
            // 
            // inputNumero
            // 
            this.inputNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNumero.Location = new System.Drawing.Point(549, 315);
            this.inputNumero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNumero.MaxLength = 25;
            this.inputNumero.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNumero.Name = "inputNumero";
            this.inputNumero.Size = new System.Drawing.Size(329, 34);
            this.inputNumero.TabIndex = 4;
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelCategoria.Location = new System.Drawing.Point(211, 156);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(188, 29);
            this.labelCategoria.TabIndex = 23;
            this.labelCategoria.Text = "Elegir Categoría";
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(549, 156);
            this.comboBoxCategorias.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(329, 33);
            this.comboBoxCategorias.TabIndex = 1;
            // 
            // datePickerVencimiento
            // 
            this.datePickerVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerVencimiento.Location = new System.Drawing.Point(549, 427);
            this.datePickerVencimiento.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerVencimiento.Name = "datePickerVencimiento";
            this.datePickerVencimiento.Size = new System.Drawing.Size(329, 22);
            this.datePickerVencimiento.TabIndex = 6;
            // 
            // labelVencimiento
            // 
            this.labelVencimiento.AutoSize = true;
            this.labelVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelVencimiento.Location = new System.Drawing.Point(211, 425);
            this.labelVencimiento.Name = "labelVencimiento";
            this.labelVencimiento.Size = new System.Drawing.Size(240, 29);
            this.labelVencimiento.TabIndex = 26;
            this.labelVencimiento.Text = "Ingresar Vencimiento";
            // 
            // labelNotas
            // 
            this.labelNotas.AutoSize = true;
            this.labelNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNotas.Location = new System.Drawing.Point(211, 474);
            this.labelNotas.Name = "labelNotas";
            this.labelNotas.Size = new System.Drawing.Size(170, 29);
            this.labelNotas.TabIndex = 27;
            this.labelNotas.Text = "Ingresar Notas";
            // 
            // inputNota
            // 
            this.inputNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNota.Location = new System.Drawing.Point(549, 470);
            this.inputNota.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNota.MaxLength = 250;
            this.inputNota.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNota.Multiline = true;
            this.inputNota.Name = "inputNota";
            this.inputNota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputNota.Size = new System.Drawing.Size(575, 189);
            this.inputNota.TabIndex = 7;
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(212, 710);
            this.labelErrores.MaximumSize = new System.Drawing.Size(296, 111);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(85, 17);
            this.labelErrores.TabIndex = 29;
            this.labelErrores.Text = "labelErrores";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.Titulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 123);
            this.panel1.TabIndex = 30;
            // 
            // CrearTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.inputNota);
            this.Controls.Add(this.labelNotas);
            this.Controls.Add(this.labelVencimiento);
            this.Controls.Add(this.datePickerVencimiento);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.ingresarCodigo);
            this.Controls.Add(this.inputCodigo);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.inputNumero);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.inputTipo);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.botonCrear);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CrearTarjeta";
            this.Size = new System.Drawing.Size(1336, 838);
            this.Load += new System.EventHandler(this.CrearTarjeta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.TextBox inputTipo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Button botonCrear;
        private System.Windows.Forms.Label ingresarCodigo;
        private System.Windows.Forms.TextBox inputCodigo;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox inputNumero;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.DateTimePicker datePickerVencimiento;
        private System.Windows.Forms.Label labelVencimiento;
        private System.Windows.Forms.Label labelNotas;
        private System.Windows.Forms.TextBox inputNota;
        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.Panel panel1;
    }
}
