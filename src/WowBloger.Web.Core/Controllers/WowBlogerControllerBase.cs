using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WowBloger.Controllers
{
    public abstract class WowBlogerControllerBase: AbpController
    {
        protected WowBlogerControllerBase()
        {
            LocalizationSourceName = WowBlogerConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
