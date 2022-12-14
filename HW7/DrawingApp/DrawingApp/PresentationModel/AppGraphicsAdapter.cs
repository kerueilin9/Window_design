using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using ClassLibrary;

namespace DrawingApp.PresentationModel
{
    public class AppGraphicsAdapter : IGraphics
    {
        Canvas _canvas;

        public AppGraphicsAdapter(Canvas canvas)
        {
            this._canvas = canvas;
        }

        //ClearAll
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        //DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Polyline lines = new Polyline();
            Windows.Foundation.Point point1 = new Windows.Foundation.Point((float)x1, (float)y1);
            Windows.Foundation.Point point2 = new Windows.Foundation.Point((float)x1, (float)y2);
            Windows.Foundation.Point point3 = new Windows.Foundation.Point((float)x2, (float)y2);
            Windows.Foundation.Point point4 = new Windows.Foundation.Point((float)x2, (float)y1);
            lines.Points.Add(point1);
            lines.Points.Add(point2);
            lines.Points.Add(point3);
            lines.Points.Add(point4);
            lines.Points.Add(point1);
            lines.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(lines);
        }

        //DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            const int HALF = 2;
            Polyline lines = new Polyline();
            Windows.Foundation.Point point1 = new Windows.Foundation.Point((float)(x1 + x2) / HALF, (float)y1);
            Windows.Foundation.Point point2 = new Windows.Foundation.Point((float)x1, (float)y2);
            Windows.Foundation.Point point3 = new Windows.Foundation.Point((float)x2, (float)y2);
            lines.Points.Add(point1);
            lines.Points.Add(point2);
            lines.Points.Add(point3);
            lines.Points.Add(point1);
            lines.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(lines);
        }
    }
}
