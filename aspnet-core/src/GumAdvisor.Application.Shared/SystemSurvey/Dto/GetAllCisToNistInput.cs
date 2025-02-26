using Abp.Application.Services.Dto;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class GetAllCisToNistInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }

}
