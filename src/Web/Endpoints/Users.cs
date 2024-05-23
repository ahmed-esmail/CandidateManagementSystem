using CandidateManagementSystem.Infrastructure.Identity;

namespace CandidateManagementSystem.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
