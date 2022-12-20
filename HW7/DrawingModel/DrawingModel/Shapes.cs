using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class Shapes
    {
        private ShapeFactory _shapeFactory;
        private List<Shape> _shapes;
        private Shape _shape;
        private const string LINE = "Line";

        public Shapes()
        {
            _shapes = new List<Shape>();
            _shapeFactory = new ShapeFactory();
        }

        //CreateShapeHint
        public Shape CreateShapeHint(string type)
        {
            return _shapeFactory.CreateShape(type);
        }

        //CreateShape
        public Shape CreateShape(string type, double[] points)
        {
            int index = 0;
            _shape = _shapeFactory.CreateShape(type);
            _shape.X1 = points[index++];
            _shape.Y1 = points[index++];
            _shape.X2 = points[index++];
            _shape.Y2 = points[index++];
            return _shape;
        }

        //CreateShape
        public Shape CreateShape(string type, Shape[] shapes)
        {
            int index = 0;
            _shape = _shapeFactory.CreateShape(type);
            _shape.FirstShape = shapes[index++];
            _shape.SecondShape = shapes[index];
            return _shape;
        }   

        //AddShapeDirect
        public void AddShapeDirect(Shape shape)
        {
            _shapes.Add(shape);
        }

        //Remove
        public void Remove()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            foreach (Shape aLine in _shapes)
                if (aLine.GetShapeType() == LINE)
                    aLine.Draw(graphics);
            foreach (Shape aLine in _shapes)
                if (aLine.GetShapeType() != LINE)
                    aLine.Draw(graphics);
        }

        //Clear
        public void Clear()
        {
            _shapes.Clear();
        }

        //GetShapes
        public List<Shape> GetShapes()
        {
            return this._shapes;
        }

        //CheckPointContains
        public Shape CheckPointContains(double pointX, double pointY)
        {
            Shape shape = null;
            for (int i = this._shapes.Count - 1; i >= 0; i--)
                if (_shapes[i].IsContains(pointX, pointY))
                {
                    shape = _shapes[i];
                    break;
                }
            return shape;
        }
    }
}
