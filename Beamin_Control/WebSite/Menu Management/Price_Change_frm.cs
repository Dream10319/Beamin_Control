using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.WebSite.Menu_Management
{
    public partial class Price_Change_frm : Form
    {
        public Price_Change_frm()
        {
            InitializeComponent();
        }


        public void Add_New_Price_Item(long Price_Id, string price_name, string Price, object offlineMenuPrice=null, bool Item_Block=false )
        {
            FlowLayoutPanel pn = new FlowLayoutPanel()
            {

                Tag = new other_Data() {  Price_Id = Price_Id , offlineMenuPrice = offlineMenuPrice },
                MinimumSize = new Size(this.flowLayoutPanel1.Width - 6, 0),
                MaximumSize = new Size(this.flowLayoutPanel1.Width - 6, 0),
                AutoSize = true,
                WrapContents = true,
            };

            Button btn = new Button()
            {
                Text = "삭제",
                AutoSize = true,
                ForeColor = Color.Red,
                //Padding = new Padding (10),
                Cursor = Cursors.Hand ,
                //Enabled = Item_Block ==false ? true : false ,
                Enabled = false ,
            };
            //btn.Click += (ss, ee) =>
            //{
            //    if(this.flowLayoutPanel1.Controls.Count > 1)
            //    {
            //        this.flowLayoutPanel1.Controls.Remove(pn);

            //    }
            //};

            pn.Controls.Add(new TextBox()
            {
                Name = "Price_Name",

                ReadOnly = Item_Block,
                Text = price_name,
                BackColor = Item_Block==true ? Color.Gray:Color.WhiteSmoke,
                //Width = (pn.MinimumSize.Width - 12  ) / 2
                Width = ((pn.MinimumSize.Width - 20) - btn.Width) / 2,
                MaxLength = 30


            });

            TextBox Price_Text = new TextBox()
            {
                Name = "Price_Text",
                Text = Price,
                TextAlign = HorizontalAlignment.Center,
                Width = ((pn.MinimumSize.Width - 20) - btn.Width) / 2

            };

          

            Label Price_Warning = new Label()
            {
                Name = "Price_Warning",
                Visible = false,
                AutoSize = true,

            };



            Price_Text.TextChanged += (ss, ee) =>
            {
                if (string.IsNullOrEmpty(Price_Text.Text))
                {
                    Price_Warning.Visible = true;
                    Price_Warning.Text = "가격을 1원 이상 입력해주세요.";
                    Price_Warning.ForeColor = Color.Red;

                }
                else
                {

                    if (int.Parse(Price_Text.Text) < 1000)
                    {
                        Price_Warning.Visible = true;
                        Price_Warning.Text = "1,000원 아래로 입력했어요. 가격을 한번 더 확인해주세요.";
                        Price_Warning.ForeColor = Color.OrangeRed;


                    }
                    else
                    {
                        Price_Warning.Visible = false;

                    }
                }

            };

            Price_Text.KeyPress += (ss, ee) =>
            {
                if (Char.IsNumber(ee.KeyChar) || Char.IsControl(ee.KeyChar))
                {
                    ee.Handled = false;

                }
                else
                {
                    ee.Handled = true;
                }



            };

            pn.Controls.Add(Price_Text);
            pn.Controls.Add(btn);

            pn.Controls.Add(Price_Warning);


            this.flowLayoutPanel1.Controls.Add(pn);
        }


    

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (FlowLayoutPanel pn in this.flowLayoutPanel1.Controls)
            {
                var tt = pn.Controls.Cast<TextBox>().Where(x => x.Name == "Price_Text").FirstOrDefault();
                if (string.IsNullOrEmpty(tt.Text) || int.Parse (tt.Text ) < 1000)
                {
                    return;
                }
            }


            this.DialogResult = DialogResult.OK;


        }

        private void Price_Change_frm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_New_Price_Item(0, String.Empty, String .Empty );
        }
    }


    public class other_Data
    {
        public long Price_Id;
        public object offlineMenuPrice;
    }

}
