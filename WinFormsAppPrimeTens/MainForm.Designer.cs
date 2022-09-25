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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.RB_Method_Fast = new System.Windows.Forms.RadioButton();
            this.RB_Method_Erat = new System.Windows.Forms.RadioButton();
            this.RB_Method_Root = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.RB_Solver_MinMaxSeg = new System.Windows.Forms.RadioButton();
            this.RB_Solver_MaxSegment = new System.Windows.Forms.RadioButton();
            this.RB_Solver_Divisors = new System.Windows.Forms.RadioButton();
            this.RB_Solver_BarChart = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Bt_Start = new System.Windows.Forms.Button();
            this.Bt_End = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.RTx_Output = new System.Windows.Forms.RichTextBox();
            this.Bt_Output = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Tx_Input = new System.Windows.Forms.TextBox();
            this.Tx_Additional_Input = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Lb_Help = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1045, 522);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1039, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Опции";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1033, 109);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.RB_Method_Fast);
            this.flowLayoutPanel1.Controls.Add(this.RB_Method_Erat);
            this.flowLayoutPanel1.Controls.Add(this.RB_Method_Root);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 57);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1027, 49);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // RB_Method_Fast
            // 
            this.RB_Method_Fast.AutoSize = true;
            this.RB_Method_Fast.Checked = true;
            this.RB_Method_Fast.Location = new System.Drawing.Point(3, 3);
            this.RB_Method_Fast.Name = "RB_Method_Fast";
            this.RB_Method_Fast.Size = new System.Drawing.Size(174, 19);
            this.RB_Method_Fast.TabIndex = 2;
            this.RB_Method_Fast.TabStop = true;
            this.RB_Method_Fast.Text = "Методом быстрого поиска";
            this.RB_Method_Fast.UseVisualStyleBackColor = true;
            this.RB_Method_Fast.CheckedChanged += new System.EventHandler(this.RB_Method_Fast_CheckedChanged);
            // 
            // RB_Method_Erat
            // 
            this.RB_Method_Erat.AutoSize = true;
            this.RB_Method_Erat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RB_Method_Erat.Location = new System.Drawing.Point(183, 3);
            this.RB_Method_Erat.Name = "RB_Method_Erat";
            this.RB_Method_Erat.Size = new System.Drawing.Size(145, 19);
            this.RB_Method_Erat.TabIndex = 0;
            this.RB_Method_Erat.Text = "Методом Эратосфена";
            this.RB_Method_Erat.UseVisualStyleBackColor = true;
            this.RB_Method_Erat.CheckedChanged += new System.EventHandler(this.RB_Method_Erat_CheckedChanged);
            // 
            // RB_Method_Root
            // 
            this.RB_Method_Root.AutoSize = true;
            this.RB_Method_Root.Location = new System.Drawing.Point(361, 3);
            this.RB_Method_Root.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.RB_Method_Root.Name = "RB_Method_Root";
            this.RB_Method_Root.Size = new System.Drawing.Size(119, 19);
            this.RB_Method_Root.TabIndex = 1;
            this.RB_Method_Root.Text = "Методом корней";
            this.RB_Method_Root.UseVisualStyleBackColor = true;
            this.RB_Method_Root.CheckedChanged += new System.EventHandler(this.RB_Method_Root_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.RB_Solver_MinMaxSeg);
            this.flowLayoutPanel3.Controls.Add(this.RB_Solver_MaxSegment);
            this.flowLayoutPanel3.Controls.Add(this.RB_Solver_Divisors);
            this.flowLayoutPanel3.Controls.Add(this.RB_Solver_BarChart);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1027, 48);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // RB_Solver_MinMaxSeg
            // 
            this.RB_Solver_MinMaxSeg.AutoSize = true;
            this.RB_Solver_MinMaxSeg.Checked = true;
            this.RB_Solver_MinMaxSeg.Location = new System.Drawing.Point(3, 3);
            this.RB_Solver_MinMaxSeg.Name = "RB_Solver_MinMaxSeg";
            this.RB_Solver_MinMaxSeg.Size = new System.Drawing.Size(146, 19);
            this.RB_Solver_MinMaxSeg.TabIndex = 0;
            this.RB_Solver_MinMaxSeg.TabStop = true;
            this.RB_Solver_MinMaxSeg.Text = "Мин. Макс. Сегменты";
            this.RB_Solver_MinMaxSeg.UseVisualStyleBackColor = true;
            this.RB_Solver_MinMaxSeg.CheckedChanged += new System.EventHandler(this.RB_Solver_MinMaxSeg_CheckedChanged);
            // 
            // RB_Solver_MaxSegment
            // 
            this.RB_Solver_MaxSegment.AutoSize = true;
            this.RB_Solver_MaxSegment.Location = new System.Drawing.Point(155, 3);
            this.RB_Solver_MaxSegment.Name = "RB_Solver_MaxSegment";
            this.RB_Solver_MaxSegment.Size = new System.Drawing.Size(266, 19);
            this.RB_Solver_MaxSegment.TabIndex = 1;
            this.RB_Solver_MaxSegment.Text = "Максимальный сегмент без простых чисел";
            this.RB_Solver_MaxSegment.UseVisualStyleBackColor = true;
            this.RB_Solver_MaxSegment.CheckedChanged += new System.EventHandler(this.RB_Solver_MaxSegment_CheckedChanged);
            // 
            // RB_Solver_Divisors
            // 
            this.RB_Solver_Divisors.AutoSize = true;
            this.RB_Solver_Divisors.Location = new System.Drawing.Point(427, 3);
            this.RB_Solver_Divisors.Name = "RB_Solver_Divisors";
            this.RB_Solver_Divisors.Size = new System.Drawing.Size(114, 19);
            this.RB_Solver_Divisors.TabIndex = 1;
            this.RB_Solver_Divisors.Text = "Делители числа";
            this.RB_Solver_Divisors.UseVisualStyleBackColor = true;
            this.RB_Solver_Divisors.CheckedChanged += new System.EventHandler(this.RB_Solver_Divisors_CheckedChanged);
            // 
            // RB_Solver_BarChart
            // 
            this.RB_Solver_BarChart.AutoSize = true;
            this.RB_Solver_BarChart.Location = new System.Drawing.Point(547, 3);
            this.RB_Solver_BarChart.Name = "RB_Solver_BarChart";
            this.RB_Solver_BarChart.Size = new System.Drawing.Size(271, 19);
            this.RB_Solver_BarChart.TabIndex = 2;
            this.RB_Solver_BarChart.Text = "Гистограмма распределения простых чисел";
            this.RB_Solver_BarChart.UseVisualStyleBackColor = true;
            this.RB_Solver_BarChart.CheckedChanged += new System.EventHandler(this.RB_Solver_BarChart_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1039, 131);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Управление";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.Bt_Start, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Bt_End, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1033, 109);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // Bt_Start
            // 
            this.Bt_Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Start.Location = new System.Drawing.Point(3, 3);
            this.Bt_Start.Name = "Bt_Start";
            this.Bt_Start.Size = new System.Drawing.Size(510, 103);
            this.Bt_Start.TabIndex = 1;
            this.Bt_Start.Text = "Начать";
            this.Bt_Start.UseVisualStyleBackColor = true;
            this.Bt_Start.Click += new System.EventHandler(this.Bt_Start_Click);
            // 
            // Bt_End
            // 
            this.Bt_End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_End.Enabled = false;
            this.Bt_End.Location = new System.Drawing.Point(519, 3);
            this.Bt_End.Name = "Bt_End";
            this.Bt_End.Size = new System.Drawing.Size(511, 103);
            this.Bt_End.TabIndex = 2;
            this.Bt_End.Text = "Прервать";
            this.Bt_End.UseVisualStyleBackColor = true;
            this.Bt_End.Click += new System.EventHandler(this.Bt_End_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 414);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1039, 105);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Вывод";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Controls.Add(this.RTx_Output, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Bt_Output, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1033, 83);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // RTx_Output
            // 
            this.RTx_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTx_Output.Location = new System.Drawing.Point(3, 3);
            this.RTx_Output.Name = "RTx_Output";
            this.RTx_Output.ReadOnly = true;
            this.RTx_Output.Size = new System.Drawing.Size(923, 77);
            this.RTx_Output.TabIndex = 1;
            this.RTx_Output.Text = "";
            // 
            // Bt_Output
            // 
            this.Bt_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Output.Enabled = false;
            this.Bt_Output.Location = new System.Drawing.Point(932, 3);
            this.Bt_Output.Name = "Bt_Output";
            this.Bt_Output.Size = new System.Drawing.Size(98, 77);
            this.Bt_Output.TabIndex = 2;
            this.Bt_Output.Text = "Вывод";
            this.Bt_Output.UseVisualStyleBackColor = true;
            this.Bt_Output.Click += new System.EventHandler(this.Bt_Output_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel6.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1039, 131);
            this.tableLayoutPanel6.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.Tx_Input, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.Tx_Additional_Input, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(777, 103);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // Tx_Input
            // 
            this.Tx_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tx_Input.Location = new System.Drawing.Point(3, 24);
            this.Tx_Input.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.Tx_Input.MaxLength = 30;
            this.Tx_Input.Name = "Tx_Input";
            this.Tx_Input.Size = new System.Drawing.Size(754, 23);
            this.Tx_Input.TabIndex = 0;
            this.Tx_Input.Text = "100";
            this.Tx_Input.TextChanged += new System.EventHandler(this.Tx_Input_TextChanged);
            // 
            // Tx_Additional_Input
            // 
            this.Tx_Additional_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tx_Additional_Input.Location = new System.Drawing.Point(3, 54);
            this.Tx_Additional_Input.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.Tx_Additional_Input.MaxLength = 5;
            this.Tx_Additional_Input.Name = "Tx_Additional_Input";
            this.Tx_Additional_Input.Size = new System.Drawing.Size(754, 23);
            this.Tx_Additional_Input.TabIndex = 1;
            this.Tx_Additional_Input.Text = "10";
            this.Tx_Additional_Input.TextChanged += new System.EventHandler(this.Tx_Additional_Input_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Lb_Help);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(792, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 125);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Справка";
            // 
            // Lb_Help
            // 
            this.Lb_Help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lb_Help.Location = new System.Drawing.Point(3, 19);
            this.Lb_Help.Name = "Lb_Help";
            this.Lb_Help.Size = new System.Drawing.Size(238, 103);
            this.Lb_Help.TabIndex = 1;
            this.Lb_Help.Text = "Поиск наибольших десятков в диапазоне [2, n] с минимальным и максимальным количес" +
    "твом простых чисел.\r\nВходные данные: натуральное число n, кратное 10 в диапазоне" +
    " [10, 2147483640].";
            this.Lb_Help.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(399, 465);
            this.Name = "MainForm";
            this.Text = "PrimeTens";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox Tx_Input;
        private Button Bt_Start;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton RB_Method_Erat;
        private RadioButton RB_Method_Root;
        private Button Bt_End;
        private ErrorProvider errorProvider;
        private TableLayoutPanel tableLayoutPanel5;
        private Label Lb_Help;
        private TableLayoutPanel tableLayoutPanel6;
        private GroupBox groupBox5;
        private FlowLayoutPanel flowLayoutPanel3;
        private RadioButton RB_Solver_MinMaxSeg;
        private RadioButton RB_Solver_MaxSegment;
        private RadioButton RB_Solver_Divisors;
        private RadioButton RB_Solver_BarChart;
        private TextBox Tx_Additional_Input;
        private TableLayoutPanel tableLayoutPanel4;
        private RichTextBox RTx_Output;
        private Button Bt_Output;
        private RadioButton RB_Method_Fast;
    }
}