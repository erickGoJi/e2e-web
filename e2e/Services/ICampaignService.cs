using e2e.Model;

namespace e2e.Services
{
    public interface ICampaignService
    {
        Campaign? GetCampaignId(Guid id);
        Task<List<Campaign>> GetCampaignsAsync();
    }
}
