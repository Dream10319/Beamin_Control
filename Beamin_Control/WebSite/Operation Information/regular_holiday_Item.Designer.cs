namespace Beamin_Control.WebSite.Operation_Information
{
    partial class regular_holiday_Item
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
            this.cycle = new System.Windows.Forms.ComboBox();
            this.Day = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cycle
            // 
            this.cycle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cycle.FormattingEnabled = true;
            this.cycle.Location = new System.Drawing.Point(10, 4);
            this.cycle.Name = "cycle";
            this.cycle.Size = new System.Drawing.Size(203, 26);
            this.cycle.TabIndex = 0;
            // 
            // Day
            // 
            this.Day.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Day.FormattingEnabled = true;
            this.Day.Location = new System.Drawing.Point(230, 4);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(203, 26);
            this.Day.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.AutoSize = true;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(467, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // regular_holiday_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.cycle);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "regular_holiday_Item";
            this.Size = new System.Drawing.Size(554, 35);
            this.Load += new System.EventHandler(this.regular_holiday_Item_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cycle;
        internal System.Windows.Forms.ComboBox Day;
        private System.Windows.Forms.Button button1;
    }
}
