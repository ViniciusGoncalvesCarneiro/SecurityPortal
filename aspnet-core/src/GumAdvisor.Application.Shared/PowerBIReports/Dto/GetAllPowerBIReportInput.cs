using Abp.Application.Services.Dto;

namespace GumAdvisor.PowerBIReports.Dto
{
    public class GetAllPowerBIReportInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}