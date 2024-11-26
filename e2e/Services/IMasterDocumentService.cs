using e2e.Model;
using e2e.Shared;

namespace e2e.Services
{
    public interface IMasterDocumentService
    {
        Task<GeneralModel> GetMasterDocumentsByCampaignID(Guid id, string participant, string participantName, string area);
        Task AddGeneralSectionAsync(GeneralModel model, Guid campaignId, string participant, string participantName, string area);
        Task UpdateGeneralAsync(GeneralModel model, Guid campaignId, string participant, string participantName, string area);
    }
}
