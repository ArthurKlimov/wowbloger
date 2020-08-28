using Abp.Authorization;
using WowBloger.Authorization.Roles;
using WowBloger.Authorization.Users;

namespace WowBloger.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
