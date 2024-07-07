using CommunityToolkit.Mvvm.ComponentModel;
using MachineVision.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Services
{
    public partial class NavigationMenuService : ObservableObject, INavigationMenuService
    {
        [ObservableProperty]
        private ObservableCollection<NavigationItem> items = new ObservableCollection<NavigationItem>();
        public NavigationMenuService() { }

        public void InitMenus()
        {
            Items.Clear();

            Items.Add(new NavigationItem("All", "全部", PackIconKind.None, new ObservableCollection<NavigationItem>()
            {
                new NavigationItem("Template","模板匹配", PackIconKind.None,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("OutLine","轮廓匹配"),
                    new NavigationItem("Shape","形状匹配"),
                    new NavigationItem("Similarity","相似度匹配"),
                    new NavigationItem("ShapeChange","形变匹配"),
                }),
                new NavigationItem("Compare","比较测量", PackIconKind.None,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("Circle","卡尺找圆"),
                    new NavigationItem("Color","颜色检测"),
                    new NavigationItem("Ruler","几何测量"),
                }),
                new NavigationItem("Character","字符识别", PackIconKind.None,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("Character","字符识别"),
                    new NavigationItem("Barcode","一维码识别"),
                    new NavigationItem("Qrcode","二维码识别"),
                }),
                new NavigationItem("Flaw","缺陷检测", PackIconKind.None,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("Crop","差分模型"),
                    new NavigationItem("CropRotate","形变模型"),
                }),
            }));

            Items.Add(new NavigationItem("Template", "模板匹配"));
            Items.Add(new NavigationItem("Compare", "比较测量"));
            Items.Add(new NavigationItem("Character", "字符识别"));
            Items.Add(new NavigationItem("Flaw", "缺陷检测"));
            Items.Add(new NavigationItem("Document", "学习文档"));
        }

    }
}
