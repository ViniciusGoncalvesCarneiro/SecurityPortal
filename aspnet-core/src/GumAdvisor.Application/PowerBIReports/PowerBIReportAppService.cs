using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GumAdvisor.Authorization;
using GumAdvisor.PowerBIReports.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GumAdvisor.PowerBIReports
{
    [AbpAuthorize(AppPermissions.Pages_PowerBIReports)]
    public class PowerBIReportAppService : GumAdvisorAppServiceBase, IPowerBIReportAppService
    {
        private readonly IRepository<PowerBIReport, Guid> _powerBIReportRepository;

        public PowerBIReportAppService(IRepository<PowerBIReport, Guid> powerBIReportRepository)
        {
            _powerBIReportRepository = powerBIReportRepository;
        }

        public virtual async Task<PagedResultDto<GetPowerBIReportForViewDto>> GetAll(GetAllPowerBIReportInput input)
        {
            var filteredPowerBIReports = _powerBIReportRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                e.GroupId.Contains(input.Filter) ||
                e.ReportId.Contains(input.Filter) ||
                //e.Url.Contains(input.Filter) || 
                e.Description.Contains(input.Filter));

            var pagedAndFilteredPowerBIReports = filteredPowerBIReports
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var powerBIReports = from o in pagedAndFilteredPowerBIReports
                                 select new
                                 {
                                     o.GroupId,
                                     o.ReportId,
                                     //o.Url,
                                     o.Description,
                                     Id = o.Id,
                                 };

            var totalCount = await filteredPowerBIReports.CountAsync();
            var dbList = await powerBIReports.ToListAsync();
            var results = new List<GetPowerBIReportForViewDto>();
            foreach (var o in dbList)
            {
                var res = new GetPowerBIReportForViewDto()
                {
                    PowerBIReport = new PowerBIReportDto
                    {
                        GroupId = o.GroupId,
                        ReportId = o.ReportId,
                        //Url = o.Url,
                        Description = o.Description,
                        Id = o.Id,
                    },
                };

                results.Add(res);
            }

            return new PagedResultDto<GetPowerBIReportForViewDto>(
                totalCount,
                results
            );
        }

        public virtual async Task<GetPowerBIReportForViewDto> GetPowerBIReportForView(Guid id)
        {
            var powerBIReport = await _powerBIReportRepository.GetAsync(id);

            var output = new GetPowerBIReportForViewDto
            {
                PowerBIReport = ObjectMapper.Map<PowerBIReportDto>(powerBIReport)
            };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_PowerBIReports_Edit)]
        public virtual async Task<GetPowerBIReportForEditOutput> GetPowerBIReportForEdit(EntityDto<Guid> input)
        {
            var powerBIReport = await _powerBIReportRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetPowerBIReportForEditOutput
            {
                PowerBIReport = ObjectMapper.Map<CreateOrEditPowerBIReportDto>(powerBIReport)
            };

            return output;
        }

        public virtual async Task CreateOrEdit(CreateOrEditPowerBIReportDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_PowerBIReports_Create)]
        protected virtual async Task Create(CreateOrEditPowerBIReportDto input)
        {
            var powerBiReport = ObjectMapper.Map<PowerBIReport>(input);

            if (AbpSession.TenantId != null)
            {
                powerBiReport.TenantId = (int)AbpSession.TenantId;
            }

            await _powerBIReportRepository.InsertAsync(powerBiReport);
        }

        [AbpAuthorize(AppPermissions.Pages_PowerBIReports_Edit)]
        protected virtual async Task Update(CreateOrEditPowerBIReportDto input)
        {
            var powerBiReport = await _powerBIReportRepository.FirstOrDefaultAsync((Guid)input.Id);
            ObjectMapper.Map(input, powerBiReport);
        }

        [AbpAuthorize(AppPermissions.Pages_PowerBIReports_Delete)]
        public virtual async Task Delete(EntityDto<Guid> input)
        {
            await _powerBIReportRepository.DeleteAsync(input.Id);
        }
    }
}
