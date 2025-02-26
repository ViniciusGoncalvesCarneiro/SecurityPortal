using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GumAdvisor.SystemSurvey
{
    [Table("Nist")]
    public class Nist : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Column(TypeName = "text")]
        public virtual string Function { get; set; }

        [Column(TypeName = "text")]
        public virtual string Category { get; set; }

        [Column(TypeName = "text")]
        public virtual string Subcategory { get; set; }
    }
}
