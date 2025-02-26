using System.Threading.Tasks;
using GumAdvisor.Authorization.Users;

namespace GumAdvisor.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
