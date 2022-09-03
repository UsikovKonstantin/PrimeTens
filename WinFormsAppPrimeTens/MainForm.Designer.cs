namespace WinFormsAppPrimeTens
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Tx_Input = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_Method_Erat = new System.Windows.Forms.CheckBox();
            this.ChB_Method_Root = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Bt_Check = new System.Windows.Forms.Button();
            this.Bt_Start = new System.Windows.Forms.Button();
            this.Bt_End = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RTx_Output = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.Tx_Input, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(788, 84);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // Tx_Input
            // 
            this.Tx_Input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Tx_Input.Location = new System.Drawing.Point(3, 16);
            this.Tx_Input.Name = "Tx_Input";
            this.Tx_Input.Size = new System.Drawing.Size(782, 23);
            this.Tx_Input.TabIndex = 0;
            this.Tx_Input.TextChanged += new System.EventHandler(this.Tx_Input_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 106);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Опции";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ChB_Method_Erat, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChB_Method_Root, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(788, 84);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ChB_Method_Erat
            // 
            this.ChB_Method_Erat.AutoSize = true;
            this.ChB_Method_Erat.Checked = true;
            this.ChB_Method_Erat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChB_Method_Erat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Method_Erat.Location = new System.Drawing.Point(3, 3);
            this.ChB_Method_Erat.Name = "ChB_Method_Erat";
            this.ChB_Method_Erat.Size = new System.Drawing.Size(388, 78);
            this.ChB_Method_Erat.TabIndex = 0;
            this.ChB_Method_Erat.Text = "Методом Эратосфена";
            this.ChB_Method_Erat.UseVisualStyleBackColor = true;
            this.ChB_Method_Erat.CheckedChanged += new System.EventHandler(this.ChB_Method_Erat_CheckedChanged);
            // 
            // ChB_Method_Root
            // 
            this.ChB_Method_Root.AutoSize = true;
            this.ChB_Method_Root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Method_Root.Location = new System.Drawing.Point(397, 3);
            this.ChB_Method_Root.Name = "ChB_Method_Root";
            this.ChB_Method_Root.Size = new System.Drawing.Size(388, 78);
            this.ChB_Method_Root.TabIndex = 1;
            this.ChB_Method_Root.Text = "Методом корней";
            this.ChB_Method_Root.UseVisualStyleBackColor = true;
            this.ChB_Method_Root.CheckedChanged += new System.EventHandler(this.ChB_Method_Root_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 106);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Управление";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.Bt_Check, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Bt_Start, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Bt_End, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(788, 84);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // Bt_Check
            // 
            this.Bt_Check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Check.Location = new System.Drawing.Point(3, 3);
            this.Bt_Check.Name = "Bt_Check";
            this.Bt_Check.Size = new System.Drawing.Size(256, 78);
            this.Bt_Check.TabIndex = 0;
            this.Bt_Check.Text = "Проверить";
            this.Bt_Check.UseVisualStyleBackColor = true;
            this.Bt_Check.Click += new System.EventHandler(this.Bt_Check_Click);
            // 
            // Bt_Start
            // 
            this.Bt_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Start.Enabled = false;
            this.Bt_Start.Location = new System.Drawing.Point(265, 3);
            this.Bt_Start.Name = "Bt_Start";
            this.Bt_Start.Size = new System.Drawing.Size(256, 78);
            this.Bt_Start.TabIndex = 1;
            this.Bt_Start.Text = "Начать";
            this.Bt_Start.UseVisualStyleBackColor = true;
            this.Bt_Start.Click += new System.EventHandler(this.Bt_Start_Click);
            // 
            // Bt_End
            // 
            this.Bt_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_End.Enabled = false;
            this.Bt_End.Location = new System.Drawing.Point(527, 3);
            this.Bt_End.Name = "Bt_End";
            this.Bt_End.Size = new System.Drawing.Size(258, 78);
            this.Bt_End.TabIndex = 2;
            this.Bt_End.Text = "Прервать";
            this.Bt_End.UseVisualStyleBackColor = true;
            this.Bt_End.Click += new System.EventHandler(this.Bt_End_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RTx_Output);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 339);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(794, 108);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вывод";
            // 
            // RTx_Output
            // 
            this.RTx_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTx_Output.Location = new System.Drawing.Point(3, 19);
            this.RTx_Output.Name = "RTx_Output";
            this.RTx_Output.ReadOnly = true;
            this.RTx_Output.Size = new System.Drawing.Size(788, 86);
            this.RTx_Output.TabIndex = 0;
            this.RTx_Output.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "PrimeTens";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox Tx_Input;
        private CheckBox ChB_Method_Erat;
        private CheckBox ChB_Method_Root;
        private Button Bt_Check;
        private Button Bt_Start;
        private Button Bt_End;
        private RichTextBox RTx_Output;
    }
}