using System.ComponentModel.DataAnnotations;
using static ReadStation.Helper.Enums.Enums;
namespace ReadStation.Models.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        [EnumDataType(typeof(Membership))]
        public Membership MembershipTier { get; set; }
        public string Description { get; set; }
        public float PricePerMonth { get; set; }
        public int DownloadableContentPerMonth { get; set; }
        [EnumDataType(typeof(DurationInDays))]
        public DurationInDays DurationInDays { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
        public virtual ICollection<SubscriptionContent> SubscriptionContents { get; set; }
    }
}
