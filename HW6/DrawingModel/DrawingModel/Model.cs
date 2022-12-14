using System.Collections.Generic;

namespace ClassLibrary
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private double _firstPointX;
        private double _firstPointY;
        private bool _isPressed = false;
        private Shapes _shapes = new Shapes();
        private Shape _hint;
        private string _type = "";

        //SetType
        public void SetType(string type)
        {
            _type = type;
        }

        //PressedPointer
        public void PressedPointer(double x1, double y1)
        {
            if (x1 > 0 && y1 > 0 && _type != "")
            {
                _hint = _shapes.CreateShapeHint(_type);
                _firstPointX = x1;
                _firstPointY = y1;
                _hint.X1 = _firstPointX;
                _hint.Y1 = _firstPointY; 
                _isPressed = true;
            }
        }

        //MovedPointer
        public void MovedPointer(double x2, double y2)
        {
            if (_isPressed && _type != "")
            {
                _hint.X2 = x2;
                _hint.Y2 = y2;
                NotifyModelChanged();
            }
        }

        //ReleasedPointer
        public void ReleasedPointer(double x2, double y2)
        {
            if (_isPressed && _type != "")
            {
                _isPressed = false;
                double[] points = new double[] { _firstPointX, _firstPointY, x2, y2 };
                _shapes.CreateShape(_type, points);
                _type = "";
                NotifyModelChanged();
            }
        }

        //Clear
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
        }

        //GetShape
        public Shape GetShape()
        {
            return _hint;
        }

        //GetShapes
        public Shapes GetShapes()
        {
            return _shapes;
        }

        //GetTypeString
        public string GetTypeString()
        {
            return _type;
        }

        //NotifyModelChanged
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
