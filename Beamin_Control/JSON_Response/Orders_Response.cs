using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.JSON_Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BaeminExpectedDeliveryTime
    {
        public string type { get; set; }
        public string model { get; set; }
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
        public object adInventoryKey { get; set; }
        public string orderInProgressCount { get; set; }
        public ShopInfo shopInfo { get; set; }
        public string orderNo { get; set; }
        public long seq { get; set; }
        public long orderSeq { get; set; }
        public string orderStatus { get; set; }
        public object riderStatus { get; set; }
        public object receiptNumber { get; set; }
        public object tableDisplayName { get; set; }
        public bool includeAlcohol { get; set; }
        public List<Food> foods { get; set; }
        public object cancelInfo { get; set; }
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
        public object cookTimeMinutesRange { get; set; }
        public object cookCompletedTime { get; set; }
        public string orderCompleteDateTime { get; set; }
        public bool delayedDeliveryRequest { get; set; }
        public string deliveryAgencyType { get; set; }
        public bool useDeliveryService { get; set; }
        public object riderInfo { get; set; }
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
        public object cookRequestedUtcTime { get; set; }
        public object estimatedPickupExecuteTime { get; set; }
        public object estimatedPickupExecuteUtcTime { get; set; }
        public object estimatedPickupTime { get; set; }
        public object pickupExecuteTime { get; set; }
        public object pickupExecuteUtcTime { get; set; }
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

    public class Ordders_Details_Response
    {
        public string serverUtcTime { get; set; }
        public string rspCode { get; set; }
        public string rspMsg { get; set; }
        public List<Ordders_Details_Datum> data { get; set; }
    }

    public class ShopInfo
    {
        public string shopNo { get; set; }
        public string shopName { get; set; }
        public string franchiseNo { get; set; }
        public string category { get; set; }
        public string rgn3 { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class ShopRequirement
    {
        public string spoonFork { get; set; }
        public string sideDish { get; set; }
        public string reusableContainer { get; set; }
    }

    public class TraceInfo
    {
        public bool ecoDelivery { get; set; }
        public bool spoonForkDelivery { get; set; }
        public bool sideDishDelivery { get; set; }
        public bool useReusableContainer { get; set; }
        public bool fastDelivery { get; set; }
        public double memberLat { get; set; }
        public double memberLng { get; set; }
        public string category { get; set; }
    }


}
