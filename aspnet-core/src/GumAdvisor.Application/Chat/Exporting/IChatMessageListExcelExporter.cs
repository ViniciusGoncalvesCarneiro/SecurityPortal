using System.Collections.Generic;
using Abp;
using GumAdvisor.Chat.Dto;
using GumAdvisor.Dto;

namespace GumAdvisor.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
