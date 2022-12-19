using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        //Execute
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        //CancelExecute
        public void CancelExecute()
        {
            _model.DeleteShape();
        }
    }
}
