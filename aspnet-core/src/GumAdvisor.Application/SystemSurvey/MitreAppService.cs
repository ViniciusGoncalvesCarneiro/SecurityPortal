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
    [AbpAuthorize(AppPermissions.Pages_Mitre)]
    public class MitreAppService : GumAdvisorAppServiceBase, IMitreAppService
    {
        private readonly IRepository<Mitre, Guid> _mitreRepository;

        public MitreAppService(IRepository<Mitre, Guid> mitreRepository)
        {
            _mitreRepository = mitreRepository;
        }

        public virtual async Task<PagedResultDto<GetMitreForViewDto>> GetAll(GetAllMitreInput input)
        {
            var filteredMitre = _mitreRepository.GetAll()
            //.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.CellPhone.Contains(input.Filter) || e.BirthPlace.Contains(input.Filter) || e.Occupation.Contains(input.Filter) || e.Education.Contains(input.Filter) || e.MaritalStatus.Contains(input.Filter) || e.Gender.Contains(input.Filter) || e.TaxNumber.Contains(input.Filter) || e.Note.Contains(input.Filter) || e.IndicatedBy.Contains(input.Filter) || e.ForwardedTo.Contains(input.Filter) || e.BloodType.Contains(input.Filter) || e.Allergy.Contains(input.Filter) || e.MedicationInUse.Contains(input.Filter) || e.MedicalInsurance.Contains(input.Filter) || e.RecordType.Contains(input.Filter))
            .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter));
            //.WhereIf(!string.IsNullOrWhiteSpace(input.TaxNumberFilter), e => e.TaxNumber.Contains(input.TaxNumberFilter));

            var pagedAndFilteredMitre = filteredMitre
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var mitre = from o in pagedAndFilteredMitre
                        select new
                        {
                            o.MitreId,
                            o.StixId,
                            o.Name,
                            o.Description,
                            o.Url,
                            o.CreatedOn,
                            o.LastModified,
                            o.Domain,
                            o.Version,
                            o.RelationshipCitation,
                            Id = o.Id
                        };

            var totalCount = await filteredMitre.CountAsync();
            var dbList = await mitre.ToListAsync();
            var results = new List<GetMitreForViewDto>();
            foreach (var o in dbList)
            {
                var res = new GetMitreForViewDto()
                {
                    Mitre = new MitreDto
                    {
                        MitreId = o.MitreId,
                        StixId = o.StixId,
                        Name = o.Name,
                        Description = o.Description,
                        Url = o.Url,
                        CreatedOn = o.CreatedOn,
                        LastModified = o.LastModified,
                        Domain = o.Domain,
                        Version = o.Version,
                        RelationshipCitation = o.RelationshipCitation,
                        Id = o.Id
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetMitreForViewDto>(
                totalCount, 
                results
            );
        }
    }
}
