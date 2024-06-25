namespace Beamin_Control
{
    partial class Order_Notification
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Order_Details = new System.Windows.Forms.Label();
            this.Order_No = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Time = new System.Windows.Forms.TextBox();
            this.Accept_Order = new System.Windows.Forms.Button();
            this.Cancel_Order = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Lable0 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Menus = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Order_Details);
            this.panel1.Location = new System.Drawing.Point(4, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 21);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Order_Details
            // 
            this.Order_Details.AutoSize = true;
            this.Order_Details.Location = new System.Drawing.Point(8, 0);
            this.Order_Details.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.Order_Details.Name = "Order_Details";
            this.Order_Details.Size = new System.Drawing.Size(23, 18);
            this.Order_Details.TabIndex = 7;
            this.Order_Details.Text = "...";
            // 
            // Order_No
            // 
            this.Order_No.AutoSize = true;
            this.Order_No.BackColor = System.Drawing.Color.Aquamarine;
            this.Order_No.ForeColor = System.Drawing.Color.Black;
            this.Order_No.Location = new System.Drawing.Point(18, 7);
            this.Order_No.Margin = new System.Windows.Forms.Padding(4);
            this.Order_No.Name = "Order_No";
            this.Order_No.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Order_No.Size = new System.Drawing.Size(33, 24);
            this.Order_No.TabIndex = 5;
            this.Order_No.Text = "...";
            this.Order_No.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button4.AutoSize = true;
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(142, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 33);
            this.button4.TabIndex = 4;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(272, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 33);
            this.button3.TabIndex = 3;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Time
            // 
            this.Time.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Time.Location = new System.Drawing.Point(176, 13);
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Size = new System.Drawing.Size(90, 26);
            this.Time.TabIndex = 2;
            this.Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Time.WordWrap = false;
            // 
            // Accept_Order
            // 
            this.Accept_Order.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Accept_Order.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Accept_Order.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Accept_Order.ForeColor = System.Drawing.Color.White;
            this.Accept_Order.Location = new System.Drawing.Point(349, 10);
            this.Accept_Order.Margin = new System.Windows.Forms.Padding(4);
            this.Accept_Order.Name = "Accept_Order";
            this.Accept_Order.Size = new System.Drawing.Size(97, 40);
            this.Accept_Order.TabIndex = 1;
            this.Accept_Order.Text = "Accept";
            this.Accept_Order.UseVisualStyleBackColor = false;
            this.Accept_Order.Click += new System.EventHandler(this.button2_Click);
            // 
            // Cancel_Order
            // 
            this.Cancel_Order.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Cancel_Order.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel_Order.Location = new System.Drawing.Point(12, 6);
            this.Cancel_Order.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel_Order.Name = "Cancel_Order";
            this.Cancel_Order.Size = new System.Drawing.Size(97, 40);
            this.Cancel_Order.TabIndex = 0;
            this.Cancel_Order.Text = "Refuse";
            this.Cancel_Order.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(443, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Lable0
            // 
            this.Lable0.AutoSize = true;
            this.Lable0.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Lable0.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lable0.Location = new System.Drawing.Point(5, 8);
            this.Lable0.Margin = new System.Windows.Forms.Padding(4);
            this.Lable0.Name = "Lable0";
            this.Lable0.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Lable0.Size = new System.Drawing.Size(100, 24);
            this.Lable0.TabIndex = 2;
            this.Lable0.Text = "New Order";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.Order_No);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 38);
            this.panel2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Menus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 171);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Menus
            // 
            this.Menus.AutoSize = true;
            this.Menus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Menus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Menus.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Menus.Location = new System.Drawing.Point(3, 70);
            this.Menus.MinimumSize = new System.Drawing.Size(431, 34);
            this.Menus.Name = "Menus";
            this.Menus.Size = new System.Drawing.Size(456, 34);
            this.Menus.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Time);
            this.panel4.Controls.Add(this.Cancel_Order);
            this.panel4.Controls.Add(this.Accept_Order);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Location = new System.Drawing.Point(3, 110);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(456, 58);
            this.panel4.TabIndex = 0;
            // 
            // Order_Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(470, 224);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Lable0);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Order_Notification";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Order_Notification";
            this.Load += new System.EventHandler(this.Order_Notification_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.TextBox Time;
        internal System.Windows.Forms.Button Accept_Order;
        internal System.Windows.Forms.Button Cancel_Order;
        private System.Windows.Forms.Label Lable0;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label Order_No;
        internal System.Windows.Forms.Label Order_Details;
        internal System.Windows.Forms.FlowLayoutPanel Menus;
    }
}