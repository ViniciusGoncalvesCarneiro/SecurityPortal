using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GumAdvisor.Authorization;
using GumAdvisor.PowerBIReports.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Text;
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


        #region [ - Embed PowerBI - ]
        
        public async Task<EmbedConfig> GetReportEmbedConfigAsync(HttpRequestMessage request, string groupId, string reportId)
        {
            var reportDetails = await GetReportDetailsAsync(groupId, reportId);

            var report = new PowerBiReportDetails(
                reportDetails.id.ToString(),
                reportDetails.name.ToString(),
                reportDetails.embedUrl.ToString()
            );

            var reportEmbedConfig = new EmbedConfig
            {
                ReportsDetail = new List<PowerBiReportDetails> { report }
            };

            var datasetIds = new List<string> { reportDetails.datasetId.ToString() };

            reportEmbedConfig.EmbedToken = await GetEmbedTokenForSingleReportSingleWorkspace(
                reportId,
                datasetIds,
                groupId
            );

            return reportEmbedConfig;
        }

        public async Task<string> GetAccessToken()
        {
            var app = PublicClientApplicationBuilder.Create(PowerBIReportConsts.clientId)
            .WithAuthority(new Uri(PowerBIReportConsts.authority))
            .Build();

            var scopes = new string[]
            {
                PowerBIReportConsts.scope
            };

            try
            {
                var result = await app.AcquireTokenByUsernamePassword(
                    scopes, 
                    PowerBIReportConsts.username,
                    PowerBIReportConsts.password).ExecuteAsync();

                return result.AccessToken;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adquirir token: {ex.Message}");
            }
        }

        protected virtual async Task<dynamic> GetReportDetailsAsync(string groupid, string reportid)
        {
            string Token = await GetAccessToken();

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://api.powerbi.com/v1.0/myorg/groups/{groupid}/reports/{reportid}");

            request.Headers.Add("Authorization", $"Bearer {Token}");

            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string errorDetails = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro {response.StatusCode}: {errorDetails}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            var reportDetails = JsonConvert.DeserializeObject<dynamic>(responseBody);

            return reportDetails;
        }

        protected virtual async Task<string> GetEmbedTokenForSingleReportSingleWorkspace(string reportId, List<string> datasetIds, string groupId)
        {
            var client = new HttpClient();

            string accessToken = await GetAccessToken();

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.powerbi.com/v1.0/myorg/groups/{groupId}/reports/{reportId}/GenerateToken");
            request.Headers.Add("Authorization", $"Bearer {accessToken}");

            var content = new StringContent("{\"accessLevel\": \"View\"}", Encoding.UTF8, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(responseBody);

            return responseBody;
        }
        #endregion
    }
}
