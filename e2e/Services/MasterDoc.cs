using e2e.Data;
using e2e.Model;
using Microsoft.EntityFrameworkCore;

namespace e2e.Services
{
    public class MasterDoc : IMasterDoc
    {
        private readonly ApplicationDbContext _context;

        public MasterDoc(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MasterDocument?> GetMasterDocumentAsync(Guid id)
        {
            return await _context.MasterDocuments.FirstOrDefaultAsync(x => x.CampaignId.Equals(id));
        }
    }
}
