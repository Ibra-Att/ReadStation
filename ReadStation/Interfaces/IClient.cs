using ReadStation.DTOs.Content;
using ReadStation.DTOs.Subscription;
using ReadStation.DTOs.UserContent;

namespace ReadStation.Interfaces
{
    public interface IClient
    {

        // try to filter on most demanding
        //Client Shall be able to search among available content via price , type  and title
        Task<List<ContentInfoDTO>> GetContentList(string? name,string? category, string? author); //done 100%

        //Client Shall be able to Registered in specific subscription 
        Task BuySubscription(BuySubscriptionDTO dto); // done 99% some extra features

        // add UserSubscriptionInfo function

        //Client Shall be able to download any book if and only if he have a subscription 
        Task ContentDownload(DownloadContentDTO dto); // done 100% 
        
    }
}
