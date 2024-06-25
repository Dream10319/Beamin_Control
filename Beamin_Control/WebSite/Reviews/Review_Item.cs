using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Reviews
{
    public partial class Review_Item : UserControl
    {
        public Review_Item()
        {
            InitializeComponent();
            this.tableLayoutPanel1.MinimumSize = new Size(this.Width - 6, 0);
            this.tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Resize += Review_Item_Resize;
        }

        private void Review_Item_Resize( object sender, EventArgs e )
        {
            //this.MaximumSize = new Size(this.Width - 6, 0);
            //this.MinimumSize = new Size(this.Width - 6, 0);
            //this.tableLayoutPanel1.Size = new Size(this.Width - 6, this.Height - 6);

            //this.tableLayoutPanel1.BackColor = Color.Aqua;
        }

        private void Main_Container_ControlAdded( object sender, ControlEventArgs e )
        {
            
            e.Control.MinimumSize = new Size(this.Main_Container.Width - 9, 0);
            e.Control.MaximumSize = new Size(this.Main_Container.Width - 9, 0);
        }

        private void Main_Container_Resize( object sender, EventArgs e )
        {
            //this.Main_Container.SuspendLayout();
          
            //foreach ( Control cn in this.Main_Container.Controls )
            //{
              
            //    cn.MinimumSize = new Size(this.Main_Container.Width - 9, 0);
            //    cn.MaximumSize = new Size(this.Main_Container.Width - 9, 0);
            //    cn.Size = new Size(this.Main_Container.Width - 9, cn.Height);

            //}
            //this.Main_Container.ResumeLayout();
        }
    }
}
