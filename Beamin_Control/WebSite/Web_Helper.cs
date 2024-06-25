using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Beamin_Control.WebSite
{
    public static class Web_Helper
    {
        //public static CultureInfo Culture = CultureInfo.GetCultureInfo("ko-KR");
        public static CultureInfo Culture = CultureInfo.GetCultureInfo(Program.Language.De[9999]);
        //public static CultureInfo Culture = CultureInfo.CurrentCulture;


        //public  const string _UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36 Edg/105.0.1343.50";
        //public const string _UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36";
        public const string _UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";



        public static async Task<IRestResponse> Send_Request(string url, Method _Method, List<Tuple<string, string>> QueryParameters = null, object Request_Payload = null,
      List<Tuple<string, string>> Special_Headers = null, List<Tuple<string, string>> Multipart_Body = null)
        {

#if Test_With_Proxy || Design_Test

            if (Helper_Class.Is_IP_OK(false ) == false)
            {
                return null;
            }
#endif

#if Design_Test
            if (url.Contains("baemin.com"))
            {
                Uri U = new Uri (url);

                //string test1 = url.Substring(url.IndexOf("baemin.com/")+1 );
                //System.Windows.Forms.MessageBox.Show(url);
                url =  "http://localhost:8000/" + U.PathAndQuery;
                //System.Windows.Forms.MessageBox.Show(url);

            }

#endif
            Cookies_Class.Load_Cookies();


            var P_client = new RestClient(url);
            //P_client.Encoding = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;
            P_client.DefaultParameters.Clear();
            if (Cookies_Class.Cookies != null)
            {
                P_client.CookieContainer = Cookies_Class.Cookies;

            }

            //P_client.AddDefaultHeader("Connection", "keep-alive");

            P_client.ConfigureWebRequest(wr =>
            {
                wr.AutomaticDecompression = DecompressionMethods.None;
                wr.KeepAlive = true;
                //wr.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.5112.102 Safari/537.36";
                wr.UserAgent = _UserAgent;
                //wr.AllowAutoRedirect = true;


                //wr.Headers.Add("method", "GET");
                //wr.Headers.Add("authority", "self.baemin.com");
                //wr.Headers.Add(":scheme", "https");
                //wr.Headers.Add(":path", "/v1/smartmenu/ceo/shops/13874200/menupans/1338355/menu-groups/soldout");

                wr.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                //wr.Connection
            });

#if Test_With_Proxy  || Design_Test
            P_client.Proxy = Program.proxy;
#endif


            //P_client.ConfigureWebRequest = new Action<Action<HttpWebRequest>>()
            var P_request = new RestRequest(_Method);
            //P_request.DefaultRequestHeaders.ConnectionClose = true;

            //P_request.DefaultRequestHeaders.Add("Connection", "keep-alive");








            //P_request.UseDefaultCredentials = true;


            //P_request.
            if (QueryParameters != null)
            {
                //MultipartContent mpContent = new MultipartContent("related", myBoundary);

                foreach (Tuple<string, string> i in QueryParameters)
                {
                    P_request.AddQueryParameter(i.Item1, i.Item2);
                }

            }

            if (Multipart_Body != null)
            {

                foreach (Tuple<string, string> i in Multipart_Body)
                {
                    P_request.AddParameter(i.Item1, i.Item2);
                }

                //P_request.AddFile("images", "E:\\test.png");

                //P_request.AddOrUpdateParameter(,  , ParameterType.)
                P_request.AlwaysMultipartFormData = true;

            }



            if (Request_Payload != null)
            {
                P_request.AddParameter("application/json; charset=utf-8", Request_Payload, ParameterType.RequestBody);

                //P_request.AddXmlBody(Request_Payload);
            }
            //P_request.AddBody()


            //if (Special_Headers != null)
            //{
            //    foreach (Tuple<string, string> x in Special_Headers)
            //    {
            //        P_request.AddHeader(x.Item1, x.Item2);
            //    }
            //}



            //P_request.AddHeader("Connection", "Keep-Alive");
            //P_request.AddHeader("Content-Type", "application/json");
            //P_request.AddHeader("Accept", "application/json");
            //P_request.AddHeader("Accept-Charset", "	UTF-8, *;q=0.8");
            //P_request.AddHeader("User-Agent", "Embarcadero RESTClient/1.0");
            //P_request.AddHeader("Host", "advance-relay.baemin.com");

            if (Special_Headers != null)
            {
                foreach (Tuple<string, string> x in Special_Headers)
                {
                    P_request.AddHeader(x.Item1, x.Item2);
                }
            }


            IRestResponse _result = await Task.Run(() => P_client.ExecuteAsync(P_request));
            return _result;

        }



        public static System.IO.MemoryStream Load_Images(string Image_url)
        {
            WebClient dd = new WebClient();

#if Test_With_Proxy || Design_Test
            dd.Proxy = Program.proxy;
#endif


            return new System.IO.MemoryStream(dd.DownloadData(Image_url));
        }



        public static  Task<byte[] > Load_Images_Test(string Image_url)
        {
            WebClient dd = new WebClient();

#if Test_With_Proxy || Design_Test
            dd.Proxy = Program.proxy;

          
#endif

            return   dd.DownloadDataTaskAsync(Image_url);
          //return  await   new Task <System.IO.MemoryStream>( new Func<System.IO.MemoryStream>(dd.DownloadDataTaskAsync(Image_url).RunSynchronously()) );

            //return dd.DownloadDataAsync(new Uri(Image_url));
            //return new System.IO.MemoryStream(dd.DownloadDataAsync(new Uri(Image_url))   );
        }


   

        public static System.Drawing.Bitmap Load_image(string Image_URL )
        {

            System.Drawing.Bitmap bmp = null;
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Image_URL);
                myRequest.Method = "GET";


#if Test_With_Proxy || Design_Test
                myRequest.Proxy = Program.proxy;
#endif

                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                myResponse.Close();

                //myRequest.Proxy 


            }
            catch { }

            return bmp;

        }

    }

}
