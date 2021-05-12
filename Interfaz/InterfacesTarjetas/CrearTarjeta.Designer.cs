
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
            this.Titulo.Location = new System.Drawing.Point(408, 32);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(187, 36);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "Crear Tarjeta";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCancelar.Location = new System.Drawing.Point(700, 563);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(144, 37);
            this.botonCancelar.TabIndex = 9;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTipo.Location = new System.Drawing.Point(158, 216);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(121, 24);
            this.labelTipo.TabIndex = 17;
            this.labelTipo.Text = "Ingresar Tipo";
            // 
            // inputTipo
            // 
            this.inputTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputTipo.Location = new System.Drawing.Point(412, 213);
            this.inputTipo.Margin = new System.Windows.Forms.Padding(2);
            this.inputTipo.MaxLength = 25;
            this.inputTipo.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputTipo.Name = "inputTipo";
            this.inputTipo.Size = new System.Drawing.Size(248, 29);
            this.inputTipo.TabIndex = 3;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNombre.Location = new System.Drawing.Point(158, 173);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(152, 24);
            this.labelNombre.TabIndex = 15;
            this.labelNombre.Text = "Ingresar Nombre";
            // 
            // inputNombre
            // 
            this.inputNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNombre.Location = new System.Drawing.Point(412, 170);
            this.inputNombre.Margin = new System.Windows.Forms.Padding(2);
            this.inputNombre.MaxLength = 25;
            this.inputNombre.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(248, 29);
            this.inputNombre.TabIndex = 2;
            // 
            // botonCrear
            // 
            this.botonCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCrear.Location = new System.Drawing.Point(516, 563);
            this.botonCrear.Margin = new System.Windows.Forms.Padding(2);
            this.botonCrear.Name = "botonCrear";
            this.botonCrear.Size = new System.Drawing.Size(144, 37);
            this.botonCrear.TabIndex = 8;
            this.botonCrear.Text = "Crear Tarjeta";
            this.botonCrear.UseVisualStyleBackColor = true;
            this.botonCrear.Click += new System.EventHandler(this.botonCrear_Click);
            // 
            // ingresarCodigo
            // 
            this.ingresarCodigo.AutoSize = true;
            this.ingresarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ingresarCodigo.Location = new System.Drawing.Point(158, 302);
            this.ingresarCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ingresarCodigo.Name = "ingresarCodigo";
            this.ingresarCodigo.Size = new System.Drawing.Size(144, 24);
            this.ingresarCodigo.TabIndex = 22;
            this.ingresarCodigo.Text = "Ingresar Codigo";
            // 
            // inputCodigo
            // 
            this.inputCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputCodigo.Location = new System.Drawing.Point(412, 299);
            this.inputCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.inputCodigo.MaxLength = 25;
            this.inputCodigo.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputCodigo.Name = "inputCodigo";
            this.inputCodigo.Size = new System.Drawing.Size(248, 29);
            this.inputCodigo.TabIndex = 5;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNumero.Location = new System.Drawing.Point(158, 259);
            this.labelNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(152, 24);
            this.labelNumero.TabIndex = 20;
            this.labelNumero.Text = "Ingresar Numero";
            // 
            // inputNumero
            // 
            this.inputNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNumero.Location = new System.Drawing.Point(412, 256);
            this.inputNumero.Margin = new System.Windows.Forms.Padding(2);
            this.inputNumero.MaxLength = 25;
            this.inputNumero.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNumero.Name = "inputNumero";
            this.inputNumero.Size = new System.Drawing.Size(248, 29);
            this.inputNumero.TabIndex = 4;
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelCategoria.Location = new System.Drawing.Point(158, 127);
            this.labelCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(144, 24);
            this.labelCategoria.TabIndex = 23;
            this.labelCategoria.Text = "Elegir Categoria";
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(412, 127);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(248, 28);
            this.comboBoxCategorias.TabIndex = 1;
            // 
            // datePickerVencimiento
            // 
            this.datePickerVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerVencimiento.Location = new System.Drawing.Point(412, 347);
            this.datePickerVencimiento.Name = "datePickerVencimiento";
            this.datePickerVencimiento.Size = new System.Drawing.Size(248, 20);
            this.datePickerVencimiento.TabIndex = 6;
            // 
            // labelVencimiento
            // 
            this.labelVencimiento.AutoSize = true;
            this.labelVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelVencimiento.Location = new System.Drawing.Point(158, 345);
            this.labelVencimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVencimiento.Name = "labelVencimiento";
            this.labelVencimiento.Size = new System.Drawing.Size(189, 24);
            this.labelVencimiento.TabIndex = 26;
            this.labelVencimiento.Text = "Ingresar Vencimiento";
            // 
            // labelNotas
            // 
            this.labelNotas.AutoSize = true;
            this.labelNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNotas.Location = new System.Drawing.Point(158, 385);
            this.labelNotas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNotas.Name = "labelNotas";
            this.labelNotas.Size = new System.Drawing.Size(131, 24);
            this.labelNotas.TabIndex = 27;
            this.labelNotas.Text = "Ingresar Notas";
            // 
            // inputNota
            // 
            this.inputNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNota.Location = new System.Drawing.Point(412, 382);
            this.inputNota.Margin = new System.Windows.Forms.Padding(2);
            this.inputNota.MaxLength = 250;
            this.inputNota.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNota.Multiline = true;
            this.inputNota.Name = "inputNota";
            this.inputNota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputNota.Size = new System.Drawing.Size(432, 154);
            this.inputNota.TabIndex = 7;
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(159, 577);
            this.labelErrores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelErrores.MaximumSize = new System.Drawing.Size(222, 90);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(62, 13);
            this.labelErrores.TabIndex = 29;
            this.labelErrores.Text = "labelErrores";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.Titulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 100);
            this.panel1.TabIndex = 30;
            // 
            // CrearTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
            this.Name = "CrearTarjeta";
            this.Size = new System.Drawing.Size(1002, 681);
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
