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
    public partial class regular_holiday_Item : UserControl
    {


        public string _interval
        {
            get
            {
                return ((cycle_clas)this.cycle.SelectedItem).Cycle_key;
            }
            set
            {
                if ( value == null )
                {
                    this.cycle.SelectedIndex = 0;

                }
                else
                {

                    this.cycle.SelectedItem = this.cycle.Items.Cast<cycle_clas>().Where(ss => ss.Cycle_key == value).FirstOrDefault();

                    //this.cycle.Items[""]
                    //foreach ( var d in this.cycle.Items )
                    //{


                    //    //if ( d.ToString () == new cycle_clas(value).ToString() )
                    //    if ( ((cycle_clas)d).Cycle_key == value )

                    //    //if( ((cycle_clas)d).Cycle_key == value )
                    //    {
                    //        //MessageBox.Show(new cycle_clas(value).ToString());
                    //        //MessageBox.Show(((cycle_clas)d).Cycle_Value);
                    //        this.cycle.SelectedItem = d;
                    //        break;
                    //    }
                    //}




                    //this.cycle.SelectedItem = value;

                }
            }
        }

        public string _day
        {
            get
            {
                return ((cycle_clas)this.Day.SelectedItem).Cycle_key;
            }
            set
            {
                if (value == null)
                {
                    this.Day.SelectedIndex = 0;

                }
                else
                {
                    this.Day.SelectedItem = this.Day.Items.Cast<cycle_clas>().Where(ss => ss.Cycle_key == value).FirstOrDefault();
                }
            }
        }

        //public Dictionary<string, string> Cycles = new Dictionary<string, string>();

        public regular_holiday_Item( string cycle = null, string Day = null )
        {
            InitializeComponent();

            this.button1.Text = Program.Language.De[28015];

            //Cycles.Add("EVERY_MONTH_FIRST", $"first of every month");
            //Cycles.Add("EVERY_MONTH_SECOND", $"second of every month");
            //Cycles.Add("EVERY_MONTH_THIRD", $"third of every month");
            //Cycles.Add("EVERY_MONTH_FORTH", $"forth of every month");
            //Cycles.Add("EVERY_MONTH_FIFTH", $"fifth of every month");
            //Cycles.Add("EVERY_MONTHLY_LAST", $"last of every month");
            //Cycles.Add("EVERY_WEEK", $"every week");

            //foreach (var t in Cycles )
            //{
            //    this.cycle.Items.Add(t);
            //}
            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "", Cycle_Value =""}.ToString());

            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_FIRST", Cycle_Value = $"first of every month" });
            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_SECOND", Cycle_Value = $"second of every month" });
            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_THIRD", Cycle_Value = $"third of every month" });
            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_FORTH", Cycle_Value = $"forth of every month" });
            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_FIFTH", Cycle_Value = $"fifth of every month" });
            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTHLY_LAST", Cycle_Value = $"last of every month" });
            //this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_WEEK", Cycle_Value = $"every week" });

            this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_FIRST", Cycle_Value = Program.Language.De[24021] });
            this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_SECOND", Cycle_Value = Program.Language.De[24022] });
            this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_THIRD", Cycle_Value = Program.Language.De[24023] });
            this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_FORTH", Cycle_Value = Program.Language.De[24024] });
            this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTH_FIFTH", Cycle_Value = Program.Language.De[24025] });
            this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_MONTHLY_LAST", Cycle_Value = Program.Language.De[24026] });
            this.cycle.Items.Add(new cycle_clas() { Cycle_key = "EVERY_WEEK", Cycle_Value = Program.Language.De[24027] });


            //this.cycle.Items.Add(new cycle_clas("EVERY_MONTH_FIRST").ToString());
            //this.cycle.Items.Add(new cycle_clas("EVERY_MONTH_SECOND").ToString());
            //this.cycle.Items.Add(new cycle_clas("EVERY_MONTH_THIRD").ToString());
            //this.cycle.Items.Add(new cycle_clas("EVERY_MONTH_FORTH").ToString());
            //this.cycle.Items.Add(new cycle_clas("EVERY_MONTH_FIFTH").ToString());
            //this.cycle.Items.Add(new cycle_clas("EVERY_MONTHLY_LAST").ToString());
            //this.cycle.Items.Add(new cycle_clas("EVERY_WEEK").ToString());


            foreach (KeyValuePair<string , string > d in Web_Main_frm.days_of_the_week)
            {
                this.Day.Items.Add(new cycle_clas() { Cycle_key = d.Key, Cycle_Value =d.Value });

            }

            //this.Day.Items.Add(new cycle_clas() { Cycle_key = "MONDAY", Cycle_Value = $"MONDAY" });
            //this.Day.Items.Add(new cycle_clas() { Cycle_key = "TUESDAY", Cycle_Value = $"TUESDAY" });
            //this.Day.Items.Add(new cycle_clas() { Cycle_key = "WEDNESDAY", Cycle_Value = $"WEDNESDAY" });
            //this.Day.Items.Add(new cycle_clas() { Cycle_key = "THURSDAY", Cycle_Value = $"THURSDAY" });
            //this.Day.Items.Add(new cycle_clas() { Cycle_key = "FRIDAY", Cycle_Value = $"FRIDAY" });
            //this.Day.Items.Add(new cycle_clas() { Cycle_key = "SATURDAY", Cycle_Value = $"SATURDAY" });
            //this.Day.Items.Add(new cycle_clas() { Cycle_key = "SUNDAY", Cycle_Value = $"SUNDAY" });




            _interval = cycle;
            _day = Day;
            //if ( cycle != null )
            //{


            //    //this.cycle.SelectedItem = Cycles[cycle];
            //}
            //else
            //{
            //    this.cycle.SelectedIndex = 0;
            //}
            this.Day.Text = Day != null ? Day : this.Day.Items[0].ToString();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
        }

        private void regular_holiday_Item_Load( object sender, EventArgs e )
        {

        }


    }



    public class test : IEquatable<test>
    {
        public string Cycle_key { get; set; }
        public string Cycle_Value { get; set; }



        public override string ToString()
        {
            return Cycle_Value;

        }

        public bool Equals( test other )
        {
            if ( other == null ) return false;
            return (this.Cycle_key .Equals(other.Cycle_key ));
        }

        //bool IEquatable<test>.Equals( test other )
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool Equals(object obj)
        //{

        //}


        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

    }
    public class cycle_clas
    {
        public string Cycle_key { get; set; }
        public string Cycle_Value { get; set; }

        //public cycle_clas( string _Cycle_key )
        //{
        //    Cycle_key = _Cycle_key;
        //}



        public override string ToString()
        {
            //switch ( Cycle_key )
            //{
                //case "EVERY_MONTH_FIRST":
                //    Cycle_Value = $"first of every month";
                //    break;
                //case "EVERY_MONTH_SECOND":
                //    Cycle_Value = $"second of every month";
                //    break;

                //case "EVERY_MONTH_THIRD":
                //    Cycle_Value = $"third of every month";
                //    break;

                //case "EVERY_MONTH_FORTH":
                //    Cycle_Value = $"forth of every month";
                //    break;

                //case "EVERY_MONTH_FIFTH":
                //    Cycle_Value = $"fifth of every month";
                //    break;

                //case "EVERY_MONTHLY_LAST":
                //    Cycle_Value = $"last of every month";
                //    break;

                //case "EVERY_WEEK":
                //    Cycle_Value = $"every week";
                //    break;

                //default:
                    //return Cycle_key.ToLower();

            //}
            return Cycle_Value;

            //return null;
        }
    }
}
