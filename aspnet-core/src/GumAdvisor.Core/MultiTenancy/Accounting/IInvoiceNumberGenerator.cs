﻿using System.Threading.Tasks;
using Abp.Dependency;

namespace GumAdvisor.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}