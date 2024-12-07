using Web.Endpoint.Account.Api;

namespace Web.Endpoint.Account;

public static class AccountEndpoint
{
    public static void Map(RouteGroupBuilder routeGroup)
    {
        var api = routeGroup.MapGroup("Account")
            .WithTags(nameof(Web.Endpoint.Account));

        api.MapPost("/GuestSignIn", GuestSignIn.Handle);
    }
}