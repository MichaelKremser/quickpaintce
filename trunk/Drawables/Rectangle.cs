using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace QuickPaint.Drawables
{
    [Serializable]
    class RectangleObject : FlatObject
    {
        public override void Draw(Graphics g)
        {
            int Width = Points[0].X - Location.X;
            int Height = Points[0].Y - Location.Y;
            Rectangle drawArea = new Rectangle(Location.X, Location.Y, Width, Height);
            if (FillMode == FillMode.BorderAndFill || FillMode == FillMode.OnlyFill)
            {
                g.FillRectangle(UsedBrush, drawArea);
            }
            if (FillMode == FillMode.BorderAndFill || FillMode == FillMode.OnlyBorder)
            {
                g.DrawRectangle(UsedPen, drawArea);
            }
        }

        public static new int RequiredPoints { get { return 2; } }
    }
}
