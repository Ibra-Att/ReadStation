using static ReadStation.Helper.Enums.Enums;
using System.ComponentModel.DataAnnotations;

namespace ReadStation.DTOs.Authenticator
{
    public class RegistrationDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }
        public string Password { get; set; }
      

    }
}
