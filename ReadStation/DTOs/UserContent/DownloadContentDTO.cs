namespace ReadStation.DTOs.UserContent
{
    public class DownloadContentDTO
    {
        public int Id { get; set; }
        public int ContentCounter { get; set; } = 0;
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int ContentId { get; set; }
    }
}
