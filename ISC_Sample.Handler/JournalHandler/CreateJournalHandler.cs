using ISC_Sample.Command.JournalCommand;
using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using MediatR;

namespace ISC_Sample.Handler.JournalHandler
{
    public class CreateJournalHandler : IRequestHandler<CreateJournalCommand, Journal>
    {
        private readonly IJournalRepository _journalRepository;

        public CreateJournalHandler(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<Journal> Handle(CreateJournalCommand command, CancellationToken cancellationToken)
        {
            var journal = new Journal()
            {
                Title = command.Title,
                Issn = command.Issn,
                WebSite = command.WebSite,
                Email = command.Email,
            };
            return await _journalRepository.AddJournalAsync(journal);
        }
    }
}