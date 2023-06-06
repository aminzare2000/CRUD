using ISC_Sample.Domain.Entity;
using MediatR;

namespace ISC_Sample.Queries.OrganizationQueries
{
    public class GetOrganizationListQuery : IRequest<List<Organization>>
    {
    }
}