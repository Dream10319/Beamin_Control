using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Out_of_Stock_Setting
{
    public partial class Menu_Item : UserControl
    {
        public  string imageUrl;
        string _restockedAt = null;
        //string _itemStatus;

        //bool _IsHidden;

        public bool useMenupanId;

        public bool displayYn
        {
            get
            {

                return !this.flowLayoutPanel1.Controls.ContainsKey("Hide");


            }
            set
            {
                //_IsHidden = value;

                switch (value)
                {
                    case false :
                        if (!this.flowLayoutPanel1.Controls.ContainsKey("Hide"))
                        {
                            Add_Panel("Hide", "메뉴가 숨겨졌어요.", string.Empty);

                        }
                        //Sold_Out_btn.Text = "Un Hide";

                        break;

                    case true :

                        if (this.flowLayoutPanel1.Controls.ContainsKey("Hide"))
                        {
                            this.flowLayoutPanel1.Controls.RemoveByKey("Hide");
                        }
                        //if (_itemStatus == "SOLDOUT")
                        //{
                        //    //Sold_Out_btn.Text = "Activate";

                        //}
                        //else
                        //{
                        //    //Sold_Out_btn.Text = "Sold Out";

                        //}

                        break;
                }


            }
        }

        public string restockedAt
        {
            get
            {
                return _restockedAt;
            }
            set
            {
                _restockedAt = value;

                //this.Invoke(new Action(() =>
                //{
                if (string.IsNullOrEmpty(value))
                {

                }
                else
                {



                    try
                    {
                        //string test = "2022-09-21 14:00";


                        //string converted_Date = DateTime.Parse(value).ToString("yy. M. dd (ddd)");
                        //string converted_Time = DateTime.Parse(value).ToString("hh tt");
                        ////string converted = DateTime.Parse(test).ToString("yy. M. dd (ddd) Available for sale from hh");
                        //this.label4.Text =  $"{converted_Date} Available for sale from {converted_Time}";

                        //DateTime dt = DateTime.Parse(value);
                        //this.label4.Text = String.Format("{0:yy. M. dd (ddd)}, Available for sale from {0:hh tt}", dt);

                        //DateTime dt = DateTime.Parse(value, Web_Helper.Culture);
                        //this.label4.Text = $"{dt.ToString("yy. M. dd (ddd)", Web_Helper.Culture).ToUpper()}, Available for sale from {dt.ToString("hh:mm tt", Web_Helper.Culture).ToUpper()}";
                    }
                    catch { }


                }
                //}));

            }
        }



    

        public string itemStatus
        {
            get
            {


                if (this.flowLayoutPanel1.Controls.ContainsKey("Sold Out"))
                {
                    return "SOLDOUT";

                }
                else if (this.flowLayoutPanel1.Controls.ContainsKey("Hide") && useMenupanId== false )
                {
                    return "HIDE";

                }
                else
                {
                    return "ACTIVE";

                }






            }
            set
            {
               



                switch (value)
                {
                    case "ACTIVE":

                        //Sold_Out_btn.Text = "Sold Out";
                        //this.Controls.Remove(restockedAt_flow);
                        if (this.flowLayoutPanel1.Controls.ContainsKey("Sold Out"))
                        {
                            this.flowLayoutPanel1.Controls.RemoveByKey("Sold Out");
                        }

                        if (useMenupanId == false)
                        {
                            //IsHidden = false;


                            if (this.flowLayoutPanel1.Controls.ContainsKey("Hide"))
                            {
                                this.flowLayoutPanel1.Controls.RemoveByKey("Hide");
                            }

                        }

                        break;

                    case "SOLDOUT":

                        //Sold_Out_btn.Text = "Activate";
                        //restockedAt_flow.Visible = true;
                        if (!this.flowLayoutPanel1.Controls.ContainsKey("Sold Out"))
                        {
                            Add_Panel("Sold Out", "Sold Out", restockedAt);

                        }

                        if (useMenupanId == false)
                        {

                            if (this.flowLayoutPanel1.Controls.ContainsKey("Hide"))
                            {
                                this.flowLayoutPanel1.Controls.RemoveByKey("Hide");
                            }

                        }

                        break;

                    case "HIDE":

                        if (!this.flowLayoutPanel1.Controls.ContainsKey("Hide"))
                        {
                            Add_Panel("Hide", "메뉴가 숨겨졌어요.", string.Empty);

                        }

                        //if (useMenupanId == false)
                        //{

                        if (this.flowLayoutPanel1.Controls.ContainsKey("Sold Out"))
                        {
                            this.flowLayoutPanel1.Controls.RemoveByKey("Sold Out");
                        }

                        //}
                        //IsHidden = true;
                        //    IsHidden = true;
                        //    Sold_Out_btn.Text = "Activate";
                        //    Add_Panel("Hide", "메뉴가 숨겨졌어요.", string.Empty);

                        break;

                        //case "UnHide":
                        //    IsHidden = false ;
                        //    Sold_Out_btn.Text = "Activate";
                        //    this.flowLayoutPanel1.Controls.RemoveByKey("Hide");

                        //break;



                }
            }


        }


        public string Menu_Name
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }



     public   List<string    > Prices { 
            
            get {

                List<string> _Prices = new List<string>();

                foreach (Label s in this.Prices_List.Controls)
                {
                    _Prices.Add(s.Text);
                }
                return _Prices;
            } set {


                this.Prices_List.Controls.Clear();


                foreach (string s in value)
                {


                    Label Price = new Label()
                    {
                        Text = s,
                        ForeColor = SystemColors.ControlDarkDark,
                        AutoSize = true,
                      
                    };
                    Price.Font = new Font("Tahoma", (float)9.75, FontStyle.Bold);
                    this.Prices_List.Controls.Add(Price);
                }

             


            }
        
        }






     


        public bool popularMenuYn;


        [NonSerialized]
        private EventHandler fClick;
        public event EventHandler Click
        {
            add { fClick += value; }
            remove { fClick -= value; }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            EventHandler handler = fClick;
            if (fClick != null)
                handler(sender, e);
        }


        public Menu_Item()
        {
            InitializeComponent();
            flowLayoutPanel1.Click += OnClick;
            panel1.Click += OnClick;

            label1.Click += OnClick;
            Prices_List.Click += OnClick;
            //label3.Click += OnClick;
            //label4.Click += OnClick;

            Menu_Image.Click += OnClick;
            //restockedAt_flow.Click += OnClick;


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menu_Item_Load(object sender, EventArgs e)
        {
            //this.panel1.AutoSize = true;

            //this.Resize += (ss, ee) =>
            //{
            //    this.flowLayoutPanel1.Size = this.Size;
            //    this.flowLayoutPanel1.Location = new Point(0, 0);
            //};
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            this.panel1.Width = this.flowLayoutPanel1.Width - 6;
        }


        public void Add_Panel(string Mname, string Title, string Text)
        {
            FlowLayoutPanel pn = new FlowLayoutPanel()
            {
                Name = Mname,
                MinimumSize = new Size(this.flowLayoutPanel1.Width - 18, 0),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.FromArgb(243, 245, 247),

                FlowDirection = FlowDirection.TopDown,
                Margin = new Padding(15, 3, 0, 5),
                Padding = new Padding(10),

            };

            pn.Controls.Add(new Label() { AutoSize = true, Text = Title });
            if (!string.IsNullOrEmpty(Text))
            {

                pn.Controls.Add(new Label()
                {
                    AutoSize = true,
                    Text = Text

                });
            }

            this.flowLayoutPanel1.Controls.Add(pn);
        }
    }
}
