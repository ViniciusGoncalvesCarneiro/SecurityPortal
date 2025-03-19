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
    [AbpAuthorize(AppPermissions.Pages_Iso)]
    public class IsoAppService : GumAdvisorAppServiceBase, IIsoAppService
    {
        private readonly IRepository<Iso, Guid> _isoRepository;

        public IsoAppService(IRepository<Iso, Guid> isoRepository)
        {
            _isoRepository = isoRepository;
        }

        public virtual async Task<PagedResultDto<GetIsoForViewDto>> GetAll(GetAllIsoInput input)
        {
            var filteredIso = _isoRepository.GetAll()
            //.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.CellPhone.Contains(input.Filter) || e.BirthPlace.Contains(input.Filter) || e.Occupation.Contains(input.Filter) || e.Education.Contains(input.Filter) || e.MaritalStatus.Contains(input.Filter) || e.Gender.Contains(input.Filter) || e.TaxNumber.Contains(input.Filter) || e.Note.Contains(input.Filter) || e.IndicatedBy.Contains(input.Filter) || e.ForwardedTo.Contains(input.Filter) || e.BloodType.Contains(input.Filter) || e.Allergy.Contains(input.Filter) || e.MedicationInUse.Contains(input.Filter) || e.MedicalInsurance.Contains(input.Filter) || e.RecordType.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Clause.Contains(input.NameFilter));
            //.WhereIf(!string.IsNullOrWhiteSpace(input.TaxNumberFilter), e => e.TaxNumber.Contains(input.TaxNumberFilter));

            var pagedAndFilteredIso = filteredIso
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var iso = from o in pagedAndFilteredIso
                      select new
                      {
                          o.Clause,
                          o.Domain,
                          o.Section,
                          o.InformationSecurityControl,
                          o.ISO27001ControlDescription,
                          Id = o.Id
                      };

            var totalCount = await filteredIso.CountAsync();
            var dbList = await iso.ToListAsync();
            var results = new List<GetIsoForViewDto>();
            foreach (var o in dbList)
            {
                var res = new GetIsoForViewDto()
                {
                    Iso = new IsoDto
                    {
                        Clause = o.Clause,
                        Domain = o.Domain,
                        Section = o.Section,
                        InformationSecurityControl = o.InformationSecurityControl,
                        ISO27001ControlDescription = o.ISO27001ControlDescription,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetIsoForViewDto>(
                totalCount, 
                results
            );
        }
    }
}
