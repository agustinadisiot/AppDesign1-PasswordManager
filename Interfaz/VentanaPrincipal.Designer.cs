
namespace Interfaz
{
    partial class VentanaPrincipal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.panelDrawer = new System.Windows.Forms.Panel();
            this.labelUsuarioActual = new System.Windows.Forms.Label();
            this.botonCerrarSesion = new System.Windows.Forms.Button();
            this.botonDataBreaches = new System.Windows.Forms.Button();
            this.botonReporteFortaleza = new System.Windows.Forms.Button();
            this.botonListaTarjetas = new System.Windows.Forms.Button();
            this.botonClavesQueMeComparten = new System.Windows.Forms.Button();
            this.botonClavesQueComparto = new System.Windows.Forms.Button();
            this.botonListaClaves = new System.Windows.Forms.Button();
            this.botonListaCategorias = new System.Windows.Forms.Button();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelDrawer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDrawer
            // 
            this.panelDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelDrawer.Controls.Add(this.labelUsuarioActual);
            this.panelDrawer.Controls.Add(this.botonCerrarSesion);
            this.panelDrawer.Controls.Add(this.botonDataBreaches);
            this.panelDrawer.Controls.Add(this.botonReporteFortaleza);
            this.panelDrawer.Controls.Add(this.botonListaTarjetas);
            this.panelDrawer.Controls.Add(this.botonClavesQueMeComparten);
            this.panelDrawer.Controls.Add(this.botonClavesQueComparto);
            this.panelDrawer.Controls.Add(this.botonListaClaves);
            this.panelDrawer.Controls.Add(this.botonListaCategorias);
            this.panelDrawer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDrawer.Location = new System.Drawing.Point(0, 0);
            this.panelDrawer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDrawer.Name = "panelDrawer";
            this.panelDrawer.Size = new System.Drawing.Size(268, 838);
            this.panelDrawer.TabIndex = 0;
            // 
            // labelUsuarioActual
            // 
            this.labelUsuarioActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUsuarioActual.AutoSize = true;
            this.labelUsuarioActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuarioActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(189)))), ((int)(((byte)(223)))));
            this.labelUsuarioActual.Location = new System.Drawing.Point(8, 11);
            this.labelUsuarioActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsuarioActual.MaximumSize = new System.Drawing.Size(253, 111);
            this.labelUsuarioActual.MinimumSize = new System.Drawing.Size(253, 111);
            this.labelUsuarioActual.Name = "labelUsuarioActual";
            this.labelUsuarioActual.Size = new System.Drawing.Size(253, 111);
            this.labelUsuarioActual.TabIndex = 8;
            this.labelUsuarioActual.Text = "UsuarioActual";
            this.labelUsuarioActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botonCerrarSesion
            // 
            this.botonCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonCerrarSesion.Location = new System.Drawing.Point(0, 711);
            this.botonCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonCerrarSesion.Name = "botonCerrarSesion";
            this.botonCerrarSesion.Size = new System.Drawing.Size(268, 78);
            this.botonCerrarSesion.TabIndex = 7;
            this.botonCerrarSesion.TabStop = false;
            this.botonCerrarSesion.Text = "Cerrar Sesión";
            this.botonCerrarSesion.UseVisualStyleBackColor = true;
            this.botonCerrarSesion.Click += new System.EventHandler(this.botonCerrarSesion_Click);
            // 
            // botonDataBreaches
            // 
            this.botonDataBreaches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.botonDataBreaches.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.botonDataBreaches.FlatAppearance.BorderSize = 0;
            this.botonDataBreaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonDataBreaches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonDataBreaches.ForeColor = System.Drawing.Color.White;
            this.botonDataBreaches.Location = new System.Drawing.Point(0, 620);
            this.botonDataBreaches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonDataBreaches.Name = "botonDataBreaches";
            this.botonDataBreaches.Size = new System.Drawing.Size(268, 58);
            this.botonDataBreaches.TabIndex = 6;
            this.botonDataBreaches.TabStop = false;
            this.botonDataBreaches.Text = "Data Breaches";
            this.botonDataBreaches.UseVisualStyleBackColor = false;
            this.botonDataBreaches.Click += new System.EventHandler(this.botonDataBreaches_Click);
            // 
            // botonReporteFortaleza
            // 
            this.botonReporteFortaleza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.botonReporteFortaleza.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.botonReporteFortaleza.FlatAppearance.BorderSize = 0;
            this.botonReporteFortaleza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonReporteFortaleza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonReporteFortaleza.ForeColor = System.Drawing.Color.White;
            this.botonReporteFortaleza.Location = new System.Drawing.Point(0, 542);
            this.botonReporteFortaleza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonReporteFortaleza.Name = "botonReporteFortaleza";
            this.botonReporteFortaleza.Size = new System.Drawing.Size(268, 58);
            this.botonReporteFortaleza.TabIndex = 5;
            this.botonReporteFortaleza.TabStop = false;
            this.botonReporteFortaleza.Text = "Reporte Fortaleza";
            this.botonReporteFortaleza.UseVisualStyleBackColor = false;
            this.botonReporteFortaleza.Click += new System.EventHandler(this.botonReporteFortaleza_Click);
            // 
            // botonListaTarjetas
            // 
            this.botonListaTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.botonListaTarjetas.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.botonListaTarjetas.FlatAppearance.BorderSize = 0;
            this.botonListaTarjetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonListaTarjetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonListaTarjetas.ForeColor = System.Drawing.Color.White;
            this.botonListaTarjetas.Location = new System.Drawing.Point(0, 464);
            this.botonListaTarjetas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonListaTarjetas.Name = "botonListaTarjetas";
            this.botonListaTarjetas.Size = new System.Drawing.Size(268, 58);
            this.botonListaTarjetas.TabIndex = 4;
            this.botonListaTarjetas.TabStop = false;
            this.botonListaTarjetas.Text = "Listado Tarjetas";
            this.botonListaTarjetas.UseVisualStyleBackColor = false;
            this.botonListaTarjetas.Click += new System.EventHandler(this.botonListaTarjetas_Click);
            // 
            // botonClavesQueMeComparten
            // 
            this.botonClavesQueMeComparten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.botonClavesQueMeComparten.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.botonClavesQueMeComparten.FlatAppearance.BorderSize = 0;
            this.botonClavesQueMeComparten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonClavesQueMeComparten.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClavesQueMeComparten.ForeColor = System.Drawing.Color.White;
            this.botonClavesQueMeComparten.Location = new System.Drawing.Point(0, 386);
            this.botonClavesQueMeComparten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonClavesQueMeComparten.Name = "botonClavesQueMeComparten";
            this.botonClavesQueMeComparten.Size = new System.Drawing.Size(268, 59);
            this.botonClavesQueMeComparten.TabIndex = 3;
            this.botonClavesQueMeComparten.TabStop = false;
            this.botonClavesQueMeComparten.Text = "Contraseña Compartidas Conmigo";
            this.botonClavesQueMeComparten.UseVisualStyleBackColor = false;
            this.botonClavesQueMeComparten.Click += new System.EventHandler(this.botonClavesQueMeComparten_Click);
            // 
            // botonClavesQueComparto
            // 
            this.botonClavesQueComparto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.botonClavesQueComparto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.botonClavesQueComparto.FlatAppearance.BorderSize = 0;
            this.botonClavesQueComparto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonClavesQueComparto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClavesQueComparto.ForeColor = System.Drawing.Color.White;
            this.botonClavesQueComparto.Location = new System.Drawing.Point(0, 305);
            this.botonClavesQueComparto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonClavesQueComparto.Name = "botonClavesQueComparto";
            this.botonClavesQueComparto.Size = new System.Drawing.Size(268, 60);
            this.botonClavesQueComparto.TabIndex = 2;
            this.botonClavesQueComparto.TabStop = false;
            this.botonClavesQueComparto.Text = "Contraseñas Que Comparto";
            this.botonClavesQueComparto.UseVisualStyleBackColor = false;
            this.botonClavesQueComparto.Click += new System.EventHandler(this.botonClavesQueComparto_Click);
            // 
            // botonListaClaves
            // 
            this.botonListaClaves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.botonListaClaves.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.botonListaClaves.FlatAppearance.BorderSize = 0;
            this.botonListaClaves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonListaClaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonListaClaves.ForeColor = System.Drawing.Color.White;
            this.botonListaClaves.Location = new System.Drawing.Point(0, 220);
            this.botonListaClaves.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonListaClaves.Name = "botonListaClaves";
            this.botonListaClaves.Size = new System.Drawing.Size(268, 60);
            this.botonListaClaves.TabIndex = 1;
            this.botonListaClaves.TabStop = false;
            this.botonListaClaves.Text = "Listado Contraseñas";
            this.botonListaClaves.UseVisualStyleBackColor = false;
            this.botonListaClaves.Click += new System.EventHandler(this.botonListaClaves_Click);
            // 
            // botonListaCategorias
            // 
            this.botonListaCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.botonListaCategorias.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.botonListaCategorias.FlatAppearance.BorderSize = 0;
            this.botonListaCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonListaCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonListaCategorias.ForeColor = System.Drawing.Color.White;
            this.botonListaCategorias.Location = new System.Drawing.Point(0, 138);
            this.botonListaCategorias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonListaCategorias.Name = "botonListaCategorias";
            this.botonListaCategorias.Size = new System.Drawing.Size(268, 60);
            this.botonListaCategorias.TabIndex = 0;
            this.botonListaCategorias.TabStop = false;
            this.botonListaCategorias.Text = "Listado Categorías";
            this.botonListaCategorias.UseVisualStyleBackColor = false;
            this.botonListaCategorias.Click += new System.EventHandler(this.botonListaCategorias_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(268, 0);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1336, 838);
            this.panelPrincipal.TabIndex = 1;
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1604, 838);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelDrawer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaPrincipal";
            this.Text = "Ventana Principal";
            this.Load += new System.EventHandler(this.VentanaPrincipal_Load);
            this.panelDrawer.ResumeLayout(false);
            this.panelDrawer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDrawer;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Button botonListaCategorias;
        private System.Windows.Forms.Button botonDataBreaches;
        private System.Windows.Forms.Button botonReporteFortaleza;
        private System.Windows.Forms.Button botonListaTarjetas;
        private System.Windows.Forms.Button botonClavesQueMeComparten;
        private System.Windows.Forms.Button botonClavesQueComparto;
        private System.Windows.Forms.Button botonListaClaves;
        private System.Windows.Forms.Button botonCerrarSesion;
        private System.Windows.Forms.Label labelUsuarioActual;
    }
}

