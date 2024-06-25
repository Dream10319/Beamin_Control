namespace Beamin_Control.Controls
{
    partial class Order_Details_Panel
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
            this.Panel_Name = new System.Windows.Forms.Label();
            this.Items_Container = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Panel_Name
            // 
            this.Panel_Name.AutoSize = true;
            this.Panel_Name.Location = new System.Drawing.Point(15, 9);
            this.Panel_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Panel_Name.Name = "Panel_Name";
            this.Panel_Name.Size = new System.Drawing.Size(23, 18);
            this.Panel_Name.TabIndex = 0;
            this.Panel_Name.Text = "...";
            // 
            // Items_Container
            // 
            this.Items_Container.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Items_Container.AutoSize = true;
            this.Items_Container.BackColor = System.Drawing.Color.White;
            this.Items_Container.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Items_Container.Location = new System.Drawing.Point(5, 39);
            this.Items_Container.MinimumSize = new System.Drawing.Size(741, 30);
            this.Items_Container.Name = "Items_Container";
            this.Items_Container.Size = new System.Drawing.Size(741, 30);
            this.Items_Container.TabIndex = 2;
            // 
            // Order_Details_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.Items_Container);
            this.Controls.Add(this.Panel_Name);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Order_Details_Panel";
            this.Size = new System.Drawing.Size(750, 82);
            this.Load += new System.EventHandler(this.Order_Details_Panel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Panel_Name;
        internal System.Windows.Forms.FlowLayoutPanel Items_Container;
    }
}
