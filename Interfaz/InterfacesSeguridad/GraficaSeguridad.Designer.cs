
namespace Interfaz
{
    partial class GraficaSeguridad
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.grafica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.botonVolver = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grafica
            // 
            chartArea2.Name = "ChartArea1";
            this.grafica.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.grafica.Legends.Add(legend2);
            this.grafica.Location = new System.Drawing.Point(64, 106);
            this.grafica.Name = "grafica";
            this.grafica.Size = new System.Drawing.Size(873, 469);
            this.grafica.TabIndex = 0;
            this.grafica.Text = "chart1";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(374, 32);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(255, 36);
            this.labelTitulo.TabIndex = 29;
            this.labelTitulo.Text = "Grafica Seguridad";
            // 
            // botonVolver
            // 
            this.botonVolver.Location = new System.Drawing.Point(814, 581);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(123, 34);
            this.botonVolver.TabIndex = 30;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 100);
            this.panel1.TabIndex = 31;
            // 
            // GraficaSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.grafica);
            this.Name = "GraficaSeguridad";
            this.Size = new System.Drawing.Size(1002, 681);
            this.Load += new System.EventHandler(this.GraficaSeguridad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafica;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button botonVolver;
        private System.Windows.Forms.Panel panel1;
    }
}
