namespace ReadStation.Models.Entities
{
    public class UserSubscription
    {
        public int Id { get; set; }
        public float Promotion { get; set; }
        public float Price { get; set; }
        public float NetPrice { get; set; }
        public int DurationInDays { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }             // Flag to indicate the active status of the association

        // Relationships
        public virtual User User { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
