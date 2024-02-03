using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadStation.Context;
using ReadStation.DTOs.Authenticator;
using ReadStation.DTOs.Content;
using ReadStation.DTOs.Subscription;
using ReadStation.Interfaces;
using ReadStation.Models.Entities;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase, IShared
    {

       private readonly ReadStationDbContext _context;
        public SharedController(ReadStationDbContext context)
        {
            _context = context;
        }








            #region Action

        #region Get requests

        /// <summary>
        /// an action to show all books and magazine...etc
        /// </summary>
        /// <response code="200">Returns contents read success</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ShowAllContentsAction()
        {
            try
            {
                var contents = await ShowAllContents();
                return Ok(new { Status = 200, Message = "All Contents successfully appeared.", Contents = contents });
            

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Failed to show All Contents {e.Message}" }; }
        }

        /// <summary>
        /// an action to show and filter the Subscriptions
        /// </summary>
        /// <response code="200">Returns done successfully</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> ShowAllSubscriptionsAction(float? pricePerMonth, string? durationInDays)
        {
             try
            {
                var contents = await ShowAllSubscriptions(pricePerMonth, durationInDays);
                return Ok(new { Status = 200, Message = "Subscriptions successfully appeared.", Contents = contents });


            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Failed to show Subscriptions {e.Message}" }; }
        }

        #endregion

        #region Post requests
        /// <summary>
        /// an action to Create a new user account
        /// </summary>
        /// <response code="201">Returns user created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///  CreateNewAccount sample
        ///  {        
        ///  "fullName": "Mohammad Maher",
        ///  "email": "Moh89@gmail.com",
        ///  "phone": "00962797416922",
        ///  "age": 35,
        ///  "birthdate": "1989-01-31",
        ///  "gender": "Male",
        ///  "password": "nwe202401"
        ///     }
        /// </remarks>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewAccountAction(RegistrationDTO dto)
        {
            try
            {
                await CreateNewAccount(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = " Successfully Registered " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Registration Failed {e.Message}" }; }
        }

        /// <summary>
        /// an action existed User login using either (Email & Pass) or (Phone & Pass) 
        /// </summary>
        /// <response code="200">Returns user created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///     Login sample
        ///     {        
        ///       "Name": "Ibra att",
        ///       "Email": "ibraatt@gmail.com", 
        ///       "Password": ABC12345,
        ///       "Phone" :"00962797458559"
        ///     }
        /// </remarks>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LoginAction(LoginDTO dto)
        {
            try
            {
                await Login(dto);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully Login  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Login Failed {e.Message}" }; }
        }

        #endregion

        #region Put requests

        /// <summary>
        /// an action to ResetPassword if user forgets his 
        /// </summary>
        /// <response code="200">Returns password successfully reset</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///     CreateNewAccount sample
        ///     {        
        ///       "email": "ibraatt@gmail.com",
        ///       "newPassword": "ABC12345", 
        ///       "confirmPassword": ABC12345,
        ///       "Phone" :"00962797458559"
        ///     }
        /// </remarks>

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ResetPasswordAction(ResetPasswordDTO dto)
        {
            try
            {
                await ResetPassword(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Password Successfully Reset" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"ResetPassword Failed {ex.Message}" };
            }
        }
            #endregion

            #region Delete requests


            #endregion


            #endregion


            #region Implementations

           


            [NonAction]
        public async Task CreateNewAccount(RegistrationDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email Is Required");
            if (string.IsNullOrEmpty(dto.Password))
                throw new Exception("Password Is Required");
            User user = new User();
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.FullName = dto.FullName;
            user.Phone = dto.Phone;
            user.Birthdate = dto.Birthdate;
            user.Age = dto.Age;
            user.RegistrationDate = DateTime.Now;

            // Parse the string value to the Gender enum
            if (Enum.TryParse(dto.Gender, out Gender gender))
            {
                user.Gender = gender;
            }
            else
            {
                throw new Exception("Invalid Gender value Make sure it's either Male or Female");
            }
            user.IsActive = true;
            user.UserType = await _context.UserTypes.FirstOrDefaultAsync(x => x.TypeName == "Client");
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        [NonAction]
        public async Task Login(LoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Password))
                throw new Exception("Password is required");

            if (string.IsNullOrEmpty(dto.Email) && string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Email or Phone is required");

            var login = await _context.Users
                .Where(x =>
                    (x.Password.Equals(dto.Password) && x.Email.Equals(dto.Email)) ||  // Email and Password
                    (x.Password.Equals(dto.Password) && x.Phone.Equals(dto.Phone))    // Password and Phone
                )
                .SingleOrDefaultAsync();

            if (login == null)
            {
                throw new Exception("Email, Password, or Phone is incorrect");
            }
        }

        [NonAction]
        public async Task ResetPassword(ResetPasswordDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Email and Phone are required");
            var user = await _context.Users.Where(x => x.Email.Equals(dto.Email)
            && x.Phone.Equals(dto.Phone)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                if (string.IsNullOrEmpty(dto.NewPassword) || string.IsNullOrEmpty(dto.ConfirmPassword))
                    throw new Exception("Password and ConfirmPassword are required");
                else
                {
                    if (dto.NewPassword.Equals(dto.ConfirmPassword))
                    {
                        user.Password = dto.ConfirmPassword;
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("NewPassword and ConfirmPassword do not match");
                    }
                }

            }

        }

        [NonAction]
        public async Task<List<ContentInfoDTO>> ShowAllContents()
        {
            var query = await (from c in _context.Contents
                               select new ContentInfoDTO
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Description = c.Description,
                                   DownloadingCount = c.DownloadingCount,
                                   Author=c.Author,
                                   Category = c.Category.ToString(),
                                   ContentType = c.ContentType.ToString(),

                               }).ToListAsync();
            return query;
             
        }

        [NonAction]
        public async Task<List<SubscriptionInfoDTO>> ShowAllSubscriptions(float? pricePerMonth, string? durationInDays)
        {

            DurationInDays foo = DurationInDays.None;
            if (Enum.TryParse<DurationInDays>(durationInDays, ignoreCase: true, out var parsedDurationInDays))
            {
                foo = parsedDurationInDays;
            }

            bool flag = pricePerMonth == null && durationInDays == null;

            var query = await (from s in _context.Subscriptions
                               where (s.PricePerMonth <= pricePerMonth || flag) &&
                                     (s.DurationInDays == foo || flag)
                               select new SubscriptionInfoDTO
                               {
                                   Id = s.Id,
                                   MembershipTier = s.MembershipTier.ToString(),
                                   Description = s.Description,
                                   DownloadableContentPerMonth = s.DownloadableContentPerMonth,
                                   PricePerMonth = s.PricePerMonth,
                                   DurationInDays = s.DurationInDays.ToString()
                               }).ToListAsync();

            return query;








            //DurationInDays foo = DurationInDays.None;

            //if (durationInDays.HasValue && Enum.IsDefined(typeof(DurationInDays), durationInDays))
            //{
            //    foo = (DurationInDays)durationInDays;
            //}

            //bool flag = pricePerMonth == null && durationInDays == null;

            //var query = await (from s in _context.Subscriptions
            //                   where (s.PricePerMonth <= pricePerMonth || flag)
            //                   select new SubscriptionInfoDTO
            //                   {
            //                       Id = s.Id,
            //                       MembershipTier = s.MembershipTier.ToString(),
            //                       Description = s.Description,
            //                       DownloadableContentPerMonth = s.DownloadableContentPerMonth,
            //                       PricePerMonth = s.PricePerMonth,
            //                       DurationInDays = s.DurationInDays.ToString()
            //                   }).ToListAsync();

            //return query;











            //DurationInDays foo = DurationInDays.None;
            //if (Enum.TryParse<DurationInDays>(durationInDays, out var parsedCategory))
            //{
            //    foo = parsedCategory;
            //}



            //bool flag = pricePerMonth == null && durationInDays == null  ? true : false;

            //var query = await (from s in _context.Subscriptions
            //                   where s.PricePerMonth <= pricePerMonth
            //                   || flag
            //                   select new SubscriptionInfoDTO
            //                   {
            //                       Id = s.Id,
            //                       MembershipTier = s.MembershipTier.ToString(),
            //                       Description = s.Description,
            //                       DownloadableContentPerMonth = s.DownloadableContentPerMonth,
            //                       PricePerMonth = s.PricePerMonth,
            //                       DurationInDays=s.DurationInDays.ToString()                            

            //                   }).ToListAsync();

            //return query;


        }
        #endregion
    }
}
