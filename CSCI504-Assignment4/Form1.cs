using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        private Stack<Line> undoLines = new Stack<Line>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ColorMouseEnter(object sender, EventArgs e)
        {
            var panel = (Panel) sender;
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
            if (!start.IsEmpty && !finish.IsEmpty)
                undoLines.Push(new Line(new Pen(pen.Color, pen.Width), new Tuple<Point,Point>(start, finish)));
            start = Point.Empty;
            finish = Point.Empty;
            Refresh();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var line in undoLines)
                e.Graphics.DrawLine(line.Pen, line.Points.Item1, line.Points.Item2);
            if (!start.IsEmpty && !finish.IsEmpty)
                e.Graphics.DrawLine(pen, start, finish);
        }

        private void ColorClick(object sender, EventArgs e)
        {
            var panel = (Panel) sender;
            pen.Color = panel.BackColor;
            SelectedColor.BackColor = panel.BackColor;
        }

        private void WidthChange(object sender, EventArgs e)
        {
            pen.Width = (float)WidthUpDown.Value;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile.ShowDialog();
        }

        private void saveFile_FileOk(object sender, CancelEventArgs e)
        {
            var width = DrawPanel.Width;
            var height = DrawPanel.Height;
            Bitmap bm = new Bitmap(width, height);
            DrawPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            bm.Save(saveFile.FileName, ImageFormat.Png);
        }
    }
}
