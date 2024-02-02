using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.DTOs.Subscription
{
    public class CreateSubscriptionDTO
    {
        public string MembershipTier { get; set; }
        public string Description { get; set; }
        public float PricePerMonth { get; set; }
        public int DownloadableContentPerMonth { get; set; }
        public int DurationInDays { get; set; }

    }
}
