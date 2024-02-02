using ReadStation.DTOs.Authenticator;
using ReadStation.DTOs.Content;
using ReadStation.DTOs.Subscription;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Interfaces
{
    public interface IShared
    {
    


        //Client Shall be able to view all available subscriptions
        //Client Shall be able to search among available subscriptions via price , duration in date , and title 
        Task<List<SubscriptionInfoDTO>> ShowAllSubscriptions(float? pricePerMonth, string? durationInDays); // Incomplete 90%


        //Client Shall be able to view all available Books 
        Task<List<ContentInfoDTO>> ShowAllContents(); //done 100%

        //Client Shall be able to Create New Account by entering (email,password,phone,fullname,birthdate)
        Task CreateNewAccount(RegistrationDTO dto); // done 100%
        //Client Shall be able to login via Phone and password or using email and password
        Task Login(LoginDTO dto); // done 100%

        Task ResetPassword(ResetPasswordDTO dto); //done 100%



    }
}
