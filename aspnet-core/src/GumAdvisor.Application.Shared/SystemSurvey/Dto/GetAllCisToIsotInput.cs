using Abp.Application.Services.Dto;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class GetAllCisToIsotInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }

}
