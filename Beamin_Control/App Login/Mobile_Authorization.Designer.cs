namespace Beamin_Control
{
    partial class Mobile_Authorization
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
            this.mobile = new System.Windows.Forms.TextBox();
            this.send_code = new System.Windows.Forms.Button();
            this.Login_btn = new System.Windows.Forms.Button();
            this.auth_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mobile Number";
            // 
            // mobile
            // 
            this.mobile.Location = new System.Drawing.Point(33, 64);
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(213, 26);
            this.mobile.TabIndex = 1;
            this.mobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // send_code
            // 
            this.send_code.Location = new System.Drawing.Point(252, 62);
            this.send_code.Name = "send_code";
            this.send_code.Size = new System.Drawing.Size(110, 28);
            this.send_code.TabIndex = 2;
            this.send_code.Text = "Send Code";
            this.send_code.UseVisualStyleBackColor = true;
            this.send_code.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login_btn
            // 
            this.Login_btn.Location = new System.Drawing.Point(106, 164);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(163, 51);
            this.Login_btn.TabIndex = 5;
            this.Login_btn.Text = "Login";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // auth_code
            // 
            this.auth_code.Location = new System.Drawing.Point(33, 120);
            this.auth_code.Name = "auth_code";
            this.auth_code.Size = new System.Drawing.Size(329, 26);
            this.auth_code.TabIndex = 4;
            this.auth_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Code";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Mobile_Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.auth_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.send_code);
            this.Controls.Add(this.mobile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mobile_Authorization";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mobile Authorization";
            this.Load += new System.EventHandler(this.Mobile_Authorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mobile;
        private System.Windows.Forms.Button send_code;
        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.TextBox auth_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}