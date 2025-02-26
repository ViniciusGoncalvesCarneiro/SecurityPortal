using Abp.Application.Services.Dto;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class GetAllIsoInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }

}
