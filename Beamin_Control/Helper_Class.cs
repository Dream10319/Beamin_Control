using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beamin_Control
{
    public static class Helper_Class
    {

        public static JToken Json_Response(string Containt)
        {
            StringReader reader = new StringReader(Containt);
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer Deserializer = new JsonSerializer();
                return (JToken)Deserializer.Deserialize<JToken>(jsonReader);
            }
        }


#if Test_With_Proxy || Design_Test




        public static bool Is_IP_OK(bool show_message = true)
        {
            Task<IRestResponse> tx_test = Task.Run(() => Helper_Class.Send_Request("http://icanhazip.com/", Method.GET));
            tx_test.Wait();

            if (tx_test.Result.Content.Trim() == Program.Testing_IP)
            {
                if (show_message == true)
                {
                    System.Windows.Forms.MessageBox.Show(tx_test.Result.Content.Trim(), "IP");

                }

                return true;
            }
            System.Windows.Forms.MessageBox.Show("Not Same IP", "IP");

            return false;
        }

#endif

        //static int X_ReqSeq=0;

        public static async Task<IRestResponse> Send_Request(string url, Method _Method, List<Tuple<string, string>> QueryParameters = null, string Request_Payload = null,
            List<Tuple<string, string>> Special_Headers = null)
        {

#if Design_Test
            //testing-server.sytes.net

            url = url.Replace("https://advance-relay.baemin.com/", "http://localhost/");
            //url = url.Replace("https://advance-relay.baemin.com/", "http://testing-server.sytes.net:567/");

            if (url.Contains("https://ceo-united-api.baemin.com/"))
            {
                url = url.Replace("https://ceo-united-api.baemin.com/", "http://localhost/");
                //url = url.Replace("https://ceo-united-api.baemin.com/", "http://testing-server.sytes.net:567/");

            }
#endif

            //System.Windows.Forms.MessageBox.Show(url);
            //return null;
            var P_client = new RestClient(url);
            ////P_client.Encoding  = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;
            //P_client.DefaultParameters.Clear();

            //P_client.AddDefaultHeader("Connection", "keep-alive");

            P_client.ConfigureWebRequest(wr =>
            {
                wr.AutomaticDecompression = DecompressionMethods.None;
                wr.KeepAlive = true;
                //wr.AllowAutoRedirect = true;
                wr.UserAgent = "woowa-order-relay";
                //wr.Connection
            });


            
#if Test_With_Proxy || Design_Test
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
                foreach (Tuple<string, string> i in QueryParameters)
                {
                    P_request.AddQueryParameter(i.Item1, i.Item2);
                }
            }

            if (Request_Payload != null)
            {
                P_request.AddJsonBody(Request_Payload);
            }


            //if (Special_Headers != null)
            //{
            //    foreach (Tuple<string, string> x in Special_Headers)
            //    {
            //        P_request.AddHeader(x.Item1, x.Item2);
            //    }
            //}

            //P_request.AddHeader("Connection", "Keep-Alive");
            //P_request.AddHeader("Content-Type", "application/json");
            P_request.AddHeader("Accept", "application/json");
            //P_request.AddHeader("Accept-Charset", "UTF-8, *;q=0.8");
            P_request.AddParameter("Connection", "Keep-Alive", ParameterType.HttpHeader);
            P_request.AddParameter("Accept-Charset", "UTF-8, *;q=0.8", ParameterType.HttpHeader);



            //P_request.AddHeader("User-Agent", "woowa-order-relay");
            //P_request.AddHeader("User-Agent", "Embarcadero RESTClient/1.0");
            //P_request.AddHeader("Host", "advance-relay.baemin.com");

            if (Special_Headers != null)
            {
                //X_ReqSeq += 1;
                foreach (Tuple<string, string> x in Special_Headers)
                {
                    if (x.Item1 == "X-Api-Secret")
                    {
                        P_request.AddHeader(x.Item1, X_Api_Secret_Helper.Generate_X_Api_Secret());
                        P_request.AddHeader("X-ReqSeq", X_Api_Secret_Helper.X_ReqSeq.ToString());


                    }
                    else
                    {
                        P_request.AddHeader(x.Item1, x.Item2);

                    }
                }

            }


            IRestResponse _result = await Task.Run(() => P_client.ExecuteAsync(P_request));


            return _result;

        }

        //private static string Rand_Pass()
        //{
        //    const string src = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    int length = 727;
        //    var sb = new StringBuilder();
        //    Random RNG = new Random();
        //    for (var i = 0; i < length; i++)
        //    {
        //        var c = src[RNG.Next(0, src.Length)];
        //        sb.Append(c);
        //    }
        //    return sb.ToString();
        //}


        //public static string Rand_X_Api_Secret()
        //{
        //    List<string> str = new List<string>();
        //    str.Add("GNiMGI0MTAxYWZlN2M4OTYzYzc3NWUyYmZmZGQ5ZmM5NzY2NTBkOGRlZmZjYjM3MmQ4N2FiYmQyMmZjYWRiZDcyNGEwZmQ2YzhhOGY0NzU0YTVhMzgxNGE0OWMzZGMxNTdiYWY1Mzc1N2Y0OTUyZTIzMTFjY2VmOWE1ZDMxMiQkMTc3MDk3MyQkZEVYbkZvdzBJRzZMQmdDbzhLSXpEQ3ZtaWhPUThkSHk4UTF2RTZ5VkRFVTdmRHpnc1k2em9XQ1BYOG1Ga3k2dlljUHBXNmp2Z2tZNjFzT29tYjR3SGJoVUhWdExLU1hEM2tnT291QTMwRmtQeHpEUTdseFVCSTF4NUloTkducHUkJEZlZkFGa0ZOelJzRHNVUnVzdWRCdk41bGJyRlJCVjZnUXd2VmxqYjVpWnIzWFFTbWV3aW9PUlFWbmJrSW9XbUh4MGRCTnJiWHNrWnBJNlg4RW5GRThmNzhSRzYxWUVvUW1JUkt5ZksxT1RrN1dKbFNOTXZwc09HaDFWck5IdTEzJCRWd3JWNmExVmVuMWIwSWN5cFVWTFdOYWRGamNUcEdUUk9YekRyQnFpQ0dyeGZ5eUtUVFVLZWNXNjdrZFFDVkZacTI1YXJlc3hNN0VHSGp4ZUViaklOamlvSndHWU9mRE1lRUVuTXhETDBkZHI1Y1VSd3gzRG9Nc3pUZlVtT01kRiQkMTI5OTkyNzkwNSQkMTM2JCQzN");
        //    //str.Add("GU1NDRlYThiNDYyNWEwM2IzY2I4YjM0MTQ5ZmZkOTlmZTFjZWFmNzhiNzU1ZTk3OTk4YTEwMGIwMmFiNWY2ZTMzYjlhNTA1YzY1YTk0MWRiODQ5MzVmNDk5NTc5NWZiZTE4OGZlNzE3YTQ3MTYyNmJhNzRmNmRmNzBkZWE0YyQkMjM4MTEzMSQkMGN1YWdTWEhzb2lPcGJtcVdWYjU0WkNGYVZHbHB5bHdiVmlFaXoyN2s1RFRMVWt1RlU4SGx0VXZERTNHTjJZRUVWajhSaWpWS1FFTkR6RWJiekEyVVVkTVM0dUJzS3pqQnd3Q1p4bkhPbjhzYXFFdHE0SVNrb0x6b1dhQzZPTGokJGxPdTFXU1pIR05wNmhqRmtBRHJEUnBEQUJrdEJmMTNHeWdSZkM0d2psV1E2WlZIT3l1Y1cySzcxdjdVNlkwSUZmNGtkam9ldm9QSmc2TU1tTjd4aEhhUUxwS1duNnp2ODNSWlQzQm9RV2NqMmRpN25LV1p4Z0syaldUdnMxTUJqJCQ3NTY0dnB4dWdoYTNJeW1yWmt2TUYybm9pVjRKUjF1WkFCbUtWM1NUbnpVTG1YeGFueEVRajNuUFNPaHB0RXpmak9GR1E4MVpGNXpTOHBvSndjN0JBUVp3RTF6UzdCdVZnclg0d0d4T1BrWlQ2UVFKb2JLeGRRc0I3aG44U0cxZSQkMTI5OTkyODg4MiQkMTQyJCRhO");
        //    //str.Add("DJlODBmZTM5NzU0OTdjZjk1NTc5ZWU1MjQwZWQ3NDQ2ZjcwYmI4OTU3YTI4NTg5MTc2MjIxMzFkYTU1MzIzYWNkN2ZmMDcyM2JhMDdkNzRhOTEyYTRiZTE5MWJmNDEyZDg3NWM3ZTc3Y2Q4ZmM4MjAxMTMwZGY3NzA4NDc4ZCQkMjUwNDE4MSQkU3BpRGRqOHB3T0wyUERheXhMcFNsSUphZkZTOGtTTFNtRklBc2ZOQ1hncXN1Um81TTByVjRxMWtZWGYxUWgwNFpNWXhuZ0h3SE1oTmplNk52QkppM3E1S3pNMDVTUDMyblRoNmVoOHN1TGJIWnFPb1ZLZTJHSVJQS2VDSVpTblAkJFIzSVlUeFM3UThiYmZybjhJcWNNRjZCeXY2MTJvNlVPdVZWVHpXM0JBaGNsdjFIR3dOWTVEd3hiQWpsYTdCZlN5YUlCNXRkU2swd2FjZWd4R1dPTUs3ckdGb3B4U1N3MkxCb3RnMWdtOEhYejZ4dkRvaDZjbDNadm5zajFGTEIxJCRkcTNUaUs0dXE3b0dkSnQyNzFWbjh5cUNad1hUdHpzclVteUtDeXo1RWhBcllaRUwwcFhnQVJ0NFJEdE80U0tsdmN3SkZxZ2JxWjNYUFJIY2JKVG9nejFZTXlqaDhYUzVrZ1RVeXNqbEhrVWNpekhSWjM4ZzNoVUpVRzR0Y0N0VCQkMTI5OTkyODYzNSQkMTQzJCRhN");
        //    //str.Add("jJjNDIxNjBiMGY4ZjIyMjM5Mjg4OTRkNzczNTE2MGZmYWRmNTdmYTM2YWJmMTVkZTA5ZGUxMGMyOTU1NzdlOWYxNjM3YjUyY2RiYWFkYmY3ZTZiYmYzMGY0NTAzOWZhZDM5Y2FmM2YyM2E5MmUyZmJkN2U4YWNkMjU3Yzc4MyQkNjYxNTIzJCR1SkF6akpXVmhpbGVTN0lRdmdOTUF0d0Z6Y0VQaTZ2ZDA1T2ZDWGZVWFNRRHpLVHhvNHNJZ3lMcmJWemFORXdLYU9PcFpYY2xKSXFla1hMR2g4Q29MSHoyNm04a0tIU1p6ektMVElxZzdiSEEwNHU3SUlVcHVtSVdnQmhwcEkzUSQkT2JRa3pSWERLejJPcU5NR0xHUU9HMm5QbFRjVjBlRUdpdmYwbzVxY3VqTVFxZTZjUXdTYkt2S2Nad1YyQjdBNnE0R21tY1RGeGRiNGdycERxRDUzVmNaYWxFMDZtU05FYXkwejBYUkZ3bUt1YXNGWVpaVkx5aW5TaWpsYW9KWHAkJGtMd2RSSTh0aHl5elNFdkpRWVZuOHZyTzhkZnVWSUFpWGNTaHJVVlJSQ0dWOER2STRpVGtkZWQzdkg3Nk5FdTg3aGI3NEVGYkxGUjZaRkRTTkc4THNJa0lBUjdkcTBIRFQ4ZDRGTnQzNUtvSFlRcHZaTGxsR2ZnOFhma2xoV3RIJCQxMjk5OTMwMzUMyQkMTQzJCRmY");
        //    //str.Add("zdmMTc3Njk1ZjUwMGRlYWQwMTM0MmY0OGQ1NzAzMjFmNDhmOWZlNWVmNTljMzQ0MzNkY2VjMmEzMzY5ZDNlMzEwZGEyZDM1YTJiZDJkNzUzYWFkMWI4ZGZjNGY4OGRiMzJlYzBlMDFkN2MyNDMzYjg0MTAzMDY3ZDA4ZTczNSQkMzE3MzI5NyQkeFJ4V2pnbG5ZMFR6MGFVaThyVGptNXg2RzFBZE1jWFZsa3V6elBBQXNjTmsyQ1hQdjh2WDg4ZW9QWjJYTzA0R3cxcUFsbmdkU3lYUlJadmVGMEJRQmJyNUZ0NUJ2dVJGSTF3bks0ZW1WM0UxSEl6cmIwSnRscWpiVFhEeVRxVWokJHRiZUx4UUhrU2dSMWJCWlU1dDVKU2pzMTZ6cHQ1ZnVkREpNcTBvcDZ5RmRpaGRQTjBlb0NJQUVOVzdHbGZxdlFXc1YyREtVZmVlTTU3a2V2Ukg1RklCSnpEQmNDZWJ5MFhiblBDdlRJSWdtbVhmUFQ4TU5oMlV3d215WU1QVllaJCRiYm1kZkZYdGtRVnYwSGdnYW1xUmIzYWhMWUJxcGJrR2ZkSU5iQXp1U0JPeUpsYXhqMGhRNEZyVGJjaTQzTk5TS0FxZGhVa1lPMGtXNEx2amRWQkZQRzdpWHlQVlVkQ0dQRkR6SGtqQW5GT0lZdGJFdDV4RFhrNnR2UmhMZkNkaiQkMTI5OTkzMjAzMyQkMTM3JCRlY");
        //    //str.Add("zIwOTQzM2QyMzdlYjQ2YzlmNGMzNDdmYjYzNzE1YTlhOTk2NTE4MGEwYTk3YWQwN2ExNDYxYjUxMzg0MzMzOWI2MmU0NmRjNjgxYTU1MzAwMGU2ZTE1MGZmMDFiODJiYzQyZjFiOGRiM2JlZmZmNjJkYWUxNDBjYWRjMTUyYyQkODIzMDQ3JCRjTW5NWG5IcmdCZm1yVG44b3lCU25rcjdMeGljaTJRU3hQbGxURVhBVVFQQ3p5WFZxQmRiRVMxb1drV2tVbGRUQlU1QXduZnJkejhzYmpTVUdha05SN2MwU1NrUHhUNFdpRW54M013amxEVkw4SEFMQTg4RlhwdUs4VU5xTWMzUyQkNlYwbHZXTnpJRmpoTzVQcmZrNTZHOEFEZEFMckVVdnFJb21CVkNjc2swU09KRkp3Sm1EQ0J6TjBRbTRRNHVaaVZFdVdRRWxIV3NTUGttbDFONlg0Sm9ZT0M0bmNUdm1XSW5YcHN5Y1czV3pXWDd0NGR1ckFUMFpwTmFESVlsVkMkJHJPYzhWaTZsbDVMNjdZODRVdjg4SFdkZnZ1YU14NnF4aXR3QlZWSkZ0R2ZqN3J1VDBCa1p1NHRDVFFsR0JEY1FFbHUydklEZ2t5a2tvdnQ0TEdnWU5GTEpsTVVwU1pZMThFTUhCV3J2RUJ5bHhyVEN0aFBaM2UwajdqWlJLRWxpJCQxMzAwMjA5NTMNSQkMTQzJCRlM");
        //    //str.Add("");
        //    //str.Add("");

        //    Random RND = new Random();

        //    return str[RND.Next(0, str.Count)];

        //}



    }


}
