using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using ISC_Sample.Queries.JournalQueries;
using ISC_Sample.Queries.OrganizationQueries;
using MediatR;

namespace ISC_Sample.Handler.OrganizationHandler;

public class GetOrganizationListHandler : IRequestHandler<GetOrganizationListQuery, List<Organization>>
{
    private readonly IOrganizationRepository _organizationRepository;

    public GetOrganizationListHandler(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<List<Organization>> Handle(GetOrganizationListQuery query, CancellationToken cancellationToken)
    {
        return await _organizationRepository.GetOrganizationListAsync();
    }
}