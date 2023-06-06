using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC_Sample.Domain.Entity;
using MediatR;

namespace ISC_Sample.Queries.JournalQueries
{
    public class GetJournalListQuery : IRequest<List<Journal>>
    {
    }
}