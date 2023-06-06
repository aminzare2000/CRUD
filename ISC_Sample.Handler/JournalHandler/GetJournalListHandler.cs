using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using ISC_Sample.Queries.JournalQueries;
using MediatR;

namespace ISC_Sample.Handler.JournalHandler;

public class GetJournalListHandler : IRequestHandler<GetJournalListQuery, List<Journal>>
{
    private readonly IJournalRepository _journalRepository;

    public GetJournalListHandler(IJournalRepository journalRepository)
    {
        _journalRepository = journalRepository;
    }

    public async Task<List<Journal>> Handle(GetJournalListQuery query, CancellationToken cancellationToken)
    {
        return await _journalRepository.GetJournalListAsync();
    }
}