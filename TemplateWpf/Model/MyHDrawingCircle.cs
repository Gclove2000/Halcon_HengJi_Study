using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWpf.Utils;

namespace TemplateWpf.Model
{
    public class MyHDrawingCircle
    {
        public HWindow HWindow { get; set; }

        public HDrawingObject HDrawingObject = new HDrawingObject();

        public string Type { get; set; }

        public event Action<MyHCircle> DrawingChanged;
        public MyHCircle Circle = new MyHCircle();

        public MyHDrawingCircle()
        {
        }

        public void Draw(float row, float column,float radius)
        {
            HDrawingObject = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.CIRCLE, row, column, radius);
            HDrawingObject.OnDrag(HDrawingCallback);
            HDrawingObject.OnSelect(HDrawingCallback);
            HDrawingObject.OnResize(HDrawingCallback);
            HWindow.AttachDrawingObjectToWindow(HDrawingObject);
        }

        public void Dispose()
        {

        }
        private void HDrawingCallback(HDrawingObject drawid, HWindow window, string type)
        {
            Type = drawid.GetDrawingObjectParams("type");
            Circle.Row = drawid.GetDrawingObjectParams("row");
            Circle.Column = drawid.GetDrawingObjectParams("column");
            Circle.Radius = drawid.GetDrawingObjectParams("radius");
            DrawingChanged?.Invoke(Circle);
        }

    }
}
