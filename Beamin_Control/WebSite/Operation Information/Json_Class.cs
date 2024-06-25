using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


//using Newtonsoft.Json.Serialization;

namespace Beamin_Control.WebSite.Operation_Information
{

    public class operation_block_reason
    {
        public List<ShopCode> shopCodes { get; set; }
    }

    public class ShopCode
    {
        public string id { get; set; }
        public string title { get; set; }

        public override string ToString()
        {
            return title;
        }
    }



    //    #region Request
    //    public class Operation_Information_Request
    //    {
    //        public string operationName { get; set; }
    //        //public Variables variables { get; set; }
    //        public dynamic variables { get; set; }
    //        public string query { get; set; }
    //    }

    //    public class Variables
    //    {
    //        public int shopNo { get; set; }
    //        //public Update_Data data { get; set; }
    //        public Data data { get; set; }

    //    }


    //    #region Update Data


    //    public class Update_Variables
    //    {
    //        public int shopNo { get; set; }
    //        public Update_Data data { get; set; }
    //    }

    //    public class Update_Data
    //    {
    //        public List<object> breakTimes { get; set; }
    //        public Update_BusinessPause businessPause { get; set; }
    //        public string closeDayText { get; set; }
    //        public List<object> dayOffs { get; set; }
    //        public List<Update_OperationHour> operationHours { get; set; }
    //        public bool ownOtherShopUpdate { get; set; }
    //        public List<object> temporaryDayOffs { get; set; }
    //    }

    //    public class Update_BusinessPause
    //    {
    //        public string reason { get; set; }
    //    }
    //    public class Update_OperationHour
    //    {
    //        public bool allDay { get; set; }
    //        public string closeHour { get; set; }
    //        public string closeMinute { get; set; }
    //        public string intervalCode { get; set; }
    //        public string openHour { get; set; }
    //        public string openMinute { get; set; }
    //    }


    //    #endregion

    //    #endregion


    //    #region Response
    //    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    //    public class Operation_Information_Response
    //    {
    //        public List<object> errors { get; set; }
    //        public Data data { get; set; }
    //        public object extensions { get; set; }
    //        public bool dataPresent { get; set; }

    //        public string errorType { get; set; }
    //        public string errorMessage { get; set; }

    //    }

    //    public class BaroPay
    //    {
    //        public bool contracted { get; set; }
    //        public bool meetPayForCash { get; set; }
    //        public bool meetPayForCredit { get; set; }
    //        public string orderTakeChannelType { get; set; }
    //        public bool possibleReservationOrder { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class BusinessPause
    //    {//fix me
    //        public string endDate { get; set; }
    //        public string reason { get; set; }
    //        public string startDate { get; set; }
    //        [JsonIgnore]
    //        public string __typename { get; set; }
    //    }

    //    public class Charge
    //    {
    //        public bool geofence { get; set; }
    //        public List<object> regions { get; set; }
    //        public List<object> days { get; set; }
    //        public object holiday { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class ConvenienceInfo
    //    {
    //        public object babySeatYn { get; set; }
    //        public object disabledYn { get; set; }
    //        public object groupYn { get; set; }
    //        public object parking { get; set; }
    //        public object petYn { get; set; }
    //        public object roomYn { get; set; }
    //        public object sedentaryYn { get; set; }
    //        public object valet { get; set; }
    //        public object wifiYn { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class Data
    //    {
    //        public Shop shop { get; set; }
    //        public Shop updateShopOperationInfo { get; set; }


    //        public List<BreakTime> breakTimes { get; set; }
    //        public BusinessPause businessPause { get; set; }


    //        public string closeDayText { get; set; }
    //        public List<DayOff> dayOffs { get; set; }

    //        public List<OperationHour> operationHours { get; set; }



    //        public bool ownOtherShopUpdate { get; set; }
    //        public List<TemporaryDayOff> temporaryDayOffs { get; set; }




    //    }

    //    public class DeliveryFee
    //    {
    //        public List<DeliveryRule> deliveryRules { get; set; }
    //        public Charge charge { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class DeliveryRegion
    //    {
    //        public string deliveryInfo { get; set; }
    //        public string regionType { get; set; }
    //        public List<object> areas { get; set; }
    //        public List<string> s2Tokens { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class DeliveryRule
    //    {
    //        public int sort { get; set; }
    //        public int orderPrice { get; set; }
    //        public int deliveryFee { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class ImageFile
    //    {
    //        public string path { get; set; }
    //        public string name { get; set; }
    //        public string typeCode { get; set; }
    //        public string size { get; set; }
    //        public int sort { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class Location
    //    {
    //        public string address { get; set; }
    //        public string addressDetail { get; set; }
    //        public double latitude { get; set; }
    //        public double longitude { get; set; }
    //        public string zipCode { get; set; }
    //        public string region1Code { get; set; }
    //        public string region2Code { get; set; }
    //        public string region3Code { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class MenuInfo
    //    {
    //        public string foodOrigin { get; set; }
    //        public string menuIntro { get; set; }
    //        public bool useSmartMenu { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class OperationHour
    //    {
    //        public bool allDay { get; set; }
    //        public string closeHour { get; set; }
    //        public string closeMinute { get; set; }
    //        public string intervalCode { get; set; }
    //        public string openHour { get; set; }
    //        public string openMinute { get; set; }


    //        [JsonIgnore]
    //        public string __typename { get; set; }




    //    }

    //    public class BreakTime
    //    {
    //        public string breakEnd { get; set; }
    //        public string breakStart { get; set; }
    //        public string weekDay { get; set; }

    //        [JsonIgnore]
    //        public string __typename { get; set; }
    //    }

    //    public class DayOff // will delete
    //    {
    //        public string day { get; set; }
    //        public string interval { get; set; }

    //        [JsonIgnore]
    //        public string __typename { get; set; }
    //    }
    //    public class TemporaryDayOff
    //    {

    //        public string startDate { get; set; }
    //        public string endDate { get; set; }

    //        [JsonIgnore]
    //        public object seq { get; set; }

    //        [JsonIgnore]
    //        public string __typename { get; set; }
    //    }
    //    public class OperationInfo
    //    {



    //        public string closeDayText { get; set; }
    //        public List<TemporaryDayOff> temporaryDayOffs { get; set; }
    //        public List<DayOff> dayOffs { get; set; }
    //        public List<BreakTime> breakTimes { get; set; }
    //        public List<OperationHour> operationHours { get; set; }
    //        public BusinessPause businessPause { get; set; }

    //        public string __typename { get; set; }

    //        public bool ownOtherShopUpdate { get; set; } //test

    //    }

    //    public class OrderInfo
    //    {
    //        public int minimumOrderPrice { get; set; }
    //        public bool reservationOrder { get; set; }
    //        public TakeOutDiscount takeOutDiscount { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class Owner
    //    {
    //        public BaroPay baroPay { get; set; }
    //        public string __typename { get; set; }
    //    }


    //    public class Shop
    //    {
    //        public int no { get; set; }
    //        public string name { get; set; }
    //        public string serviceType { get; set; }
    //        public string serviceTypeName { get; set; }
    //        public string categoryCode { get; set; }
    //        public string categoryCodeName { get; set; }
    //        public List<object> contents { get; set; }
    //        public ConvenienceInfo convenienceInfo { get; set; }
    //        public List<Telephone> telephones { get; set; }
    //        public Location location { get; set; }
    //        public string status { get; set; }
    //        public bool useBaroPay { get; set; }
    //        public bool useAdService { get; set; }
    //        public bool useFranchiseTelephone { get; set; }
    //        public object intro { get; set; }
    //        public DateTime modified { get; set; }
    //        public List<ImageFile> imageFiles { get; set; }
    //        public MenuInfo menuInfo { get; set; }
    //        public Owner owner { get; set; }
    //        public OperationInfo operationInfo { get; set; }
    //        public OrderInfo orderInfo { get; set; }
    //        public DeliveryFee deliveryFee { get; set; }
    //        public DeliveryRegion deliveryRegion { get; set; }
    //        public ShopStopReason shopStopReason { get; set; }
    //        public object shopRiderNotice { get; set; }
    //        public bool operationStatus { get; set; }
    //        public object franchise { get; set; }
    //        public string shopPath { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class ShopStopReason
    //    {
    //        public object startDate { get; set; }
    //        public object endDate { get; set; }
    //        public object reasonCode { get; set; }
    //        public object reasonName { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class TakeOutDiscount
    //    {
    //        public int discountFee { get; set; }
    //        public int discountRate { get; set; }
    //        public string discountType { get; set; }
    //        public bool useMinimumOrderAmountDiscount { get; set; }
    //        public string __typename { get; set; }
    //    }

    //    public class Telephone
    //    {
    //        public string telephone { get; set; }
    //        public int telephoneId { get; set; }
    //        public string telephoneType { get; set; }
    //        public string virtualTelephone { get; set; }
    //        public string __typename { get; set; }
    //    }


    //    #endregion
}
