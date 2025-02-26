using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GumAdvisor.SystemSurvey
{
    [Table("Mitre")]
    public class Mitre : FullAuditedEntity<Guid>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string MitreId { get; set; }
        public virtual string StixId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Url { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime LastModified { get; set; }
        public virtual string Domain { get; set; }
        public virtual string Version { get; set; }
        [Column(TypeName = "text")]
        public virtual string RelationshipCitation { get; set; }
    }
}
