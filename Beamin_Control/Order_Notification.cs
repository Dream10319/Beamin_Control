using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Beamin_Control
{
    public partial class Order_Notification : Form
    {
        public string orderNo;
        public string orderProgress;
        public string orderStatus;
        public string riderStatus;
        public string date;


        public JArray Selected_Time;

        JToken _Current_selected_timee;
        public JToken Current_selected_timee
        {
            get { return _Current_selected_timee; }
            set
            {
                _Current_selected_timee = value;
                //Time.Text = value.ToString();

                if ( value.SelectToken("min")!=null && value.SelectToken("max") != null )
                {

                    Time.Text = value["min"].ToString() + "-" + value["max"].ToString();

                }
                else
                {
                    Time.Text = value.ToString();

                }

            }
        }

        public Order_Notification()
        {
            InitializeComponent();

            this.Disposed += (ss, ee) =>
            {
                int Notifications_frm_count = 0;

                for (int i = 0; i <= Application.OpenForms.Count - 1; i++)
                {
                    if (Application.OpenForms[i].GetType() == typeof(Order_Notification) && Application.OpenForms[i] != this)
                    {
                        Notifications_frm_count += 1;
                        int Y_Location = Screen.PrimaryScreen.WorkingArea.Height - (Application.OpenForms[i].Height * Notifications_frm_count);
                        Application.OpenForms[i].Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Application.OpenForms[i].Width, Y_Location);

                    }
                }
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {




          
            this.Dispose();


        }

        private void Order_Notification_Load(object sender, EventArgs e)
        {
            //this.Time.Text = "35"; //bug here no time
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //int x = int.Parse(this.Time.Text);
            //if( x > 5)
            //{
            //    this.Time.Text = (x - 5).ToString();

            //}
            if (Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Previous != null)
            {
                Current_selected_timee = Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Previous;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int x = int.Parse(this.Time.Text);
            //this.Time.Text = (x + 5).ToString();

            if (Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Next != null)
            {
                Current_selected_timee = Selected_Time[Selected_Time.IndexOf(Current_selected_timee)].Next;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
