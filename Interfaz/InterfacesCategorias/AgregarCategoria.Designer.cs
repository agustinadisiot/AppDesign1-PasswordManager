
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
            this.botonCancelar.Location = new System.Drawing.Point(324, 397);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(123, 34);
            this.botonCancelar.TabIndex = 14;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Location = new System.Drawing.Point(509, 397);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(123, 34);
            this.botonAceptar.TabIndex = 13;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // labelNombreCategoria
            // 
            this.labelNombreCategoria.AutoSize = true;
            this.labelNombreCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreCategoria.Location = new System.Drawing.Point(309, 302);
            this.labelNombreCategoria.Name = "labelNombreCategoria";
            this.labelNombreCategoria.Size = new System.Drawing.Size(65, 20);
            this.labelNombreCategoria.TabIndex = 12;
            this.labelNombreCategoria.Text = "Nombre";
            // 
            // textNombreCategoria
            // 
            this.textNombreCategoria.Location = new System.Drawing.Point(427, 304);
            this.textNombreCategoria.Name = "textNombreCategoria";
            this.textNombreCategoria.Size = new System.Drawing.Size(168, 20);
            this.textNombreCategoria.TabIndex = 11;
            // 
            // labelCrearCategoria
            // 
            this.labelCrearCategoria.AutoSize = true;
            this.labelCrearCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelCrearCategoria.ForeColor = System.Drawing.Color.White;
            this.labelCrearCategoria.Location = new System.Drawing.Point(389, 32);
            this.labelCrearCategoria.Name = "labelCrearCategoria";
            this.labelCrearCategoria.Size = new System.Drawing.Size(224, 36);
            this.labelCrearCategoria.TabIndex = 10;
            this.labelCrearCategoria.Text = "Crear Categoria";
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(672, 408);
            this.labelErrores.MaximumSize = new System.Drawing.Size(222, 90);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(64, 13);
            this.labelErrores.TabIndex = 15;
            this.labelErrores.Text = "MostrarError";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelCrearCategoria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 100);
            this.panel1.TabIndex = 16;
            // 
            // AgregarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.labelNombreCategoria);
            this.Controls.Add(this.textNombreCategoria);
            this.Name = "AgregarCategoria";
            this.Size = new System.Drawing.Size(1002, 681);
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
