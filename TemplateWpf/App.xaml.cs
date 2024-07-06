using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace TemplateWpf
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly static ServiceProvider ServiceProvider;

        static App()
        {
            IServiceCollection services = new ServiceCollection();
            ServiceProvider = services.BuildServiceProvider();
            //var res = ServiceProvider.GetService<MainWindowViewModel>();
        }
    }



}
