using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadStation.Context;
using ReadStation.DTOs.Content;
using ReadStation.DTOs.Subscription;
using ReadStation.DTOs.UserContent;
using ReadStation.Interfaces;
using ReadStation.Models.Entities;
using static ReadStation.Helper.Enums.Enums;

namespace ReadStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase, IClient
    {

        private readonly ReadStationDbContext _context;
        public ClientController(ReadStationDbContext context)
        {
            _context = context;
        }


        #region Action
        





        #region Get requests
        /// <summary>
        /// an action to return and filtering contents 
        /// </summary>
        /// <response code="200">Returns successfully returned</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetContentListAction(string? name, string? category, string? author)
        {
            try
            {
                var contents = await GetContentList(name, category, author);
                return Ok(new { Status = 200, Message = "Contents successfully appeared.", Contents = contents });


            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Failed to show Contents {e.Message}" }; }
        }
        #endregion

        #region Post requests
        /// <summary>
        /// an action to Subscribe in one of the memberships
        /// </summary>
        /// <response code="201">Returns Subscribe created</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        ///    {
        /// "promotion": 1,// 1 means 100% of the price or no promotion
        /// "price": 4.99,
        /// "durationInMonths": 1,
        /// "downloadCounter": 1,
        /// "membershipCounter": 1,
        /// "userId": 4,
        /// "membershipTier": "Standard"// the name of membership
        /// }
        /// </remarks>

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> BuySubscriptionAction(BuySubscriptionDTO dto)
        {
            try
            {
                await BuySubscription(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "WOOHOO! Successfully Subscribed" };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"Subscription Failed {e.Message}" }; }
        }

        /// <summary>
        /// an action to let a user download a content (if he is already subscribed)
        /// </summary>
        /// <response code="200">Returns successfully downloaded</response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="503">Server is Un Available</response>   
        /// <remarks>
        /// Sample request:
        /// {
        ///   "contentCounter": 1,
        ///   "isActive": true,
        ///   "userId": 1, // must be listed the UserSubscription 
        ///   "contentId": 2
        /// }
        /// </remarks>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ContentDownloadAction(DownloadContentDTO dto)
        {
            try
            {
                await ContentDownload(dto);
                return new ObjectResult(null) { StatusCode = 200, Value = "WOOHOO! Successfully Downloaded" };

            }

            catch (Exception e)

            { return new ObjectResult(null) { StatusCode = 500, Value = $"OOPPs): Downloading Failed {e.Message}" }; }
        }


        #endregion
        #region Put requests

        #endregion
        #region Delete requests

        #endregion



        #endregion



        #region Implementations
        [NonAction]
        public async Task BuySubscription(BuySubscriptionDTO dto)
        {
            
            UserSubscription userSub =new UserSubscription();
            var entity = await _context.Subscriptions
    .Where(s => s.MembershipTier == Enum.Parse<Membership>(dto.MembershipTier))
    .FirstOrDefaultAsync();

            if (entity != null)
            {
                
                userSub.Subscription = entity;
                
            }
            else
            {
                // Handle the case where the Subscription with the specified MembershipTier is not found
                throw new Exception($"Subscription with MembershipTier '{dto.MembershipTier}' not found");
            }
            userSub.Subscription = entity;
            userSub.User = await _context.Users.FindAsync(dto.UserId);
            userSub.IsActive = true;
            userSub.MembershipCounter = 1;
            var priceTrace = await _context.Subscriptions.Where(x => x.MembershipTier == entity.MembershipTier)
                 .FirstOrDefaultAsync();
            userSub.Price = priceTrace.PricePerMonth;
            userSub.Promotion = dto.Promotion;
            userSub.DurationInMonths = dto.DurationInMonths;
            var periodPrice = userSub.DurationInMonths * userSub.Price;
            userSub.NetPrice = periodPrice - (periodPrice * userSub.Promotion);
            userSub.SubscriptionDate=DateTime.Now;
            userSub.ExpiryDate = userSub.ExpiryDate = userSub.SubscriptionDate.AddMonths(userSub.DurationInMonths);
            
            await _context.AddAsync(userSub);
            await _context.SaveChangesAsync();



        }
        [NonAction]
        public async Task<List<ContentInfoDTO>> GetContentList(string? name, string? category, string? author)
        {


            Category foo = Category.None;
            if (Enum.TryParse<Category>(category, ignoreCase: true, out var parsedCategory))
            {
                foo = parsedCategory;
            }

            bool flag = name == null && category == null && author == null;

            var query = await (from c in _context.Contents
                               where c.Name.Contains(name)
                                   || c.Author.Contains(author)
                                   || c.Category == foo
                                   || flag
                               select new ContentInfoDTO
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Description = c.Description,
                                   PublishingDate = DateTime.Now,
                                   Author = c.Author,
                                   DownloadingCount = c.DownloadingCount,
                                   Category = c.Category.ToString(),
                                   ContentType = c.ContentType.ToString(),
                               }).ToListAsync();

            return query;


            //Category foo = Category.None;
            //if (Enum.TryParse<Category>(category, out var parsedCategory))
            //{
            //    foo = parsedCategory;
            //}

            //bool flag = name == null && category == null && author == null ? true : false;

            //var query = await (from c in _context.Contents
            //                   where c.Name.Contains(name)
            //                       || c.Author.Contains(author)
            //                       || c.Category == foo
            //                       || flag
            //                   select new ContentInfoDTO
            //                   {
            //                       Id = c.Id,
            //                       Name = c.Name,
            //                       Description = c.Description,
            //                       PublishingDate = DateTime.Now,
            //                       Author = c.Author,
            //                       DownloadingCount = c.DownloadingCount,
            //                       Category = c.Category.ToString(),
            //                       ContentType = c.ContentType.ToString(),
            //                   }).ToListAsync();

            //return query;


        }

        [NonAction]
        public async Task ContentDownload(DownloadContentDTO dto)
        {
            UserContent userCont = new UserContent();
            var contIdTrace = await _context.Contents.Where(c => c.Id == dto.ContentId).FirstOrDefaultAsync();
            var userIdTrace = await _context.UserSubscriptions.Include(us => us.User).Where(c => c.User.Id == dto.UserId).FirstOrDefaultAsync();

            if (userIdTrace != null)
            {
                //if UserSubscription record found, proceed with download
                userCont.User = userIdTrace.User;
                userCont.Content = contIdTrace;
                userCont.ContentCounter = dto.ContentCounter;
                userCont.IsActive = dto.IsActive;

                await _context.AddAsync(userCont);
                await _context.SaveChangesAsync();
            }
            else
            {
                // If UserSubscription record not found
                throw new Exception($"User with ID {dto.UserId} does not have a valid UserSubscription.");
            }




            //UserContent userCont = new UserContent();

            //var contIdTrace= await _context.Contents.Where(c => c.Id == dto.ContentId).FirstOrDefaultAsync();
            //var userIdTrace = await _context.UserSubscriptions.Where(c => c.User.Id == dto.UserId).FirstOrDefaultAsync();
            //userCont.User = userIdTrace.User;
            //userCont.Content = contIdTrace;
            //userCont.ContentCounter = dto.ContentCounter;
            //userCont.IsActive = dto.IsActive;

            //await _context.AddAsync(userCont);
            //await _context.SaveChangesAsync();

        }
        #endregion

    }
}
