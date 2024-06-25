using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite.Out_of_Stock
{

    // 2024

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class menupan_Data
    {
        public int menupanId { get; set; }
    }

    public class menupan_Response
    {
        public long timestamp { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public menupan_Data data { get; set; }
    }


    #region Sold Out 2024

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        //public List<List<>> menuMoumCuts { get; set; }
        public List<RepresentativeMenu> representativeMenus { get; set; }
        public List<MenuGroup> menuGroups { get; set; }
    }

    public class Menu
    {
        public int menuId { get; set; }
        public string menuName { get; set; }
        public bool soloYn { get; set; }
        public bool representativeMenuYn { get; set; }
        public bool canRepresentativeMenuYn { get; set; }
        public bool representativeMenuAcceptProgressYn { get; set; }
        public bool vegetarianYn { get; set; }
        public bool popularMenuYn { get; set; }
        public string imageUrl { get; set; }
        public string menuDesc { get; set; }
        public string menuComposition { get; set; }
        public string menuType { get; set; }
        public string restockedAt { get; set; }
        public string itemStatus { get; set; }
        public bool displayYn { get; set; }
        public List<MenuPriceResponse> menuPriceResponses { get; set; }
        public List<object> promotions { get; set; }
    }

    public class MenuGroup
    {
        public int menuGroupId { get; set; }
        public string menuGroupName { get; set; }
        public string menuGroupDesc { get; set; }
        public List<Menu> menus { get; set; }
    }

    public class MenuPriceResponse
    {
        public int menuId { get; set; }
        public int menuPriceId { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int menupanMenuPrice { get; set; }
        public int menupanMenuPriceId { get; set; }
    }

    public class RepresentativeMenu
    {
        public int menuId { get; set; }
        public string menuName { get; set; }
        public string imageUrl { get; set; }
        public List<MenuPriceResponse> menuPriceResponses { get; set; }
    }

    public class SoldOut
    {
        public long timestamp { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

     
        public string errorType { get; set; }
        public string errorMessage { get; set; }

    }




    #endregion



    #region use Menupan Response
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class useMenupan_Response
    {
        public long timestamp { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Data_02 data { get; set; }

        public string errorType { get; set; }
        public string errorMessage { get; set; }
    }


    public class Data_02
    {
        public int menupanId { get; set; }
        public string menupanName { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public bool deletedYn { get; set; }
        public List<MenuGroup2> menuGroups { get; set; }
        public List<RepresentativeMenu_02> representativeMenus { get; set; }
        public List<MenuSoldOut2> menuSoldOuts { get; set; }
    }

    public class Menu_02
    {
        public Menu2 menu { get; set; }
        public MenuAttribute menuAttribute { get; set; }
        public MenuPriceInfo menuPriceInfo { get; set; }
        public MenuDisplayScheduleTime menuDisplayScheduleTime { get; set; }
        public MenuDisplayScheduleDay menuDisplayScheduleDay { get; set; }
        public MenuImage menuImage { get; set; }
        public MenuSoldOut2 menuSoldOuts { get; set; }
        public List<object> menuPromotions { get; set; }
        public List<object> promotions { get; set; }
        public bool popularMenuYn { get; set; }
        public object menuStockCount { get; set; }
        public int menuId { get; set; }
    }

    public class Menu2
    {
        public int menuId { get; set; }
        public string menuName { get; set; }
        public string menuSimpleDescription { get; set; }
        public string menuTypeCode { get; set; }
        public string menuDescription { get; set; }
        public string menuCookTypeCode { get; set; }
        public string menuCookTypeDescription { get; set; }
        public string menuNutrient { get; set; }
        public string menuAllergy { get; set; }
        public int displayOrder { get; set; }
        public bool displayYn { get; set; }
        public bool vegetarianMenuYn { get; set; }
        public List<object> vegetarianMenuAttr { get; set; }
        public bool defaultDisplayYn { get; set; }
        public bool noMarkupYn { get; set; }
        public List<string> menuNoMarkupFailReason { get; set; }
    }

    public class MenuAttribute
    {
        public List<object> menuAttributes { get; set; }
    }

    public class MenuDisplayScheduleDay
    {
        public object displayMonday { get; set; }
        public object displayTuesday { get; set; }
        public object displayWednesday { get; set; }
        public object displayThursday { get; set; }
        public object displayFriday { get; set; }
        public object displaySaturday { get; set; }
        public object displaySunday { get; set; }
    }

    public class MenuDisplayScheduleTime
    {
        public string displayStartDate { get; set; }
        public string  displayStartTime { get; set; }
        public string displayEndDate { get; set; }
        public string displayEndTime { get; set; }
    }

    public class MenuGroup2
    {
        public int menuGroupId { get; set; }
        public int menupanId { get; set; }
        public string menuGroupName { get; set; }
        public string desc { get; set; }
        public int displayOrder { get; set; }
        public bool displayYn { get; set; }
        public string channelType { get; set; }
        public bool deletedYn { get; set; }
        public string createdAt { get; set; }
        public string createdBy { get; set; }
        public string modifiedAt { get; set; }
        public string modifiedBy { get; set; }
        public List<Menu_02> menus { get; set; }
    }

    public class MenuImage
    {
        public List<MenuImage2> menuImages { get; set; }
    }

    public class MenuImage2
    {
        public int menuImageId { get; set; }
        public int imageFarmId { get; set; }
        public int displayOrder { get; set; }
        public string menuImageTypeCode { get; set; }
        public string menuImageTypeDescription { get; set; }
        public string menuImagePath { get; set; }
        public string menuImageUrl { get; set; }
        public int heightResolution { get; set; }
        public int widthResolution { get; set; }
    }

    public class MenuPriceInfo
    {
        public List<MenuPriceInfo2> menuPriceInfos { get; set; }
    }

    public class MenuPriceInfo2
    {
        public int menuPriceId { get; set; }
        public int menuPriceInfoId { get; set; }
        public string menuPriceName { get; set; }
        public int menuPrice { get; set; }
        public int displayOrder { get; set; }
        public object offlinePrice { get; set; }
    }

    public class MenuSoldOut2
    {
        public int menuId { get; set; }
        public bool isSoldOut { get; set; }
        public string restockedAt { get; set; }
    }


    public class RepresentativeMenu_02
    {
        public int menuId { get; set; }
        public int? representativeMenuId { get; set; }
        public bool canBeSetToTheRepresentativeMenu { get; set; }
        public bool isRepresentativeMenu { get; set; }
        public int? displayOrder { get; set; }
    }

  

    #endregion

    //--------------------------

    //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //public class Menu
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public bool displayYn { get; set; }
    //    public string restockedAt { get; set; }
    //    public List<MenuPrice> menuPrices { get; set; }
    //}

    //public class MenuGroup
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string description { get; set; }
    //    public bool displayYn { get; set; }
    //    public List<Menu> menus { get; set; }
    //}

    //public class MenuPrice
    //{
    //    public string name { get; set; }
    //    public string price { get; set; }
    //}

    //public class SoldOut
    //{
    //    public List<MenuGroup> menuGroups { get; set; }
    //    public string errorType { get; set; }
    //    public string errorMessage { get; set; }
    //}

    ////-----------------------------

    //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MenuMapping
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string typeDescription { get; set; }
    }

    public class Option
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public object templateOptionId { get; set; }
        public object templateCode { get; set; }
        public object minPrice { get; set; }
        public object maxPrice { get; set; }
        public object unitPrice { get; set; }
        public object itemCount { get; set; }
        public object priceEditYn { get; set; }
        public object deletable { get; set; }
        public bool displayYn { get; set; }
        public string restockedAt { get; set; }
    }

    public class OptionGroup
    {
        public int id { get; set; }
        public string name { get; set; }
        public int minOrderableQuantity { get; set; }
        public int maxOrderableQuantity { get; set; }
        public object templateOptionGroupId { get; set; }
        public object templateCode { get; set; }
        public List<Option> options { get; set; }
        public List<MenuMapping> menuMappings { get; set; }
    }

    public class OptionGroup_SoldOut
    {
        public List<OptionGroup> optionGroups { get; set; }
        public string errorType { get; set; }
        public string errorMessage { get; set; }
    }



}
