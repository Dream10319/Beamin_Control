using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beamin_Control.App_Login
{
    public partial class Hardware_Info_Frm : Form
    {

        [SecurityCritical]
        [DllImport("ntdll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int RtlGetVersion(ref OSVERSIONINFOEX versionInfo);
        [StructLayout(LayoutKind.Sequential)]
        internal struct OSVERSIONINFOEX
        {
            // The OSVersionInfoSize field must be set to Marshal.SizeOf(typeof(OSVERSIONINFOEX))
            internal int OSVersionInfoSize;
            internal int MajorVersion;
            internal int MinorVersion;
            internal int BuildNumber;
            internal int PlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string CSDVersion;
            internal ushort ServicePackMajor;
            internal ushort ServicePackMinor;
            internal short SuiteMask;
            internal byte ProductType;
            internal byte Reserved;
        }


        public Hardware_Info_Frm()
        {
            InitializeComponent();
            this.os_lb.Text = Program.Language.De[4001];
            this.deviceName_lb.Text = Program.Language.De[4002];
            this.deviceMacAddress_lb.Text = Program.Language.De[4003];
            this.deviceMotherBoardId_lb.Text = Program.Language.De[4004];
            this.deviceHddSerial_lb.Text = Program.Language.De[4005];
            this.button1.Text = Program.Language.De[4006];

            this.My_PC.Text = Program.Language.De[4007];
            this.Your_PC.Text = Program.Language.De[4008];


        


        }

        private void Hardware_Info_Frm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default._os)
                 || string.IsNullOrEmpty(Properties.Settings.Default._deviceName) || string.IsNullOrEmpty(Properties.Settings.Default._deviceMacAddress)
                 || string.IsNullOrEmpty(Properties.Settings.Default._deviceMotherBoardId) || string.IsNullOrEmpty(Properties.Settings.Default._deviceHddSerial)
           )

            {
                this.My_PC.PerformClick();
            }
            else
            {
                this.os.Text = Properties.Settings.Default._os;
                this.deviceName.Text = Properties.Settings.Default._deviceName;
                this.deviceMacAddress.Text = Properties.Settings.Default._deviceMacAddress;
                this.deviceMotherBoardId.Text = Properties.Settings.Default._deviceMotherBoardId;
                this.deviceHddSerial.Text = Properties.Settings.Default._deviceHddSerial;
            }

        }

        private void My_PC_Click(object sender, EventArgs e)
        {
            //this.os.Text = "Windows 10 (Version 10.0, Build 19042, 64-bit Edition)";
            //this.deviceName.Text = "DESKTOP-QCAKS75";
            //this.deviceMacAddress.Text = "00:0C:29:D4:A3:65";
            //this.deviceMotherBoardId.Text = "DESKTOP-QCAKS75";
            //this.deviceHddSerial.Text = "DE4F-F2A0";


            this.os.Text = "Windows 10 (Version 10.0, Build 19042, 64-bit Edition)";
            this.deviceName.Text = "DESKTOP-QCAKS75";
            this.deviceMacAddress.Text = "00:0C:29:D4:A3:65";
            this.deviceMotherBoardId.Text = "DESKTOP-QCAKS75";
            this.deviceHddSerial.Text = "DE4F-F2A0";
        }

        private void Your_PC_Click(object sender, EventArgs e)
        {
            //this.os.Text = Get_OS_info();
            this.os.Text = "Windows 10 (Version 10.0, Build 19042, 64-bit Edition)";

            this.deviceName.Text = Environment.MachineName;
            this.deviceMacAddress.Text = GetMacAddress();
            this.deviceMotherBoardId.Text = Environment.MachineName;
            this.deviceHddSerial.Text = DeviceHddSerial();
        }



        private string GetMacAddress()
        {
            var ff = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

            //if (ff.Length > 0)
            //{
            string dd = ff[0].GetPhysicalAddress().ToString();

            return string.Join(":", Enumerable.Range(0, 6).Select(i => dd.Substring(i * 2, 2)));



            //}
        }

        private string Get_OS_info()
        {
            var osVersionInfo = new OSVERSIONINFOEX { OSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX)) };
            if (RtlGetVersion(ref osVersionInfo) != 0)
            {
                // TODO: Error handling
            }
            //MessageBox.Show(osVersionInfo.MajorVersion.ToString());

            return string.Format("Windows 10 (Version {0}.{1}, Build {2}, {3}-bit Edition)", osVersionInfo.MajorVersion, osVersionInfo.MinorVersion, osVersionInfo.BuildNumber,
                Environment.Is64BitOperatingSystem ? "64" : "32"
                );

        }

        public string DeviceHddSerial()
        {
            string drive = "C";
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            disk.Get();
            return disk["VolumeSerialNumber"].ToString().Insert(4, "-");


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(this.os.Text)
                        && !string.IsNullOrEmpty(this.deviceName.Text) && !string.IsNullOrEmpty(this.deviceMacAddress.Text)
                       && !string.IsNullOrEmpty(this.deviceMotherBoardId.Text) && !string.IsNullOrEmpty(this.deviceHddSerial.Text)
                )

            {




                Properties.Settings.Default._os = this.os.Text;
                Properties.Settings.Default._deviceName = this.deviceName.Text;
                Properties.Settings.Default._deviceMacAddress = this.deviceMacAddress.Text;
                Properties.Settings.Default._deviceMotherBoardId = this.deviceMotherBoardId.Text;
                Properties.Settings.Default._deviceHddSerial = this.deviceHddSerial.Text;
                Properties.Settings.Default.Save();

                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
