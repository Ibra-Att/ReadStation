using static ReadStation.Helper.Enums.Enums;
namespace ReadStation.Models.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public Membership MembershipTier { get; set; }
        public string Description { get; set; }
        public float PricePerMonth { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
        public virtual ICollection<SubscriptionContent> SubscriptionContents { get; set; }
    }
}
