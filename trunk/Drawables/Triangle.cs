using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickPaint.Drawables
{
    [Serializable]
    class Triangle : FlatObject
    {
        public override void Draw(Graphics g)
        {
            Point[] allPoints = new Point[Points.Count + 1];
            allPoints[0] = Location;
            Points.CopyTo(allPoints, 1);
            if (FillMode == FillMode.BorderAndFill || FillMode == FillMode.OnlyFill)
            {
                g.FillPolygon(UsedBrush, allPoints);
            }
            if (FillMode == FillMode.BorderAndFill || FillMode == FillMode.OnlyBorder)
            {
                g.DrawPolygon(UsedPen, allPoints);
            }
        }

        public static new int RequiredPoints { get { return 3; } }
    }
}
