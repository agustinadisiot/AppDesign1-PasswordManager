
namespace Interfaz.InterfacesTarjetas
{
    partial class VerTarjeta
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
            this.labelNotas = new System.Windows.Forms.Label();
            this.labelVencimiento = new System.Windows.Forms.Label();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.ingresarCodigo = new System.Windows.Forms.Label();
            this.labelNumero = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.Titulo = new System.Windows.Forms.Label();
            this.labelMostrarCategoria = new System.Windows.Forms.Label();
            this.labelMostrarNombre = new System.Windows.Forms.Label();
            this.labelMostrarTipo = new System.Windows.Forms.Label();
            this.labelMostrarNumero = new System.Windows.Forms.Label();
            this.labelMostrarCodigo = new System.Windows.Forms.Label();
            this.labelMostrarVencimiento = new System.Windows.Forms.Label();
            this.labelMostrarNotas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(163, 606);
            this.labelErrores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(62, 13);
            this.labelErrores.TabIndex = 65;
            this.labelErrores.Text = "labelErrores";
            // 
            // labelNotas
            // 
            this.labelNotas.AutoSize = true;
            this.labelNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNotas.Location = new System.Drawing.Point(222, 416);
            this.labelNotas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNotas.Name = "labelNotas";
            this.labelNotas.Size = new System.Drawing.Size(58, 24);
            this.labelNotas.TabIndex = 63;
            this.labelNotas.Text = "Notas";
            // 
            // labelVencimiento
            // 
            this.labelVencimiento.AutoSize = true;
            this.labelVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelVencimiento.Location = new System.Drawing.Point(222, 373);
            this.labelVencimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVencimiento.Name = "labelVencimiento";
            this.labelVencimiento.Size = new System.Drawing.Size(116, 24);
            this.labelVencimiento.TabIndex = 62;
            this.labelVencimiento.Text = "Vencimiento";
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(476, 155);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(0, 28);
            this.comboBoxCategorias.TabIndex = 60;
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelCategoria.Location = new System.Drawing.Point(222, 155);
            this.labelCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(90, 24);
            this.labelCategoria.TabIndex = 59;
            this.labelCategoria.Text = "Categoria";
            // 
            // ingresarCodigo
            // 
            this.ingresarCodigo.AutoSize = true;
            this.ingresarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ingresarCodigo.Location = new System.Drawing.Point(222, 330);
            this.ingresarCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ingresarCodigo.Name = "ingresarCodigo";
            this.ingresarCodigo.Size = new System.Drawing.Size(71, 24);
            this.ingresarCodigo.TabIndex = 58;
            this.ingresarCodigo.Text = "Codigo";
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNumero.Location = new System.Drawing.Point(222, 287);
            this.labelNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(79, 24);
            this.labelNumero.TabIndex = 56;
            this.labelNumero.Text = "Numero";
            // 
            // botonVolver
            // 
            this.botonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonVolver.Location = new System.Drawing.Point(764, 591);
            this.botonVolver.Margin = new System.Windows.Forms.Padding(2);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(144, 37);
            this.botonVolver.TabIndex = 54;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTipo.Location = new System.Drawing.Point(222, 244);
            this.labelTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(48, 24);
            this.labelTipo.TabIndex = 53;
            this.labelTipo.Text = "Tipo";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNombre.Location = new System.Drawing.Point(222, 201);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(79, 24);
            this.labelNombre.TabIndex = 51;
            this.labelNombre.Text = "Nombre";
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(307, 49);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(159, 33);
            this.Titulo.TabIndex = 48;
            this.Titulo.Text = "Ver Tarjeta";
            // 
            // labelMostrarCategoria
            // 
            this.labelMostrarCategoria.AutoSize = true;
            this.labelMostrarCategoria.BackColor = System.Drawing.Color.White;
            this.labelMostrarCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMostrarCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarCategoria.Location = new System.Drawing.Point(476, 154);
            this.labelMostrarCategoria.MaximumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarCategoria.MinimumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarCategoria.Name = "labelMostrarCategoria";
            this.labelMostrarCategoria.Size = new System.Drawing.Size(248, 29);
            this.labelMostrarCategoria.TabIndex = 66;
            // 
            // labelMostrarNombre
            // 
            this.labelMostrarNombre.AutoSize = true;
            this.labelMostrarNombre.BackColor = System.Drawing.Color.White;
            this.labelMostrarNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMostrarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarNombre.Location = new System.Drawing.Point(476, 201);
            this.labelMostrarNombre.MaximumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarNombre.MinimumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarNombre.Name = "labelMostrarNombre";
            this.labelMostrarNombre.Size = new System.Drawing.Size(248, 29);
            this.labelMostrarNombre.TabIndex = 67;
            // 
            // labelMostrarTipo
            // 
            this.labelMostrarTipo.AutoSize = true;
            this.labelMostrarTipo.BackColor = System.Drawing.Color.White;
            this.labelMostrarTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMostrarTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarTipo.Location = new System.Drawing.Point(476, 244);
            this.labelMostrarTipo.MaximumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarTipo.MinimumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarTipo.Name = "labelMostrarTipo";
            this.labelMostrarTipo.Size = new System.Drawing.Size(248, 29);
            this.labelMostrarTipo.TabIndex = 68;
            // 
            // labelMostrarNumero
            // 
            this.labelMostrarNumero.AutoSize = true;
            this.labelMostrarNumero.BackColor = System.Drawing.Color.White;
            this.labelMostrarNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMostrarNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarNumero.Location = new System.Drawing.Point(476, 287);
            this.labelMostrarNumero.MaximumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarNumero.MinimumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarNumero.Name = "labelMostrarNumero";
            this.labelMostrarNumero.Size = new System.Drawing.Size(248, 29);
            this.labelMostrarNumero.TabIndex = 69;
            // 
            // labelMostrarCodigo
            // 
            this.labelMostrarCodigo.AutoSize = true;
            this.labelMostrarCodigo.BackColor = System.Drawing.Color.White;
            this.labelMostrarCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMostrarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarCodigo.Location = new System.Drawing.Point(476, 330);
            this.labelMostrarCodigo.MaximumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarCodigo.MinimumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarCodigo.Name = "labelMostrarCodigo";
            this.labelMostrarCodigo.Size = new System.Drawing.Size(248, 29);
            this.labelMostrarCodigo.TabIndex = 70;
            // 
            // labelMostrarVencimiento
            // 
            this.labelMostrarVencimiento.AutoSize = true;
            this.labelMostrarVencimiento.BackColor = System.Drawing.Color.White;
            this.labelMostrarVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMostrarVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarVencimiento.Location = new System.Drawing.Point(476, 373);
            this.labelMostrarVencimiento.MaximumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarVencimiento.MinimumSize = new System.Drawing.Size(248, 29);
            this.labelMostrarVencimiento.Name = "labelMostrarVencimiento";
            this.labelMostrarVencimiento.Size = new System.Drawing.Size(248, 29);
            this.labelMostrarVencimiento.TabIndex = 71;
            // 
            // labelMostrarNotas
            // 
            this.labelMostrarNotas.AutoSize = true;
            this.labelMostrarNotas.BackColor = System.Drawing.Color.White;
            this.labelMostrarNotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMostrarNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarNotas.Location = new System.Drawing.Point(476, 416);
            this.labelMostrarNotas.MaximumSize = new System.Drawing.Size(432, 154);
            this.labelMostrarNotas.MinimumSize = new System.Drawing.Size(432, 154);
            this.labelMostrarNotas.Name = "labelMostrarNotas";
            this.labelMostrarNotas.Size = new System.Drawing.Size(432, 154);
            this.labelMostrarNotas.TabIndex = 72;
            // 
            // VerTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelMostrarNotas);
            this.Controls.Add(this.labelMostrarVencimiento);
            this.Controls.Add(this.labelMostrarCodigo);
            this.Controls.Add(this.labelMostrarNumero);
            this.Controls.Add(this.labelMostrarTipo);
            this.Controls.Add(this.labelMostrarNombre);
            this.Controls.Add(this.labelMostrarCategoria);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.labelNotas);
            this.Controls.Add(this.labelVencimiento);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.ingresarCodigo);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.Titulo);
            this.Name = "VerTarjeta";
            this.Size = new System.Drawing.Size(1071, 677);
            this.Load += new System.EventHandler(this.VerTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.Label labelNotas;
        private System.Windows.Forms.Label labelVencimiento;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label ingresarCodigo;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label labelMostrarCategoria;
        private System.Windows.Forms.Label labelMostrarNombre;
        private System.Windows.Forms.Label labelMostrarTipo;
        private System.Windows.Forms.Label labelMostrarNumero;
        private System.Windows.Forms.Label labelMostrarCodigo;
        private System.Windows.Forms.Label labelMostrarVencimiento;
        private System.Windows.Forms.Label labelMostrarNotas;
    }
}
