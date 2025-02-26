using System.Threading.Tasks;
using Abp.Application.Services;
using GumAdvisor.MultiTenancy.Payments.Dto;
using GumAdvisor.MultiTenancy.Payments.Stripe.Dto;

namespace GumAdvisor.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}