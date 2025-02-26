using Abp.Application.Services.Dto;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class GetAllNistInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }

}
