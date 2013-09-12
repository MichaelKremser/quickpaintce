using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickPaint.Drawables
{
    [Serializable]
    class Line : FlatObject
    {
        public override void Draw(Graphics g)
        {
            g.DrawLine(UsedPen, Location.X, Location.Y, Points[0].X, Points[0].Y);
        }

        public static new int RequiredPoints { get { return 2; } }
    }
}
