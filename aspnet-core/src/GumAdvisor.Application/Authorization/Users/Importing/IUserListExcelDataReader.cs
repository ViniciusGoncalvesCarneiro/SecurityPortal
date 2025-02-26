using System.Collections.Generic;
using GumAdvisor.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace GumAdvisor.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader : ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
