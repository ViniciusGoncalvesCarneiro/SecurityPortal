using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using GumAdvisor.Dto;

namespace GumAdvisor.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
