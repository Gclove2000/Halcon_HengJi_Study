using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TemplateWpf.Model;
using TemplateWpf.Utils;

namespace TemplateWpf
{
    public partial class MainWindowViewModel : ObservableObject
    {

        public HImage HImage = new HImage();

        public TextBlock TextBlock { get; set; }

        private HTuple modelId = new HTuple();

        public HSmartWindowControlWPF HSmart { get; set; }
        public MyHDrawingCircle Circle = new MyHDrawingCircle();
        public MyHDrawingRect Rect = new MyHDrawingRect();
        public MainWindowViewModel()
        {
            Rect.DrawingChanged += Rect_DrawingRectChanged;
            Circle.DrawingChanged += Circle_DrawingChanged;
        }

        private void Circle_DrawingChanged(MyHCircle obj)
        {
            NLogHelper.Debug(obj.ToString());
        }

        private void Rect_DrawingRectChanged(MyHRectangle obj)
        {

            NLogHelper.Debug(obj.ToString());
        }

        [RelayCommand]
        public void ReadImg()
        {
            var imageUrl = "D:/workspace/program/Halcon/Images/A.png";
            MsgHelper.Info($"读取图片，图片路径{imageUrl}");
            HImage.ReadImage(imageUrl);
            HSmart.HalconWindow.DispObj(HImage);
            //图片适应阶段
            HSmart.SetFullImagePart();
            var templateUrl = "D:/workspace/program/Halcon/WPF_Halcon_StudyProgram/Halcon/train/A_Template.shm";
            MsgHelper.Info($"读取文件{templateUrl}");
           
            HOperatorSet.ReadShapeModel(templateUrl, out modelId);
        }

        [RelayCommand]
        public void Run()
        {
            HSmart.HalconWindow.DispObj(HImage);
            var imageParameter = (
                   row: new HTuple(),
                   col: new HTuple(),
                   angle: new HTuple(),
                   score: new HTuple()
               );
            HTuple start = new HTuple();
            HTuple end = new HTuple();
            HOperatorSet.TupleRad(-90, out start);
            HOperatorSet.TupleRad(180, out end);
            Console.WriteLine(start.DArr[0]);
            Console.WriteLine(end.DArr[0]);
            HOperatorSet.FindShapeModel(HImage, modelId, start, end, 0.5, 0, 0.5,
                "least_squares", 0, 0.7, out imageParameter.row, out imageParameter.col, out imageParameter.angle, out imageParameter.score);
            //Console.WriteLine(imageParameter.score.DArr[0]);
            TextBlock.Text = $"Score:{imageParameter.score.DArr[0]}";
            MsgHelper.Info($"{TextBlock.Text}");
            HOperatorSet.SetColor(HSmart.HalconWindow, "red");
            var length = new HTuple();
            HOperatorSet.TupleLength(imageParameter.score, out length);
            for (var i = 0; i < length; i++)
            {
                HOperatorSet.DispCross(HSmart.HalconWindow, imageParameter.row.DArr[i], imageParameter.col.DArr[i], 20, imageParameter.angle.DArr[i]);

            }
        }


        [RelayCommand]
        public void SelectFile()
        {
            MsgHelper.Info("选择文件路径");
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "选择文件路径"; // Default file name

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                MsgHelper.Success($"选择文件路径:{filename}");
            }
        }

        [RelayCommand]
        public void SelectFolder()
        {
            MsgHelper.Info("选择文件夹路径");
            var dialog = new Microsoft.Win32.OpenFolderDialog();
            dialog.Title = "选择文件夹路径"; // Default file name

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FolderName;
                MsgHelper.Success($"选择文件路径:{filename}");
            }
        }

        [RelayCommand]
        public void DrawCircle()
        {
            MsgHelper.Info("绘制圆形");
            Circle.HWindow = HSmart.HalconWindow;
            Circle.Draw(100, 100, 50);
        }

        [RelayCommand]
        public void DrawRectangle()
        {
            Rect.HWindow = HSmart.HalconWindow;
            Rect.Draw(100, 100, 200, 200);
            MsgHelper.Info("绘制矩形");
        }


        [RelayCommand]
        public void GetRectArea()
        {
            var rectObj = Rect.GetRegion();
            var newImage = new HObject();
            var partImage = new HObject();
            HOperatorSet.ReduceDomain(HImage, rectObj, out partImage);
            HOperatorSet.CropDomain(partImage, out newImage);
            //HSmart.HalconWindow.DispObj(newImage);

            HOperatorSet.CreateShapeModel(newImage, "auto", (new HTuple(0)).TupleRad(), (new HTuple(90)).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out modelId);
            var folderPath = "Output/" + Guid.NewGuid();
            MsgHelper.Info($"文件输出路径:{folderPath}");

            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            var imagePath = folderPath + "/" + Guid.NewGuid() +".png";
            var filePath = folderPath + "/" + Guid.NewGuid() +".shm";
            NLogHelper.Debug($"图片保存路径:{imagePath}");
            NLogHelper.Debug($"文件保存路径:{imagePath}");

            HOperatorSet.WriteImage(newImage, "png", 0, imagePath);
            HOperatorSet.WriteShapeModel(modelId, filePath);
        }
    }
}
