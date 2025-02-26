using System.Threading.Tasks;
using Abp.Application.Services;
using GumAdvisor.MultiTenancy.Payments.PayPal.Dto;

namespace GumAdvisor.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
