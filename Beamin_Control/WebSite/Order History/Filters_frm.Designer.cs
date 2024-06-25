namespace Beamin_Control.WebSite.Order_History
{
    partial class Filters_frm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Shops_List = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Order_Status = new System.Windows.Forms.FlowLayoutPanel();
            this.Payment_Method = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shops";
            // 
            // Shops_List
            // 
            this.Shops_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Shops_List.BackColor = System.Drawing.SystemColors.Window;
            this.Shops_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Shops_List.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shops_List.FormattingEnabled = true;
            this.Shops_List.Location = new System.Drawing.Point(30, 75);
            this.Shops_List.Name = "Shops_List";
            this.Shops_List.Size = new System.Drawing.Size(276, 26);
            this.Shops_List.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Order Status";
            // 
            // Order_Status
            // 
            this.Order_Status.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Order_Status.Location = new System.Drawing.Point(30, 149);
            this.Order_Status.Name = "Order_Status";
            this.Order_Status.Size = new System.Drawing.Size(276, 90);
            this.Order_Status.TabIndex = 6;
            this.Order_Status.WrapContents = false;
            // 
            // Payment_Method
            // 
            this.Payment_Method.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Payment_Method.Location = new System.Drawing.Point(30, 281);
            this.Payment_Method.Name = "Payment_Method";
            this.Payment_Method.Size = new System.Drawing.Size(276, 90);
            this.Payment_Method.TabIndex = 8;
            this.Payment_Method.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Payment Method";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(80, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Filters_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 452);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Payment_Method);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Order_Status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Shops_List);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filters_frm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filters_frm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.FlowLayoutPanel Order_Status;
        internal System.Windows.Forms.FlowLayoutPanel Payment_Method;
        internal System.Windows.Forms.ComboBox Shops_List;
        private System.Windows.Forms.Button button1;
    }
}