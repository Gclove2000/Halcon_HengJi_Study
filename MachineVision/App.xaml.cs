using MachineVision.Services;
using MachineVision.ViewModels;
using MachineVision.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MachineVision
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return null;
        }

        protected override void OnInitialized()
        {
            var container = ContainerLocator.Container;
            var shell = container.Resolve<object>("MainView");
            if(shell is Window view)
            {
                //通过region容器重新注入Window
                var regionManager = container.Resolve<IRegionManager>();
                RegionManager.SetRegionManager(view,regionManager);
                RegionManager.UpdateRegions();

                //找到首页的导航，初始化首页
                if(view.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(null);
                    App.Current.MainWindow = view;
                }
            }
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry services)
        {
            services.RegisterForNavigation<MainView, MainViewModel>();
            services.RegisterSingleton<NavigationMenuService>();
        }
    }

}
