using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Beamin_Control.WebSite.Menu_Management
{
    //internal class Menu_Item_Edit_Response_02
    //{
    //}


    #region Price Update Json Request
    public partial class Price_Update_Json
    {
        public long id { get; set; }
        public string name { get; set; }
        public string simpleDescription { get; set; }
        public string typeCode { get; set; }
        public string description { get; set; }
        public string cookTypeCode { get; set; }
        public string cookTypeDescription { get; set; }
        public Nutrient_02 nutrient { get; set; }
        public string allergy { get; set; }
        public object menuStockCount { get; set; }
        public bool displayYn { get; set; }
        public List<MenuPrice_02> menuPrices { get; set; }
        public List<long> optionGroups { get; set; }
        public List<MenuImage_02> menuImages { get; set; }
        //public List<DataImage> images { get; set; }

        //[JsonArray("id")]
        //[JsonProperty("ss")]
        //public DataImage[][] images { get; set; }

        public List<List<DataImage>> images { get; set; }

        public bool solo { get; set; }
        public string restockedAt { get; set; }
        public bool vegetarianMenuYn { get; set; }
        public List<object> vegetarianMenuAttr { get; set; }
        public List<object> promotions { get; set; }
        public MenuImageAcceptResponse menuImageAcceptResponse { get; set; }
        public MenuVegetarianAcceptResponse menuVegetarianAcceptResponse { get; set; }
        public MenuDisplayScheduleTime menuDisplayScheduleTime { get; set; }
        public MenuDisplayScheduleDay menuDisplayScheduleDay { get; set; }
        public bool popularMenuYn { get; set; }
        public bool representativeMenu { get; set; }
    }

    #endregion

    public partial class Menu_item_02
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Data_02 Data { get; set; }
    }

    public partial class Data_02
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("simpleDescription")]
        public string SimpleDescription { get; set; }

        [JsonProperty("typeCode")]
        public string TypeCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cookTypeCode")]
        public string CookTypeCode { get; set; }

        [JsonProperty("cookTypeDescription")]
        public string CookTypeDescription { get; set; }

        [JsonProperty("nutrient")]
        public Nutrient_02 Nutrient { get; set; }

        [JsonProperty("allergy")]
        public string Allergy { get; set; }

        [JsonProperty("menuStockCount")]
        public object MenuStockCount { get; set; }

        [JsonProperty("displayYn")]
        public bool DisplayYn { get; set; }

        [JsonProperty("menuPrices")]
        //public MenuPrice_02[] MenuPrices { get; set; }
        public List<MenuPrice_02> MenuPrices { get; set; }


        [JsonProperty("optionGroups")]
        public OptionGroup_02[] OptionGroups { get; set; }

        [JsonProperty("menuImages")]
        public List<MenuImage_02> MenuImages { get; set; }

        [JsonProperty("images")]
        public DataImage[][] Images { get; set; }
        //public List<DataImage> Images { get; set; }

        [JsonProperty("solo")]
        public bool Solo { get; set; }

        [JsonProperty("restockedAt")]
        public string RestockedAt { get; set; }

        [JsonProperty("vegetarianMenuYn")]
        public bool VegetarianMenuYn { get; set; }

        [JsonProperty("vegetarianMenuAttr")]
        public List<object> VegetarianMenuAttr { get; set; }

        [JsonProperty("promotions")]
        public List<object> Promotions { get; set; }

        [JsonProperty("menuImageAcceptResponse")]
        public MenuImageAcceptResponse MenuImageAcceptResponse { get; set; }

        [JsonProperty("menuVegetarianAcceptResponse")]
        public MenuVegetarianAcceptResponse MenuVegetarianAcceptResponse { get; set; }

        [JsonProperty("menuDisplayScheduleTime")]
        public MenuDisplayScheduleTime MenuDisplayScheduleTime { get; set; }

        [JsonProperty("menuDisplayScheduleDay")]
        public MenuDisplayScheduleDay MenuDisplayScheduleDay { get; set; }

        [JsonProperty("popularMenuYn")]
        public bool PopularMenuYn { get; set; }

        [JsonProperty("representativeMenu")]
        public bool RepresentativeMenu { get; set; }
    }

    public partial class DataImage
    {

        //[JsonPropertyOrder(-1)]
        [JsonProperty("imageId")]
        public long imageId { get; set; }

        [JsonProperty("imageFarmId")]
        public long ImageFarmId { get; set; }

        [JsonProperty("imageType")]
        public string ImageType { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl_02 { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class MenuDisplayScheduleDay
    {
        [JsonProperty("displayMonday")]
        public bool DisplayMonday { get; set; }

        [JsonProperty("displayTuesday")]
        public bool DisplayTuesday { get; set; }

        [JsonProperty("displayWednesday")]
        public bool DisplayWednesday { get; set; }

        [JsonProperty("displayThursday")]
        public bool DisplayThursday { get; set; }

        [JsonProperty("displayFriday")]
        public bool DisplayFriday { get; set; }

        [JsonProperty("displaySaturday")]
        public bool DisplaySaturday { get; set; }

        [JsonProperty("displaySunday")]
        public bool DisplaySunday { get; set; }
    }

    public partial class MenuDisplayScheduleTime
    {
        [JsonProperty("displayStartDate")]
        public object DisplayStartDate { get; set; }

        [JsonProperty("displayStartTime")]
        public object DisplayStartTime { get; set; }

        [JsonProperty("displayEndDate")]
        public object DisplayEndDate { get; set; }

        [JsonProperty("displayEndTime")]
        public object DisplayEndTime { get; set; }
    }

    public partial class MenuImageAcceptResponse
    {
        [JsonProperty("menuId")]
        public long MenuId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDescription")]
        public string StatusDescription { get; set; }

        [JsonProperty("images")]
        public MenuImageAcceptResponseImage[][] Images { get; set; }

        [JsonProperty("cancelReason")]
        public object CancelReason { get; set; }
    }

    public partial class MenuImageAcceptResponseImage
    {
        [JsonProperty("imageUrl")]
        public Uri ImageUrl_02 { get; set; }

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }

        [JsonProperty("imageAccessUrl")]
        public Uri ImageAccessUrl { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("imageFarmId")]
        public long ImageFarmId { get; set; }

        [JsonProperty("imageId")]
        public long ImageId { get; set; }

        [JsonProperty("imageType")]
        public string ImageType { get; set; }

        [JsonProperty("thumbnailImageAccessUrl")]
        public object ThumbnailImageAccessUrl { get; set; }
    }

    public partial class MenuImage_02
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("farmId")]
        public long FarmId { get; set; }

        [JsonProperty("imageTypeCode")]
        public string ImageTypeCode { get; set; }

        [JsonProperty("imageTypeDescription")]
        public string ImageTypeDescription { get; set; }

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl_03 { get; set; }

        [JsonProperty("heightResolution")]
        public long HeightResolution { get; set; }

        [JsonProperty("widthResolution")]
        public long WidthResolution { get; set; }
    }

    public partial class MenuPrice_02
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }
    }

    public partial class MenuVegetarianAcceptResponse
    {
        [JsonProperty("menuId")]
        public long MenuId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDescription")]
        public string StatusDescription { get; set; }

        [JsonProperty("vegetarianYn")]
        public bool VegetarianYn { get; set; }

        [JsonProperty("vegetarianMenuAttr")]
        public string VegetarianMenuAttr { get; set; }

        [JsonProperty("menuDescription")]
        public string MenuDescription { get; set; }

        [JsonProperty("cancelReason")]
        public object CancelReason { get; set; }
    }

    public partial class Nutrient_02
    {
        [JsonProperty("setMenuYn")]
        public bool SetMenuYn { get; set; }

        [JsonProperty("data")]
        public object[] Data { get; set; }
    }

    public partial class OptionGroup_02
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("minOrderableQuantity")]
        public long MinOrderableQuantity { get; set; }

        [JsonProperty("maxOrderableQuantity")]
        public long MaxOrderableQuantity { get; set; }

        [JsonProperty("cupOptionCode")]
        public string CupOptionCode { get; set; }

        [JsonProperty("cupOptionItemCount")]
        public object CupOptionItemCount { get; set; }

        [JsonProperty("templateOptionGroupId")]
        public object TemplateOptionGroupId { get; set; }

        [JsonProperty("hidable")]
        public bool Hidable { get; set; }

        [JsonProperty("displayYn")]
        public bool DisplayYn { get; set; }

        [JsonProperty("options")]
        public Option_02[] Options { get; set; }

        [JsonProperty("menuMappings")]
        public MenuMapping[] MenuMappings { get; set; }
    }

    public partial class MenuMapping
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("typeDescription")]
        public string TypeDescription { get; set; }
    }

    public partial class Option_02
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("cupOptionCode")]
        public string CupOptionCode { get; set; }

        [JsonProperty("cupOptionItemCount")]
        public object CupOptionItemCount { get; set; }

        [JsonProperty("mainOptionId")]
        public object MainOptionId { get; set; }

        [JsonProperty("restockedAt")]
        public object RestockedAt { get; set; }

        [JsonProperty("displayYn")]
        public bool DisplayYn { get; set; }

        [JsonProperty("promotions")]
        public object[] Promotions { get; set; }

        [JsonProperty("soldOut")]
        public bool SoldOut { get; set; }
    }


}
