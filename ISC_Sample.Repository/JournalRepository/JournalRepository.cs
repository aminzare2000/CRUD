using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using ISC_Sample.EntityFrameworkCore.ISCDbContextProject;

namespace ISC_Sample.Repository.JournalRepository
{
    public class JournalRepository : IJournalRepository
    {
        private readonly IscDbContext _dbContext;

        public JournalRepository(IscDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Journal>> GetJournalListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Journal> GetJournalByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Journal> AddJournalAsync(Journal journal)
        {
            var result = _dbContext.Journals.Add(journal);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<int> UpdateJournalAsync(Journal journal)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteJournalAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}