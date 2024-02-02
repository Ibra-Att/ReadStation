using System.ComponentModel.DataAnnotations;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [EnumDataType(typeof(DepartmentName))]
        public DepartmentName DepartmentName { get; set; }
        [EnumDataType(typeof(DepartmentNameAr))]
        public DepartmentNameAr DepartmentNameAr { get; set; }
        public bool IsActive { get; set; }

        // Relationships
        public virtual ICollection<User> Users { get; set; }
    }
}
