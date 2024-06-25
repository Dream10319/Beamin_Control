using Beamin_Control.Controls;
using Beamin_Control.Main_Class;
using CefSharp.DevTools.BackgroundService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control
{


    public partial class Form1 : Form
    {
        public int Checker_New_Order_Timer_current = Orders_Control.Checker_New_Order_Timer;

        private void Apply_Language()
        {
            this.Login_Btn.Text = Program.Language.De[400]; //Login
            this.Web_Settings_btn.Text = Program.Language.De[500];

            this.tabPage1.Text = Program.Language.De[501];
            this.tabPage2.Text = Program.Language.De[502];
        }

        public JsonSerializerSettings Serializer_Settings = new JsonSerializerSettings { Error = (se, ev) => { ev.ErrorContext.Handled = true; } };

        public List<Tuple<string, string>> Special_Headers = new List<Tuple<string, string>>();




        Thread Load_Settings, Load_Completed_Orders_TH;




        public JArray Cancel_Codes;
        public JArray selectedTimes;

        public Form1()
        {
            InitializeComponent();
            Apply_Language();
            Orders_Control.Main_Frm = this;
            Availabilitie_Control.Main_Frm = this;

            //Availabilities_Check_TH = new Thread(new ThreadStart(Availabilities_Check));
            Load_Completed_Orders_TH = new Thread(new ThreadStart(() => { Orders_Control.Load_Orders_Details(); }));

            Load_Completed_Orders_TH.IsBackground = true;
            //Check_New_Orders_TH = new Thread(new ThreadStart(() => {


            //}));
            //this.Enabled = false;









            //Check_For_New_Version_TH = new Thread(new ThreadStart(Check_For_New_Version));
            //Availabilities_Check_TH = new Thread(new ThreadStart(Availabilities_Check));
            //Load_Cancel_Codes_TH = new Thread(new ThreadStart(Load_Cancel_Codes));
            //Load_Selected_Times_TH = new Thread(new ThreadStart(Load_Selected_Times));
            //Load_Completed_Orders_TH = new Thread(new ThreadStart(() => { Load_Orders_Details} ) );
            //Check_New_Orders_TH = new Thread(new ThreadStart(Check_New_Orders));

            this.FormClosing += (s, e) =>
            {

                //if (Load_Settings.IsAlive == true)
                //{
                //    Load_Settings.Abort();

                //    MessageBox.Show("alive");
                //}

                //Availabilities_Check_TH.Abort();

                //Load_Completed_Orders_TH = null;

                //Load_Completed_Orders_TH = new Thread(new ThreadStart(() => { MessageBox.Show("ddd"); }));

                //if (Load_Completed_Orders_TH.IsAlive == true)
                //{
                //    //MessageBox.Show("alive");
                //    Load_Completed_Orders_TH.Abort();

                //}

                // Check_New_Orders_TH.Abort(); // Bug here Please Fix Me (^_^)

                //Check_For_New_Version_TH.Abort();
                //Availabilities_Check_TH.Abort();
                //Load_Cancel_Codes_TH.Abort();
                //Load_Selected_Times_TH.Abort();
                //Load_Completed_Orders_TH.Abort();
                //Check_New_Orders_TH.Abort(); // Bug here Please Fix Me (^_^)
            };
        }





        public void Form1_Load(object sender, EventArgs e)
        {

            Properties.Settings.Default.X_Channel = "BM_PC"; //Fix me Now Please
            Properties.Settings.Default.Save();

#if Test_With_Proxy
            this.button2.Visible = true;
#endif
            if (Properties.Settings.Default.Default_Language == "Korean")
            {
                this.comboBox1.SelectedIndex = 1;
            }
            else if (Properties.Settings.Default.Default_Language == "English")
            {
                this.comboBox1.SelectedIndex = 0;

            }

            this.comboBox1.SelectedIndexChanged += (ss, ee) =>
            {
                if (this.comboBox1.SelectedIndex == 1)
                {
                    Properties.Settings.Default.Default_Language = "Korean";
                }
                else
                {
                    Properties.Settings.Default.Default_Language = "English";

                }


                Properties.Settings.Default.Save();



                Program.Language = new Language_Class(Properties.Settings.Default.Default_Language);
                Apply_Language();
            };




#if Test_With_Proxy

            if (Helper_Class.Is_IP_OK() == false)
            {
                return;
            }

            //Properties.Settings.Default.X_Auth = "eyJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwiYWxnIjoiUlNBLU9BRVAtMjU2In0.eWhd5uKyu6SH8mpkFssuYl3e1C2-QDIPu1cuBYMmm5u348E4a4iOs8dbi92cptX0QWGxyLEpSVH6_yFNeE_Up68vonxHq_nAZQGCpgPjx8dctKrBtkLzOpvFGHfbvfCSnz7ZyVQMZ5cn3d3HFbGnQkVOzb2OMVZYSh6wyWy2taXyLCbMOs6d7TSoshy5CjBYxMaS2vf891T2iU114NvIFvyBlGxtxqt7O8VRFVeTsQtXDUm6-zIe9SZYRdgOBXwup9FP8D1HmvY3ZU0qhHb8Ci0xeJLtLTS5DzuEuPSTUnUTN2eqRJNonY_svj865uu9u7WmYd2A4KCbB_5N_hzedg.rXihftp3z8YYmB8g_rFScg.remNVPzG2XxTY5_YOWyhlvtTc9h4YFvhryihz-O5rZ-2_WiCISh88_crKKE8IQwVl_QJcevOXkS8KEAPwJZvnvgpP85qXM-rTPQW6ynNOeRfGKGnfvOSCIsX7OQUuCLXqc9hvUiYRahZQzyulXqmc1XnIiRg9ixnmxb1oV0CjEQbtCCk9OSwjicDrAcOFTdaSl0cf5b2Ta7EmgoOHBohTw._oHjMz4NA9to-ajwEPTObQ";
            //Properties.Settings.Default.Save();
#endif


#if Design_Test
            this.button2.Visible = true;
#endif

            Check_For_New_Version();




            if (string.IsNullOrEmpty(Properties.Settings.Default.deviceToken) ||
                string.IsNullOrEmpty(Properties.Settings.Default.Member_No) ||
                string.IsNullOrEmpty(Properties.Settings.Default.Owner_No) ||
                string.IsNullOrEmpty(Properties.Settings.Default.X_Auth) ||
                string.IsNullOrEmpty(Properties.Settings.Default.X_Refresh) ||
                string.IsNullOrEmpty(Properties.Settings.Default.ETag)
                )
            {

                //Login_Btn.PerformClick();

            }
            else
            {
                //Properties.Settings.Default.CurrentVersion = "0.8.1680.0";//0.8.1470.0
                //Properties.Settings.Default.CurrentVersion = "0.8.1571.0";//0.8.1470.0

                Initialize_Special_Headers();


                if (Load_Settings != null && Load_Settings.IsAlive == true)
                {
                    Load_Settings.Abort();

                }

                Load_Settings = new Thread(new ThreadStart(() =>
                //Load_Settings_Task = new Task( new Action(() =>
                {

                    //if (Check_For_New_Version() == true)
                    //{
                    if (Availabilitie_Control.Availabilities_Check() == true && Load_Selected_Times() == true && Load_Cancel_Codes() == true)
                    {

                        Load_Completed_Orders_TH.Start();
                        this.Invoke(new Action(() =>
                        {
                            timer1.Enabled = true;
                            Login_Btn.Text = Program.Language.De[401]; // Logout
                        }));
                    }

                    //}


                }));

                Load_Settings.IsBackground = true;

                Load_Settings.Start();

            }

        }

        private void Initialize_Special_Headers()
        {
            Special_Headers.Clear();
            Special_Headers.Add(new Tuple<string, string>("X-Auth", Properties.Settings.Default.X_Auth));
            Special_Headers.Add(new Tuple<string, string>("X-Refresh", Properties.Settings.Default.X_Refresh));
            Special_Headers.Add(new Tuple<string, string>("X-MchN", Properties.Settings.Default.Owner_No));
            Special_Headers.Add(new Tuple<string, string>("X-DeviceToken", Properties.Settings.Default.deviceToken));
            Special_Headers.Add(new Tuple<string, string>("X-UserAgent", Properties.Settings.Default.CurrentVersion));
            Special_Headers.Add(new Tuple<string, string>("X-Api-Secret-Version", "woowa-sec-v1"));
            Special_Headers.Add(new Tuple<string, string>("X-Api-Secret", ""));
        }




        private bool Check_For_New_Version()
        {
            JObject request_payload = new JObject();
            request_payload.Add("_t", "TUpdateTargetDeviceReq");
            request_payload.Add("currentVersion", string.IsNullOrEmpty(Properties.Settings.Default.CurrentVersion) ? "0.8.1680.0" : Properties.Settings.Default.CurrentVersion);
            request_payload.Add("ReqContentType", 5);

            Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request("https://advance-relay.baemin.com/v5/patch-files/verifications/target-device", Method.POST, null, request_payload.ToString()));
            tx.Wait();

            //MessageBox.Show(tx.Result.Content);
            if (!string.IsNullOrEmpty(tx.Result.Content))
            {
                JToken o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                if (tx.Result.StatusCode == HttpStatusCode.OK && o.SelectToken("rspCode").ToString() == "200")
                {
                    if (o["data"].HasValues == true)
                    {
                        string new_Version = o["data"]["version"].ToString();
                        if (new_Version.Contains("."))
                        {
                            Properties.Settings.Default.CurrentVersion = new_Version.Substring(0, new_Version.LastIndexOf(".")).ToString() + ".0";
                            Properties.Settings.Default.Save();
                        }

                        this.Invoke(new Action(() =>
                        {
                            this.App_Version.Text = String.Format("{0}: {1}", Program.Language.De[02], Properties.Settings.Default.CurrentVersion);

                        }));

                        return true;

                    }
                }
            }


            return false;

        }
        private bool Load_Selected_Times()
        {
            Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request("https://advance-relay.baemin.com/v10/order/selectedTimes", Method.GET, null, null, Special_Headers));
            tx.Wait();

            if (!string.IsNullOrEmpty(tx.Result.Content))
            {
                JToken o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                if (tx.Result.StatusCode == HttpStatusCode.OK && o.SelectToken("rspCode").ToString() == "200")
                {
                    if (o["data"].HasValues == true)
                    {
                        selectedTimes = (JArray)o["data"];
                        return true;

                    }
                }
            }

            return false;

        }
        private bool Load_Cancel_Codes()
        {
            Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request("https://advance-relay.baemin.com/v8/order/cancelCodes", Method.GET, null, null, Special_Headers));
            tx.Wait();
            if (!string.IsNullOrEmpty(tx.Result.Content))
            {
                JToken o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                if (tx.Result.StatusCode == HttpStatusCode.OK && o.SelectToken("rspCode").ToString() == "200")
                {

                    if (o["data"].HasValues == true)
                    {
                        Cancel_Codes = (JArray)o["data"];


                   

                        return true;
                    }
                }

            }

            return false;
        }




        private void Login_Button(object sender, EventArgs e)
        {


            if (this.Login_Btn.Text == Program.Language.De[400]) // Login

            {
                App_Login.Hardware_Info_Frm HW_FRM = new App_Login.Hardware_Info_Frm();
                HW_FRM.Text = Program.Language.De[4000];
                if (HW_FRM.ShowDialog() != DialogResult.OK)
                {
                    return;
                }


                Login_frm frm = new Login_frm();

                frm.button1.Click += (ss, ee) =>
                {
#if Test_With_Proxy
                    if (Helper_Class.Is_IP_OK() == false)
                    {
                        return;
                    }
#endif

                    frm.button1.Enabled = false;
                    Thread th = new Thread(new ParameterizedThreadStart((object f) =>
                    {

                        if (string.IsNullOrEmpty(frm.username.Text) && string.IsNullOrEmpty(frm.password.Text))
                        {
                            return;
                        }


                        var client = new RestClient("https://advance-relay.baemin.com");
                        var request = new RestRequest("v3/auth/login");
                        request.AddHeader("User-Agent", "woowa-order-relay");
                        request.AddHeader("Host", "advance-relay.baemin.com");
                        request.AddJsonBody(new
                        {
                            ReqContentType = 5,
                            _t = "TLoginReq",
                            deviceHddSerial = "DE4F-F2A0",
                            deviceMacAddress = "70:85:C2:7F:BE:B5",
                            deviceMotherBoardId = "DESKTOP-QCAKS75",
                            deviceName = "DESKTOP-QCAKS75",
                            domain = "bmord",
                            os = "Windows 10 (Version 10.0, Build 18363, 64-bit Edition)",
                            pwd = frm.password.Text,
                            typ = "in",
                            uid = frm.username.Text,
                            version = "0.8.2581.0"
                        });
                        var response = client.ExecutePostAsync(request);
                        var data = JObject.Parse(response.Result.Content);
                        if (data["rspCode"].ToString() == "301")
                        {
                            Properties.Settings.Default.Owner_No = data["data"]["merchantNo"].ToString();
                            Properties.Settings.Default.Save();

                            request = new RestRequest($"v3/device/{Properties.Settings.Default.Owner_No}");
                            response = client.ExecuteGetAsync(request);
                            data = JObject.Parse(response.Result.Content);
                            Properties.Settings.Default.deviceToken = data["data"][0]["token"].ToString();
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.Owner_No = data["data"]["Owner_No"].ToString();
                            Properties.Settings.Default.deviceToken = data["data"]["deviceToken"].ToString();
                            Properties.Settings.Default.Save();
                        }

                        List<Tuple<string, string>> Special_Login_Headers_1 = new List<Tuple<string, string>>();

                        Special_Login_Headers_1.Add(new Tuple<string, string>("X-Api-Secret-Version", "woowa-sec-v1"));
                        Special_Login_Headers_1.Add(new Tuple<string, string>("X-Api-Secret", ""));


                        JObject request_payload = new JObject();


                        request_payload.Add("_t", "TLoginReq");
                        request_payload.Add("uid", frm.username.Text);
                        request_payload.Add("typ", "in");
                        request_payload.Add("domain", "bmord");
                        request_payload.Add("version", Properties.Settings.Default.CurrentVersion);
                        request_payload.Add("os", Properties.Settings.Default._os);
                        request_payload.Add("deviceName", Properties.Settings.Default._deviceName);
                        request_payload.Add("deviceMacAddress", Properties.Settings.Default._deviceMacAddress);
                        request_payload.Add("deviceMotherBoardId", Properties.Settings.Default._deviceMotherBoardId);
                        request_payload.Add("deviceHddSerial", Properties.Settings.Default._deviceHddSerial);
                        request_payload.Add("pwd", frm.password.Text);


                        //request_payload.Add("deviceToken", "2BA9F810-061C-483A-810C-BD5E8FC396B6");
                        //Special_Login_Headers_1.Add(new Tuple<string, string>("X-MchN", "201411070015"));
                        //Special_Login_Headers_1.Add(new Tuple<string, string>("X-DeviceToken", "BM_PC2BA9F810-061C-483A-810C-BD5E8FC396B6"));

                        //2BA9F810-061C-483A-810C-BD5E8FC396B6
#if Test_With_Proxy
                        request_payload.Add("deviceToken", "2BA9F810-061C-483A-810C-BD5E8FC396B6");


#else
                        if (!string.IsNullOrEmpty(Properties.Settings.Default.Owner_No) && !string.IsNullOrEmpty(Properties.Settings.Default.deviceToken) &&
                       !string.IsNullOrEmpty(Properties.Settings.Default.X_Channel))
                        {
                            Special_Login_Headers_1.Add(new Tuple<string, string>("X-MchN", Properties.Settings.Default.Owner_No));
                            Special_Login_Headers_1.Add(new Tuple<string, string>("X-DeviceToken", Properties.Settings.Default.deviceToken));

                            string Dd = Properties.Settings.Default.deviceToken.Replace(Properties.Settings.Default.X_Channel, null);

                            request_payload.Add("deviceToken", Dd);

                        }

#endif


                        request_payload.Add("ReqContentType", 5);

                        Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request("https://advance-relay.baemin.com/v3/auth/login", Method.POST, null, request_payload.ToString(), Special_Login_Headers_1));

                        tx.Wait();


                        if (!string.IsNullOrEmpty(tx.Result.Content))
                        {

                            var o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                            if (o.SelectToken("rspCode").ToString() == "200")
                            {

                                string X_Auth = null, X_Refresh = null, deviceToken = null, Owner_No = null, Member_No, ETag = null;

                                if (o["data"].HasValues == true)
                                {
                                    if (o["data"]["deviceToken"] != null)
                                    {

                                        deviceToken = o["data"]["deviceToken"].ToString();
                                        Owner_No = o["data"]["Owner_No"].ToString();
                                        Member_No = o["data"]["Member_No"].ToString();

                                        foreach (var res in tx.Result.Headers)
                                        {
                                            if (res.Name == "X-Auth")
                                            {
                                                X_Auth = res.Value.ToString();
                                            }

                                            if (res.Name == "X-Refresh")
                                            {
                                                X_Refresh = res.Value.ToString();
                                            }

                                            if (res.Name == "ETag")
                                            {
                                                ETag = res.Value.ToString();
                                            }
                                        }

                                        if (X_Auth != null && X_Refresh != null && Owner_No != null)
                                        {

                                            JObject request_payload2 = new JObject();
                                            request_payload2.Add("_t", "TAuthRefreshReq");
                                            request_payload2.Add("domain", "bmord");
                                            request_payload2.Add("version", Properties.Settings.Default.CurrentVersion);

                                            request_payload2.Add("deviceName", Properties.Settings.Default._deviceName);
                                            request_payload2.Add("deviceMacAddress", Properties.Settings.Default._deviceMacAddress);
                                            request_payload2.Add("deviceMotherBoardId", Properties.Settings.Default._deviceMotherBoardId);
                                            request_payload2.Add("deviceHddSerial", Properties.Settings.Default._deviceHddSerial);
                                            request_payload2.Add("os", Properties.Settings.Default._os);

                                            request_payload2.Add("ReqContentType", 5);




                                            List<Tuple<string, string>> Special_Login_Headers = new List<Tuple<string, string>>();
                                            Special_Login_Headers.Add(new Tuple<string, string>("X-Auth", X_Auth));
                                            Special_Login_Headers.Add(new Tuple<string, string>("X-Refresh", X_Refresh));
                                            Special_Login_Headers.Add(new Tuple<string, string>("X-MchN", Owner_No));
                                            Special_Login_Headers.Add(new Tuple<string, string>("X-DeviceToken", deviceToken));
                                            Special_Login_Headers.Add(new Tuple<string, string>("X-UserAgent", Properties.Settings.Default.CurrentVersion));
                                            Special_Login_Headers.Add(new Tuple<string, string>("X-Api-Secret-Version", "woowa-sec-v1"));
                                            Special_Login_Headers.Add(new Tuple<string, string>("X-Api-Secret", ""));

                                            Task<IRestResponse> tx2 = Task.Run(() => Helper_Class.Send_Request("https://advance-relay.baemin.com/v3/auth/refresh", Method.POST, null, request_payload2.ToString(), Special_Login_Headers));
                                            tx2.Wait();

                                            var o2 = Helper_Class.Json_Response(tx2.Result.Content.ToString());
                                            if (o2.SelectToken("rspCode").ToString() == "200")
                                            {
                                                foreach (var res in tx2.Result.Headers)
                                                {
                                                    if (res.Name == "X-Auth")
                                                    {
                                                        X_Auth = res.Value.ToString();
                                                    }

                                                    if (res.Name == "X-Refresh")
                                                    {
                                                        X_Refresh = res.Value.ToString();
                                                    }

                                                    if (res.Name == "ETag")
                                                    {
                                                        ETag = res.Value.ToString();
                                                    }
                                                }

                                                Properties.Settings.Default.deviceToken = deviceToken;
                                                Properties.Settings.Default.Member_No = Member_No;
                                                Properties.Settings.Default.Owner_No = Owner_No;
                                                Properties.Settings.Default.X_Auth = X_Auth;
                                                Properties.Settings.Default.X_Refresh = X_Refresh;
                                                Properties.Settings.Default.ETag = ETag;

                                                Properties.Settings.Default.User_Name = frm.username.Text;
                                                Properties.Settings.Default.Save();


                                                ShowMessages(Program.Language.De[2000], "", MessageBoxIcon.Information, new Action(() =>
                                                {
                                                    frm.Dispose();
                                                    Form1_Load(null, EventArgs.Empty);
                                                    //Initialize_Special_Headers();


                                                }));


                                                //this.Invoke(new Action(() =>
                                                //{
                                                //    MessageBox.Show(this, "Authorization Success", "Authorized", MessageBoxButtons.OK, MessageBoxIcon.Information);




                                                //    //((Form1)Application.OpenForms["Form1"]).Form1_Load(null, EventArgs.Empty);
                                                //    //this.Dispose();
                                                //}));



                                            }




                                            //Form1 frm = (Form1)Application.OpenForms[0];


                                        }


                                    }
                                }

                            }

                            else if (o.SelectToken("rspCode").ToString() == "301")
                            {
                                this.Invoke(new Action(() =>
                                {

                                    frm.button1.Enabled = true;

                                    //foreach (var res in tx.Result.Headers)
                                    //{
                                    //    if (res.Name == "X-Auth")
                                    //    {
                                    //        Properties.Settings.Default.X_Auth = res.Value.ToString();
                                    //        Properties.Settings.Default.Save();
                                    //    }

                                    //    if (res.Name == "X-Refresh")
                                    //    {
                                    //        Properties.Settings.Default.X_Refresh = res.Value.ToString();
                                    //        Properties.Settings.Default.Save();
                                    //    }

                                    //    if (res.Name == "ETag")
                                    //    {
                                    //        Properties.Settings.Default.ETag = res.Value.ToString();
                                    //        Properties.Settings.Default.Save();
                                    //    }
                                    //}


                                    //MessageBox.Show(this, "Need Mobile Authorization", "Mobile Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    ShowMessages(Program.Language.De[2001], Program.Language.De[2002], MessageBoxIcon.Information, new Action(() =>
                                    {
                                        Mobile_Authorization auth = new Mobile_Authorization();
                                        auth.memberNo = o["data"]["memberNo"].ToString();
                                        auth.tempDeviceToken = o["data"]["tempDeviceToken"].ToString();
                                        auth.merchantNo = o["data"]["merchantNo"].ToString();
                                        if (auth.ShowDialog(frm) == DialogResult.Yes)
                                        {
                                            Login_Button(sender, e); // login Again
                                        }
                                    }));





                                }));


                                //MessageBox.Show(this, o.SelectToken("rspMsg").ToString(), o.SelectToken("code").ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                            else
                            {
                                this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show(this, o.SelectToken("rspMsg").ToString(), "Authorization Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }));
                            }

                        }


                        //}
                        //else
                        //{
                        //    this.Invoke(new Action(() => {

                        //        MessageBox.Show(this, "Not Same IP","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }));

                        //}


                        if (!this.IsDisposed)
                        {
                            this.Invoke(new Action(() =>
                            {

                                frm.button1.Enabled = true;

                            }));
                        }

                    }));
                    th.Start();
                };

                frm.ShowDialog(this);

            }
            else
            {
                if (MessageBox.Show(Program.Language.De[2003], Program.Language.De[401], MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Thread th = new Thread(new ThreadStart(() =>
                    {

                        JObject x = new JObject();
                        x.Add("_t", "TLogoutReq");
                        x.Add("merchantNo", Properties.Settings.Default.Owner_No);
                        x.Add("deviceToken", Properties.Settings.Default.deviceToken);
                        x.Add("ReqContentType", 5);


                        Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v4/auth/logout", Method.POST, null, x.ToString(), Special_Headers));
                        tx.Wait();
                        if (tx.Result.StatusCode == HttpStatusCode.OK)
                        {
                            this.Invoke(new Action(() =>
                            {
                                Properties.Settings.Default.deviceToken = null;
                                Properties.Settings.Default.Member_No = null;
                                Properties.Settings.Default.Owner_No = null;
                                Properties.Settings.Default.X_Auth = null;
                                Properties.Settings.Default.X_Refresh = null;
                                Properties.Settings.Default.ETag = null;
                                Properties.Settings.Default.User_Name = null;
                                Properties.Settings.Default.X_Channel = null;

                                Properties.Settings.Default.Save();

                                Login_Btn.Text = Program.Language.De[400]; // Login
                                Special_Headers.Clear();
                                timer1.Enabled = false;
                                Order_Checker_lable.Text = "...";
                                Order_Details.Controls.Clear();
                                Completed_Orders_Details.Controls.Clear();
                                New_Orders.Controls.Clear();
                                In_Progress_Orders.Controls.Clear();
                                Completed_Orders.Controls.Clear();

                            }));
                        }
                    }));
                    th.Start();
                }
            }
        }


#region Availabilitie Control UI
        private void Show_Close_TIme()
        {


            REJECT_REASON_frm frm = new REJECT_REASON_frm() { Text = Program.Language.De[700] };
            Button Close_Time_01 = new Button()
            {
                Text = Program.Language.De[701],
                Tag = 30,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(250, 40),
                Image = Properties.Resources.Busy,
                ImageAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            Button Close_Time_02 = new Button()
            {
                Text = Program.Language.De[702],
                Tag = 60,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(250, 40),
                Image = Properties.Resources.Busy,
                ImageAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            Button Close_Time_03 = new Button()
            {
                Text = Program.Language.De[703],
                Tag = 90,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(250, 40),
                Image = Properties.Resources.Busy,
                ImageAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            Button Close_Time_04 = new Button()
            {
                Text = Program.Language.De[704],
                Tag = 120,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(250, 40),
                Image = Properties.Resources.Busy,
                ImageAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            Button Close_Time_05 = new Button()
            {
                Text = Program.Language.De[705],
                Tag = 180,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(250, 40),
                Image = Properties.Resources.Busy,
                ImageAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            Button Close_Time_06 = new Button()
            {
                Text = Program.Language.De[706],
                Tag = 240,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(250, 40),
                Image = Properties.Resources.Busy,
                ImageAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            //reson.Click += (ss, ee) => { Order_Set_Action_Click(ss, ee, Order_No, reson.Tag.ToString(), "5", shopNo); };
            frm.flowLayoutPanel1.Controls.Add(Close_Time_01);
            frm.flowLayoutPanel1.Controls.Add(Close_Time_02);
            frm.flowLayoutPanel1.Controls.Add(Close_Time_03);
            frm.flowLayoutPanel1.Controls.Add(Close_Time_04);
            frm.flowLayoutPanel1.Controls.Add(Close_Time_05);
            frm.flowLayoutPanel1.Controls.Add(Close_Time_06);
            foreach (Button b in frm.flowLayoutPanel1.Controls)
            {
                b.Click += (ss, ee) => { Availabilitie_Control.Set_Availabilities_Status(b, ee, Availabilitie_Control.Availabilities_Status.Block); };
            }
            frm.ShowDialog(this);
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            if (Close_btn.Tag != null)
            {

                switch ((bool)Close_btn.Tag)
                {
                    case true:  //"Temporarily Suspend":
                        Show_Close_TIme();
                        break;
                    case false:  //"Open":
                        if (MessageBox.Show(Program.Language.De[100], Program.Language.De[101],
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Availabilitie_Control.Set_Availabilities_Status(null, null, Availabilitie_Control.Availabilities_Status.Unblock);
                        }
                        break;
                }

            }

        }

#endregion



        public void ShowMessages(string Message, string Title, MessageBoxIcon Message_Icon, Action action = null)
        {
            this.Invoke(new Action(() =>
            {
                MessageBox.Show(Message, Title, MessageBoxButtons.OK, Message_Icon);
                if (action != null)
                {
                    action();

                }
            }));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {


            if (Checker_New_Order_Timer_current > 0)
            {
                Checker_New_Order_Timer_current -= 1;

                Order_Checker_lable.Text = Checker_New_Order_Timer_current.ToString() + " " + Program.Language.De[01]; //Seconds To Check For New Order

            }
            else
            {

                Orders_Control.Check_New_Orders();
                Order_Checker_lable.Text = Program.Language.De[03];//"Checking For New Orders"

                this.timer1.Enabled = false;



            }


        }




        private void button9_Click(object sender, EventArgs e)
        {
            WebSite.Web_Main_frm frm = new WebSite.Web_Main_frm();
            frm.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Testtt tt = new Testtt();
            //tt.Special_Headers = Special_Headers;
            //string z = tt.OrderCancel("111", "06");

            //JObject x = new JObject();
            //x.Add("_t", "TOrderCancelReq");
            //x.Add("pcName", Properties.Settings.Default._deviceName);
            //x.Add("cancelReasonCode", "6");
            //x.Add("canceledByMenuDetail", null);
            //x.Add("ReqContentType", 5);

            //Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v7/orders/{"B1LH006R94"}/cancel", Method.POST, null, x.ToString(), Special_Headers));
            //tx.Wait();
            //MessageBox.Show(tx.Result.Content);

            this.Order_Details.Controls.Clear();
            Rider_Control cn = new Rider_Control()
            {
                Width = this.Order_Details.Width -10
            };

            this.Order_Details.Controls.Add(cn);
        }

        private void button2_Click(object sender, EventArgs e)
        {



            //Properties.Settings.Default.Owner_No = "201411070015";
            //Properties.Settings.Default.deviceToken = "BM_PC94890784-6A09-48A7-8FEE-FF4FCEB4C";
            //Properties.Settings.Default.Save();
            //Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"http://localhost:8000/v3/ord/alerts/{Properties.Settings.Default.Owner_No}/{Properties.Settings.Default.deviceToken}", Method.GET, null, null, this.Special_Headers));
            //Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"http://localhost:8000/v7/orders?orderNos=B1JK00LBWN", Method.GET, null, null, this.Special_Headers));

            //tx.Wait();
            //MessageBox.Show(tx.Result.Content);
            Orders_Control.Check_New_Orders();


        }




    }






}


