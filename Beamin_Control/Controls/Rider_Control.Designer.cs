namespace Beamin_Control.Controls
{
    partial class Rider_Control
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
            this.button1 = new System.Windows.Forms.Button();
            this.rider_ProgressBar2 = new Beamin_Control.Controls.Rider_ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.Rider_Location_lb = new System.Windows.Forms.Label();
            this.Minutes_Until_Rider_Pickup_lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(180, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(311, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Update Rider Location Information";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rider_ProgressBar2
            // 
            this.rider_ProgressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rider_ProgressBar2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rider_ProgressBar2.Location = new System.Drawing.Point(8, 75);
            this.rider_ProgressBar2.Name = "rider_ProgressBar2";
            this.rider_ProgressBar2.Size = new System.Drawing.Size(657, 64);
            this.rider_ProgressBar2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "The Rider Is on His Way";
            // 
            // Rider_Location_lb
            // 
            this.Rider_Location_lb.AutoSize = true;
            this.Rider_Location_lb.Location = new System.Drawing.Point(41, 30);
            this.Rider_Location_lb.Name = "Rider_Location_lb";
            this.Rider_Location_lb.Size = new System.Drawing.Size(23, 18);
            this.Rider_Location_lb.TabIndex = 3;
            this.Rider_Location_lb.Text = "...";
            // 
            // Minutes_Until_Rider_Pickup_lb
            // 
            this.Minutes_Until_Rider_Pickup_lb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minutes_Until_Rider_Pickup_lb.AutoEllipsis = true;
            this.Minutes_Until_Rider_Pickup_lb.AutoSize = true;
            this.Minutes_Until_Rider_Pickup_lb.BackColor = System.Drawing.Color.LightSlateGray;
            this.Minutes_Until_Rider_Pickup_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minutes_Until_Rider_Pickup_lb.Location = new System.Drawing.Point(384, 9);
            this.Minutes_Until_Rider_Pickup_lb.Name = "Minutes_Until_Rider_Pickup_lb";
            this.Minutes_Until_Rider_Pickup_lb.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.Minutes_Until_Rider_Pickup_lb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Minutes_Until_Rider_Pickup_lb.Size = new System.Drawing.Size(60, 43);
            this.Minutes_Until_Rider_Pickup_lb.TabIndex = 4;
            this.Minutes_Until_Rider_Pickup_lb.Text = "...";
            this.Minutes_Until_Rider_Pickup_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Minutes_Until_Rider_Pickup_lb.UseCompatibleTextRendering = true;
            // 
            // Rider_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Minutes_Until_Rider_Pickup_lb);
            this.Controls.Add(this.Rider_Location_lb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rider_ProgressBar2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Rider_Control";
            this.Size = new System.Drawing.Size(673, 230);
            this.Load += new System.EventHandler(this.Rider_Control_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Rider_Location_lb;
        private System.Windows.Forms.Label Minutes_Until_Rider_Pickup_lb;
        internal Rider_ProgressBar rider_ProgressBar2;
    }
}
