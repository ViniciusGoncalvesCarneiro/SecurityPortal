using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface ICisToMitreQuestionExcelDataReader : ITransientDependency
    {
        List<ImportCisToMitreDto> GetCisToMitreFromExcel(byte[] fileBytes);
    }
}
