using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickPaint
{
    public partial class SelectColor : Form
    {
        public SelectColor()
        {
            InitializeComponent();

            GenerateColorSelectionButtons();
        }

        private readonly int buttonWidth = 40;
        private readonly int buttonHeight = 40;
        public Color SelectedColor
        {
            get;
            private set;
        }

        private void GenerateColorSelectionButtons()
        {
            Color[] selectableColors = new Color[] {
                Color.Black, Color.DarkGray, Color.Gray, Color.LightGray, Color.White, Color.Plum
                , Color.Red, Color.Lime, Color.Blue, Color.Yellow, Color.Cyan, Color.BlueViolet
                , Color.DarkRed, Color.Green, Color.DarkBlue, Color.Orange, Color.LightCyan, Color.HotPink
                , Color.MintCream, Color.LightGreen , Color.LightBlue, Color.LightYellow, Color.Khaki, Color.LightPink
            };
            Button chooseColorButton;
            int X = 0, Y = 0;
            foreach (Color colorX in selectableColors)
            {
                chooseColorButton = new Button();
                chooseColorButton.BackColor = colorX;
                chooseColorButton.Left = X;
                chooseColorButton.Top = Y;
                chooseColorButton.Size = new Size(buttonWidth, buttonHeight);
                X += buttonWidth;
                if (X >= this.Width)
                {
                    X = 0;
                    Y += buttonHeight;
                }
                chooseColorButton.Click += new EventHandler(chooseColorButton_Click);
                Controls.Add(chooseColorButton);
            }
        }

        void chooseColorButton_Click(object sender, EventArgs e)
        {
            SelectedColor = ((Button)sender).BackColor;
            this.Close();
        }
    }
}