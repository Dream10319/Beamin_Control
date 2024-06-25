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
    public partial class Holiday_Update_frm : Form
    {
        //public List<Operation_Information.DayOff> _Dayoff;
        //public List<Operation_Information.TemporaryDayOff> _TemporaryDayOff;



        //public List<Other_Response.Shop_Response.DayOff2> _Dayoff;
        //public List<Other_Response.Shop_Response.TemporaryDayOff> _TemporaryDayOff;

        public Holiday_Update_frm()
        {
            InitializeComponent();



            this.regular_holiday_lst.MaximumSize = new Size(0, 200);
            //this.MaximumSize = new Size(0, Screen.FromControl(this).WorkingArea.Height -100);
            //this.MaximumSize = new Size(this.Width, this.Height +100);
            this.regular_holiday_lst.AutoScroll = true;


            this.Temporary_list.ControlAdded += Temporary_list_ControlAdded;
            this.regular_holiday_lst.ControlAdded += Temporary_list_ControlAdded;

            this.regular_holiday_lst.ControlAdded += (ss, ee) =>{
                regular_holiday_Count.Text = $"{this.regular_holiday_lst.Controls.Count} / 15";
                //if(regular_holiday_lst.Size.Height )
            };

            this.regular_holiday_lst.ControlRemoved += (ss, ee) => {
                regular_holiday_Count.Text = $"{this.regular_holiday_lst.Controls.Count} / 15";
            };
        }

        private void Holiday_Update_frm_Load(object sender, EventArgs e)
        {
            this.flowLayoutPanel2.VerticalScroll.Visible = true;

            label3.Text = Program.Language.De[24009];
            label2.Text = Program.Language.De[24010];

            checkBox1.Text = Program.Language.De[28014];



            button4.Text = Program.Language.De[28011];
            button2.Text = Program.Language.De[28012];
            button3.Text = Program.Language.De[28013];

        }
        private void button1_Click( object sender, EventArgs e )
        {

            if (this.regular_holiday_lst.Controls.Count  < 15)
            {
                this.regular_holiday_lst.Controls.Add(new regular_holiday_Item());


            }
        }

        private void button2_Click( object sender, EventArgs e )
        {

            TimeZoneInfo TZ = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            DateTime dt2 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TZ);

            this.Temporary_list.Controls.Add(new Temporary_Leave_Item( 0,dt2.ToString (), dt2.AddDays(1).ToString() ) );

        }

        private void button3_Click( object sender, EventArgs e )
        {
            //_Dayoff.Clear();
            //foreach (regular_holiday_Item r in this.regular_holiday_lst.Controls )
            //{
            //    if( r.cycle.SelectedItem != null&&r.Day.SelectedItem != null )
            //    {
            //        DayOff i = new DayOff();
            //        i.day = r.Day.Text.ToUpper();
            //        i.interval = ((cycle_clas)r.cycle.SelectedItem).Cycle_key;
            //        if( _Dayoff.Exists(p => p.day == i.day && p.interval == i.interval ) == false  )
            //        {
            //            _Dayoff.Add(i);
            //        }
            //    }
            //    //i.interval = (Cycles)r.cycle.SelectedItem;
            //    //if ( _Dayoff .Contains ())
            //}


            //if(this.checkBox1.Checked == true )
            //{

            //    DayOff i = new DayOff();
            //    i.day = "PUBLIC_HOLIDAY";
            //    i.interval = "PUBLIC_HOLIDAY";
            //    _Dayoff.Add(i);


            //}
            //_TemporaryDayOff.Clear();
            //foreach  (Temporary_Leave_Item t in this.Temporary_list.Controls )
            //{
            //    TemporaryDayOff tt = new TemporaryDayOff();
            //    tt.startDate = t.Start_Date.Value.ToString ("yyy-MM-dd");
            //    tt.endDate  = t.End_Date .Value.ToString ("yyy-MM-dd");

            //    if ( _TemporaryDayOff .Exists(o=> o.startDate == tt.startDate &&  o.endDate == tt.endDate) == false)
            //    {
            //       _TemporaryDayOff .Add(tt);
            //    }
            //}


            this.DialogResult = DialogResult.OK;
        }

 

        private void Temporary_list_ControlAdded( object sender, ControlEventArgs e )
        {
            //((FlowLayoutPanel)sender).MaximumSize = new Size(0, regular_holiday_lst.Size.Height - Temporary_list.Size.Height + 200);
            e.Control.Padding = new Padding(0);
            e.Control.Margin = new Padding(0);
            e.Control.Width = ((FlowLayoutPanel)sender).Width - 20;

            
        }

        private void vScrollBar1_Scroll( object sender, ScrollEventArgs e )
        {

        }

        private void button1_Click_1( object sender, EventArgs e )
        {
            //this.panel2.Padding 
        }
    }
}
