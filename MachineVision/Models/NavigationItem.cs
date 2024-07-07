using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Models
{
    public partial class NavigationItem : ObservableObject
    {
        [ObservableProperty]
        private string title = "title";

        [ObservableProperty]
        private string name = "name";

        [ObservableProperty]
        private PackIconKind icon = PackIconKind.None;

        [ObservableProperty]
        private ObservableCollection<NavigationItem> items = null;


        public NavigationItem()
        {

        }
        public NavigationItem(string _name,string _title,PackIconKind _icon = PackIconKind.None,ObservableCollection<NavigationItem> _items = null)
        {
            Name = _name;
            Title = _title;
            Icon = _icon;
            Items = _items;
        }

    }
}
