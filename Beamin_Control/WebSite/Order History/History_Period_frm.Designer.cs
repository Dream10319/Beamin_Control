namespace Beamin_Control.WebSite.Order_History
{
    partial class History_Period_frm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Day_Week_Tab = new System.Windows.Forms.TabPage();
            this.Day_Week_List = new System.Windows.Forms.FlowLayoutPanel();
            this.Month_Tab = new System.Windows.Forms.TabPage();
            this.Months_list = new System.Windows.Forms.FlowLayoutPanel();
            this.bifurcation_Tab = new System.Windows.Forms.TabPage();
            this.Periods_lst = new System.Windows.Forms.FlowLayoutPanel();
            this.Date_Tab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.Start_Date = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Day_Week_Tab.SuspendLayout();
            this.Month_Tab.SuspendLayout();
            this.bifurcation_Tab.SuspendLayout();
            this.Date_Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Day_Week_Tab);
            this.tabControl1.Controls.Add(this.Month_Tab);
            this.tabControl1.Controls.Add(this.bifurcation_Tab);
            this.tabControl1.Controls.Add(this.Date_Tab);
            this.tabControl1.Location = new System.Drawing.Point(12, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 457);
            this.tabControl1.TabIndex = 0;
            // 
            // Day_Week_Tab
            // 
            this.Day_Week_Tab.Controls.Add(this.Day_Week_List);
            this.Day_Week_Tab.Location = new System.Drawing.Point(4, 22);
            this.Day_Week_Tab.Name = "Day_Week_Tab";
            this.Day_Week_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Day_Week_Tab.Size = new System.Drawing.Size(365, 405);
            this.Day_Week_Tab.TabIndex = 0;
            this.Day_Week_Tab.Text = "Day & Week";
            this.Day_Week_Tab.UseVisualStyleBackColor = true;
            // 
            // Day_Week_List
            // 
            this.Day_Week_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Day_Week_List.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Day_Week_List.Location = new System.Drawing.Point(33, 6);
            this.Day_Week_List.Name = "Day_Week_List";
            this.Day_Week_List.Size = new System.Drawing.Size(326, 342);
            this.Day_Week_List.TabIndex = 0;
            this.Day_Week_List.WrapContents = false;
            // 
            // Month_Tab
            // 
            this.Month_Tab.Controls.Add(this.Months_list);
            this.Month_Tab.Location = new System.Drawing.Point(4, 27);
            this.Month_Tab.Name = "Month_Tab";
            this.Month_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Month_Tab.Size = new System.Drawing.Size(365, 426);
            this.Month_Tab.TabIndex = 1;
            this.Month_Tab.Text = "Month";
            this.Month_Tab.UseVisualStyleBackColor = true;
            // 
            // Months_list
            // 
            this.Months_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Months_list.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Months_list.Location = new System.Drawing.Point(33, 6);
            this.Months_list.Name = "Months_list";
            this.Months_list.Size = new System.Drawing.Size(326, 386);
            this.Months_list.TabIndex = 1;
            this.Months_list.WrapContents = false;
            // 
            // bifurcation_Tab
            // 
            this.bifurcation_Tab.Controls.Add(this.Periods_lst);
            this.bifurcation_Tab.Location = new System.Drawing.Point(4, 27);
            this.bifurcation_Tab.Name = "bifurcation_Tab";
            this.bifurcation_Tab.Size = new System.Drawing.Size(365, 426);
            this.bifurcation_Tab.TabIndex = 2;
            this.bifurcation_Tab.Text = "Bifurcation";
            this.bifurcation_Tab.UseVisualStyleBackColor = true;
            // 
            // Periods_lst
            // 
            this.Periods_lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Periods_lst.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Periods_lst.Location = new System.Drawing.Point(33, 6);
            this.Periods_lst.Name = "Periods_lst";
            this.Periods_lst.Size = new System.Drawing.Size(326, 417);
            this.Periods_lst.TabIndex = 2;
            this.Periods_lst.WrapContents = false;
            // 
            // Date_Tab
            // 
            this.Date_Tab.Controls.Add(this.label1);
            this.Date_Tab.Controls.Add(this.EndDate);
            this.Date_Tab.Controls.Add(this.Start_Date);
            this.Date_Tab.Location = new System.Drawing.Point(4, 22);
            this.Date_Tab.Name = "Date_Tab";
            this.Date_Tab.Size = new System.Drawing.Size(365, 405);
            this.Date_Tab.TabIndex = 3;
            this.Date_Tab.Text = "Date";
            this.Date_Tab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "~";
            // 
            // EndDate
            // 
            this.EndDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EndDate.CustomFormat = "yyyy. MM. dd";
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDate.Location = new System.Drawing.Point(199, 78);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(149, 26);
            this.EndDate.TabIndex = 1;
            // 
            // Start_Date
            // 
            this.Start_Date.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Start_Date.CustomFormat = "yyyy. MM. dd";
            this.Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Start_Date.Location = new System.Drawing.Point(16, 78);
            this.Start_Date.Name = "Start_Date";
            this.Start_Date.Size = new System.Drawing.Size(149, 26);
            this.Start_Date.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(103, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // History_Period_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(397, 539);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "History_Period_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History_Period_frm";
            this.Load += new System.EventHandler(this.History_Period_frm_Load);
            this.tabControl1.ResumeLayout(false);
            this.Day_Week_Tab.ResumeLayout(false);
            this.Month_Tab.ResumeLayout(false);
            this.bifurcation_Tab.ResumeLayout(false);
            this.Date_Tab.ResumeLayout(false);
            this.Date_Tab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage Day_Week_Tab;
        private System.Windows.Forms.TabPage Month_Tab;
        private System.Windows.Forms.TabPage bifurcation_Tab;
        private System.Windows.Forms.FlowLayoutPanel Day_Week_List;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.TabPage Date_Tab;
        internal System.Windows.Forms.DateTimePicker Start_Date;
        internal System.Windows.Forms.DateTimePicker EndDate;
        private System.Windows.Forms.FlowLayoutPanel Months_list;
        private System.Windows.Forms.FlowLayoutPanel Periods_lst;
    }
}