using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Rectangle : Shape
    {
        const string RECTANGLE = "Rectangle";

        public double X1
        {
            get;
            set;
        }
        public double Y1
        {
            get;
            set;
        }
        public double X2
        {
            get;
            set;
        }
        public double Y2
        {
            get;
            set;
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }

        //GetShapeType
        public string GetShapeType()
        {
            return RECTANGLE;
        }
    }
}
