using System.Collections.Generic;
using GumAdvisor.Authorization.Users.Dto;
using GumAdvisor.Dto;

namespace GumAdvisor.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}