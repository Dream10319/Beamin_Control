using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control
{
    public partial class Login_frm : Form
    {

   
        public Login_frm()
        {
            InitializeComponent();
            this.Text = Program.Language.De[2203];
            this.label1.Text = Program.Language.De[2200];
            this.label2.Text = Program.Language.De[2201];
            this.button1.Text = Program.Language.De[2202];
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.password.UseSystemPasswordChar = ((CheckBox)(sender)).Checked;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            //if ( string.IsNullOrEmpty(this.username.Text) && string.IsNullOrEmpty(this.username.Text) )
            //{
            //    //this.DialogResult = DialogResult.OK;
            //    return;
            //}

        }

        private void Login_frm_Load( object sender, EventArgs e )
        {
#if Test_With_Proxy



#endif
        }
    }
}
