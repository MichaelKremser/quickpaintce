using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickPaint.Drawables
{
    [Serializable]
    class EllipseObject : FlatObject
    {
        public override void Draw(System.Drawing.Graphics g)
        {
            int Width = Points[0].X - Location.X;
            int Height = Points[0].Y - Location.Y;
            Rectangle drawArea = new Rectangle(Location.X, Location.Y, Width, Height);
            if (FillMode == FillMode.BorderAndFill || FillMode == FillMode.OnlyFill)
            {
                g.FillEllipse(UsedBrush, drawArea);
            }
            if (FillMode == FillMode.BorderAndFill || FillMode == FillMode.OnlyBorder)
            {
                g.DrawEllipse(UsedPen, drawArea);
            }
        }

        public static new int RequiredPoints { get { return 2; } }
    }
}
