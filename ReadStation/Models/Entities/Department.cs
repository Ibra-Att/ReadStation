using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public DepartmentName DepartmentName { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public virtual ICollection<User> Users { get; set; }
    }
}
