﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class Rectangle : Shape
    {
        const string RECTANGLE = "Rectangle";

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }

        //GetShapeType
        public override string GetShapeType()
        {
            return RECTANGLE;
        }

        //GetSelectedPosition
        public override string GetSelectedPosition()
        {
            const string LABEL = "{0}({1}, {2}, {3}, {4})";
            return string.Format(LABEL, RECTANGLE, this.X1, this.Y1, this.X2, this.Y2);
        }
    }
}
