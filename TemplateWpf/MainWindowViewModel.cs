using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TemplateWpf.Utils;

namespace TemplateWpf
{
    public partial class MainWindowViewModel : ObservableObject
    {

        public HImage HImage = new HImage();

        public TextBlock TextBlock { get; set; }

        private HTuple modelId = new HTuple();

        public HSmartWindowControlWPF HSmart { get; set; }

        public MainWindowViewModel()
        {

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
        }

        [RelayCommand]
        public void Run()
        {
            var templateUrl = "D:/workspace/program/Halcon/WPF_Halcon_StudyProgram/Halcon/train/A_Template.shm";
            MsgHelper.Info($"读取文件{templateUrl}");
            var imageParameter = (
                    row: new HTuple(),
                    col: new HTuple(),
                    angle: new HTuple(),
                    score: new HTuple()
                );
            HOperatorSet.ReadShapeModel(templateUrl, out modelId);
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

        public void DrawCircle()
        {

        }

        public void DrawRectangle()
        {

        }
    }
}
