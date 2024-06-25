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
    public partial class Operation_Hours : UserControl
    {

        public List<string> Days;

        //public string defult_OpenHour = null, Defult_CloseHour = null;
        public string defult_OpenTime
        {
            get
            {
                //return "00:00";

                return this.openHour.SelectedItem!=null ?   ((Operation_Hourr)this.openHour.SelectedItem).Hour.ToString() + ":" + this.openMinute.Text : null;
            }
            set
            {
                if (value != null)
                {
                    string[] ti = value.Split(':');
                    this.openHour.SelectedItem = this.openHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == ti[0]).FirstOrDefault();
                    this.openMinute.SelectedItem = this.openMinute.Items.OfType<string>().Where(T => T == ti[1]).FirstOrDefault();
                }
            }
        }

        public string defult_CloseTime
        {
            get
            {

                return this.closeHour.SelectedItem !=null ? ((Operation_Hourr)this.closeHour.SelectedItem).Hour.ToString() + ":" + this.closeMinute.Text: null;
            }
            set
            {
                string[] ti = value.Split(':');
                this.closeHour.SelectedItem = this.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == ti[0]).FirstOrDefault();
                this.closeMinute.SelectedItem = this.closeMinute.Items.OfType<string>().Where(T => T == ti[1]).FirstOrDefault();

            }
        }


        string Defult_CloseHour = null;


        public enum Hour_Types { Operation_Time, Break_Time, Temporaily_Suspend }


        //public Hour_Types Hour_Type;

        public Hour_Types Hour_Type;



        //, string _defult_OpenHour = null, string _Defult_CloseHour = null 
        public Operation_Hours(Hour_Types _Hour_Type , string  _defult_OpenTime=null )
        {
            InitializeComponent();

            this.label1.Text = Program.Language.De[25005];
            this.label4.Text = Program.Language.De[25006];
            this.All_Day.Text = Program.Language.De[25007];

            Hour_Type = _Hour_Type;
            //defult_OpenHour = _defult_OpenHour;
            //Defult_CloseHour = _Defult_CloseHour;
            //this.openHour.SelectedIndex = 0;
            //this.openMinute.SelectedIndex = 0;

            //this.closeHour.SelectedIndex = this.closeHour.Items.Count - 1;
            //this.closeMinute.SelectedIndex = 0;

            defult_OpenTime = _defult_OpenTime;

            int start_From = int.Parse(DateTime.Now.ToString("HH"), Web_Helper.Culture);





            for (int i = 0; i < 24; i++)
            {


                Operation_Hourr H = new Operation_Hourr()
                {
                    //Hour = i,
                    Hour = DateTime.ParseExact((i).ToString(), "%H", System.Globalization.CultureInfo.CurrentCulture)
                        .ToString("HH", Web_Helper.Culture),

                    Hour_String = DateTime.ParseExact(i.ToString(), "%H",
                    System.Globalization.CultureInfo.CurrentCulture
                    ).ToString("tt hh", Web_Helper.Culture).ToUpper()

                };

                Open_Hours.Add(H);


                if (Hour_Type == Hour_Types.Temporaily_Suspend)
                {
                    if (i >= start_From)
                    {
                        this.openHour.Items.Add(H);

                    }
                }
                else
                {
                    this.openHour.Items.Add(H);

                }

                //this.closeHour.Items.Add(H);
            }

            //if ( this.Tag != null && this.Tag.ToString() == "Break_Time" )
            //{
            //    this.intervalCode.Text = this.Name;

            //    this.All_Day.Text="Enable";

            //}




            //if (this.Parent.Name == "Hours")
            //{
            //this.openHour.SelectedIndex = 0;



            if (defult_OpenTime != null)
            {
                //this.openHour.SelectedItem = this.openHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == defult_OpenHour).FirstOrDefault();
                //Add_Close_Hours();

            }
            else
            {
                this.openMinute.SelectedIndex = 0;

                this.openHour.SelectedIndex = 0;
            }


            switch (Hour_Type)
            {
                case Hour_Types.Operation_Time:
                    this.openHour.SelectedIndexChanged += (ss, ee) =>
                    {
                        Add_Close_Hours_For_Operation_Time();

                    };

                    break;

                case Hour_Types.Break_Time:
                    this.openHour.SelectedIndexChanged += (ss, ee) =>
                    {
                        Add_Close_Hours_For_Break_Time();

                    };

                    break;

                case Hour_Types.Temporaily_Suspend:

                    this.openHour.SelectedIndexChanged += (ss, ee) =>
                    {
                        Add_Close_Hours_For_Temporaily_Suspend();

                    };
                    this.openMinute.SelectedIndexChanged += (ss, ee) =>
                    {
                        Add_Close_Hours_For_Temporaily_Suspend();

                    };

              


                    //int dd = int.Parse (DateTime.Now.ToString("mm") );
                    //MessageBox.Show(dd.ToString());

                    //this.openMinute.Text  = this.openMinute.Items.Cast<string >().Where(ss => dd <= int.Parse (ss)).FirstOrDefault();
                    break;

            }


           



        }

        //public string Title {
        //    get { return this.intervalCode.Text; }
        //    set { this.intervalCode.Text = value; }
        //}
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if ( this.Tag!=null && this.Tag.ToString() == "Break_Time" )
            //{
            //    this.panel1.Visible = this.All_Day.Checked;

            //}
            //else
            //{

            this.panel1.Visible = !this.All_Day.Checked;

            //}
        }

        List<Operation_Hourr> Open_Hours = new List<Operation_Hourr>();

        private void Operation_Hours_Load(object sender, EventArgs e)
        {

          



            //Operation_Hourr Ht = new Operation_Hourr()
            //{
            //    //Hour = 12,
            //    Hour = DateTime.ParseExact((12).ToString(), "%H", System.Globalization.CultureInfo.CurrentCulture)
            //        .ToString("HH", Web_Helper.Culture),
            //    //Hour_String = DateTime.ParseExact((i - 12).ToString(), "%H",

            //    Hour_String = DateTime.ParseExact((12).ToString(), "%H",
            //    System.Globalization.CultureInfo.CurrentCulture).ToString("tt hh ( 다음 날 오전 )", Web_Helper.Culture).ToUpper()

            //};

            //this.closeHour.Items.Add(Ht);

            // 24 = 12 pm 
            // 25 = 1 AM

            //33 = 8 AM

            //for (int i = 24; i <= 32; i++)
            ////for (int i = 1; i <= 8; i++)

            //{
            //    Operation_Hourr H = new Operation_Hourr()
            //    {
            //        Hour = i.ToString (),
            //        //Hour = DateTime.ParseExact((i).ToString(), "%H", System.Globalization.CultureInfo.CurrentCulture )
            //        //.ToString("HH", Web_Helper.Culture),

            //        Hour_String = DateTime.ParseExact((  i==24? i-12 : i-24  ).ToString(), 

            //        //Hour_String = DateTime.ParseExact((i).ToString(),
            //        "%H", System.Globalization.CultureInfo.CurrentCulture
            //      ).ToString("tt hh ( 다음 날 오전 )", Web_Helper.Culture).ToUpper()

            //    };
            //    this.closeHour.Items.Add(H);

            //}



            //}

        }


        void Add_Close_Hours_For_Operation_Time()
        {
            this.closeHour.Items.Clear();

            Operation_Hourr cc = ((Operation_Hourr)this.openHour.Items[this.openHour.SelectedIndex]);


            int Time_Now = int.Parse(cc.Hour) + 1;






            for (int H = 0; H < 24; H++)
            {
                Operation_Hourr H2 = new Operation_Hourr();



                if (Time_Now <= 23)
                {
                    H2.Hour = DateTime.ParseExact((Time_Now).ToString(), "%H", System.Globalization.CultureInfo.CurrentCulture)
                    .ToString("HH", Web_Helper.Culture);

                    H2.Hour_String = DateTime.ParseExact(Time_Now.ToString(), "%H",
                     System.Globalization.CultureInfo.CurrentCulture
                     ).ToString("tt hh", Web_Helper.Culture).ToUpper();

                }
                else
                {



                    H2.Hour = Time_Now.ToString();

                    H2.Hour_String = DateTime.ParseExact((Time_Now - 24).ToString(), "%H",
                     System.Globalization.CultureInfo.CurrentCulture
                     //{Program.Language.De[9991]}
                     ).ToString("tt hh", Web_Helper.Culture).ToUpper() + $" ({Program.Language.De[9991]})"; //" (다음 날)";
                }



                this.closeHour.Items.Add(H2);
                Time_Now = Time_Now + 1;

            }

            if (Defult_CloseHour != null)
            {
                Operation_Hourr sss = this.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == Defult_CloseHour).FirstOrDefault();
                this.closeHour.SelectedItem = sss != null ? sss : this.closeHour.SelectedItem = this.closeHour.Items[0];
            }
            else
            {

                //if (Hour_Type == Hour_Types.Operation_Time || Hour_Type == Hour_Types.Temporaily_Suspend)
                //{

                if (Defult_CloseHour != null)
                {
                    //this.closeHour.SelectedItem = this.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == defult_OpenHour).FirstOrDefault();
                    //Add_Close_Hours();

                }
                else
                {
                    this.closeHour.SelectedIndex = 0;

                }


            }
        }

        void Add_Close_Hours_For_Break_Time()
        {
            this.closeHour.Items.Clear();

            for (int H = this.openHour.SelectedIndex + 1; H < this.openHour.Items.Count; H++)
            {

                Operation_Hourr cc = ((Operation_Hourr)this.openHour.Items[H]);


                Operation_Hourr H2 = new Operation_Hourr()
                {
                    Hour = cc.Hour,
                    Hour_String = cc.Hour_String

                };
                this.closeHour.Items.Add(H2);

                //if(H2.Hour == Defult_CloseHour)
                //{
                //    this.closeHour.SelectedItem = H2;

                //}

            }

            //if (this.closeHour.Items.Count > 1)
            //{

            //    this.closeHour.SelectedIndex = 1;
            //}
            //else
            //{
            //this.closeHour.SelectedIndex = 0;

            //}

            if (Defult_CloseHour != null)
            {
                //this.closeHour.SelectedItem = this.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == defult_OpenHour).FirstOrDefault();
                //Add_Close_Hours();

            }
            else
            {
                this.closeHour.SelectedIndex = 0;

            }

        }
        void Add_Close_Hours_For_Temporaily_Suspend()
        {
            this.closeHour.Items.Clear();

            //int cc = int.Parse(((Operation_Hourr)this.openHour.SelectedItem).Hour);

            //int start_From = 0;

            //int start_from2 = 0<= this.openHour.SelectedIndex;

            //switch (Hour_Type)
            //{
            //    case Hour_Types.Operation_Time:
            //        start_From = this.openHour.SelectedIndex + 1;

            //        break;
            //    case Hour_Types.Break_Time:
            //        start_From = this.openHour.SelectedIndex;

            //        break;
            //    case Hour_Types.Temporaily_Suspend:
            //        start_From = this.openHour.SelectedIndex + 1;

            //        break;

            //}


            //if(Hour_Type == Hour_Types.Operation_Time || Hour_Type == Hour_Types.Temporaily_Suspend)
            //{
            //    start_From = this.openHour.SelectedIndex + 1;
            //}
            //else
            //{
            //    start_From = this.openHour.SelectedIndex ;

            //}




            // Temporaily_Suspend = 0 <  this.openHour.SelectedIndex
            // Temporaily_Suspend = 0 <=  this.openHour.SelectedIndex


            //if (Hour_Type == Hour_Types.Operation_Time)
            //{


            //    for (int H = 0; H < this.openHour.SelectedIndex; H++)
            //    {

            //        Operation_Hourr cc = ((Operation_Hourr)this.openHour.Items[H]);


            //        Operation_Hourr H2 = new Operation_Hourr()
            //        {
            //            Hour = (int.Parse(cc.Hour) + 24).ToString("00"),
            //            Hour_String = cc.Hour_String + " (다음 날)"

            //        };
            //        this.closeHour.Items.Add(H2);


            //    }

            //}


            //if (Hour_Type == Hour_Types.Temporaily_Suspend)
            //{

            //this.closeHour.Items.Clear();





            Operation_Hourr cc = ((Operation_Hourr)this.openHour.Items[this.openHour.SelectedIndex]);

            //if(string.IsNullOrEmpty(cc.Hour)) { return; }
            //int Time_Now = DateTime.Now.Hour +1;
            int Time_Now = int.Parse(cc.Hour);

            //this.openMinute.SelectedItem != null &&
            if ( int.Parse(this.openMinute.Text) >= 30)
            {
                Time_Now = Time_Now + 1;
            }

            //MessageBox.Show(this.openMinute.Items[0].ToString ());
            this.closeMinute.Items.Clear();

            switch (this.openMinute.SelectedItem.ToString())
            {
                case "00":
                    this.closeMinute.Items.AddRange(new string[] { "30", "40", "50" });
                    break;

                case "10":
                    this.closeMinute.Items.AddRange(new string[] { "40", "50" });
                    break;

                case "20":
                    this.closeMinute.Items.AddRange(new string[] { "50" });
                    break;

                case "30":
                    this.closeMinute.Items.AddRange(new string[] { "00", "10", "20", "30", "40", "50" });
                    break;
                case "40":
                    this.closeMinute.Items.AddRange(new string[] { "10", "20", "30", "40", "50" });
                    break;

                case "50":
                    this.closeMinute.Items.AddRange(new string[] { "20", "30", "40", "50" });
                    break;
            }
            this.closeMinute.SelectedIndex = 0;

            //if (this.openHour.SelectedIndex < this.openHour.Items.Count)
            //{
            //    int.Parse(cc.Hour);
            //}
            //else
            //{

            //}

            for (int H = 0; H < 24; H++)
            {
                Operation_Hourr H2 = new Operation_Hourr()
                {


                };


                if (Time_Now <= 23)
                {
                    H2.Hour = DateTime.ParseExact((Time_Now).ToString(), "%H", System.Globalization.CultureInfo.CurrentCulture)
                    .ToString("HH", Web_Helper.Culture);

                    H2.Hour_String = DateTime.ParseExact(Time_Now.ToString(), "%H",
                     System.Globalization.CultureInfo.CurrentCulture
                     ).ToString("tt hh", Web_Helper.Culture).ToUpper();

                }
                else
                {



                    H2.Hour = Time_Now.ToString();

                    H2.Hour_String = DateTime.ParseExact((Time_Now - 24).ToString(), "%H",
                     System.Globalization.CultureInfo.CurrentCulture
                     ).ToString("tt hh", Web_Helper.Culture).ToUpper() + $" ({Program.Language.De[9991]})"; //" (다음 날)";
                }



                this.closeHour.Items.Add(H2);
                Time_Now = Time_Now + 1;
                //}




                //foreach (Operation_Hourr cc in Open_Hours) { 
                ////for (int H = 0; H <= this.openHour.SelectedIndex; H++)
                ////{

                ////    Operation_Hourr cc = ((Operation_Hourr)this.openHour.Items[H]);

                //    //DateTime.Today.

                //    Operation_Hourr H2 = new Operation_Hourr()
                //    {
                //        Hour = (int.Parse(cc.Hour) + 24).ToString("00"),
                //        Hour_String = cc.Hour_String + " (다음 날)"

                //    };
                //    this.closeHour.Items.Add(H2);


                //}

            }

            if (Defult_CloseHour != null)
            {
                Operation_Hourr sss = this.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == Defult_CloseHour).FirstOrDefault();
                this.closeHour.SelectedItem = sss != null ? sss : this.closeHour.SelectedItem = this.closeHour.Items[0];
            }
            else
            {

                if (Hour_Type == Hour_Types.Operation_Time || Hour_Type == Hour_Types.Temporaily_Suspend)
                {
                    this.closeHour.SelectedIndex = 0;

                }
                else
                {

                    if (this.closeHour.Items.Count > 1)
                    {

                        this.closeHour.SelectedIndex = 1;
                    }
                    else
                    {
                        this.closeHour.SelectedIndex = 0;

                    }

                }


            }
            //this.openHour.Items.OfType<Operation_Hourr>().Where (p => p. )


            //for (int i = 0; i < 23; i++)
            //{

            //    Operation_Hourr H2 = new Operation_Hourr()
            //    {
            //        Hour = (i+ cc +1) .ToString ("00"),
            //        //Hour = DateTime.ParseExact((i).ToString(), "%H", System.Globalization.CultureInfo.CurrentCulture)
            //        //    .ToString("HH", Web_Helper.Culture),

            //        Hour_String = DateTime.ParseExact(   ( (i + cc+1 ) < 24 ? (i + cc+1)  : i )      .ToString(), "%H",
            //        System.Globalization.CultureInfo.CurrentCulture
            //        ).ToString("tt hh", Web_Helper.Culture).ToUpper() + ( (     (i + cc +1 ) >= 24 )  ? " (다음 날)":""   )

            //    };
            //this.closeHour.Items.Add(H2);

            //}

        }

    }




}
public class Operation_Hourr
{
    //public int Hour { get; set; }
    public string Hour { get; set; }
    public string Hour_String { get; set; }

    public override string ToString()
    {
        return Hour_String + $"- {Hour}";
    }
}
