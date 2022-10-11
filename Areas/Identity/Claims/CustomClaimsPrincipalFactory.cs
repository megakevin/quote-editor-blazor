using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using QuoteEditorBlazor.Models;
using System.Security.Claims;

namespace QuoteEditorBlazor.Areas.Identity.Claims;

// Thanks to surferonwww's answer in
// https://learn.microsoft.com/en-us/answers/questions/1009750/how-to-add-custom-claims-on-user-identity-net-6.html
public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
{
    public CustomClaimsPrincipalFactory(
        UserManager<User> userManager,
        IOptions<IdentityOptions> optionsAccessor
    ) : base(userManager, optionsAccessor) { }

    public async override Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var principal = await base.CreateAsync(user);

        if (principal.Identity != null)
        {
            ((ClaimsIdentity)principal.Identity).AddClaims(
                new[] { new Claim(Claims.CompanyID, user.CompanyID.ToString()) }
            );
        }

        return principal;
    }
}
