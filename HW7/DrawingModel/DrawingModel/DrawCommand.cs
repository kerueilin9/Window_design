using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DrawCommand : ICommand
    {
        Shape _rect;
        Model _model;
        public DrawCommand(Model m, Shape r)
        {
            _rect = r;
            _model = m;
        }

        public void Execute()
        {
            _model.DrawShape(_rect);
        }

        public void UnExecute()
        {
            _model.DeleteShape();
        }
    }
}
