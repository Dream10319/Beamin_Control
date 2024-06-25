using Beamin_Control.WebSite.Out_of_Stock_Setting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Beamin_Control.WebSite.Out_of_Stock_Setting.Menu_Item;

namespace Beamin_Control.WebSite.Menu_Management
{
    public partial class Edit_Menu_Item : Form
    {
        public List<Tuple<string, string>> SELF_SERVICE_Headers = new List<Tuple<string, string>>();

        public Menu_Item mu;
        public bool Menu_Blocked;

        public string shopOwnerNumber;
        public long shopNumber, menupanId, menuGroupId, menuId;

        public Edit_Menu_Item()
        {
            InitializeComponent();
        }

        private void Edit_Menu_Item_Load(object sender, EventArgs e)
        {

            Item_Status = mu.itemStatus;
            //MessageBox.Show(mu.itemStatus, "Form load");
            if (Menu_Blocked == false)
            {
                Load_Item_For_Non_Blocked_Menu();
            }
            else
            {
                Load_Item_For_Blocked_Menu();
            }


        }





        string _Item_Status;
        public string Item_Status
        {


            get { return _Item_Status; }

            set
            {
                _Item_Status = value;
                //MessageBox.Show(value, "Item_Status");
                switch (value)
                {
                    case "ACTIVE":
                        this.SoldOut_btn.BackColor = Color.PaleTurquoise;

                        if (this.flowLayoutPanel2.Controls.Find("SoldOUT", true).FirstOrDefault() != null)
                        {
                            this.flowLayoutPanel2.Controls.RemoveByKey("SoldOUT");
                        }


                        if (Menu_Blocked == false)
                        {
                            this.Hiding_btn.BackColor = Color.PaleTurquoise;

                        }


                        break;

                    case "HIDE":

                        this.Hiding_btn.BackColor = Color.DarkSlateGray;

                        if (Menu_Blocked == false)
                        {
                            this.SoldOut_btn.BackColor = Color.PaleTurquoise;

                            if (this.flowLayoutPanel2.Controls.Find("SoldOUT", true).FirstOrDefault() != null)
                            {
                                this.flowLayoutPanel2.Controls.RemoveByKey("SoldOUT");
                            }
                        }


                        break;

                    case "SOLDOUT":

                        this.SoldOut_btn.BackColor = Color.DarkSlateGray;


                        DateTime dt = DateTime.Parse(mu.restockedAt, Web_Helper.Culture);


                        FlowLayoutPanel ff = new FlowLayoutPanel() { Name = "SoldOUT", AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
                        ff.Controls.Add(new Label() { Text = "Sold Out", AutoSize = true, BackColor = Color.Salmon, ForeColor = Color.DarkRed, Padding = new Padding(4) });
                        ff.Controls.Add(new Label()
                        {
                            Text = $"{dt.ToString("yy. M. dd (ddd)", Web_Helper.Culture).ToUpper()}, Available for sale from {dt.ToString("hh:mm tt", Web_Helper.Culture).ToUpper()}"
                            ,
                            AutoSize = true,
                            Margin = new Padding(4)
                        });


                        Button change_btn = new Button()
                        {
                            Text = "Change",
                            AutoSize = true,
                            BackColor = Color.Salmon,
                            ForeColor = Color.DarkRed
                        };

                        ff.Controls.Add(change_btn);


                        if(!this.flowLayoutPanel2.Controls.ContainsKey("SoldOUT"))
                        {
                            this.flowLayoutPanel2.Controls.Add(ff);

                        }




                        if (Menu_Blocked == false)
                        {
                            this.Hiding_btn.BackColor = Color.PaleTurquoise;
                        }


                        break;


                }

            }

        }

  


        Menu_item Menu_Item_Response_Non_Blocked;

        Menu_item_02 Menu_Item_Response_Blocked;


        public List<string> Prices
        {

            get
            {
                Prices.Clear();
                foreach (Label s in this.Prices_List.Controls)
                {
                    Prices.Add(s.Text);
                }
                return Prices;
            }
            set
            {


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

        private void Load_Item_For_Non_Blocked_Menu()
        {

            Thread th = new Thread(new ThreadStart(() =>
            {


                string Response = null;

#if !Design_Test



                Task<IRestResponse> menupanItem_Task = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/v1/shop-owners/{shopOwnerNumber}/menus/{menuId}", Method.GET, null, null, SELF_SERVICE_Headers));
                menupanItem_Task.Wait();

                Response = menupanItem_Task.Result.Content.ToString();
#else
                //Response = System.IO.File.ReadAllText(Application.StartupPath + "\\Response\\Menu_Item_01.json");
                Response = System.IO.File.ReadAllText(Application.StartupPath + @"\Response\Menu Items\Menu Item 03.json");
#endif


                if (!string.IsNullOrEmpty(Response))
                {

                    Menu_Item_Response_Non_Blocked = JsonConvert.DeserializeObject<Menu_item>(Response);
                    //Menu_item_02 _menupan_Response = JsonConvert.DeserializeObject<Menu_item_02>(Response);


                    if (Menu_Item_Response_Non_Blocked.data == null)
                    {
                        MessageBox.Show("Loading Menu Error Please Try Again Later", "Server Error"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //shopOwnerNumber

                        //Stores that sell this menu


                        Group_Item[] GR = new Group_Item[5];

                        GR[0] = new Group_Item();
                        GR[0].I_Name.Text = "이 메뉴를 판매하는 가게";//"Stores that sell this menu"


                        if (Menu_Item_Response_Non_Blocked.data.useShops != null)
                        {
                            UseShop UseShop = Menu_Item_Response_Non_Blocked.data.useShops.FirstOrDefault();
                            GR[0].Menu_Items.Controls.Add(new Label()
                            {
                                AutoSize = true,
                                Text = string.Format("[{0}] {1}", UseShop.menuGroupName, UseShop.shopName)
                            });



                            GR[0].Menu_Items.Controls.Add(new Label()
                            {
                                AutoSize = true,
                                Text = string.Format("[{0}] {1}", UseShop.category, UseShop.shopId)
                            });
                        }


                        GR[1] = new Group_Item();
                        GR[1].I_Name.Text = "구성 및 설명"; //Composition and Description
                        GR[1].Menu_Items.Controls.Add(new Label()
                        {
                            AutoSize = true,
                            //composition
                            Text = "구성" + "\r\n" + (string.IsNullOrEmpty(Menu_Item_Response_Non_Blocked.data.menuComposition) ? "등록된 내용이 없어요." : Menu_Item_Response_Non_Blocked.data.menuComposition)

                        });
                        GR[1].Menu_Items.Controls.Add(new Label()
                        {
                            AutoSize = true,
                            //explanation
                            Text = "설명" + "\r\n" + (string.IsNullOrEmpty(Menu_Item_Response_Non_Blocked.data.menuDesc) ? "등록된 내용이 없어요." : Menu_Item_Response_Non_Blocked.data.menuDesc)
                        });


                        if (Menu_Item_Response_Non_Blocked.data.optionGroups != null && Menu_Item_Response_Non_Blocked.data.optionGroups.Count >= 1)
                        {


                            OptionGroup optionGroups = Menu_Item_Response_Non_Blocked.data.optionGroups.FirstOrDefault();

                            GR[2] = new Group_Item();
                            GR[2].I_Name.Text = "옵션"; //option
                            GR[2].Menu_Items.Controls.Add(new Label()
                            {
                                AutoSize = true,
                                Text = string.Format("Minimum of {0} {1} selection Maximum of {2} {1}", optionGroups.minOrderQuantity, optionGroups.optionGroupName, optionGroups.maxOrderQuantity)
                            });


                            GR[2].Menu_Items.Controls.Add(new Label()
                            {
                                AutoSize = true,
                                Text = string.Format("{0} menu using this option", optionGroups.mappedMenuCount)
                            });

                            foreach (Option Option in optionGroups.options)
                            {
                                optionGroups_Edit_Item O = new optionGroups_Edit_Item();
                                O.Option_Name.Text = Option.optionName;
                                O.Option_Price.Text = Option.optionPrice.ToString();
                                //O.BackColor = Color.Red;
                                //O.Width = GR[2].Width;
                                O.Dock = DockStyle.Fill;
                                GR[2].Menu_Items.Controls.Add(O);
                            }
                        }

                        //1 menu using this option


                        //

                        this.flowLayoutPanel1.Invoke(new Action(() =>
                        { // bug here when form closed
                            mu.Menu_Name = Menu_Item_Response_Non_Blocked.data.menuName;
                            this.menuName_LB.Text = Menu_Item_Response_Non_Blocked.data.menuName;

                            mu.restockedAt = Menu_Item_Response_Non_Blocked.data.menuStatusResponse.restockedAt;
                            mu.itemStatus = Menu_Item_Response_Non_Blocked.data.menuStatusResponse.status;
                            Item_Status = mu.itemStatus;

                            //if (Menu_Item_Response_Non_Blocked.data.menuPrices.Count >= 0) // will Check
                            //{
                            //    MenuPrice price = Menu_Item_Response_Non_Blocked.data.menuPrices.FirstOrDefault();
                            //    //mu.label2.Text = $"{mp.menuPrices[0].name} {mp.menuPrices[0].price}";
                            //    mu.Price = $"{price.menuPriceName} {price.menuPrice}";

                            //}
                            //this.menuPrice_LB.Text = mu.Price;


                            if (Menu_Item_Response_Non_Blocked.data.menuPrices.Count >= 0) 
                            {
                                List<string> All_Prices = new List<string>();

                                foreach (MenuPrice Price in Menu_Item_Response_Non_Blocked.data.menuPrices)
                                {
                                    All_Prices.Add($"{Price.menuPriceName} {Price.menuPrice}");
                                }
                                mu.Prices = All_Prices;
                                this.Prices = mu.Prices;

                            }


                            foreach (Group_Item G in GR)
                            {
                                if (G != null)
                                {

                                    G.AutoSize = true; G.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                                    G.MinimumSize = new Size(this.panel1.Width, 0);
                                    this.flowLayoutPanel1.Controls.Add(G);

                                }
                            }
                        }));











                    }



                }

            }));

            th.IsBackground = true;
            th.Start();
        }

        private void Load_Item_For_Blocked_Menu()
        {

            Thread th = new Thread(new ThreadStart(() =>
            {


                string Response = null;

#if !Design_Test





                Task<IRestResponse> menupanItem_Task = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/ceo/v3/shops/{shopNumber}/menupans/{menupanId}/menu-groups/{menuGroupId}/menus/{menuId}", Method.GET, null, null, SELF_SERVICE_Headers));
                menupanItem_Task.Wait();

                Response = menupanItem_Task.Result.Content.ToString();
#else
                Response = System.IO.File.ReadAllText(Application.StartupPath + "\\Response\\Menu_Item_02.json");
#endif


                if (!string.IsNullOrEmpty(Response))
                {

                    Menu_Item_Response_Blocked = JsonConvert.DeserializeObject<Menu_item_02>(Response);
                    //Menu_item_02 _menupan_Response = JsonConvert.DeserializeObject<Menu_item_02>(Response);

                    if (Menu_Item_Response_Blocked.Data == null)
                    {
                        MessageBox.Show("Loading Menu Error Please Try Again Later", "Server Error"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        //Item_Status = mu.itemStatus;

                        //Menu_Item_Response_Blocked.Data.DisplayYn


                        //shopOwnerNumber

                        //Stores that sell this menu


                        Group_Item[] GR = new Group_Item[5];

                        GR[0] = new Group_Item();
                        GR[0].I_Name.Text = "이 메뉴를 판매하는 가게";//"Stores that sell this menu"

                        //if (_menupan_Response.Data.useShops != null)
                        //{
                        //    UseShop UseShop = _menupan_Response.data.useShops.FirstOrDefault();
                        //    GR[0].Menu_Items.Controls.Add(new Label()
                        //    {
                        //        AutoSize = true,
                        //        Text = string.Format("[{0}] {1}", UseShop.menuGroupName, UseShop.shopName)
                        //    });



                        //    GR[0].Menu_Items.Controls.Add(new Label()
                        //    {
                        //        AutoSize = true,
                        //        Text = string.Format("[{0}] {1}", UseShop.category, UseShop.shopId)
                        //    });
                        //}


                        GR[1] = new Group_Item();
                        GR[1].I_Name.Text = "구성 및 설명"; //Composition and Description
                        GR[1].Menu_Items.Controls.Add(new Label()
                        {
                            AutoSize = true,
                            //composition
                            Text = "구성" + "\r\n" + (string.IsNullOrEmpty(Menu_Item_Response_Blocked.Data.SimpleDescription) ? "등록된 내용이 없어요." : Menu_Item_Response_Blocked.Data.SimpleDescription)

                        });

                        GR[1].Menu_Items.Controls.Add(new Label()
                        {
                            AutoSize = true,
                            //explanation
                            Text = "설명" + "\r\n" + (string.IsNullOrEmpty(Menu_Item_Response_Blocked.Data.Description) ? "등록된 내용이 없어요." : Menu_Item_Response_Blocked.Data.Description)
                        });


                        if (Menu_Item_Response_Blocked.Data.OptionGroups != null && Menu_Item_Response_Blocked.Data.OptionGroups.Count() >= 1)
                        {


                            OptionGroup_02 optionGroups = Menu_Item_Response_Blocked.Data.OptionGroups.FirstOrDefault();

                            GR[2] = new Group_Item();
                            GR[2].I_Name.Text = "옵션"; //option
                            GR[2].Menu_Items.Controls.Add(new Label()
                            {
                                AutoSize = true,
                                Text = string.Format("Minimum of {0} {1} selection Maximum of {2} {1}", optionGroups.MinOrderableQuantity, optionGroups.Name, optionGroups.MaxOrderableQuantity),
                                Margin = new Padding(0, 0, 0, 0)

                            }); ;


                            //GR[2].Menu_Items.Controls.Add(new Label()
                            //{
                            //    AutoSize = true,
                            //    Text = string.Format("{0} menu using this option", optionGroups.mappedMenuCount)
                            //});

                            foreach (Option_02 Option in optionGroups.Options)
                            {
                                optionGroups_Edit_Item O = new optionGroups_Edit_Item();
                                O.Option_Name.Text = Option.Name;
                                O.Option_Price.Text = Option.Price.ToString();
                                //O.BackColor = Color.Red;
                                //O.MinimumSize = new Size (this.panel1.Width-16, 0);
                                //O.MinimumSize = new Size (GR[2].Width , 0);
                                //O.Margin = new Padding(5);
                                //O.Dock = DockStyle.Fill;
                                if (Option.DisplayYn == false)
                                {
                                    O.button2.BackColor = Color.DarkTurquoise;
                                }

                                if (Option.SoldOut == true)
                                {
                                    O.button1.BackColor = Color.DarkTurquoise;
                                }

                                GR[2].Menu_Items.Controls.Add(O);
                            }
                        }


                        //1 menu using this option


                        //

                        this.flowLayoutPanel1.Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(Menu_Item_Response_Blocked.Data.RestockedAt))
                            {
                                mu.restockedAt = Menu_Item_Response_Blocked.Data.RestockedAt;
                                mu.itemStatus = "SOLDOUT";

                            }
                            else
                            {
                                mu.itemStatus = "ACTIVE";
                            }


                            mu.displayYn = Menu_Item_Response_Blocked.Data.DisplayYn;
                            Item_Status = mu.itemStatus;

                            if (Menu_Item_Response_Blocked.Data.DisplayYn == true)
                            {
                                this.Hiding_btn.BackColor = Color.PaleTurquoise;

                            }
                            else
                            {
                                this.Hiding_btn.BackColor = Color.DarkSlateGray;

                            }

                       

                            if (Menu_Item_Response_Blocked.Data.MenuPrices.Count >= 0)
                            {
                                List<string> All_Prices = new List<string>();

                                foreach (MenuPrice_02 Price in Menu_Item_Response_Blocked.Data.MenuPrices)
                                {
                                    All_Prices.Add($"{Price.Name} {Price.Price}");
                                }
                                mu.Prices = All_Prices;
                                this.Prices = mu.Prices;
                            }



                            foreach (Group_Item G in GR)
                            {
                                if (G != null)
                                {

                                    G.AutoSize = true;
                                    G.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                                    G.MinimumSize = new Size(this.panel1.Width, 0);
                                    this.flowLayoutPanel1.Controls.Add(G);

                                }
                            }
                        }));











                    }



                }

            }));


            th.IsBackground = true; th.Start();
        }


        public void Change_Item_Status_For_Non_Blocked_Menu(string _Item_Status)
        {
            Thread th = new Thread(new ThreadStart(() =>
            {


                //JArray ddd = new JArray();
                //ddd.Add (menuGroupId);


                JObject request = new JObject();
                request.Add("menuIds", new JArray(menuId));

                string Response = null;

#if !Design_Test

                //soldout

                Task<IRestResponse> menupanItem_Task = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/v1/shop-owners/{shopOwnerNumber}/status/menus/{_Item_Status}", Method.PUT, null, JsonConvert.SerializeObject(request), SELF_SERVICE_Headers));
                menupanItem_Task.Wait();

                Response = menupanItem_Task.Result.Content.ToString();

                if (!string.IsNullOrEmpty(Response))
                {

                    //Menu_item _menupan_Response = JsonConvert.DeserializeObject<Menu_item>(Response);
                    Soldout_MenuUpdateResponse _menupan_Response = JsonConvert.DeserializeObject<Soldout_MenuUpdateResponse>(Response);
                    if (_menupan_Response.data == null)
                    {
                        MessageBox.Show("Update Menu Error Please Try Again Later", "Server Error"
                      , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (_menupan_Response.message == "OK" && _menupan_Response.code == 200)
                        {

                            mu.Invoke(new Action(() =>
                            {
                                if (_Item_Status == "soldout")
                                {
                                    //if (menuGroupId == _menupan_Response.data.soldoutMenus.FirstOrDefault().menuId)
                                    //{
                                        //restockedAt = _menupan_Response.data.soldoutMenus.FirstOrDefault().restockedAt;
                                        //Item_Status = "SOLDOUT";
                                        //mu.itemStatus = Item_Status;
                                        //mu.restockedAt = restockedAt;


                                        mu.restockedAt = _menupan_Response.data.soldoutMenus.FirstOrDefault().restockedAt;
                                        mu.itemStatus = "SOLDOUT";
                                        Item_Status = mu.itemStatus;


                                

                                    //}

                                }
                                else if (_Item_Status == "active")
                                {

                                    //if (_menupan_Response.data.validMenuIds.Contains(menuGroupId))
                                    //{
                                        //Item_Status = "ACTIVE";
                                        //mu.itemStatus = Item_Status;
                                        //mu.restockedAt = null;

                                        mu.restockedAt = null;
                                        mu.itemStatus = "ACTIVE";
                                        Item_Status = mu.itemStatus;
                                    //}

                                }

                                else if (_Item_Status == "hide")
                                {

                                    //if (_menupan_Response.data.validMenuIds.Contains(menuGroupId))
                                    //{
                                        //Item_Status = "HIDE";
                                        //mu.itemStatus = Item_Status;
                                        //mu.restockedAt = null;

                                        mu.itemStatus = "HIDE";
                                        this.Hiding_btn.BackColor = Color.DarkSlateGray;
                                        Item_Status = mu.itemStatus;
                                    //}

                                }
                            }));
                        }
                        else
                        {
                            MessageBox.Show("Update Menu Error Please Try Again Later", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }



                }



#else
                MessageBox.Show(JsonConvert.SerializeObject(request, Formatting.Indented));

                mu.Invoke(new Action(() =>
                {



                    switch (_Item_Status)
                    {

                        case "soldout":
                           

                            mu.restockedAt = "2023-08-27 10:40:00";
                            mu.itemStatus = "SOLDOUT";
                            Item_Status = mu.itemStatus;
                            
                       

                            break;


                        case "active":
                            mu.restockedAt = null;
                            mu.itemStatus = "ACTIVE";

                            Item_Status = mu.itemStatus;


                            break;

                        case "hide":
                            mu.itemStatus = "HIDE";
                            this.Hiding_btn.BackColor = Color.DarkSlateGray;
                            Item_Status = mu.itemStatus;

                        


                            break;

                        
                    }


                }));

#endif



            }));


            th.IsBackground = true; th.Start();
        }


        public void Change_Item_Status_For_Blocked_Menu(string _Item_Status)
        {
            Thread th = new Thread(new ThreadStart(() =>
            {

                string URL = string.Empty;
                string restockedAt = null;
                switch (_Item_Status)
                {
                    case "soldout":
                        restockedAt = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd", Web_Helper.Culture);

                        URL = $"https://self-api.baemin.com/v1/smartmenu/ceo/shops/{shopNumber}/menupans/{menupanId}/menus/{menuId}/menu-soldout-on?restockedAt={restockedAt}";
                        break;

                    case "active":
                        URL = $"https://self-api.baemin.com/v1/smartmenu/ceo/shops/{shopNumber}/menupans/{menupanId}/menus/{menuId}/menu-soldout-off";
                        break;

                    case "hide":
                        URL = $"https://self-api.baemin.com/v1/smartmenu/ceo/shops/{shopNumber}/menupans/{menupanId}/menu-groups/{menuGroupId}/menus/{menuId}/display-off";

                        break;

                    case "UnHide":
                        URL = $"https://self-api.baemin.com/v1/smartmenu/ceo/shops/{shopNumber}/menupans/{menupanId}/menu-groups/{menuGroupId}/menus/{menuId}/display-on";
                        break;
                }



#if !Design_Test


                Task<IRestResponse> menupanItem_Task = Task.Run(() => Web_Helper.Send_Request(URL, Method.PUT, null, null, SELF_SERVICE_Headers));
                menupanItem_Task.Wait();



                if (menupanItem_Task.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    mu.Invoke(new Action(() =>
                    {



                        switch (_Item_Status)
                        {

                            case "soldout":
                                mu.restockedAt = restockedAt;
                                mu.itemStatus = "SOLDOUT";
                                Item_Status = mu.itemStatus;

                                break;


                            case "active":
                                mu.itemStatus = "ACTIVE";
                                mu.restockedAt = null;
                                Item_Status = mu.itemStatus;
                                break;

                            case "hide":
                                this.Hiding_btn.BackColor = Color.DarkSlateGray;
                                mu.displayYn = false;


                                break;

                            case "UnHide":
                                this.Hiding_btn.BackColor = Color.PaleTurquoise;
                                mu.displayYn = true;

                                break;
                        }


                    }));
                }
                else
                {
                    MessageBox.Show("Update Menu Error Please Try Again Later", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



#else
                //MessageBox.Show(JsonConvert.SerializeObject(request, Formatting.Indented));

                mu.Invoke(new Action(() =>
                {



                    switch (_Item_Status)
                    {

                        case "soldout":
                            //restockedAt = "2023-08-27 10:40:00";
                            mu.restockedAt = restockedAt;
                            mu.itemStatus = "SOLDOUT";
                            Item_Status = mu.itemStatus;

                            break;


                        case "active":
                            mu.itemStatus = "ACTIVE";
                            mu.restockedAt = null;
                            Item_Status = mu.itemStatus;

                            break;

                        case "hide":
                            //mu.itemStatus = "HIDE";
                            //mu.restockedAt = null;
                            this.Hiding_btn.BackColor = Color.DarkSlateGray;

                            mu.displayYn = false ;


                            break;

                        case "UnHide":
                            this.Hiding_btn.BackColor = Color.PaleTurquoise;
                            mu.displayYn = true ;

                            break;
                    }


                }));

#endif



            }));


            th.IsBackground = true; th.Start();
        }



        private void SoldOut_btn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(mu.itemStatus);

            if (Menu_Blocked == true)
            {
                if (mu.itemStatus == "SOLDOUT")
                {
                    Change_Item_Status_For_Blocked_Menu("active");

                }
                else
                {
                    Change_Item_Status_For_Blocked_Menu("soldout");

                }

            }
            else
            {
                if (mu.itemStatus == "ACTIVE" || mu.itemStatus == "HIDE")
                //if(!mu.item_Status.Contains(Status.SOLDOUT )  )
                {
                    Change_Item_Status_For_Non_Blocked_Menu("soldout");


                }
                else
                {
                    Change_Item_Status_For_Non_Blocked_Menu("active");

                }


            }







            //if (mu.itemStatus == "ACTIVE")
            //{

            //    if (useMenupanId == false)
            //    {
            //        Change_Item_Status("soldout");

            //    }
            //    else
            //    {

            //        Change_Item_Status_02("soldout");

            //    }


            //    //restockedAt = "2024-01-11 10:40:00";
            //    //Item_Status = "SOLDOUT";

            //    //mu.itemStatus = Item_Status;
            //    //mu.restockedAt = restockedAt;


            //}
            //else if (mu.itemStatus == "SOLDOUT")
            //{


            //    if (useMenupanId == false)
            //    {
            //        Change_Item_Status("active");

            //    }
            //    else
            //    {

            //        Change_Item_Status_02("active");

            //    }






            //    //Item_Status = "ACTIVE";
            //    //mu.itemStatus = Item_Status;
            //    //mu.restockedAt = null;



            //}



        }

        private void Hiding_btn_Click(object sender, EventArgs e)
        {
            //

            if (Menu_Blocked == true)
            {


                if (mu.displayYn == true)
                {
                    Change_Item_Status_For_Blocked_Menu("hide");


                }
                else
                {
                    Change_Item_Status_For_Blocked_Menu("UnHide");

                }


            }

            else
            {
                if (mu.itemStatus == "ACTIVE" || mu.itemStatus == "SOLDOUT")
                {
                    Change_Item_Status_For_Non_Blocked_Menu("hide");


                }
                else if (mu.itemStatus == "HIDE" || mu.itemStatus == "SOLDOUT")
                {
                    Change_Item_Status_For_Non_Blocked_Menu("active");

                }

            }



        }

        private void Price_Change_btn_Click(object sender, EventArgs e)
        {


            if (Menu_Blocked == false)
            {
                Change_Price_For_Non_Blocked_Menu();
            }
            else
            {
                Change_Price_For_Blocked_Menu();
            }


        }

        void Change_Price_For_Non_Blocked_Menu()
        {
            if (Menu_Item_Response_Non_Blocked != null)
            {
                Price_Change_frm frm = new Price_Change_frm() { Text = Price_Change_btn.Text };
                foreach (MenuPrice cc in Menu_Item_Response_Non_Blocked.data.menuPrices)
                {
                    frm.Add_New_Price_Item(cc.menuPriceId, cc.menuPriceName, cc.menuPrice.ToString(), cc.offlineMenuPrice);
                }

                if (frm.ShowDialog(this) == DialogResult.OK)
                {

                    List<MenuPrice> _MenuPrice = new List<MenuPrice>();
                    foreach (FlowLayoutPanel pn in frm.flowLayoutPanel1.Controls)
                    {

                        _MenuPrice.Add(new MenuPrice()
                        {
                            menuPriceId = ((other_Data)pn.Tag).Price_Id,
                            menuPriceName = pn.Controls.Cast<TextBox>().Where(x => x.Name == "Price_Name").FirstOrDefault().Text,
                            menuPrice = long.Parse(pn.Controls.Cast<TextBox>().Where(x => x.Name == "Price_Text").FirstOrDefault().Text),
                            offlineMenuPrice = ((other_Data)pn.Tag).offlineMenuPrice,
                        });

                    }


                    List<MenupanMenuPrice> _menupanMenuPrices = new List<MenupanMenuPrice>();
                    foreach (MenupanMenuPrice P in Menu_Item_Response_Non_Blocked.data.menupanMenuPrices)
                    {
                        _menupanMenuPrices.Add(P);
                    }



                    JObject dd = new JObject();
                    dd.Add("menuPrices", JToken.FromObject(_MenuPrice));
                    dd.Add("menupanMenuPrices", JToken.FromObject(_menupanMenuPrices));






#if !Design_Test
                    string Request = JsonConvert.SerializeObject(dd);

                    Thread th = new Thread(new ThreadStart(() =>
                    {
                        Task<IRestResponse> menupanItem_Task = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/v1/shop-owners/{shopOwnerNumber}/menus/{menuId}/price", Method.PUT, null, Request, SELF_SERVICE_Headers));
                        menupanItem_Task.Wait();

                        string Response = menupanItem_Task.Result.Content.ToString();

                        if (!string.IsNullOrEmpty(Response))
                        {

                            //Menu_item _menupan_Response = JsonConvert.DeserializeObject<Menu_item>(Response);
                            Soldout_MenuUpdateResponse _menupan_Response = JsonConvert.DeserializeObject<Soldout_MenuUpdateResponse>(Response);
                            if (_menupan_Response.message != "OK" || menupanItem_Task.Result.StatusCode != System.Net.HttpStatusCode.OK)
                            {
                                MessageBox.Show("Update Menu Price Error Please Try Again Later", "Server Error"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                this.Invoke(new Action(() =>
                                {
                                    //menuPrice_LB.Text = _MenuPrice.FirstOrDefault().menuPrice.ToString();
                                    //mu.Price = $"{_MenuPrice.FirstOrDefault().menuPriceName} {_MenuPrice.FirstOrDefault().menuPrice}";
                                    Menu_Item_Response_Non_Blocked.data.menuPrices.Clear();
                                    Menu_Item_Response_Non_Blocked.data.menuPrices = _MenuPrice;

                                    if (_MenuPrice.Count >= 0)
                                    {
                                        List<string> All_Prices = new List<string>();

                                        foreach (MenuPrice Price in _MenuPrice)
                                        {
                                            All_Prices.Add($"{Price.menuPriceName} {Price.menuPrice}");
                                        }

                                        Menu_Item_Response_Non_Blocked.data.menuPrices = _MenuPrice;

                                        mu.Prices = All_Prices;
                                        this.Prices = mu.Prices;
                                    }


                                 
                                }));


                            }



                        }

                    }));
                    th.IsBackground = true; th.Start();
#else


                    //mu.Price = $"{_MenuPrice.FirstOrDefault().menuPriceName} {_MenuPrice.FirstOrDefault().menuPrice}";

                    string Request = JsonConvert.SerializeObject(dd, Formatting.Indented);

                    MessageBox.Show(Request);
                    Clipboard.SetText(Request);
#endif

                }






            }
        }


        void Change_Price_For_Blocked_Menu()
        {
            if (Menu_Item_Response_Blocked != null)
            {
                Price_Change_frm frm = new Price_Change_frm() { Text = Price_Change_btn.Text };
                foreach (MenuPrice_02 cc in Menu_Item_Response_Blocked.Data.MenuPrices)
                {
                    frm.Add_New_Price_Item(cc.Id, cc.Name, cc.Price.ToString(), null, true);
                }

                //frm.Add_Price_Btn.Enabled = false;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {

                    Price_Update_Json Menu_Item = new Price_Update_Json()
                    {
                        id = Menu_Item_Response_Blocked.Data.Id,
                        name = Menu_Item_Response_Blocked.Data.Name,
                        simpleDescription = Menu_Item_Response_Blocked.Data.SimpleDescription,
                        typeCode = Menu_Item_Response_Blocked.Data.TypeCode,
                        description = Menu_Item_Response_Blocked.Data.Description,
                        cookTypeCode = Menu_Item_Response_Blocked.Data.CookTypeCode,
                        cookTypeDescription = Menu_Item_Response_Blocked.Data.CookTypeDescription,
                        allergy = Menu_Item_Response_Blocked.Data.Allergy,
                        menuStockCount = Menu_Item_Response_Blocked.Data.MenuStockCount,
                        displayYn = Menu_Item_Response_Blocked.Data.DisplayYn, // 
                        solo = Menu_Item_Response_Blocked.Data.Solo,
                        restockedAt = Menu_Item_Response_Blocked.Data.RestockedAt,
                        vegetarianMenuYn = Menu_Item_Response_Blocked.Data.VegetarianMenuYn,
                        popularMenuYn = Menu_Item_Response_Blocked.Data.PopularMenuYn,
                        representativeMenu = Menu_Item_Response_Blocked.Data.RepresentativeMenu,


                        nutrient = Menu_Item_Response_Blocked.Data.Nutrient,
                        //menuPrices = Menu_Item_Response.Data.MenuPrices,//
                        menuPrices = new List<MenuPrice_02>(),

                        //menuImages = Menu_Item_Response.Data.MenuImages,
                        //images= Menu_Item_Response.Data.Images,
                        menuImages = Menu_Item_Response_Blocked.Data.MenuImages.OrderByDescending(x => x.ImageTypeCode == "THUMBNAIL").ToList(),
                        images = new List<List<DataImage>>(),



                        //images = new DataImage[][] { },

                        vegetarianMenuAttr = Menu_Item_Response_Blocked.Data.VegetarianMenuAttr,
                        promotions = Menu_Item_Response_Blocked.Data.Promotions,
                        menuImageAcceptResponse = Menu_Item_Response_Blocked.Data.MenuImageAcceptResponse,
                        menuVegetarianAcceptResponse = Menu_Item_Response_Blocked.Data.MenuVegetarianAcceptResponse,

                        menuDisplayScheduleTime = Menu_Item_Response_Blocked.Data.MenuDisplayScheduleTime,
                        menuDisplayScheduleDay = Menu_Item_Response_Blocked.Data.MenuDisplayScheduleDay,

                        optionGroups = new List<long>(),
                    };


                    foreach (var rr in Menu_Item_Response_Blocked.Data.Images)
                    {
                        List<DataImage> ddd = rr.OrderByDescending(s => s.ImageType == "THUMBNAIL").ToList();
                        Menu_Item.images.Add(ddd);
                    }

                    foreach (OptionGroup_02 t in Menu_Item_Response_Blocked.Data.OptionGroups)
                    {
                        Menu_Item.optionGroups.Add(t.Id);
                    }

                    foreach (FlowLayoutPanel pn in frm.flowLayoutPanel1.Controls)
                    {

                        Menu_Item.menuPrices.Add(new MenuPrice_02()
                        {
                            //Id = long.Parse(pn.Tag.ToString()),
                            Id = ((other_Data)pn.Tag).Price_Id,
                            Name = pn.Controls.Cast<TextBox>().Where(x => x.Name == "Price_Name").FirstOrDefault().Text,
                            Price = long.Parse(pn.Controls.Cast<TextBox>().Where(x => x.Name == "Price_Text").FirstOrDefault().Text),
                        });

                    }






#if !Design_Test
                    string Request = JsonConvert.SerializeObject(Menu_Item);

                    Thread th = new Thread(new ThreadStart(() =>
                    {

                        Task<IRestResponse> menupanItem_Task = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/ceo/v3/shops/{shopNumber}/menupans/{menupanId}/menu-groups/{menuGroupId}/menus/{menuId}", Method.PUT, null, Request, SELF_SERVICE_Headers));
                        menupanItem_Task.Wait();

                        string Response = menupanItem_Task.Result.Content.ToString();

                        if (!string.IsNullOrEmpty(Response))
                        {

                            //Menu_item _menupan_Response = JsonConvert.DeserializeObject<Menu_item>(Response);
                            Menu_item_02 _menupan_Response = JsonConvert.DeserializeObject<Menu_item_02>(Response);
                            if (_menupan_Response.Message != "OK" || menupanItem_Task.Result.StatusCode != System.Net.HttpStatusCode.OK || _menupan_Response.Data == null)
                            {
                                MessageBox.Show("Update Menu Price Error Please Try Again Later", "Server Error"
                              , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                this.Invoke(new Action(() =>
                                {
                                    //menuPrice_LB.Text = $"{Menu_Item.menuPrices.FirstOrDefault().Name} {Menu_Item.menuPrices.FirstOrDefault().Price}";
                                    //mu.Price = menuPrice_LB.Text;

                                    //menuPrice_LB.Text = $"{_menupan_Response.Data.MenuPrices.FirstOrDefault().Name} {_menupan_Response.Data.MenuPrices.FirstOrDefault().Price}";
                                    //mu.Price = menuPrice_LB.Text;


                                    if (_menupan_Response.Data.MenuPrices.Count >= 0)
                                    {
                                        List<string> All_Prices = new List<string>();

                                        foreach (MenuPrice_02 Price in _menupan_Response.Data.MenuPrices)
                                        {
                                            All_Prices.Add($"{Price.Name} {Price.Price}");
                                        }
                                        Menu_Item_Response_Blocked.Data.MenuPrices = Menu_Item.menuPrices;
                                        mu.Prices = All_Prices;
                                        this.Prices = mu.Prices;
                                    }


                                }));


                            }



                        }

                    }));
                    th.IsBackground = true; th.Start();
#else
                    string Request = JsonConvert.SerializeObject(Menu_Item, Formatting.Indented);

                    MessageBox.Show(Request);
                    Clipboard.SetText(Request);
#endif


                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Menu_Blocked == false)
            {
                Change_Menu_Name_01();
            }


        }


        void Change_Menu_Name_01()
        {
            Change_Menu_Name_Frm frm = new Change_Menu_Name_Frm() { Text = this.button1.Text };
            frm.textBox1.Text = Menu_Item_Response_Non_Blocked.data.menuName;

            if (Menu_Item_Response_Non_Blocked.data != null)
            {

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    JObject dd = new JObject();
                    dd.Add("menuType", JToken.FromObject(Menu_Item_Response_Non_Blocked.data.menuType));
                    dd.Add("menuName", JToken.FromObject(frm.textBox1.Text.Length <= 30 ? frm.textBox1.Text : frm.textBox1.Text.Substring(0, 30)));
                    dd.Add("useShops", JToken.FromObject(Menu_Item_Response_Non_Blocked.data.useShops));
                    dd.Add("soloYn", JToken.FromObject(Menu_Item_Response_Non_Blocked.data.soloYn));
                    dd.Add("vegetarianYn", JToken.FromObject(Menu_Item_Response_Non_Blocked.data.vegetarianYn));
                    dd.Add("menuPrices", JToken.FromObject(Menu_Item_Response_Non_Blocked.data.menuPrices));
#if !Design_Test
                    string Request = JsonConvert.SerializeObject(dd);
                    //string Request2 = JsonConvert.SerializeObject(dd, Formatting.Indented); // For Testing Test

                    Task<IRestResponse> menupanItem_Task = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/v1/shop-owners/{shopOwnerNumber}/menus/{menuId}/base-info", Method.PUT, null, Request, SELF_SERVICE_Headers));
                    menupanItem_Task.Wait();

                    string Response = menupanItem_Task.Result.Content.ToString();

                    if (!string.IsNullOrEmpty(Response))
                    {

                        //Menu_item _menupan_Response = JsonConvert.DeserializeObject<Menu_item>(Response);
                        Soldout_MenuUpdateResponse _menupan_Response = JsonConvert.DeserializeObject<Soldout_MenuUpdateResponse>(Response);
                        if (_menupan_Response.message != "OK" || menupanItem_Task.Result.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Update Menu Price Error Please Try Again Later", "Server Error"
                          , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            this.Invoke(new Action(() =>
                            {
                                this.menuName_LB.Text = dd["menuName"].ToString();

                                mu.Menu_Name = String.Format("{0} {1}", mu.popularMenuYn == true ? "인기" : "", dd["menuName"].ToString());
                                Menu_Item_Response_Non_Blocked.data.menuName = dd["menuName"].ToString();

                              
                                this.menuName_LB.Text = Menu_Item_Response_Non_Blocked.data.menuName;

                                //MessageBox.Show(Request2);
                                //Clipboard.SetText(Request2);

                            }));


                        }



                    }



#else
                    string Request = JsonConvert.SerializeObject(dd, Formatting.Indented);

                    MessageBox.Show(Request);
                    Clipboard.SetText(Request);
#endif
                }
            }

        }


    }



    #region Menu Update Response

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class SoldoutData
    {
        public List<SoldoutMenu> soldoutMenus { get; set; }


        public List<long> validMenuIds { get; set; }
        public List<object> invalidMenuIds { get; set; }

    }

    public class Soldout_MenuUpdateResponse
    {
        public long timestamp { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public SoldoutData data { get; set; }
    }

    public class SoldoutMenu
    {
        public int menuId { get; set; }
        public string restockedAt { get; set; }
    }



    #endregion



}
