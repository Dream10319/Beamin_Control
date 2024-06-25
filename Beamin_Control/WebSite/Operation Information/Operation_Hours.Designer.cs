namespace Beamin_Control.WebSite.Operation_Information
{
    partial class Operation_Hours
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.closeMinute = new System.Windows.Forms.ComboBox();
            this.closeHour = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openMinute = new System.Windows.Forms.ComboBox();
            this.openHour = new System.Windows.Forms.ComboBox();
            this.All_Day = new System.Windows.Forms.CheckBox();
            this.intervalCode = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.closeMinute);
            this.panel1.Controls.Add(this.closeHour);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.openMinute);
            this.panel1.Controls.Add(this.openHour);
            this.panel1.Location = new System.Drawing.Point(173, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 57);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "End";
            // 
            // closeMinute
            // 
            this.closeMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.closeMinute.FormattingEnabled = true;
            this.closeMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.closeMinute.Location = new System.Drawing.Point(393, 24);
            this.closeMinute.Name = "closeMinute";
            this.closeMinute.Size = new System.Drawing.Size(65, 26);
            this.closeMinute.TabIndex = 7;
            // 
            // closeHour
            // 
            this.closeHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.closeHour.FormattingEnabled = true;
            this.closeHour.Location = new System.Drawing.Point(175, 24);
            this.closeHour.Name = "closeHour";
            this.closeHour.Size = new System.Drawing.Size(214, 26);
            this.closeHour.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start";
            // 
            // openMinute
            // 
            this.openMinute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.openMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.openMinute.FormattingEnabled = true;
            this.openMinute.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.openMinute.Location = new System.Drawing.Point(98, 24);
            this.openMinute.Name = "openMinute";
            this.openMinute.Size = new System.Drawing.Size(65, 26);
            this.openMinute.TabIndex = 2;
            // 
            // openHour
            // 
            this.openHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.openHour.FormattingEnabled = true;
            this.openHour.Location = new System.Drawing.Point(6, 24);
            this.openHour.Name = "openHour";
            this.openHour.Size = new System.Drawing.Size(89, 26);
            this.openHour.TabIndex = 1;
            // 
            // All_Day
            // 
            this.All_Day.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.All_Day.AutoSize = true;
            this.All_Day.Cursor = System.Windows.Forms.Cursors.Hand;
            this.All_Day.Location = new System.Drawing.Point(542, 4);
            this.All_Day.Name = "All_Day";
            this.All_Day.Size = new System.Drawing.Size(95, 22);
            this.All_Day.TabIndex = 5;
            this.All_Day.Text = "24 Hours";
            this.All_Day.UseVisualStyleBackColor = true;
            this.All_Day.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // intervalCode
            // 
            this.intervalCode.AutoSize = true;
            this.intervalCode.Location = new System.Drawing.Point(3, 25);
            this.intervalCode.Name = "intervalCode";
            this.intervalCode.Size = new System.Drawing.Size(55, 18);
            this.intervalCode.TabIndex = 6;
            this.intervalCode.Text = "label2";
            // 
            // Operation_Hours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.intervalCode);
            this.Controls.Add(this.All_Day);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Operation_Hours";
            this.Size = new System.Drawing.Size(643, 64);
            this.Load += new System.EventHandler(this.Operation_Hours_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox closeMinute;
        internal System.Windows.Forms.ComboBox closeHour;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox openMinute;
        internal System.Windows.Forms.ComboBox openHour;
        internal System.Windows.Forms.CheckBox All_Day;
        internal System.Windows.Forms.Label intervalCode;
        internal System.Windows.Forms.Panel panel1;
    }
}
