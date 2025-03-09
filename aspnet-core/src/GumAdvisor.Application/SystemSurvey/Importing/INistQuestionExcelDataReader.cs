using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface INistQuestionExcelDataReader : ITransientDependency
    {
        List<ImportNistDto> GetNistFromExcel(byte[] fileBytes);
    }
}
