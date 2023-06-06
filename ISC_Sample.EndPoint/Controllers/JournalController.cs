using ISC_Sample.Command.JournalCommand;
using ISC_Sample.Domain.Entity;
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
    }
}