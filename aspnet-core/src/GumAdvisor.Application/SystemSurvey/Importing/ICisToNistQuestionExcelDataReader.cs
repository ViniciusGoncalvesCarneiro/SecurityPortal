using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface ICisToNistQuestionExcelDataReader : ITransientDependency
    {
        List<ImportCisToNistDto> GetCisToNistFromExcel(byte[] fileBytes);
    }
}
