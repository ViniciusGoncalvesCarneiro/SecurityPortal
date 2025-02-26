using Abp.Application.Services.Dto;
using System;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class MitreDto : EntityDto<Guid>
    {
        public string MitreId { get; set; }
        public string StixId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
        public string Domain { get; set; }
        public string Version { get; set; }
        public string RelationshipCitation { get; set; }
    }
}
