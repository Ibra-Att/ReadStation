using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadStation.Context;
using ReadStation.DTOs.Authenticator;
using ReadStation.DTOs.Content;
using ReadStation.DTOs.Subscription;
using ReadStation.DTOs.User;
using ReadStation.Interfaces;
using ReadStation.Models.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdmin
    {
        private readonly ReadStationDbContext _context;
        public AdminController(ReadStationDbContext context)
        {
            _context = context;
        }


        #region Action










        #region Get requests

        #endregion

        #region Post requests

        /// <summary>
        /// an action to Create a new  Admin
        /// </summary>
        /// <response code="201">Returns Admin created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// {
        ///"fullName": "Mohammad Mahmoud",
        ///"email": "Moh89@yahoo.com",
        ///"phone": "00962797416933",
        ///"age": 35,
        ///"birthdate": "1989-01-31",
        ///"gender": "Male",         //or Female
        ///"password": "wqeqwjhkkj32",
        ///"departmentId": 0,        // u can keep it null
        ///"jobTitle": "string",    // u can keep it null
        ///"salary": 0              // u can keep it null
        ///      }
    /// </remarks>
    [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAdminAction(CreateEmployeeDTO dto)
        {
            try
            {
                await AddAdmin(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Admin Successfully added " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Operation Failed  {e.Message}" }; }
        }
        /// <summary>
        /// an action to add a new Content
        /// </summary>
        /// <response code="201">Returns  created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        ///    
        ///     ContentType 
     ///      {
     ///      None = 1000,
     ///      Book = 0,
     ///      AudioBook,
     ///      Magazine,
     ///      Manga,
     ///       }
     ///  Category
     ///    {
     ///      None = 1000,
     ///      Nonfiction = 0,
     ///      Documentary ,
     ///      Scientific,
     ///      Sport,
     ///      Novel,
     ///      Action,
     ///      Comedy,
     ///      Romance,
     ///     }
      /// </remarks>

[HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddContentAction(CreateContentDTO dto)
        {
            try
            {
                await AddContent(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Content Successfully added " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Operation Failed  {e.Message}" }; }
        }
        /// <summary>
        /// an action to Create a new Employee
        /// </summary>
        /// <response code="201">Returns  created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// Sample request:
        /// {
        ///"fullName": "Mohammad Mahmoud",
        ///"email": "Moh89@yahoo.com",
        ///"phone": "00962797416933",
        ///"age": 35,
        ///"birthdate": "1989-01-31",
        ///"gender": "Male",         //or Female
        ///"password": "wqeqwjhkkj32",
        ///"departmentId": 1,        
        ///"jobTitle": "sales agent",    
        ///"salary": 260             
        ///      }
        /// </remarks>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddEmployeeAction(CreateEmployeeDTO dto)
        {
            try
            {
                await AddEmployee(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Employee Successfully added " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Operation Failed  {e.Message}" }; }
        }
        /// <summary>
        /// an action to add a new Subscription
        /// </summary>
        /// <response code="201">Returns Successfully added</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///    sample
        ///     {        
        ///       "membershipTier": "Economy",
        ///       "description": "budget", 
        ///       "pricePerMonth": 4.99,
        ///       "downloadableContentPerMonth" :15,
        ///       "durationInDays":30
        ///     }
        /// </remarks>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddSubscriptionAction(CreateSubscriptionDTO dto)
        {
            try
            {
                await AddSubscription(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Subscription Successfully added " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Operation Failed  {e.Message}" }; }
        }
        /// <summary>
        /// an action to let existed admin login
        /// </summary>
        /// <response code="200">Returns done</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///      sample
        ///     {        
        ///       
        ///       "Email": "ibraatt@gmail.com", 
        ///       "Password": "ABC12345",
        ///      
        ///     }
        /// </remarks>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AdminLoginAction(AdminLoginDTO dto)
        {
            try
            {
                await AdminLogin(dto);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully Login  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Login Failed {e.Message}" }; }
        }



        #endregion
        #region Put requests

        /// <summary>
        /// an action Update existed Admin's account
        /// </summary>
        /// <response code="200">Returns user created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///      sample
        ///    {
        ///"fullName": "Mohammad Mahmoud",
        ///"email": "Moh89@yahoo.com",
        ///"phone": "00962797416933",
        ///"age": 35,
        ///"birthdate": "1989-01-31",
        ///"gender": "Male",         //or Female
        ///"password": "wqeqwjhkkj32",
        ///"departmentId": 0,        // u can keep it null
        ///"jobTitle": "string",    // u can keep it null
        ///"salary": 0,              // u can keep it null
        ///"isActive": true
        ///      }
        /// </remarks>

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateAdminAction(UpdateEmployeeDTO dto, int id)
        {
            try
            {
                await UpdateAdmin(dto, id);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully updated  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"update Failed {e.Message}" }; }
        }
        /// <summary>
        /// an action to Update an existed Content
        /// </summary>
        /// <response code="200">Returns updated</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///      sample:
        ///     {        
        ///       "name": ""One Piece",",
        ///       "description": "Anime about pirates",
        ///       "contentType": "Manga",
        ///       "category": "Action",
        ///       "author": "EIICHIRO ODA",
        ///       "publishingDate": "1997-07-22",
        ///       "downloadingCount": 1,
        ///       "isActive": true
        ///
        ///     }
        /// </remarks>

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateContentAction(UpdateContentDTO dto, int id)
        {
            try
            {
                await UpdateContent(dto, id);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully updated  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"update Failed {e.Message}" }; }
        }
        /// <summary>
        /// an action to Update existed Employee 
        /// </summary>
        /// <response code="200">Returns user created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///      sample
        ///    {
        ///"fullName": "Mohammad Mahmoud",
        ///"email": "Moh89@yahoo.com",
        ///"phone": "00962797416933",
        ///"age": 35,
        ///"birthdate": "1989-01-31",
        ///"gender": "Male",         //or Female
        ///"password": "wqeqwjhkkj32",
        ///"departmentId": 1,        // u can keep it null
        ///"jobTitle": "market agent",    // u can keep it null
        ///"salary": 350,              // u can keep it null
        ///"isActive": true
        ///      }
        /// </remarks>

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateEmployeeAction(UpdateEmployeeDTO dto, int id)
        {
            try
            {
                await UpdateEmployee(dto, id);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully updated  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"update Failed {e.Message}" }; }
        }
        /// <summary>
        /// an action to Update existed Subscription
        /// </summary>
        /// <response code="200">Returns updated</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// 
        ///    sample
        ///     {        
        ///       "membershipTier": "Economy",
        ///       "description": "budget", 
        ///       "pricePerMonth": 4.99,
        ///       "downloadableContentPerMonth" :15,
        ///       "durationInDays":30,
        ///       "isActive":true
        ///     }
        /// </remarks>

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateSubscriptionAction(UpdateSubscriptionDTO dto, int id)
        {
            try
            {
                await UpdateSubscription(dto, id);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully updated  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"update Failed {e.Message}" }; }
        }


        #endregion
        #region Delete requests

        /// <summary>
        ///  Delete any existed User, just enter his/her id
        /// </summary>
        /// <response code="200">Returns deleted</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        [HttpDelete]
        [Route("[action]/{id}")]

        public async Task<IActionResult> DeleteUserAction(int id)
        {
            try
            {
                await DeleteUser (id);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully deleted  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"delete Failed {e.Message}" }; }

        }
        /// <summary>
        ///  Delete any existed Subscription, just enter it's id
        /// </summary>
        /// <response code="200">Returns deleted</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteSubscriptionAction(int id)
        {
            try
            {
                await DeleteSubscription(id);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully deleted  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"delete Failed {e.Message}" }; }
        }
        /// <summary>
        ///  Delete any existed Content, just enter it's id
        /// </summary>
        /// <response code="200">Returns deleted</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteContentAction(int id)
        {
            try
            {
                await DeleteContent(id);
                return new ObjectResult(null) { StatusCode = 200, Value = " Successfully deleted  " };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"delete Failed {e.Message}" }; }
        }


        #endregion



        #endregion



        #region Implementations
        [NonAction]
        public async Task AddAdmin(CreateEmployeeDTO dto)
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
            user.RegistrationDate=DateTime.Now;

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
            user.UserType = await _context.UserTypes.FirstOrDefaultAsync(x => x.TypeName == "Admin");
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        [NonAction]
        public async Task AddContent(CreateContentDTO dto)
        {
            Content content = new Content();
            content.Name = dto.Name;
            content.Description = dto.Description;
            content.Author = dto.Author;
            content.PublishingDate = dto.PublicationDate;
            content.DownloadingCount = 1;
            if (Enum.TryParse(dto.ContentType, out ContentType cont))
            {
                content.ContentType = cont;
            }
            else
            {
                throw new Exception("Invalid ContentType value Make sure it's one of the listed in the Enum\"");
            }
            if (Enum.TryParse(dto.Category, out Category cat))
            {
                content.Category = cat;
            }
            else
            {
                throw new Exception("Invalid Category value Make sure it's one of the listed in the Enum");
            }
            await _context.AddAsync(content);
            await _context.SaveChangesAsync();
        }

        [NonAction]
        public async Task AddEmployee(CreateEmployeeDTO dto)
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
            user.JobTitle = dto.JobTitle;
            user.Salary = dto.Salary;
            user.DepartmentId = dto.DepartmentId;
            user.RegistrationDate=DateTime.Now;

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
            user.UserType = await
            _context.UserTypes.FirstOrDefaultAsync(x => x.TypeName == "Employee");
            user.Department = await
           _context.Departments.FirstOrDefaultAsync(x => x.Id == dto.DepartmentId);
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        [NonAction]
        public async Task AddSubscription(CreateSubscriptionDTO dto)
        {
            Subscription subscription = new Subscription();
            subscription.Description = dto.Description;
            subscription.PricePerMonth = dto.PricePerMonth;
            subscription.DownloadableContentPerMonth = dto.DownloadableContentPerMonth;
           // subscription.DurationInDays=int(dto.DurationInDays);
            if (Enum.IsDefined(typeof(DurationInDays), dto.DurationInDays))
            {
                subscription.DurationInDays = (DurationInDays)dto.DurationInDays;
            }
            else
            {
                throw new ArgumentException("Invalid DurationInDays value");
            }
            if (Enum.TryParse(dto.MembershipTier, out Membership mem))
            {
                subscription.MembershipTier = mem;
            }
            else
            {
                throw new Exception("Invalid Membership value Make sure it's one of the listed in the Enum");

            }
            await _context.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        [NonAction]
        public async Task AdminLogin(AdminLoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                throw new Exception("Both Email and Password are required");
            var login = await _context.Users
                 .Where(x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password))
                 .SingleOrDefaultAsync();
            if (login == null)
            {
                throw new Exception("Email Or Password Is InCorrect");
            }

        }

        [NonAction]
        public async Task UpdateAdmin(UpdateEmployeeDTO dto, int id)
        {
            var query = await _context.Users.FindAsync(id);

            if (query != null)
            {
                query.FullName = dto.FullName;
                query.Email = dto.Email;
                query.Password = dto.Password;
                query.Age = dto.Age;
                query.Phone = dto.Phone;
                query.Birthdate = dto.Birthdate;
                query.IsActive = dto.IsActive;
                //query.Gender = dto.Gender;
                if (Enum.TryParse<Gender>(dto.Gender, out var gender))
                {
                    query.Gender = gender;
                }
                else
                {
                    throw new ArgumentException("Invalid gender value");
                }

                _context.Update(query);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the user with the specified ID is not found
                throw new Exception($"User with ID {id} not found");
            }


        }

        [NonAction]
        public async Task UpdateContent(UpdateContentDTO dto, int id)
        {
            var query = await _context.Contents.FindAsync(id);

            if (query != null)
            {
                query.Name = dto.Name;
                query.Description = dto.Description;
                query.ContentType = dto.ContentType;
                query.Category = dto.Category;
                query.Author = dto.Author;
                query.PublishingDate = dto.PublishingDate;
                query.DownloadingCount = dto.DownloadingCount;
                query.IsActive = dto.IsActive;

                _context.Update(query);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Content with ID {id} not found");
            }
        }

        [NonAction]
        public async Task UpdateEmployee(UpdateEmployeeDTO dto, int id)
        {
            var query = await _context.Users.FindAsync(id);

            if (query != null)
            {
                query.FullName = dto.FullName;
                query.Email = dto.Email;
                query.Password = dto.Password;
                query.Age = dto.Age;
                query.Phone = dto.Phone;
                query.Birthdate = dto.Birthdate;
                if (Enum.TryParse<Gender>(dto.Gender, out var gender))
                {
                    query.Gender = gender;
                }
                else
                {
                    throw new ArgumentException("Invalid gender value");
                }
                query.DepartmentId = dto.DepartmentId;
                query.JobTitle = dto.JobTitle;
                query.Salary = dto.Salary;
                query.IsActive = dto.IsActive;

                _context.Update(query);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the user with the specified ID is not found
                throw new Exception($"User with ID {id} not found");
            }
        }

        [NonAction]
        public async Task UpdateSubscription(UpdateSubscriptionDTO dto, int id)
        {
            var query = await _context.Subscriptions.FindAsync(id);

            if (query != null)
            {
                if (Enum.TryParse(dto.MembershipTier, out Membership mem))
                {
                    query.MembershipTier = mem;
                }
                else
                {
                    throw new Exception("Invalid Membership value Make sure it's one of the listed in the Enum");

                }
                if (Enum.IsDefined(typeof(DurationInDays), dto.DurationInDays))
                {
                    query.DurationInDays = (DurationInDays)dto.DurationInDays;
                }
                else
                {
                    throw new ArgumentException("Invalid DurationInDays value");
                }
                query.PricePerMonth = dto.PricePerMonth;
                query.Description = dto.Description;
                query.DownloadableContentPerMonth = dto.DownloadableContentPerMonth;
                query.IsActive = dto.IsActive;

                _context.Update(query);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Subscription with ID {id} not found");
            }
        }
        [NonAction]
        public async Task DeleteUser(int id)
        {

            var entity = await _context.Users.FindAsync(id);
            
            _context.Remove(entity);
            await _context.SaveChangesAsync();


        }
        [NonAction]

        public async Task DeleteSubscription(int id)
        {
            var entity = await _context.Subscriptions.FindAsync(id);

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        [NonAction]

        public async Task DeleteContent(int id)
        {
            var entity = await _context.Contents.FindAsync(id);

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }




        #endregion


    }
}