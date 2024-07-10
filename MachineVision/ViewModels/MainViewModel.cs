using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MachineVision.Core;
using MachineVision.Models;
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
    public partial class MainViewModel : NavigationViewModel
    {
        public NavigationMenuService NavigationMenuService { get; set; }


        [ObservableProperty]
        private bool isTopDrawOpen = true;

        public MainViewModel(NavigationMenuService navigationMenuService)
        {
            this.NavigationMenuService = navigationMenuService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationMenuService.InitMenus();

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


    }
}
