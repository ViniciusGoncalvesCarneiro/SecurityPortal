using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class GetAllMitreInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
    }

}
