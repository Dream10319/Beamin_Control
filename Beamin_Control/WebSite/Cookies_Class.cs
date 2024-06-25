using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite
{
    public static class Cookies_Class
    {
        static string cookies_file_path = System.Windows.Forms.Application.StartupPath + "\\WEB_Cookies.json";
        public static CookieContainer Cookies = null;

        public class Cookie_Response
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Path { get; set; }
            public string Domain { get; set; }
            public bool Secure { get; set; }
            public DateTime Expires { get; set; }
        }




        public static void save_Cookie_02()
        {
#if Test_With_Proxy || Design_Test
            if( Cookies != null )
            {
                if ( File.Exists(cookies_file_path) == true )
                {
                    File.Delete(cookies_file_path);
                }



                List<Cookie_Response> co = new List<Cookie_Response>();
                foreach ( Cookie c in Cookies.GetCookies(new Uri("https://baemin.com")) )
                {
                    co.Add(new Cookie_Response()
                    {
                        Name = c.Name,
                        Value = c.Value,
                        Path = c.Path,
                        //Domain = c.Domain,
                        Secure = c.Secure,
                        Expires = c.Expires
                    });

                }

                StringWriter wr = new StringWriter();

                using ( JsonWriter jw = new JsonTextWriter(wr) )
                {
                    JsonSerializer sz = new JsonSerializer();
                    sz.Formatting = Formatting.Indented;
                    sz.Serialize(jw, co, typeof(List<Cookie_Response>));
                }



                File.WriteAllText(cookies_file_path, wr.ToString());
            }

#endif
        }

        public static void Load_Cookies()
        {

            if ( Cookies == null )
            {
                Cookies = new CookieContainer();
            }

            if ( File.Exists(cookies_file_path) == true )
            {
                StringReader reader = new StringReader(File.ReadAllText(cookies_file_path));


                List<Cookie_Response> co = new List<Cookie_Response>();

                using ( JsonTextReader jr = new JsonTextReader(reader) )
                {
                    JsonSerializer sz = new JsonSerializer();
                    co = (List<Cookie_Response>)sz.Deserialize(jr, typeof(List<Cookie_Response>));


                    foreach ( Cookie_Response c in co )
                    {
                        Cookies.Add(new Cookie()
                        {
                            Name = c.Name,
                            Value = c.Value,
                            Path = c.Path,
                            //Domain = c.Domain,
                            Domain = "baemin.com",
                            Secure = c.Secure,
                            Expires = c.Expires
                        });
                    }
                }



            }

        }
    }
}
