namespace ReadStation.DTOs.Content
{
    public class CreateContentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
