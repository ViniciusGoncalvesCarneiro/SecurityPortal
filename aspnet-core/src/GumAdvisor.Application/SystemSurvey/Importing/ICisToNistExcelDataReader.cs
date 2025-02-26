using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface ICisToNistExcelDataReader : ITransientDependency
    {
        List<ImportCisToNistDto> GetCisToNistFromExcel(byte[] fileBytes);
    }
}
