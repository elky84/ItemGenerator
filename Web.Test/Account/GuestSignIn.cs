using Web.Endpoint.Account.Dto;
using Web.Test.Extensions;
using Xunit.Abstractions;

namespace Web.Test.Account;

[Collection(nameof(Web))]
public class GuestSignIn: IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly WebFixture _fixture;

    public GuestSignIn(WebFixture fixture, CustomWebApplicationFactory factory, ITestOutputHelper output)
    {
        _fixture = fixture;
        _fixture.SetOutputHelper(output);

        _factory = factory;
    }

    [Fact]
    public async Task EmptyAccount()
    {
        using var client = _factory.CreateClient();

        var resGuestSignIn = await client.Post<GuestSignInRes>("/api/account/GuestSignIn",
            new GuestSignInReq("", "", ""));

        Assert.NotNull(resGuestSignIn);

        Assert.Equal(500, resGuestSignIn.StatusCode);
    }

    [Fact]
    public async Task Normal()
    {
        using var client = _factory.CreateClient();

        var resGuestSignIn = await client.Post<GuestSignInRes>("/api/account/GuestSignIn",
            new GuestSignInReq("elky", "", ""));

        Assert.NotNull(resGuestSignIn);

        Assert.Equal(200, resGuestSignIn.StatusCode);
    }
}