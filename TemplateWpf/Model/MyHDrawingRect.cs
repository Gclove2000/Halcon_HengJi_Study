using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWpf.Utils;

namespace TemplateWpf.Model
{
    public class MyHDrawingRect
    {
        public HWindow HWindow { get; set; }

        public HDrawingObject HDrawingObject = new HDrawingObject();

        public string Type { get; set; }

        public event Action<MyHRectangle> DrawingChanged;
        public MyHRectangle Rectangle  = new MyHRectangle();

        public MyHDrawingRect()
        {
        }

        public void Draw(float row1, float column1, float row2, float column2)
        {
            HDrawingObject = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, row1, column1, row2, column2);
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
            var row1 = drawid.GetDrawingObjectParams("row1");
            var column1 = drawid.GetDrawingObjectParams("column1");
            var row2 = drawid.GetDrawingObjectParams("row2");
            var column2 = drawid.GetDrawingObjectParams("column2");
            var msg = $"{row1},{column1},{row2},{column2}";
            Rectangle.Row1 = row1;
            Rectangle.Row2 = row2;
            Rectangle.Column1 = column1;
            Rectangle.Column2 = column2;
            DrawingChanged?.Invoke(Rectangle);
        }

        public HObject GetRegion()
        {
            HObject hObject = null;
            HOperatorSet.GenRectangle1(out hObject, Rectangle.Row1,Rectangle.Column1,Rectangle.Row2,Rectangle.Column2);
            return hObject;
        }
    }
}
