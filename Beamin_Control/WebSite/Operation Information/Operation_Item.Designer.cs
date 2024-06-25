namespace Beamin_Control.WebSite.Operation_Information
{
    partial class Operation_Item
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
            this.Change_btn = new System.Windows.Forms.Button();
            this.Item_Name = new System.Windows.Forms.Label();
            this.Operation_Values = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Change_btn
            // 
            this.Change_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Change_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Change_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Change_btn.Location = new System.Drawing.Point(606, 12);
            this.Change_btn.Name = "Change_btn";
            this.Change_btn.Size = new System.Drawing.Size(119, 37);
            this.Change_btn.TabIndex = 5;
            this.Change_btn.Text = "Change";
            this.Change_btn.UseVisualStyleBackColor = true;
            // 
            // Item_Name
            // 
            this.Item_Name.AutoSize = true;
            this.Item_Name.Location = new System.Drawing.Point(26, 21);
            this.Item_Name.Name = "Item_Name";
            this.Item_Name.Size = new System.Drawing.Size(23, 18);
            this.Item_Name.TabIndex = 4;
            this.Item_Name.Text = "...";
            // 
            // Operation_Values
            // 
            this.Operation_Values.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Operation_Values.AutoSize = true;
            this.Operation_Values.Location = new System.Drawing.Point(19, 55);
            this.Operation_Values.Name = "Operation_Values";
            this.Operation_Values.Size = new System.Drawing.Size(706, 90);
            this.Operation_Values.TabIndex = 6;
            // 
            // Operation_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Operation_Values);
            this.Controls.Add(this.Change_btn);
            this.Controls.Add(this.Item_Name);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Operation_Item";
            this.Size = new System.Drawing.Size(742, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Change_btn;
        internal System.Windows.Forms.Label Item_Name;
        internal System.Windows.Forms.FlowLayoutPanel Operation_Values;
    }
}
