using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface ICisToMitreExcelDataReader : ITransientDependency
    {
        List<ImportCisToMitreDto> GetCisToMitreFromExcel(byte[] fileBytes);
    }
}
