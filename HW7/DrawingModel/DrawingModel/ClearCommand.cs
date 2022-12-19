using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ClearCommand : ICommand
    {
        Shapes _shapes;
        List<Shape> _shapeList;
        public ClearCommand(Shapes shapes)
        {
            _shapes = shapes;
            _shapeList = new List<Shape>();
        }

        //Execute
        public void Execute()
        {
            foreach (Shape shape in _shapes.GetShapes())
                _shapeList.Add(shape);
            _shapes.Clear();
        }

        //CancelExecute
        public void CancelExecute()
        {
            foreach (Shape shape in _shapeList)
                _shapes.AddShapeDirect(shape);
            _shapeList.Clear();
        }
    }
}
