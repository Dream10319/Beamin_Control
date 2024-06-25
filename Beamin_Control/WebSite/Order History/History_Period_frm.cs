using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Order_History
{
    public partial class History_Period_frm : Form
    {
        public History_Period_frm()
        {
            InitializeComponent();
        }


        internal Date_Iem Selected_Date;
        private void History_Period_frm_Load( object sender, EventArgs e )
        {

            Add_Days_Weeks();
            Add_Months();
            Add_Periods();

            Start_Date.ValueChanged += Date_ValueChanged;
            EndDate.ValueChanged += Date_ValueChanged;

            //TimeZoneInfo TZ = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            //DateTime dt2 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TZ);

            //Start_Date.Value = dt2;
            //EndDate.Value = dt2.AddDays(7);

        }

        private void Date_ValueChanged( object sender, EventArgs e )
        {
            if ( this.tabControl1.SelectedTab == Date_Tab )
            {
                if ( Selected_Date == null )
                {
                    Selected_Date = new Date_Iem();
                }
                Selected_Date.StartDate = this.Start_Date.Value;
                Selected_Date.EndDate = this.EndDate.Value;
            }


        }

        void Add_Days_Weeks()
        {
            TimeZoneInfo TZ = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            DateTime dt2 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TZ);

            int count = 5;
            RadioButton[] Item = new RadioButton[count];
            Date_Iem[] D_Item = new Date_Iem[count];
            for ( int i = 0; i < count; i++ )
            {

                Item[i] = new RadioButton();
                Item[i].Size = new Size(400, 60);
                Item[i].Controls.Add(new Label()
                {
                    AutoSize = true,
                    //Location = new Point(16, 40),
                    Location = new Point(16, 40),
                    ForeColor = Color.DimGray,
                    Font = new Font(this.Font.Name, 9, FontStyle.Bold)
                });

                D_Item[i] = new Date_Iem();
            }

            D_Item[0].StartDate = dt2; D_Item[0].EndDate = dt2;
            Item[0].Text = "Today";
            Item[0].Tag = D_Item[0];
            Item[0].Controls[0].Text = D_Item[0].StartDate.ToString("yyyy. MM. dd. (ddd)");

            D_Item[1].StartDate = dt2.AddDays(-1); D_Item[1].EndDate = dt2.AddDays(-1); ;
            Item[1].Text = "Yesterday";
            Item[1].Tag = D_Item[1];
            Item[1].Controls[0].Text = D_Item[1].StartDate.ToString("yyyy. MM. dd. (ddd)");

            D_Item[2].StartDate = dt2.AddDays(-7); D_Item[2].EndDate = D_Item[2].StartDate.AddDays(+6); ;
            Item[2].Text = "Last 7 Days";
            Item[2].Tag = D_Item[2];
            Item[2].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[2].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[2].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));


            D_Item[3].StartDate = dt2; D_Item[3].EndDate = D_Item[3].StartDate.AddDays(+6); ;
            Item[3].Text = "This Week";
            Item[3].Tag = D_Item[3];
            Item[3].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[3].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[3].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));

            D_Item[4].StartDate = dt2.AddDays(-7); D_Item[4].EndDate = dt2.AddDays(-1); ;
            Item[4].Text = "Last Week";
            Item[4].Tag = D_Item[4];
            Item[4].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[4].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[4].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));

            //MessageBox.Show(D_Item[2].StartDate.ToString());

            //Item[0].AutoSize = true;



            foreach ( RadioButton all in Item )
            {
                all.CheckedChanged += All_CheckedChanged;
                all.Padding = new Padding(0, 10, 0, 10);
                this.Day_Week_List.Controls.Add(all);


            }
        }

        void Add_Months()
        {
            TimeZoneInfo TZ = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            DateTime dt2 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TZ);

            int count = 5;
            RadioButton[] Item = new RadioButton[count];
            Date_Iem[] D_Item = new Date_Iem[count];
            for ( int i = 0; i < count; i++ )
            {

                Item[i] = new RadioButton();
                Item[i].Size = new Size(400, 60);
                Item[i].Controls.Add(new Label()
                {
                    AutoSize = true,
                    //Location = new Point(16, 40),
                    Location = new Point(16, 40),
                    ForeColor = Color.DimGray,
                    Font = new Font(this.Font.Name, 9, FontStyle.Bold)
                });

                D_Item[i] = new Date_Iem();
            }

            D_Item[0].StartDate = dt2.AddDays ( - (dt2.Day-1 ) );
            D_Item[0].EndDate = D_Item[0].StartDate.AddDays (DateTime.DaysInMonth(dt2.Year , dt2.Month ) -1);
            Item[0].Text = "This Month";
            Item[0].Tag = D_Item[0];
            Item[0].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[0].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[0].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));


            D_Item[1].StartDate = dt2.AddMonths (-1).AddDays(-(dt2.Day - 1));
            D_Item[1].EndDate = D_Item[1].StartDate.AddDays(DateTime.DaysInMonth(dt2.Year, D_Item[1].StartDate.Month) - 1);
            Item[1].Text = "Last Month";
            Item[1].Tag = D_Item[1];
            Item[1].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[1].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[1].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));



            D_Item[2].StartDate = dt2.AddMonths (-1).AddDays (1);
            D_Item[2].EndDate = dt2.AddDays(-1);
            Item[2].Text = "Last 1 Month";
            Item[2].Tag = D_Item[2];
            Item[2].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[2].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[2].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));

            D_Item[3].StartDate = dt2.AddMonths(-3).AddDays(1);
            D_Item[3].EndDate = dt2.AddDays(-1);
            Item[3].Text = "Last 3 Month";
            Item[3].Tag = D_Item[3];
            Item[3].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[3].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[3].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));


            D_Item[4].StartDate = dt2.AddMonths(-6).AddDays(1);
            D_Item[4].EndDate = dt2.AddDays(-1);
            Item[4].Text = "Last 6 Month";
            Item[4].Tag = D_Item[4];
            Item[4].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[4].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[4].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));



            foreach ( RadioButton all in Item )
            {
                all.CheckedChanged += All_CheckedChanged;
                all.Padding = new Padding(0, 10, 0, 10);
                this.Months_list.Controls.Add(all);


            }
        }

        void Add_Periods()
        {
            TimeZoneInfo TZ = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            DateTime dt2 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TZ);

            int count = 6;
            RadioButton[] Item = new RadioButton[count];
            Date_Iem[] D_Item = new Date_Iem[count];
            for ( int i = 0; i < count; i++ )
            {

                Item[i] = new RadioButton();
                Item[i].Size = new Size(400, 60);
                Item[i].Controls.Add(new Label()
                {
                    AutoSize = true,
                    //Location = new Point(16, 40),
                    Location = new Point(16, 40),
                    ForeColor = Color.DimGray,
                    Font = new Font(this.Font.Name, 9, FontStyle.Bold)
                });

                D_Item[i] = new Date_Iem();
            }

            DateTime dt = new DateTime().AddYears(dt2.Year -1);

            D_Item[0].StartDate = dt;
            D_Item[0].EndDate = D_Item[0].StartDate.AddMonths(2).AddDays((DateTime.DaysInMonth(dt.Year, D_Item[0].StartDate.Month) - 1));
            Item[0].Text = "Q1";
            Item[0].Tag = D_Item[0];
            Item[0].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[0].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[0].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));


            D_Item[1].StartDate = dt.AddMonths (3);
            D_Item[1].EndDate = D_Item[1].StartDate.AddMonths (2).AddDays ((DateTime.DaysInMonth(dt.Year, D_Item[1].StartDate.Month )-1)) ;
            Item[1].Text = "Q2";
            Item[1].Tag = D_Item[1];
            Item[1].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[1].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[1].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));



            D_Item[2].StartDate = dt.AddMonths(6);
            D_Item[2].EndDate = D_Item[2].StartDate.AddMonths(2).AddDays((DateTime.DaysInMonth(dt.Year, D_Item[2].StartDate.Month) -2));
            Item[2].Text = "Q3";
            Item[2].Tag = D_Item[2];
            Item[2].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[2].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[2].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));

            D_Item[3].StartDate = dt.AddMonths(9);
            D_Item[3].EndDate = D_Item[3].StartDate.AddMonths(2).AddDays((DateTime.DaysInMonth(dt.Year, D_Item[3].StartDate.Month) - dt.Day));
            Item[3].Text = "Q4";
            Item[3].Tag = D_Item[3];
            Item[3].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[3].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[3].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));


            DateTime ff = new DateTime();
            ff = dt.AddMonths (5);

            D_Item[4].StartDate = dt;
            //MessageBox.Show(DateTime.DaysInMonth(ff.Year, ff.Month).ToString ());
            
            D_Item[4].EndDate = ff.AddDays (DateTime.DaysInMonth (ff.Year,ff.Month ) - ff.Day );
            Item[4].Text = "First";
            Item[4].Tag = D_Item[4];
            Item[4].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[4].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[4].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));




            //DateTime ff2 = new DateTime();
            ff = dt.AddMonths(5);

            D_Item[5].StartDate = ff.AddMonths (1);

            D_Item[5].EndDate = D_Item[5].StartDate.AddMonths (5).AddDays(DateTime.DaysInMonth(D_Item[5].StartDate.Year, D_Item[5].StartDate.Month) - D_Item[5].StartDate.Day);
            Item[5].Text = "Second Half";
            Item[5].Tag = D_Item[4];
            Item[5].Controls[0].Text = String.Format("{0} ~ {1}",
                 D_Item[5].StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture),
                 D_Item[5].EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));



            foreach ( RadioButton all in Item )
            {
                all.CheckedChanged += All_CheckedChanged;
                all.Padding = new Padding(0, 10, 0, 10);
                this.Periods_lst.Controls.Add(all);


            }
        }

        private void All_CheckedChanged( object sender, EventArgs e )
        {
            RadioButton rd = (RadioButton)sender;

            if ( rd.Checked == true )
            {
                if ( Selected_Date == null )
                {
                    Selected_Date = new Date_Iem();
                }
                Selected_Date.StartDate = ((Date_Iem)rd.Tag).StartDate;
                Selected_Date.EndDate = ((Date_Iem)rd.Tag).EndDate;

                //this.Start_Date.Value = Selected_Date.StartDate;
                //this.EndDate.Value = Selected_Date.EndDate;
            }

        }



        private void button1_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
        }
    }

    public class Date_Iem
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public override string ToString()
        {

            return String.Format("Date Selection\r\n{0} ~ {1}",
            StartDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture), EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));


        }
    }
}
