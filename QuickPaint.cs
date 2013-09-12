using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using QuickPaint.Drawables;
using System.Reflection;

namespace QuickPaint
{
    public partial class QuickPaint : Form
    {
        public QuickPaint()
        {
            InitializeComponent();

            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            this.Text = assemblyName.Name + " " + assemblyName.Version.ToString(3);

            objectsToDraw = new List<IDrawableObject>();
            CurrentObjectType = typeof(RectangleObject);
            availableFillModes = new FillMode[] { FillMode.OnlyBorder, FillMode.BorderAndFill, FillMode.OnlyFill };
            InitFillMode2Button();
            InitFillKey2Type();
            lastPoints = new List<Point>();
            AddImagesToImageList();

            //FillObjectsToDrawWithTestData();
        }

        private void AddImagesToImageList()
        {
        }

        private void InitFillKey2Type()
        {
            Key2Type = new Dictionary<Keys, Type>();
            Key2Type.Add(Keys.R, typeof(RectangleObject));
            Key2Type.Add(Keys.E, typeof(EllipseObject));
            Key2Type.Add(Keys.T, typeof(Triangle));
            Key2Type.Add(Keys.L, typeof(Line));
        }

        private void InitFillMode2Button()
        {
            FillMode2Button = new Dictionary<FillMode, int>();
            FillMode2Button.Add(FillMode.OnlyBorder, 3);
            FillMode2Button.Add(FillMode.BorderAndFill, 4);
            FillMode2Button.Add(FillMode.OnlyFill, 5);
        }

        Type CurrentObjectType;
        Color CurrentBorderColor = Color.Black;
        Color CurrentFillColor = Color.Lime;
        FillMode CurrentFillMode = FillMode.OnlyBorder;
        float CurrentPencilWidth = 1;

        List<IDrawableObject> objectsToDraw; // List of all drewn objects
        FillMode[] availableFillModes; // Contains a list of all available fill modes (may vary on object type)
        int requiredPoints = 2; // Number of points the user has to click in order to enable drawing a specific object
        List<Point> lastPoints;
        Type[] emptyTypeArray = new Type[] { };
        object[] emptyObjectArray = new object[] { };
        readonly int maximumPencilWidth = 4;
        readonly int pencilImageIndexBase = 8;

        Dictionary<FillMode, int> FillMode2Button;
        Dictionary<Keys, Type> Key2Type; // used to assign a key to a type

        //private void FillObjectsToDrawWithTestData()
        //{
            //objectsToDraw.Add(new RectangleObject { Location = new Point(10, 10), Height = 100, Width = 100, PencilColor = Color.Green });
            //objectsToDraw.Add(new EllipseObject { Location = new Point(50, 80), Height = 100, Width = 100, PencilColor = Color.Blue, FillColor = Color.Yellow, FillMode = FillMode.BorderAndFill });
            //objectsToDraw.Add(new RectangleObject { Location = new Point(5, 160), Height = 70, Width = 50, FillColor = Color.Lime, FillMode = FillMode.OnlyFill });
        //}

        private void QuickPaint_Paint(object sender, PaintEventArgs e)
        {
            // e.ClipRectangle TO DO: be aware!
            Trace.WriteLine("QuickPaint_Paint");
            foreach (IDrawableObject objectToDraw in objectsToDraw)
            {
                Trace.WriteLine("Drawing object " + objectToDraw.ToString());
                objectToDraw.Draw(e.Graphics);
            }
        }

        private void QuickPaint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                AskToQuit();
            }
            else
            {
                if (Key2Type.ContainsKey(e.KeyCode))
                {
                    ChangeObjectType(Key2Type[e.KeyCode]);
                }
                else
                {
                    if (e.KeyCode == Keys.F)
                    {
                        toolBarButtonFillMode_Click();
                    }
                }
            }
        }

        private void ChangeObjectType(Type type)
        {
            CurrentObjectType = type;
            Trace.WriteLine(string.Format("Selected object type: {0}", CurrentObjectType.Name));
            PropertyInfo propRequiredPoints = CurrentObjectType.GetProperty("RequiredPoints", BindingFlags.Static | BindingFlags.Public);
            requiredPoints = (int)propRequiredPoints.GetValue(null, emptyObjectArray);
            Trace.WriteLine(string.Format("Requires {0} points", requiredPoints.ToString()));
        }

        private void AskToQuit()
        {
            if (MessageBox.Show("Beenden?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void QuickPaint_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoints.Add(new Point(e.X, e.Y));
            if (lastPoints.Count == requiredPoints)
            {
                Trace.WriteLine("Sufficient points available; generating requested object...");
                FlatObject newObject = CurrentObjectType.GetConstructor(emptyTypeArray).Invoke(emptyTypeArray) as FlatObject;
                if (newObject != null)
                {
                    Trace.WriteLine("...success!");
                    newObject.Location = lastPoints[0]; // new Point(X1, Y1);
                    for (int ptr = 1; ptr < lastPoints.Count; ptr++)
                        newObject.Points.Add(lastPoints[ptr]);
                    newObject.PencilColor = CurrentBorderColor;
                    newObject.FillColor = CurrentFillColor;
                    newObject.FillMode = CurrentFillMode;
                    newObject.PencilWidth = CurrentPencilWidth;
                    ResetPoints();
                    objectsToDraw.Add(newObject);
                    this.Refresh();
                }
                else
                {
                    Trace.WriteLine("...failed! :-(");
                }
            }
            else
            {
                Trace.WriteLine("Added a cross hair.");
                objectsToDraw.Add(new CrossHair { Location = new Point(e.X, e.Y) });
                this.Refresh();
            }
        }

        private void RemoveLastElement<T>(List<T> list)
        {
            if (list.Count > 0)
                list.RemoveAt(list.Count - 1);
        }

        private void ResetPoints()
        {
            while (lastPoints.Count > 0)
            {
                lastPoints.RemoveAt(lastPoints.Count - 1);
                if (lastPoints.Count > 0)
                {
                    objectsToDraw.RemoveAt(objectsToDraw.Count - 1);
                }
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonNew)
            {
                toolBarButtonNew_Click();
            }
            if (e.Button == toolBarButtonObjectType)
            {
                toolBarButtonObjectType_Click();
            }
            if (e.Button == toolBarButtonPencilColor || e.Button == toolBarButtonFillColor)
            {
                ChangeColor(e.Button == toolBarButtonPencilColor ? ColorType.Pencil : ColorType.Fill);
            }
            if (e.Button == toolBarButtonDelete)
            {
                toolBarButtonDelete_Click();
            }
            if (e.Button == toolBarButtonFillMode)
            {
                toolBarButtonFillMode_Click();
            }
            if (e.Button == toolBarButtonPencilWidth)
            {
                changePencilWidth();
            }
            if (e.Button == toolBarButtonQuit)
            {
                AskToQuit();
            }
        }

        private void changePencilWidth()
        {
            CurrentPencilWidth++;
            if (CurrentPencilWidth > maximumPencilWidth)
                CurrentPencilWidth = 1;
            toolBarButtonPencilWidth.ImageIndex = pencilImageIndexBase + (int)CurrentPencilWidth - 1;
        }

        private void toolBarButtonDelete_Click()
        {
            RemoveLastElement(objectsToDraw);
            this.Refresh();
        }

        private void toolBarButtonNew_Click()
        {
            objectsToDraw.Clear();
            this.Refresh();
        }

        private void toolBarButtonObjectType_Click()
        {
            var dlg = new SelectObjectType();
            dlg.ShowDialog();
            ChangeObjectType(dlg.SelectedType);
        }

        private void ChangeColor(ColorType colorType)
        {
            var dlg = new SelectColor();
            dlg.ShowDialog();
            Color selectedColor = dlg.SelectedColor;
            if (colorType == ColorType.Pencil)
            {
                CurrentBorderColor = selectedColor;
            }
            else
            {
                CurrentFillColor = selectedColor;
            }
        }

        private void toolBarButtonFillMode_Click()
        {
            int ptr = Array.IndexOf(availableFillModes, CurrentFillMode);
            ptr++;
            if (ptr == availableFillModes.Length)
            {
                ptr = 0;
            }
            CurrentFillMode = availableFillModes[ptr];
            toolBarButtonFillMode.ImageIndex = FillMode2Button[CurrentFillMode];
        }
    }

    /// <summary>
    /// Which color should be saved.
    /// </summary>
    public enum ColorType
    {
        Unknown,
        Pencil,
        Fill
    }
}