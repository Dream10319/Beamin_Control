using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

namespace Beamin_Control.WebSite
{
    public partial class Recaptcha_frm : Form
    {
        public string Recaptcha_Response = null;

        ChromiumWebBrowser browser;
        private CallbackObjectForJs _callBackObjectForJs;

        public Recaptcha_frm()
        {
            InitializeComponent();

            _callBackObjectForJs = new CallbackObjectForJs();
            _callBackObjectForJs._MainFrm = this;


            CefSettings cfsettings = new CefSettings();
            cfsettings.UserAgent = Web_Helper._UserAgent;

#if Test_With_Proxy



            cfsettings.CefCommandLineArgs.Add("proxy-server", $"{Program.proxy.Address.Host}:{Program.proxy.Address.Port}");
            cfsettings.CefCommandLineArgs.Add("ignore-certificate-errors");
            //cfsettings.IgnoreCertificateErrors = true;

            //CefSharpSettings.Proxy = new ProxyOptions(Program.proxy.Address.Host, Program.proxy.Address.Port.ToString());


#endif

            if ( Cef.IsInitialized == false )
            {
                //CefSharpSettings.SubprocessExitIfParentProcessClosed = true;
                Cef.Initialize(cfsettings);
            }

            browser = new ChromiumWebBrowser();
            //browser.RegisterResourceHandler 


            //var ctx = RequestContext.Configure()
            //    .WithSharedSettings(Cef.GetGlobalRequestContext())
            //    .WithPreference("webkit.webprefs.minimum_font_size", 24)
                
            //    .Create();
            //browser.RequestContext = ctx;

            browser.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            browser.JavascriptObjectRepository.Register("callbackObj", _callBackObjectForJs, isAsync: true, options: BindingOptions.DefaultBinder);


      
            //browser.RequestContext.Dispose();

            //MessageBox.Show("IN");

            //Cef.Shutdown();
            this.FormClosing += ( ss, ee ) =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //browser.Dispose();

                //if ( Cef.IsShutdown == false )
                //{
                //    MessageBox.Show("Shutdown");
                //    //Cef.ShutdownWithoutChecks ();
                //    Cef.Shutdown ();

                //}
                //browser.RequestContext.Dispose();

                //Cef.ShutdownWithoutChecks();
            };

        }

        //string html = File.ReadAllText(Application.StartupPath + "\\" + "test_02.html");

        private void Recaptcha_frm_Load( object sender, EventArgs e )
        {
            browser.Dock = DockStyle.Fill;

            browser.LoadHtml(RecaptchaHTML, "https://ceo.baemin.com/web/login");

            this.Controls.Add(browser);
        }

        private void button1_Click( object sender, EventArgs e )
        {
            browser.LoadHtml(RecaptchaHTML, "https://ceo.baemin.com/web/login");

        }

        private void button2_Click( object sender, EventArgs e )
        {
            browser.Load("http://icanhazip.com");
        }


        string RecaptchaHTML = @"
<html>
  <head>
    <title>reCAPTCHA Needed Please Solve it</title>

    <script type='text/javascript'>
      var verifyCallback = function(response) {
        callbackObj.showMessage(response); // Return reCAPTCHA Responce To C# 
      };

      var recaptcha_widgetId;
      var onloadCallback = function() {
      
        
        recaptcha_widgetId = grecaptcha.render('recaptcha_main', {
          'sitekey' : '6LcR4MAUAAAAABcRSjkbtOvGGbVRPGm_1tAzFJQM',
          'callback' : verifyCallback,
          'theme' : 'light',
          'type': 'image',
          'tabindex': 0,
          'size': 'normal',
          'badge': 'bottomright'

        });
      };
    </script>
  </head>
  <body>
  
  

    <div>
      <div id='recaptcha_main'></div>

      <form action='javascript:grecaptcha.reset(recaptcha_widgetId);'>
        <input type='submit' value='Refresh'>
      </form>

    </div>

    <script src='https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit'
        async defer>
    </script>
  </body>
</html>

";

    }


    public class CallbackObjectForJs
    {

        public Recaptcha_frm _MainFrm { get; set; }

        public void showMessage( string msg )
        {

            _MainFrm.Recaptcha_Response = msg;
            _MainFrm.DialogResult = DialogResult.OK;

            //_MainFrm.Invoke(new Action(() =>
            //{
            //    MessageBox.Show(msg);

            //}));
        }
    }


}
