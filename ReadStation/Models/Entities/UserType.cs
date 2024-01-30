namespace ReadStation.Models.Entities
{
    public class UserType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
