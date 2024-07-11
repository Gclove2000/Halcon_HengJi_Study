using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MachineVision.Core;
using MachineVision.Models;
using MachineVision.Services;
using MachineVision.Views;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MachineVision.ViewModels
{
    public partial class MainViewModel : NavigationViewModel
    {

        public NavigationMenuService NavigationMenuService { get; set; }

        private readonly IRegionManager regionManager;

        [ObservableProperty]
        private bool isTopDrawOpen = false;

        public MainViewModel(IRegionManager regionManager, NavigationMenuService navigationMenuService)
        {
            this.NavigationMenuService = navigationMenuService;
            this.regionManager = regionManager;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationMenuService.InitMenus();

            NavigatePage(nameof(DashboardView));

            base.OnNavigatedTo(navigationContext);
        }

        [RelayCommand]
        public void Navigate(NavigationItem item)
        {
            if (item == null)
            {
                return;
            }
            if (item.Name == "All")
            {
                IsTopDrawOpen = true;
                return;
            }
            IsTopDrawOpen = false;
        }

        /// <summary>
        /// 跳转Regoin
        /// </summary>
        /// <param name="pageName"></param>
        private void NavigatePage(string pageName)
        {
            regionManager.Regions[NavigationItem.RegionNameEnum.MainViewRegion.ToString()]
                .RequestNavigate(pageName, callBack =>
                {
                    var result = callBack.Result;

                    if (result == null) {
                        Debug.WriteLine(callBack.Error.Message);
                    }else if (!(bool)result)
                    {
                        Debug.WriteLine(callBack.Error.Message);

                    }
                });
        }
    }
}
