using System.Collections.Generic;
using MvvmHelpers;
using GumAdvisor.Models.NavigationMenu;

namespace GumAdvisor.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}