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

namespace Beamin_Control.WebSite
{
    public partial class Store_Management : Form
    {
        public Store_Management()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Thread th = new Thread(new ParameterizedThreadStart(( object f ) =>
            {

                WebSite.Cookies_Class.Load_Cookies();

                //SendRequest();


                //Task<IRestResponse> tx_test = Task.Run(() => Helper_Class.Send_Request("http://icanhazip.com/", Method.GET));
                //tx_test.Wait();



                //MessageBox.Show(tx_test.Result.Content);
                //if (!string.IsNullOrEmpty(tx_test.Result.Content))
                //{

                List<Tuple<string, string>> ss = new List<Tuple<string, string>>();

                //ss.Add(new Tuple<string, string>(":method", "GET"));
                //ss.Add(new Tuple<string, string>(":authority", "ceo.baemin.com"));
                //ss.Add(new Tuple<string, string>(":scheme", "https"));
                //ss.Add(new Tuple<string, string>(":path", "/v1/session/profile?__ts=1661404751174"));



                ss.Add(new Tuple<string, string>("sec-ch-ua", "\"Chromium\";v=\"104\""));

                ss.Add(new Tuple<string, string>("accept", "application/json, text/plain, */*"));


                ss.Add(new Tuple<string, string>("sec-ch-ua-mobile", "?0"));

                //ss.Add(new Tuple<string, string>("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36"));
                ss.Add(new Tuple<string, string>("sec-ch-ua-platform", "\"Windows\""));
                ss.Add(new Tuple<string, string>("accept-language", "en-US,en;q=0.9"));
                ss.Add(new Tuple<string, string>("sec-fetch-site", "same-origin"));
                ss.Add(new Tuple<string, string>("sec-fetch-mode", "cors"));
                ss.Add(new Tuple<string, string>("sec-fetch-dest", "empty"));
                ss.Add(new Tuple<string, string>("referer", "https://ceo.baemin.com/"));
                ss.Add(new Tuple<string, string>("accept-encoding", "gzip, deflate, br"));


                //request_payload.Add("pwd", this.password.Text);
                //request_payload.Add("ReqContentType", 5);
                //-------------




                Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://ceo.baemin.com/v1/session/profile?__ts={GetUnixTimstamp().ToString()}", Method.GET, null, null, ss));

                tx.Wait();


                //MessageBox.Show(tx.Result.Content);
                if ( !string.IsNullOrEmpty(tx.Result.Content) )
                {


                    //var o = Helper_Class.Json_Response(tx.Result.Content.ToString());
                    this.Invoke(new Action(() =>
                    {
                        this.textBox1.Text = tx.Result.Content.ToString();

                    }));
                }


                //}
                //else
                //{
                //    this.Invoke(new Action(() => {

                //        MessageBox.Show(this, "Not Same IP","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }));

                //}


                if ( !this.IsDisposed )
                {
                    this.Invoke(new Action(() =>
                    {

                        this.button1.Enabled = true;

                    }));
                }

            }));
            th.Start();
        }

        public static long GetUnixTimstamp( DateTime date )
        {
            DateTime zero = new DateTime(1970, 1, 1);
            TimeSpan span = date.Subtract(zero);

            return (long)span.TotalMilliseconds;
        }

        public static long GetUnixTimstamp()
        {
            return GetUnixTimstamp(DateTime.UtcNow);

        }
        private void button2_Click( object sender, EventArgs e )
        {
            //MessageBox.Show(DateTime.Now.ToUniversalTime().);
            Console.WriteLine(GetUnixTimstamp());
        }
    }
}
