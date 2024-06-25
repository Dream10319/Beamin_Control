using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.App_Login
{
    public partial class Delete_Devices : Form
    {
        public Delete_Devices()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in this.listView1.Items)
            {

                if(it.Checked == true) { this.DialogResult = DialogResult.OK; }
            }
        }
    }

   public class Device_Tag
    {
        public string deviceNo { get; set; }
        public string deviceToken { get; set; }
        public string merchantNo { get; set; }
    }

}
