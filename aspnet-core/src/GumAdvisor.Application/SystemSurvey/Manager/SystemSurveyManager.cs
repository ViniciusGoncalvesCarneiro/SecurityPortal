using Abp.EntityFrameworkCore;
using GumAdvisor.EntityFrameworkCore;
using GumAdvisor.SystemSurvey.Importing;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Manager
{
    public class SystemSurveyManager : GumAdvisorDomainServiceBase, ISystemSurveyManager
    {
        private readonly IIsoQuestionExcelDataReader _isoQuestionExcelDataReader;
        private readonly IMitreQuestionExcelDataReader _mitreQuestionExcelDataReader;
        private readonly INistQuestionExcelDataReader _nistQuestionExcelDataReader;

        // Falhou
        //private readonly ICisToIsoExcelDataReader _cisToIsoExcelDataReader;
        private readonly ICisToIsoQuestionExcelDataReader _cisToIsoQuestionExcelDataReader;
        // Falhou

        private readonly ICisToMitreQuestionExcelDataReader _cisToMitreQuestionExcelDataReader;
        private readonly ICisToNistQuestionExcelDataReader _cisToNistQuestionExcelDataReader;

        private IDbContextProvider<GumAdvisorDbContext> _contextProvider;

        public SystemSurveyManager(

            IIsoQuestionExcelDataReader isoQuestionExcelDataReader,
            IMitreQuestionExcelDataReader mitreQuestionExcelDataReader,
            INistQuestionExcelDataReader nistQuestionExcelDataReader,

            // Falhou
            ICisToIsoQuestionExcelDataReader cisToIsoQuestionExcelDataReader,
            // Falhou

            ICisToMitreQuestionExcelDataReader cisToMitreQuestionExcelDataReader,
            ICisToNistQuestionExcelDataReader cisToNistQuestionExcelDataReader,

            IDbContextProvider<GumAdvisorDbContext> contextProvider

            )
        {
            _isoQuestionExcelDataReader = isoQuestionExcelDataReader;
            _mitreQuestionExcelDataReader = mitreQuestionExcelDataReader;
            _nistQuestionExcelDataReader = nistQuestionExcelDataReader;
            // Falhou
            _cisToIsoQuestionExcelDataReader = cisToIsoQuestionExcelDataReader;
            // Falhou
            _cisToMitreQuestionExcelDataReader = cisToMitreQuestionExcelDataReader;
            _cisToNistQuestionExcelDataReader = cisToNistQuestionExcelDataReader;

            _contextProvider = contextProvider;
        }

        #region [ Get Data Drom Excell ]
        public bool GetCisToMitreImportedFile(byte[] fileBytes)
        {
            bool success = false;
            try
            {
                var result = _cisToMitreQuestionExcelDataReader.GetCisToMitreFromExcel(fileBytes);
                SaveCisToMitreToDb(result);
                success = true;
            }
            catch (System.Exception)
            {
                success = false;
            }
            return success;

        }

        public bool GetCisToNistImportedFile(byte[] fileBytes)
        {
            bool success = false;
            try
            {
                var result = _cisToNistQuestionExcelDataReader.GetCisToNistFromExcel(fileBytes);
                SaveCisToNistToDb(result);
                success = true;
            }
            catch (System.Exception)
            {
                success = false;
            }
            return success;
        }

        public bool GetIsoFromImportedFile(byte[] fileBytes)
        {
            bool success = false;
            try
            {
                var result = _isoQuestionExcelDataReader.GetIsoFromExcel(fileBytes);
                SaveIsoToDb(result);
                success = true;
            }
            catch (System.Exception)
            {
                success = false;
            }
            return success;

        }

        public bool GetMitreImportedFile(byte[] fileBytes)
        {
            bool success = false;
            try
            {
                var result = _mitreQuestionExcelDataReader.GetMitreFromExcel(fileBytes);
                SaveMitreToDb(result);
                success = true;
            }
            catch (System.Exception)
            {
                success = false;
            }
            return success;

        }

        public bool GetNistImportedFile(byte[] fileBytes)
        {
            bool success = false;
            try
            {
                var result = _nistQuestionExcelDataReader.GetNistFromExcel(fileBytes);
                SaveNistToDb(result);
                success = true;
            }
            catch (System.Exception)
            {
                success = false;
            }
            return success;

        }
        public bool GetCisToIsoImportedFile(byte[] fileBytes)
        {
            bool success = false;
            try
            {
                var result = _cisToIsoQuestionExcelDataReader.GetCisToIsoFromExcel(fileBytes);
                SaveCisToIsoToDb(result);
                success = true;
            }
            catch (System.Exception)
            {
                success = false;
            }
            return success;

        }
        #endregion

        #region [ - Save Data to DB - ]
        protected void SaveIsoToDb(List<ImportIsoDto> importIso)
        {
            var ctx = _contextProvider.GetDbContext();
            foreach (ImportIsoDto item in importIso)
            {
                var iso = new Iso();
                iso.TenantId = (int)ctx.AbpSession.TenantId;
                iso.Clause = item.Clause;
                iso.Domain = item.Domain;
                iso.Section = item.Section;
                iso.InformationSecurityControl = item.InformationSecurityControl;
                iso.ISO27001ControlDescription = item.ISO_27001_Control_Description;
                ctx.Iso.Add(iso);
            }
            ctx.SaveChanges();
        }

        protected void SaveMitreToDb(List<ImportMitreDto> importMitre)
        {
            var ctx = _contextProvider.GetDbContext();
            foreach (ImportMitreDto item in importMitre)
            {
                var mitre = new Mitre();
                mitre.TenantId = (int)ctx.AbpSession.TenantId;
                mitre.MitreId = item.Mitre_ID;
                mitre.StixId = item.STIX_ID;
                mitre.Name = item.Name;
                mitre.Description = item.Description;
                mitre.Url = item.Url;
                mitre.CreatedOn = item.Created;
                mitre.LastModified = item.Last_Modified;
                mitre.Domain = item.Domain;
                mitre.Version = item.Version;
                mitre.RelationshipCitation = item.Relationship_Citations;

                ctx.Mitre.Add(mitre);
            }
            ctx.SaveChanges();
        }

        protected void SaveNistToDb(List<ImportNistDto> importNist)
        {
            var ctx = _contextProvider.GetDbContext();
            foreach (ImportNistDto item in importNist)
            {
                var nist = new Nist();
                nist.TenantId = (int)ctx.AbpSession.TenantId;
                nist.Function = item.Function;
                nist.Category = item.Category;
                nist.Subcategory = item.Subcategory;
                ctx.Nist.Add(nist);
            }
            ctx.SaveChanges();

        }

        protected void SaveCisToMitreToDb(List<ImportCisToMitreDto> importCisToMitre)
        {
            var ctx = _contextProvider.GetDbContext();
            foreach (ImportCisToMitreDto item in importCisToMitre)
            {
                var cisToMitre = new CisToMitre();
                cisToMitre.TenantId = (int)ctx.AbpSession.TenantId;
                cisToMitre.CISControl = item.CIS_Control;
                cisToMitre.CISSafeguard = item.CIS_Safeguard;
                cisToMitre.AssetType = item.Asset_Type;
                cisToMitre.SecurityFunction = item.Security_Function;
                cisToMitre.Title = item.Title;
                cisToMitre.Description = item.Description;
                cisToMitre.EnterpriseMitigationId = item.Enterprise_Mitigation_ID;

                ctx.CisToMitre.Add(cisToMitre);
            }
            ctx.SaveChanges();
        }

        protected void SaveCisToNistToDb(List<ImportCisToNistDto> importCisToNist)
        {
            var ctx = _contextProvider.GetDbContext();
            foreach (ImportCisToNistDto item in importCisToNist)
            {
                var cisToNist = new CisToNist();
                cisToNist.TenantId = (int)ctx.AbpSession.TenantId;
                cisToNist.CISControl = item.CIS_Control;
                cisToNist.CISSafeguard = item.CIS_Safeguard;
                cisToNist.AssetType = item.Asset_Type;
                cisToNist.SecurityFunction = item.Security_Function;
                cisToNist.Title = item.Title;
                cisToNist.Description = item.Description;
                cisToNist.Relationship = item.Relationship;
                cisToNist.NIST = item.NIST;
                ctx.CisToNist.Add(cisToNist);
            }
            ctx.SaveChanges();
        }

        protected void SaveCisToIsoToDb(List<ImportCisToIsoDto> importCisToIso)
        {
            var ctx = _contextProvider.GetDbContext();
            foreach (ImportCisToIsoDto item in importCisToIso)
            {
                var cisToIso = new CisToIso();
                cisToIso.TenantId = (int)ctx.AbpSession.TenantId;
                cisToIso.CISControl = item.CIS_Control;
                cisToIso.CISSafeguard = item.CIS_Safeguard;
                cisToIso.AssetType = item.Asset_Type;
                cisToIso.SecurityFunction = item.Security_Function;
                cisToIso.Title = item.Title;
                cisToIso.Description = item.Description;
                cisToIso.Relationship = item.Relationship;
                cisToIso.ISOIEC270012022 = item.ISO_IEC_27001_2022;
                ctx.CisToIso.Add(cisToIso);
            }
        }
        #endregion

    }
}
