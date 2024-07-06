using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWpf.Model
{
    public class HShapeModel
    {
        public HShapeModel() { }

        public HTuple Row { get; set; }
        public HTuple Column { get; set; }
        public HTuple Angle { get; set; }
        public HTuple Score { get; set; }
    }
}
