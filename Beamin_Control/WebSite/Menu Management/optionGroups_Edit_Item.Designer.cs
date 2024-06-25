namespace Beamin_Control.WebSite.Menu_Management
{
    partial class optionGroups_Edit_Item
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
            this.Option_Name = new System.Windows.Forms.Label();
            this.Option_Price = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Option_Name
            // 
            this.Option_Name.AutoSize = true;
            this.Option_Name.Location = new System.Drawing.Point(15, 5);
            this.Option_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Option_Name.Name = "Option_Name";
            this.Option_Name.Size = new System.Drawing.Size(23, 18);
            this.Option_Name.TabIndex = 0;
            this.Option_Name.Text = "...";
            // 
            // Option_Price
            // 
            this.Option_Price.AutoSize = true;
            this.Option_Price.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Option_Price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Option_Price.Location = new System.Drawing.Point(27, 27);
            this.Option_Price.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Option_Price.Name = "Option_Price";
            this.Option_Price.Size = new System.Drawing.Size(19, 14);
            this.Option_Price.TabIndex = 1;
            this.Option_Price.Text = "...";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(209, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sold Out";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(298, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Hiding";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // optionGroups_Edit_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Option_Price);
            this.Controls.Add(this.Option_Name);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "optionGroups_Edit_Item";
            this.Size = new System.Drawing.Size(396, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Option_Name;
        internal System.Windows.Forms.Label Option_Price;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button2;
    }
}
