using MachineVision.Core;
using MachineVision.Services;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.ViewModels
{
    public class DashboardViewModel :NavigationViewModel
    {
        public NavigationMenuService NavigationMenuService { get; set; }

        public DashboardViewModel(NavigationMenuService navigationMenuService) {
            NavigationMenuService = navigationMenuService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
        }
    }
}
