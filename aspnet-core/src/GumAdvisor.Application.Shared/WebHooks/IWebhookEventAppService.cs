using System.Threading.Tasks;
using Abp.Webhooks;

namespace GumAdvisor.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
