using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GumAdvisor.SystemSurvey
{
    [Table("Iso")]
    public class Iso : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        [StringLength(IsoConsts.MaxClauseLength, MinimumLength = IsoConsts.MinClauseLength)]
        public virtual string Clause { get; set; }

        [StringLength(IsoConsts.MaxDomainLength, MinimumLength = IsoConsts.MinDomainLength)]
        public virtual string Domain { get; set; }

        [StringLength(IsoConsts.MaxSectionLength, MinimumLength = IsoConsts.MinSectionLength)]
        public virtual string Section { get; set; }

        [StringLength(IsoConsts.MaxInformationSecurityControlLength, MinimumLength = IsoConsts.MinInformationSecurityControlLength)]
        public virtual string InformationSecurityControl { get; set; }

        [Column(TypeName = "text")]
        public virtual string ISO27001ControlDescription { get; set; }
    }
}
