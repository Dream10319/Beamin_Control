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
    public partial class Review_Item_Container : UserControl
    {
        //public FlowLayoutPanel Main_Panel;
        public Review_Item_Container(string Item_Name= null)
        {
            InitializeComponent();
            //Main_Panel = new FlowLayoutPanel();

            //int location_x = 0;

            if( Item_Name != null )
            {
                
              Label  lb=new Label()
                {
                    Text = Item_Name,
                    Padding = new Padding(0, 5, 0, 3),
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    Location = new Point (0,0),
                    
                } ;

                this.Controls.Add(lb);
                //location_x = lb.Bottom;
                this.Items_List.Location = new Point(0, lb.Bottom + 3);

            }

            //Main_Panel.siz
            //this.Controls.Add(Main_Panel);



        }

        private void Items_List_ControlAdded( object sender, ControlEventArgs e )
        {
            //e.Control.MinimumSize = new Size(this.Items_List.Width - 6, 0);
            //e.Control.MaximumSize = new Size(this.Items_List.Width - 6, 0);
        }
    }
}
