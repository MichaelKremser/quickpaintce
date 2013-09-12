using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QuickPaint.Drawables
{
    interface IDrawableObject
    {
        void Draw(Graphics g);
    }
}
