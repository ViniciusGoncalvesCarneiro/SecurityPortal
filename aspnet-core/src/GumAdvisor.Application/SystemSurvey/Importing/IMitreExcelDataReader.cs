using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface IMitreExcelDataReader : ITransientDependency
    {
        List<ImportMitreDto> GetMitreFromExcel(byte[] fileBytes);
    }
}
