﻿
namespace Interfaz
{
    partial class CompartirClave
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelSitio = new System.Windows.Forms.Label();
            this.inputSitio = new System.Windows.Forms.TextBox();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCompartir = new System.Windows.Forms.ComboBox();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.Location = new System.Drawing.Point(3, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(305, 36);
            this.labelTitulo.TabIndex = 18;
            this.labelTitulo.Text = "Compartir Contraseña";
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonCancelar.Location = new System.Drawing.Point(117, 314);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(144, 37);
            this.botonCancelar.TabIndex = 24;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelUsuario.Location = new System.Drawing.Point(4, 257);
            this.labelUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(74, 24);
            this.labelUsuario.TabIndex = 23;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelSitio
            // 
            this.labelSitio.AutoSize = true;
            this.labelSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelSitio.Location = new System.Drawing.Point(4, 179);
            this.labelSitio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSitio.Name = "labelSitio";
            this.labelSitio.Size = new System.Drawing.Size(45, 24);
            this.labelSitio.TabIndex = 21;
            this.labelSitio.Text = "Sitio";
            // 
            // inputSitio
            // 
            this.inputSitio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputSitio.Location = new System.Drawing.Point(182, 176);
            this.inputSitio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputSitio.MaxLength = 25;
            this.inputSitio.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputSitio.Name = "inputSitio";
            this.inputSitio.ReadOnly = true;
            this.inputSitio.Size = new System.Drawing.Size(248, 29);
            this.inputSitio.TabIndex = 20;
            // 
            // inputUsuario
            // 
            this.inputUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputUsuario.Location = new System.Drawing.Point(182, 254);
            this.inputUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputUsuario.MaxLength = 25;
            this.inputUsuario.MinimumSize = new System.Drawing.Size(4, 5);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.ReadOnly = true;
            this.inputUsuario.Size = new System.Drawing.Size(248, 29);
            this.inputUsuario.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(4, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 24);
            this.label1.TabIndex = 25;
            this.label1.Text = "Compartir con";
            // 
            // comboCompartir
            // 
            this.comboCompartir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompartir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboCompartir.FormattingEnabled = true;
            this.comboCompartir.Location = new System.Drawing.Point(182, 103);
            this.comboCompartir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboCompartir.Name = "comboCompartir";
            this.comboCompartir.Size = new System.Drawing.Size(248, 32);
            this.comboCompartir.TabIndex = 26;
            // 
            // botonAceptar
            // 
            this.botonAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botonAceptar.Location = new System.Drawing.Point(284, 314);
            this.botonAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(144, 37);
            this.botonAceptar.TabIndex = 27;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            // 
            // CompartirClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.comboCompartir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.labelSitio);
            this.Controls.Add(this.inputSitio);
            this.Controls.Add(this.labelTitulo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CompartirClave";
            this.Size = new System.Drawing.Size(1343, 852);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelSitio;
        private System.Windows.Forms.TextBox inputSitio;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCompartir;
        private System.Windows.Forms.Button botonAceptar;
    }
}
