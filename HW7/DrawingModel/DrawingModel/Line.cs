using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        const string LINE = "Line";

        //DrawLine
        public override void Draw(IGraphics graphics)
        {
            Shape shape1 = this.FirstShape;
            Shape shape2 = this.SecondShape;
            const double HALF = 2;
            if (shape1 != null && shape2 != null)
            {
                double x1 = (shape1.X1 + shape1.X2) / HALF;
                double y1 = (shape1.Y1 + shape1.Y2) / HALF;
                double x2 = (shape2.X1 + shape2.X2) / HALF;
                double y2 = (shape2.Y1 + shape2.Y2) / HALF;
                graphics.DrawLine(x1, y1, x2, y2);
            }
            else if (shape1 != null)
            {
                double x1 = (shape1.X1 + shape1.X2) / HALF;
                double y1 = (shape1.Y1 + shape1.Y2) / HALF;
                graphics.DrawLine(x1, y1, X2, Y2);
            }
        }

        //GetShapeType
        public override string GetShapeType()
        {
            return LINE;
        }

        //IsContains
        public override bool IsContains(double x1, double y1)
        {
            return false;
        }

        //GetSelectedPosition
        public override string GetSelectedPosition()
        {
            return "";
        }
    }
}
