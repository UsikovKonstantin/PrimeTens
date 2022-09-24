namespace WinFormsAppPrimeTens
{
    partial class Divisor_Output
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
            this.RTx_Div_Out = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RTx_Div_Out
            // 
            this.RTx_Div_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTx_Div_Out.Location = new System.Drawing.Point(0, 0);
            this.RTx_Div_Out.Name = "RTx_Div_Out";
            this.RTx_Div_Out.Size = new System.Drawing.Size(800, 450);
            this.RTx_Div_Out.TabIndex = 0;
            this.RTx_Div_Out.Text = "";
            // 
            // Divisor_Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RTx_Div_Out);
            this.Name = "Divisor_Output";
            this.Text = "Divisors";
            this.Load += new System.EventHandler(this.Divisor_Output_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox RTx_Div_Out;
    }
}