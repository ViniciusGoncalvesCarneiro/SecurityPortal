using Abp.Application.Services.Dto;
using System;

namespace GumAdvisor.PowerBIReports.Dto
{
    public class PowerBIReportDto : EntityDto<Guid>
    {
        public string GroupId { get; set; }

        public string ReportId { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }
    }
}
