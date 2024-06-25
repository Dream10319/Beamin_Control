using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite.Other_Response.Shop_Response
{



    #region Shops_Response old


    //    public class MenupanList
    //    {
    //        public lon menupanId { get; set; }
    //        public bool activated { get; set; }
    //        public string menupanType { get; set; }
    //        public string menupanTypeCode { get; set; }
    //        public string menupanTypeDescription { get; set; }
    //    }

    //    public class OperationHour2
    //    {
    //        public string dayType { get; set; }
    //        public string startTime { get; set; }
    //        public string endTime { get; set; }
    //    }

    //    public class Shop_Details
    //    {
    //       public long shopId { get; set; }
    //        public object franchiseId { get; set; }
    //        public object franchiseName { get; set; }
    //        public string shopName { get; set; }
    //        public string serviceType { get; set; }
    //        public List<string> categories { get; set; }
    //        public List<MenupanList> menupanList { get; set; }
    //        public bool menuBatchManageYn { get; set; }
    //        public List<OperationHour2> operationHours { get; set; }
    //        public object managementType { get; set; }
    //        public object depositCup { get; set; }
    //    }

    //    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //    public class BusinessPause
    //    {
    //        public string startDate { get; set; }
    //        public string endDate { get; set; }
    //        public string reason { get; set; }
    //    }

    //    public class Category
    //    {
    //        public string code { get; set; }
    //        public string text { get; set; }
    //    }

    //    public class Datum
    //    {
    //        [JsonProperty]
    //       public long shopNumber { get; set; }
    //        [JsonProperty]
    //        public string name { get; set; }
    //        [JsonProperty]
    //        public List<string> serviceTypes { get; set; }
    //        [JsonProperty]
    //        public List<Category> categories { get; set; }
    //        [JsonProperty]
    //        public object address { get; set; }
    //        [JsonProperty]
    //        public OperationHour operationHour { get; set; }
    //        [JsonProperty]
    //        public BusinessPause businessPause { get; set; }
    //        [JsonProperty]
    //        public bool useAdService { get; set; }
    //        [JsonProperty]
    //        public bool useSmartOrder { get; set; }
    //        [JsonProperty]
    //        public string status { get; set; }
    //        [JsonProperty]
    //        public object shopStopReason { get; set; }

    //        //[JsonIgnore, JsonProperty(Required = Required.Default)]
    //        public Shop_Details _Shop_Details = null;


    //        public override string ToString()
    //        {
    //#if !Design_Test
    //            return $"{name} | {categories[0].text} | {shopNumber}";
    //#else 
    //            return $" {shopNumber}";

    //#endif
    //        }
    //    }

    //    public class OperationHour
    //    {
    //        public string openTime { get; set; }
    //        public string closeTime { get; set; }
    //        public bool allDay { get; set; }


    //    }

    //    public class Shops_Response
    //    {
    //        public long timestamp { get; set; }
    //        public string statusCode { get; set; }
    //        public string statusMessage { get; set; }
    //        public List<Datum> data { get; set; }


    //        //public long timestamp { get; set; }
    //        public string path { get; set; }
    //        public string code { get; set; }
    //        public string type { get; set; }
    //        public string message { get; set; }
    //        public List<object> fieldErrors { get; set; }
    //        //    public Data data { get; set; }
    //        //    public string statusMessage { get; set; }
    //        //public string statusCode { get; set; }

    //    }


    #endregion


    #region Shops_Response 2024


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BusinessPause
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string reason { get; set; }
    }

    public class Category2
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    public class Datum
    {
       public long shopNumber { get; set; }
        public string name { get; set; }
        public List<string> serviceTypes { get; set; }
        public List<Category2> categories { get; set; }
        public object address { get; set; }
        public OperationHour2 operationHour { get; set; }
        public BusinessPause businessPause { get; set; }
        public bool useAdService { get; set; }
        public bool useSmartOrder { get; set; }
        public string status { get; set; }
        public object shopStopReason { get; set; }


        public Shop_Details _Shop_Details = null;


        public Shop_Other_Details _Shop_Other_Details = null;





        public override string ToString()
        {
#if !Design_Test
            return $"{name} | {categories[0].text} | {shopNumber}";
#else
                    return $" {shopNumber}";

#endif
        }
    
}


    #region Shop Other Details
    public class Shop_Other_Details_Response
    {
        public long timestamp { get; set; }
       public long code { get; set; }
        public string message { get; set; }
        public Shop_Other_Details_Data data { get; set; }
    }


    public class Shop_Other_Details_Data
    {
        public List<Shop_Other_Details> shops { get; set; }
        public bool displayIntegrationYn { get; set; }
    }


    public class Shop_Other_Details
    {
       public long shopId { get; set; }
        public long franchiseId { get; set; } // thisi is the fix convert to long
       public long menupanId { get; set; }
       public long franchiseMenupanId { get; set; }
       public long useMenupanId { get; set; }
        public string shopName { get; set; }
        public string franchiseName { get; set; }
        public string serviceType { get; set; }
        public string category { get; set; }
        public List<string> adCategories { get; set; }
       public long minimumOrderPrice { get; set; }
        public bool depositCupUseFranchiseYn { get; set; }
        public bool noMarkupYn { get; set; }
        public object noMarkupFalseReason { get; set; }
        public object abusingResolvedAt { get; set; }
        public bool hasOfflineMenupanImage { get; set; }
    }
    #endregion

    public class Shops_Response
    {
        public long timestamp { get; set; }
        public string statusCode { get; set; }
        public string statusMessage { get; set; }
        public List<Datum> data { get; set; }

        public string type { get; set; }
        public string message { get; set; }
    }



    public class Address
    {
        public Jibun jibun { get; set; }
        public Road road { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string regionCode1 { get; set; }
        public string regionCode2 { get; set; }
        public string regionCode3 { get; set; }
        public string legalSidoCode { get; set; }
        public string legalGugunCode { get; set; }
        public string legalDongCode { get; set; }
    }

    public class AlcoholicMenuCount
    {
       public long alcoholicMenuCount { get; set; }
        public bool success { get; set; }
    }

    public class BaroPay
    {
        public bool contracted { get; set; }
        public OrderTakeChannelType orderTakeChannelType { get; set; }
        public List<PossibleOrderTakeChannelType> possibleOrderTakeChannelTypes { get; set; }
        public bool meetPayForCash { get; set; }
        public bool meetPayForCredit { get; set; }
        public bool possibleReservationOrder { get; set; }
        public bool success { get; set; }
    }

    public class Category
    {
        public string code { get; set; }
        public string name { get; set; }
        public string fullPathText { get; set; }
    }

    public class Content
    {
       public long id { get; set; }
       public long shopNo { get; set; }
        public string contentCategory { get; set; }
        public string contentType { get; set; }
        public string caption { get; set; }
        public string status { get; set; }
        public string blockReason { get; set; }
        public string revisionRecommendReason { get; set; }
       public long displayOrder { get; set; }
        public Detail detail { get; set; }
    }

    public class ConvenienceInfo
    {
        public object parking { get; set; }
        public object valet { get; set; }
        public object room { get; set; }
        public object group { get; set; }
        public object wifi { get; set; }
        public object pet { get; set; }
        public object babySeat { get; set; }
        public object disabledItem { get; set; }
        public object sedentary { get; set; }
    }



    public class DayOff
    {
        public List<DayOff2> dayOffs { get; set; }
        public List<TemporaryDayOff> temporaryDayOffs { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string dayOffText { get; set; }
    }

    public class DayOff2
    {
        public string interval { get; set; }
        public string day { get; set; }
    }

    public class TemporaryDayOff
    {
        //[JsonIgnore]
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
       public long  temporaryDayOffSeq { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class DeliveryArea
    {
        public string deliveryAreaInfo { get; set; }
        public List<string> s2Tokens { get; set; }
        public bool useDeliveryArea { get; set; }
    }

    public class DeliveryAreas
    {
        public List<DeliveryAreasByType> deliveryAreasByType { get; set; }
        public bool success { get; set; }
    }

    public class DeliveryAreasByType
    {
        public string deliveryType { get; set; }
        public DeliveryArea deliveryArea { get; set; }
    }

    public class DeliveryFee
    {
        public string deliveryType { get; set; }
        public List<Rule> rules { get; set; }
        public ExtraCharge extraCharge { get; set; }
       public long minimumOrderPrice { get; set; }
    }

    public class Detail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ExtraCharge
    {
        public List<Region> regions { get; set; }
        public List<object> days { get; set; }
        public Holiday holiday { get; set; }
        public object distance { get; set; }
    }

    public class Franchise
    {
        public string name { get; set; }
        public long no { get; set; }
        public string telephoneNo { get; set; }
        public bool success { get; set; }
    }

    public class Holiday
    {
       public long deliveryFee { get; set; }
    }

    public class Image
    {
        public string type { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }
    }

    public class Jibun
    {
        public string zipCode { get; set; }
        public string address { get; set; }
        public string addressDetail { get; set; }
    }

    public class MenuInfo
    {
        public string foodOrigin { get; set; }
        public string menuIntro { get; set; }
        public bool useSmartMenu { get; set; }
        public bool useFranchiseMenu { get; set; }
    }

    public class OperationHour
    {
        public List<OperationHour2> operationHours { get; set; }
        public List<BreakTime> breakTimes { get; set; }
    }

    public class OperationHour2
    {
        public bool allDay { get; set; }
        public string openTime { get; set; }
        public string closeTime { get; set; }
        public string intervalCode { get; set; }

    }

    public class BreakTime
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string weekDay { get; set; }

        public bool endNextDay { get; set; }
    }

    public class OrderInfo
    {
        public bool reservationOrder { get; set; }
        public TakeOutDiscount takeOutDiscount { get; set; }
        public bool possibleReservationOrder { get; set; }
    }

    public class OrderTakeChannelType
    {
        //[JsonProperty(PropertyName = "FooBar")]
        public string code { get; set; }
        public string name { get; set; }
    }

    public class PossibleOrderTakeChannelType
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class RecommendDeliveryTip
    {
        public string regionCode1 { get; set; }
        public string regionName1 { get; set; }
        public string serviceType { get; set; }
        public string category { get; set; }
       public long lowerDeliveryTip { get; set; }
       public long upperDeliveryTip { get; set; }
       public long recommendDeliveryTip { get; set; }
        public string orderRatio { get; set; }
    }

    public class Region
    {
       public long deliveryFee { get; set; }
        public string region3Code { get; set; }
    }

    public class ReturnFee
    {
        public object exchangeFee { get; set; }
        public object fullReturnFee { get; set; }
        public object partialReturnFee { get; set; }
        public bool success { get; set; }
    }

    public class Road
    {
        public string zipCode { get; set; }
        public string address { get; set; }
        public string addressDetail { get; set; }
    }

    public class Shop_Details
    {
       public long shopNo { get; set; }
        public string name { get; set; }
        public ServiceType serviceType { get; set; }
        public List<string> deliveryTypes { get; set; }
        public List<Category> categories { get; set; }
        public string intro { get; set; }
        public bool useFranchiseTelephone { get; set; }
        public Franchise franchise { get; set; }
        public string status { get; set; }
        public bool advertisement { get; set; }
        public List<Image> images { get; set; }
        public MenuInfo menuInfo { get; set; }
        public List<Telephone> telephones { get; set; }
        public Address address { get; set; }
        public OperationHour operationHour { get; set; }
        public DayOff dayOff { get; set; }
        public TemporaryStop temporaryStop { get; set; }
        public object riderNotice { get; set; }
        public OrderInfo orderInfo { get; set; }
        public List<DeliveryFee> deliveryFees { get; set; }
        public ConvenienceInfo convenienceInfo { get; set; }
        public List<Content> contents { get; set; }
        public object shopPath { get; set; }
       public long bagFee { get; set; }
        public object returnAddress { get; set; }
        public ReturnFee returnFee { get; set; }
        public bool useBaroPay { get; set; }
        public BaroPay baroPay { get; set; }
        public object shopStopReason { get; set; }
        public bool operating { get; set; }
        public UsePickUp usePickUp { get; set; }
        public string lastModified { get; set; }
        public DeliveryAreas deliveryAreas { get; set; }
        public AlcoholicMenuCount alcoholicMenuCount { get; set; }
        public List<RecommendDeliveryTip> recommendDeliveryTips { get; set; }
    }



    public class Rule
    {
       public long sort { get; set; }
       public long orderPrice { get; set; }
       public long deliveryFee { get; set; }
    }

    public class ServiceType
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class TakeOutDiscount
    {
       public long discountFee { get; set; }
       public long discountRate { get; set; }
        public string discountType { get; set; }
        public bool minimumOrderAmountDiscount { get; set; }
    }

    public class Telephone
    {
       public long telephoneId { get; set; }
        public string telephoneType { get; set; }
        public string telephone { get; set; }
        public string virtualTelephone { get; set; }
    }

    public class TemporaryStop
    {
        public string reason { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class UsePickUp
    {
        public object isUsingPickUp { get; set; }
        public bool success { get; set; }
    }


    #endregion

}
