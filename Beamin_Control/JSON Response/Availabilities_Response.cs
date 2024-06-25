using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.JSON_Response
{
    #region Availabilities_Check Response
    public class Settings_Response_Data
    {
        public string merchantNo { get; set; }
        public string estimatedDeliveryTimeType { get; set; }
        public string updatedAt { get; set; }
        public string channel { get; set; }
        public object userId { get; set; }
        public bool useAPI { get; set; }
        public bool useDLL { get; set; }
    }
    public class Settings_Response
    {
        public long timestamp { get; set; }
        public string statusCode { get; set; }
        public string statusMessage { get; set; }
        public Settings_Response_Data data { get; set; }
    }

    public class Availabilities_Check_Response
    {
        public string merchantNo { get; set; }
        public bool isTemporarilyClosed { get; set; }
        public string temporaryClosurePeriod { get; set; }

        public string reason { get; set; }
        public string displayReason { get; set; }


        public string message { get; set; }
        public string fullMessage { get; set; }
    }


    #endregion

}
