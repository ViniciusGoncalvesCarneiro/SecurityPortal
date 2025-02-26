using Abp.AutoMapper;
using GumAdvisor.Organizations.Dto;

namespace GumAdvisor.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}