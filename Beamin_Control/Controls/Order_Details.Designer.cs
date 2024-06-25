namespace Beamin_Control.Controls
{
    partial class Order_Details
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orderNo = new System.Windows.Forms.Label();
            this.amountToReceive = new System.Windows.Forms.Label();
            this.O_modifiers = new System.Windows.Forms.FlowLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Time = new System.Windows.Forms.TextBox();
            this.Accept_Order = new System.Windows.Forms.Button();
            this.Cancel_Order = new System.Windows.Forms.Button();
            this.Order_Header = new System.Windows.Forms.Panel();
            this.date = new System.Windows.Forms.Label();
            this.orderProgress = new System.Windows.Forms.Label();
            this.Order_Controls = new System.Windows.Forms.FlowLayoutPanel();
            this.pn = new System.Windows.Forms.Panel();
            this.Send_Notifcation = new System.Windows.Forms.Button();
            this.Details_Items = new System.Windows.Forms.FlowLayoutPanel();
            this.Order_Header.SuspendLayout();
            this.Order_Controls.SuspendLayout();
            this.pn.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderNo
            // 
            this.orderNo.AutoSize = true;
            this.orderNo.Location = new System.Drawing.Point(9, 33);
            this.orderNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.orderNo.Name = "orderNo";
            this.orderNo.Size = new System.Drawing.Size(23, 18);
            this.orderNo.TabIndex = 0;
            this.orderNo.Text = "...";
            // 
            // amountToReceive
            // 
            this.amountToReceive.AutoSize = true;
            this.amountToReceive.Location = new System.Drawing.Point(9, 60);
            this.amountToReceive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amountToReceive.Name = "amountToReceive";
            this.amountToReceive.Size = new System.Drawing.Size(23, 18);
            this.amountToReceive.TabIndex = 2;
            this.amountToReceive.Text = "...";
            // 
            // O_modifiers
            // 
            this.O_modifiers.AutoSize = true;
            this.O_modifiers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.O_modifiers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.O_modifiers.Location = new System.Drawing.Point(19, 84);
            this.O_modifiers.Name = "O_modifiers";
            this.O_modifiers.Size = new System.Drawing.Size(0, 0);
            this.O_modifiers.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(19, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 26);
            this.button4.TabIndex = 10;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(135, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Time
            // 
            this.Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Time.Location = new System.Drawing.Point(60, 0);
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Size = new System.Drawing.Size(69, 26);
            this.Time.TabIndex = 8;
            this.Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Accept_Order
            // 
            this.Accept_Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Accept_Order.AutoSize = true;
            this.Accept_Order.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Accept_Order.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accept_Order.Location = new System.Drawing.Point(558, 4);
            this.Accept_Order.Margin = new System.Windows.Forms.Padding(4);
            this.Accept_Order.Name = "Accept_Order";
            this.Accept_Order.Size = new System.Drawing.Size(89, 26);
            this.Accept_Order.TabIndex = 7;
            this.Accept_Order.Text = "Accept";
            this.Accept_Order.UseVisualStyleBackColor = true;
            // 
            // Cancel_Order
            // 
            this.Cancel_Order.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Order.AutoSize = true;
            this.Cancel_Order.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel_Order.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Order.Location = new System.Drawing.Point(4, 4);
            this.Cancel_Order.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel_Order.Name = "Cancel_Order";
            this.Cancel_Order.Size = new System.Drawing.Size(120, 26);
            this.Cancel_Order.TabIndex = 6;
            this.Cancel_Order.Text = "Order Rejection";
            this.Cancel_Order.UseVisualStyleBackColor = true;
            // 
            // Order_Header
            // 
            this.Order_Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Order_Header.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Order_Header.Controls.Add(this.date);
            this.Order_Header.Controls.Add(this.orderProgress);
            this.Order_Header.Controls.Add(this.Order_Controls);
            this.Order_Header.Controls.Add(this.orderNo);
            this.Order_Header.Controls.Add(this.amountToReceive);
            this.Order_Header.Location = new System.Drawing.Point(0, 0);
            this.Order_Header.Name = "Order_Header";
            this.Order_Header.Size = new System.Drawing.Size(741, 97);
            this.Order_Header.TabIndex = 11;
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(468, 75);
            this.date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(19, 14);
            this.date.TabIndex = 16;
            this.date.Text = "...";
            // 
            // orderProgress
            // 
            this.orderProgress.AutoSize = true;
            this.orderProgress.Location = new System.Drawing.Point(9, 6);
            this.orderProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.orderProgress.Name = "orderProgress";
            this.orderProgress.Size = new System.Drawing.Size(23, 18);
            this.orderProgress.TabIndex = 13;
            this.orderProgress.Text = "...";
            // 
            // Order_Controls
            // 
            this.Order_Controls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Order_Controls.AutoSize = true;
            this.Order_Controls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Order_Controls.BackColor = System.Drawing.Color.Transparent;
            this.Order_Controls.Controls.Add(this.Accept_Order);
            this.Order_Controls.Controls.Add(this.pn);
            this.Order_Controls.Controls.Add(this.Send_Notifcation);
            this.Order_Controls.Controls.Add(this.Cancel_Order);
            this.Order_Controls.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.Order_Controls.Location = new System.Drawing.Point(70, 36);
            this.Order_Controls.Name = "Order_Controls";
            this.Order_Controls.Size = new System.Drawing.Size(651, 36);
            this.Order_Controls.TabIndex = 12;
            this.Order_Controls.Visible = false;
            // 
            // pn
            // 
            this.pn.Controls.Add(this.button4);
            this.pn.Controls.Add(this.Time);
            this.pn.Controls.Add(this.button3);
            this.pn.Location = new System.Drawing.Point(363, 3);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(188, 30);
            this.pn.TabIndex = 11;
            this.pn.Visible = false;
            // 
            // Send_Notifcation
            // 
            this.Send_Notifcation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Send_Notifcation.AutoSize = true;
            this.Send_Notifcation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Send_Notifcation.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Notifcation.Location = new System.Drawing.Point(132, 4);
            this.Send_Notifcation.Margin = new System.Windows.Forms.Padding(4);
            this.Send_Notifcation.Name = "Send_Notifcation";
            this.Send_Notifcation.Size = new System.Drawing.Size(224, 26);
            this.Send_Notifcation.TabIndex = 12;
            this.Send_Notifcation.Text = "Send Notification of Completion";
            this.Send_Notifcation.UseVisualStyleBackColor = true;
            this.Send_Notifcation.Visible = false;
            // 
            // Details_Items
            // 
            this.Details_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Details_Items.AutoSize = true;
            this.Details_Items.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Details_Items.Location = new System.Drawing.Point(0, 103);
            this.Details_Items.Name = "Details_Items";
            this.Details_Items.Size = new System.Drawing.Size(741, 91);
            this.Details_Items.TabIndex = 16;
            this.Details_Items.WrapContents = false;
            // 
            // Order_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.Details_Items);
            this.Controls.Add(this.Order_Header);
            this.Controls.Add(this.O_modifiers);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Order_Details";
            this.Size = new System.Drawing.Size(741, 197);
            this.Load += new System.EventHandler(this.Order_Item_Load);
            this.Order_Header.ResumeLayout(false);
            this.Order_Header.PerformLayout();
            this.Order_Controls.ResumeLayout(false);
            this.Order_Controls.PerformLayout();
            this.pn.ResumeLayout(false);
            this.pn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.FlowLayoutPanel O_modifiers;
        internal System.Windows.Forms.Label orderNo;
        internal System.Windows.Forms.Label amountToReceive;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Panel Order_Header;
        internal System.Windows.Forms.Button Accept_Order;
        internal System.Windows.Forms.Button Cancel_Order;
        internal System.Windows.Forms.TextBox Time;
        internal System.Windows.Forms.FlowLayoutPanel Order_Controls;
        internal System.Windows.Forms.Panel pn;
        internal System.Windows.Forms.Button Send_Notifcation;
        internal System.Windows.Forms.Label date;
        internal System.Windows.Forms.Label orderProgress;
        internal System.Windows.Forms.FlowLayoutPanel Details_Items;
    }
}
