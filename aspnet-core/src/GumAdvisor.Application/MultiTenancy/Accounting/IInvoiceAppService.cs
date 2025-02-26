using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GumAdvisor.MultiTenancy.Accounting.Dto;

namespace GumAdvisor.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
