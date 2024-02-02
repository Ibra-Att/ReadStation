using System.ComponentModel.DataAnnotations;
using static ReadStation.Helper.Enums.Enums;
namespace ReadStation.Models.Entities

{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
       
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int? DepartmentId { get; set; }
        public string? JobTitle { get; set; }
        public float? Salary { get; set; }
        public bool IsActive { get; set; }


        // Relationships
        public virtual UserType UserType { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
        public virtual ICollection<UserContent> UserContents { get; set; }

    }
}

 



