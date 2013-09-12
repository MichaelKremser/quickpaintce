using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickPaint.Drawables
{
    [Serializable]
    class CrossHair : PositionableObject
    {
        public CrossHair()
        {
            UsedPen = new Pen(Color.Black);
        }

        Pen UsedPen;
        readonly int size = 5;

        public override void Draw(Graphics g)
        {
            g.DrawLine(UsedPen, Location.X - size, Location.Y, Location.X + size, Location.Y); // horizontal line
            g.DrawLine(UsedPen, Location.X, Location.Y - size, Location.X, Location.Y + size); // vertical line
        }
    }
}
