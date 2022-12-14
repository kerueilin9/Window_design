using System.Windows.Forms;
using System.Drawing;
using ClassLibrary;

namespace DrawingForm.PresentationModel
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //ClearAll
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {

            Pen blackPen = new Pen(Color.Black, 1);

            PointF point1 = new PointF((float)x1, (float)y1);
            PointF point2 = new PointF((float)x1, (float)y2);
            PointF point3 = new PointF((float)x2, (float)y2);
            PointF point4 = new PointF((float)x2, (float)y1);
            PointF[] curvePoints = { point1, point2, point3, point4 };
            _graphics.DrawPolygon(blackPen, curvePoints);
        }

        //DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            const int HALF = 2;
            Pen blackPen = new Pen(Color.Black, 1);
            PointF point1 = new PointF((float)(x1 + x2) / HALF, (float)y1);
            PointF point2 = new PointF((float)x1, (float)y2);
            PointF point3 = new PointF((float)x2, (float)y2);
            PointF[] curvePoints = { point1, point2, point3 };
            _graphics.DrawPolygon(blackPen, curvePoints);
        }
    }
}

