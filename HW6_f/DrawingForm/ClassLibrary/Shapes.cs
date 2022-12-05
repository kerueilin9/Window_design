using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Shapes
    {
        private ShapeFactory _shapeFactory;
        private List<Shape> _shapes;
        private Shape _shape;

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
        public void CreateShape(string type, double[] points)
        {
            int index = 0;
            _shape = _shapeFactory.CreateShape(type);
            _shape.X1 = points[index++];
            _shape.Y1 = points[index++];
            _shape.X2 = points[index++];
            _shape.Y2 = points[index++];
            _shapes.Add(_shape);
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            foreach (Shape aLine in _shapes)
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
    }
}
