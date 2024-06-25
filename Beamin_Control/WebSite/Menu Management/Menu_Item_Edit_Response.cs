using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite.Menu_Management
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Menu_item
    {
        public long timestamp { get; set; }
        public long code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public long menuId { get; set; }
        public long shopOwnerId { get; set; }
        public List<UseShop> useShops { get; set; }
        public string menuName { get; set; }
        public List<MenuPrice> menuPrices { get; set; }
        public List<MenupanMenuPrice> menupanMenuPrices { get; set; }
        public string menuComposition { get; set; }
        public string menuDesc { get; set; }
        public string menuType { get; set; }
        public bool soloYn { get; set; }
        public bool vegetarianYn { get; set; }
        public string vegetarianType { get; set; }
        public bool inProgressVegetarianAccept { get; set; }
        public List<OptionGroup> optionGroups { get; set; }
        public MenuImageInfos menuImageInfos { get; set; }
        public MenuStatusResponse menuStatusResponse { get; set; }
        public List<object> promotions { get; set; }
        public Nutrient nutrient { get; set; }
        public string allergy { get; set; }
    }

    public class MenuDisplayScheduleDto
    {
        public long menuId { get; set; }
        public string displayStartDate { get; set; }
        public string displayStartTime { get; set; }
        public string displayEndDate { get; set; }
        public string displayEndTime { get; set; }
        public bool displayMonYn { get; set; }
        public bool displayTueYn { get; set; }
        public bool displayWedYn { get; set; }
        public bool displayThuYn { get; set; }
        public bool displayFriYn { get; set; }
        public bool displaySatYn { get; set; }
        public bool displaySunYn { get; set; }
    }

    public class MenuImageInfos
    {
        public List<List<MenuImage>> menuImages { get; set; }
    }
    public partial class MenuImage
    {
        [JsonProperty("menuImageId")]
        public long MenuImageId { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("imageType")]
        public string ImageType { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("imageFarmId")]
        public long ImageFarmId { get; set; }
    }
    public class MenupanMenuPrice
    {
        public long shopId { get; set; }
        public long menupanId { get; set; }
        public string shopName { get; set; }
        public long menupanMenuId { get; set; }
        public List<MenupanPrice> menupanPrices { get; set; }
    }

    public class MenupanPrice
    {
        public long menuPriceId { get; set; }
        public long menupanMenuPriceId { get; set; }
        public string menuPriceName { get; set; }
        public int menupanMenuPrice { get; set; }
    }

    public class MenuPrice
    {
        public long menuPriceId { get; set; }
        public string menuPriceName { get; set; }
        public long menuPrice { get; set; }
        public object offlineMenuPrice { get; set; }
    }

    public class MenuStatusResponse
    {
        public long id { get; set; }
        public long menuId { get; set; }
        public string status { get; set; }
        public bool displayYn { get; set; }
        public string restockedAt { get; set; }
        public MenuDisplayScheduleDto menuDisplayScheduleDto { get; set; }
    }

    public class Nutrient
    {
        public bool setMenuYn { get; set; }
        public List<object> data { get; set; }
    }

    public class Option
    {
        public long optionId { get; set; }
        public string optionName { get; set; }
        public int optionPrice { get; set; }
        public string itemStatus { get; set; }
        public object offlineOptionPrice { get; set; }
        public string cupOptionCode { get; set; }
        public object mainOptionId { get; set; }
        public object restockedAt { get; set; }
        public List<object> promotions { get; set; }
    }

    public class OptionGroup
    {
        public long optionGroupId { get; set; }
        public string optionGroupName { get; set; }
        public int minOrderQuantity { get; set; }
        public int maxOrderQuantity { get; set; }
        public string cupOptionCode { get; set; }
        public int cupOptionItemCount { get; set; }
        public int mappedMenuCount { get; set; }
        public List<Option> options { get; set; }
    }



    public class UseShop
    {
        public long shopId { get; set; }
        public string shopName { get; set; }
        public long menuGroupId { get; set; }
        public string menuGroupName { get; set; }
        public long menupanId { get; set; }
        public bool representativeYn { get; set; }
        public string serviceType { get; set; }
        public string category { get; set; }
        public int minimumOrderPrice { get; set; }
        public object noMarkupYn { get; set; }
        public object noMarkupFalseReason { get; set; }
    }


}
