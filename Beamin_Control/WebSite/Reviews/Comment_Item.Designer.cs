namespace Beamin_Control.WebSite.Reviews
{
    partial class Comment_Item
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contents = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.managerNickname = new System.Windows.Forms.Label();
            this.createdDate = new System.Windows.Forms.Label();
            this.Comment_buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.Comment_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.contents, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Comment_buttons, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(516, 89);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // contents
            // 
            this.contents.AutoSize = true;
            this.contents.Location = new System.Drawing.Point(3, 28);
            this.contents.Name = "contents";
            this.contents.Size = new System.Drawing.Size(55, 18);
            this.contents.TabIndex = 2;
            this.contents.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.managerNickname);
            this.flowLayoutPanel1.Controls.Add(this.createdDate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(510, 22);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // managerNickname
            // 
            this.managerNickname.AutoSize = true;
            this.managerNickname.Location = new System.Drawing.Point(3, 0);
            this.managerNickname.Name = "managerNickname";
            this.managerNickname.Size = new System.Drawing.Size(55, 18);
            this.managerNickname.TabIndex = 0;
            this.managerNickname.Text = "label2";
            // 
            // createdDate
            // 
            this.createdDate.AutoSize = true;
            this.createdDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.createdDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.createdDate.Location = new System.Drawing.Point(71, 3);
            this.createdDate.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.createdDate.Name = "createdDate";
            this.createdDate.Size = new System.Drawing.Size(45, 16);
            this.createdDate.TabIndex = 14;
            this.createdDate.Text = "label1";
            // 
            // Comment_buttons
            // 
            this.Comment_buttons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Comment_buttons.AutoSize = true;
            this.Comment_buttons.Controls.Add(this.Delete_btn);
            this.Comment_buttons.Location = new System.Drawing.Point(438, 49);
            this.Comment_buttons.Name = "Comment_buttons";
            this.Comment_buttons.Size = new System.Drawing.Size(75, 36);
            this.Comment_buttons.TabIndex = 4;
            // 
            // Delete_btn
            // 
            this.Delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_btn.AutoSize = true;
            this.Delete_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_btn.ForeColor = System.Drawing.Color.Red;
            this.Delete_btn.Location = new System.Drawing.Point(3, 3);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(69, 30);
            this.Delete_btn.TabIndex = 2;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            // 
            // Comment_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Comment_Item";
            this.Size = new System.Drawing.Size(522, 96);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.Comment_buttons.ResumeLayout(false);
            this.Comment_buttons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Label createdDate;
        internal System.Windows.Forms.Label contents;
        internal System.Windows.Forms.Label managerNickname;
        internal System.Windows.Forms.FlowLayoutPanel Comment_buttons;
        internal System.Windows.Forms.Button Delete_btn;
    }
}
