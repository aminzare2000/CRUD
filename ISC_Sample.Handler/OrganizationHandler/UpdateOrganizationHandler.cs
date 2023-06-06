using ISC_Sample.Command.JournalCommand;
using ISC_Sample.Domain.Repository;
using MediatR;

namespace ISC_Sample.Handler.OrganizationHandler
{
    public class UpdateOrganizationHandler : IRequestHandler<UpdateJournalCommand, int>
    {
        private readonly IJournalRepository _journalRepository;

        public UpdateOrganizationHandler(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<int> Handle(UpdateJournalCommand command, CancellationToken cancellationToken)
        {
            var journalInfo = await _journalRepository.GetJournalByIdAsync(command.Id);
            if (journalInfo == null)
            {
                throw new Exception(Resoure.ExceptionHandler.journalInfo_NotFound);
            }

            journalInfo.Title = command.Title;
            journalInfo.Issn = command.Issn;
            journalInfo.WebSite = command.WebSite;
            journalInfo.Email = command.Email;
            return await _journalRepository.UpdateJournalAsync(journalInfo);
        }
    }
}