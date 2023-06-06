using ISC_Sample.Command.JournalCommand;
using ISC_Sample.Domain.Repository;
using MediatR;

namespace ISC_Sample.Handler.JournalHandler
{
    public class DeleteJournalHandler : IRequestHandler<DeleteJournalCommand, int>
    {
        private readonly IJournalRepository _journalRepository;

        public DeleteJournalHandler(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<int> Handle(DeleteJournalCommand command, CancellationToken cancellationToken)
        {
            var getJournal = await _journalRepository.GetJournalByIdAsync(command.Id);
            if (getJournal == null)
                throw new Exception(Resoure.ExceptionHandler.DeleteJournalCommandNull);
            return await _journalRepository.DeleteJournalAsync(getJournal.Id);
        }
    }
}