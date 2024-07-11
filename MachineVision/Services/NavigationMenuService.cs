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

            Items.Add(new NavigationItem("All", "全部", PackIconKind.Add, new ObservableCollection<NavigationItem>()
            {
                new NavigationItem("Template","模板匹配", PackIconKind.Add,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("OutLine","轮廓匹配",PackIconKind.ShapeCirclePlus),
                    new NavigationItem("Shape","形状匹配",PackIconKind.ShapeOutline),
                    new NavigationItem("Similarity","相似度匹配",PackIconKind.Clouds),
                    new NavigationItem("ShapeChange","形变匹配",PackIconKind.ShapeOvalPlus),
                }),
                new NavigationItem("Compare","比较测量", PackIconKind.Add,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("Circle","卡尺找圆",PackIconKind.Circle),
                    new NavigationItem("Color","颜色检测",PackIconKind.Palette),
                    new NavigationItem("Ruler","几何测量",PackIconKind.Ruler),
                }),
                new NavigationItem("Character","字符识别", PackIconKind.Add,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("Character","字符识别", PackIconKind.FormatColorText),
                    new NavigationItem("Barcode","一维码识别", PackIconKind.Barcode),
                    new NavigationItem("Qrcode","二维码识别", PackIconKind.Qrcode),
                }),
                new NavigationItem("Flaw","缺陷检测", PackIconKind.Add,new ObservableCollection<NavigationItem>()
                {
                    new NavigationItem("Crop","差分模型", PackIconKind.Crop),
                    new NavigationItem("CropRotate","形变模型", PackIconKind.CropRotate),
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
