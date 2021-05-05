
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelDrawer
            // 
            this.panelDrawer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDrawer.Location = new System.Drawing.Point(0, 0);
            this.panelDrawer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDrawer.Name = "panelDrawer";
            this.panelDrawer.Size = new System.Drawing.Size(252, 838);
            this.panelDrawer.TabIndex = 0;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(252, 0);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1433, 838);
            this.panelPrincipal.TabIndex = 1;
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelDrawer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VentanaPrincipal";
            this.Text = "Ventana Principal";
            this.Load += new System.EventHandler(this.VentanaPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDrawer;
        private System.Windows.Forms.Panel panelPrincipal;
    }
}

