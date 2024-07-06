using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWpf.Utils;

namespace TemplateWpf
{
    public partial class MainWindowViewModel : ObservableObject
    {


        public MainWindowViewModel()
        {

        }

        [RelayCommand]
        public void Info()
        {
            MsgHelper.Info("Info!");
        }

        [RelayCommand]
        public void Error()
        {
            MsgHelper.Error("Error!");
        }

        [RelayCommand]
        public void Success()
        {
            MsgHelper.Success("Success!");
        }

        [RelayCommand]
        public void Fatal()
        {
            MsgHelper.Fatal("Fatal!");
        }
        [RelayCommand]
        public void Warning()
        {
            MsgHelper.Warning("Warning!");
        }

    }
}
