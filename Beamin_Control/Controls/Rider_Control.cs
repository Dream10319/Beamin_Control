using Newtonsoft.Json.Linq;
using RestSharp;
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
            TokenRefresh();
            var client = new RestClient($"https://ceo-united-api.baemin.com");
            var request = new RestRequest($"api/v1/delivery-status/{OrderNo.Text}");
            request.AddHeader("User-Agent", "woowa-order-relay");
            request.AddHeader("Host", "ceo-united-api.baemin.com");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Charset", "UTF-8, *;q=0.8");
            request.AddHeader("Authorization", Properties.Settings.Default.AuthToken);
            request.AddHeader("Connection", "Keep-Alive");
            request.AddHeader("X-Channel", "BM_PC");
            request.AddHeader("X-DeviceId", Properties.Settings.Default.deviceToken);
            request.AddHeader("X-MerchantNo", Properties.Settings.Default.Owner_No);
            request.AddHeader("X-UserAgent", "0.8.2670.0");

            var response = client.ExecuteGetAsync(request);
            var data = JObject.Parse(response.Result.Content);
            if (data["remainDistanceArea"] == null)
                Rider_Location_lb.Text = "";
            else Rider_Location_lb.Text = data["remainDistanceArea"]["distanceToStore"].ToString() + "m 남음";
            label1.Text = data["descriptionTitle"].ToString();
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

        public void TokenRefresh()
        {
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
                pwd = Properties.Settings.Default.Pass,
                typ = "in",
                uid = Properties.Settings.Default.User,
                version = "0.8.2670.0"
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
            request_payload.Add("uid", Properties.Settings.Default.User);
            request_payload.Add("typ", "in");
            request_payload.Add("domain", "bmord");
            request_payload.Add("version", Properties.Settings.Default.CurrentVersion);
            request_payload.Add("os", Properties.Settings.Default._os);
            request_payload.Add("deviceName", Properties.Settings.Default._deviceName);
            request_payload.Add("deviceMacAddress", Properties.Settings.Default._deviceMacAddress);
            request_payload.Add("deviceMotherBoardId", Properties.Settings.Default._deviceMotherBoardId);
            request_payload.Add("deviceHddSerial", Properties.Settings.Default._deviceHddSerial);
            request_payload.Add("pwd", Properties.Settings.Default.Pass);


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
                    if (o["data"].HasValues == true)
                    {
                        Properties.Settings.Default.AuthToken = o["data"]["authToken"].ToString();
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

    }
}
