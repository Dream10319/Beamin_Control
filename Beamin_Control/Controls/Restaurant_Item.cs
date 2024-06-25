using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.Restaurants_Controls
{
    public partial class Restaurant_Item : UserControl
    {
        public Restaurant_Item()
        {
            InitializeComponent();
        }
       public  bool collapsed = true;

        private void Restaurant_Item_Load(object sender, EventArgs e)
        {
            foreach (Control cn in this.Controls)
            {
                cn.Click += Restaurant_Item_Click;
            }
        }
        public bool _changeable = false;


        public bool changeable
        {
            get { return _changeable; }

            set { 
                _changeable = value; 
                //switch (value)
                //{
                   

                //    case false:
                //        //Pen p = new Pen(Color.Black);
                //        SolidBrush sb = new SolidBrush((Color)ColorTranslator.FromHtml ("#0e191a"));
                       

                //        Graphics g = shape.CreateGraphics();
                //        //g.DrawEllipse(p , new RectangleF(0,0,20,20));
                //        g.FillEllipse(sb, new RectangleF(0, 0, shape.Size.Width , shape.Size.Height  ));
                        
                //        break;
                //}
            }
        }
        public string  R_name
        {
            get { return this.R_Name.Text; }

            set { this.R_Name.Text = value; }
        }

        private string _R_ID;
        public string R_ID
        {
            get { return _R_ID; }

            set { _R_ID = value; }
        }

        public string R_status
        {
            get { return this.R_Status.Text; }

            set { 
                this.R_Status.Text = value;
                //SolidBrush sb = null;

                switch (value)
                {
                    case "OPEN":
                        //this.Status_Buttons.Controls.Add(new Button
                        //{
                        //    Text = "Set to busy (30 mins)",
                        //    Size = new Size (201 -10 , 30)
                        //});

                        //this.Status_Buttons.Controls.Add(new Button
                        //{
                        //    Text = "Set to busy (60 mins)",
                        //    Size = new Size(201 - 10, 30)
                        //});

                        //this.Status_Buttons.Controls.Add(new Button
                        //{
                        //    Text = "Set to busy (120 mins)",
                        //    Size = new Size(201 - 10, 30)
                        //});

                        //this.Status_Buttons.Controls.Add(new Button
                        //{
                        //    Text = "Close for the day",
                        //    Size = new Size(201 - 10, 30)
                        //});
                        this.Status.Image = Properties.Resources.Open;
                        //sb = new SolidBrush((Color)ColorTranslator.FromHtml("#27ae60"));
                        break;

                    case "CLOSED":
                       
                        if (changeable == true)
                        {
                             //sb = new SolidBrush((Color)ColorTranslator.FromHtml("#e20338"));
                            this.Status.Image = Properties.Resources.Closed;

                        }
                        else
                        {
                            //sb = new SolidBrush((Color)ColorTranslator.FromHtml("#0e191a80"));
                            this.Status.Image = Properties.Resources.Disabled;
                        }
             
                        break;

                    case "BUSY":
                        this.Status.Image = Properties.Resources.Busy;
                        break;
                }

                //Graphics g = shape.CreateGraphics();
                //g.FillEllipse(sb, new RectangleF(0, 0, shape.Size.Width, shape.Size.Height));
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (collapsed)
            {
                case true:
                    if(this.Height >= this.panel1.Height + 80)
                    {
                       
                        this.timer1.Enabled = false;
                        this.Height = this.panel1.Height + 80;
                        collapsed = false;
                   
                    }
                    else
                    {
                        //this.BackColor = SystemColors.ActiveCaption;
                        this.Height += 10;
                    }
                    break;

                case false:
                    if (this.Height == this.MinimumSize.Height)
                    {

                        this.timer1.Enabled = false;
                        //this.Height = this.panel1.MinimumSize.Height;
                        collapsed = true ;
                        
                    }
                    else
                    {
                        //this.BackColor = SystemColors.Control;
                        this.Height -= 10;
                    }
                    break;
            }
        }

        private void Restaurant_Item_Click(object sender, EventArgs e)
        {
            if (changeable == true)
            {
                this.timer1.Enabled = true;
            }

            //SolidBrush sb = new SolidBrush((Color)ColorTranslator.FromHtml("#e20338"));
            //Graphics g = shape.CreateGraphics();
            //g.FillEllipse(sb, new RectangleF(0, 0, shape.Size.Width, shape.Size.Height));

        }

        private void shape_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
