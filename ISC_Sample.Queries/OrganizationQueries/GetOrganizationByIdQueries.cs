using ISC_Sample.Domain.Entity;
using MediatR;

namespace ISC_Sample.Queries.OrganizationQueries
{
    public class GetOrganizationByIdQueries : IRequest<Organization>
    {
        public int Id { get; set; }
    }
}