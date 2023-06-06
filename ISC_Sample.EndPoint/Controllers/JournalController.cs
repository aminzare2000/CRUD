using ISC_Sample.Command.JournalCommand;
using ISC_Sample.Domain.Entity;
using ISC_Sample.Queries.JournalQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISC_Sample.EndPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JournalController : ControllerBase
    {
        private readonly ILogger<JournalController> _logger;
        private readonly IMediator _mediator;


        public JournalController(ILogger<JournalController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateJournal")]
        public async Task<Journal> CreateJournalAsync(Journal journal)
        {
            var result = await _mediator.Send(new CreateJournalCommand(
                journal.Title,
                journal.Issn,
                journal.WebSite,
                journal.Email
            ));
            return result;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Journal> GetJournalById(int journalId)
        {
            var getJournal = await _mediator.Send(new GetJournalByIdQueries() { Id = journalId });
            return getJournal;
        }

        [HttpGet]
        [Route("GetListJournal")]
        public async Task<List<Journal>> GetJournalListAsync()
        {
            var journalList = await _mediator.Send(new GetJournalListQuery());
            return journalList;
        }

        [HttpDelete]
        [Route("DeleteJournal")]
        public async Task<int> DeleteJournal(int id)
        {
            return await _mediator.Send(new DeleteJournalCommand() { Id = id });
        }

        [HttpPut]
        [Route("UpdateJournal")]
        public async Task<int> UpdateCustomerAsync(Journal journal)
        {
            var isJournalUpdated = await _mediator.Send(new UpdateJournalCommand(
                journal.Title,
                journal.Issn,
                journal.WebSite,
                journal.Email
            ));
            return isJournalUpdated;
        }
    }
}