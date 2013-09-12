using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickPaint.Drawables;

namespace QuickPaint
{
    public partial class SelectObjectType : Form
    {
        public SelectObjectType()
        {
            InitializeComponent();

            AddObjectTypePictureBoxes();
        }

        public Type SelectedType { get; private set; }

        private void AddObjectTypePictureBoxes()
        {
            var objectTypes = new Type[] { typeof(Line), typeof(RectangleObject), typeof(EllipseObject), typeof(Triangle) };
            var whiteBrush = new SolidBrush(Color.White);
            var blackPen = new Pen(Color.Black);
            PictureBox newPictureBox;
            int X = 8, Y = 8;
            Rectangle drawArea;
            const int pictureBoxWidth = 48;
            const int pictureBoxHeight = 48;
            foreach (var t in objectTypes)
            {
                var img = new Bitmap(pictureBoxWidth, pictureBoxHeight);
                drawArea = new Rectangle(1, 1, img.Width - 2, img.Height - 2);
                using (var canvas = Graphics.FromImage(img))
                {
                    canvas.FillRectangle(whiteBrush, 0, 0, img.Width, img.Height);
                    switch (t.Name)
                    {
                        case "RectangleObject":
                            canvas.DrawRectangle(blackPen, drawArea);
                            break;
                        case "EllipseObject":
                            canvas.DrawEllipse(blackPen, drawArea);
                            break;
                        case "Line":
                            canvas.DrawLine(blackPen, 0, 0, pictureBoxWidth, pictureBoxHeight);
                            break;
                        case "Triangle":
                            canvas.DrawLine(blackPen, 0, pictureBoxHeight, pictureBoxWidth / 2, 0);
                            canvas.DrawLine(blackPen, pictureBoxWidth / 2, 0, pictureBoxWidth, pictureBoxHeight);
                            canvas.DrawLine(blackPen, 0, pictureBoxHeight, pictureBoxWidth, pictureBoxHeight);
                            break;
                    }
                    newPictureBox = new PictureBox();
                    newPictureBox.Location = new Point(X, Y);
                    newPictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                    newPictureBox.Image = img;
                    newPictureBox.Tag = t;
                    newPictureBox.Click += new EventHandler((object sender, EventArgs evt) => {
                        SelectedType = (Type)((Control)sender).Tag;
                        this.Close();
                    });
                    Controls.Add(newPictureBox);
                }
                X += newPictureBox.Width + 8;
                if (X >= this.Width - newPictureBox.Width)
                    Y += newPictureBox.Height + 8;
            }
            /*var img = new Bitmap(16, 16);
            var canvas = Graphics.FromImage(img);
            canvas.DrawRectangle(new Pen(Color.Red), 2, 2, 14, 14);
            //toolbarImages.Images.Add(img);
            canvas.Dispose();
            //toolBarButtonFillColor.ImageIndex = toolbarImages.Images.Count - 1;*/
        }
    }
}