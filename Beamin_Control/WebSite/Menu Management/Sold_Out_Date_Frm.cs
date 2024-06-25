using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Out_of_Stock
{
    public partial class Sold_Out_Date_Frm : Form
    {
        public Sold_Out_Date_Frm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged( object sender, EventArgs e )
        {
            //if(radioButton1.Checked == true )
            //{
            //    comboBox1.Enabled = true;
            //}
            //else
            //{
            //    comboBox1.Enabled = false;

            //}
        }

        private void radioButton2_CheckedChanged( object sender, EventArgs e )
        {
            //if ( radioButton2.Checked == true )
            //{
            //    dateTimePicker1.Enabled = true;
            //}
            //else
            //{
            //    dateTimePicker1.Enabled = false;

            //}
        }

        private void button1_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Sold_Out_Date_Frm_Load( object sender, EventArgs e )
        {

        }
    }


    public  class Time_Item
    {
        public string Date_Time { get; set; }
        public override string ToString()
        {

            //return String.Format("{0:yy}. {0:MM}. {0:dd} ({0:ddd}) {0:hh}:{0:mm tt}", DateTime.Parse (Date_Time)).ToUpper();
            //return DateTime.Parse(Date_Time).ToString ("yy, MM. dd (ddd) hh:mm tt",Web_Helper.Culture);
            return DateTime.Parse(Date_Time).ToString ("yy, MM. dd (ddd) hh:mm tt", Web_Helper.Culture);

        }
    }
}
