using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamin_Control.WebSite.Reviews
{

    public class Review_Comment_Request
    {
        public long reviewId { get; set; }
        public string contents { get; set; }
    }

    public class Reviews_Count
    {
        public int reviewCount { get; set; }
        public int noCommentReviewCount { get; set; }
        public int blockedReviewCount { get; set; }
        public int recentReviewCount { get; set; }


        public string errorType { get; set; }
        public string errorMessage { get; set; }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DeliveryReviews
    {
        public string recommendation { get; set; }
        public List<string> contents { get; set; }
    }

   

    public class Image
    {
        public long id { get; set; }
        public string imageUrl { get; set; }
        public string displayStatus { get; set; }
        public int sequence { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
        public string blockMessage { get; set; }
    }

    public class Comment
    {
        public object id { get; set; }
        public long managerNo { get; set; }
        public string managerNickname { get; set; }
        public string contents { get; set; }
        public string displayType { get; set; }
        public string displayStatus { get; set; }
        public string createdDate { get; set; }
        public bool modifiable { get; set; }
        public string blockType { get; set; }
        public string blockMessage { get; set; }
    }

    public class Menu
    {
        public object id { get; set; }
        public string name { get; set; }
        public string contents { get; set; }
        public string recommendation { get; set; }
        public object createdAt { get; set; }
        public object modifiedAt { get; set; }
        public string menuDisplayType { get; set; }
    }


    public class Review
    {
        public long id { get; set; }
        public object memberNo { get; set; }
        public string memberNickname { get; set; }
        public double rating { get; set; }
        public string contents { get; set; }
        public string displayType { get; set; }
        public string displayStatus { get; set; }
        public List<Comment> comments { get; set; }
        public List<Image> images { get; set; }
        public List<Menu> menus { get; set; }
        public DeliveryReviews deliveryReviews { get; set; }
        public string createdDate { get; set; }
        public object coupon { get; set; }
        public string menuDisplayType { get; set; }
        public string blockMessage { get; set; }
        public string blockType { get; set; }
        public bool writableComment { get; set; }
        public string writableCommentType { get; set; }
    }

    public class Reviews_Response
    {
        public bool next { get; set; }
        public bool copyReview { get; set; }
        public string copyReviewPopup { get; set; }
        public List<Review> reviews { get; set; }

        public string errorType { get; set; }
        public string errorMessage { get; set; }

    }


}
