using HalconDotNet;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWpf.Model
{
    public class MyHCircle
    {

        public HTuple Row { get; set; }

        public HTuple Column { get; set; }

        public HTuple Radius {  get; set; }

        public override string ToString()
        {
            var res = $"row:{Row},column:{Column},radius:{Radius}";
            return res;
        }
    }
}
