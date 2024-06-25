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
    public partial class Operation_Hours_frm : Form
    {
        public string Last_openTime, Last_closeTime;
        public Operation_Hours_frm()
        {
            InitializeComponent();
        }

        private void Operation_Hours_frm_Load(object sender, EventArgs e)
        {
            button2.Text = Program.Language.De[25001];
            button3.Text = Program.Language.De[25002];
            button4.Text = Program.Language.De[25003];
            button1.Text = Program.Language.De[25004];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hours.Controls.Clear();
            this.Hours.Controls.Add(Add_New_Working_Hour(false, Last_openTime, Last_closeTime, "EVERYDAY", Program.Language.De[26008]));

        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Hours.Controls.Clear();

            this.Hours.Controls.Add(Add_New_Working_Hour(false, Last_openTime, Last_closeTime, "WEEKDAY", Program.Language.De[26009]));
            this.Hours.Controls.Add(Add_New_Working_Hour(false, Last_openTime, Last_closeTime, "SATURDAY", Program.Language.De[26006]));
            this.Hours.Controls.Add(Add_New_Working_Hour(false, Last_openTime, Last_closeTime, "SUNDAY", Program.Language.De[26007]));


        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hours.Controls.Clear();



            //List<string> days_of_the_week = new List<string> {   "MONDAY" ,"TUESDAY","WEDNESDAY","THURSDAY","FRIDAY","SATURDAY","SUNDAY"    };

           

            foreach (KeyValuePair<string , string > day in Web_Main_frm.days_of_the_week)
            {
                this.Hours.Controls.Add(Add_New_Working_Hour(false, Last_openTime, Last_closeTime, day.Key,day.Value));

            }



        }



        public Operation_Hours Add_New_Working_Hour(bool allDay, string openTime, string closeTime, string intervalCode,string Hour_Name)
        {

            //string[] openTime_splitter = openTime.Split(':');
            //string[] closeTime_splitter = closeTime.Split(':');

            Operation_Information.Operation_Hours New_H = new Operation_Information.Operation_Hours( Operation_Hours.Hour_Types.Operation_Time);

            New_H.All_Day.Checked = allDay;
            New_H.intervalCode.Tag = intervalCode;

            //New_H.Hour_Type = Operation_Hours.Hour_Types.Operation_Time;
            //for (int i = 24; i <= 32; i++)
            ////for (int i = 1; i <= 8; i++)

            //{
            //    Operation_Hourr H = new Operation_Hourr()
            //    {
            //        Hour = i.ToString("00"),
            //        //Hour = DateTime.ParseExact((i).ToString(), "%H", System.Globalization.CultureInfo.CurrentCulture )
            //        //.ToString("HH", Web_Helper.Culture),

            //        //Hour_String = DateTime.ParseExact((i == 24 ? i - 12 : i - 24).ToString(),
            //        Hour_String = DateTime.ParseExact(( i - 24).ToString(),

            //        //Hour_String = DateTime.ParseExact((i).ToString(),
            //        "%H", System.Globalization.CultureInfo.CurrentCulture
            //      ).ToString("tt hh ( 다음 날 오전 )", Web_Helper.Culture).ToUpper()

            //    };
            //    New_H.closeHour.Items.Add(H);

            //}


            New_H.openMinute.Items.Clear();
            New_H.openMinute.Items.AddRange(new string[] { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" });
            New_H.openMinute.SelectedIndex = 0;

            New_H.closeMinute.Items.Clear();
            New_H.closeMinute.Items.AddRange(new string[] { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" });
            New_H.closeMinute.SelectedIndex = 0;

            switch (intervalCode)
            {
                case "EVERYDAY":
                    New_H.intervalCode.Text = Program.Language.De[26008]; //"EVERYDAY";
                    New_H.Days = new List<string> { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };
                    break;

                case "WEEKDAY":
                    New_H.intervalCode.Text = Program.Language.De[26010]; //"MONDAY To FRIDAY";
                    New_H.Days = new List<string> { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY" };

                    break;

                default:
                    //New_H.intervalCode.Text = intervalCode;
                    New_H.intervalCode.Text = Hour_Name;
                    New_H.Days = new List<string> { intervalCode };

                    break;
            }



            if (allDay == false && (!string.IsNullOrEmpty (openTime) && !string.IsNullOrEmpty(closeTime))) 
            {

                //New_H.defult_OpenHour=openTime_splitter[0];
                //New_H.Defult_CloseHour=closeTime_splitter[0];

                //New_H.openMinute.Text = openTime_splitter[1];
                //New_H.closeMinute.Text = closeTime_splitter[1];

                New_H.defult_OpenTime = openTime;
                New_H.defult_CloseTime = closeTime;

            

                //if (openTime_splitter[0]=="24")
                //{
                //    openTime_splitter[0] = "01";
                //}

                //if (closeTime_splitter[0] == "24")
                //{
                //    closeTime_splitter[0] = "01";
                //}
                //closeTime_splitter[0] = "25";
                //DateTime To_12Time1 = DateTime.ParseExact(openTime, "HH:mm", Web_Helper.Culture);
                //DateTime To_12Time2 = DateTime.ParseExact(closeTime, "HH:mm", Web_Helper.Culture);


                //MessageBox.Show(closeTime_splitter[0]);


                //New_H.openHour.SelectedItem = New_H.openHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == openTime_splitter[0]).FirstOrDefault();
                //New_H.closeHour.SelectedItem = New_H.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == closeTime_splitter[0]).FirstOrDefault();





                //foreach (Operation_Hourr h in New_H.openHour.Items)
                //{
                //    if (h.Hour == int.Parse(To_12Time1.ToString("HH")))
                //    {
                //        New_H.openHour.SelectedItem = h;
                //        break;
                //    }
                //}


                //foreach (Operation_Hourr h in New_H.closeHour.Items)
                //{
                //    if (h.Hour == int.Parse(To_12Time2.ToString("HH")))
                //    {
                //        New_H.closeHour.SelectedItem = h;
                //        break;
                //    }
                //}

                //New_H.openMinute.Text = To_12Time1.ToString("mm");
                //New_H.closeMinute.Text = To_12Time2.ToString("mm");

            }
            else
            {
            
            }

            return New_H;

        }

    }
}
