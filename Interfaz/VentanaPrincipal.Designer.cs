
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
            this.panelDrawer = new System.Windows.Forms.Panel();
            this.botonDataBranches = new System.Windows.Forms.Button();
            this.botonReeeporteFortaleza = new System.Windows.Forms.Button();
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
            this.panelDrawer.Controls.Add(this.botonDataBranches);
            this.panelDrawer.Controls.Add(this.botonReeeporteFortaleza);
            this.panelDrawer.Controls.Add(this.botonListaTarjetas);
            this.panelDrawer.Controls.Add(this.botonClavesQueMeComparten);
            this.panelDrawer.Controls.Add(this.botonClavesQueComparto);
            this.panelDrawer.Controls.Add(this.botonListaClaves);
            this.panelDrawer.Controls.Add(this.botonListaCategorias);
            this.panelDrawer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDrawer.Location = new System.Drawing.Point(0, 0);
            this.panelDrawer.Margin = new System.Windows.Forms.Padding(2);
            this.panelDrawer.Name = "panelDrawer";
            this.panelDrawer.Size = new System.Drawing.Size(189, 681);
            this.panelDrawer.TabIndex = 0;
            // 
            // botonDataBranches
            // 
            this.botonDataBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonDataBranches.Location = new System.Drawing.Point(12, 438);
            this.botonDataBranches.Name = "botonDataBranches";
            this.botonDataBranches.Size = new System.Drawing.Size(172, 63);
            this.botonDataBranches.TabIndex = 6;
            this.botonDataBranches.Text = "Data Branches";
            this.botonDataBranches.UseVisualStyleBackColor = true;
            // 
            // botonReeeporteFortaleza
            // 
            this.botonReeeporteFortaleza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonReeeporteFortaleza.Location = new System.Drawing.Point(12, 369);
            this.botonReeeporteFortaleza.Name = "botonReeeporteFortaleza";
            this.botonReeeporteFortaleza.Size = new System.Drawing.Size(172, 63);
            this.botonReeeporteFortaleza.TabIndex = 5;
            this.botonReeeporteFortaleza.Text = "Reporte Fortaleza";
            this.botonReeeporteFortaleza.UseVisualStyleBackColor = true;
            // 
            // botonListaTarjetas
            // 
            this.botonListaTarjetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonListaTarjetas.Location = new System.Drawing.Point(14, 300);
            this.botonListaTarjetas.Name = "botonListaTarjetas";
            this.botonListaTarjetas.Size = new System.Drawing.Size(172, 63);
            this.botonListaTarjetas.TabIndex = 4;
            this.botonListaTarjetas.Text = "Listado Tarjetas";
            this.botonListaTarjetas.UseVisualStyleBackColor = true;
            this.botonListaTarjetas.Click += new System.EventHandler(this.botonListaTarjetas_Click);
            // 
            // botonClavesQueMeComparten
            // 
            this.botonClavesQueMeComparten.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClavesQueMeComparten.Location = new System.Drawing.Point(12, 231);
            this.botonClavesQueMeComparten.Name = "botonClavesQueMeComparten";
            this.botonClavesQueMeComparten.Size = new System.Drawing.Size(172, 63);
            this.botonClavesQueMeComparten.TabIndex = 3;
            this.botonClavesQueMeComparten.Text = "Contraseña Compartidas Conmigo";
            this.botonClavesQueMeComparten.UseVisualStyleBackColor = true;
            // 
            // botonClavesQueComparto
            // 
            this.botonClavesQueComparto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonClavesQueComparto.Location = new System.Drawing.Point(12, 162);
            this.botonClavesQueComparto.Name = "botonClavesQueComparto";
            this.botonClavesQueComparto.Size = new System.Drawing.Size(172, 63);
            this.botonClavesQueComparto.TabIndex = 2;
            this.botonClavesQueComparto.Text = "Contraseñas Que Comparto";
            this.botonClavesQueComparto.UseVisualStyleBackColor = true;
            // 
            // botonListaClaves
            // 
            this.botonListaClaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonListaClaves.Location = new System.Drawing.Point(12, 93);
            this.botonListaClaves.Name = "botonListaClaves";
            this.botonListaClaves.Size = new System.Drawing.Size(172, 63);
            this.botonListaClaves.TabIndex = 1;
            this.botonListaClaves.Text = "Listado Contraseñas";
            this.botonListaClaves.UseVisualStyleBackColor = true;
            this.botonListaClaves.Click += new System.EventHandler(this.botonListaClaves_Click);
            // 
            // botonListaCategorias
            // 
            this.botonListaCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonListaCategorias.Location = new System.Drawing.Point(12, 24);
            this.botonListaCategorias.Name = "botonListaCategorias";
            this.botonListaCategorias.Size = new System.Drawing.Size(172, 63);
            this.botonListaCategorias.TabIndex = 0;
            this.botonListaCategorias.Text = "Listado Categorias";
            this.botonListaCategorias.UseVisualStyleBackColor = true;
            this.botonListaCategorias.Click += new System.EventHandler(this.botonListaCategorias_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(189, 0);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1014, 681);
            this.panelPrincipal.TabIndex = 1;
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 681);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelDrawer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VentanaPrincipal";
            this.Text = "Ventana Principal";
            this.Load += new System.EventHandler(this.VentanaPrincipal_Load);
            this.panelDrawer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDrawer;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Button botonListaCategorias;
        private System.Windows.Forms.Button botonDataBranches;
        private System.Windows.Forms.Button botonReeeporteFortaleza;
        private System.Windows.Forms.Button botonListaTarjetas;
        private System.Windows.Forms.Button botonClavesQueMeComparten;
        private System.Windows.Forms.Button botonClavesQueComparto;
        private System.Windows.Forms.Button botonListaClaves;
    }
}

