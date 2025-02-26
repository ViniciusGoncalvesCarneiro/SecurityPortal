using System.Collections.Generic;
using GumAdvisor.Auditing.Dto;
using GumAdvisor.Dto;

namespace GumAdvisor.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
