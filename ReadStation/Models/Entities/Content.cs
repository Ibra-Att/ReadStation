using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Models.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentType ContentType { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public virtual ICollection<SubscriptionContent> SubscriptionContents { get; set; }
    }
}

