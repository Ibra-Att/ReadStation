using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.DTOs.Subscription
{
    public class SubscriptionInfoDTO
    {
        public int Id { get; set; }
        public string MembershipTier { get; set; }
        public string Description { get; set; }
        public float PricePerMonth { get; set; }
        public string DurationInDays { get; set; }
        public int DownloadableContentPerMonth { get; set; }

    }
}
