using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.DTOs.Content
{
    public class UpdateContentDTO
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentType ContentType { get; set; }
        public Category Category { get; set; }
        public string Author { get; set; }
        public DateTime PublishingDate { get; set; }
        public int DownloadingCount { get; set; }
        public bool IsActive { get; set; }
    }
}
