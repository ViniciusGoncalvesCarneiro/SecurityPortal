using Abp.Domain.Services;

namespace GumAdvisor.SystemSurvey.Manager
{
    public interface ISystemSurveyManager : IDomainService
    {
        // OK
        void GetIsoFromImportedFile(byte[] fileBytes);
        // OK
        void GetMitreImportedFile(byte[] fileBytes);
        // OK
        void GetNistImportedFile(byte[] fileBytes);

        // Falhou
        //void GetCisToIsoImportedFile(byte[] fileBytes);
        // Falhou

        // OK
        void GetCisToMitreImportedFile(byte[] fileBytes);
        // OK
        void GetCisToNistImportedFile(byte[] fileBytes);
    }
}
