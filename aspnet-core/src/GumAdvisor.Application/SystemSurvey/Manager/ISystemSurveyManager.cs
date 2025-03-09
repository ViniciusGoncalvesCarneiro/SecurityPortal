using Abp.Domain.Services;

namespace GumAdvisor.SystemSurvey.Manager
{
    public interface ISystemSurveyManager : IDomainService
    {
        // OK
        bool GetIsoFromImportedFile(byte[] fileBytes);
        // OK
        bool GetMitreImportedFile(byte[] fileBytes);
        // OK
        bool GetNistImportedFile(byte[] fileBytes);

        // Falhou
        bool GetCisToIsoImportedFile(byte[] fileBytes);
        // Falhou

        // OK
        bool GetCisToMitreImportedFile(byte[] fileBytes);
        // OK
        bool GetCisToNistImportedFile(byte[] fileBytes);
    }
}
