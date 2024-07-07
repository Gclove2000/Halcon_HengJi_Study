using Prism.DryIoc;
using Prism.Ioc;
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

        protected override void RegisterTypes(IContainerRegistry services)
        {

        }
    }

}
