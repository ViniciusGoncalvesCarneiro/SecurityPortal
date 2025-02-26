using Abp.Application.Services.Dto;

namespace GumAdvisor.SystemSurvey.Dto
{
    public  class GetAllCisToMitreInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }

}
