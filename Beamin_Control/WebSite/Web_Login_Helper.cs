using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Beamin_Control.WebSite
{


    internal class Web_Login_Enc
    {
        RSACryptoServiceProvider RSA_Provider;
        internal Web_Login_Enc( string ceoTag, string ceoValue )
        {

            byte[] modulus = ConvertHexStringToByteArray(ceoTag);
            byte[] Exponent = { 0x01, 0x00, 0x01 };

            RSA_Provider = new RSACryptoServiceProvider();
            RSAParameters RSAKeyInfo = new RSAParameters();
            RSAKeyInfo.Modulus = modulus;
            RSAKeyInfo.Exponent = Exponent;

            RSA_Provider.ImportParameters(RSAKeyInfo);
        }

        private byte[] ConvertHexStringToByteArray( string hexString )
        {
            if ( hexString.Length % 2 != 0 )
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for ( int index = 0; index < data.Length; index++ )
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }


        public string Get_Enc( string Input_TxT )
        {
            if ( RSA_Provider == null )
            {
                return null;
            }
            else
            {

                string text2 = BitConverter.ToString(RSA_Provider.Encrypt(Encoding.UTF8.GetBytes(Input_TxT), false));
                return $"{text2.Replace("-", "").ToLower()}";

                //return Convert.ToBase64String(RSA_Provider.Encrypt(Encoding.UTF8.GetBytes(Input_TxT), false));
            }

        }

    }

    public static class Web_Login_Helper
    {



        public static bool Web_Login( Login_frm frm )
        {

            if ( string.IsNullOrEmpty(frm.username.Text) || string.IsNullOrEmpty(frm.username.Text) )
            {
                return false;
            }
            Cookies_Class.Load_Cookies();

            List<Tuple<string, string>> ss = new List<Tuple<string, string>>();

            ss.Add(new Tuple<string, string>("sec-ch-ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"Google Chrome\";v=\"120\""));
            //ss.Add(new Tuple<string, string>("sec-ch-ua", "\"Google Chrome\";v=\"105\", \"Not)A; Brand\";v=\"8\", \"Chromium\";v=\"105\""));
            //ss.Add(new Tuple<string, string>("sec-ch-ua", "\".Not / A)Brand\";v=\"99\", \"Google Chrome\";v=\"103\", \"Chromium\";v=\"105\""));
            ss.Add(new Tuple<string, string>("sec-ch-ua-mobile", "?0"));
            ss.Add(new Tuple<string, string>("accept", "application/json, text/plain, */*"));
            ss.Add(new Tuple<string, string>("sec-ch-ua-platform", "\"Windows\""));
            ss.Add(new Tuple<string, string>("sec-fetch-site", "same-origin"));
            ss.Add(new Tuple<string, string>("sec-fetch-mode", "cors"));
            ss.Add(new Tuple<string, string>("sec-fetch-dest", "empty"));
            ss.Add(new Tuple<string, string>("referer", "https://biz-member.baemin.com/login?returnUrl=https%3A%2F%2Fceo.baemin.com%2F"));
            ss.Add(new Tuple<string, string>("accept-encoding", "gzip, deflate, br"));
            ss.Add(new Tuple<string, string>("accept-language", "en-US,en;q=0.9"));



            //Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://ceo.baemin.com/login/start?returnUrl=&failedUrl=&__ts={New_Time()}", Method.GET, null, null, ss));
            Task<IRestResponse> tx = Task.Run(() => Web_Helper.Send_Request($"https://biz-member.baemin.com/v1/login/init?__ts={New_Time()}", Method.GET, null, null, ss));

            tx.Wait();
            if ( !string.IsNullOrEmpty(tx.Result.Content) )
            {
                Login_start Start_Response = JsonConvert.DeserializeObject<Login_start>(tx.Result.Content);

                //if ( Start_Response.ceoTag != null && Start_Response.ceoValue != null )
                if (Start_Response.status == "SUCCESS" && Start_Response.data != null && Start_Response.data.tag != null )
                {


                    //Web_Login_Enc Enc = new Web_Login_Enc(Start_Response.ceoTag, Start_Response.ceoValue);
                    Web_Login_Enc Enc = new Web_Login_Enc(Start_Response.data.tag,null);


                    Login_Body L = new Login_Body()
                    {
                        id = frm.username.Text,
                        //password = Rand_Pass(),
                        //addValue1 = Enc.Get_Enc(frm.username.Text),
                        //addValue2 = Enc.Get_Enc(frm.password.Text),

                        pw = Rand_Pass(),
                        value1 = Enc.Get_Enc(frm.username.Text),
                        value2 = Enc.Get_Enc(frm.password.Text),
                        token = ""
                    };

                    //MessageBox.Show(JsonConvert.SerializeObject(L));

                    ss.Add(new Tuple<string, string>("content-type", "application/json"));
                    //ss.Add(new Tuple<string, string>("origin", "https://ceo.baemin.com"));
                    ss.Add(new Tuple<string, string>("origin", "https://biz-member.baemin.com"));


                    if ( Start_Response.data.needRecaptcha == true )
                    {

                        Recaptcha_frm New_Recaptcha = new Recaptcha_frm();

                        frm.Invoke(new Action(() =>
                        {
                            //MessageBox.Show(frm, "need Recaptcha");
                            New_Recaptcha.ShowDialog(frm);
                        }));



                        if ( New_Recaptcha.DialogResult == DialogResult.OK )
                        {
                            L.token = New_Recaptcha.Recaptcha_Response;
                        }
                        else
                        {
                            return false;
                        }


                    }


                    //MessageBox.Show("Returned");

                    //Task<IRestResponse> tx2 = Task.Run(() => Web_Helper.Send_Request($"https://ceo.baemin.com/login/authentication?__ts={New_Time()}", Method.POST, null, JsonConvert.SerializeObject(L), ss));
                    Task<IRestResponse> tx2 = Task.Run(() => Web_Helper.Send_Request($"https://biz-member.baemin.com/v1/login?__ts={New_Time()}", Method.POST, null, JsonConvert.SerializeObject(L), ss));

                    tx2.Wait();

                    authentication auth = JsonConvert.DeserializeObject<authentication>(tx2.Result.Content);
               
                    MessageBox.Show(frm, auth.message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (auth.status == "SUCCESS")
                    {

                        //if (auth.userProfile != null && !string.IsNullOrEmpty(auth.userProfile.username))
                        if (auth.data.sessionId != null && !string.IsNullOrEmpty(auth.data.sessionId))
                        {
                            //MessageBox.Show(auth.userProfile.email);
                            frm.Invoke(new Action(() =>
                            {
                                frm.Dispose();


                            }));


                            Cookies_Class.save_Cookie_02();
                            return true;
                        }

                      

                    }
                    else
                    {
                        frm.Invoke(new Action(() =>
                        {
                            MessageBox.Show(frm, auth.message,"" ,MessageBoxButtons.OK, MessageBoxIcon.Error) ;

                        }));
                    }


                    //MessageBox.Show(tx2.Result.Content);

                }
            }


            return false;


        }


        public static string New_Time()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long ts = (long)((utcNow - epoch).TotalMilliseconds);
            return ts.ToString();
        }

        private static string Rand_Pass()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 60;
            var sb = new StringBuilder();
            Random RNG = new Random();
            for ( var i = 0; i < length; i++ )
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }


    }



    #region Login Response
    public class Login_start
    {
        public string status { get; set; }
        public string message { get; set; }
        public string serverDatetime { get; set; }
        public Data_Login data { get; set; }
    }

    public class Data_Login
    {
        public string tag { get; set; }
        public string value { get; set; }
        public bool needRecaptcha { get; set; }
    }



    public class authentication
    {

        #region Login_Error
        //public long timestamp { get; set; }
        //public string path { get; set; }
        //public string code { get; set; }
        //public string type { get; set; }
        //public string message { get; set; }
        //public List<object> fieldErrors { get; set; }
        ////public Data data { get; set; }
        //public string statusMessage { get; set; }
        //public string statusCode { get; set; }

        public string status { get; set; }
        public string message { get; set; }
        public string serverDatetime { get; set; }
      

        #endregion


        #region Login

        //public UserProfile userProfile { get; set; }
        //public object accessToken { get; set; }
        //public object refreshToken { get; set; }
        //public object sessionCreateDate { get; set; }
        //public bool needCertification { get; set; }
        //public bool needChangePassword { get; set; }
        //public bool needPrivacyUsageReAgree { get; set; }
        //public string param { get; set; }

        public authentication_Data data { get; set; }


        public class authentication_Data
        {
            public string sessionId { get; set; }
            public bool needPasswordChange { get; set; }
            public bool needCheckIdentity { get; set; }
        }

  



        #endregion

    }

    #endregion

    #region Response_Json
    //public class Login_start
    //{
    //    public string signup { get; set; }
    //    public string findaccount { get; set; }
    //    public object id { get; set; }
    //    public long timestamp { get; set; }
    //    public string ceoTag { get; set; }
    //    public string ceoValue { get; set; }
    //    public bool needRecaptcha { get; set; }
    //}






    public class Attributes
    {
        public string shopOwnerNo { get; set; }
        public string authorityCode { get; set; }
        public string agreeAcademy { get; set; }
        public string memNo { get; set; }
        public string memGradeCd { get; set; }
    }
    public class UserProfile
    {
        public string username { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string corporateName { get; set; }
        public Attributes attributes { get; set; }
        public string memberNumber { get; set; }
        public string storeOwnerNumber { get; set; }
        public bool baroSettlement { get; set; }
        public string shopOwnerNumber { get; set; }
        public string memberGrade { get; set; }
        public string authorityCode { get; set; }
        public string loginId { get; set; }
    }

    //public class Data
    //{
    //}

    #endregion


    #region Request_Json

    public class Login_Body
    {
        public string id { get; set; }
        public string pw { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string token { get; set; }
    }

    //public class Login_Body
    //{
    //    public string id { get; set; }
    //    public string password { get; set; }
    //    public string addValue1 { get; set; }
    //    public string addValue2 { get; set; }
    //    public string token { get; set; }
    //}

    #endregion
}
