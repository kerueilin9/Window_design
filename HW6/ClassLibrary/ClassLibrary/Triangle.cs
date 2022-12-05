using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Triangle : Shape
    {
        const string TRIANGLE = "Triangle";

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
            graphics.DrawTriangle(this.X1, Y1, X2, Y2);
        }

        //GetShapeType
        public string GetShapeType()
        {
            return TRIANGLE;
        }
    }
}
