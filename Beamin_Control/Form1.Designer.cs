
namespace Beamin_Control
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Order_Checker_lable = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.In_Progress_Orders = new System.Windows.Forms.FlowLayoutPanel();
            this.New_Orders = new System.Windows.Forms.FlowLayoutPanel();
            this.Order_Details = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Completed_Orders_Details = new System.Windows.Forms.FlowLayoutPanel();
            this.Completed_Orders = new System.Windows.Forms.FlowLayoutPanel();
            this.Login_Btn = new System.Windows.Forms.Button();
            this.Close_btn = new System.Windows.Forms.Button();
            this.temporaryBlockedInfo = new System.Windows.Forms.Label();
            this.Web_Settings_btn = new System.Windows.Forms.Button();
            this.App_Version = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Order_Checker_lable
            // 
            this.Order_Checker_lable.AutoSize = true;
            this.Order_Checker_lable.Location = new System.Drawing.Point(3, 6);
            this.Order_Checker_lable.Name = "Order_Checker_lable";
            this.Order_Checker_lable.Size = new System.Drawing.Size(23, 18);
            this.Order_Checker_lable.TabIndex = 29;
            this.Order_Checker_lable.Text = "...";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "order (1).png");
            this.imageList1.Images.SetKeyName(1, "icons8-database-64.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 585);
            this.splitter1.TabIndex = 31;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.Order_Checker_lable);
            this.panel2.Location = new System.Drawing.Point(15, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1039, 471);
            this.panel2.TabIndex = 35;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 27);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1029, 439);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.Order_Details);
            this.tabPage1.Location = new System.Drawing.Point(29, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(996, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.In_Progress_Orders);
            this.panel1.Controls.Add(this.New_Orders);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 425);
            this.panel1.TabIndex = 3;
            // 
            // In_Progress_Orders
            // 
            this.In_Progress_Orders.AutoScroll = true;
            this.In_Progress_Orders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.In_Progress_Orders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.In_Progress_Orders.Location = new System.Drawing.Point(0, 157);
            this.In_Progress_Orders.Name = "In_Progress_Orders";
            this.In_Progress_Orders.Size = new System.Drawing.Size(200, 268);
            this.In_Progress_Orders.TabIndex = 2;
            // 
            // New_Orders
            // 
            this.New_Orders.AutoScroll = true;
            this.New_Orders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.New_Orders.Dock = System.Windows.Forms.DockStyle.Top;
            this.New_Orders.Location = new System.Drawing.Point(0, 0);
            this.New_Orders.Name = "New_Orders";
            this.New_Orders.Size = new System.Drawing.Size(200, 157);
            this.New_Orders.TabIndex = 1;
            // 
            // Order_Details
            // 
            this.Order_Details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Order_Details.AutoScroll = true;
            this.Order_Details.BackColor = System.Drawing.Color.SkyBlue;
            this.Order_Details.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Order_Details.Location = new System.Drawing.Point(209, 3);
            this.Order_Details.Name = "Order_Details";
            this.Order_Details.Size = new System.Drawing.Size(784, 425);
            this.Order_Details.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Completed_Orders_Details);
            this.tabPage2.Controls.Add(this.Completed_Orders);
            this.tabPage2.Location = new System.Drawing.Point(29, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(996, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Completed";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Completed_Orders_Details
            // 
            this.Completed_Orders_Details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Completed_Orders_Details.AutoScroll = true;
            this.Completed_Orders_Details.BackColor = System.Drawing.Color.SkyBlue;
            this.Completed_Orders_Details.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Completed_Orders_Details.Location = new System.Drawing.Point(209, 3);
            this.Completed_Orders_Details.Name = "Completed_Orders_Details";
            this.Completed_Orders_Details.Size = new System.Drawing.Size(784, 438);
            this.Completed_Orders_Details.TabIndex = 4;
            // 
            // Completed_Orders
            // 
            this.Completed_Orders.AutoScroll = true;
            this.Completed_Orders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Completed_Orders.Dock = System.Windows.Forms.DockStyle.Left;
            this.Completed_Orders.Location = new System.Drawing.Point(3, 3);
            this.Completed_Orders.Name = "Completed_Orders";
            this.Completed_Orders.Size = new System.Drawing.Size(200, 425);
            this.Completed_Orders.TabIndex = 3;
            // 
            // Login_Btn
            // 
            this.Login_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Login_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login_Btn.Location = new System.Drawing.Point(886, 24);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(168, 51);
            this.Login_Btn.TabIndex = 36;
            this.Login_Btn.Text = "Login";
            this.Login_Btn.UseVisualStyleBackColor = true;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Button);
            // 
            // Close_btn
            // 
            this.Close_btn.AutoSize = true;
            this.Close_btn.BackColor = System.Drawing.Color.White;
            this.Close_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Close_btn.Location = new System.Drawing.Point(15, 24);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(228, 51);
            this.Close_btn.TabIndex = 37;
            this.Close_btn.Text = "...";
            this.Close_btn.UseVisualStyleBackColor = false;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // temporaryBlockedInfo
            // 
            this.temporaryBlockedInfo.AutoSize = true;
            this.temporaryBlockedInfo.Location = new System.Drawing.Point(256, 40);
            this.temporaryBlockedInfo.Name = "temporaryBlockedInfo";
            this.temporaryBlockedInfo.Size = new System.Drawing.Size(0, 18);
            this.temporaryBlockedInfo.TabIndex = 42;
            // 
            // Web_Settings_btn
            // 
            this.Web_Settings_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Web_Settings_btn.AutoSize = true;
            this.Web_Settings_btn.BackColor = System.Drawing.Color.White;
            this.Web_Settings_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Web_Settings_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Web_Settings_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Web_Settings_btn.Location = new System.Drawing.Point(735, 24);
            this.Web_Settings_btn.Name = "Web_Settings_btn";
            this.Web_Settings_btn.Size = new System.Drawing.Size(145, 51);
            this.Web_Settings_btn.TabIndex = 47;
            this.Web_Settings_btn.Text = "Web Settings";
            this.Web_Settings_btn.UseVisualStyleBackColor = false;
            this.Web_Settings_btn.Click += new System.EventHandler(this.button9_Click);
            // 
            // App_Version
            // 
            this.App_Version.AutoSize = true;
            this.App_Version.Location = new System.Drawing.Point(262, 41);
            this.App_Version.Name = "App_Version";
            this.App_Version.Size = new System.Drawing.Size(23, 18);
            this.App_Version.TabIndex = 49;
            this.App_Version.Text = "...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(216, 43);
            this.button2.TabIndex = 51;
            this.button2.Text = "Check For New Orders";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "English",
            "한국인"});
            this.comboBox1.Location = new System.Drawing.Point(338, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 26);
            this.comboBox1.TabIndex = 52;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 585);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.App_Version);
            this.Controls.Add(this.Web_Settings_btn);
            this.Controls.Add(this.temporaryBlockedInfo);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1085, 624);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pos System Version 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Order_Checker_lable;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Login_Btn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Web_Settings_btn;
        private System.Windows.Forms.Label App_Version;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.FlowLayoutPanel New_Orders;
        internal System.Windows.Forms.FlowLayoutPanel In_Progress_Orders;
        internal System.Windows.Forms.FlowLayoutPanel Completed_Orders;
        internal System.Windows.Forms.FlowLayoutPanel Order_Details;
        internal System.Windows.Forms.FlowLayoutPanel Completed_Orders_Details;
        internal System.Windows.Forms.Button Close_btn;
        internal System.Windows.Forms.Label temporaryBlockedInfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

