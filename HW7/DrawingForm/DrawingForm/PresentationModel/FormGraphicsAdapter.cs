using System.Windows.Forms;
using System.Drawing;
using DrawingModel;

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
            Brush brush = new SolidBrush(Color.Yellow);
            PointF point1 = new PointF((float)x1, (float)y1);
            PointF point2 = new PointF((float)x1, (float)y2);
            PointF point3 = new PointF((float)x2, (float)y2);
            PointF point4 = new PointF((float)x2, (float)y1);
            PointF[] curvePoints = { point1, point2, point3, point4 };
            _graphics.FillPolygon(brush, curvePoints);
            _graphics.DrawPolygon(blackPen, curvePoints);
        }

        //DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            const int HALF = 2;
            Brush brush = new SolidBrush(Color.Red);
            Pen blackPen = new Pen(Color.Black, 1);
            PointF point1 = new PointF((float)(x1 + x2) / HALF, (float)y1);
            PointF point2 = new PointF((float)x1, (float)y2);
            PointF point3 = new PointF((float)x2, (float)y2);
            PointF[] curvePoints = { point1, point2, point3 };
            _graphics.FillPolygon(brush, curvePoints);
            _graphics.DrawPolygon(blackPen, curvePoints);
        }

        //DrawSelected
        public void DrawSelected(double x1, double y1, double x2, double y2)
        {
            const float DIAMETER = 6;
            const float RADIUS = DIAMETER / 2;
            Pen pen = new Pen(Color.Red, 1);
            Pen pen1 = Pens.Black;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            _graphics.DrawRectangle(pen, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
            _graphics.FillEllipse(brush, (float)x1 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(pen1, (float)x1 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.FillEllipse(brush, (float)x1 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(pen1, (float)x1 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            _graphics.FillEllipse(brush, (float)x2 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(pen1, (float)x2 - RADIUS, (float)y1 - RADIUS, DIAMETER, DIAMETER);
            _graphics.FillEllipse(brush, (float)x2 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            _graphics.DrawEllipse(pen1, (float)x2 - RADIUS, (float)y2 - RADIUS, DIAMETER, DIAMETER);
            pen.Dispose();
            brush.Dispose();
        }

        //DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            const int HALF = 2;
            Pen blackPen = new Pen(Color.Black, 1);
            PointF point1 = new PointF((float)x1, (float)y1);
            PointF point2 = new PointF((float)(x1 + x2) / HALF, (float)y1);
            PointF point3 = new PointF((float)(x1 + x2) / HALF, (float)y2);
            PointF point4 = new PointF((float)x2, (float)y2);
            PointF[] curvePoints = { point1, point2, point3, point4 };
            _graphics.DrawLines(blackPen, curvePoints);
        }
    }
}

