using System.Collections.Generic;
using GumAdvisor.Authorization.Users.Importing.Dto;
using GumAdvisor.Dto;

namespace GumAdvisor.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
