using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Menu_Management
{
    public partial class Group_Item : UserControl
    {
        public Group_Item()
        {
            InitializeComponent();
            //this.Menu_Items.BackColor = Color.Red;
            //this.Menu_Items.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        }

        private void Menu_Items_ControlAdded( object sender, ControlEventArgs e )
        {
            //e.Control.MinimumSize = new Size(this.Menu_Items.Width - 6, 0);
            //e.Control.MaximumSize = new Size(this.Menu_Items.Width - 6, 0);
            //e.Control.Size = new Size(this.Menu_Items.Width - 6, e.Control.Height);
            //e.Control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //e.Control.Size = new Size(this.Menu_Items.Width - 6, 0);

        }

        private void Group_Item_Load( object sender, EventArgs e )
        {
        }

        private void Group_Item_Resize( object sender, EventArgs e )
        {
            this.I_Name.MaximumSize = new Size(this.Width-6, 0);
            this.I_Name.Size  = new Size(this.Width-6, this.I_Name.Height );


            foreach (Control  cn in this.Menu_Items.Controls)
            {
                cn.Width = this.Menu_Items.Width - 16;
                cn.Margin = new Padding(5);

            }

        }
    }
}
