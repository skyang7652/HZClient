namespace HZ
{
    partial class FormSalary
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewName = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.monthCalendarDate = new System.Windows.Forms.MonthCalendar();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numAllPay = new System.Windows.Forms.NumericUpDown();
            this.numOTPay = new System.Windows.Forms.NumericUpDown();
            this.numOTSegement = new System.Windows.Forms.NumericUpDown();
            this.numPmPay = new System.Windows.Forms.NumericUpDown();
            this.numPmSegement = new System.Windows.Forms.NumericUpDown();
            this.comboBoxOTLocation = new System.Windows.Forms.ComboBox();
            this.comboBoxPmLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxAmLocation = new System.Windows.Forms.ComboBox();
            this.numAmSegement = new System.Windows.Forms.NumericUpDown();
            this.numAmPay = new System.Windows.Forms.NumericUpDown();
            this.buttonDate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewName)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAllPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOTPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOTSegement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPmPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPmSegement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmSegement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmPay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewName
            // 
            this.dataGridViewName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewName.Location = new System.Drawing.Point(0, 11);
            this.dataGridViewName.Name = "dataGridViewName";
            this.dataGridViewName.RowTemplate.Height = 24;
            this.dataGridViewName.Size = new System.Drawing.Size(209, 521);
            this.dataGridViewName.TabIndex = 0;
            this.dataGridViewName.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewName_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.monthCalendarDate);
            this.groupBox2.Controls.Add(this.textBoxDate);
            this.groupBox2.Controls.Add(this.labelName);
            this.groupBox2.Controls.Add(this.buttonApply);
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Controls.Add(this.buttonDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(233, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(972, 548);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // monthCalendarDate
            // 
            this.monthCalendarDate.Location = new System.Drawing.Point(13, 11);
            this.monthCalendarDate.Name = "monthCalendarDate";
            this.monthCalendarDate.TabIndex = 17;
            this.monthCalendarDate.Visible = false;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxDate.Location = new System.Drawing.Point(550, 46);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(164, 36);
            this.textBoxDate.TabIndex = 16;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelName.Location = new System.Drawing.Point(228, 52);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 24);
            this.labelName.TabIndex = 15;
            // 
            // buttonApply
            // 
            this.buttonApply.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonApply.Location = new System.Drawing.Point(805, 40);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(89, 42);
            this.buttonApply.TabIndex = 14;
            this.buttonApply.Text = "新增";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.40902F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.59098F));
            this.tableLayoutPanel1.Controls.Add(this.numAllPay, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.numOTPay, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.numOTSegement, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.numPmPay, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.numPmSegement, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxOTLocation, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPmLocation, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxAmLocation, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numAmSegement, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numAmPay, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(45, 104);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(885, 428);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // numAllPay
            // 
            this.numAllPay.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numAllPay.Location = new System.Drawing.Point(237, 382);
            this.numAllPay.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numAllPay.Name = "numAllPay";
            this.numAllPay.Size = new System.Drawing.Size(127, 36);
            this.numAllPay.TabIndex = 26;
            // 
            // numOTPay
            // 
            this.numOTPay.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numOTPay.Location = new System.Drawing.Point(237, 340);
            this.numOTPay.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numOTPay.Name = "numOTPay";
            this.numOTPay.Size = new System.Drawing.Size(127, 36);
            this.numOTPay.TabIndex = 25;
            // 
            // numOTSegement
            // 
            this.numOTSegement.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numOTSegement.Location = new System.Drawing.Point(237, 298);
            this.numOTSegement.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numOTSegement.Name = "numOTSegement";
            this.numOTSegement.Size = new System.Drawing.Size(127, 36);
            this.numOTSegement.TabIndex = 24;
            this.numOTSegement.ValueChanged += new System.EventHandler(this.numOTSegement_ValueChanged);
            // 
            // numPmPay
            // 
            this.numPmPay.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numPmPay.Location = new System.Drawing.Point(237, 214);
            this.numPmPay.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPmPay.Name = "numPmPay";
            this.numPmPay.Size = new System.Drawing.Size(127, 36);
            this.numPmPay.TabIndex = 23;
            // 
            // numPmSegement
            // 
            this.numPmSegement.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numPmSegement.Location = new System.Drawing.Point(237, 172);
            this.numPmSegement.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPmSegement.Name = "numPmSegement";
            this.numPmSegement.Size = new System.Drawing.Size(127, 36);
            this.numPmSegement.TabIndex = 22;
            this.numPmSegement.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPmSegement.ValueChanged += new System.EventHandler(this.numPmSegement_ValueChanged);
            // 
            // comboBoxOTLocation
            // 
            this.comboBoxOTLocation.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxOTLocation.FormattingEnabled = true;
            this.comboBoxOTLocation.Location = new System.Drawing.Point(237, 256);
            this.comboBoxOTLocation.Name = "comboBoxOTLocation";
            this.comboBoxOTLocation.Size = new System.Drawing.Size(633, 32);
            this.comboBoxOTLocation.TabIndex = 19;
            this.comboBoxOTLocation.SelectedIndexChanged += new System.EventHandler(this.comboBoxOTLocation_SelectedIndexChanged);
            // 
            // comboBoxPmLocation
            // 
            this.comboBoxPmLocation.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxPmLocation.FormattingEnabled = true;
            this.comboBoxPmLocation.Location = new System.Drawing.Point(237, 130);
            this.comboBoxPmLocation.Name = "comboBoxPmLocation";
            this.comboBoxPmLocation.Size = new System.Drawing.Size(633, 32);
            this.comboBoxPmLocation.TabIndex = 16;
            this.comboBoxPmLocation.SelectedIndexChanged += new System.EventHandler(this.comboBoxPmLocation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(52, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "上午薪資：";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(52, 391);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 24);
            this.label11.TabIndex = 11;
            this.label11.Text = "當日薪資：";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(52, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 24);
            this.label12.TabIndex = 12;
            this.label12.Text = "加班薪資：";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(52, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "上午時數：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(52, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "下午地點：";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(52, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 24);
            this.label10.TabIndex = 10;
            this.label10.Text = "加班時數：";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(52, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "上午地點：";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(52, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 24);
            this.label9.TabIndex = 9;
            this.label9.Text = "加班地點：";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(52, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "下午薪資：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(52, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "下午時數：";
            // 
            // comboBoxAmLocation
            // 
            this.comboBoxAmLocation.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxAmLocation.FormattingEnabled = true;
            this.comboBoxAmLocation.Location = new System.Drawing.Point(237, 4);
            this.comboBoxAmLocation.Name = "comboBoxAmLocation";
            this.comboBoxAmLocation.Size = new System.Drawing.Size(633, 32);
            this.comboBoxAmLocation.TabIndex = 13;
            this.comboBoxAmLocation.SelectedIndexChanged += new System.EventHandler(this.comboBoxAmLocation_SelectedIndexChanged);
            // 
            // numAmSegement
            // 
            this.numAmSegement.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numAmSegement.Location = new System.Drawing.Point(237, 46);
            this.numAmSegement.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numAmSegement.Name = "numAmSegement";
            this.numAmSegement.Size = new System.Drawing.Size(127, 36);
            this.numAmSegement.TabIndex = 20;
            this.numAmSegement.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numAmSegement.ValueChanged += new System.EventHandler(this.numAmSegement_ValueChanged);
            // 
            // numAmPay
            // 
            this.numAmPay.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numAmPay.Location = new System.Drawing.Point(237, 88);
            this.numAmPay.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numAmPay.Name = "numAmPay";
            this.numAmPay.Size = new System.Drawing.Size(127, 36);
            this.numAmPay.TabIndex = 21;
            // 
            // buttonDate
            // 
            this.buttonDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDate.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDate.Location = new System.Drawing.Point(410, 47);
            this.buttonDate.Name = "buttonDate";
            this.buttonDate.Size = new System.Drawing.Size(94, 35);
            this.buttonDate.TabIndex = 6;
            this.buttonDate.Text = "日期";
            this.buttonDate.UseVisualStyleBackColor = true;
            this.buttonDate.Click += new System.EventHandler(this.buttonDate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(510, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(103, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工姓名：";
            // 
            // FormSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 576);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSalary";
            this.Load += new System.EventHandler(this.FormSalary_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormSalary_MouseClick);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewName)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAllPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOTPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOTSegement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPmPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPmSegement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmSegement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmPay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.NumericUpDown numAllPay;
        private System.Windows.Forms.NumericUpDown numOTPay;
        private System.Windows.Forms.NumericUpDown numOTSegement;
        private System.Windows.Forms.NumericUpDown numPmPay;
        private System.Windows.Forms.NumericUpDown numPmSegement;
        private System.Windows.Forms.ComboBox comboBoxOTLocation;
        private System.Windows.Forms.ComboBox comboBoxPmLocation;
        private System.Windows.Forms.ComboBox comboBoxAmLocation;
        private System.Windows.Forms.NumericUpDown numAmSegement;
        private System.Windows.Forms.NumericUpDown numAmPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.MonthCalendar monthCalendarDate;
    }
}