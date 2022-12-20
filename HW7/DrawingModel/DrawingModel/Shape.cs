using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel
{
    public abstract class Shape
    {
        protected double _largeX;
        protected double _smallX;
        protected double _largeY;
        protected double _smallY;

        //Draw
        abstract public void Draw(IGraphics graphics);

        //GetShapeType
        abstract public string GetShapeType();

        //IsContains
        virtual public bool IsContains(double x1, double y1)
        {
            _largeX = this.X1 > this.X2 ? this.X1 : this.X2;
            _smallX = this.X1 > this.X2 ? this.X2 : this.X1;
            _largeY = this.Y1 > this.Y2 ? this.Y1 : this.Y2;
            _smallY = this.Y1 > this.Y2 ? this.Y2 : this.Y1;
            return x1 >= _smallX && x1 <= _largeX && y1 >= _smallY && y1 <= _largeY;
        }

        //DrawSelected
        virtual public void DrawSelected(IGraphics graphics)
        {
            graphics.DrawSelected(this._smallX, this._smallY, this._largeX, this._largeY);
        }

        //GetSelectedPosition
        abstract public string GetSelectedPosition();

        public double X1
        {
            get;
            set;
        }

        public double X2
        {
            get;
            set;
        }

        public double Y1
        {
            get;
            set;
        }

        public double Y2
        {
            get;
            set;
        }

        public Shape FirstShape
        {
            get;
            set;
        }

        public Shape SecondShape
        {
            get;
            set;
        }
    }
}
