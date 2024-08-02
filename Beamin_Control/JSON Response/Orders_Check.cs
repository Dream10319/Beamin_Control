using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.JSON_Response
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    #region Order Check Response
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Order_Check
    {
        //public string serverUtcTime { get; set; }

        public string rspCode { get; set; }
        public string rspMsg { get; set; }
        public List<Order_Check_Datum> data { get; set; }
    }

    public class Order_Check_Datum
    {
        public string orderNo { get; set; }
        public string orderProgress { get; set; }
        public string orderStatus { get; set; }
        public string riderStatus { get; set; }
        public string date { get; set; }
        public bool partialCancelEvent { get; set; }
    }



    #endregion



    #region delivery_Check

    public class delivery_Check
    {
        //public string serverUtcTime { get; set; }

        public string rspCode { get; set; }
        public string rspMsg { get; set; }
        public List<delivery_Check_Datum> data { get; set; }
    }

    public class delivery_Check_Datum
    {
        public string orderNo { get; set; }
        public string orderStatus { get; set; }
        public string riderStatus { get; set; }

        public string deliveryEventCode { get; set; }
        public string message { get; set; }
    }

    #endregion 

    #region Ordders Details Response
    public class Ordders_Details_Response
    {
        public string serverUtcTime { get; set; }
        public string rspCode { get; set; }
        public string rspMsg { get; set; }
        public List<Ordders_Details_Datum> data { get; set; }
    }
    public class BaeminExpectedDeliveryTime
    {
        public string type { get; set; }
        public object model { get; set; }
        public List<int> deliveryTime { get; set; }
        public int pureDeliveryTime { get; set; }
        public double calcDeliveryTime { get; set; }
        public string deliveryTimeWeightVersion { get; set; }
    }

    public class BasicMemo
    {
        public string memoType { get; set; }
        public string memo { get; set; }
        public string title { get; set; }
    }

    public class Charge
    {
        public string type { get; set; }
        public int amount { get; set; }
    }

    public class Ordders_Details_Datum
    {
        public string merchantNo { get; set; }
        public string channel { get; set; }
        public string siteCode { get; set; }
        public string serviceType { get; set; }
        public string memberNo { get; set; }
        public bool offerShopOrderCount { get; set; }
        public string  adInventoryKey { get; set; }
        public string orderInProgressCount { get; set; }
        public ShopInfo shopInfo { get; set; }
        public string orderNo { get; set; }
        public object seq { get; set; }
        public object orderSeq { get; set; }
        public string orderStatus { get; set; }
        public string riderStatus { get; set; }
        public object receiptNumber { get; set; }
        public object tableDisplayName { get; set; }
        public bool includeAlcohol { get; set; }
        public List<Food> foods { get; set; }
        public cancelInfo cancelInfo { get; set; }
        public int amountToReceive { get; set; }
        public int smallOrderFee { get; set; }
        public PayInfo payInfo { get; set; }
        public string txDateTime { get; set; }
        public string orderTime { get; set; }
        public string orderUtcTime { get; set; }
        public string orderDate { get; set; }
        public string orderDateTime { get; set; }
        public string orderModifyDateTime { get; set; }
        public string orderModifyUtcTime { get; set; }
        public string orderReceiptDateTime { get; set; }
        public string orderReceiptUtcTime { get; set; }
        public object cookTimeMinutes { get; set; }
        public cookTimeMinutesRange cookTimeMinutesRange { get; set; }
        public object cookCompletedTime { get; set; }
        public string orderCompleteDateTime { get; set; }
        public bool delayedDeliveryRequest { get; set; }
        public string deliveryAgencyType { get; set; }
        public bool useDeliveryService { get; set; }
        public RiderInfo riderInfo { get; set; }
        public DeliveryInfo deliveryInfo { get; set; }
        public string deliveryType { get; set; }
        public string deliveryCarryType { get; set; }
        public OverSizeDelivery overSizeDelivery { get; set; }
        public int deliveryTip { get; set; }
        public DeliveryTipDetail deliveryTipDetail { get; set; }
        public string deliveryMinutes { get; set; }
        public string deliveryTimeBuffer { get; set; }
        public string minPickupTime { get; set; }
        public string maxPickupTime { get; set; }
        public object cookRequestedTime { get; set; }
        public string cookRequestedUtcTime { get; set; }
        public string estimatedPickupExecuteTime { get; set; }
        public string estimatedPickupExecuteUtcTime { get; set; }
        public object estimatedPickupTime { get; set; }
        public object pickupExecuteTime { get; set; }
        public string pickupExecuteUtcTime { get; set; }
        public BaeminExpectedDeliveryTime baeminExpectedDeliveryTime { get; set; }
        public object deliveries { get; set; }
        public bool reserved { get; set; }
        public string reservedDateTime { get; set; }
        public string notiDateTime { get; set; }
        public int notiSelectedTime { get; set; }
        public bool usePersonalCup { get; set; }
        public TraceInfo traceInfo { get; set; }
        public ShopRequirement shopRequirement { get; set; }
        public bool useDisposableCup { get; set; }
        public int disposableCupOrderAmount { get; set; }
        public object ridersExpectedDeliveryTime { get; set; }
        public object detailLink { get; set; }
        public object orderToken { get; set; }
        public object robotInfo { get; set; }
        public object shopOrderCount { get; set; }
    }


    public class cancelInfo
    {
        public string cancelDate { get; set; }
        public string cancelReason { get; set; }

    }
    public class cookTimeMinutesRange
    {
        public int min { get; set; }
        public int max { get; set; }

    }

    public class DeliveryInfo
    {
        public string phoneNo { get; set; }
        public string address { get; set; }
        public string memo { get; set; }
        public List<Memo> memos { get; set; }
        public List<BasicMemo> basicMemos { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string addressJibun { get; set; }
        public string addressRoad { get; set; }
        public string addressDetail { get; set; }
    }

    public class DeliveryTipDetail
    {
        public List<Charge> charges { get; set; }
        public int chargeAmount { get; set; }
    }

    public class Food
    {
        public int foodSeq { get; set; }
        public string foodName { get; set; }
        public string foodContents { get; set; }
        public string quantity { get; set; }
        public int price { get; set; }
        public object code { get; set; }
        public List<PriceGroup> priceGroup { get; set; }
    }

    public class FoodPrice
    {
        public object priceSeq { get; set; }
        public int shopFoodPriceSeq { get; set; }
        public string priceName { get; set; }
        public int price { get; set; }
        public string code { get; set; }
        public string templateCode { get; set; }
        public int templateUnitPrice { get; set; }
    }

    public class Memo
    {
        public string memoType { get; set; }
        public string memo { get; set; }
        public string title { get; set; }
    }

    public class OverSizeDelivery
    {
        public bool over { get; set; }
        public int maxRiderCount { get; set; }
    }

    public class PayInfo
    {
        public string price { get; set; }
        public string salePrice { get; set; }
        public string vat { get; set; }
        public string paymentGroup { get; set; }
        public string paymentMethod { get; set; }
    }

    public class PriceGroup
    {
        public int groupSeq { get; set; }
        public string groupName { get; set; }
        public string isDefault { get; set; }
        public List<FoodPrice> foodPrice { get; set; }
    }

    public class RiderInfo
    {
        public string companyCode { get; set; }
        public string companyName { get; set; }
        public string agencyRelayType { get; set; }
        public string riderKey { get; set; }
        public int estimatedTimeOfArrival { get; set; }
        public object pickupTime { get; set; }
        public object messageUrl { get; set; }
        public object sn { get; set; }
        public object businessDay { get; set; }
        public object riderName { get; set; }
        public object riderPhoneNo { get; set; }
        public string riderAssignTime { get; set; }
        public string cookRequestedTime { get; set; }
        public string  pickupExecuteTime { get; set; }
        public string estimatedPickupExecuteTime { get; set; }
        public string deliveryFee { get; set; }
        public object handOverTime { get; set; }
        public object messageUserId { get; set; }
        public bool reDelivery { get; set; }
        public string agencyReceiptTime { get; set; }
        public string pickupExecuteUtcTime { get; set; }
        public string estimatedPickupExecuteUtcTime { get; set; }
        public string riderAssignUtcTime { get; set; }
        public object pickupUtcTime { get; set; }
        public string cookRequestedUtcTime { get; set; }
        public string agencyReceiptUtcTime { get; set; }
        public object handOverUtcTime { get; set; }
    }

   

    public class ShopInfo
    {
        public string shopNo { get; set; }
        public string shopName { get; set; }
        public string franchiseNo { get; set; }
        public string category { get; set; }
        public object rgn3 { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
    }

    public class ShopRequirement
    {
        public string spoonFork { get; set; }
        public string sideDish { get; set; }
        public string reusableContainer { get; set; }
    }

    public class TraceInfo
    {
        public object ecoDelivery { get; set; }
        public bool spoonForkDelivery { get; set; }
        public bool sideDishDelivery { get; set; }
        public object useReusableContainer { get; set; }
        public object fastDelivery { get; set; }
        public object memberLat { get; set; }
        public object memberLng { get; set; }
        public object category { get; set; }
    }

    #endregion
}
