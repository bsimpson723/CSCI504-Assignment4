using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCI504_Assignment4
{
    public partial class Form1 : Form
    {
        private ToolTip tt;
        private Pen pen = new Pen(Color.Black, 1);
        private Point start;
        private Point finish;

        public Form1()
        {
            InitializeComponent();
        }

        private void ColorMouseEnter(object sender, EventArgs e)
        {
            var textBox = (TextBox) sender;
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.IsBalloon = false;
            tt.Show(string.Empty, textBox);
            tt.Show(textBox.Name, textBox, 0);
        }

        private void CustomColorMouseEnter(object sender, EventArgs e)
        {
            var panel = (Panel)sender;
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.IsBalloon = false;
            tt.Show(string.Empty, panel);
            tt.Show(panel.Name, panel, 0);
        }

        private void ColorMouseExit(object sender, EventArgs e)
        {
            tt.Dispose();
        }

        private void CustomColorMouseExit(object sender, EventArgs e)
        {
            tt.Dispose();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                start = e.Location;
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
            finish = e.Location;

            panel1.CreateGraphics().DrawLine(pen, start, finish);
        }

        private void ColorClick(object sender, EventArgs e)
        {
            var textBox = (TextBox) sender;
            pen.Color = textBox.BackColor;
        }

        private void WidthChange(object sender, EventArgs e)
        {
            pen.Width = (float)WidthUpDown.Value;
        }
    }
}
