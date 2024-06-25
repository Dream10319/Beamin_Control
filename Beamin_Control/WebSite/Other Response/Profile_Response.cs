using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite.Other_Response.Profile_Response
//namespace Beamin_Control.WebSite.Other_Response.Profile_Response
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //public class Attributes
    //{
    //    public string shopOwnerNo { get; set; }
    //    public string authorityCode { get; set; }
    //    public string agreeAcademy { get; set; }
    //    public string memNo { get; set; }
    //    public string memGradeCd { get; set; }
    //}

    //public class MemberEtcProfile
    //{
    //    public string memberNumber { get; set; }
    //    public string nickName { get; set; }
    //    public string profileImageUrl { get; set; }
    //    public string gender { get; set; }
    //    public string mainCategory { get; set; }
    //    public string allCategory { get; set; }
    //    public string sido { get; set; }
    //    public string gugun { get; set; }
    //    public string dong { get; set; }
    //    public string mainShopName { get; set; }
    //    public bool visibleShopName { get; set; }
    //    public string storeStartYear { get; set; }
    //    public bool preparationCeo { get; set; }
    //    public DateTime createdDate { get; set; }
    //    public DateTime updatedDate { get; set; }
    //    public string createdBy { get; set; }
    //    public string updatedBy { get; set; }
    //}

    public class Profile_Response
    {
        public string memNo { get; set; }
        public string memName { get; set; }
        public string mobileNo { get; set; }
        public string email { get; set; }
        public string memGradeCd { get; set; }
        public string shopOwnerNumber { get; set; }
        public string decodedEmail { get; set; }
        public string decodedMobileNo { get; set; }

        public string errorType { get; set; }
        public string errorMessage { get; set; }

        //public string username { get; set; }
        //public string name { get; set; }
        //public string email { get; set; }
        //public string corporateName { get; set; }
        //public Attributes attributes { get; set; }
        //public string phoneNumber { get; set; }
        //public string uid { get; set; }
        //public string memberNumber { get; set; }
        //public string memberGrade { get; set; }
        //public string storeOwnerNumber { get; set; }
        //public string authorityCode { get; set; }
        //public bool baroSettlement { get; set; }
        //public string shopOwnerNumber { get; set; }
        //public string loginId { get; set; }
        //public MemberEtcProfile memberEtcProfile { get; set; }
    }



    //public class Data
    //{
    //    public string memNo { get; set; }
    //    public string memId { get; set; }
    //    public string memName { get; set; }
    //    public string businessName { get; set; }
    //    public string mobileNo { get; set; }
    //    public string email { get; set; }
    //    public string shopOwnerNo { get; set; }
    //    public bool baroSettlement { get; set; }
    //    public string memGradeCd { get; set; }
    //    public bool agreeAcademy { get; set; }
    //    public bool needCertification { get; set; }
    //    public string birthDate { get; set; }
    //    public string shopOwnerNumber { get; set; }
    //    public string decodedEmail { get; set; }
    //    public string decodedMobileNo { get; set; }
    //    public string memNm { get; set; }
    //}

    //public class Profile_Response
    //{
    //    public long timestamp { get; set; }
    //    public string statusCode { get; set; }
    //    public string statusMessage { get; set; }
    //    public Data data { get; set; }

    //    public string type { get; set; }
    //    public string message { get; set; }

    //}


}
