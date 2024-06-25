using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

//using System.Runtime.InteropServices.RuntimeInformation;
namespace Beamin_Control
{
    public static class Computer_Info_Helper
    {

        private static string GetDefaultInterface()
        {

            //string socketaddr;
            //using (var s = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            //{
            //    try
            //    {
            //        s.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0));
            //        s.Connect("www.google.com", 0);

            //        var ipaddr = s.LocalEndPoint as System.Net.IPEndPoint;
            //        socketaddr = ipaddr.Address.ToString();

            //    }
            //    catch { return null; }


            //}

            var interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (var intf in interfaces)
            {
                if (intf.OperationalStatus != OperationalStatus.Up)
                {
                    continue;
                }
                if (intf.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }

                var properties = intf.GetIPProperties();
                if (properties == null)
                {
                    continue;
                }

                var gateways = properties.GatewayAddresses;
                if ((gateways == null) || (gateways.Count == 0))
                {
                    continue;
                }
                var addresses = properties.UnicastAddresses;
                if ((addresses == null) || (addresses.Count == 0))
                {
                    continue;
                }

                //return intf;
                foreach (var address in addresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                    {
                        continue;
                    }
                    if (address.IsTransient)
                    {
                        continue;
                    }

                    //if (address.Address.ToString() == socketaddr)
                    //{
                    //return gateways.FirstOrDefault<GatewayIPAddressInformation>().Address.ToString();
                    return intf.Name;
                    //}
                }



                //return addresses.FirstOrDefault<UnicastIPAddressInformation >().Address.ToString();
            }
            return null;

        }

        public static string DeviceMacAddress(){
            string ad_name = GetDefaultInterface();
 
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {

                if (((string)item["NetConnectionId"]) == ad_name)
                {
                    return item["MacAddress"].ToString();
                   
                }
            }

            return null;
        }



        public static string DeviceHddSerial()
        {
            string drive = "C";
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            disk.Get();
            return  disk["VolumeSerialNumber"].ToString().Insert(4,"-");

           
        }

    
    }
}
