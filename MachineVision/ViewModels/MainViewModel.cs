using MachineVision.Core;
using MachineVision.Services;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MachineVision.ViewModels
{
    public class MainViewModel : NavigationViewModel
    {
        private NavigationMenuService navigationMenuService;
        public MainViewModel(NavigationMenuService navigationMenuService)
        {
            this.navigationMenuService = navigationMenuService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigationMenuService.InitMenus();

            base.OnNavigatedTo(navigationContext);
        }



    }
}
