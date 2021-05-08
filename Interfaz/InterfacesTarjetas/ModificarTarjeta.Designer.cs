﻿
namespace Interfaz
{
    partial class ModificarTarjeta
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
            this.inputNota = new System.Windows.Forms.TextBox();
            this.labelNotas = new System.Windows.Forms.Label();
            this.labelVencimiento = new System.Windows.Forms.Label();
            this.datePickerVencimiento = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.ingresarCodigo = new System.Windows.Forms.Label();
            this.inputCodigo = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.inputNumero = new System.Windows.Forms.TextBox();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.labelTipo = new System.Windows.Forms.Label();
            this.inputTipo = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.botonModificar = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.Location = new System.Drawing.Point(145, 607);
            this.labelErrores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(62, 13);
            this.labelErrores.TabIndex = 47;
            this.labelErrores.Text = "labelErrores";
            // 
            // inputNota
            // 
            this.inputNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNota.Location = new System.Drawing.Point(458, 411);
            this.inputNota.Margin = new System.Windows.Forms.Padding(2);
            this.inputNota.MaxLength = 25;
            this.inputNota.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNota.Multiline = true;
            this.inputNota.Name = "inputNota";
            this.inputNota.Size = new System.Drawing.Size(432, 154);
            this.inputNota.TabIndex = 46;
            // 
            // labelNotas
            // 
            this.labelNotas.AutoSize = true;
            this.labelNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNotas.Location = new System.Drawing.Point(204, 414);
            this.labelNotas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNotas.Name = "labelNotas";
            this.labelNotas.Size = new System.Drawing.Size(131, 24);
            this.labelNotas.TabIndex = 45;
            this.labelNotas.Text = "Ingresar Notas";
            // 
            // labelVencimiento
            // 
            this.labelVencimiento.AutoSize = true;
            this.labelVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelVencimiento.Location = new System.Drawing.Point(204, 374);
            this.labelVencimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVencimiento.Name = "labelVencimiento";
            this.labelVencimiento.Size = new System.Drawing.Size(189, 24);
            this.labelVencimiento.TabIndex = 44;
            this.labelVencimiento.Text = "Ingresar Vencimiento";
            // 
            // datePickerVencimiento
            // 
            this.datePickerVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerVencimiento.Location = new System.Drawing.Point(458, 376);
            this.datePickerVencimiento.Name = "datePickerVencimiento";
            this.datePickerVencimiento.Size = new System.Drawing.Size(248, 20);
            this.datePickerVencimiento.TabIndex = 43;
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(458, 156);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(248, 28);
            this.comboBoxCategorias.TabIndex = 42;
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelCategoria.Location = new System.Drawing.Point(204, 156);
            this.labelCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(144, 24);
            this.labelCategoria.TabIndex = 41;
            this.labelCategoria.Text = "Elegir Categoria";
            // 
            // ingresarCodigo
            // 
            this.ingresarCodigo.AutoSize = true;
            this.ingresarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ingresarCodigo.Location = new System.Drawing.Point(204, 331);
            this.ingresarCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ingresarCodigo.Name = "ingresarCodigo";
            this.ingresarCodigo.Size = new System.Drawing.Size(144, 24);
            this.ingresarCodigo.TabIndex = 40;
            this.ingresarCodigo.Text = "Ingresar Codigo";
            // 
            // inputCodigo
            // 
            this.inputCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputCodigo.Location = new System.Drawing.Point(458, 328);
            this.inputCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.inputCodigo.MaxLength = 25;
            this.inputCodigo.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputCodigo.Name = "inputCodigo";
            this.inputCodigo.Size = new System.Drawing.Size(248, 29);
            this.inputCodigo.TabIndex = 39;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNumero.Location = new System.Drawing.Point(204, 288);
            this.labelNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(152, 24);
            this.labelNumero.TabIndex = 38;
            this.labelNumero.Text = "Ingresar Numero";
            // 
            // inputNumero
            // 
            this.inputNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNumero.Location = new System.Drawing.Point(458, 285);
            this.inputNumero.Margin = new System.Windows.Forms.Padding(2);
            this.inputNumero.MaxLength = 25;
            this.inputNumero.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNumero.Name = "inputNumero";
            this.inputNumero.Size = new System.Drawing.Size(248, 29);
            this.inputNumero.TabIndex = 37;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCancelar.Location = new System.Drawing.Point(746, 592);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(144, 37);
            this.botonCancelar.TabIndex = 36;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTipo.Location = new System.Drawing.Point(204, 245);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(121, 24);
            this.labelTipo.TabIndex = 35;
            this.labelTipo.Text = "Ingresar Tipo";
            // 
            // inputTipo
            // 
            this.inputTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputTipo.Location = new System.Drawing.Point(458, 242);
            this.inputTipo.Margin = new System.Windows.Forms.Padding(2);
            this.inputTipo.MaxLength = 25;
            this.inputTipo.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputTipo.Name = "inputTipo";
            this.inputTipo.Size = new System.Drawing.Size(248, 29);
            this.inputTipo.TabIndex = 34;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNombre.Location = new System.Drawing.Point(204, 202);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(152, 24);
            this.labelNombre.TabIndex = 33;
            this.labelNombre.Text = "Ingresar Nombre";
            // 
            // inputNombre
            // 
            this.inputNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNombre.Location = new System.Drawing.Point(458, 199);
            this.inputNombre.Margin = new System.Windows.Forms.Padding(2);
            this.inputNombre.MaxLength = 25;
            this.inputNombre.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(248, 29);
            this.inputNombre.TabIndex = 32;
            // 
            // botonModificar
            // 
            this.botonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonModificar.Location = new System.Drawing.Point(562, 592);
            this.botonModificar.Margin = new System.Windows.Forms.Padding(2);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(144, 37);
            this.botonModificar.TabIndex = 31;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(289, 50);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(233, 33);
            this.Titulo.TabIndex = 30;
            this.Titulo.Text = "Modificar Tarjeta";
            // 
            // ModificarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Controls.Add(this.botonModificar);
            this.Controls.Add(this.Titulo);
            this.Name = "ModificarTarjeta";
            this.Size = new System.Drawing.Size(1075, 681);
            this.Load += new System.EventHandler(this.ModificarTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.TextBox inputNota;
        private System.Windows.Forms.Label labelNotas;
        private System.Windows.Forms.Label labelVencimiento;
        private System.Windows.Forms.DateTimePicker datePickerVencimiento;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label ingresarCodigo;
        private System.Windows.Forms.TextBox inputCodigo;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox inputNumero;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.TextBox inputTipo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.Label Titulo;
    }
}