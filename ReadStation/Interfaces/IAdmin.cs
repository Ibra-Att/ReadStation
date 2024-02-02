using ReadStation.DTOs.Authenticator;
using ReadStation.DTOs.Content;
using ReadStation.DTOs.Subscription;
using ReadStation.DTOs.User;
using ReadStation.Models.Entities;

namespace ReadStation.Interfaces
{
    public interface IAdmin
    {
        //Create Employee by adding there (first name , last name , email , phone , age , specialization , gender)
        Task AddEmployee(CreateEmployeeDTO dto);// done 100% 

        //Admin Shall be able to add another employee to system from different department 
        //Admin  Shall be able to add / update / delete any employee or coach and department and remember each department must have Arabic name and English name 
        Task UpdateEmployee(UpdateEmployeeDTO dto, int id); //done 100%

        //# Task AddDepartment and Update it

        //Admin shall be able to add / update / disactivate / reactivate subscription each subscriptions mush have (name , description , price , duration in day’s , Downloaded book amount)
        Task AddSubscription(CreateSubscriptionDTO dto);// done 100%
        Task UpdateSubscription(UpdateSubscriptionDTO dto, int id);// done 100%
        //Admin Can Add Another Admin and can update his name and password
        Task AddAdmin(CreateEmployeeDTO dto); // done 100% 
        Task UpdateAdmin(UpdateEmployeeDTO dto,int id); //done 90% except Gender as a name , recheck it



        //Admin Shall be able to add Content such as book , story , magazine by adding (name , price ,description , ContentType)
        Task AddContent(CreateContentDTO dto); //done 100% 
        Task UpdateContent(UpdateContentDTO dto, int id); //done 100%

        //Admin Shall be able to login via email and password 
        Task AdminLogin(AdminLoginDTO dto); // done 90% except chk if admin
    }
}
