using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public class Triangle : Shape
    {
        const string TRIANGLE = "Triangle";

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(this.X1, Y1, X2, Y2);
        }

        //GetShapeType
        public override string GetShapeType()
        {
            return TRIANGLE;
        }

        //GetSelectedPosition
        public override string GetSelectedPosition()
        {
            const string LABEL = "Selectde：{0}({1}, {2}, {3}, {4})";
            return string.Format(LABEL, TRIANGLE, this.X1, this.Y1, this.X2, this.Y2);
        }
    }
}
