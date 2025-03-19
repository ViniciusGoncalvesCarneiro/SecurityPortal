using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace GumAdvisor.PowerBIReports.Dto
{
    public class CreateOrEditPowerBIReportDto : EntityDto<Guid?>
    {
        [Required]
        [StringLength(PowerBIReportConsts.MaxGroupIdLength, MinimumLength = PowerBIReportConsts.MinGroupIdLength)]
        public string GroupId { get; set; }

        [Required]
        [StringLength(PowerBIReportConsts.MaxReportIdLength, MinimumLength = PowerBIReportConsts.MinReportIdLength)]
        public string ReportId { get; set; }

        [StringLength(PowerBIReportConsts.MaxUrlength, MinimumLength = PowerBIReportConsts.MinUrlLength)]
        public string Url { get; set; }

        [StringLength(PowerBIReportConsts.MaxDescriptionLength, MinimumLength = PowerBIReportConsts.MinDescriptionLength)]
        public string Description { get; set; }
    }
}
