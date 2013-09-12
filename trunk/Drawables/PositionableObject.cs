using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickPaint.Drawables
{
    [Serializable]
    public abstract class PositionableObject : IDrawableObject
    {
        public PositionableObject()
        {
            PencilColor = Color.Black;
            PencilWidth = 1;
        }

        public Point Location { get; set; }
        public Color PencilColor { get; set; }
        public float PencilWidth { get; set; }

        public abstract void Draw(Graphics g);
        public static int RequiredPoints { get { return 0; } }
    }
}
