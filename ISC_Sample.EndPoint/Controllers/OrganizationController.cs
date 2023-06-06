using ISC_Sample.Command.JournalCommand;
using ISC_Sample.Command.OrganizationCommand;
using ISC_Sample.Domain.Entity;
using ISC_Sample.Queries.JournalQueries;
using ISC_Sample.Queries.OrganizationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISC_Sample.EndPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IMediator _mediator;


        public OrganizationController(ILogger<OrganizationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateOrganization")]
        public async Task<Organization> CreateOrganizationAsync(Organization organization)
        {
            var result = await _mediator.Send(new CreateOrganizationCommand(
                organization.OrganizationName,
                organization.Depart1,
                organization.Depart2,
                organization.Depart3
            ));
            return result;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Organization> GetOrganizationById(int organizationId)
        {
            var getOrganization = await _mediator.Send(new GetOrganizationByIdQueries() { Id = organizationId });
            return getOrganization;
        }

        [HttpGet]
        [Route("GetListOrganization")]
        public async Task<List<Organization>> GetOrganizationListAsync()
        {
            var organizationList = await _mediator.Send(new GetOrganizationListQuery());
            return organizationList;
        }

        [HttpDelete]
        [Route("DeleteOrganization")]
        public async Task<int> DeleteOrganization(int id)
        {
            return await _mediator.Send(new DeleteOrganizationCommand() { Id = id });
        }

        [HttpPut]
        [Route("UpdateOrganization")]
        public async Task<int> UpdateOrganizationAsync(Organization organization)
        {
            var isOrganizationUpdated = await _mediator.Send(new UpdateOrganizationCommand(
                organization.OrganizationName,
                organization.Depart1,
                organization.Depart2,
                organization.Depart3
            ));
            return isOrganizationUpdated;
        }
    }
}