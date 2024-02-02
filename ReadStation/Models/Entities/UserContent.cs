namespace ReadStation.Models.Entities
{
    public class UserContent
    {
        public int Id { get; set; }
        public int ContentCounter { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public virtual Content Content { get; set; }

    }
}
