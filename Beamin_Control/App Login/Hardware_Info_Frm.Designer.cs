namespace Beamin_Control.App_Login
{
    partial class Hardware_Info_Frm
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
            this.os_lb = new System.Windows.Forms.Label();
            this.deviceName_lb = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.deviceHddSerial = new System.Windows.Forms.TextBox();
            this.deviceMotherBoardId = new System.Windows.Forms.TextBox();
            this.deviceMacAddress = new System.Windows.Forms.TextBox();
            this.deviceHddSerial_lb = new System.Windows.Forms.Label();
            this.deviceName = new System.Windows.Forms.TextBox();
            this.deviceMotherBoardId_lb = new System.Windows.Forms.Label();
            this.deviceMacAddress_lb = new System.Windows.Forms.Label();
            this.os = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.My_PC = new System.Windows.Forms.Button();
            this.Your_PC = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // os_lb
            // 
            this.os_lb.AutoSize = true;
            this.os_lb.Location = new System.Drawing.Point(5, 7);
            this.os_lb.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.os_lb.Name = "os_lb";
            this.os_lb.Size = new System.Drawing.Size(142, 18);
            this.os_lb.TabIndex = 0;
            this.os_lb.Text = "Operating System";
            // 
            // deviceName_lb
            // 
            this.deviceName_lb.AutoSize = true;
            this.deviceName_lb.Location = new System.Drawing.Point(5, 39);
            this.deviceName_lb.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.deviceName_lb.Name = "deviceName_lb";
            this.deviceName_lb.Size = new System.Drawing.Size(106, 18);
            this.deviceName_lb.TabIndex = 1;
            this.deviceName_lb.Text = "Device Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.deviceHddSerial, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.deviceMotherBoardId, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.deviceMacAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.deviceHddSerial_lb, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.deviceName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.deviceMotherBoardId_lb, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.os_lb, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.deviceName_lb, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.deviceMacAddress_lb, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.os, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 163);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // deviceHddSerial
            // 
            this.deviceHddSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceHddSerial.Location = new System.Drawing.Point(155, 131);
            this.deviceHddSerial.Name = "deviceHddSerial";
            this.deviceHddSerial.ReadOnly = true;
            this.deviceHddSerial.Size = new System.Drawing.Size(389, 26);
            this.deviceHddSerial.TabIndex = 9;
            // 
            // deviceMotherBoardId
            // 
            this.deviceMotherBoardId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceMotherBoardId.Location = new System.Drawing.Point(155, 99);
            this.deviceMotherBoardId.Name = "deviceMotherBoardId";
            this.deviceMotherBoardId.ReadOnly = true;
            this.deviceMotherBoardId.Size = new System.Drawing.Size(389, 26);
            this.deviceMotherBoardId.TabIndex = 8;
            // 
            // deviceMacAddress
            // 
            this.deviceMacAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceMacAddress.Location = new System.Drawing.Point(155, 67);
            this.deviceMacAddress.Name = "deviceMacAddress";
            this.deviceMacAddress.ReadOnly = true;
            this.deviceMacAddress.Size = new System.Drawing.Size(389, 26);
            this.deviceMacAddress.TabIndex = 7;
            // 
            // deviceHddSerial_lb
            // 
            this.deviceHddSerial_lb.AutoSize = true;
            this.deviceHddSerial_lb.Location = new System.Drawing.Point(5, 135);
            this.deviceHddSerial_lb.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.deviceHddSerial_lb.Name = "deviceHddSerial_lb";
            this.deviceHddSerial_lb.Size = new System.Drawing.Size(124, 18);
            this.deviceHddSerial_lb.TabIndex = 6;
            this.deviceHddSerial_lb.Text = "Harddisk Serial";
            // 
            // deviceName
            // 
            this.deviceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceName.Location = new System.Drawing.Point(155, 35);
            this.deviceName.Name = "deviceName";
            this.deviceName.ReadOnly = true;
            this.deviceName.Size = new System.Drawing.Size(389, 26);
            this.deviceName.TabIndex = 2;
            // 
            // deviceMotherBoardId_lb
            // 
            this.deviceMotherBoardId_lb.AutoSize = true;
            this.deviceMotherBoardId_lb.Location = new System.Drawing.Point(5, 103);
            this.deviceMotherBoardId_lb.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.deviceMotherBoardId_lb.Name = "deviceMotherBoardId_lb";
            this.deviceMotherBoardId_lb.Size = new System.Drawing.Size(127, 18);
            this.deviceMotherBoardId_lb.TabIndex = 5;
            this.deviceMotherBoardId_lb.Text = "MotherBoard ID";
            // 
            // deviceMacAddress_lb
            // 
            this.deviceMacAddress_lb.AutoSize = true;
            this.deviceMacAddress_lb.Location = new System.Drawing.Point(5, 71);
            this.deviceMacAddress_lb.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.deviceMacAddress_lb.Name = "deviceMacAddress_lb";
            this.deviceMacAddress_lb.Size = new System.Drawing.Size(102, 18);
            this.deviceMacAddress_lb.TabIndex = 3;
            this.deviceMacAddress_lb.Text = "Mac Address";
            // 
            // os
            // 
            this.os.Dock = System.Windows.Forms.DockStyle.Fill;
            this.os.Location = new System.Drawing.Point(155, 3);
            this.os.Name = "os";
            this.os.ReadOnly = true;
            this.os.Size = new System.Drawing.Size(389, 26);
            this.os.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // My_PC
            // 
            this.My_PC.Location = new System.Drawing.Point(12, 12);
            this.My_PC.Name = "My_PC";
            this.My_PC.Size = new System.Drawing.Size(245, 35);
            this.My_PC.TabIndex = 4;
            this.My_PC.Text = "Mohamed\'s PC Information";
            this.My_PC.UseVisualStyleBackColor = true;
            this.My_PC.Click += new System.EventHandler(this.My_PC_Click);
            // 
            // Your_PC
            // 
            this.Your_PC.Location = new System.Drawing.Point(314, 12);
            this.Your_PC.Name = "Your_PC";
            this.Your_PC.Size = new System.Drawing.Size(245, 35);
            this.Your_PC.TabIndex = 5;
            this.Your_PC.Text = "Your Real PC Information";
            this.Your_PC.UseVisualStyleBackColor = true;
            this.Your_PC.Click += new System.EventHandler(this.Your_PC_Click);
            // 
            // Hardware_Info_Frm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 319);
            this.Controls.Add(this.Your_PC);
            this.Controls.Add(this.My_PC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Hardware_Info_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardware_Info_Frm";
            this.Load += new System.EventHandler(this.Hardware_Info_Frm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label os_lb;
        private System.Windows.Forms.Label deviceName_lb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox os;
        private System.Windows.Forms.Label deviceMacAddress_lb;
        private System.Windows.Forms.Label deviceMotherBoardId_lb;
        private System.Windows.Forms.Label deviceHddSerial_lb;
        private System.Windows.Forms.TextBox deviceHddSerial;
        private System.Windows.Forms.TextBox deviceMotherBoardId;
        private System.Windows.Forms.TextBox deviceMacAddress;
        private System.Windows.Forms.TextBox deviceName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button My_PC;
        private System.Windows.Forms.Button Your_PC;
    }
}