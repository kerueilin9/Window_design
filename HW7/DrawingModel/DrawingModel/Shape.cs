using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public interface Shape
    {
        //Draw
        void Draw(IGraphics graphics);

        //GetShapeType
        string GetShapeType();

        double X1
        {
            get;
            set;
        }

        double X2
        {
            get;
            set;
        }

        double Y1
        {
            get;
            set;
        }

        double Y2
        {
            get;
            set;
        }
    }
}
