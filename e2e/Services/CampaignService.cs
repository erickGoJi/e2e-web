using e2e.Data;
using e2e.Model;
using Microsoft.EntityFrameworkCore;

namespace e2e.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationDbContext _context;

        public CampaignService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Campaign? GetCampaignId(Guid id)
        {
            var campaign = _context.Campaigns.Find(id);
            return campaign != null ? campaign : null;
        }

        public async Task<List<Campaign>> GetCampaignsAsync()
        {
            return await _context.Campaigns.ToListAsync();
        }
    }
}
