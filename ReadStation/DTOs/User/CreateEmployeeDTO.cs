namespace ReadStation.DTOs.User
{
    public class CreateEmployeeDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }
        public string Password { get; set; }
        public int? DepartmentId { get; set; }
        public string? JobTitle { get; set; }
        public float? Salary { get; set; }

    }
}
