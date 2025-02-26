using Abp.EntityFrameworkCore;
using GumAdvisor.EntityFrameworkCore;
using GumAdvisor.SystemSurvey.Importing;
using GumAdvisor.SystemSurvey.Importing.Dto;
using System.Collections.Generic;

namespace GumAdvisor.SystemSurvey.Manager
{
    public class SystemSurveyManager : GumAdvisorDomainServiceBase, ISystemSurveyManager
    {
        private readonly IIsoExcelDataReader _isoExcelDataReader;
        private readonly IMitreExcelDataReader _mitreExcelDataReader;
        private readonly INistExcelDataReader _nistExcelDataReader;

        // Falhou
        //private readonly ICisToIsoExcelDataReader _cisToIsoExcelDataReader;
        // Falhou

        private readonly ICisToMitreExcelDataReader _cisToMitreExcelDataReader;
        private readonly ICisToNistExcelDataReader _cisToNistExcelDataReader;

        private IDbContextProvider<GumAdvisorDbContext> _contextProvider;

        public SystemSurveyManager(

            IIsoExcelDataReader isoExcelDataReader,
            IMitreExcelDataReader mitreExcelDataReader,
            INistExcelDataReader nistExcelDataReader,

            // Falhou
            //ICisToIsoExcelDataReader cisToIsoExcelDataReader,
            // Falhou

            ICisToMitreExcelDataReader cisToMitreExcelDataReader,
            ICisToNistExcelDataReader cisToNistExcelDataReader,

            IDbContextProvider<GumAdvisorDbContext> contextProvider

            )
        {
            _isoExcelDataReader = isoExcelDataReader;
            _mitreExcelDataReader = mitreExcelDataReader;
            _nistExcelDataReader = nistExcelDataReader;

            // Falhou
            //_cisToIsoExcelDataReader = cisToIsoExcelDataReader;
            // Falhou

            _cisToMitreExcelDataReader = cisToMitreExcelDataReader;
            _cisToNistExcelDataReader = cisToNistExcelDataReader;

            _contextProvider = contextProvider;
        }

        public void GetCisToMitreImportedFile(byte[] fileBytes)
        {
            SaveCisToMitreToDb(_cisToMitreExcelDataReader.GetCisToMitreFromExcel(fileBytes));
        }

        public void GetCisToNistImportedFile(byte[] fileBytes)
        {
            SaveCisToNistToDb(_cisToNistExcelDataReader.GetCisToNistFromExcel(fileBytes));
        }

        public void GetIsoFromImportedFile(byte[] fileBytes)
        {
            SaveIsoToDb(_isoExcelDataReader.GetIsoFromExcel(fileBytes));
        }

        public void GetMitreImportedFile(byte[] fileBytes)
        {
            SaveMitreToDb(_mitreExcelDataReader.GetMitreFromExcel(fileBytes));
        }

        public void GetNistImportedFile(byte[] fileBytes)
        {
            SaveNistToDb(_nistExcelDataReader.GetNistFromExcel(fileBytes));
        }

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
    }
}
