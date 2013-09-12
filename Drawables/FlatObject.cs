using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuickPaint.Drawables
{
    [Serializable]
    public abstract class FlatObject : PositionableObject
    {
        public FlatObject()
        {
            FillMode = FillMode.OnlyBorder;
            FillColor = Color.Transparent;
            Points = new List<Point>();
        }

        private Pen thePen;
        protected Pen UsedPen
        {
            get
            {
                if (thePen == null)
                    thePen = new Pen(PencilColor, PencilWidth);
                return thePen;
            }
        }

        private Brush theBrush;
        protected Brush UsedBrush
        {
            get
            {
                if (theBrush == null)
                    theBrush = new SolidBrush(FillColor);
                return theBrush;
            }
        }

        public FillMode FillMode { get; set; }
        public Color FillColor { get; set; }
        //public int Width { get; set; }
        //public int Height { get; set; }
        public List<Point> Points { get; set; }
    }
}
