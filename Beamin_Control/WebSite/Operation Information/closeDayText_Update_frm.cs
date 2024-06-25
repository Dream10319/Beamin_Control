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
    public partial class closeDayText_Update_frm : Form
    {
        int _max_length;
        public closeDayText_Update_frm(int max_length)
        {
            InitializeComponent();
            _max_length = max_length;
            this.textBox1.MaxLength = max_length;
            this.label1.Text = string.Format("{0} / {1}", this.textBox1.Text.Length, _max_length);

        }

        private void button1_Click( object sender, EventArgs e )
        {
           
                this.DialogResult = DialogResult.OK;
            
        }

        private void closeDayText_Update_frm_Load( object sender, EventArgs e )
        {
            button1.Text = Program.Language.De[29001];
        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {
            this.label1.Text = string.Format("{0} / {1}", this.textBox1.Text.Length, _max_length);
        }
    }
}
