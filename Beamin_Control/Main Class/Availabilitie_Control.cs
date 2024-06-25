using Beamin_Control.JSON_Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.Main_Class
{

    public static class Availabilitie_Control
    {
        public static Form1 Main_Frm;

        #region Availabilitie Control

    

        public  static  bool Availabilities_Check()
        {
            Task<IRestResponse> settings_res = Task.Run(() => Helper_Class.Send_Request($"https://advance-relay.baemin.com/v4/merchant/{Properties.Settings.Default.Owner_No}/settings", Method.GET, null, null, Main_Frm.Special_Headers));
            settings_res.Wait();

            if (!string.IsNullOrEmpty(settings_res.Result.Content))
            {
                Settings_Response rs = JsonConvert.DeserializeObject<Settings_Response>(settings_res.Result.Content, Main_Frm.Serializer_Settings);


                //if (settings_res.Result.StatusCode == HttpStatusCode.OK && rs.se("rspCode").ToString() == "200")
                if (rs.statusCode == "200" && rs.statusMessage == "SUCCESS" && rs.data != null)
                {
                    if (rs.data.merchantNo == Properties.Settings.Default.Owner_No)
                    {
 

                        List<Tuple<string, string>> Checker_Headers = new List<Tuple<string, string>>();

                        Checker_Headers.Add(new Tuple<string, string>("Authorization", Properties.Settings.Default.X_Auth));
                        Checker_Headers.Add(new Tuple<string, string>("User-Agent", "woowa-order-relay"));
                        //Checker_Headers.Add(new Tuple<string, string>("X-Channel", rs.data.channel));
                        Checker_Headers.Add(new Tuple<string, string>("X-Channel", Properties.Settings.Default.X_Channel)); //Fix me Now Please
                        Checker_Headers.Add(new Tuple<string, string>("X-UserAgent", Properties.Settings.Default.CurrentVersion));
                        Checker_Headers.Add(new Tuple<string, string>("X-DeviceId", Properties.Settings.Default.deviceToken));
                        Checker_Headers.Add(new Tuple<string, string>("X-MerchantNo", rs.data.merchantNo));


                        //Properties.Settings.Default.X_Channel = rs.data.channel;
                        //Properties.Settings.Default.Save();

                        Task<IRestResponse> Checker_respose = Task.Run(() => Helper_Class.Send_Request($"https://ceo-united-api.baemin.com/api/v1/merchants/temporary-closure", Method.GET, null, null, Checker_Headers));
                        Checker_respose.Wait();
                        if (!string.IsNullOrEmpty(Checker_respose.Result.Content))
                        {
                            JToken o = Helper_Class.Json_Response(Checker_respose.Result.Content.ToString());
                            if (o["isTemporarilyClosed"] != null)
                            {
                                Availabilitie_Response(Checker_respose.Result.Content);
                                return true;

                            }
                            else if (o["message"] != null && o["fullMessage"] != null)
                            {
                                Main_Frm.ShowMessages(o["fullMessage"].ToString(), o["message"].ToString(), MessageBoxIcon.Error);
                            }

                        }




                    }
                }

            }

            return false;
        }
        private static  void Availabilitie_Response(string Response)
        {
            Availabilities_Check_Response Availabilities_Check_Response = JsonConvert.DeserializeObject<Availabilities_Check_Response>(Response, Main_Frm.Serializer_Settings);


            Main_Frm.Invoke(new Action(() =>
            {

                if (Availabilities_Check_Response.isTemporarilyClosed == true)
                {
                    Main_Frm.Close_btn.Text = Program.Language.De[402]; //"Temporarily Closed"
                    Main_Frm.Close_btn.Tag = (bool)false;
                    Main_Frm.Close_btn.Image = Properties.Resources.Closed;
                    Main_Frm.temporaryBlockedInfo.Text = Availabilities_Check_Response.temporaryClosurePeriod;
                }
                else
                {
                    Main_Frm.Close_btn.Text = Program.Language.De[403]; //"Open"
                    Main_Frm.Close_btn.Tag = (bool)true;
                    Main_Frm.Close_btn.Image = Properties.Resources.Open;
                }

            }));
        }

      
        public enum Availabilities_Status { Block, Unblock }
        public  static  void Set_Availabilities_Status(Button sender, EventArgs e, Availabilities_Status s)
        {
            Main_Frm.Close_btn.Enabled = false;
            Thread th = new Thread(new ParameterizedThreadStart((object f) =>
            {

                List<Tuple<string, string>> Checker_Headers = new List<Tuple<string, string>>();

                Checker_Headers.Add(new Tuple<string, string>("Authorization", Properties.Settings.Default.X_Auth));
                Checker_Headers.Add(new Tuple<string, string>("X-Channel", Properties.Settings.Default.X_Channel));
                Checker_Headers.Add(new Tuple<string, string>("X-UserAgent", Properties.Settings.Default.CurrentVersion));
                Checker_Headers.Add(new Tuple<string, string>("X-DeviceId", Properties.Settings.Default.deviceToken));
                Checker_Headers.Add(new Tuple<string, string>("X-MerchantNo", Properties.Settings.Default.Owner_No));

                Task<IRestResponse> tx;



                JObject Request_Payload = null;
                if (s == Availabilities_Status.Block)
                {
                    ((REJECT_REASON_frm)sender.Parent.Parent).DialogResult = DialogResult.OK;
                    //url = $"https://advance-relay.baemin.com/v4/merchant/{Properties.Settings.Default.Owner_No}/block";



                    Request_Payload = new JObject();
                    Request_Payload.Add("_t", "TTemporaryClosureReq");
                    Request_Payload.Add("temporaryClosureTime", sender.Tag.ToString());
                    Request_Payload.Add("ReqContentType",5);


                    //payload.Add("merchantNo", Properties.Settings.Default.Owner_No);
                    //payload.Add("temporaryBlockTime", sender.Tag.ToString());
                    //Request_Payload = new JObject();
                    //Request_Payload.Add("_t", "TMerchantBlockReq");
                    //Request_Payload.Add("payload", payload);
                    //Request_Payload.Add("ReqContentType", 5);
                    //MessageBox.Show(Request_Payload.ToString());
                    tx = Task.Run(() => Helper_Class.Send_Request($"https://ceo-united-api.baemin.com/api/v1/merchants/temporary-closure", Method.POST, null,
                Request_Payload != null ? Request_Payload.ToString() : null, Checker_Headers));
                    tx.Wait();


                    if (!string.IsNullOrEmpty(tx.Result.Content))
                    {
                        Availabilitie_Response(tx.Result.Content);
                    }


                }
                else if (s == Availabilities_Status.Unblock)
                {
                    //url = $"https://advance-relay.baemin.com/v4/merchant/{Properties.Settings.Default.Owner_No}/unblock";
                    tx = Task.Run(() => Helper_Class.Send_Request($"https://ceo-united-api.baemin.com/api/v1/merchants/temporary-closure", Method.DELETE, null,
                    null, Checker_Headers));

                    tx.Wait();
                    if (tx.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Availabilities_Check();
                    }
                }

                Main_Frm.Invoke(new Action(() =>
                {
                    Main_Frm.Close_btn.Enabled = true;
                }));

                ////MessageBox.Show(tx.Result.Content);
                //if (!string.IsNullOrEmpty(tx.Result.Content))
                //{
                //    var o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                //    if (o.SelectToken("rspCode").ToString() == "200") // SUCCESS
                //    {
                //        //Availabilities_Check();
                //        Availabilities_Check_TH.Start();
                //    }
                //}

            }));
            th.Start();
        }
     
        #endregion


    }
}
