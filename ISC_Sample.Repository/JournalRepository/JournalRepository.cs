using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using ISC_Sample.EntityFrameworkCore.ISCDbContextProject;
using Microsoft.EntityFrameworkCore;

namespace ISC_Sample.Repository.JournalRepository
{
    public class JournalRepository : IJournalRepository
    {
        private readonly IscDbContext _dbContext;

        public JournalRepository(IscDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Journal>> GetJournalListAsync()
        {
            return await _dbContext.Journals.ToListAsync();
        }

        public async Task<Journal> GetJournalByIdAsync(int id)
        {
            return await _dbContext.Journals.Where(it => it.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Journal> AddJournalAsync(Journal journal)
        {
            var result = _dbContext.Journals.Add(journal);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateJournalAsync(Journal journal)
        {
            _dbContext.Journals.Update(journal);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteJournalAsync(int id)
        {
            var filteredData = _dbContext.Journals.Where(it => it.Id == id).FirstOrDefault();
            if (filteredData != null) _dbContext.Journals.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }
    }
}