namespace Beamin_Control.WebSite.Reviews
{
    partial class Review_Item
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
            this.rating = new System.Windows.Forms.Label();
            this.memberNickname = new System.Windows.Forms.Label();
            this.Main_Container = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rating
            // 
            this.rating.AutoSize = true;
            this.rating.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.rating.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rating.Location = new System.Drawing.Point(26, 44);
            this.rating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rating.Name = "rating";
            this.rating.Size = new System.Drawing.Size(45, 16);
            this.rating.TabIndex = 15;
            this.rating.Text = "label1";
            // 
            // memberNickname
            // 
            this.memberNickname.AutoSize = true;
            this.memberNickname.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberNickname.Location = new System.Drawing.Point(6, 15);
            this.memberNickname.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.memberNickname.Name = "memberNickname";
            this.memberNickname.Size = new System.Drawing.Size(55, 18);
            this.memberNickname.TabIndex = 14;
            this.memberNickname.Text = "label1";
            // 
            // Main_Container
            // 
            this.Main_Container.AutoSize = true;
            this.Main_Container.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Main_Container.BackColor = System.Drawing.SystemColors.Control;
            this.Main_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Container.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Main_Container.Location = new System.Drawing.Point(104, 4);
            this.Main_Container.Margin = new System.Windows.Forms.Padding(4);
            this.Main_Container.Name = "Main_Container";
            this.Main_Container.Size = new System.Drawing.Size(1, 58);
            this.Main_Container.TabIndex = 16;
            this.Main_Container.WrapContents = false;
            this.Main_Container.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Main_Container_ControlAdded);
            this.Main_Container.Resize += new System.EventHandler(this.Main_Container_Resize);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Main_Container, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(108, 66);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.memberNickname);
            this.panel1.Controls.Add(this.rating);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 60);
            this.panel1.TabIndex = 0;
            // 
            // Review_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.Name = "Review_Item";
            this.Size = new System.Drawing.Size(108, 66);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label rating;
        internal System.Windows.Forms.Label memberNickname;
        internal System.Windows.Forms.FlowLayoutPanel Main_Container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
