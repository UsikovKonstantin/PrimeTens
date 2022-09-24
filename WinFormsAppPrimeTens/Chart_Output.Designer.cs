namespace WinFormsAppPrimeTens
{
    partial class Chart_Output
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
            this.Pl_Out = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // Pl_Out
            // 
            this.Pl_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pl_Out.Location = new System.Drawing.Point(0, 0);
            this.Pl_Out.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Pl_Out.Name = "Pl_Out";
            this.Pl_Out.Size = new System.Drawing.Size(800, 450);
            this.Pl_Out.TabIndex = 2;
            // 
            // Chart_Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pl_Out);
            this.Name = "Chart_Output";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Output_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot Pl_Out;
    }
}