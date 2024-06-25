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
    public partial class New_Boss_Comment_frm : Form
    {
        public New_Boss_Comment_frm()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            if (!string.IsNullOrEmpty(this.textBox1.Text) )
            {
                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
