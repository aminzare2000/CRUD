using MediatR;

namespace ISC_Sample.Command.OrganizationCommand
{
    public class UpdateOrganizationCommand : IRequest<int>
    {
        public UpdateOrganizationCommand(string organizationName, string depart1, string depart2, string depart3)
        {
            OrganizationName = organizationName;
            Depart1 = depart1;
            Depart2 = depart2;
            Depart3 = depart3;
        }

        public string OrganizationName { get; set; }
        public string Depart1 { get; set; }
        public string Depart2 { get; set; }
        public string Depart3 { get; set; }
    }
}