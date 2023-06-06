using MediatR;

namespace ISC_Sample.Command.OrganizationCommand;

public class DeleteOrganizationCommand : IRequest<int>
{
    public int Id { get; set; }
}