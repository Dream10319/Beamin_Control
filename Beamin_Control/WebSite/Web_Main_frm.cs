using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Beamin_Control.WebSite.Boss_Notice;
using Beamin_Control.WebSite.Operation_Information;
using Beamin_Control.WebSite.Order_History;

using Beamin_Control.WebSite.Other_Response.Shop_Response;
using Beamin_Control.WebSite.Other_Response.Profile_Response;

using Beamin_Control.WebSite.Out_of_Stock;
using Beamin_Control.WebSite.Out_of_Stock_Setting;
using Beamin_Control.WebSite.Reviews;
using Beamin_Control.WebSite.Menu_Management;

//using Data = Beamin_Control.WebSite.Operation_Information.Data;
using Menu = Beamin_Control.WebSite.Out_of_Stock.Menu;

namespace Beamin_Control.WebSite
{
    public partial class Web_Main_frm : Form
    {

        List<Tuple<string, string>> SELF_SERVICE_Headers = new List<Tuple<string, string>>();
        List<Tuple<string, string>> CEO_Headers = new List<Tuple<string, string>>();


        JsonSerializerSettings settings = new JsonSerializerSettings { Error = (se, ev) => { ev.ErrorContext.Handled = true; } };

        CancellationTokenSource cancellationToken = null;
        operation_block_reason _operation_block_reason;
        string shopOwnerNumber = null;

        public Web_Main_frm()
        {
            InitializeComponent();

            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("service-channel", "SELF_SERVICE_PC"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("accept", "application/json, text/plain, */*"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-ch-ua", "\"Chromium\";v=\"104\""));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-ch-ua-mobile", "?0"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-ch-ua", "\".Not / A)Brand\";v=\"99\", \"Google Chrome\";v=\"103\", \"Chromium\";v=\"103\""));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-ch-ua-platform", "\"Windows\""));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("origin", "https://ceo.baemin.com"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-fetch-site", "same-site"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-fetch-mode", "cors"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-fetch-dest", "empty"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("referer", "https://ceo.baemin.com/"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("accept-encoding", "gzip, deflate, br"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("accept-language", "en-US,en;q=0.9"));

            SELF_SERVICE_Headers.Add(new Tuple<string, string>("service-channel", "SELF_SERVICE_PC"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("accept", "application/json, text/plain, */*"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("x-e-request", "hirfxe|1702824973569|6639750080179aa3b21780305d2a1794284cb774fc01fa1db27fe08bf33f9b5a"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-ch-ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"Google Chrome\";v=\"120\""));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-ch-ua-mobile", "?0"));
            //SELF_SERVICE_Headers.Add(new Tuple<string, string>("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-ch-ua-platform", "\"Windows\""));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("origin", "https://self.baemin.com"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-fetch-site", "same-site"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-fetch-mode", "cors"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("sec-fetch-dest", "empty"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("referer", "https://self.baemin.com/"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("accept-encoding", "gzip, deflate, br"));
            SELF_SERVICE_Headers.Add(new Tuple<string, string>("accept-language", "en-US,en;q=0.9"));

            //CEO_Headers.Add(new Tuple<string, string>("sec-ch-ua", "\"Chromium\";v=\"104\""));
            //CEO_Headers.Add(new Tuple<string, string>("accept", "application/json, text/plain, */*"));
            //CEO_Headers.Add(new Tuple<string, string>("sec-ch-ua-mobile", "?0"));
            //CEO_Headers.Add(new Tuple<string, string>("sec-ch-ua", "\".Not / A)Brand\";v=\"99\", \"Google Chrome\";v=\"103\", \"Chromium\";v=\"103\""));
            //CEO_Headers.Add(new Tuple<string, string>("sec-ch-ua-platform", "\"Windows\""));
            //CEO_Headers.Add(new Tuple<string, string>("sec-fetch-site", "same-origin"));
            //CEO_Headers.Add(new Tuple<string, string>("sec-fetch-mode", "cors"));
            //CEO_Headers.Add(new Tuple<string, string>("sec-fetch-dest", "empty"));
            //CEO_Headers.Add(new Tuple<string, string>("referer", "https://ceo.baemin.com/"));
            //CEO_Headers.Add(new Tuple<string, string>("accept-encoding", "gzip, deflate, br"));
            //CEO_Headers.Add(new Tuple<string, string>("accept-language", "en-US,en;q=0.9"));



            //--------------- New 2024
            CEO_Headers.Add(new Tuple<string, string>("sec-ch-ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"Google Chrome\";v=\"120\""));
            CEO_Headers.Add(new Tuple<string, string>("accept", "application/json, text/plain, */*"));
            CEO_Headers.Add(new Tuple<string, string>("sec-ch-ua-mobile", "?0"));
            CEO_Headers.Add(new Tuple<string, string>("sec-ch-ua-platform", "\"Windows\""));
            CEO_Headers.Add(new Tuple<string, string>("sec-fetch-site", "same-origin"));
            CEO_Headers.Add(new Tuple<string, string>("sec-fetch-mode", "cors"));
            CEO_Headers.Add(new Tuple<string, string>("sec-fetch-dest", "empty"));
            CEO_Headers.Add(new Tuple<string, string>("referer", "https://ceo.baemin.com/"));
            CEO_Headers.Add(new Tuple<string, string>("accept-encoding", "gzip, deflate, br"));
            CEO_Headers.Add(new Tuple<string, string>("accept-language", "en-US,en;q=0.9"));
        }

       public static  Dictionary<string, string> days_of_the_week = new Dictionary<string, string>();
       
        private void Apply_Language()
        {
            this.memId.Text = Program.Language.De[20000];
            this.memName.Text = Program.Language.De[20001];

            this.tabPage1.Text = Program.Language.De[20002];
            this.tabPage2.Text = Program.Language.De[20003];
            this.tabPage3.Text = Program.Language.De[20004];
            this.tabPage4.Text = Program.Language.De[20005];
            this.tabPage5.Text = Program.Language.De[20006];
            this.tabPage6.Text = Program.Language.De[20007];

            this.BossNotice_tab.Text = Program.Language.De[20008];
            this.fromBoss_tab.Text = Program.Language.De[20009];

            this.MenuSoldOut_tab.Text = Program.Language.De[20010];
            this.Optionstock_tab.Text = Program.Language.De[20011];

            this.Write_New_Boss_Notice_btn.Text = Program.Language.De[20012];
            this.Write_New_Word_btn.Text = Program.Language.De[20012];

            this.Optionstock_tab.Text = Program.Language.De[20011];
            this.Optionstock_tab.Text = Program.Language.De[20011];


        }


        private void Web_Main_frm_Load(object sender, EventArgs e)
        {





            Apply_Language();

            days_of_the_week.Add("MONDAY", Program.Language.De[26001]);
            days_of_the_week.Add("TUESDAY", Program.Language.De[26002]);
            days_of_the_week.Add("WEDNESDAY", Program.Language.De[26003]);
            days_of_the_week.Add("THURSDAY", Program.Language.De[26004]);
            days_of_the_week.Add("FRIDAY", Program.Language.De[26005]);
            days_of_the_week.Add("SATURDAY", Program.Language.De[26006]);
            days_of_the_week.Add("SUNDAY", Program.Language.De[26007]);

            //TH = new Thread(new ThreadStart(() =>
            //{
            //    MessageBox.Show("aaaa");
            //}));

            //th.IsBackground = true;
            // th.IsBackground = true;  th.IsBackground = true; th.Start();

            this.Write_New_Boss_Notice_btn.Click += (ss, ee) =>
            {
                long shop_number = ((Datum)this.Shops_List.SelectedItem).shopNumber;
                Notice_Uploader(shop_number, "notices");
            };

            this.Write_New_Word_btn.Click += (ss, ee) =>
            {
                long shop_number = ((Datum)this.Shops_List.SelectedItem).shopNumber;
                Notice_Uploader(shop_number, "announcements");
            };


            //this.Date_Selection.Text = String.Format("Date Selection\r\n{0} ~ {1}",
            //   Selected_Date.StartDate .ToString ("yyyy. MM. dd. (ddd)", Web_Helper.Culture ), Selected_Date.EndDate.ToString("yyyy. MM. dd. (ddd)", Web_Helper.Culture));
            //Show_Error_Message("NOT_AUTH", "Test", null);


            //this.All_Reviews_Lst.Container.
            this.DoubleBuffered = true;
            //this.All_Reviews_Lst


            this.Boss_Notice_List.ControlAdded += List_ControlAdded;
            this.word_from_boss_List.ControlAdded += List_ControlAdded;
            this.Operation_Information_List.ControlAdded += List_ControlAdded;

            this.Menu_Sold_Out.ControlAdded += List_ControlAdded;
            this.Option_Groups.ControlAdded += List_ControlAdded;

            this.All_Reviews_Lst.ControlAdded += List_ControlAdded;
            this.No_Comment_Reviews_Lst.ControlAdded += List_ControlAdded;
            this.Blocking_Reviews_Lst.ControlAdded += List_ControlAdded;


            TimeZoneInfo TZ = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            DateTime dt2 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TZ);


            this.Review_Date_From.Value = dt2.AddMonths(-6).AddDays(4);
            //this.Review_Date_To.Value = DateTime.Parse("2022-09-23");

            Initialize_Filters();

            //Load_Shops();


            //#if !Design_Test             
            //Load_Shops();
            //#endif


#if !Design_Test
            Load_Profile();
#else
            //this.Review_Date_From.Value = DateTime.Parse("2022-03-28");
            //this.Review_Date_To.Value = DateTime.Parse("2022-09-23");

            this.tabControl1.Enabled = true;

            //Shop_Details dd = new Shop_Details();
            //dd.menupanList = new List<MenupanList>();
            //dd.menupanList.Add(new MenupanList() { menupanId = 1338355 });
       

            string Json_Input = System.IO.File.ReadAllText(Application.StartupPath + "\\Response\\Shop_Details_03.json");
            Shop_Details Response = JsonConvert.DeserializeObject<Shop_Details>(Json_Input, settings);

            //shopOwnerNumber = "202112150426";
            //shopOwnerNumber = "201411070015";
            shopOwnerNumber = "202112150426";

            Datum New_Shop = new Datum()
            {
                name = "test",
                //shopNumber = 13770055,
                //shopNumber = 10537845,
                //shopNumber = 13544832,
                shopNumber = 13770055,
                _Shop_Details = Response
            };

            New_Shop._Shop_Details.shopNo = 13770055;
            New_Shop._Shop_Other_Details = new Shop_Other_Details() { shopId = 13770055, menupanId = 1241263, useMenupanId = 1241263 };
            this.Shops_List.Items.Add(New_Shop);
            this.Shops_List.SelectedIndex = 0;



            string Json_Input2 = System.IO.File.ReadAllText(Application.StartupPath + "\\Response\\operation-block-reason.json");
            _operation_block_reason = JsonConvert.DeserializeObject<operation_block_reason>(Json_Input2, settings);

            //int shop_number = ((Datum)this.Shops_List.SelectedItem).shopNumber;


            //Load_Menu_Sold_Out(((Datum)this.Shops_List.SelectedItem));
            //Load_Boss_Notice(shop_number, "notices");
            //Load_word_from_Boss(shop_number);
            //Load_Operation_Information(shop_number);
            //Load_Option_out_of_stock()
            //Load_Reviews();

#endif




        }

        void Load_operation_block_reason()
        {
            Thread th = new Thread(new ThreadStart(() =>
            {
                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/codes/operation-block-reason", Method.GET, null, null, SELF_SERVICE_Headers));
                tx.Wait();


                if (!string.IsNullOrEmpty(tx.Result.Content) && tx.Result.StatusCode == HttpStatusCode.OK)
                {


                    _operation_block_reason = JsonConvert.DeserializeObject<operation_block_reason>(tx.Result.Content, settings);



                }
                else
                {
                    Show_Error_Message("Connection Error", "Error On Loading Profile", null);

                }






            }));
            th.IsBackground = true; th.IsBackground = true; th.Start();
        }

        #region Profile


        bool Check_OUT_OF_BUSINESS()
        {



#if !Design_Test
            Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shop-owners/{shopOwnerNumber}", Method.GET, null, null, SELF_SERVICE_Headers));
            tx.Wait();


            if (!string.IsNullOrEmpty(tx.Result.Content))
            {

                if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(tx.Result.Content))
                {

                    JToken o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                    if (o["status"].ToString() != "OUT_OF_BUSINESS")
                    {
                        return true;
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.Shops_List.Enabled = false;
                            this.tabControl1.Enabled = false;
                        }));
                    }
                }

            }


            return false;
#else
            return true;
            //return new Task<bool>(() => true);

#endif



        }


        void Load_Profile()
        {
            this.Invoke(new Action(() =>
            {
                this.memId.Text = "Member ID: ..."; this.memName.Text = "Member Name: ...";

            }));


            Thread th = new Thread(new ThreadStart(() =>
            {
                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/session/user-profile", Method.GET, null, null, SELF_SERVICE_Headers));
                tx.Wait();


                if (!string.IsNullOrEmpty(tx.Result.Content))
                {


                    Profile_Response rs = JsonConvert.DeserializeObject<Profile_Response>(tx.Result.Content, settings);

                    if (rs.errorType == null && tx.Result.StatusCode == HttpStatusCode.OK)
                    {
                        shopOwnerNumber = rs.shopOwnerNumber;
                        this.Invoke(new Action(() =>
                        {
                            this.memId.Text = $"Username : {rs.memName}"; this.memName.Text = $"Email : {rs.decodedEmail}";
                            //this.tabControl1.Enabled = true;

                        }));
                        if (Check_OUT_OF_BUSINESS() == true)
                        {
                            Load_operation_block_reason();
                            Load_Shops();

                        }

                    }
                    else
                    {

                        Show_Error_Message(rs.errorType, rs.errorMessage, Load_Profile);
                    }

                }
                else
                {
                    Show_Error_Message("Connection Error", "Error On Loading Profile", Load_Profile);

                }






            }));
            th.IsBackground = true; th.IsBackground = true; th.Start();

        }

        #endregion

        #region Shops


        void Load_Shops()
        {
            this.Shops_List.Invoke(new Action(() =>
            {
                this.Shops_List.Controls.Clear();

            }));
            Thread th = new Thread(new ThreadStart(() =>
            {
                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://ceo.baemin.com/v2/store/shops/open?__ts={Web_Login_Helper.New_Time()}", Method.GET, null, null, CEO_Headers));
                tx.Wait();


                if (!string.IsNullOrEmpty(tx.Result.Content))
                {

                    Shops_Response rs = JsonConvert.DeserializeObject<Shops_Response>(tx.Result.Content, settings);
                    if (rs.statusMessage.ToUpper() == "OK")
                    {

                        Task<IRestResponse> tx2 = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/v1/shop-owners/{shopOwnerNumber}/shops", Method.GET, null, null, SELF_SERVICE_Headers));
                        tx2.Wait();
                        Shop_Other_Details_Response rs2 = JsonConvert.DeserializeObject<Shop_Other_Details_Response>(tx2.Result.Content, settings);


                        if (rs2.message.ToUpper() == "OK" && rs2.code == 200 && rs2.data != null)
                        {

                            foreach (Shop_Other_Details shope_data in rs2.data.shops)
                            {
                                rs.data.Where(sh => sh.shopNumber == shope_data.shopId).FirstOrDefault()._Shop_Other_Details = shope_data;
                            }


                            foreach (Datum x in rs.data)
                            {


                                Load_Shop_Details(x.shopNumber, x);
                                this.Shops_List.Invoke(new Action(() =>
                                {
                                    this.Shops_List.Items.Add(x);
                                }));
                            }



                            this.Invoke(new Action(() =>
                            {
                                if (this.Shops_List.Items.Count > 0 && (this.Shops_List.Items.Cast<Datum>().All(aa => aa._Shop_Details != null && aa._Shop_Other_Details != null) == true))
                                {
                                    this.tabControl1.Enabled = true;

                                    this.Shops_List.SelectedIndexChanged += (ss, ee) =>
                                    {
                                        tabControl1_SelectedIndexChanged(null ,EventArgs.Empty);
                                    };

                                    this.Shops_List.SelectedIndex = 0;
                                }
                            }));


                        }



                    }
                    else
                    {

                        //Show_Error_Message(rs.statusCode, rs.message, Load_Shops);
                        Show_Error_Message(rs.type, rs.message, Load_Shops);
                    }

                }


            }));
            th.IsBackground = true; th.Start();
        }

        void Load_Shop_Details(long shop_number, Datum Shop_Response)
        {
            //Thread th = new Thread(new ThreadStart(() =>
            //{

            Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shops/{shop_number}", Method.GET, null, null, SELF_SERVICE_Headers));
            tx.Wait();


            if (!string.IsNullOrEmpty(tx.Result.Content))
            {

                if (tx.Result.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(tx.Result.Content))
                {
                    Shop_Details rs = JsonConvert.DeserializeObject<Shop_Details>(tx.Result.Content, settings);
                    if (rs.shopNo == shop_number)
                    {
                        Shop_Response._Shop_Details = rs;
                    }

                }

            }


            //}));
            //th.IsBackground = true; th.IsBackground = true; th.Start();
        }



        void Shop_List_SelectedIndexChanged()
        {

        }
        #endregion





        #region Notice a word

        void Load_Boss_Notice(long shop_number, string Notice_Type)
        {
            cancellationToken = new CancellationTokenSource();

            this.Boss_Notice_List.Invoke(new Action(() =>
            {
                if (Notice_Type == "notices")
                {
                    this.Boss_Notice_List.Controls.Clear();

                }
                else if (Notice_Type == "announcements")
                {
                    this.word_from_boss_List.Controls.Clear();

                }


            }));

            Thread th = new Thread(new ThreadStart(() =>
            {

                string ind = "offset=0&limit=10";

            test:


                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/review/shops/{shop_number}/ceo/{Notice_Type}?{ind}", Method.GET, null, null, SELF_SERVICE_Headers));
                tx.Wait();


                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    Boss_Notice_Response Response = JsonConvert.DeserializeObject<Boss_Notice_Response>(tx.Result.Content.ToString());
                    if (Response.errorType != null && Response.errorMessage != null)
                    {
                        Show_Error_Message(Response.errorType, Response.errorMessage, new Action(() => { Load_Boss_Notice(shop_number, Notice_Type); }));
                        return;
                    }

                    List<Notice> Re = null;
                    if (Notice_Type == "notices")
                    {
                        Re = Response.notices;
                    }
                    else if (Notice_Type == "announcements")
                    {
                        Re = Response.announcements;
                    }

                    if (Re != null)
                    {
                        foreach (Notice gr in Re)
                        {
                            if (cancellationToken.Token.IsCancellationRequested == false)
                            {

                                Boss_Notice_Item GR = new Boss_Notice_Item();
                                GR.Tag = gr.id;
                                GR.label1.Text = gr.createdAt.ToString();
                                GR.label2.Text = gr.contents;

                                if (gr.images.Count > 0)
                                {

                                    FlowLayoutPanel all_images = new FlowLayoutPanel() { AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, Name = "all_images" };

                                    List<Tuple<PictureBox, string>> Images_To_Load = new List<Tuple<PictureBox, string>>();



                                    all_images.Margin = new Padding(0, 3, 0, 40);

                                    foreach (Boss_Notice.Image i in gr.images)
                                    {
                                        PictureBox px = new PictureBox();
                                        px.Size = new Size(150, 150);
                                        px.Margin = new Padding(5, 3, 0, 3);

                                        px.SizeMode = PictureBoxSizeMode.StretchImage;
                                        px.BorderStyle = BorderStyle.FixedSingle;
                                        // px.Load(i.imageUrl); // The request was aborted: Could not create SSL/TLS secure channel

                                        //px.Image = System.Drawing.Image.FromStream(Web_Helper.Load_Images(i.imageUrl));

                                        px.Tag = i.id;
                                        Images_To_Load.Add(new Tuple<PictureBox, string>(px, i.imageUrl));
                                        //Label lb = new Label() { Text = gr.images.Count.ToString(), AutoSize = true, BackColor = Color.Transparent, FlatStyle = FlatStyle.Flat };
                                        //px.Controls.Add(lb);
                                        //lb.Location = new Point(px.Width - (lb.Width + 3), px.Height - (lb.Height + 3));

                                        all_images.Controls.Add(px);
                                    }
                                    Load_Notice_Images(Images_To_Load);
                                    GR.Controls.Add(all_images);
                                    all_images.Location = new Point(GR.Correction_btn.Right - (all_images.Width - 2), GR.Correction_btn.Top + 5);
                                    all_images.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                                }

                                GR.Delete_btn.Click += (s, e) =>
                                {
                                    Delete_Button(Notice_Type, shop_number, gr.id, gr.contents, () => { Load_Boss_Notice(shop_number, Notice_Type); });
                                };

                                GR.Correction_btn.Click += (s, e) =>
                                {
                                    Notice_Uploader(shop_number, Notice_Type, GR);
                                };

                                GR.Upload_btn.Click += new EventHandler((s, ee) =>
                                {
                                    bool t = GR.Display == false ? true : false;

                                    Task<IRestResponse> tx2 = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/review/shops/{shop_number}/ceo/{Notice_Type}/{gr.id}?display={t}", Method.POST, null, null, SELF_SERVICE_Headers));
                                    tx2.Wait();
                                    if (tx2.Result.StatusCode == HttpStatusCode.OK)
                                    {
                                        Load_Display_Notice(shop_number, Notice_Type);

                                    }
                                    else
                                    {
                                        Show_Error_Message("Status Update Error", tx2.Result.ToString(), new Action(() => { Load_Boss_Notice(shop_number, Notice_Type); }));

                                    }

                                });

                                this.Invoke(new Action(() =>
                                {
                                    GR.MinimumSize = new Size(this.Boss_Notice_List.Width - 30, GR.Height);

                                    if (Notice_Type == "notices")
                                    {
                                        this.Boss_Notice_List.Controls.Add(GR);
                                    }
                                    else if (Notice_Type == "announcements")
                                    {
                                        this.word_from_boss_List.Controls.Add(GR);
                                    }
                                }));

                            }
                            else
                            {
                                return;
                            }

                        }

                        if (Response.next == true)
                        {

                            ind = $"offset={Re.Count}&limit=10";
                            goto test; // Get Next Items
                        }
                        else
                        {
                            Load_Display_Notice(shop_number, Notice_Type);

                        }
                    }


                }


            }));

#if !Design_Test
            th.IsBackground = true; th.Start();
#endif
        }


        void Load_Display_Notice(long shop_number, string Notice_Type)
        {

            FlowLayoutPanel main_panel = null;
            if (Notice_Type == "notices")
            {
                main_panel = this.Boss_Notice_List;


            }
            else if (Notice_Type == "announcements")
            {
                main_panel = this.word_from_boss_List;

            }

            foreach (Boss_Notice_Item x in main_panel.Controls)
            {
                x.Display = false;
            }

            Thread th = new Thread(new ThreadStart(() =>
            {

                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/review/shops/{shop_number}/ceo/{Notice_Type}/display", Method.GET, null, null, SELF_SERVICE_Headers));
                tx.Wait();


                if (!string.IsNullOrEmpty(tx.Result.Content))
                {

                    Notice Response = JsonConvert.DeserializeObject<Notice>(tx.Result.Content.ToString());

                    if (main_panel != null)
                    {
                        foreach (Boss_Notice_Item x in main_panel.Controls)
                        {
                            if (int.Parse(x.Tag.ToString()) == Response.id)
                            {
                                x.Display = true;
                                break;
                            }
                        }

                    }


                }


            }));
            th.IsBackground = true; th.Start();
        }


        void Notice_Uploader(long shop_number, string notice_type, Boss_Notice_Item Item = null)
        {


            New_Boss_Notice_frm frm = new New_Boss_Notice_frm();
            frm.Apply_Language();
            string Upload_url = $"https://self-api.baemin.com/v1/review/shops/{shop_number}/ceo/{notice_type}";

            List<int> Deleted_Images = new List<int>();
            if (Item != null)
            {
                Upload_url += $"/{Item.Tag}";
                frm.textBox1.Text = Item.label2.Text;
                frm.checkBox1.Checked = Item.Display;


                FlowLayoutPanel pn = (FlowLayoutPanel)Item.Controls["all_images"];
                if (pn != null)
                {
                    foreach (PictureBox pxi in pn.Controls)
                    {
                        PictureBox px = new PictureBox();
                        px.Image = pxi.Image;
                        px.Tag = pxi.Tag;
                        px.SizeMode = PictureBoxSizeMode.StretchImage;
                        px.Size = new Size(frm.Images_list.Height, frm.Images_list.Height);


                        Button delete_btn = new Button()
                        {
                            AutoSize = true,
                            Text = "X",
                            FlatStyle = FlatStyle.Flat,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Cursor = Cursors.Hand,
                            ForeColor = Color.Red
                        };
                        delete_btn.BackColor = Color.Transparent;

                        delete_btn.Click += (ss, ee) =>
                        {
                            Deleted_Images.Add(int.Parse(px.Tag.ToString()));
                            frm.Images_list.Controls.Remove(px);
                        };

                        px.Controls.Add(delete_btn);
                        delete_btn.Location = new Point(px.Width - (delete_btn.Width + 3), 0);


                        frm.Images_list.Controls.Add(px);
                    }
                }

            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Thread th = new Thread(new ThreadStart(async () =>
                {

                    Cookies_Class.Load_Cookies();


                    var P_client = new RestClient(Upload_url);



                    P_client.DefaultParameters.Clear();
                    if (Cookies_Class.Cookies != null)
                    {
                        P_client.CookieContainer = Cookies_Class.Cookies;

                    }


                    P_client.ConfigureWebRequest(wr =>
                    {
                        wr.AutomaticDecompression = DecompressionMethods.None;
                        wr.KeepAlive = true;
                        wr.UserAgent = Web_Helper._UserAgent;
                        wr.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                    });

#if Test_With_Proxy
                    Helper_Class.Is_IP_OK();

                    P_client.Proxy = Program.proxy;
#endif

                    var P_request = new RestRequest(Method.POST);



                    P_request.AddParameter("contents", frm.textBox1.Text);
                    P_request.AddParameter("display", frm.checkBox1.Checked);

                    foreach (int d in Deleted_Images)
                    {
                        P_request.AddParameter("deleteImageIds", d);
                    }

                    foreach (PictureBox px in frm.Images_list.Controls)
                    {
                        if (px.Tag == null)
                        {
                            P_request.AddFile("images", px.ImageLocation, "image/png");
                        }


                        //byte[] Images_Byte = null;
                        //ImageConverter cn = new ImageConverter();
                        //Images_Byte = (byte[])cn.ConvertTo(px.Image, typeof(byte[]));


                        //if( Images_Byte != null )
                        //{
                        //    P_request.AddFileBytes("images", Images_Byte,"", "image/png");

                        //}


                    }

                    P_request.AlwaysMultipartFormData = true;


                    foreach (Tuple<string, string> x in SELF_SERVICE_Headers)
                    {
                        P_request.AddHeader(x.Item1, x.Item2);
                    }


                    IRestResponse res = await P_client.ExecuteAsync(P_request);

                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        Load_Boss_Notice(shop_number, notice_type);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(res.Content))
                        {
                            Boss_Notice_Response Response = JsonConvert.DeserializeObject<Boss_Notice_Response>(res.Content.ToString());

                            if (Response.errorType != null && Response.errorMessage != null)
                            {
                                Show_Error_Message(Response.errorType, Response.errorMessage, new Action(() => { Notice_Uploader(shop_number, notice_type, Item); }));
                            }
                            else
                            {
                                Show_Error_Message("Server Error", "Can't Upload Notice Please Try Again Later", new Action(() => { Notice_Uploader(shop_number, notice_type, Item); }));

                            }
                        }

                    }

                }));
                th.IsBackground = true; th.Start();
            }

        }

        void Delete_Button(string Item_Type, long Store_ID, long Item_ID, string Item_Text, Action CallBack)
        {
            if (MessageBox.Show(this, $"Do You Want To Delete {Item_Text}", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Thread th = new Thread(new ThreadStart(() =>
                {




                    Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/review/shops/{Store_ID}/ceo/{Item_Type}/{Item_ID}", Method.DELETE, null, null, SELF_SERVICE_Headers));
                    tx.Wait();


                    if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //MessageBox.Show(tx.Result.Content);
                        CallBack();
                        //this.tabControl3.Invoke(new Action(() =>
                        //{
                        //    if ( this.tabControl3.SelectedTab == BossNotice_tab )
                        //    {
                        //        Load_Boss_Notice(Store_ID);
                        //    }
                        //    else if ( this.tabControl3.SelectedTab == fromBoss_tab )
                        //    {
                        //        Load_word_from_Boss(Store_ID);
                        //    }
                        //}));


                    }
                    else
                    {
                        Show_Error_Message("Test", "Delete Error", null);
                    }




                }));
                th.IsBackground = true; th.Start();
            }

        }



        void Load_Notice_Images(List<Tuple<PictureBox, string>> Notice_Imges)
        {



            Thread th = new Thread(new ThreadStart(() =>
            {
                if (Notice_Imges.Count > 0)
                {


                    foreach (Tuple<PictureBox, string> i in Notice_Imges)
                    {


                        WebClient dd = new WebClient();

#if Test_With_Proxy || Design_Test
                        dd.Proxy = Program.proxy;

#endif


                        if (cancellationToken.Token.IsCancellationRequested == false)
                        {


                            //px.Load(i.imageUrl);
                            //i.Image = System.Drawing.Image.FromStream(Web_Helper.Load_Images(i.Tag.ToString ()));

                            Bitmap Bm = new Bitmap(Bitmap.FromStream(new System.IO.MemoryStream(dd.DownloadDataTaskAsync(i.Item2).Result)), i.Item1.Width, i.Item1.Size.Height);
                            i.Item1.Image = Bm;


                        }
                        else
                        {
                            dd.CancelAsync();
                            break;
                            //return;
                        }

                    }
                    //Review_Images_Container.Invoke(new Action(() =>
                    //{
                    //    Review_Images_Container.Controls.Add(all_images);

                    //}));
                }

            }));
            th.IsBackground = true;
            th.Start();


        }

        #endregion




        #region Operation Information

        //List<OperationHour2> _OperationHour;
        //List<Other_Response.BreakTime> _BreakTime;

        void Operation_Info_Response(Shop_Details Response)
        {
            //MessageBox.Show("ddd");
            if (Response != null)
            {

                this.Operation_Information_List.Invoke(new Action(() =>
                {
                    this.Operation_Information_List.Controls.Clear();

                }));

                //MessageBox.Show(JsonConvert.DeserializeObject(Response.operationHour.operationHours.ToString()).ToString());
                //Shop sh = Response.data.shop != null ? Response.data.shop : Response.data.updateShopOperationInfo;

                //_BreakTime = Response.operationHour.breakTimes;

                //_BreakTime = sh.operationInfo.breakTimes;
                //_BusinessPause = sh.operationInfo.businessPause;
                //_dayOffs = sh.operationInfo.dayOffs;
                //_OperationHour = Response.operationHour.operationHours;
                //_temporaryDayOffs = sh.operationInfo.temporaryDayOffs;
                //_closeDayText = sh.operationInfo.closeDayText;

                int Items_Count = 5;
                Operation_Item[] Item = new Operation_Item[Items_Count];


                #region Opening hours
                Item[0] = new Operation_Item();
                Item[0].Item_Name.Text = Program.Language.De[24000]; //"Opening hours"
                Item[0].Change_btn.Text = Program.Language.De[24013];///"Change";




                Item[0].Response_Values = Response.operationHour.operationHours;

                if (Response.operationHour.operationHours.Count > 0)
                {
                    //OperationHour2 Check_Everyday = Response.operationHour.operationHours.First(ss => ss.intervalCode == "EVERYDAY" || ss.intervalCode == "WEEKDAY");
                    OperationHour2 Check_Everyday = Response.operationHour.operationHours.Find(ss => ss.intervalCode == "EVERYDAY" || ss.intervalCode == "WEEKDAY");

                    if (Check_Everyday != null)
                    {
                        Operation_Value O_V = new Operation_Value();
                        if (Check_Everyday.intervalCode == "EVERYDAY")
                        {
                            O_V.O_Title.Text = Program.Language.De[26008]; 

                        }
                        else if (Check_Everyday.intervalCode == "WEEKDAY")
                        {
                            O_V.O_Title.Text = Program.Language.De[26009]; 

                        }



                        if (Check_Everyday.allDay == true)
                        {
                            O_V.O_Value.Text = $"24 {Program.Language.De[24006]}";

                        }
                        else
                        {

                            O_V.O_Value.Text = Get_Time(Check_Everyday.closeTime, Check_Everyday.openTime);


                        }

                        Item[0].Operation_Values.Controls.Add(O_V);

                    }
                    else
                    {


                        foreach (var I_v in Response.operationHour.operationHours)
                        {
                            //if(Check_Everyday!= null) { }
                            Operation_Value O_V = new Operation_Value();
                            O_V.O_Title.Text = days_of_the_week[ I_v.intervalCode];

                            //if ( I_v.intervalCode == "WEEKDAY" )
                            //{
                            //    O_V.O_Title.Text = "WEEK DAY";// Translate this into korean Language
                            //}
                            //else
                            //{
                            //    DateTime To_12Time1 = DateTime.ParseExact(I_v.intervalCode, "%dddd",System.Globalization.CultureInfo.CurrentCulture);
                            //    O_V.O_Title.Text = To_12Time1.ToString ("dddd",Web_Helper.Culture ).ToUpper () ;

                            //}

                            if (I_v.allDay == true)
                            {
                                O_V.O_Value.Text = $"24 {Program.Language.De[24006]}";

                            }
                            else
                            {

                                O_V.O_Value.Text = Get_Time(I_v.closeTime, I_v.openTime);

                                //}
                                //else
                                //{
                                //    To_12Time2 = DateTime.ParseExact(int.Parse(I_v.closeHour) - 12 + "-" + I_v.closeMinute, "HH-mm", Web_Helper.Culture);
                                //    O_V.O_Value.Text = String.Format("{0} ~ 다음 날 오전 {1}", To_12Time1.ToString("hh:mm tt", Web_Helper.Culture), To_12Time2.ToString("hh:mm tt", Web_Helper.Culture));

                                //}


                                //O_V.O_Value.Text = String.Format("{0:hh}:{0:mm} {0:tt}~{1:hh}:{1:mm} {1:tt}", To_12Time1, To_12Time2);



                                //O_V.O_Value.Text = $"{O_V.O_Value.Text = To_12Time_Format(I_v.openHour)}";
                                //To_12Time_Format(I_v.closeHour, I_v.closeMinute);
                            }


                            //_OperationHour.Find<OperationHour2>().allDay =""



                            Item[0].Operation_Values.Controls.Add(O_V);
                        }
                    }


                }
                else
                {
                    Item[0].Operation_Values.Controls.Add(new Label() { Text = Program.Language.De[24005] });
                }


          

                Item[0].Change_btn.Click += (e, s) =>
                {
                    //Operation_Hours_Change_btn(Response.shopNo, Response.operationHour.operationHours);
                    Operation_Hours_Change_btn(Response);
                };


                string Get_Time(string Close_Time, string Open_Time = null)
                {



                    //DateTime To_12Time2 = DateTime.ParseExact(Close_Time, "HH:mm", Web_Helper.Culture);

                    string To_12Time2 = TIME_CONVERTER(Close_Time, "HH:mm", "hh:mm tt");


                    if (Open_Time != null && Close_Time != null)
                    {




                        //DateTime To_12Time1 = DateTime.ParseExact(Open_Time, "HH:mm", Web_Helper.Culture);
                        string To_12Time1 = TIME_CONVERTER(Open_Time, "HH:mm", "hh:mm tt");


                        return String.Format("{0} ~ {1}", To_12Time1, To_12Time2);
                    }
                    else
                    {

                        return String.Format("{0}", To_12Time2);
                    }


                }


                #endregion

                #region Break time
                Item[1] = new Operation_Item();
                Item[1].Item_Name.Text = Program.Language.De[24001]; ; //"break time"
                Item[1].Change_btn.Text = Program.Language.De[24013];///"Change";

                if (Response.operationHour.breakTimes.Count > 0)
                {
                    foreach (var I_v in Response.operationHour.breakTimes)
                    {
                        Operation_Value O_V = new Operation_Value();
                        //O_V.O_Title.Text = I_v.weekDay;
                        O_V.O_Title.Text = days_of_the_week[I_v.weekDay];


                        if (I_v.startTime.Contains("24"))
                        {
                            I_v.startTime = I_v.startTime.Replace("24", "01");
                        }

                        if (I_v.endTime.Contains("24"))
                        {
                            I_v.endTime = I_v.endTime.Replace("24", "01");
                        }

                        DateTime To_12Time1 = DateTime.ParseExact(I_v.startTime, "HH:mm", Web_Helper.Culture);
                        DateTime To_12Time2 = DateTime.ParseExact(I_v.endTime, "HH:mm", Web_Helper.Culture);

                        //O_V.O_Value.Text = String.Format("{0:hh}:{0:mm} {0:tt} ~ {1:hh}:{1:mm} {1:tt}", To_12Time1, To_12Time2);
                        O_V.O_Value.Text = String.Format("{0} ~ {1}", To_12Time1.ToString("hh:mm tt", Web_Helper.Culture), To_12Time2.ToString("hh:mm tt", Web_Helper.Culture));

                        Item[1].Operation_Values.Controls.Add(O_V);
                    }
                }
                else
                {
                    Item[1].Operation_Values.Controls.Add(new Label() { Text = Program.Language.De[24005]  });

                }
                Item[1].Change_btn.Click += (s, e) =>
                {
                    Break_Time_Change_btn(Response);
                };

                #endregion

                #region Closing

                Item[2] = new Operation_Item();
                Item[2].Item_Name.Text = Program.Language.De[24002]; //Closed Days
                Item[2].Change_btn.Text = Program.Language.De[24013];///"Change";



                if (Response.dayOff.dayOffs.Count > 0)
                {
                    foreach (var I_v in Response.dayOff.dayOffs)
                    {
                        Operation_Value O_V_01 = new Operation_Value();
                        if (I_v.interval == "PUBLIC_HOLIDAY" && I_v.day == "PUBLIC_HOLIDAY")
                        {
                            O_V_01.O_Title.Text = Program.Language.De[24007];//"holiday"
                            O_V_01.O_Value.Text = Program.Language.De[24008];//"Closed";

                        }
                        else
                        {
                            O_V_01.O_Title.Text = Program.Language.De[24009];// "regular holiday";
                            O_V_01.O_Value.Text = Get_regular_holiday(I_v.day, I_v.interval);
                        }
                        Item[2].Operation_Values.Controls.Add(O_V_01);

                    }
                }
                else
                {
                    Operation_Value O_V_01 = new Operation_Value();
                    O_V_01.O_Title.Text = Program.Language.De[24007];
                    O_V_01.O_Value.Text = Program.Language.De[24005];//"not set";
                    Item[2].Operation_Values.Controls.Add(O_V_01);

                }

                Item[2].Change_btn.Click += (s, e) =>
                {
                    Close_Days_Change_btn_Click(Response);
                };
                //Operation_Value O_V_02 = new Operation_Value();
                //O_V_02.O_Title.Text = "regular holiday";

                //if ( sh.ope
                //
                //rationInfo.breakTimes.Count > 0 ) // test
                //{

                //}
                //else
                //{
                //    O_V_02.O_Value.Text = "not set";

                //}
                //Item[2].Operation_Values.Controls.Add(O_V_02);





                if (Response.dayOff.temporaryDayOffs.Count > 0)
                {
                    foreach (var I_v in Response.dayOff.temporaryDayOffs)
                    {
                        Operation_Value O_V_01 = new Operation_Value();
                        O_V_01.O_Title.Text = Program.Language.De[24010];// "temporary closure";
                        O_V_01.O_Value.Text = $"{I_v.startDate} ~ {I_v.endDate}";
                        Item[2].Operation_Values.Controls.Add(O_V_01);

                    }
                }
                else
                {
                    Operation_Value O_V_03 = new Operation_Value();
                    O_V_03.O_Title.Text = Program.Language.De[24010];// "temporary closure";
                    O_V_03.O_Value.Text = Program.Language.De[24005];//"not set";
                    Item[2].Operation_Values.Controls.Add(O_V_03);


                }


                string Get_regular_holiday(string day, string interval)
                {
                    switch (interval)
                    {

                        case "EVERY_MONTH_FIRST":
                            return String.Format (Program.Language.De[24014], days_of_the_week[day]);

                        case "EVERY_MONTH_SECOND":
                            return String.Format(Program.Language.De[24015], days_of_the_week[day]);


                        case "EVERY_MONTH_THIRD":
                            return String.Format(Program.Language.De[24016], days_of_the_week[day]);


                        case "EVERY_MONTH_FORTH":
                            return String.Format(Program.Language.De[24017], days_of_the_week[day]);


                        case "EVERY_MONTH_FIFTH":
                            return String.Format(Program.Language.De[24018], days_of_the_week[day]);


                        case "EVERY_MONTHLY_LAST":
                            return String.Format(Program.Language.De[24019], days_of_the_week[day]);


                        case "EVERY_WEEK":
                            return String.Format(Program.Language.De[24020], days_of_the_week[day]);

                            //case "EVERY_MONTH_FIRST":
                            //    return $"first {day} of every month";

                            //case "EVERY_MONTH_SECOND":
                            //    return $"second {day} of every month";

                            //case "EVERY_MONTH_THIRD":
                            //    return $"third {day} of every month";

                            //case "EVERY_MONTH_FORTH":
                            //    return $"forth {day} of every month";

                            //case "EVERY_MONTH_FIFTH":
                            //    return $"fifth {day} of every month";

                            //case "EVERY_MONTHLY_LAST":
                            //    return $"last {day} of every month";

                            //case "EVERY_WEEK":
                            //    return $"every {day}";


                    }
                    return null;
                }






                #endregion


                #region Holiday Information
                Item[3] = new Operation_Item();
                Item[3].Item_Name.Text = Program.Language.De[24003]; //Holiday Information
                Item[3].Change_btn.Text = Program.Language.De[24013];///"Change";


                Label lb = new Label() { AutoSize = true };
                if (!string.IsNullOrEmpty(Response.dayOff.dayOffText))
                {
                    lb.Text = Response.dayOff.dayOffText;

                }
                else
                {
                    lb.Text = Program.Language.De[24005];//"not set";

                }

                Item[3].Change_btn.Click += (s, e) =>
                {
                    Holiday_Information_Change_btn_Click(Response.shopNo, Response.dayOff.dayOffText);
                };

                Item[3].Operation_Values.Controls.Add(lb);

                #endregion


                #region Temporaily Suspended Business
                Item[4] = new Operation_Item();
                Item[4].Item_Name.Text = Program.Language.De[24004];

                if (Response.temporaryStop != null)
                {
                    Operation_Value O_V = new Operation_Value();

                    ShopCode Current_ShopCode = null;

                    if (_operation_block_reason != null)
                    {
                        Current_ShopCode = _operation_block_reason.shopCodes.OfType<ShopCode>().Where(sh => sh.id == Response.temporaryStop.reason).FirstOrDefault();

                    }

                    O_V.O_Title.Text = string.Format("{0} {1}", $"{Program.Language.De[24011]} ", Current_ShopCode != null ? Current_ShopCode.title : Response.temporaryStop.reason);




                    string _startDate = DateTime.ParseExact(Response.temporaryStop.startDate, "yyyy-MM-dd HH:mm:ss", Web_Helper.Culture).ToString("yyyy-MM-dd hh:mm tt", Web_Helper.Culture);
                    string _endDate = DateTime.ParseExact(Response.temporaryStop.endDate, "yyyy-MM-dd HH:mm:ss", Web_Helper.Culture).ToString("yyyy-MM-dd hh:mm tt", Web_Helper.Culture);

                    //string _startDate = TIME_CONVERTER(  Response.temporaryStop.startDate , "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd hh:mm:ss");
                    // string _endDate = TIME_CONVERTER(  Response.temporaryStop.endDate , "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd hh:mm:ss");

                    O_V.O_Value.Text = String.Format("{0} ~ {1}", _startDate, _endDate);

                    Item[4].Operation_Values.Controls.Add(O_V);

                    Item[4].Change_btn.Text = Program.Language.De[24012];//"Clear";
                    Item[4].Change_btn.ForeColor = Color.Red;
                    Item[4].Change_btn.Click += (s, e) =>
                    {
                        Temporaily_Suspended_Business_Clear_btn(Response);
                    };

                }
                else
                {
                    Item[4].Operation_Values.Controls.Add(new Label() { Text = Program.Language.De[24005] });

                    Item[4].Change_btn.Text = Program.Language.De[24013];///"Change";
                    Item[4].Change_btn.ForeColor = Color.Black;

                    Item[4].Change_btn.Click += (s, e) =>
                    {
                        Temporaily_Suspended_Business_Change_btn(Response);
                    };

                }


                //Item[4].Change_btn.Text = "Change";
                //Item[4].Change_btn.Click += (s, e) =>
                //{
                //    Temporaily_Suspended_Business_Change_btn(Response);
                //};





                #endregion


                this.Operation_Information_List.Invoke(new Action(() =>
                {
                    for (int i = 0; i < Items_Count; i++)
                    {
                        this.Operation_Information_List.Controls.Add(Item[i]);

                    }
                }));

            }
            else
            {

                Show_Error_Message("ERROR", "Error", null);
            }
        }




        //         Operation_Hours_Change_btn(Response.shopNo, Response.operationHour.operationHours);

        //private void Operation_Hours_Change_btn(int shop_number, List<OperationHour2> _OperationHour)
        private void Operation_Hours_Change_btn(Shop_Details _Shop_Details)
        {


            Operation_Hours_frm frm = new Operation_Hours_frm() { Text= Program.Language.De[25000] };


            //OperationHour2 Check_Everyday = _Shop_Details.operationHour.operationHours.First(ss => ss.intervalCode == "EVERYDAY" || ss.intervalCode == "WEEKDAY");
            OperationHour2 Check_Everyday = _Shop_Details.operationHour.operationHours.Find(ss => ss.intervalCode == "EVERYDAY" || ss.intervalCode == "WEEKDAY");
            if (Check_Everyday != null)
            {
                frm.Last_openTime = Check_Everyday.openTime;
                frm.Last_closeTime = Check_Everyday.closeTime;


                //string To_12Time1 = TIME_CONVERTER(Check_Everyday.openTime, "HH:mm", "HH:mm");

                switch (Check_Everyday.intervalCode)
                {
                    case "EVERYDAY":
                        frm.Hours.Controls.Add(frm.Add_New_Working_Hour(Check_Everyday.allDay, Check_Everyday.openTime, Check_Everyday.closeTime, "EVERYDAY", Program.Language.De[26008]));
                        break;

                    case "WEEKDAY":
                        frm.Hours.Controls.Add(frm.Add_New_Working_Hour(Check_Everyday.allDay, Check_Everyday.openTime, Check_Everyday.closeTime, "WEEKDAY", Program.Language.De[26009]));
                        frm.Hours.Controls.Add(frm.Add_New_Working_Hour(Check_Everyday.allDay, Check_Everyday.openTime, Check_Everyday.closeTime, "SATURDAY",Program.Language.De[26006]));
                        frm.Hours.Controls.Add(frm.Add_New_Working_Hour(Check_Everyday.allDay, Check_Everyday.openTime, Check_Everyday.closeTime, "SUNDAY",Program.Language.De[26007]));
                        break;
                }

            }
            else
            {

               

                foreach (var Hour in _Shop_Details.operationHour.operationHours)
                {

                    frm.Hours.Controls.Add(frm.Add_New_Working_Hour(Hour.allDay, Hour.openTime, Hour.closeTime, Hour.intervalCode, days_of_the_week[Hour.intervalCode]));

                }

            }




            //MessageBox.Show(To_24Time_Format(frm.openHour.Text));
            //MessageBox.Show(To_24Time_Format(frm.closeHour.Text));

            if (frm.ShowDialog(this) == DialogResult.OK)
            {

                List<OperationHour2> New_OperationHour = new List<OperationHour2>();

                foreach (Operation_Hours day in frm.Hours.Controls)
                {

                    foreach (string a_ady in day.Days)
                    {
                        New_OperationHour.Add(new OperationHour2()
                        {
                            allDay = day.All_Day.Checked,
                            //openTime = DateTime.ParseExact( ( day.openHour.Text + ":"+ day.openMinute.Text), "tt hh:mm", Web_Helper.Culture).ToString("HH:mm") ,
                            //closeTime = DateTime.ParseExact( (day.closeHour.Text + ":" + day.closeMinute.Text), "tt hh:mm", Web_Helper.Culture).ToString("HH:mm"),


                            //openTime = TIME_CONVERTER((day.openHour.Text + ":" + day.openMinute.Text), "tt hh:mm", "HH:mm"),
                            //closeTime = TIME_CONVERTER((day.closeHour.Text + ":" + day.closeMinute.Text), "tt hh:mm", "HH:mm"),

                            openTime = ((Operation_Hourr)day.openHour.SelectedItem).Hour.ToString() + ":" + day.openMinute.Text,
                            closeTime = ((Operation_Hourr)day.closeHour.SelectedItem).Hour.ToString() + ":" + day.closeMinute.Text,


                            intervalCode = a_ady
                        });
                        //MessageBox.Show(((Operation_Hourr)day.closeHour.SelectedItem).Hour.ToString());

                    }


                }


                //Operation_Hours Check_Everyday_cn = frm.Hours.Controls.Cast<Operation_Hours>().First(sss =>
                //    sss.intervalCode.Tag.ToString() == "EVERYDAY" || sss.intervalCode.Tag.ToString() == "WEEKDAY"
                //);

                //if (Check_Everyday_cn != null)
                //{
                //    List<string> days_of_the_week = new List<string>
                //    {
                //        "MONDAY" ,"TUESDAY","WEDNESDAY","THURSDAY","FRIDAY","SATURDAY","SUNDAY"
                //    };





                //    foreach (string Day in days_of_the_week)
                //    {
                //        New_OperationHour.Add(new OperationHour2()
                //        {
                //            allDay = Check_Everyday_cn.All_Day.Checked,
                //            openTime = DateTime.ParseExact(Check_Everyday_cn.openHour.Text, "h tt", Web_Helper.Culture).ToString("HH") + ":" + Check_Everyday_cn.openMinute.Text,
                //            closeTime = DateTime.ParseExact(Check_Everyday_cn.closeHour.Text, "h tt", Web_Helper.Culture).ToString("HH") + ":" + Check_Everyday_cn.closeMinute.Text,
                //            intervalCode = Day
                //        });

                //    }
 
                //settings.NullValueHandling = NullValueHandling.Ignore;


#if Design_Test
                //settings.Formatting = Formatting.Indented;
                object Update_Request = JsonConvert.SerializeObject(New_OperationHour, Formatting.Indented  );



                MessageBox.Show(Update_Request.ToString());

                ((Datum)this.Shops_List.SelectedItem)._Shop_Details.operationHour.operationHours = New_OperationHour;

#endif



                //}
                //else
                //{

                //}


#if !Design_Test
                object Update_Request = JsonConvert.SerializeObject(New_OperationHour, settings).ToString();

                Thread th = new Thread(new ThreadStart(() =>
                {


                    Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shops/{_Shop_Details.shopNo}/operation-hour", Method.PUT, null, Update_Request, SELF_SERVICE_Headers));
                    tx.Wait();

                    if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(tx.Result.Content))
                    {
                        Shop_Details rs = JsonConvert.DeserializeObject<Shop_Details>(tx.Result.Content, settings);

                        Datum Shop_Old_Values = (Datum)this.Shops_List.Items.OfType<Datum>().Where(Sh => Sh.shopNumber == rs.shopNo).FirstOrDefault();

                        if (_Shop_Details.shopNo == rs.shopNo && Shop_Old_Values != null)
                        {
                            this.Shops_List.Invoke(new Action(() =>
                            {
                                //((Datum)this.Shops_List.SelectedItem)._Shop_Details = rs;
                                Shop_Old_Values._Shop_Details = rs;

                            }));

                            Operation_Info_Response(rs);
                        }

                        //Operation_Information_Response Response = JsonConvert.DeserializeObject<Operation_Information_Response>(tx.Result.Content.ToString());
                        //Operation_Info_Response(Response, request);

                    }
                    else
                    {
                        Show_Error_Message(Program.Language.De[25050], Program.Language.De[25051], null);

                    }



                }));
                th.IsBackground = true; th.Start();



#endif
            }


        }

        private void Break_Time_Change_btn(Shop_Details _Shop_Details)
        {

            //how to get endNextDay
            break_time_frm frm = new break_time_frm() { Text= Program.Language.De[25100] };



            //List<string> days_of_the_week = new List<string> { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };

          


            foreach (KeyValuePair<string, string> day in days_of_the_week)
            {

                Operation_Hours W1 = new Operation_Hours( Operation_Hours.Hour_Types.Break_Time);
                W1.Name = day.Key;
                W1.intervalCode.Text = day.Value;
                W1.All_Day.Text = Program.Language.De[26100];
                W1.panel1.Visible = false;
                //W1.Hour_Type = Operation_Hours.Hour_Types.Break_Time;


                //W1.openHour.SelectedIndex = 0; W1.openMinute.SelectedIndex = 0;
                //W1.closeHour.SelectedIndex = W1.closeHour.Items.Count - 1; W1.closeMinute.SelectedIndex = 0;



                W1.openMinute.Items.Clear();
                W1.openMinute.Items.AddRange(new string[] { "00", "10", "20", "30", "40", "50" });
                W1.openMinute.SelectedIndex = 0;

                W1.closeMinute.Items.Clear();
                W1.closeMinute.Items.AddRange(new string[] { "00", "10", "20", "30", "40", "50" });
                W1.closeMinute.SelectedIndex = 0;

                W1.All_Day.CheckedChanged += new EventHandler((ss, ee) => { W1.panel1.Visible = W1.All_Day.Checked; });


                frm.break_Hours.Controls.Add(W1);

            }


            foreach (BreakTime Br_Time in _Shop_Details.operationHour.breakTimes)
            {


                Operation_Hours x = frm.break_Hours.Controls.OfType<Operation_Hours>().Where(o => o.Name == Br_Time.weekDay).FirstOrDefault();



                //Operation_Hours x = (Operation_Hours)frm.Hours.Controls[Br_Time.weekDay];
                if (x != null)
                {
                    x.All_Day.Checked = true;



                    //DateTime To_12Time1 = DateTime.ParseExact(Br_Time.startTime, "HH:mm", Web_Helper.Culture);
                    //DateTime To_12Time2 = DateTime.ParseExact(Br_Time.endTime, "HH:mm", Web_Helper.Culture);

                    ////fix here

                    //x.openHour.Text = To_12Time1.ToString("h tt", Web_Helper.Culture).ToUpper();
                    //x.openMinute.Text = To_12Time1.ToString("mm");

                    //x.closeHour.Text = To_12Time2.ToString("h tt", Web_Helper.Culture).ToUpper();
                    //x.closeMinute.Text = To_12Time2.ToString("mm");



                    //x.openHour.SelectedItem = x.openHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == startTime_splitter[0]).FirstOrDefault();
                    //x.closeHour.SelectedItem = x.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == endTime_splitter[0]).FirstOrDefault();

                    //string[] startTime_splitter = Br_Time.startTime.Split(':');
                    //string[] endTime_splitter = Br_Time.endTime.Split(':');

                    //x.defult_OpenHour = startTime_splitter[0];
                    //x.Defult_CloseHour = endTime_splitter[0];

                    MessageBox.Show(Br_Time.startTime);
                    MessageBox.Show(Br_Time.endTime);
                    x.defult_OpenTime = Br_Time.startTime;
                    x.defult_CloseTime = Br_Time.endTime;

                    //New_H.closeHour.SelectedItem = New_H.closeHour.Items.OfType<Operation_Hourr>().Where(T => T.Hour == int.Parse(closeTime_splitter[0])).FirstOrDefault();


                    //string[] B_start = Br_Time.breakStart.Split(':');
                    //string[] B_end = Br_Time.breakEnd.Split(':');

                    //x.openHour.Text = To_12Time_Format(B_start[0]);
                    //x.openMinute.Text = startTime_splitter[1];
                    //x.closeMinute.Text = endTime_splitter[1];

                    //x.closeHour.Text = To_12Time_Format(B_end[0]);

                }



            }



            if (frm.ShowDialog(this) == DialogResult.OK)
            {

                //_BreakTime.Clear();
                List<BreakTime> New_BreakTime = new List<BreakTime>();
                foreach (Operation_Hours H in frm.break_Hours.Controls)
                {
                    if (H.All_Day.Checked == true)
                    {
                        BreakTime New_H = new BreakTime();
                        //Operation_Information.BreakTime New_H = new Operation_Information.BreakTime();

                        //New_H.breakStart = $"{To_24Time_Format(H.openHour.Text)}:{H.openMinute.Text}";
                        //New_H.breakEnd = $"{To_24Time_Format(H.closeHour.Text)}:{H.closeMinute.Text}";


                        New_BreakTime.Add(new BreakTime()
                        {
                            weekDay = H.Name,


                            startTime = ((Operation_Hourr)H.openHour.SelectedItem).Hour.ToString() + ":" + H.openMinute.Text,
                            endTime = ((Operation_Hourr)H.closeHour.SelectedItem).Hour.ToString() + ":" + H.closeMinute.Text,

                            //startTime = TIME_CONVERTER($"{H.openHour.Text}:{H.openMinute.Text}", "tt hh:mm", "HH:mm"),
                            //endTime = TIME_CONVERTER($"{H.closeHour.Text}:{H.closeMinute.Text}", "tt hh:mm", "HH:mm"),


                            //startTime = DateTime.ParseExact($"{H.openHour.Text}:{H.openMinute.Text}", "tt hh:mm", Web_Helper.Culture).ToString("HH:mm", Web_Helper.Culture),
                            //endTime = DateTime.ParseExact($"{H.closeHour.Text}:{H.closeMinute.Text}", "tt hh:mm", Web_Helper.Culture).ToString("HH:mm", Web_Helper.Culture),
                            endNextDay = false,
                        });




                    }

                }






#if Design_Test
                //settings.Formatting = Formatting.Indented;
                object Update_Request = JsonConvert.SerializeObject(New_BreakTime, Formatting.Indented).ToString();

                MessageBox.Show(Update_Request.ToString());

#else



                //JsonSerializer sz = new JsonSerializer().Serialize(New_BreakTime);



                //}
                //else
                //{

                //}




                object Update_Request = JsonConvert.SerializeObject(New_BreakTime, settings);

                Thread th = new Thread(new ThreadStart(() =>
                {


                    Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shops/{_Shop_Details.shopNo}/break-time", Method.PUT, null, Update_Request, SELF_SERVICE_Headers));
                    tx.Wait();



                    if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(tx.Result.Content))
                    {
                        Shop_Details rs = JsonConvert.DeserializeObject<Shop_Details>(tx.Result.Content, settings);

                        Datum Shop_Old_Values = (Datum)this.Shops_List.Items.OfType<Datum>().Where(Sh => Sh.shopNumber == rs.shopNo).FirstOrDefault();
                        if (_Shop_Details.shopNo == rs.shopNo && Shop_Old_Values != null)
                        {
                            this.Shops_List.Invoke(new Action(() =>
                            {
                                Shop_Old_Values._Shop_Details = rs;
                            }));

                            Operation_Info_Response(rs);
                        }


                    }
                    else
                    {
                        Show_Error_Message(Program.Language.De[25050], Program.Language.De[26050], null);

                    }



                }));
                th.IsBackground = true; th.Start();



#endif

            }
        }

        private void Close_Days_Change_btn_Click(Shop_Details _Shop_Details)
        {

            //[1] how to get temporaryDayOffSeq
            Holiday_Update_frm frm = new Holiday_Update_frm() { Text = Program.Language.De[28010] };

            //frm._Dayoff = dayOff.dayOffs.ToList();
            //frm._TemporaryDayOff = dayOff.temporaryDayOffs.ToList();

            foreach (var R_holiday in _Shop_Details.dayOff.dayOffs)
            {

                if (R_holiday.interval == "PUBLIC_HOLIDAY" && R_holiday.day == "PUBLIC_HOLIDAY")
                {
                    frm.checkBox1.Checked = true;
                }
                else
                {
                    regular_holiday_Item item = new regular_holiday_Item(R_holiday.interval, R_holiday.day);

                    frm.regular_holiday_lst.Controls.Add(item);
                }


            }


            foreach (var Temp_holiday in _Shop_Details.dayOff.temporaryDayOffs)
            {
                Temporary_Leave_Item item = new Temporary_Leave_Item(Temp_holiday.temporaryDayOffSeq, Temp_holiday.startDate, Temp_holiday.endDate);
                frm.Temporary_list.Controls.Add(item);
            }

            //MessageBox.Show(To_24Time_Format(frm.openHour.Text));
            //MessageBox.Show(To_24Time_Format(frm.closeHour.Text));

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                JObject final = new JObject();

                JArray _Day_Offs = new JArray();
                JArray _TemporaryDayOff = new JArray();


                //frm._Dayoff.Clear();

                if (frm.checkBox1.Checked == true)
                {


                    JObject d = new JObject();
                    d.Add("day", "PUBLIC_HOLIDAY");
                    d.Add("interval", "PUBLIC_HOLIDAY");


                    _Day_Offs.Add(d);

                    //frm._Dayoff.Add(new DayOff2() { day = "PUBLIC_HOLIDAY", interval = "PUBLIC_HOLIDAY" });

                }

                foreach (regular_holiday_Item R in frm.regular_holiday_lst.Controls)
                {

                    if (_Day_Offs.Count <= 15)
                    {
                        JObject d = new JObject();
                        d.Add("day", R._day);
                        d.Add("interval", R._interval);


                        _Day_Offs.Add(d);

                        //frm._Dayoff.Add(new DayOff2() { day = R._day, interval = R._interval });

                    }

                }

                //frm._TemporaryDayOff.Clear();

                foreach (Temporary_Leave_Item t in frm.Temporary_list.Controls)
                {

                    //frm._TemporaryDayOff.Add(new TemporaryDayOff()
                    //{
                    //    temporaryDayOffSeq = t.temporaryDayOffSeq,
                    //    startDate = t.Start_Date.Value.ToString("yyy-MM-dd"),
                    //    endDate = t.End_Date.Value.ToString("yyy-MM-dd")
                    //});


                    JObject sss = new JObject();

                    if (t.temporaryDayOffSeq != 0)
                    {
                        sss.Add("temporaryDayOffSeq", t.temporaryDayOffSeq);

                    }
                    sss.Add("startDate", t.Start_Date.Value.ToString("yyy-MM-dd"));
                    sss.Add("endDate", t.End_Date.Value.ToString("yyy-MM-dd"));

                    _TemporaryDayOff.Add(sss);

                    //var dd = new
                    //{
                    //    //[JsonProperty(PropertyName = "FooBar")]


                    //    frm._TemporaryDayOff

                    //};



                    //TemporaryDayOff tt = new TemporaryDayOff();
                    // tt.startDate = t.Start_Date.Value.ToString("yyy-MM-dd");
                    // tt.endDate = t.End_Date.Value.ToString("yyy-MM-dd");

                    // if (_TemporaryDayOff.Exists(o => o.startDate == tt.startDate && o.endDate == tt.endDate) == false)
                    // {
                    //     _TemporaryDayOff.Add(tt);
                    // }
                }


                //dd.Add(frm._TemporaryDayOff);

                //JsonPropertyAttribute zzz = new JsonPropertyAttribute("dd");


                //JObject.



                //JObject dd = new JObject();
                //dd.Add("dd", ss);

                //JsonParameter dd = new JsonParameter("re", frm._Dayoff);







                //var dd = new
                //{
                //    //[JsonProperty(PropertyName = "FooBar")]


                //    frm._TemporaryDayOff

                //};



                //DayOff aaa = new DayOff()
                //{
                //    dayOffs = frm._Dayoff,
                //    temporaryDayOffs = frm._TemporaryDayOff
                //};


                final.Add("dayOffs", _Day_Offs);
                final.Add("temporaryDayOffs", _TemporaryDayOff);









       

#if Design_Test
                settings.Formatting = Formatting.Indented;
                object Update_Request = JsonConvert.SerializeObject(final, Formatting.Indented).ToString();

                MessageBox.Show(Update_Request.ToString());

#else



                //JsonSerializer sz = new JsonSerializer().Serialize(New_BreakTime);



                //}
                //else
                //{

                //}



                object Update_Request = JsonConvert.SerializeObject(final, settings);


                Thread th = new Thread(new ThreadStart(() =>
                {


                    Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shops/{_Shop_Details.shopNo}/day-off", Method.PUT, null, Update_Request, SELF_SERVICE_Headers));
                    tx.Wait();



                    if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(tx.Result.Content))
                    {
                        Shop_Details rs = JsonConvert.DeserializeObject<Shop_Details>(tx.Result.Content, settings);

                        Datum Shop_Old_Values = (Datum)this.Shops_List.Items.OfType<Datum>().Where(Sh => Sh.shopNumber == rs.shopNo).FirstOrDefault();
                        if (_Shop_Details.shopNo == rs.shopNo && Shop_Old_Values != null)
                        {
                            this.Shops_List.Invoke(new Action(() =>
                            {
                                Shop_Old_Values._Shop_Details = rs;
                            }));

                            Operation_Info_Response(rs);
                        }


                    }
                    else
                    {
                        Show_Error_Message(Program.Language.De[25050], Program.Language.De[28050], null);

                    }



                }));
                th.IsBackground = true; th.Start();



#endif


                //_dayOffs.Clear();
                //foreach ( Operation_Hours H in frm.Hours.Controls )
                //{
                //    if ( H.All_Day.Checked == true )
                //    {
                //        BreakTime New_H = new BreakTime();

                //        New_H.breakStart = $"{To_24Time_Format(H.openHour.Text)}:{H.openMinute.Text}";
                //        New_H.breakEnd = $"{To_24Time_Format(H.closeHour.Text)}:{H.closeMinute.Text}";
                //        New_H.weekDay = H.intervalCode.Text;

                //        _BreakTime.Add(New_H);

                //    }

                //}
                //Post_Updates(shop_number);

            }
        }


        private void Holiday_Information_Change_btn_Click(long shop_number, string _closeDayText)
        {
            closeDayText_Update_frm frm = new closeDayText_Update_frm(41) { Text= Program.Language.De[29000] };


            frm.textBox1.Text = _closeDayText;

            //if (string.IsNullOrEmpty(_closeDayText))
            //{
            //    frm.textBox1.Text = "매주 월요일 휴무";//Testing
            //}

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                JObject final = new JObject();
                final.Add("dayOffText", frm.textBox1.Text);

           

#if Design_Test
                object Update_Request = JsonConvert.SerializeObject(final, Formatting.Indented).ToString();

                MessageBox.Show(Update_Request.ToString());

#endif

#if !Design_Test
                object Update_Request = JsonConvert.SerializeObject(final, settings);

                Thread th = new Thread(new ThreadStart(() =>
                {


                    Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shops/{shop_number}/day-off/text", Method.PUT, null, Update_Request, SELF_SERVICE_Headers));
                    tx.Wait();



                    if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(tx.Result.Content))
                    {
                        Shop_Details rs = JsonConvert.DeserializeObject<Shop_Details>(tx.Result.Content, settings);

                        Datum Shop_Old_Values = (Datum)this.Shops_List.Items.OfType<Datum>().Where(Sh => Sh.shopNumber == rs.shopNo).FirstOrDefault();
                        if (shop_number == rs.shopNo && Shop_Old_Values != null)
                        {
                            this.Shops_List.Invoke(new Action(() =>
                            {
                                Shop_Old_Values._Shop_Details = rs;
                            }));

                            Operation_Info_Response(rs);
                        }


                    }
                    else
                    {
                        Show_Error_Message(Program.Language.De[25050], Program.Language.De[29050], null);

                    }



                }));
                th.IsBackground = true; th.Start();



#endif


            }
        }



        void Temporaily_Suspended_Business_Change_btn(Shop_Details _Shop_Details)
        {


            if (_operation_block_reason != null)
            {
                break_time_frm frm = new break_time_frm() { Text = Program.Language.De[30000] };



                ComboBox All_Reasons = new ComboBox()
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = frm.break_Hours.Width - 10,

                };

                foreach (ShopCode Reason in _operation_block_reason.shopCodes.Where(s => s.id != "NONE" && s.id != "ORDER_CANCEL"))
                {
                    All_Reasons.Items.Add(Reason);
                }

                All_Reasons.SelectedIndex = 2;



                frm.break_Hours.Controls.Add(new Label { Text = Program.Language.De[30001], AutoSize = true });
                frm.break_Hours.Controls.Add(All_Reasons);

                Operation_Hours Hour = new Operation_Hours( Operation_Hours.Hour_Types.Temporaily_Suspend)
                {
                    //Hour_Type = Operation_Hours.Hour_Types.Temporaily_Suspend,
                    Width = frm.break_Hours.Width - 10,

                };
                Hour.openMinute.Items.Clear();
                Hour.closeMinute.Items.Clear();
                Hour.openMinute.Items.AddRange(new string[] { "00", "10", "20", "30", "40", "50" });
                Hour.closeMinute.Items.AddRange(new string[] { "00", "10", "20", "30", "40", "50" });


                Hour.openMinute.SelectedIndex = 0;
                //Hour.closeMinute.SelectedIndex = 0;

                Hour.All_Day.Visible = false;
                Hour.intervalCode.Visible = false;

                Hour.panel1.Size = new Size(Hour.Width - 6, Hour.Height - 6);
                Hour.panel1.Location = new Point(3, 3);
                Hour.openHour.Width = Hour.closeHour.Width;
                Hour.openMinute.Left = Hour.openHour.Right + 3;

                frm.break_Hours.Controls.Add(Hour);

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    //DateTime DT= DateTime.ParseExact(To_Convert, In_Format, Web_Helper.Culture).ToString(Out_Format, Web_Helper.Culture) + next_day;
                    //string DT = DateTime.Now.ToString("yyyy-MM-dd", Web_Helper.Culture);

                    //MessageBox.Show(int.Parse(((Operation_Hourr)Hour.openHour.SelectedItem).Hour).ToString());
                    DateTime DT1 = DateTime.Now;//.ToString("yyyy-MM-dd");

                    //string DT2 = DateTime.Now.AddHours(int.Parse(((Operation_Hourr)Hour.closeHour.SelectedItem).Hour)).
                    //    AddMinutes(int.Parse(Hour.closeMinute.Text)).ToString("yyyy-MM-dd hh:mm:ss");

                    string startDate, endDate;

                    int _openHour = int.Parse(((Operation_Hourr)Hour.openHour.SelectedItem).Hour);
                    int _closeHour = int.Parse(((Operation_Hourr)Hour.closeHour.SelectedItem).Hour);

                    if (_openHour >= 24)
                    {
                        startDate= DT1.AddDays(1).ToString("yyyy-MM-dd") + $" {(_openHour-24 ).ToString ("00") } :{Hour.openMinute.Text}:00";
                    }
                    else
                    {
                        startDate = DT1.ToString("yyyy-MM-dd") + $" {(_openHour).ToString ("00") }:{Hour.openMinute.Text}:00";

                    }

                    if (_closeHour >= 24)
                    {
                        endDate = DT1.AddDays(1).ToString("yyyy-MM-dd") + $" {(_closeHour - 24).ToString("00")}:{Hour.closeMinute.Text}:00";
                    }
                    else
                    {
                        endDate = DT1.ToString("yyyy-MM-dd") + $" {(_closeHour).ToString ("00") }:{Hour.closeMinute.Text}:00";

                    }

                    JObject op = new JObject();
                    op.Add("reason", ((ShopCode)All_Reasons.SelectedItem).id);
                    op.Add("startDate", startDate);
                    op.Add("endDate", endDate);

                    //op.Add("reason", "PERSONAL_REASON");
                    //op.Add("startDate", "2023-12-25 19:19:02");
                    //op.Add("endDate", "2023-12-25 19:49:02");

                    //last
                    //op.Add("reason", "PERSONAL_REASON");
                    //op.Add("startDate", "2024-02-09 20:01:36");
                    //op.Add("endDate", "2024-02-09 21:01:36");



#if !Design_Test

                    Thread th = new Thread(new ThreadStart(() =>
                    {

                    string sss = JsonConvert.SerializeObject(op);



                        Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shops/{_Shop_Details.shopNo}/temporary-stop", Method.PUT, null, JsonConvert.SerializeObject(op), SELF_SERVICE_Headers));
                        tx.Wait();


                        if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(tx.Result.Content))
                        {
                            Shop_Details rs = JsonConvert.DeserializeObject<Shop_Details>(tx.Result.Content, settings);

                            Datum Shop_Old_Values = (Datum)this.Shops_List.Items.OfType<Datum>().Where(Sh => Sh.shopNumber == rs.shopNo).FirstOrDefault();

                            if (_Shop_Details.shopNo == rs.shopNo && Shop_Old_Values != null)
                            {
                                this.Shops_List.Invoke(new Action(() =>
                                {
                                    Shop_Old_Values._Shop_Details = rs;

                                }));

                                Operation_Info_Response(rs);
                            }



                        }
                        else
                        {
                            Show_Error_Message(Program.Language.De[25050], Program.Language.De[29050], null);
                        }



                    }));
                    th.IsBackground = true; th.Start();

#else
                    //string sss = JsonConvert.SerializeObject(op, Formatting.Indented);
                    //         MessageBox.Show(sss);

#endif
                }

            }



        }
        void Temporaily_Suspended_Business_Clear_btn(Shop_Details _Shop_Details)
        {
#if !Design_Test

            Thread th = new Thread(new ThreadStart(() =>
            {




                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/store/shops/{_Shop_Details.shopNo}/temporary-stop", Method.DELETE, null, null, SELF_SERVICE_Headers));
                tx.Wait();


                //MessageBox.Show(tx.Result.Content);
                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    Shop_Details rs = JsonConvert.DeserializeObject<Shop_Details>(tx.Result.Content, settings);

                    Datum Shop_Old_Values = (Datum)this.Shops_List.Items.OfType<Datum>().Where(Sh => Sh.shopNumber == rs.shopNo).FirstOrDefault();

                    if (_Shop_Details.shopNo == rs.shopNo && Shop_Old_Values != null)
                    {
                        this.Shops_List.Invoke(new Action(() =>
                        {
                            Shop_Old_Values._Shop_Details = rs;

                        }));

                        Operation_Info_Response(rs);
                    }



                }



            }));

            if(MessageBox.Show (Program.Language.De[30101], Program.Language.De[30100], MessageBoxButtons.YesNo , MessageBoxIcon.Question )== DialogResult.Yes)
            {
                th.IsBackground = true; th.Start();

            }

#else
            if (MessageBox.Show(Program.Language.De[30101], Program.Language.De[30100], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Shop_Details.temporaryStop = null;

            }

#endif
        }

        string TIME_CONVERTER(string To_Convert, string In_Format, string Out_Format)
        {

            string[] Time_Splitter = To_Convert.Split(':');
            int time_test = int.Parse(Time_Splitter[0]);

            string next_day = string.Empty;
            //if (time_test == 24)
            //{
            //    To_Convert = (time_test - 12).ToString("00") + ":" + Time_Splitter[1];
            //    next_day = " ( 다음 날 오전 )";
            //}
            if (time_test >= 24)
            {
                To_Convert = (time_test - 24).ToString("00") + ":" + Time_Splitter[1];
                next_day = $" ( {Program.Language.De[9991]} )";
            }


            //if (To_Convert.Contains("24"))
            //{
            //    To_Convert = To_Convert.Replace("24", "01");
            //}
            //MessageBox.Show(To_Convert + "-" + In_Format + "-" + Out_Format);


            return DateTime.ParseExact(To_Convert, In_Format, Web_Helper.Culture).ToString(Out_Format, Web_Helper.Culture) + next_day;

        }

        //--------------------------

        #endregion

        #region Reviews

        private void Reviews_Lookup_btn_Click(object sender, EventArgs e)
        {
            if (cancellationToken != null)
            {
                cancellationToken.Cancel();

            }

            Load_Reviews_Count();
            if (this.tabControl4.SelectedTab == All_Reviews_Tab)
            {
                this.All_Reviews_Lst.Controls.Clear();
                this.All_Reviews_Lst.Paint -= All_Reviews_Lst_Paint;
                Load_Reviews(this.All_Reviews_Lst);

            }
            else if (this.tabControl4.SelectedTab == NoCommentReview_Tab)
            {
                this.No_Comment_Reviews_Lst.Controls.Clear();
                this.No_Comment_Reviews_Lst.Paint -= All_Reviews_Lst_Paint;
                Load_Reviews(this.No_Comment_Reviews_Lst);

            }
            else if (this.tabControl4.SelectedTab == BlockedReview_Tab)
            {
                this.Blocking_Reviews_Lst.Controls.Clear();
                this.Blocking_Reviews_Lst.Paint -= All_Reviews_Lst_Paint;
                Load_Reviews(this.Blocking_Reviews_Lst);

            }



        }


        void Load_Reviews_Count()
        {
            if (this.Shops_List.SelectedItem == null) { return; }
            long shop_number = ((Datum)this.Shops_List.SelectedItem).shopNumber;



            Thread th = new Thread(new ParameterizedThreadStart((object from) =>
            {
                List<Tuple<string, string>> Q = new List<Tuple<string, string>>();
                Q.Add(new Tuple<string, string>("from", this.Review_Date_From.Value.ToString("yyyy-MM-dd")));
                Q.Add(new Tuple<string, string>("to", this.Review_Date_To.Value.ToString("yyyy-MM-dd")));

                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/review/shops/{shop_number}/reviews/count?", Method.GET, Q, null, SELF_SERVICE_Headers));
                tx.Wait();
                if (!string.IsNullOrEmpty(tx.Result.Content))
                {
                    Reviews_Count Response = JsonConvert.DeserializeObject<Reviews_Count>(tx.Result.Content);
                    if (Response.errorType != null && Response.errorMessage != null)
                    {
                        Show_Error_Message(Response.errorType, Response.errorMessage, new Action(() => { Load_Reviews_Count(); }));
                        return;

                    }
                    this.Invoke(new Action(() =>
                    {
                        this.All_Reviews_Tab.Text = $"All ({Response.reviewCount})";
                        this.NoCommentReview_Tab.Text = $"Unanswered ({Response.noCommentReviewCount})";
                        this.BlockedReview_Tab.Text = $"Blocking ({Response.blockedReviewCount})";

                    }));



                }

            }));
            th.IsBackground = true; th.Start();
        }

        void Load_Reviews(FlowLayoutPanel List_Panel)
        {

            if (this.Shops_List.SelectedItem == null) { return; }

            cancellationToken = new CancellationTokenSource();

            Thread th = new Thread(new ParameterizedThreadStart((object shop_number) =>
            {



                //string ind = $"offset={offset}&limit=10";

                List<Tuple<string, string>> Q = new List<Tuple<string, string>>();
                //Q.Add(new Tuple<string, string>("from", "2022-03-26"));
                //Q.Add(new Tuple<string, string>("to", "2022-09-21"));
                Q.Add(new Tuple<string, string>("from", this.Review_Date_From.Value.ToString("yyyy-MM-dd")));
                Q.Add(new Tuple<string, string>("to", this.Review_Date_To.Value.ToString("yyyy-MM-dd")));

                //Q.Add(new Tuple<string, string>("offset", offset.ToString()));
                Q.Add(new Tuple<string, string>("offset", List_Panel.Controls.Count.ToString()));
                Q.Add(new Tuple<string, string>("limit", "10"));




                string Reviews_Url = null;

                if (List_Panel == this.All_Reviews_Lst)
                {
                    Reviews_Url = "/reviews?";
                }
                else if (List_Panel == this.No_Comment_Reviews_Lst)
                {
                    Reviews_Url = "/reviews/no-comment";

                }
                else if (List_Panel == this.Blocking_Reviews_Lst)
                {
                    Reviews_Url = "/reviews/block";
                }

                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/review/shops/{shop_number}" + Reviews_Url, Method.GET, Q, null, SELF_SERVICE_Headers));
                tx.Wait();


                if (!string.IsNullOrEmpty(tx.Result.Content))
                {

                    Reviews_Response Response = JsonConvert.DeserializeObject<Reviews_Response>(tx.Result.Content.ToString());
                    if (Response.errorType != null && Response.errorMessage != null)
                    {
                        Show_Error_Message(Response.errorType, Response.errorMessage, new Action(() => { Load_Reviews(List_Panel); }));
                        return;
                    }




                    foreach (Review gr in Response.reviews)
                    {
                        if (cancellationToken.Token.IsCancellationRequested == false)
                        {


                            Review_Item New_Review_Item = new Review_Item();
                            New_Review_Item.MinimumSize = new Size(this.All_Reviews_Lst.Width - 25, 0);
                            New_Review_Item.MaximumSize = new Size(this.All_Reviews_Lst.Width - 25, 0);

                            //New_Review_Item.Main_Container.MaximumSize = new Size(New_Review_Item.MaximumSize.Width  - 12, 0);


                            New_Review_Item.Tag = gr.id;
                            New_Review_Item.memberNickname.Text = gr.memberNickname;
                            New_Review_Item.rating.Text = $"{gr.rating} {gr.createdDate}";


                            if (gr.contents != null)
                            {

                                Label lb = new Label()
                                {
                                    //Text = gr.contents,
                                    AutoSize = true,
                                    Padding = new Padding(5),
                                    //Margin = new Padding(5),
                                };

                                New_Review_Item.Main_Container.Controls.Add(lb);
                                lb.Text = gr.contents;
                            }




                            //if (gr.images != null && gr.images.Count > 0)
                            //{
                            Review_Item_Container all_images = new Review_Item_Container();
                            Load_Reviews_Images(gr.images, all_images);

                            //    //all_images.BackColor = Color.Aqua;

                            //    foreach (Reviews.Image i in gr.images)
                            //    {
                            //        PictureBox px = new PictureBox();
                            //        px.Size = new Size(130, 130);
                            //        px.Margin = new Padding(3, 3, 3, 3);

                            //        px.SizeMode = PictureBoxSizeMode.StretchImage;
                            //        px.BorderStyle = BorderStyle.FixedSingle;
                            //        //px.Load(i.imageUrl);
                            //        px.Image = System.Drawing.Image.FromStream(Web_Helper.Load_Images(i.imageUrl));



                            //        all_images.Items_List.Controls.Add(px);
                            //    }
                            New_Review_Item.Main_Container.Controls.Add(all_images);
                            //}


                            if (gr.menus != null && gr.menus.Count > 0)
                            {
                                Review_Item_Container Order_Menu = new Review_Item_Container("Order Menu");
                                //Order_Menu.BackColor = Color.Azure;


                                foreach (Reviews.Menu i in gr.menus)
                                {
                                    Label lb = new Label();


                                    lb.Tag = i.id;
                                    lb.Text = i.name;
                                    lb.AutoSize = true;
                                    lb.Padding = new Padding(3);
                                    lb.Margin = new Padding(3);
                                    lb.BackColor = Color.Silver;

                                    if (i.recommendation != "NONE")
                                    {
                                        lb.Text += $" {i.recommendation}";
                                    }
                                    Order_Menu.Items_List.Controls.Add(lb);
                                }
                                New_Review_Item.Main_Container.Controls.Add(Order_Menu);
                            }


                            if (gr.deliveryReviews != null)
                            {
                                Review_Item_Container Delivery_Reviews = new Review_Item_Container("Delivery Reviews");

                                //Delivery_Reviews.BackColor = Color.Bisque;

                                Delivery_Reviews.Items_List.Controls.Add(new Label()
                                {
                                    AutoSize = true,
                                    Text =
                                    gr.deliveryReviews.recommendation
                                });

                                New_Review_Item.Main_Container.Controls.Add(Delivery_Reviews);
                            }


                            if (gr.comments != null && gr.comments.Count > 0)
                            {

                                FlowLayoutPanel Comments = new FlowLayoutPanel()
                                {
                                    FlowDirection = FlowDirection.TopDown,
                                    WrapContents = false,
                                    AutoSize = true,
                                    Name = "Comments_list"
                                };

                                //Comments.BackColor = Color.BurlyWood;


                                foreach (Comment CM in gr.comments)
                                {
                                    if (CM.displayStatus == "DISPLAY")
                                    {
                                        Comment_Item cm = new Comment_Item();


                                        cm.Tag = CM.id;
                                        cm.managerNickname.Text = CM.managerNickname;
                                        cm.createdDate.Text = CM.createdDate;
                                        cm.contents.Text = CM.contents;

                                        cm.MinimumSize = new Size(New_Review_Item.Main_Container.Width - 12, 0);
                                        cm.MaximumSize = new Size(New_Review_Item.Main_Container.Width - 12, 0);


                                        //if ( CM.managerNo == long.Parse(memNo) )
                                        if (CM.modifiable == true)
                                        {
                                            Button Correct_Comment_btn = new Button()
                                            {
                                                AutoSize = true,
                                                Margin = new Padding(3),
                                                ForeColor = Color.DodgerBlue,
                                                FlatStyle = FlatStyle.Flat,
                                                Cursor = Cursors.Hand,
                                            };
                                            Correct_Comment_btn.Click += (ss, ee) => { Comment_Post_Click(shop_number, New_Review_Item, cm); };

                                            cm.Comment_buttons.Controls.Add(Correct_Comment_btn);
                                            Correct_Comment_btn.Text = "Correct";

                                        }

                                        cm.Delete_btn.Click += (ss, ee) => { Comment_Delete_btn_Click(shop_number, New_Review_Item, cm); };
                                        Comments.Controls.Add(cm);
                                    }



                                }

                                if (Comments.Controls.Count > 0)
                                {
                                    New_Review_Item.Main_Container.Controls.Add(Comments);

                                }



                            }


                            if (gr.writableComment == true)
                            {
                                Button Write_Comment_btn = new Button()
                                {
                                    AutoSize = true,
                                    Padding = new Padding(0, 5, 0, 5),
                                    ForeColor = Color.DodgerBlue,
                                    FlatStyle = FlatStyle.Flat,
                                    Cursor = Cursors.Hand
                                };
                                //Write_Comment_btn.Click += Comment_Post_Click();
                                Write_Comment_btn.Click += (ss, ee) => { Comment_Post_Click(shop_number, New_Review_Item); };

                                New_Review_Item.Main_Container.Controls.Add(Write_Comment_btn);
                                Write_Comment_btn.Text = "Register your boss comment";
                            }
                            else
                            {
                                Label lb = new Label()
                                {
                                    AutoSize = true,
                                    Padding = new Padding(0, 5, 0, 5),
                                    ForeColor = SystemColors.ControlDarkDark,
                                    Font = new Font(this.Font.Name, 8, FontStyle.Bold),
                                };

                                New_Review_Item.Main_Container.Controls.Add(lb);
                                lb.Text = "Reviews that are more than 30 days old cannot be registered for comment from the boss.";
                            }

                            //Handle Me when the app closed 
                            //System.InvalidOperationException: 'Invoke or BeginInvoke cannot be called on a control until the window handle has been created.'
                            if (this.Disposing == false)
                            {
                                List_Panel.Invoke(new Action(() =>
                                {
                                    List_Panel.Controls.Add(New_Review_Item);
                                }));
                            }
                        }
                        else
                        {
                            break;
                        }
                    }





                    if (Response.next == true)
                    {
                        List_Panel.Paint += All_Reviews_Lst_Paint;

                    }



                }





            }));

            th.Start(((Datum)this.Shops_List.SelectedItem).shopNumber);
        }


        void Load_Reviews_Images(List<Reviews.Image> Review_Iamges, Review_Item_Container Review_Images_Container)
        {

            if (Review_Iamges != null && Review_Iamges.Count > 0)
            {
                foreach (Reviews.Image i in Review_Iamges)
                {
                    PictureBox px = new PictureBox();
                    px.Size = new Size(130, 130);
                    px.Margin = new Padding(3, 3, 3, 3);

                    px.SizeMode = PictureBoxSizeMode.StretchImage;
                    px.BorderStyle = BorderStyle.FixedSingle;
                    px.Tag = i.imageUrl;
                    Review_Images_Container.Items_List.Controls.Add(px);
                }
            }


            Thread th = new Thread(new ThreadStart(() =>
            {
                if (Review_Images_Container.Items_List.Controls.Count > 0)
                {


                    foreach (PictureBox i in Review_Images_Container.Items_List.Controls.OfType<PictureBox>())
                    {


                        WebClient dd = new WebClient();

#if Test_With_Proxy || Design_Test
                        dd.Proxy = Program.proxy;

#endif


                        if (cancellationToken.Token.IsCancellationRequested == false)
                        {


                            //px.Load(i.imageUrl);
                            //i.Image = System.Drawing.Image.FromStream(Web_Helper.Load_Images(i.Tag.ToString ()));

                            Bitmap Bm = new Bitmap(Bitmap.FromStream(new System.IO.MemoryStream(dd.DownloadDataTaskAsync(i.Tag.ToString()).Result)), i.Width, i.Size.Height);
                            i.Image = Bm;


                        }
                        else
                        {
                            dd.CancelAsync();
                            break;
                            //return;
                        }

                    }
                    //Review_Images_Container.Invoke(new Action(() =>
                    //{
                    //    Review_Images_Container.Controls.Add(all_images);

                    //}));
                }

            }));
            th.IsBackground = true;
            th.Start();


        }

        private void Comment_Delete_btn_Click(object shop_number, Review_Item Review_Main, Comment_Item Current_Comment)
        {
            this.Invoke(new Action(() =>
            {
                if (MessageBox.Show("Are You Sure To Delete This Comment", "Delete Comment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Thread th2 = new Thread(new ThreadStart(() =>
                    {
                        Task<IRestResponse> tx_post = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/review/shops/{shop_number}/reviews/comments/{Current_Comment.Tag}"
                         , Method.DELETE, null, null, SELF_SERVICE_Headers));

                        tx_post.Wait();

                        if (tx_post.Result.StatusCode == HttpStatusCode.OK)
                        {
                            FlowLayoutPanel Comments = (FlowLayoutPanel)Current_Comment.Parent;
                            Comments.Invoke(new Action(() =>
                            {
                                Comments.Controls.Remove(Current_Comment);
                                if (Comments.Controls.Count == 0)
                                {
                                    Review_Main.Main_Container.Controls.Remove(Comments);
                                    Load_Reviews_Count();
                                }

                            }));
                        }
                        else
                        {

                            Show_Error_Message("Server Error", "Can't Delete Comment Please Try Again Later", null);


                        }

                    }));
                    th2.Start();
                }

            }));

        }

        private void Comment_Post_Click(object shop_number, Review_Item Review_Main, Comment_Item Current_Comment = null)
        {
            string post_url = $"https://self-api.baemin.com/v1/review/shops/{shop_number}/reviews/comments";



            New_Boss_Comment_frm comment_frm = new New_Boss_Comment_frm();
            if (Current_Comment != null)
            {
                comment_frm.textBox1.Text = Current_Comment.contents.Text;
                post_url += "/" + Current_Comment.Tag.ToString();
            }
            else
            {
                comment_frm.textBox1.Text = $"{Review_Main.memberNickname.Text}님, ";
            }

            if (comment_frm.ShowDialog() == DialogResult.OK)
            {
                Thread th = new Thread(new ThreadStart(() =>
                {
                    Review_Comment_Request request = new Review_Comment_Request()
                    {
                        reviewId = (long)Review_Main.Tag,
                        contents = comment_frm.textBox1.Text
                    };

                    Task<IRestResponse> tx_post = Task.Run(() => Web_Helper.Send_Request(post_url
                  , Method.POST, null, JsonConvert.SerializeObject(request), SELF_SERVICE_Headers));
                    tx_post.Wait();


                    if (tx_post.Result.StatusCode == HttpStatusCode.OK)
                    {
                        if (string.IsNullOrEmpty(tx_post.Result.Content))
                        {
                            Current_Comment.Invoke(new Action(() =>
                            {
                                Current_Comment.contents.Text = comment_frm.textBox1.Text;

                            }));
                        }
                        else
                        {
                            JToken o = Helper_Class.Json_Response(tx_post.Result.Content.ToString());
                            if (o["reviewCommentId"] != null)
                            {
                                //Review_Main.Main_Container
                                Review_Main.Invoke(new Action(() =>
                                {
                                    FlowLayoutPanel Comments_list = (FlowLayoutPanel)Review_Main.Main_Container.Controls["Comments_list"];

                                    if (Comments_list == null)
                                    {
                                        Comments_list = new FlowLayoutPanel()
                                        {
                                            FlowDirection = FlowDirection.TopDown,
                                            WrapContents = false,
                                            AutoSize = true,
                                            Name = "Comments_list",
                                            //BackColor = Color.Red,
                                        };
                                        Review_Main.Main_Container.Controls.Add(Comments_list);
                                        Review_Main.Main_Container.Controls.SetChildIndex(Comments_list, Review_Main.Main_Container.Controls.Count - 2);
                                    }

                                    Comment_Item cm = new Comment_Item();


                                    cm.Tag = o["reviewCommentId"];
                                    cm.managerNickname.Text = "사장님";
                                    cm.createdDate.Text = "오늘";
                                    cm.contents.Text = comment_frm.textBox1.Text;
                                    cm.MinimumSize = new Size(Review_Main.Main_Container.Width - 12, 0);
                                    cm.MaximumSize = new Size(Review_Main.Main_Container.Width - 12, 0);


                                    cm.Delete_btn.Click += (ss, ee) => { Comment_Delete_btn_Click(shop_number, Review_Main, cm); };


                                    Button Correct_Comment_btn = new Button()
                                    {
                                        AutoSize = true,
                                        Margin = new Padding(3),
                                        ForeColor = Color.DodgerBlue,
                                        FlatStyle = FlatStyle.Flat,
                                        Cursor = Cursors.Hand,
                                    };
                                    Correct_Comment_btn.Click += (ss, ee) => { Comment_Post_Click(shop_number, Review_Main, cm); };

                                    cm.Comment_buttons.Controls.Add(Correct_Comment_btn);
                                    Correct_Comment_btn.Text = "Correct";


                                    Comments_list.Controls.Add(cm);

                                    Load_Reviews_Count();


                                }));










                            }
                        }


                    }
                    else
                    {
                        Show_Error_Message("Server Error", "Can't Post Comment Please Try Again Later", new Action(() => { Comment_Post_Click(shop_number, Review_Main, Current_Comment); }));

                    }

                }));
                th.IsBackground = true; th.Start();



            }
        }

        private void All_Reviews_Lst_Paint(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel List_Panel = (FlowLayoutPanel)sender;

            if (List_Panel.VerticalScroll.Value >= (List_Panel.VerticalScroll.Maximum - 1000))
            {
                List_Panel.Paint -= All_Reviews_Lst_Paint;

                if (cancellationToken.Token.IsCancellationRequested == false)
                {
                    Load_Reviews(List_Panel);

                }

            }


        }





        #endregion

        #region Order History
        internal Date_Iem Selected_Date = new Date_Iem();


        Dictionary<string, string> PayType_Dic = new Dictionary<string, string>();
        Dictionary<string, string> OrderType_Dic = new Dictionary<string, string>();

        void Initialize_Filters()
        {
            TimeZoneInfo TZ = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            DateTime dt2 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TZ);

            Selected_Date.StartDate = dt2.AddDays(-6);
            Selected_Date.EndDate = dt2;
            this.Date_Selection.Text = Selected_Date.ToString();

            PayType_Dic.Add("BARO", "Pay now");
            PayType_Dic.Add("MEET", "Meet and pay");
            PayType_Dic.Add("RIDER", "Rider Payment");

            OrderType_Dic.Add("CLOSED", "Delivery Completed");
            OrderType_Dic.Add("CANCELLED", "Cancel an Order");
            OrderType_Dic.Add("ACCEPTED", "In Processing");


            this.Filters_List.Controls.Clear();
            Filter_Item Shop_number = new Filter_Item()
            {
                Name = "Shop_number",
                Text = "The Whole Shop"
            };

            this.Filters_List.Controls.Add(Shop_number);

            Filter_Item Order_Status = new Filter_Item()
            {
                Name = "Order_Status",
                Text = OrderType_Dic["CLOSED"],
                Tag = "CLOSED",
            };
            this.Filters_List.Controls.Add(Order_Status);


            Filter_Item Payment_Method = new Filter_Item()
            {
                Text = "Full Payment Method",
            };
            this.Filters_List.Controls.Add(Payment_Method);


            Back_Pages.Click += (ss, ee) =>
            {
                if (this.Pages.Left < 0)
                {
                    this.Pages.Location = new Point(this.Pages.Location.X + this.panel2.Width, this.Pages.Location.Y);

                }
            };


            Next_Pages.Click += (ss, ee) =>
            {
                if (this.Pages.Right > this.panel2.Width)
                {
                    this.Pages.Location = new Point(this.Pages.Location.X - this.panel2.Width, this.Pages.Location.Y);
                }
            };




        }

        void Load_Oder_History(string offset = "0")
        {
            //
            //Shop_number




            string orderStatus = null;
            string shopNumbers = "";
            string purchaseType = "";
            foreach (Filter_Item c in this.Filters_List.Controls)
            {
                if (c.Name == "Order_Status")
                {
                    orderStatus = c.Tag.ToString();
                }
                else if (c.Name == "Shop_number")
                {
                    if (c.Tag != null)
                    {
                        shopNumbers = ((Datum)c.Tag).shopNumber.ToString();
                    }
                }
                else if (c.Name == "purchaseType")
                {
                    if (purchaseType != "") { purchaseType += ","; }
                    purchaseType += c.Tag.ToString();
                }
            }




            this.Order_History_Grd.Invoke(new Action(() =>
            {
                this.Order_History_Grd.Rows.Clear();

            }));


#if !Design_Test

            if (shopOwnerNumber == null || orderStatus == null)
            {
                return;
            }

            Thread th = new Thread(new ThreadStart(() =>
            {

                //orderStatus=CLOSED&offset=0&limit=10&startDate=2022-09-22&endDate=2022-09-28&shopNumbers=&shopOwnerNumber=201411070015

                List<Tuple<string, string>> Q = new List<Tuple<string, string>>();
                //Q.Add(new Tuple<string, string>("orderStatus", "CLOSED")); 

                Q.Add(new Tuple<string, string>("offset", offset));
                Q.Add(new Tuple<string, string>("limit", "10"));
                Q.Add(new Tuple<string, string>("startDate", Selected_Date.StartDate.ToString("yyyy-MM-dd")));
                Q.Add(new Tuple<string, string>("endDate", Selected_Date.EndDate.ToString("yyyy-MM-dd")));

                Q.Add(new Tuple<string, string>("shopOwnerNumber", shopOwnerNumber));
                Q.Add(new Tuple<string, string>("shopNumbers", shopNumbers));


                Q.Add(new Tuple<string, string>("orderStatus", orderStatus));


                //Q.Add(new Tuple<string, string>("shopOwnerNumber", "201411070015")); //real accoun
                if (purchaseType != "")
                {
                    Q.Add(new Tuple<string, string>("purchaseType", purchaseType));

                }

                //201411070015

                //offset=0&limit=10&startDate=2023-12-15&endDate=2023-12-21&shopOwnerNumber=202112150426&shopNumbers=&orderStatus=CLOSED
                //Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self.baemin.com/v1/orders?", Method.GET, Q, null, SELF_SERVICE_Headers));
                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v4/orders?", Method.GET, Q, null, SELF_SERVICE_Headers));
                tx.Wait();


                if (!string.IsNullOrEmpty(tx.Result.Content))
                {

              

                    Order_History_Response Response = JsonConvert.DeserializeObject<Order_History_Response>(tx.Result.Content.ToString(), settings);
                    if (Response != null && Response.contents != null)
                    {
                        Order_History_UI_Helper(Response);
                    }
                    else if (Response.errorType != null && Response.errorMessage != null)
                    {

                        Show_Error_Message(Response.errorType, Response.errorMessage, new Action(() => { Load_Oder_History(); }));

                    }

                }


            }));


            th.IsBackground = true; th.Start();
#else

            Order_History_Response Response = JsonConvert.DeserializeObject<Order_History_Response>(System.IO.File.ReadAllText("Response\\Order_History.json"));
            Order_History_UI_Helper(Response);

#endif
        }



        void Order_History_UI_Helper(Order_History_Response Response)
        {
            this.Invoke(new Action(() =>
            {
                this.Orders_Number.Text = String.Format("Number of orders     {0} tendon", Response.totalSize);
                this.Payment.Text = String.Format("Payment     {0} won", Response.totalPayAmount.ToString("#,###,###"));



                this.Pages.Controls.Clear();

                if (Response.totalSize > 10)
                {

                    int Pages_Number = (Response.totalSize / 10) + ((Response.totalSize % 10) > 0 ? 1 : 0);

                    //MessageBox.Show(Pages_Number.ToString());
                    for (int p = 0; p < Pages_Number; p++)
                    {
                        Round_Button Page_Button = new Round_Button()
                        {
                            Text = (p + 1).ToString(),
                            Tag = p * 10,
                        };

                        Page_Button.Click += (ss, ee) =>
                        {
                            Load_Oder_History(Page_Button.Tag.ToString());
                        };

                        this.Pages.Controls.Add(Page_Button);

                    }




                    //MessageBox.Show((Response.totalSize / 10).ToString());
                    //MessageBox.Show((Response.totalSize % 10).ToString());
                    flowLayoutPanel3.Visible = true;
                }
                else
                {
                    flowLayoutPanel3.Visible = false;

                }







            }));



            foreach (Content OrderH in Response.contents)
            {
                Order _Order = OrderH.order;

                if (_Order != null)
                {

                    DataGridViewRow Order_Row = new DataGridViewRow();

                    DataGridViewTextBoxCell[] Order_Cells = new DataGridViewTextBoxCell[this.Order_History_Grd.ColumnCount];
                    for (int i = 0; i < Order_Cells.Length; i++)
                    {
                        Order_Cells[i] = new DataGridViewTextBoxCell();
                    }




                    Order_Cells[0].Value = _Order.orderNumber != null ? _Order.orderNumber + "\r\n" + OrderType_Dic[_Order.status] : String.Empty;
                    Order_Cells[1].Value = _Order.orderDateTime != null ? _Order.orderDateTime.ToString("yyyy. MM. dd. (ddd) hh:mm:ss tt", Web_Helper.Culture) : String.Empty;
                    Order_Cells[2].Value = String.Empty;//Advertising Product Group	
                    Order_Cells[3].Value = _Order.adCampaign != null ? _Order.adCampaign.id : String.Empty;
                    Order_Cells[4].Value = string.IsNullOrEmpty(_Order.itemsSummary) == false ? _Order.itemsSummary : String.Empty;
                    Order_Cells[5].Value = string.IsNullOrEmpty(_Order.payType) == false ? PayType_Dic[_Order.payType] : String.Empty;
                    Order_Cells[6].Value = string.IsNullOrEmpty(_Order.deliveryType) == false ? _Order.deliveryType : String.Empty;

                    Order_Cells[7].Value = _Order.payAmount.ToString("##,###") + " KRW";


                    foreach (DataGridViewTextBoxCell C in Order_Cells)
                    {
                        Order_Row.Cells.Add(C);
                    }



                    this.Order_History_Grd.Invoke(new Action(() =>
                    {
                        this.Order_History_Grd.Rows.Add(Order_Row);
                    }));

                }

            }

        }


        private void Date_Selection_Click(object sender, EventArgs e)
        {
            History_Period_frm frm = new History_Period_frm();

            frm.tabControl1.SelectedTab = frm.Date_Tab;
            frm.Selected_Date = Selected_Date;
            frm.Start_Date.Value = Selected_Date.StartDate;
            frm.EndDate.Value = Selected_Date.EndDate;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                Selected_Date = frm.Selected_Date;

                this.Date_Selection.Text = Selected_Date.ToString();
                Load_Oder_History();
            }
        }

        private void Filters_List_MouseClick(object sender, MouseEventArgs e)
        {

            Filters_frm frm = new Filters_frm();

            Padding _Margin = new Padding(30, 3, 3, 3);

            foreach (var o in OrderType_Dic)
            {
                RadioButton ch = new RadioButton()
                {
                    Text = o.Value,
                    Tag = o.Key,
                    AutoSize = true,
                    Margin = _Margin,
                };
                frm.Order_Status.Controls.Add(ch);
                //if ( o.Key == "CLOSED" )
                if (o.Key == this.Filters_List.Controls["Order_Status"].Tag.ToString())
                {
                    ch.Checked = true;
                }
            }


            frm.Shops_List.Items.Add("The Whole Shop");
            foreach (Datum s in this.Shops_List.Items)
            {
                frm.Shops_List.Items.Add(s);
            }
            Control cn = this.Filters_List.Controls.Find("Shop_number", true)[0];

            if (cn.Tag != null)
            {
                frm.Shops_List.SelectedItem = cn.Tag;
            }
            else
            {
                frm.Shops_List.SelectedIndex = 0;
            }


            Control[] f = this.Filters_List.Controls.Find("purchaseType", true);
            foreach (var o in PayType_Dic)
            {





                CheckBox ch = new CheckBox()
                {
                    Text = o.Value,
                    Tag = o.Key,
                    AutoSize = true,
                    Margin = _Margin,

                };

                if (f != null && f.Length > 0)
                {
                    if (f.FirstOrDefault(dd => dd.Tag == ch.Tag) != null)
                    {
                        ch.Checked = true;
                    }
                }

                frm.Payment_Method.Controls.Add(ch);
            }



            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                this.Filters_List.Controls.Clear();
                Filter_Item Shop_number = new Filter_Item()
                {
                    Name = "Shop_number",
                    Text = frm.Shops_List.Text
                };

                if (typeof(Datum) == frm.Shops_List.SelectedItem.GetType())
                {
                    //Shop_number.Tag = ((Datum)frm.Shops_List.SelectedItem).shopNumber;
                    Shop_number.Tag = frm.Shops_List.SelectedItem;
                }
                this.Filters_List.Controls.Add(Shop_number);




                foreach (RadioButton rd in frm.Order_Status.Controls)
                {
                    if (rd.Checked == true)
                    {
                        Filter_Item Order_Status = new Filter_Item()
                        {
                            Name = "Order_Status",
                            Text = rd.Text,
                            Tag = rd.Tag,
                        };

                        this.Filters_List.Controls.Add(Order_Status);
                        break;
                    }
                }

                //string purchaseType = "";
                for (int i = 0; i < frm.Payment_Method.Controls.Count; i++)
                {
                    CheckBox ch = (CheckBox)frm.Payment_Method.Controls[i];

                    if (ch.Checked == true)
                    {

                        this.Filters_List.Controls.Add(new Filter_Item
                        {
                            Name = "purchaseType",
                            Text = ch.Text,
                            Tag = ch.Tag,
                        });


                    }
                    else if (ch.Checked == false && i == frm.Payment_Method.Controls.Count - 1)
                    {
                        this.Filters_List.Controls.Add(new Filter_Item
                        {
                            Text = "Full Payment Method",
                        });
                    }

                }


                //Load_Oder_History(Order_Status.Tag.ToString(), Shop_number.Tag != null ? Shop_number.Tag.ToString() : "", purchaseType);
                Load_Oder_History();
            }



        }
        #endregion

        #region Edit Store Menu

        void Load_Menu_Items(Datum shop_Item)
        {
            cancellationToken = new CancellationTokenSource();

            this.Menu_List.Invoke(new Action(() =>
            {
                this.Menu_List.Controls.Clear();

            }));

#if !Design_Test
            Thread th = new Thread(new ThreadStart(() =>
            {






                if (shop_Item._Shop_Other_Details.menupanId == shop_Item._Shop_Other_Details.useMenupanId)  //if (shop_Item.useSmartOrder==true )// fix me
                {

                    Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/v1/shop-owners/{shopOwnerNumber}/menupans/{shop_Item._Shop_Other_Details.menupanId}", Method.GET, null, null, SELF_SERVICE_Headers)); // last
                    tx.Wait();


                    if (!string.IsNullOrEmpty(tx.Result.Content))
                    {


                        SoldOut Response = JsonConvert.DeserializeObject<SoldOut>(tx.Result.Content.ToString());
                        if (Response.data != null)
                        {

                            Load_Menu_Items_UI_For_Menupan(Response, shop_Item);



                        }
                        else
                        {
                            Show_Error_Message(Response.errorType, Response.errorMessage, new Action(() => { Load_Menu_Items_UI_For_Menupan(Response, shop_Item); }));

                        }
                    }




                }
                else
                {
                    Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://self-api.baemin.com/v1/smartmenu/common/ceo/v3/shops/{shop_Item.shopNumber}/menupans/{shop_Item._Shop_Other_Details.useMenupanId}/new", Method.GET, null, null, SELF_SERVICE_Headers));
                    tx.Wait();


                    if (!string.IsNullOrEmpty(tx.Result.Content))
                    {


                        useMenupan_Response Response = JsonConvert.DeserializeObject<useMenupan_Response>(tx.Result.Content.ToString());
                        if (Response.data != null)
                        {

                            Load_Menu_Items_UI_If_Menu_Blocked(Response, shop_Item);


                        }
                        else
                        {
                            Show_Error_Message(Response.errorType, Response.errorMessage, new Action(() => { Load_Menu_Items_UI_If_Menu_Blocked(Response, shop_Item); }));

                        }
                    }


                }


                Load_Menu_Items_Images();





            }));


            th.IsBackground = true; th.Start();





#else

            //SoldOut Response = JsonConvert.DeserializeObject<SoldOut>(System.IO.File.ReadAllText("Response\\Menu_Items.json"));
            //Load_Menu_Items_UI_For_Menupan(Response, shop_Item);

            //useMenupan_Response Response = JsonConvert.DeserializeObject<useMenupan_Response>(System.IO.File.ReadAllText("Response\\Menu_Items_useMenupanId.json"));
            //Load_Menu_Items_UI_For_useMenupanId(Response, shop_Item);

            SoldOut Response = JsonConvert.DeserializeObject<SoldOut>(System.IO.File.ReadAllText(@"Response\Menu Items\Main List 03.json"));
            Load_Menu_Items_UI_For_Menupan(Response, shop_Item);



#endif
        }

        void Load_Menu_Items_UI_For_Menupan(SoldOut Response, Datum shop_Item)
        {


            foreach (MenuGroup gr in Response.data.menuGroups)
            {
                if (cancellationToken.Token.IsCancellationRequested == true) { return; }

                FlowLayoutPanel GR = new FlowLayoutPanel()
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Margin = new Padding(0, 5, 0, 5),
                    BorderStyle = BorderStyle.FixedSingle

                };
                GR.Tag = gr.menuGroupId;
                GR.MinimumSize = new Size(Menu_Sold_Out.Width - 25, 0);
                GR.AutoSize = true;

                GR.Controls.Add(new Label() { Text = gr.menuGroupName, AutoSize = true, Margin = new Padding(5, 15, 5, 5) });



                foreach (Menu mp in gr.menus)
                {
                    if (cancellationToken.Token.IsCancellationRequested == false)
                    {

                        Menu_Item mu = new Menu_Item()
                        {
                            Cursor = Cursors.Hand,
                        };


                        mu.Tag = mp.menuId;
                        mu.popularMenuYn = mp.popularMenuYn;
                        mu.Menu_Name = String.Format("{0} {1}", mp.popularMenuYn == true ? "인기" : "", mp.menuName);
                        if (mp.menuPriceResponses.Count >= 0)
                        {
                            List<string> All_Prices = new List<string>();

                            foreach (MenuPriceResponse Price in mp.menuPriceResponses)
                            {
                                All_Prices.Add($"{Price.name} {Price.price}");
                            }
                            mu.Prices = All_Prices;

                        }


                        mu.Size = new Size(GR.Width - 10, GR.Height);

                        mu.useMenupanId = false;
                        mu.restockedAt = mp.restockedAt;
                        mu.itemStatus = mp.itemStatus;

                        mu.imageUrl = mp.imageUrl;


                        mu.Click += (sse, ee) =>
                        {

                            Edit_Menu_Item edit_frm = new Edit_Menu_Item();

                            edit_frm.mu = mu;


                            edit_frm.SELF_SERVICE_Headers = SELF_SERVICE_Headers;

                            edit_frm.shopOwnerNumber = shopOwnerNumber;
                            edit_frm.shopNumber = shop_Item.shopNumber;
                            edit_frm.menuId = mp.menuId;
                            edit_frm.menuGroupId = gr.menuGroupId;


                            edit_frm.menuName_LB.Text = mu.Menu_Name;
                            edit_frm.Prices = mu.Prices;
                            edit_frm.menuType_LB.Text = mp.menuType;


                            edit_frm.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                            edit_frm.pictureBox1.BackgroundImage = mu.Menu_Image.BackgroundImage;



                            edit_frm.ShowDialog(this);

                        };



                        GR.Controls.Add(mu);


                    }
                    else
                    {
                        break;

                    }



                }

                this.Invoke(new Action(() =>
                {
                    this.Menu_List.Controls.Add(GR);

                }));
            }



        }


        void Load_Menu_Items_UI_If_Menu_Blocked(useMenupan_Response Response, Datum shop_Item)
        {
            this.Invoke(new Action(() =>
            {
                this.Menu_List.Controls.Add(new Label()
                {
                    BackColor = Color.Red,
                    AutoSize = true,

                    MinimumSize = new Size(this.Menu_List.Width - 20, 0),
                    Margin = new Padding(0),
                    Padding = new Padding(5, 5, 5, 5),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = "이 본사 메뉴는 메뉴 가격 변경, 1인분 메뉴 설정, 품절, 숨김만 할 수 있어요.", //For this headquarters menu, you can only change the menu price, set the menu for one person, sell out, or hide it.
                });

            }));

            //cancellationToken = new CancellationTokenSource();
            foreach (MenuGroup2 gr in Response.data.menuGroups)
            {
                if (cancellationToken.Token.IsCancellationRequested == true) { return; }

                FlowLayoutPanel GR = new FlowLayoutPanel()
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Margin = new Padding(0, 5, 0, 5),
                    BorderStyle = BorderStyle.FixedSingle

                };
                //GR.Tag = gr.id;
                GR.Tag = gr.menuGroupId;
                GR.MinimumSize = new Size(Menu_Sold_Out.Width - 25, 0);
                GR.AutoSize = true;

                //GR.BackColor = Color.Red;
                //GR.Controls.Add(new Label() { Text = gr.name, AutoSize = true, Margin = new Padding(5, 15, 5, 5) });
                GR.Controls.Add(new Label() { Text = gr.menuGroupName, AutoSize = true, Margin = new Padding(5, 15, 5, 5) });



                foreach (Menu_02 mp in gr.menus)
                {
                    if (cancellationToken.Token.IsCancellationRequested == false)
                    {

                        Menu_Item mu = new Menu_Item()
                        {
                            Cursor = Cursors.Hand,
                        };
                        mu.useMenupanId = true;

                        if (mp.menuImage.menuImages.Count != 0)
                        {
                            mu.imageUrl = mp.menuImage.menuImages.Find(dd => dd.menuImageTypeCode == "THUMBNAIL").menuImageUrl;

                        }

                        //mu.Tag = mp.id;
                        mu.Tag = mp.menuId;
                        //mu.label1.Text = mp.name;
                        mu.popularMenuYn = mp.popularMenuYn;
                        mu.Menu_Name = String.Format("{0} {1}", mp.popularMenuYn == true ? "인기" : "", mp.menu.menuName);
                        //if (mp.menuPrices.Count >= 0)

                        //if (mp.menuPriceInfo.menuPriceInfos.Count >= 0) // will Check
                        //{
                        //    //mu.label2.Text = $"{mp.menuPrices[0].name} {mp.menuPrices[0].price}";
                        //    MenuPriceInfo2 price = mp.menuPriceInfo.menuPriceInfos.FirstOrDefault();

                        //    mu.Price = $"{price.menuPriceName} {price.menuPrice}";

                        //}
                        if (mp.menuPriceInfo.menuPriceInfos.Count >= 0) // will Check
                        {
                            //mu.Price = $"{mp.menuPriceResponses[0].name} {mp.menuPriceResponses[0].price}";
                            List<string> All_Prices = new List<string>();

                            foreach (MenuPriceInfo2 Price in mp.menuPriceInfo.menuPriceInfos)
                            {
                                All_Prices.Add($"{Price.menuPriceName} {Price.menuPrice}");
                            }
                            mu.Prices = All_Prices;

                        }

                        mu.MinimumSize = new Size(GR.Width - 10, 0);
                        //mu.Width = GR.Width - 10;
                        //mu.itemStatus = mp.itemStatus;
                        if (mp.menuSoldOuts != null && mp.menuSoldOuts.isSoldOut == true && mp.menuSoldOuts.restockedAt != null)
                        {
                            mu.restockedAt = mp.menuSoldOuts.restockedAt;
                            mu.itemStatus = "SOLDOUT";

                        }

                        mu.displayYn = mp.menu.displayYn;
                        //if(mp.menu.displayYn == true )
                        //{
                        //    //mu.itemStatus = "ACTIVE";
                        //    mu.IsHidden = false;

                        //}
                        //else
                        //{
                        //    mu.itemStatus = "HIDE";
                        //    mu.IsHidden = true ;


                        //}

                        if (mp.menuDisplayScheduleTime != null)
                        {
                            if (!string.IsNullOrEmpty(mp.menuDisplayScheduleTime.displayStartDate) && !string.IsNullOrEmpty(mp.menuDisplayScheduleTime.displayEndDate))
                            {
                                mu.Add_Panel("menuDisplayScheduleTime", "노출기간", string.Format("{0} ~ {1}", mp.menuDisplayScheduleTime.displayStartDate, mp.menuDisplayScheduleTime.displayEndDate));

                            }

                            if (!string.IsNullOrEmpty(mp.menuDisplayScheduleTime.displayStartTime) && !string.IsNullOrEmpty(mp.menuDisplayScheduleTime.displayEndTime))
                            {

                                mu.Add_Panel("menuDisplayScheduleTime", "노출기간", string.Format("{0} ~ {1}", mp.menuDisplayScheduleTime.displayStartTime, mp.menuDisplayScheduleTime.displayEndTime));

                            }

                        }


                        //mu.Sold_Out_btn.Click += (sss, eee) =>
                        //{



                        //    if (string.IsNullOrEmpty(mu.restockedAt))
                        //    {

                        //        Sold_Out_Date_Frm so_date = Initialize_Sold_out_Date_Frm(shop_Item, mu.restockedAt);
                        //        if (so_date.ShowDialog() == DialogResult.OK)
                        //        {
                        //            Update_Sold_out(shop_Item, mu, ((Time_Item)so_date.comboBox1.SelectedItem).Date_Time + " " + so_date.dateTimePicker1.Value.ToString("HH:mm"), "menu");
                        //        }

                        //    }
                        //    else
                        //    {

                        //        if (MessageBox.Show("Do you want to clear this sold out", "Clear Sold out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //        {
                        //            Update_Sold_out(shop_Item, mu, null, "menu");

                        //        }

                        //    }






                        //};




                        //mu.Change_btn.Click += (sss, eee) =>
                        //{
                        //    Sold_Out_Date_Frm so_date = Initialize_Sold_out_Date_Frm(shop_Item, mu.restockedAt);
                        //    if (so_date.ShowDialog() == DialogResult.OK)
                        //    {
                        //        Update_Sold_out(shop_Item, mu, ((Time_Item)so_date.comboBox1.SelectedItem).Date_Time + " " + so_date.dateTimePicker1.Value.ToString("HH:mm"), "menu");
                        //    }
                        //};

                        //mu.Menu_Image.BackgroundImageLayout = ImageLayout.Stretch;

                        mu.Click += (sse, ee) =>
                        {
                            Edit_Menu_Item edit_frm = new Edit_Menu_Item();
                            edit_frm.mu = mu;

                            edit_frm.button1.Enabled = false;
                            edit_frm.Menu_Blocked = true;

                            edit_frm.menupanId = gr.menupanId;
                            edit_frm.menuGroupId = gr.menuGroupId;
                            edit_frm.menuId = mp.menuId;
                            edit_frm.shopOwnerNumber = shopOwnerNumber;
                            edit_frm.shopNumber = shop_Item.shopNumber;

                            edit_frm.SELF_SERVICE_Headers = SELF_SERVICE_Headers;


                            edit_frm.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                            edit_frm.pictureBox1.BackgroundImage = mu.Menu_Image.BackgroundImage;

                            edit_frm.menuName_LB.Text = mp.menu.menuName;
                            edit_frm.Prices = mu.Prices;
                            edit_frm.menuType_LB.Text = mp.menu.menuTypeCode;

                            if (mu.displayYn == false)
                            {
                                edit_frm.Hiding_btn.BackColor = Color.DarkSlateGray;

                            }

                            //if (mp.menuSoldOuts!=null && mp.menuSoldOuts.isSoldOut == true )
                            //{
                            //    edit_frm.restockedAt = mp.menuSoldOuts.restockedAt;

                            //}

                            //edit_frm.restockedAt = mu.restockedAt;
                            //edit_frm.Item_Status = mu.itemStatus;





                            //Response.data.menupanId;


                            edit_frm.ShowDialog(this);

                        };


                        GR.Controls.Add(mu);
                    }
                    else
                    {
                        break;
                    }


                    //if (mp.menuImage != null)
                    //{
                    //mu.Menu_Image.Image = System.Drawing.Image.FromStream(Web_Helper.Load_Images_Test(mp.imageUrl));


                    //Task tx = new Task(new Action(() =>
                    //{
                    //    if (cancellationToken.IsCancellationRequested == false)
                    //    {

                    //        Bitmap bt = Load_image_02(mp.imageUrl, mu.Menu_Image.Width, mu.Menu_Image.Height);
                    //        mu.Menu_Image.BackgroundImage = bt;
                    //    }


                    //}), cancellationToken.Token);
                    //tx.Start();



                    //}

                }

                this.Invoke(new Action(() =>
                {
                    this.Menu_List.Controls.Add(GR);

                }));
            }
        }



        void Load_Menu_Items_Images()
        {

            Thread th2 = new Thread(new ThreadStart(() =>
            {



                foreach (FlowLayoutPanel cn in this.Menu_List.Controls.OfType<FlowLayoutPanel>())
                {

                    foreach (Menu_Item it in cn.Controls.OfType<Menu_Item>())
                    {
                        if (!string.IsNullOrEmpty(it.imageUrl))
                        {
                            //Task tx = new Task(new Action(async () =>

                            //{



                            WebClient dd = new WebClient();

#if Test_With_Proxy || Design_Test
                            dd.Proxy = Program.proxy;

#endif


                            if (cancellationToken.Token.IsCancellationRequested == false)
                            {
                                //MessageBox.Show(it.imageUrl);



                                Bitmap Bm = new Bitmap(Bitmap.FromStream(new System.IO.MemoryStream(dd.DownloadDataTaskAsync(it.imageUrl).Result)), it.Menu_Image.Size.Width, it.Menu_Image.Size.Height);

                                //it.Menu_Image.BackgroundImage =  System.Drawing.Image.FromStream( new System.IO.MemoryStream (await Load_Images_Test(it.imageUrl)  ));
                                it.Menu_Image.BackgroundImage = Bm;


                                //Bitmap bt = Load_image_02(it.imageUrl, it.Menu_Image.Width, it.Menu_Image.Height);
                                //it.Invoke(new Action(() =>
                                //{
                                //it.Menu_Image.BackgroundImage = bt;

                                //}));
                            }
                            else
                            {
                                dd.CancelAsync();
                                break;
                            }

                            //}), cancellationToken.Token);
                            //tx.Start();

                        }
                    }


                }




            }));

            th2.IsBackground = true;
            th2.Start();




            //if (!string.IsNullOrEmpty(mp.imageUrl))
            //{
            //    //mu.Menu_Image.Image = System.Drawing.Image.FromStream(Web_Helper.Load_Images_Test(mp.imageUrl));

            //    Thread th = new Thread(new ThreadStart(() =>
            //    {


            //        Task tx = new Task(new Action(() =>
            //        {
            //            if (cancellationToken.Token.IsCancellationRequested == false)
            //            {

            //                Bitmap bt = Load_image_02(mp.imageUrl, mu.Menu_Image.Width, mu.Menu_Image.Height);
            //                mu.Invoke(new Action(() =>
            //                {
            //                    mu.Menu_Image.BackgroundImage = bt;

            //                }));
            //            }


            //        }), cancellationToken.Token);
            //        tx.Start();
            //    }));

            //    //th.IsBackground = true;
            //    th.Start();


            //}
        }

        #endregion


        #region UI Helpers

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cancellationToken != null)
            {
                cancellationToken.Cancel();

            }


            if (this.Shops_List.SelectedItem == null) { return; }
            long shop_number = ((Datum)this.Shops_List.SelectedItem).shopNumber;


            if (this.tabControl1.SelectedTab == tabPage1)
            {
#if !Design_Test
                Load_Boss_Notice(shop_number, "notices");

#endif
            }
            else if (this.tabControl1.SelectedTab == tabPage2)
            {
                //#if !Design_Test
                //Operation_Hours.json
                //Load_Operation_Information(shop_number);
                Shop_Details ds = ((Datum)this.Shops_List.SelectedItem)._Shop_Details;
                Operation_Info_Response(ds);

                //#else

                //                Operation_Information_Request req = new Operation_Information_Request();

                //                Variables xx = new Variables();
                //                xx.shopNo = ((Datum)this.Shops_List.SelectedItem).shopNumber;

                //                req.variables = xx;


                //                string Json_Input = System.IO.File.ReadAllText(Application.StartupPath + "\\Response\\Operation_Info.json");





                //                Operation_Information_Response Response = JsonConvert.DeserializeObject<Operation_Information_Response>(Json_Input);
                //                Operation_Info_Response(Response, req);
                //#endif
            }
            else if (this.tabControl1.SelectedTab == tabPage3)
            {

                //Load_Menu_Sold_Out(((Datum)this.Shops_List.SelectedItem));

            }
            else if (this.tabControl1.SelectedTab == tabPage4)
            {
                //Load_word_from_Boss(shop_number);
            }


            else if (this.tabControl1.SelectedTab == tabPage6)
            {
                Load_Menu_Items(((Datum)this.Shops_List.SelectedItem));
            }

        }


        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {


            //if (cancellationToken != null) { cancellationToken.Cancel(); }

            //if (this.tabControl2.SelectedTab == MenuSoldOut_tab)
            //{
            //    Load_Menu_Sold_Out(((Datum)this.Shops_List.SelectedItem));
            //}
            //else if (this.tabControl2.SelectedTab == Optionstock_tab)
            //{
            //    Load_Option_out_of_stock(((Datum)this.Shops_List.SelectedItem));
            //}

        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cancellationToken != null)
            {
                cancellationToken.Cancel();

            }

            long shop_number = ((Datum)this.Shops_List.SelectedItem).shopNumber;

            if (this.tabControl3.SelectedTab == BossNotice_tab)
            {
                Load_Boss_Notice(shop_number, "notices");
            }
            else if (this.tabControl3.SelectedTab == fromBoss_tab)
            {
                Load_Boss_Notice(shop_number, "announcements");
            }
        }

        private void List_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Padding = new Padding(0);
            e.Control.Margin = new Padding(0, 5, 0, 5);
            e.Control.MinimumSize = new Size(((FlowLayoutPanel)sender).Width - 25, 0);
            e.Control.MaximumSize = new Size(((FlowLayoutPanel)sender).Width - 25, 0);

            e.Control.Size = new Size(((FlowLayoutPanel)sender).Width - 25, e.Control.Height);



            //e.Control.Width = ((FlowLayoutPanel)sender).Width - 6;

        }

        void Show_Error_Message(string Error_Type, string Error_Message, Action Callback)
        {

            this.Invoke(new Action(() =>
            {
                if (Error_Type == "UNAUTHORIZED_DEFAULT" || Error_Type == "NOT_AUTH")
                {
                    MessageBox.Show(this, "Authorization Failed", Error_Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Login_frm _Login_frm = new Login_frm();

                    _Login_frm.button1.Click += (ss, ee) =>
                    {
                        if (Web_Login_Helper.Web_Login(_Login_frm) == true)
                        {
                            MessageBox.Show(this, "Authorization Success", "Authorized", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //_Login_frm.Dispose();
                            //Load_Profile();
                            Callback();
                        }
                    };
                    _Login_frm.ShowDialog(this);


                    //if ( _Login_frm.ShowDialog(this) == DialogResult.OK )
                    //{
                    //    if ( Web_Login_Helper.Web_Login(_Login_frm.username.Text, _Login_frm.password.Text) == true )
                    //    {
                    //        MessageBox.Show(this, "Authorization Success", "Authorized", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //        //Load_Profile();
                    //        Callback();
                    //    }
                    //}





                }
                else
                {
                    MessageBox.Show(this, Error_Message, Error_Type, MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }));


        }







        //        public async Task<byte[]> Load_Images_Test(string Image_url)
        //        {
        //            WebClient dd = new WebClient();

        //#if Test_With_Proxy || Design_Test
        //            dd.Proxy = Program.proxy;


        //#endif

        //            return await dd.DownloadDataTaskAsync(Image_url);
        //            //return  await   new Task <System.IO.MemoryStream>( new Func<System.IO.MemoryStream>(dd.DownloadDataTaskAsync(Image_url).RunSynchronously()) );

        //            //return dd.DownloadDataAsync(new Uri(Image_url));
        //            //return new System.IO.MemoryStream(dd.DownloadDataAsync(new Uri(Image_url))   );
        //        }


        #endregion






        private void button1_Click(object sender, EventArgs e)
        {

            cancellationToken.Cancel();
            return;

#if Design_Test
    
#else
            //Datum selected = ((Datum)this.Shops_List.SelectedItem);
            //Load_Menu_Menus(selected);
#endif
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Helper_Class.Is_IP_OK(true);

            //WebClient dd = new WebClient();
            //dd.Proxy = Program.proxy;




            //System.IO.MemoryStream yyy = new System.IO.MemoryStream(dd.DownloadData("https://bmreview.cdn.baemin.com/bmreview-qh2e/i/2023/9/20/01harrck6pgzw5hq58gj5v5d83.jpg"));
            //PictureBox bx = new PictureBox();
            ////bx.Image = System.Drawing.Image.FromStream(yyy);
            //bx.Image = new System.Drawing.Bitmap(yyy);

            //Login_frm _Login_frm = new Login_frm();

            //_Login_frm.button1.Click += (ss, ee) =>
            //{
            //    if (Web_Login_Helper.Web_Login(_Login_frm) == true)
            //    {
            //        MessageBox.Show(this, "Authorization Success", "Authorized", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //_Login_frm.Dispose();
            //        //Load_Profile();
            //    }
            //};
            //_Login_frm.ShowDialog(this);
        }
    }

}
