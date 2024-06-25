using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.Controls
{
    public partial class Order_Details_Panel : UserControl
    {
        public Order_Details_Panel(string Panel_Name)
        {
            InitializeComponent();
            this.Panel_Name.Text = Panel_Name;
        }

        private void Order_Details_Panel_Load(object sender, EventArgs e)
        {
            //if(this.Parent!=null)
            //{
            this.Items_Container.FlowDirection = FlowDirection.TopDown;
            this.Items_Container.WrapContents = false;

                //this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                //this.Items_Container.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //}
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //this.Items_Container.Width = this.Width ;

        }
    }
}
