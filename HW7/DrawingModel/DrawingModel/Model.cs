using System.Collections.Generic;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        CommandManager _commandManager = new CommandManager();
        private double _firstPointX;
        private double _firstPointY;
        private Shape _firstShape;
        private bool _isPressed = false;
        private Shapes _shapes = new Shapes();
        private Shape _hint;
        private string _type = "";
        private Shape _selectedShape;
        private const string LINE = "Line";
        private bool _isLineEnable = true;

        //SetType
        public void SetType(string type)
        {
            _type = type;
        }

        //PressedPointer
        public void PressedPointer(double x1, double y1)
        {
            if (x1 > 0 && y1 > 0)
            {
                if (_type == "")
                {
                    _selectedShape = _shapes.CheckPointContains(x1, y1);
                    _isPressed = false;
                }
                else if (_type == LINE && _shapes.CheckPointContains(x1, y1) != null)
                    DrawLinePressedPointer(x1, y1);
                else
                    DrawOrderPressedPointer(x1, y1);
                NotifyModelChanged();
            }
        }

        //DrawLinePressedPointer
        public void DrawLinePressedPointer(double x1, double y1)
        {
            //_hint = _shapes.CreateShapeHint(_type);
            _hint = new Line();
            _firstShape = _shapes.CheckPointContains(x1, y1);
            _hint.FirstShape = _firstShape;
            _hint.X2 = x1;
            _hint.Y2 = y1;
            _isPressed = true;
        }

        //DrawOrderPressedPointer
        public void DrawOrderPressedPointer(double x1, double y1)
        {
            _hint = _shapes.CreateShapeHint(_type);
            _firstPointX = x1;
            _firstPointY = y1;
            _hint.X1 = _firstPointX;
            _hint.Y1 = _firstPointY;
            _hint.X2 = x1;
            _hint.Y2 = y1;
            _isPressed = true;
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
            _isLineEnable = true;
            if (_isPressed && _type == LINE)
                if (_shapes.CheckPointContains(x2, y2) != null)
                {
                    Shape[] shapes = new Shape[] { _firstShape, _shapes.CheckPointContains(x2, y2) };
                    _commandManager.Execute(new DrawCommand(this, _shapes.CreateShape(_type, shapes)));
                    _type = "";
                } else
                    _isLineEnable = false;
            else if (_isPressed && _type != "")
            {
                double[] points = new double[] { _firstPointX, _firstPointY, x2, y2 };
                _commandManager.Execute(new DrawCommand(this, _shapes.CreateShape(_type, points)));
                _type = "";
            }
            _isPressed = false;
            NotifyModelChanged();
        }

        //GetSelectedPosition
        public string GetSelectedPosition()
        {
            if (_selectedShape != null)
                return _selectedShape.GetSelectedPosition();
            else
                return "";
        }

        //Clear
        public void Clear()
        {
            _isPressed = false;
            if (_shapes.GetShapes().Count != 0)
                _commandManager.Execute(new ClearCommand(_shapes));
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
            if (_selectedShape != null && _shapes.GetShapes().Contains(_selectedShape))
                _selectedShape.DrawSelected(graphics);
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

        //DrawShape
        public void DrawShape(Shape shape)
        {
            _shapes.AddShapeDirect(shape);
        }

        //DeleteShape
        public void DeleteShape()
        {
            _shapes.Remove();
        }

        //Undo
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        //Redo
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        //GetIsLineEnabled
        public bool GetIsLineEnabled()
        {
            return _isLineEnable;
        }
    }
}
