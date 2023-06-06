using ISC_Sample.Domain.Entity;

namespace ISC_Sample.Domain.Repository
{
    public interface IOrganizationRepository
    {
        Task<List<Organization>> GetOrganizationListAsync();
        Task<Organization> GetOrganizationByIdAsync(int id);
        Task<Organization> AddOrganizationAsync(Organization organization);
        Task<int> UpdateOrganizationAsync(Organization organization);
        Task<int> DeleteOrganizationAsync(int id);
    }
}