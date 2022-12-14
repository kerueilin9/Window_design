using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class ShapeFactory
    {
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";

        //CreateShape
        public Shape CreateShape(string type)
        {
            if (type == TRIANGLE)
                return new Triangle();
            if (type == RECTANGLE)
                return new Rectangle();
            else
                return null;
        }
    }
}
