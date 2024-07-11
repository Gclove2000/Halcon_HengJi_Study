using MachineVision.Services;
using MachineVision.ViewModels;
using MachineVision.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
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
        /// <summary>
        /// 创造时直接返回Window，但是这样就不能用IOC注入了
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            //return new MainView();
            return null;
        }

        /// <summary>
        /// 在创造完之后获得Windows
        /// </summary>
        protected override void OnInitialized()
        {
            var container = ContainerLocator.Container;
            var shell = container.Resolve<object>("MainView");
            if (shell is Window view)
            {
                //通过region容器重新注入Window
                var regionManager = container.Resolve<IRegionManager>();
                RegionManager.SetRegionManager(view, regionManager);
                RegionManager.UpdateRegions();

                //找到首页的导航，初始化首页
                if (view.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(null);
                    App.Current.MainWindow = view;
                }
            }
            base.OnInitialized();
        }
        /// <summary>
        /// Ioc注入
        /// </summary>
        /// <param name="services"></param>
        protected override void RegisterTypes(IContainerRegistry services)
        {
            services.RegisterForNavigation<MainView, MainViewModel>();
            services.RegisterForNavigation<DashboardView, DashboardViewModel>();
            services.RegisterSingleton<NavigationMenuService>();
        }

    }

}
