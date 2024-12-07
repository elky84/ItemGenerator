using Web.Common;
using Char = Web.Domain.Char.Char;


namespace Web.Endpoint.Account.Dto;

public record GuestSignInRes : BaseResponse
{
    public Web.Domain.Account.Account? Account { get; init; }

    public IEnumerable<Char> Chars { get; set; } = [];
}