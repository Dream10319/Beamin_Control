namespace Beamin_Control.WebSite.Operation_Information
{
    partial class Operation_Value
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
            this.O_Value = new System.Windows.Forms.Label();
            this.O_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // O_Value
            // 
            this.O_Value.AutoSize = true;
            this.O_Value.Location = new System.Drawing.Point(40, 29);
            this.O_Value.Name = "O_Value";
            this.O_Value.Size = new System.Drawing.Size(23, 18);
            this.O_Value.TabIndex = 6;
            this.O_Value.Text = "...";
            // 
            // O_Title
            // 
            this.O_Title.AutoSize = true;
            this.O_Title.Location = new System.Drawing.Point(40, 5);
            this.O_Title.Name = "O_Title";
            this.O_Title.Size = new System.Drawing.Size(23, 18);
            this.O_Title.TabIndex = 5;
            this.O_Title.Text = "...";
            // 
            // Operation_Value
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.O_Value);
            this.Controls.Add(this.O_Title);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Operation_Value";
            this.Size = new System.Drawing.Size(698, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label O_Value;
        internal System.Windows.Forms.Label O_Title;
    }
}
