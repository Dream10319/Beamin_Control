using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Operation_Information
{
    public partial class Temporary_Leave_Item : UserControl
    {
        public long temporaryDayOffSeq;
        public Temporary_Leave_Item(long _temporaryDayOffSeq, string _start_Date, string _end_Date)
        {
            InitializeComponent();
            this.button1.Text = Program.Language.De[28015];

            temporaryDayOffSeq = _temporaryDayOffSeq;
            //this.Start_Date.Value = DateTime.Parse (_start_Date ,  CultureInfo.CurrentCulture.)
            if (_start_Date != null)
            {
                this.Start_Date.Value = DateTime.Parse(_start_Date);

            }
            if (_end_Date != null)
            {
                this.End_Date.Value = DateTime.Parse(_end_Date);

            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            ((FlowLayoutPanel)this.Parent).Controls.Remove(this);

        }
    }
}
