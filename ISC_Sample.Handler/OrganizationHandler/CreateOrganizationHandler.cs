using ISC_Sample.Command.JournalCommand;
using ISC_Sample.Command.OrganizationCommand;
using ISC_Sample.Domain.Entity;
using ISC_Sample.Domain.Repository;
using MediatR;

namespace ISC_Sample.Handler.OrganizationHandler
{
    public class CreateOrganizationHandler : IRequestHandler<CreateOrganizationCommand, Organization>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public CreateOrganizationHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<Organization> Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            var organization = new Organization()
            {
                OrganizationName = command.OrganizationName,
                Depart1 = command.Depart1,
                Depart2 = command.Depart2,
                Depart3 = command.Depart3
            };
            return await _organizationRepository.AddOrganizationAsync(organization);
        }
    }
}