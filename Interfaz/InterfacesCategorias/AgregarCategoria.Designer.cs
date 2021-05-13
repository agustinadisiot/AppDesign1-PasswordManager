
namespace Interfaz
{
    partial class AgregarCategoria
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
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.labelNombreCategoria = new System.Windows.Forms.Label();
            this.textNombreCategoria = new System.Windows.Forms.TextBox();
            this.labelCrearCategoria = new System.Windows.Forms.Label();
            this.labelErrores = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(432, 489);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(164, 42);
            this.botonCancelar.TabIndex = 14;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(679, 489);
            this.botonAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(164, 42);
            this.botonAceptar.TabIndex = 13;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // labelNombreCategoria
            // 
            this.labelNombreCategoria.AutoSize = true;
            this.labelNombreCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreCategoria.Location = new System.Drawing.Point(412, 372);
            this.labelNombreCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombreCategoria.Name = "labelNombreCategoria";
            this.labelNombreCategoria.Size = new System.Drawing.Size(81, 25);
            this.labelNombreCategoria.TabIndex = 12;
            this.labelNombreCategoria.Text = "Nombre";
            // 
            // textNombreCategoria
            // 
            this.textNombreCategoria.Location = new System.Drawing.Point(569, 374);
            this.textNombreCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textNombreCategoria.Name = "textNombreCategoria";
            this.textNombreCategoria.Size = new System.Drawing.Size(223, 22);
            this.textNombreCategoria.TabIndex = 11;
            // 
            // labelCrearCategoria
            // 
            this.labelCrearCategoria.AutoSize = true;
            this.labelCrearCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelCrearCategoria.ForeColor = System.Drawing.Color.White;
            this.labelCrearCategoria.Location = new System.Drawing.Point(519, 39);
            this.labelCrearCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCrearCategoria.Name = "labelCrearCategoria";
            this.labelCrearCategoria.Size = new System.Drawing.Size(283, 42);
            this.labelCrearCategoria.TabIndex = 10;
            this.labelCrearCategoria.Text = "Crear Categoría";
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(896, 502);
            this.labelErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrores.MaximumSize = new System.Drawing.Size(296, 111);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(88, 17);
            this.labelErrores.TabIndex = 15;
            this.labelErrores.Text = "MostrarError";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelCrearCategoria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 123);
            this.panel1.TabIndex = 16;
            // 
            // AgregarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.labelNombreCategoria);
            this.Controls.Add(this.textNombreCategoria);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AgregarCategoria";
            this.Size = new System.Drawing.Size(1336, 838);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Label labelNombreCategoria;
        private System.Windows.Forms.TextBox textNombreCategoria;
        private System.Windows.Forms.Label labelCrearCategoria;
        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.Panel panel1;
    }
}
