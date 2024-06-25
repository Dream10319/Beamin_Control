using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.Controls
{
    public partial class Rider_Control : UserControl
    {

        public Rider_Control()
        {
            InitializeComponent();


        }


        public string Rider_Location
        {
            get
            {
                return Rider_Location_lb.Text;
            }
            set
            {
                Rider_Location_lb.Text = value;
            }
        }
        public  string Minutes_Until_Rider_Pickup
        {
            set
            {
                Minutes_Until_Rider_Pickup_lb.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //rider_ProgressBar1.Value = 50;
            if (rider_ProgressBar2.Value < rider_ProgressBar2.Maximum)
            {
                rider_ProgressBar2.Value += 1;

            }
        }

        private void Rider_Control_Load(object sender, EventArgs e)
        {



            //if(this.Controls.ContainsKey("rider_ProgressBar1"))
            //{
            //    this.Controls.RemoveByKey("rider_ProgressBar1");
            //}


            //rider_ProgressBar1 = new Rider_ProgressBar()
            //{
            //    Maximum = 100,
            //    Minimum = 0,
            //    Width = this.Width - 10,
            //    Height = 80,
            //    Name = "rider_ProgressBar1",
            //};

            //this.Controls.Add(rider_ProgressBar1);

        }
    }
}
