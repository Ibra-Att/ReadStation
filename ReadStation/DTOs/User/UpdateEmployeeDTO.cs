using System.Text.Json.Serialization;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.DTOs.User
{
    public class UpdateEmployeeDTO
    {
        //    [JsonIgnore] 
        //    public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public int? DepartmentId { get; set; }
        public string? JobTitle { get; set; }
        public float? Salary { get; set; }
        public bool IsActive { get; set; }
        // public string Specialization { get; set; }

    }
}
