using ISC_Sample.Domain.Entity;
using ISC_Sample.EntityFrameworkCore.ISCDbContextProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC_Sample.Test.Organization_Test
{
    [TestClass]
    public class OrganizationTest
    {
        #region ConfigurationRoot

        // to have the same Configuration object as in Startup
        private readonly IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<IscDbContext> _options;

        #endregion

        public OrganizationTest()
        {
            #region Configuration

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<IscDbContext>()
                .UseInMemoryDatabase(databaseName: "ISCDb")
                .Options;

            #endregion
        }


        private static List<Organization> CreateOrganizationInitialize()
        {
            return new List<Organization>()
            {
                new Organization()
                {
                    OrganizationName = "ISC_Org",
                    Depart1 = "Computer",
                    Depart2 = "Software",
                    Depart3 = "Program"
                },
                new Organization()
                {
                    OrganizationName = "ISC_Org",
                    Depart1 = "Computer",
                    Depart2 = "Hardware",
                    Depart3 = "Network+"
                },
            };
        }

        private static void DeleteOrganization(IscDbContext _dbContext)
        {
            var orgId = _dbContext.Organizations.Where(it => it.Id != null);
            _dbContext.Organizations.RemoveRange(orgId);
            _dbContext.SaveChanges(true);
        }

        [TestMethod]
        public void Create_Read_Update_Delete_Organization()
        {
            using (var _dbContext = new IscDbContext(configuration: _configuration))
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();

                #region Assert_Step_One

                Assert.AreEqual(0, _dbContext.Journals.Count());

                #endregion

                #region Create_OrganizationList

                var organization1 = new Organization()
                {
                    OrganizationName = "ISC_Org",
                    Depart1 = "Computer",
                    Depart2 = "Software",
                    Depart3 = "Program"
                };
                var organization2 = new Organization()
                {
                    OrganizationName = "ISC_Org",
                    Depart1 = "Computer",
                    Depart2 = "Hardware",
                    Depart3 = "Network+"
                };

                #endregion

                #region Create_Organization_Test

                //Create Organization Test
                _dbContext.Organizations.AddRange(organization1,organization2);
                _dbContext.SaveChanges();
                Assert.AreEqual(2, _dbContext.Organizations.Count());

                #endregion

                #region Get_OrganizationList_Test

                //Get OrganizationList
                var getOrganization = _dbContext.Organizations.ToList();
                Assert.AreEqual(2, _dbContext.Organizations.Count());
                Assert.IsTrue(getOrganization.Any(it => it.OrganizationName == organization1.OrganizationName));
                Assert.IsTrue(getOrganization.Any(it => it.Depart1 == organization1.Depart1));
                Assert.IsTrue(getOrganization.Any(it => it.Depart2 == organization2.Depart2));
                Assert.IsTrue(getOrganization.Any(it => it.Depart3 == organization2.Depart3));

                #endregion

                #region Update _JournalList_Test

                //Update  OrganizationList
                var organizationUpdate = _dbContext.Organizations.FirstOrDefault(it => it.Id == 1);
                Assert.IsNotNull(organizationUpdate);
                organizationUpdate.OrganizationName = "ISCOrganization";
                organizationUpdate.Depart1 = "Adabiat";
                organizationUpdate.Depart2 = "Persian";
                organizationUpdate.Depart3 = "FarhanghLoghat";
                _dbContext.Organizations.Update(organizationUpdate);
                _dbContext.SaveChanges();

                #endregion

                #region List_After_Update_Test

                //get List After Update
                var getJournalAfterUpdate = _dbContext.Organizations.ToList();
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.OrganizationName == "ISCOrganization"));
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.Depart1 == "Adabiat"));
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.Depart2 == "Persian"));
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.Depart3 == "FarhanghLoghat"));

                #endregion

                #region Delete_Organization_Test

                //Delete Organization List
                DeleteOrganization(_dbContext);
                Assert.AreEqual(0, _dbContext.Organizations.Count());

                #endregion
            }
        }
    }
}