using Abp.Application.Services.Dto;
using System;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class CisToMitreDto : EntityDto<Guid>
    {
        public string CISControl { get; set; }
        public string CISSafeguard { get; set; }
        public string AssetType { get; set; }
        public string SecurityFunction { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EnterpriseMitigationId { get; set; }
    }
}
