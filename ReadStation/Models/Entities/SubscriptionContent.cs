namespace ReadStation.Models.Entities
{
    public class SubscriptionContent
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }            

        // Relationships
        public virtual Subscription Subscription { get; set; }
        public virtual Content Content { get; set; }
    }
}
