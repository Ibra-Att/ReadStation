using System.ComponentModel.DataAnnotations;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Models.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(ContentType))]
        public ContentType ContentType { get; set; }

        [EnumDataType(typeof(Category))]
        public Category Category { get; set; }
        public string Author { get; set; }
        public DateTime PublishingDate { get; set; }
        public int DownloadingCount { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public virtual ICollection<SubscriptionContent> SubscriptionContents { get; set; }
        public virtual ICollection<UserContent> UserContents { get; set; }

    }
}

