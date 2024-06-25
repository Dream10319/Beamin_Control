namespace Beamin_Control.WebSite.Menu_Management
{
    partial class Group_Item
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
            this.I_Name = new System.Windows.Forms.Label();
            this.Menu_Items = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // I_Name
            // 
            this.I_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.I_Name.Location = new System.Drawing.Point(2, 2);
            this.I_Name.Name = "I_Name";
            this.I_Name.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.I_Name.Size = new System.Drawing.Size(281, 33);
            this.I_Name.TabIndex = 0;
            this.I_Name.Text = "...";
            // 
            // Menu_Items
            // 
            this.Menu_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_Items.AutoSize = true;
            this.Menu_Items.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Menu_Items.Location = new System.Drawing.Point(0, 35);
            this.Menu_Items.Margin = new System.Windows.Forms.Padding(0);
            this.Menu_Items.Name = "Menu_Items";
            this.Menu_Items.Size = new System.Drawing.Size(372, 21);
            this.Menu_Items.TabIndex = 1;
            this.Menu_Items.WrapContents = false;
            this.Menu_Items.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Menu_Items_ControlAdded);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button1.Location = new System.Drawing.Point(290, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // Group_Item
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Menu_Items);
            this.Controls.Add(this.I_Name);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Group_Item";
            this.Size = new System.Drawing.Size(372, 56);
            this.Resize += new System.EventHandler(this.Group_Item_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label I_Name;
        internal System.Windows.Forms.FlowLayoutPanel Menu_Items;
        private System.Windows.Forms.Button button1;
    }
}
