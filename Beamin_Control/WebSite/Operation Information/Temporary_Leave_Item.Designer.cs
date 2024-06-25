namespace Beamin_Control.WebSite.Operation_Information
{
    partial class Temporary_Leave_Item
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
            this.button1 = new System.Windows.Forms.Button();
            this.Start_Date = new System.Windows.Forms.DateTimePicker();
            this.End_Date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // Start_Date
            // 
            this.Start_Date.CustomFormat = "yyyy - MM - dd";
            this.Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Start_Date.Location = new System.Drawing.Point(10, 4);
            this.Start_Date.Name = "Start_Date";
            this.Start_Date.Size = new System.Drawing.Size(175, 26);
            this.Start_Date.TabIndex = 3;
            // 
            // End_Date
            // 
            this.End_Date.CustomFormat = "yyyy - MM - dd";
            this.End_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.End_Date.Location = new System.Drawing.Point(223, 4);
            this.End_Date.Name = "End_Date";
            this.End_Date.Size = new System.Drawing.Size(175, 26);
            this.End_Date.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "To";
            // 
            // Temporary_Leave_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.End_Date);
            this.Controls.Add(this.Start_Date);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Temporary_Leave_Item";
            this.Size = new System.Drawing.Size(554, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.DateTimePicker Start_Date;
        internal System.Windows.Forms.DateTimePicker End_Date;
        private System.Windows.Forms.Label label1;
    }
}
