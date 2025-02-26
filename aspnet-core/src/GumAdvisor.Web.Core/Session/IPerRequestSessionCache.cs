using System.Threading.Tasks;
using GumAdvisor.Sessions.Dto;

namespace GumAdvisor.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
