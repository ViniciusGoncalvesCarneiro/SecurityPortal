using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using GumAdvisor.Authorization.Users;
using GumAdvisor.MultiTenancy;

namespace GumAdvisor.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}