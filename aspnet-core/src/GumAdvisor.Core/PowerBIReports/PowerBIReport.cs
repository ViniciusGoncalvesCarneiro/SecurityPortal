using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GumAdvisor.PowerBIReports
{
    [Table("PowerBIReports")]
    public class PowerBIReport : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(PowerBIReportConsts.MaxGroupIdLength, MinimumLength = PowerBIReportConsts.MinGroupIdLength)]
        public virtual string GroupId { get; set; }

        [Required]
        [StringLength(PowerBIReportConsts.MaxReportIdLength, MinimumLength = PowerBIReportConsts.MinReportIdLength)]
        public virtual string ReportId { get; set; }

        [StringLength(PowerBIReportConsts.MaxUrlength, MinimumLength = PowerBIReportConsts.MinUrlLength)]
        public virtual string Url { get; set; }

        [StringLength(PowerBIReportConsts.MaxDescriptionLength, MinimumLength = PowerBIReportConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }
    }
}
