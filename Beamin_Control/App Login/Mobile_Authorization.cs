using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control
{
    public partial class Mobile_Authorization : Form
    {
        public string memberNo;
        public string tempDeviceToken;
        public string merchantNo;
        //public string displayCallcenterNumber;

        List<Tuple<string, string>> Special_Headers = new List<Tuple<string, string>>();

        public Mobile_Authorization()
        {
            InitializeComponent();

            this.Text = Program.Language.De[2400];
            this.label1.Text = Program.Language.De[2401];
            this.send_code.Text = Program.Language.De[2402];
            this.label2.Text = Program.Language.De[2403];
            this.Login_btn.Text = Program.Language.De[2404];

        }

        private void Mobile_Authorization_Load(object sender, EventArgs e)
        {
            //Special_Headers.Add(new Tuple<string, string>("X-Auth", X_Auth));
            //Special_Headers.Add(new Tuple<string, string>("X-Refresh", X_Refresh));
            Special_Headers.Add(new Tuple<string, string>("X-MchN", merchantNo));
            Special_Headers.Add(new Tuple<string, string>("X-DeviceToken", tempDeviceToken));
            Special_Headers.Add(new Tuple<string, string>("X-UserAgent", Properties.Settings.Default.CurrentVersion));
            Special_Headers.Add(new Tuple<string, string>("X-Api-Secret-Version", "woowa-sec-v1"));
            Special_Headers.Add(new Tuple<string, string>("X-Api-Secret", ""));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobile.Text))
            {
                send_code.Enabled = false;
                Thread th = new Thread(new ParameterizedThreadStart((object f) =>
                {



           


                    JObject x = new JObject();

                    x.Add("_t", "TCertSendMessageReq");
                    x.Add("mobileNo", this.mobile.Text);
                    x.Add("memberNo", memberNo);
                    x.Add("ReqContentType",5);

                    Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v1/cert/send-message", Method.POST, null, x.ToString(), Special_Headers));

                    tx.Wait();





                    this.Invoke(new Action(() =>
                    {
                        send_code.Enabled = true;

                        if (!string.IsNullOrEmpty(tx.Result.Content))
                        {
                            var o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                            if (o.SelectToken("rspCode").ToString() == "200") // SUCCESS
                            {
                                Login_btn.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show(this, o["rspMsg"].ToString(), o["rspCode"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }




                    }));




                }));
                th.Start();
            }
        }


        private void Login_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobile.Text) && !string.IsNullOrEmpty(auth_code.Text))
            {
                Login_btn.Enabled = false;
                Thread th = new Thread(new ParameterizedThreadStart((object f) =>
                {

                    //List<Tuple<string, string>> Special_Headers = new List<Tuple<string, string>>();

                    //Special_Headers.Add(new Tuple<string, string>("X-MchN", merchantNo));
                    //Special_Headers.Add(new Tuple<string, string>("X-DeviceToken", tempDeviceToken));
                    //Special_Headers.Add(new Tuple<string, string>("X-UserAgent", Properties.Settings.Default.CurrentVersion )  );

                


                    JObject x = new JObject();

                    x.Add("_t", "TCertCheckReq");
                    x.Add("mobileNo", mobile.Text);
                    x.Add("memberNo", memberNo);
                    x.Add("certNo", auth_code.Text);
                    x.Add("ReqContentType",5);

                    Task<IRestResponse> tx = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v1/cert/check", Method.POST, null, x.ToString(), Special_Headers));

                    tx.Wait();





                    this.Invoke(new Action(() =>
                    {

                        var o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                        if (o.SelectToken("rspCode").ToString() == "200") // SUCCESS
                        {

                            Task<IRestResponse> tx_Get_Devices = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v3/device/{merchantNo}", Method.GET, null, null, Special_Headers));

                            tx_Get_Devices.Wait();
                            var response_02 = Helper_Class.Json_Response(tx_Get_Devices.Result.Content.ToString());
                            if (response_02.SelectToken("rspCode").ToString() == "200")
                            {




                                App_Login.Delete_Devices frm = new App_Login.Delete_Devices();

                                foreach (JToken or in response_02["data"])
                                {


                                    App_Login.Device_Tag Device = new App_Login.Device_Tag()
                                    {
                                        deviceNo = or["deviceNo"].ToString(),
                                        deviceToken = or["token"].ToString(),
                                        merchantNo = or["merchantNo"].ToString()

                                    };

                                    ListViewItem it = new ListViewItem()
                                    {
                                        Checked = false,
                                        Text = or["deviceName"].ToString(),
                                        Tag = Device
                                    };

                                    it.SubItems.Add(or["deviceMacAddress"].ToString());
                                    it.SubItems.Add(or["channel"].ToString());

                                    frm.listView1.Items.Add(it);



                                }


                                if (frm.ShowDialog(this) == DialogResult.OK)
                                {
                                    foreach (ListViewItem item in frm.listView1.Items)
                                    {
                                        if (item.Checked == true)
                                        {
                                            JObject delete_request = new JObject();

                                            delete_request.Add("_t", "TDeviceDeleteReq");
                                            delete_request.Add("deviceNo", ((App_Login.Device_Tag)item.Tag).deviceNo ) ;
                                            delete_request.Add("deviceToken", ((App_Login.Device_Tag)item.Tag).deviceToken)  ;
                                            delete_request.Add("merchantNo", ((App_Login.Device_Tag)item.Tag).merchantNo ) ;
                                            delete_request.Add("ReqContentType",5);

                                            Task<IRestResponse> Delete_Devices = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v3/device/delete", Method.POST, null, delete_request.ToString(), Special_Headers));

                                            Delete_Devices.Wait();
                                        }
                                    }
                                    this.DialogResult = DialogResult.Yes;

                                }





                                //((Login_frm)this.Owner).button1.PerformClick();
                                //this.Dispose();
                            }



                        }
                        else
                        {
                            MessageBox.Show(this, o["rspMsg"].ToString(), o["rspCode"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        Login_btn.Enabled = true;

                    }));




                }));
                th.Start();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Login_btn.Enabled = true;
        }
    }
}
