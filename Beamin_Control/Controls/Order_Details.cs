using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Beamin_Control.Controls
{
    public partial class Order_Details : UserControl
    {
        public string _orderNo { get; set; }
        //public string orderProgress;
        //public string orderStatus;
        //public string riderStatus;
        //public string date;
        public List<order_item> Foods_Menu = new List <order_item>();

        public class order_item
        {
            //order_item(){
            //    return new CheckBox ();
            //}


            public Int64 ID;
            public string name;
            public bool Checked = false;

            public List<order_item> Options = new List<order_item>();
            public override string ToString()
            {
                return name;
            }
        }

        public JArray Selected_Time;

        JToken _Current_selected_timee;
        public JToken Current_selected_timee
        {
            get { return _Current_selected_timee; }
            set
            {

                _Current_selected_timee = value;
                if ( value.SelectToken("min")!=null && value.SelectToken("max") != null )
                {
            
                    Time.Text = value["min"].ToString() + "-" + value["max"].ToString ();

                }
                else
                {
                    Time.Text = value.ToString();

                }

            }
        }

        public Order_Details()
        {
            InitializeComponent();
        }

        private void Order_Item_Load(object sender, EventArgs e)
        {
            //this.Time.Text = "35";
     
            Current_selected_timee = Selected_Time.First();
            
        }

     

        private void button3_Click(object sender, EventArgs e)
        {
          
            

            if (Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Next != null)
            {
                Current_selected_timee = Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Next;
            }

            //int x = int.Parse(this.Time.Text);
            //this.Time.Text = (x + 5).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Previous != null)
            {
                Current_selected_timee = Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Previous;
            }

            //int x = int.Parse(this.Time.Text);
            //if (x > 5)
            //{
            //    this.Time.Text = (x - 5).ToString();

            //}
        }

        private void total_panel_Paint( object sender, PaintEventArgs e )
        {

        }
    }
}
