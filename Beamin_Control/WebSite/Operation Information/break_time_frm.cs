using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Operation_Information
{
    public partial class break_time_frm : Form
    {
        public break_time_frm()
        {
            InitializeComponent();
        }
        private void break_time_frm_Load(object sender, EventArgs e)
        {
            button1.Text = Program.Language.De[251001];
        }
        private void button1_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
        }

      
    }
}
