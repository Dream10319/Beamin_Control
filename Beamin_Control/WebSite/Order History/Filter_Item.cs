using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Order_History
{
    public  class Filter_Item:Label
    {
        public bool _purchaseType;
     public   Filter_Item(bool purchaseType = false)
        {
            //_purchaseType = purchaseType;
            //Label lb = new Label();
           this. AutoSize = true;
            this.Padding = new Padding(3);
            this.Margin = new Padding(3, 2, 3, 0);
            this.BackColor = Color.LightGray;
        }
    }
}
