using e2e.Model;

namespace e2e.Services
{
    public interface IMasterDoc
    {
        Task<MasterDocument?> GetMasterDocumentAsync(Guid id);
    }
}
