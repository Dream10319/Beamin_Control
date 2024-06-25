
using System;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Beamin_Control
{

    static class Program
    {
        //public static Language_Class Language = new Language_Class("Korean");
        //public static Language_Class Language = new Language_Class("English");
        public static Language_Class Language = new Language_Class(Properties.Settings.Default.Default_Language);




        //public static Newtonsoft.Json.Linq.JObject Computer_Info;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // To Enable HTTPS

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;








            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 main_frm = new Form1();
            //WebSite.Web_Main_frm main_frm = new WebSite.Web_Main_frm();

            //WebSite.Operation_Information.Holiday_Update_frm main_frm = new WebSite.Operation_Information.Holiday_Update_frm();
            //WebSite.Boss_Notice.New_Boss_Notice_frm main_frm = new WebSite.Boss_Notice.New_Boss_Notice_frm();


            DateTime dt = DateTime.Now;

            //MessageBox.Show(dt.ToString("yyyy/MM/dd dddd", System.Globalization.CultureInfo.GetCultureInfo("en-US")));




            DayOfWeek[] days1 = {
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday };

            //create a sort order that starts yesterday
            DateTime orderStartDate = DateTime.Today.AddDays(-1);
            List<int> sortOrder = Enumerable.Range(0, 7).Select(days => (int)orderStartDate.AddDays(days).DayOfWeek).ToList();


            //sort collection using the index of the sortOrder


            //collection.AddRange(list.OrderBy(list => sortOrder.FindIndex(days => day == list.TargetDay)));

            //MessageBox.Show(DateTime.UtcNow.DayOfWeek.ToString ());

            //DateTime xx = new DateTime(;

            //List<WebSite.OperationHour2> list_hours = new List<WebSite.OperationHour2>();
            //list_hours.Add(new WebSite.OperationHour2() { dayType = "SATURDAY", endTime ="14:00" , startTime ="05:00" });
            //list_hours.Add(new WebSite.OperationHour2() { dayType = "TUESDAY", endTime ="10:00" , startTime ="14:00" });
            //list_hours.Add(new WebSite.OperationHour2() { dayType = "MONDAY", endTime = "11:00" , startTime ="13:00" });
            //list_hours.Add(new WebSite.OperationHour2() { dayType = "WEDNESDAY", endTime = "11:00" , startTime ="13:00" });
            //list_hours.Add(new WebSite.OperationHour2() { dayType = "THURSDAY", endTime = "11:00" , startTime ="13:00" });
            //list_hours.Add(new WebSite.OperationHour2() { dayType = "FRIDAY", endTime = "11:00" , startTime ="13:00" });
            //list_hours.Add(new WebSite.OperationHour2() { dayType = "SUNDAY", endTime = "11:00" , startTime ="13:00" });

            //List<string> test_s = new List<string>();

            //for (int i =1; i <= 7;i++ )
            //{
            //    DateTime current = DateTime.Today.AddDays(i);
            //    //MessageBox.Show(string.Format ("{0:dddd} test {0:dd MM yyyy} " , current ));


            //    WebSite.OperationHour2 oo =(WebSite.OperationHour2)list_hours.Find(d => d.dayType == string.Format("{0:dddd}", current).ToUpper ());
            //    //WebSite.OperationHour2 sw = (WebSite.OperationHour2)list_hours.Select(h => h.dayType == string.Format("{0:dddd}", current));
            //    if(oo != null )
            //    {
            //        //MessageBox.Show(oo.endTime);
            //        test_s.Add(String.Format("{0:dddd yyyy-MM-dd} {1}", current, oo.startTime));

            //    }
            //}

            //foreach (var xc in test_s )
            //{
            //    //MessageBox.Show(xc,"test");
            //}







            Application.Run(main_frm);


        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Application Crashed",  MessageBoxButtons.OK, MessageBoxIcon.Error );

            if (MessageBox.Show("Do You Want To Restart Application ?", "Restart Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
