using Web.Domain.Account;
using Web.Domain.Char;
using Web.Endpoint.Account.Dto;
using Microsoft.AspNetCore.Authorization;
using Char = Web.Domain.Char.Char;

namespace Web.Endpoint.Account.Api;

public static class GuestSignIn
{
    [AllowAnonymous]
    public static async Task<GuestSignInRes> Handle(GuestSignInReq dto, AccountRepository accountRepository,
        CharRepository charRepository, ILoggerFactory loggerFactory)
    {
        if (string.IsNullOrEmpty(dto.AccountId))
        {
            throw new ArgumentException("need account id");
        }

        var account = new Domain.Account.Account { AccountId = dto.AccountId };
        await accountRepository.Insert(account);

        var logger = loggerFactory.CreateLogger(nameof(GuestSignIn));

        try
        {
            var character = new Char { AccountUid = account.AccountUid };
            await charRepository.Insert(character);

            return new GuestSignInRes
            {
                Account = account,
                Chars = [character],
            };
        }
        catch (Exception ex)
        {
            logger.LogWarning("Exception:{Ex}", ex);
            throw;
        }
    }
}