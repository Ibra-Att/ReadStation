


namespace ReadStation.DTOs.Subscription
{
    public class BuySubscriptionDTO
    {
        public float Promotion { get; set; }
       // public float Price { get; set; }
      //  public float NetPrice { get; set; }
        public int DurationInMonths { get; set; }
        public int DownloadCounter { get; set; }
        public int MembershipCounter { get; set; }
       
        //public DateTime SubscriptionDate { get; set; }
        //public DateTime ExpiryDate { get; set; }

        public int UserId { get; set; }
        public string MembershipTier { get; set; }

    }
}
