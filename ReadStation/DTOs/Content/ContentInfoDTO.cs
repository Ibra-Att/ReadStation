namespace ReadStation.DTOs.Content
{
    public class ContentInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ContentType { get; set; }
        public string Category { get; set; }
        public int DownloadingCount { get; set; }
        public DateTime PublishingDate { get; set; }


    }
}
