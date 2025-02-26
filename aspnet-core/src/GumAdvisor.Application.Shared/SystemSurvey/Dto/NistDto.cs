using Abp.Application.Services.Dto;
using System;

namespace GumAdvisor.SystemSurvey.Dto
{
    public class NistDto : EntityDto<Guid>
    {
        public virtual string Function { get; set; }
        public virtual string Category { get; set; }
        public virtual string Subcategory { get; set; }
    }
}
