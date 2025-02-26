using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace GumAdvisor.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
