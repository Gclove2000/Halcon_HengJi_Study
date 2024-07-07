using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWpf.Model
{
    public class MyHRectangle
    {

        public HTuple Row1 { get; set; }

        public HTuple Row2 { get; set; }
        public HTuple Column1 { get; set; }

        public HTuple Column2 { get; set; }

        public override string ToString()
        {
            var res = $"row1:{Row1},column1:{Column1},row2:{Row2},column2:{Column2}";
            return res;
        }
    }
}
