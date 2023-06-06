using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ISC_Sample.Domain.Entity;
using ISC_Sample.EntityFrameworkCore.ISCDbContextProject;

namespace ISC_Sample.Test.Journal_Test
{
    [TestClass]
    public class JournalTest
    {
        #region ConfigurationRoot

        // to have the same Configuration object as in Startup
        private readonly IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<IscDbContext> _options;

        #endregion

        public JournalTest()
        {
            #region Configuration

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<IscDbContext>()
                //.UseSqlServer(_configuration.GetConnectionString("ISCConnectionString"))
                .UseInMemoryDatabase(databaseName: "ISCDb")
                .Options;

            #endregion
        }

        private static List<Journal> CreateJournalsInitialize()
        {
            return new List<Journal>()
            {
                new Journal
                {
                    Title = "Developer",
                    Issn = 6543112561,
                    Email = "saadatahmad267@gmail.com",
                    WebSite = "AhmadSaadat.ir"
                },
                new Journal
                {
                    Title = "WebDeveloper",
                    Issn = 2615459,
                    Email = "saadatahmad5459@gmail.com",
                    WebSite = "AhmadZare.ir"
                },
                new Journal
                {
                    Title = "DotnetDeveloper",
                    Issn = 1613158,
                    Email = "saadatahmad3158@gmail.com",
                    WebSite = "Alireza.ir"
                },
                new Journal
                {
                    Title = "FullStackDeveloper",
                    Issn = 4075598,
                    Email = "Ahmadi1234@gmail.com",
                    WebSite = "Ahmadi.ir"
                },
                new Journal
                {
                    Title = "Tester",
                    Issn = 1613158,
                    Email = "ArashAhmadi@gmail.com",
                    WebSite = "ArashAhmadi.ir"
                },
            };
        }

        private static void DeleteJournal(IscDbContext _dbContext)
        {
            var journalId = _dbContext.Journals.Where(it => it.Id != null);
            _dbContext.Journals.RemoveRange(journalId);
            _dbContext.SaveChanges(true);
        }

        [TestMethod]
        public void Create_Read_Update_Delete_Journal()
        {
            using (var _dbContext = new IscDbContext(configuration: _configuration))
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();

                #region Assert_Step_One

                Assert.AreEqual(0, _dbContext.Journals.Count());

                #endregion

                #region Create_JournalList

                var journal1 = new Journal()
                {
                    Title = "Developer",
                    Issn = 6543112561,
                    Email = "saadatahmad267@gmail.com",
                    WebSite = "AhmadSaadat.ir"
                };
                var journal2 = new Journal()
                {
                    Title = "WebDeveloper",
                    Issn = 2615459,
                    Email = "saadatahmad5459@gmail.com",
                    WebSite = "AhmadZare.ir"
                };
                var journal3 = new Journal()
                {
                    Title = "DotnetDeveloper",
                    Issn = 1613158,
                    Email = "saadatahmad3158@gmail.com",
                    WebSite = "Alireza.ir"
                };

                #endregion

                #region Create_Journal_Test

                //Create Journal Test
                _dbContext.Journals.AddRange(journal1, journal2, journal3);
                _dbContext.SaveChanges();
                Assert.AreEqual(3, _dbContext.Journals.Count());

                #endregion

                #region Get_JournalList_Test

                //Get JournalList
                var getJournal = _dbContext.Journals.ToList();
                Assert.AreEqual(3, _dbContext.Journals.Count());
                Assert.IsTrue(getJournal.Any(it => it.Email == journal1.Email));
                Assert.IsTrue(getJournal.Any(it => it.Email == journal2.Email));
                Assert.IsTrue(getJournal.Any(it => it.WebSite == journal1.WebSite));
                Assert.IsTrue(getJournal.Any(it => it.Title == journal1.Title));

                #endregion

                #region Update _JournalList_Test

                //Update  JournalList
                var journalUpdate = _dbContext.Journals.FirstOrDefault(it => it.Id == 1);
                Assert.IsNotNull(journalUpdate);
                journalUpdate.Title = "WebDeveloper";
                journalUpdate.Issn = 123456789;
                journalUpdate.Email = "saadat999@outlook.com";
                journalUpdate.WebSite = "www.AhmadSaadat.ir";
                _dbContext.Journals.Update(journalUpdate);
                _dbContext.SaveChanges();

                #endregion

                #region List_After_Update_Test

                //get List After Update
                var getJournalAfterUpdate = _dbContext.Journals.ToList();
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.Title == "WebDeveloper"));
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.Issn == 123456789));
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.Email == "saadat999@outlook.com"));
                Assert.IsTrue(getJournalAfterUpdate.Any(it => it.WebSite == "www.AhmadSaadat.ir"));

                #endregion

                #region Delete_Journal_Test

                //Delete Journal List
                DeleteJournal(_dbContext);
                Assert.AreEqual(0, _dbContext.Journals.Count());

                #endregion
            }
        }
    }
}