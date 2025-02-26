using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class IsoDto : EntityDto<Guid>
    {
        [StringLength(IsoConsts.MaxClauseLength, MinimumLength = IsoConsts.MinClauseLength)]
        public string Clause { get; set; }

        [StringLength(IsoConsts.MaxDomainLength, MinimumLength = IsoConsts.MinDomainLength)]
        public string Domain { get; set; }

        [StringLength(IsoConsts.MaxSectionLength, MinimumLength = IsoConsts.MinSectionLength)]
        public string Section { get; set; }

        [StringLength(IsoConsts.MaxInformationSecurityControlLength, MinimumLength = IsoConsts.MinInformationSecurityControlLength)]
        public string InformationSecurityControl { get; set; }

        public string ISO27001ControlDescription { get; set; }
    }
}
