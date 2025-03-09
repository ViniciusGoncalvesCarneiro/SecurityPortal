using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GumAdvisor.SystemSurvey.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    //[AbpAuthorize(AppPermissions.Pages_Addresses)]
    public class CisToIsoAppService : GumAdvisorAppServiceBase, ICisToIsoAppService
    {
        private readonly IRepository<CisToIso, Guid> _cisToIsoRepository;

        public CisToIsoAppService(IRepository<CisToIso, Guid> cisToIsoRepository)
        {
            _cisToIsoRepository = cisToIsoRepository;
        }

        public async Task<PagedResultDto<GetCisToIsoForViewDto>> GetAll(GetAllCisToIsotInput input)
        {
            var filteredCisToIso = _cisToIsoRepository.GetAll()
            //.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.CellPhone.Contains(input.Filter) || e.BirthPlace.Contains(input.Filter) || e.Occupation.Contains(input.Filter) || e.Education.Contains(input.Filter) || e.MaritalStatus.Contains(input.Filter) || e.Gender.Contains(input.Filter) || e.TaxNumber.Contains(input.Filter) || e.Note.Contains(input.Filter) || e.IndicatedBy.Contains(input.Filter) || e.ForwardedTo.Contains(input.Filter) || e.BloodType.Contains(input.Filter) || e.Allergy.Contains(input.Filter) || e.MedicationInUse.Contains(input.Filter) || e.MedicalInsurance.Contains(input.Filter) || e.RecordType.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Title.Contains(input.NameFilter));
            //.WhereIf(!string.IsNullOrWhiteSpace(input.TaxNumberFilter), e => e.TaxNumber.Contains(input.TaxNumberFilter));

            var pagedAndFilteredCisToIso = filteredCisToIso
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var cisToIso = from o in pagedAndFilteredCisToIso
                           select new
                           {
                               o.CISControl,
                               o.CISSafeguard,
                               o.AssetType,
                               o.SecurityFunction,
                               o.Title,
                               o.Description,
                               o.Relationship,
                               o.ISOIEC270012022,
                               Id = o.Id
                           };

            var totalCount = await filteredCisToIso.CountAsync();
            var dbList = await cisToIso.ToListAsync();
            var results = new List<GetCisToIsoForViewDto>();
            foreach (var o in dbList)
            {
                var res = new GetCisToIsoForViewDto()
                {
                    CisToIso = new CisToIsoDto
                    {
                        CISControl = o.CISControl,
                        CISSafeguard = o.CISSafeguard,
                        AssetType = o.AssetType,
                        SecurityFunction = o.SecurityFunction,
                        Title = o.Title,
                        Description = o.Description,
                        Relationship = o.Relationship,
                        ISOIEC270012022 = o.ISOIEC270012022,
                        Id = o.Id
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCisToIsoForViewDto>(totalCount, results);
        }
    }
}
