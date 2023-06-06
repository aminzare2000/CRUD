using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using ISC_Sample.Queries.JournalQueries;
using MediatR;

namespace ISC_Sample.Handler.JournalHandler;

public class GetJournalByIdHandler : IRequestHandler<GetJournalByIdQueries, Journal>
{
    private readonly IJournalRepository _journalRepository;

    public GetJournalByIdHandler(IJournalRepository journalRepository)
    {
        _journalRepository = journalRepository;
    }

    public async Task<Journal> Handle(GetJournalByIdQueries query, CancellationToken cancellationToken)
    {
        return await _journalRepository.GetJournalByIdAsync(query.Id);
    }
}