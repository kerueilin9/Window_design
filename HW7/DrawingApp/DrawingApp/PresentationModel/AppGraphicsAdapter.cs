using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;

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
            const int HALF = 2;
            Windows.Foundation.Point point1 = new Windows.Foundation.Point((float)x1, (float)y1);
            Windows.Foundation.Point point2 = new Windows.Foundation.Point((float)(x1 + x2) / HALF, (float)y1);
            Windows.Foundation.Point point3 = new Windows.Foundation.Point((float)(x1 + x2) / HALF, (float)y2);
            Windows.Foundation.Point point4 = new Windows.Foundation.Point((float)x2, (float)y2);
            PointCollection points = new PointCollection();
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            Polyline polyline = new Polyline();
            polyline.Points = points;
            polyline.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(polyline);
        }

        //DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Windows.Foundation.Point point1 = new Windows.Foundation.Point((float)x1, (float)y1);
            Windows.Foundation.Point point2 = new Windows.Foundation.Point((float)x1, (float)y2);
            Windows.Foundation.Point point3 = new Windows.Foundation.Point((float)x2, (float)y2);
            Windows.Foundation.Point point4 = new Windows.Foundation.Point((float)x2, (float)y1);
            PointCollection points = new PointCollection();
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            Polygon polygon = new Polygon();
            polygon.Points = points;
            polygon.Fill = new SolidColorBrush(Colors.Yellow);
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(polygon);
        }

        //DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            const int HALF = 2;
            Windows.Foundation.Point point1 = new Windows.Foundation.Point((float)(x1 + x2) / HALF, (float)y1);
            Windows.Foundation.Point point2 = new Windows.Foundation.Point((float)x1, (float)y2);
            Windows.Foundation.Point point3 = new Windows.Foundation.Point((float)x2, (float)y2);
            PointCollection points = new PointCollection();
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            Polygon polygon = new Polygon();
            polygon.Points = points;
            polygon.Fill = new SolidColorBrush(Colors.Red);
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(polygon);
        }

        //DrawSelected
        public void DrawSelected(double x1, double y1, double x2, double y2)
        {
            Windows.Foundation.Point point1 = new Windows.Foundation.Point((float)x1, (float)y1);
            Windows.Foundation.Point point2 = new Windows.Foundation.Point((float)x1, (float)y2);
            Windows.Foundation.Point point3 = new Windows.Foundation.Point((float)x2, (float)y2);
            Windows.Foundation.Point point4 = new Windows.Foundation.Point((float)x2, (float)y1);
            PointCollection points = new PointCollection();
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            DoubleCollection doubles = new DoubleCollection();
            doubles.Add(3);
            doubles.Add(3);
            Polygon polygon = new Polygon();
            polygon.Points = points;
            polygon.StrokeDashArray = doubles;
            polygon.StrokeThickness = 3;
            polygon.Stroke = new SolidColorBrush(Colors.Red);
            _canvas.Children.Add(polygon);
            const double WIDTH = 6;
            const double RADIUS = WIDTH / 2;
            _canvas.Children.Add(CreateEllipse(x1 - RADIUS, y1 - RADIUS, WIDTH, WIDTH));
            _canvas.Children.Add(CreateEllipse(x1 - RADIUS, y2 - RADIUS, WIDTH, WIDTH));
            _canvas.Children.Add(CreateEllipse(x2 - RADIUS, y1 - RADIUS, WIDTH, WIDTH));
            _canvas.Children.Add(CreateEllipse(x2 - RADIUS, y2 - RADIUS, WIDTH, WIDTH));
        }

        private Windows.UI.Xaml.Shapes.Ellipse CreateEllipse(double x1, double y1, double width, double height)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.White);
            ellipse.Width = width;
            ellipse.Height = height;
            Canvas.SetLeft(ellipse, x1);
            Canvas.SetTop(ellipse, y1);
            return ellipse;
        }
    }
}
