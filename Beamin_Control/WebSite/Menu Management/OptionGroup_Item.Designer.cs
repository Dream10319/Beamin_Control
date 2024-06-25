namespace Beamin_Control.WebSite.Out_of_Stock
{
    partial class OptionGroup_Item
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
            this.number_of_options = new System.Windows.Forms.Label();
            this.Connection_menu = new System.Windows.Forms.Label();
            this.Menu_Items = new System.Windows.Forms.FlowLayoutPanel();
            this.I_Name = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // number_of_options
            // 
            this.number_of_options.AutoSize = true;
            this.number_of_options.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.number_of_options.Location = new System.Drawing.Point(30, 39);
            this.number_of_options.Margin = new System.Windows.Forms.Padding(30, 0, 3, 5);
            this.number_of_options.Name = "number_of_options";
            this.number_of_options.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.number_of_options.Size = new System.Drawing.Size(65, 24);
            this.number_of_options.TabIndex = 7;
            this.number_of_options.Text = "label1";
            // 
            // Connection_menu
            // 
            this.Connection_menu.AutoSize = true;
            this.Connection_menu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Connection_menu.Location = new System.Drawing.Point(30, 68);
            this.Connection_menu.Margin = new System.Windows.Forms.Padding(30, 0, 3, 10);
            this.Connection_menu.Name = "Connection_menu";
            this.Connection_menu.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Connection_menu.Size = new System.Drawing.Size(65, 24);
            this.Connection_menu.TabIndex = 6;
            this.Connection_menu.Text = "label1";
            // 
            // Menu_Items
            // 
            this.Menu_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_Items.AutoSize = true;
            this.Menu_Items.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Menu_Items.Location = new System.Drawing.Point(3, 105);
            this.Menu_Items.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.Menu_Items.MinimumSize = new System.Drawing.Size(393, 47);
            this.Menu_Items.Name = "Menu_Items";
            this.Menu_Items.Size = new System.Drawing.Size(393, 47);
            this.Menu_Items.TabIndex = 5;
            this.Menu_Items.WrapContents = false;
            this.Menu_Items.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Menu_Items_ControlAdded);
            // 
            // I_Name
            // 
            this.I_Name.AutoSize = true;
            this.I_Name.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.I_Name.Location = new System.Drawing.Point(3, 5);
            this.I_Name.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
            this.I_Name.Name = "I_Name";
            this.I_Name.Padding = new System.Windows.Forms.Padding(3);
            this.I_Name.Size = new System.Drawing.Size(61, 24);
            this.I_Name.TabIndex = 4;
            this.I_Name.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.I_Name);
            this.flowLayoutPanel1.Controls.Add(this.number_of_options);
            this.flowLayoutPanel1.Controls.Add(this.Connection_menu);
            this.flowLayoutPanel1.Controls.Add(this.Menu_Items);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(399, 157);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // OptionGroup_Item
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 94);
            this.Name = "OptionGroup_Item";
            this.Size = new System.Drawing.Size(399, 157);
            this.Resize += new System.EventHandler(this.OptionGroup_Item_Resize);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label number_of_options;
        internal System.Windows.Forms.Label Connection_menu;
        internal System.Windows.Forms.FlowLayoutPanel Menu_Items;
        internal System.Windows.Forms.Label I_Name;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
