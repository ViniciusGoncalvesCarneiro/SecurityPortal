﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GumAdvisor.SystemSurvey
{
    [Table("CisToNist")]
    public class CisToNist : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string CISControl { get; set; }
        public virtual string CISSafeguard { get; set; }
        public virtual string AssetType { get; set; }
        public virtual string SecurityFunction { get; set; }
        public virtual string Title { get; set; }
        [Column(TypeName = "text")]
        public virtual string Description { get; set; }
        public virtual string Relationship { get; set; }
        public virtual string NIST { get; set; }
    }
}
