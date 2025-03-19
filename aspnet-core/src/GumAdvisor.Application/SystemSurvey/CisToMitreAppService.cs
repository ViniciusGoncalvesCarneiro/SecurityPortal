using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GumAdvisor.Authorization;
using GumAdvisor.SystemSurvey.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    [AbpAuthorize(AppPermissions.Pages_CisToMitre)]
    public class CisToMitreAppService : GumAdvisorAppServiceBase, ICisToMitreAppService
    {
        private readonly IRepository<CisToMitre, Guid> _cisToMitreRepository;

        public CisToMitreAppService(IRepository<CisToMitre, Guid> cisToMitreRepository)
        {
            _cisToMitreRepository = cisToMitreRepository;
        }

        public virtual async Task<PagedResultDto<GetCisToMitreForViewDto>> GetAll(GetAllCisToMitreInput input)
        {
            var filteredCisToMitre = _cisToMitreRepository.GetAll()
            //.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.CellPhone.Contains(input.Filter) || e.BirthPlace.Contains(input.Filter) || e.Occupation.Contains(input.Filter) || e.Education.Contains(input.Filter) || e.MaritalStatus.Contains(input.Filter) || e.Gender.Contains(input.Filter) || e.TaxNumber.Contains(input.Filter) || e.Note.Contains(input.Filter) || e.IndicatedBy.Contains(input.Filter) || e.ForwardedTo.Contains(input.Filter) || e.BloodType.Contains(input.Filter) || e.Allergy.Contains(input.Filter) || e.MedicationInUse.Contains(input.Filter) || e.MedicalInsurance.Contains(input.Filter) || e.RecordType.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Title.Contains(input.NameFilter));
            //.WhereIf(!string.IsNullOrWhiteSpace(input.TaxNumberFilter), e => e.TaxNumber.Contains(input.TaxNumberFilter));

            var pagedAndFilteredCisToMitre = filteredCisToMitre
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var cisToMitre = from o in pagedAndFilteredCisToMitre
                             select new
                             {
                                 o.CISControl,
                                 o.CISSafeguard,
                                 o.AssetType,
                                 o.SecurityFunction,
                                 o.Title,
                                 o.Description,
                                 o.EnterpriseMitigationId,
                                 Id = o.Id
                             };

            var totalCount = await filteredCisToMitre.CountAsync();
            var dbList = await cisToMitre.ToListAsync();
            var results = new List<GetCisToMitreForViewDto>();
            foreach (var o in dbList)
            {
                var res = new GetCisToMitreForViewDto()
                {
                    CisToMitre = new CisToMitreDto
                    {
                        CISControl = o.CISControl,
                        CISSafeguard = o.CISSafeguard,
                        AssetType = o.AssetType,
                        SecurityFunction = o.SecurityFunction,
                        Title = o.Title,
                        Description = o.Description,
                        EnterpriseMitigationId = o.EnterpriseMitigationId,
                        Id = o.Id
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCisToMitreForViewDto>(
                totalCount, 
                results
            );
        }
    }
}
