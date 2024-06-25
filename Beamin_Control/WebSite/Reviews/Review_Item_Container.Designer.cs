namespace Beamin_Control.WebSite.Reviews
{
    partial class Review_Item_Container
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
            this.Items_List = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Items_List
            // 
            this.Items_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Items_List.AutoSize = true;
            this.Items_List.Location = new System.Drawing.Point(0, 0);
            this.Items_List.Margin = new System.Windows.Forms.Padding(0);
            this.Items_List.MinimumSize = new System.Drawing.Size(283, 27);
            this.Items_List.Name = "Items_List";
            this.Items_List.Size = new System.Drawing.Size(283, 27);
            this.Items_List.TabIndex = 16;
            this.Items_List.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Items_List_ControlAdded);
            // 
            // Review_Item_Container
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Items_List);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(0, 4, 0, 10);
            this.Name = "Review_Item_Container";
            this.Size = new System.Drawing.Size(283, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.FlowLayoutPanel Items_List;
    }
}
