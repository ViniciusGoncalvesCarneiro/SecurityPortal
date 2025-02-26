using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GumAdvisor.MultiTenancy.HostDashboard.Dto;

namespace GumAdvisor.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}