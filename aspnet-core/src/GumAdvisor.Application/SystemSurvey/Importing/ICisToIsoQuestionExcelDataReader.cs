using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface ICisToIsoQuestionExcelDataReader : ITransientDependency
    {
        // Big, ver isso com calma...
        List<ImportCisToIsoDto> GetCisToIsoFromExcel(byte[] fileBytes);
    }
}
