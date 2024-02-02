namespace ReadStation.Models.Entities
{
    public class UserSubscription
    {
        public int Id { get; set; }
        public float Promotion { get; set; }
        public float Price { get; set; }
        public float NetPrice { get; set; }
        public int DurationInMonths { get; set; }
        public int DownloadCounter { get; set; }
        public int MembershipCounter { get; set; }

        public DateTime SubscriptionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }             

        // Relationships
        public virtual User User { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
