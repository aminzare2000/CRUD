using ISC_Sample.Domain.Entity;
using MediatR;

namespace ISC_Sample.Queries.JournalQueries
{
    public class GetJournalListQuery : IRequest<List<Journal>>
    {
    }
}