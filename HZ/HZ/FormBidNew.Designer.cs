namespace HZ
{
    partial class FormBidNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonDateEnd = new System.Windows.Forms.Button();
            this.buttonDateStart = new System.Windows.Forms.Button();
            this.numBIdMoney = new System.Windows.Forms.NumericUpDown();
            this.buttonNewBid = new System.Windows.Forms.Button();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.textBoxStartDate = new System.Windows.Forms.TextBox();
            this.textBoxBidAbbreviation = new System.Windows.Forms.TextBox();
            this.textBoxBidName = new System.Windows.Forms.TextBox();
            this.numBidBond = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendarDate = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBIdMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBidBond)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(49, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "標案名稱：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendarDate);
            this.groupBox1.Controls.Add(this.buttonExport);
            this.groupBox1.Controls.Add(this.buttonDateEnd);
            this.groupBox1.Controls.Add(this.buttonDateStart);
            this.groupBox1.Controls.Add(this.numBIdMoney);
            this.groupBox1.Controls.Add(this.buttonNewBid);
            this.groupBox1.Controls.Add(this.textBoxEndDate);
            this.groupBox1.Controls.Add(this.textBoxStartDate);
            this.groupBox1.Controls.Add(this.textBoxBidAbbreviation);
            this.groupBox1.Controls.Add(this.textBoxBidName);
            this.groupBox1.Controls.Add(this.numBidBond);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 406);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonExport.Location = new System.Drawing.Point(63, 353);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(116, 47);
            this.buttonExport.TabIndex = 16;
            this.buttonExport.Text = "新增";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonDateEnd
            // 
            this.buttonDateEnd.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDateEnd.Location = new System.Drawing.Point(455, 287);
            this.buttonDateEnd.Name = "buttonDateEnd";
            this.buttonDateEnd.Size = new System.Drawing.Size(79, 36);
            this.buttonDateEnd.TabIndex = 15;
            this.buttonDateEnd.Text = "日期";
            this.buttonDateEnd.UseVisualStyleBackColor = true;
            this.buttonDateEnd.Click += new System.EventHandler(this.buttonDateEnd_Click);
            // 
            // buttonDateStart
            // 
            this.buttonDateStart.Font = new System.Drawing.Font("PMingLiU", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonDateStart.Location = new System.Drawing.Point(455, 237);
            this.buttonDateStart.Name = "buttonDateStart";
            this.buttonDateStart.Size = new System.Drawing.Size(79, 36);
            this.buttonDateStart.TabIndex = 14;
            this.buttonDateStart.Text = "日期";
            this.buttonDateStart.UseVisualStyleBackColor = true;
            this.buttonDateStart.Click += new System.EventHandler(this.buttonDateStart_Click);
            // 
            // numBIdMoney
            // 
            this.numBIdMoney.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numBIdMoney.Location = new System.Drawing.Point(185, 138);
            this.numBIdMoney.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.numBIdMoney.Name = "numBIdMoney";
            this.numBIdMoney.Size = new System.Drawing.Size(240, 36);
            this.numBIdMoney.TabIndex = 13;
            // 
            // buttonNewBid
            // 
            this.buttonNewBid.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonNewBid.Location = new System.Drawing.Point(241, 353);
            this.buttonNewBid.Name = "buttonNewBid";
            this.buttonNewBid.Size = new System.Drawing.Size(116, 47);
            this.buttonNewBid.TabIndex = 12;
            this.buttonNewBid.Text = "新增";
            this.buttonNewBid.UseVisualStyleBackColor = true;
            this.buttonNewBid.Click += new System.EventHandler(this.buttonNewBid_Click);
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxEndDate.Location = new System.Drawing.Point(185, 287);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.Size = new System.Drawing.Size(264, 36);
            this.textBoxEndDate.TabIndex = 11;
            // 
            // textBoxStartDate
            // 
            this.textBoxStartDate.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxStartDate.Location = new System.Drawing.Point(185, 237);
            this.textBoxStartDate.Name = "textBoxStartDate";
            this.textBoxStartDate.Size = new System.Drawing.Size(264, 36);
            this.textBoxStartDate.TabIndex = 10;
            // 
            // textBoxBidAbbreviation
            // 
            this.textBoxBidAbbreviation.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxBidAbbreviation.Location = new System.Drawing.Point(185, 87);
            this.textBoxBidAbbreviation.Name = "textBoxBidAbbreviation";
            this.textBoxBidAbbreviation.Size = new System.Drawing.Size(337, 36);
            this.textBoxBidAbbreviation.TabIndex = 8;
            // 
            // textBoxBidName
            // 
            this.textBoxBidName.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxBidName.Location = new System.Drawing.Point(185, 37);
            this.textBoxBidName.Name = "textBoxBidName";
            this.textBoxBidName.Size = new System.Drawing.Size(337, 36);
            this.textBoxBidName.TabIndex = 7;
            // 
            // numBidBond
            // 
            this.numBidBond.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numBidBond.Location = new System.Drawing.Point(185, 188);
            this.numBidBond.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numBidBond.Name = "numBidBond";
            this.numBidBond.Size = new System.Drawing.Size(240, 36);
            this.numBidBond.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(49, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "結束日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(49, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "起始日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(49, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "押標金額：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(49, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "標案金額：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(49, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "標案簡稱：";
            // 
            // monthCalendarDate
            // 
            this.monthCalendarDate.Location = new System.Drawing.Point(12, 14);
            this.monthCalendarDate.Name = "monthCalendarDate";
            this.monthCalendarDate.TabIndex = 17;
            this.monthCalendarDate.Visible = false;
            // 
            // FormBidNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 464);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormBidNew";
            this.Text = "FormBidNew";
            this.Load += new System.EventHandler(this.FormBidNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBIdMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBidBond)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDateEnd;
        private System.Windows.Forms.Button buttonDateStart;
        private System.Windows.Forms.NumericUpDown numBIdMoney;
        private System.Windows.Forms.Button buttonNewBid;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.TextBox textBoxStartDate;
        private System.Windows.Forms.TextBox textBoxBidAbbreviation;
        private System.Windows.Forms.TextBox textBoxBidName;
        private System.Windows.Forms.NumericUpDown numBidBond;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.MonthCalendar monthCalendarDate;
    }
}