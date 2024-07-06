using HalconDotNet;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace A_Template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HObject image;
            HOperatorSet.GenEmptyObj(out image);
            // read image
            var imageUrl = @"D:/workspace/program/Halcon/Images/A.png";
            HOperatorSet.ReadImage(out image, imageUrl);

            //read template file
            HTuple modelId = new HTuple();
            var modelUrl = "D:\\workspace\\program\\Halcon\\WPF_Halcon_StudyProgram\\Halcon\\train\\A_Template.shm";
            HOperatorSet.ReadShapeModel(modelUrl, out modelId);

            var imageParameter = (
                    row: new HTuple(),
                    col: new HTuple(),
                    angle: new HTuple(),
                    score: new HTuple()
                );

            HOperatorSet.FindShapeModel(image, modelId, 0.39, 0.79, 0.5, 1, 0.5,
                "least_squares", 0, 0.9, out imageParameter.row, out imageParameter.col, out imageParameter.angle, out imageParameter.score);

            Console.WriteLine(imageParameter.score.DArr[0]);
            Console.WriteLine("Hello, World!");

            Console.ReadLine();
        }
    }
}
