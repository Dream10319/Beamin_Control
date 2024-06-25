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
    public partial class Change_Menu_Name_Frm : Form
    {
        public Change_Menu_Name_Frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty (this.textBox1.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
