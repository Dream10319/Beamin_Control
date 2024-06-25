using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite
{





    #region Response
    //public class AdCampaign
    //{
    //    public string id { get; set; }
    //    public string key { get; set; }
    //}

    //public class Content
    //{
    //    public Order order { get; set; }
    //    public Settle settle { get; set; }
    //}

    //public class Item
    //{
    //    public string name { get; set; }
    //    public int totalPrice { get; set; }
    //    public int quantity { get; set; }
    //    public object discountPrice { get; set; }
    //    public List<Option> options { get; set; }
    //}

    //public class Option
    //{
    //    public string name { get; set; }
    //    public int price { get; set; }
    //}

    //public class Order
    //{
    //    public string orderNumber { get; set; }
    //    public string status { get; set; }
    //    public string deliveryType { get; set; }
    //    public string payType { get; set; }
    //    public int payAmount { get; set; }
    //    public DateTime orderDateTime { get; set; }
    //    public int shopNumber { get; set; }
    //    public string itemsSummary { get; set; }
    //    public List<Item> items { get; set; }
    //    public int deliveryTip { get; set; }
    //    public object smallOrderFee { get; set; }
    //    public object takeOutDiscountAmount { get; set; }
    //    public object employeeDiscountAmount { get; set; }
    //    public object ownerChargeCouponDiscountAmount { get; set; }
    //    public object baeminChargeCouponDiscountAmount { get; set; }
    //    public AdCampaign adCampaign { get; set; }
    //}

    //public class Order_History_Response
    //{
    //    public int totalSize { get; set; }
    //    public int totalPayAmount { get; set; }
    //    public List<Content> contents { get; set; }

    //    public string errorType { get; set; }
    //    public string errorMessage { get; set; }
    //}

    //public class Settle
    //{
    //    public string notDisplayReason { get; set; }
    //    public int? salesAmount { get; set; }
    //    public int? discountAmount { get; set; }
    //    public int? disposableCupDepositAmount { get; set; }
    //    public SubtractAmount subtractAmount { get; set; }
    //    public object deliveryFeeSupportAmount { get; set; }
    //    public int? vat { get; set; }
    //    public object meetAmount { get; set; }
    //    public int? depositDueAmount { get; set; }
    //    public string depositDueDate { get; set; }
    //}

    //public class SubtractAmount
    //{
    //    public int? total { get; set; }
    //    public object advertiseFee { get; set; }
    //    public object riderServiceFee { get; set; }
    //    public object deliverySupplyPrice { get; set; }
    //    public int? serviceFee { get; set; }
    //    public object deliveryFeeDiscount { get; set; }
    //}

    #endregion

    #region Response 2024
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Order_History_Response
    {
        public int totalSize { get; set; }
        public int totalPayAmount { get; set; }
        public List<Content> contents { get; set; }

        public string errorType { get; set; }
        public string errorMessage { get; set; }
    }


    public class AdCampaign
    {
        public string id { get; set; }
        public string key { get; set; }
    }

    public class Content
    {
        public Order order { get; set; }
        public Settle settle { get; set; }
    }

    public class DeliveryItem
    {
        public string code { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public int sequence { get; set; }
    }

    public class EtcItem
    {
        public string code { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public int sequence { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public int totalPrice { get; set; }
        public int quantity { get; set; }
        public int discountPrice { get; set; }
        public List<Option> options { get; set; }
    }

    public class Option
    {
        public string name { get; set; }
        public int price { get; set; }
        public int discountPrice { get; set; }
    }

    public class Order
    {
        public string orderNumber { get; set; }
        public string status { get; set; }
        public string deliveryType { get; set; }
        public string payType { get; set; }
        public int payAmount { get; set; }
        public DateTime orderDateTime { get; set; }
        public int shopNumber { get; set; }
        public string itemsSummary { get; set; }
        public List<Item> items { get; set; }
        public int deliveryTip { get; set; }
        public object smallOrderFee { get; set; }
        public object takeOutDiscountAmount { get; set; }
        public object employeeDiscountAmount { get; set; }
        public object ownerChargeCouponDiscountAmount { get; set; }
        public int? baeminChargeCouponDiscountAmount { get; set; }
        public AdCampaign adCampaign { get; set; }
        public string deliveryCarryType { get; set; }
        public string serviceType { get; set; }
        public bool partialCanceled { get; set; }
        public bool isPartialCanceled { get; set; }
    }

    public class OrderBrokerageItem
    {
        public string code { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public List<object> depth3Items { get; set; }
    }

 
    public class Settle
    {
        public object notDisplayReason { get; set; }
        public int orderBrokerageAmount { get; set; }
        public List<OrderBrokerageItem> orderBrokerageItems { get; set; }
        public int deliveryItemAmount { get; set; }
        public List<DeliveryItem> deliveryItems { get; set; }
        public int etcItemAmount { get; set; }
        public List<EtcItem> etcItems { get; set; }
        public int deductionAmountTotalVat { get; set; }
        public object meetAmount { get; set; }
        public int depositDueAmount { get; set; }
        public string depositDueDate { get; set; }
        public int total { get; set; }
    }



    #endregion
}
