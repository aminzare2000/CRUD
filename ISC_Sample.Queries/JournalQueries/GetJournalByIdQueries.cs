using ISC_Sample.Domain.Entity;
using MediatR;

namespace ISC_Sample.Queries.JournalQueries
{
    public class GetJournalByIdQueries : IRequest<Journal>
    {
        public int Id { get; set; }
    }
}