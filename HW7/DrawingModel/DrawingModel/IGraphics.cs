using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public interface IGraphics 
    {
        //ClearAll
        void ClearAll();

        //DrawRectangle
        void DrawRectangle(double x1, double y1, double x2, double y2);

        //DrawTriangle
        void DrawTriangle(double x1, double y1, double x2, double y2);
    }
}
