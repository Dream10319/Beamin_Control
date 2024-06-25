using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Out_of_Stock
{
    public partial class OptionGroup_Item : UserControl
    {
        public OptionGroup_Item()
        {
            InitializeComponent();
            //this.Menu_Items.BackColor = Color.Red;
            //this.Menu_Items.MinimumSize = new Size(this.flowLayoutPanel1.Width, this.Menu_Items.Height);
            //this.Menu_Items.MaximumSize = new Size(this.flowLayoutPanel1.Width, 0);
            //this.Menu_Items.Size = new Size(this.Width - 6, this.Menu_Items.Height);


        }

        private void Menu_Items_Paint( object sender, PaintEventArgs e )
        {

        }

        private void OptionGroup_Item_Load( object sender, EventArgs e )
        {

        }

        private void flowLayoutPanel1_Resize( object sender, EventArgs e )
        {
            //        this.Menu_Items.MaximumSize = new Size(this.Width - 6, 0);
            //this.Menu_Items.Size = new Size(this.Width - 6, this.Menu_Items.Height);
        }

        private void OptionGroup_Item_Resize( object sender, EventArgs e )
        {
            //this.Menu_Items.MaximumSize = new Size(this.Width - 6, 0);
            //this.Menu_Items.Size = new Size(this.Width - 6, this.Menu_Items.Height);
        }

        private void Menu_Items_ControlAdded( object sender, ControlEventArgs e )
        {
            e.Control.Padding = new Padding(0);
            e.Control.Margin = new Padding(0);
            e.Control.Size = new Size(this.Menu_Items.Width - 6, e.Control.Height);

        }
    }
}
