using Abp.Dependency;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Importing
{
    public interface IIsoExcelDataReader : ITransientDependency
    {
        List<ImportIsoDto> GetIsoFromExcel(byte[] fileBytes);
    }
}
