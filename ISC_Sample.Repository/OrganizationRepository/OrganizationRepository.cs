using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using ISC_Sample.EntityFrameworkCore.ISCDbContextProject;
using Microsoft.EntityFrameworkCore;

namespace ISC_Sample.Repository.OrganizationRepository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IscDbContext _dbContext;

        public OrganizationRepository(IscDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Organization>> GetOrganizationListAsync()
        {
            return await _dbContext.Organizations.ToListAsync();
        }

        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            return await _dbContext.Organizations.Where(it => it.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Organization> AddOrganizationAsync(Organization organization)
        {
            var result = _dbContext.Organizations.Add(organization);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateOrganizationAsync(Organization organization)
        {
            _dbContext.Organizations.Update(organization);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteOrganizationAsync(int id)
        {
            var filteredData = _dbContext.Organizations.Where(it => it.Id == id).FirstOrDefault();
            if (filteredData != null) _dbContext.Organizations.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }
    }
}