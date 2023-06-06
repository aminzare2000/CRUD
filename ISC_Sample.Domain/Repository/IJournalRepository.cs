using ISC_Sample.Domain.Entity;

namespace ISC_Sample.Domain.Repository
{
    public interface IJournalRepository
    {
        Task<List<Journal>> GetJournalListAsync();
        Task<Journal> GetJournalByIdAsync(int id);
        Task<Journal> AddJournalAsync(Journal journal);
        Task<int> UpdateJournalAsync(Journal journal);
        Task<int> DeleteJournalAsync(int id);
    }
}