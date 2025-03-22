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
    [AbpAuthorize(AppPermissions.Pages_Queries_Nist)]
    public class NistAppService : GumAdvisorAppServiceBase, INistAppService
    {
        private readonly IRepository<Nist, Guid> _nistRepository;

        public NistAppService(IRepository<Nist, Guid> nistRepository)
        {
            _nistRepository = nistRepository;
        }

        public virtual async Task<PagedResultDto<GetNistForViewDto>> GetAll(GetAllNistInput input)
        {
            var filteredNist = _nistRepository.GetAll()
            //.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.CellPhone.Contains(input.Filter) || e.BirthPlace.Contains(input.Filter) || e.Occupation.Contains(input.Filter) || e.Education.Contains(input.Filter) || e.MaritalStatus.Contains(input.Filter) || e.Gender.Contains(input.Filter) || e.TaxNumber.Contains(input.Filter) || e.Note.Contains(input.Filter) || e.IndicatedBy.Contains(input.Filter) || e.ForwardedTo.Contains(input.Filter) || e.BloodType.Contains(input.Filter) || e.Allergy.Contains(input.Filter) || e.MedicationInUse.Contains(input.Filter) || e.MedicalInsurance.Contains(input.Filter) || e.RecordType.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Function.Contains(input.NameFilter));
            //.WhereIf(!string.IsNullOrWhiteSpace(input.TaxNumberFilter), e => e.TaxNumber.Contains(input.TaxNumberFilter));

            var pagedAndFilteredNist = filteredNist
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var nist = from o in pagedAndFilteredNist
                       select new
                       {
                           o.Function,
                           o.Category,
                           o.Subcategory,
                           Id = o.Id
                       };

            var totalCount = await filteredNist.CountAsync();
            var dbList = await nist.ToListAsync();
            var results = new List<GetNistForViewDto>();
            foreach (var o in dbList)
            {
                var res = new GetNistForViewDto()
                {
                    Nist = new NistDto
                    {
                        Function = o.Function,
                        Category = o.Category,
                        Subcategory = o.Subcategory,
                        Id = o.Id
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetNistForViewDto>(
                totalCount, 
                results
            );
        }
    }
}
