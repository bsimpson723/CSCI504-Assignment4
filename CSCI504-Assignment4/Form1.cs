using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CSCI504_Assignment4;

namespace CSCI504_Assignment4
{
    public partial class Form1 : Form
    {
        private enum Tool
        {
            Line,
            Brush,
            Pencil,
            Eraser
        };
        private Tool tool = Tool.Line;
        private ToolTip tt;
        private Pen pen = new Pen(Color.Black, 1);
        private Point start;
        private Point finish;
        private Stack<Line> undoLines = new Stack<Line>();
        private Stack<Line> redoLines = new Stack<Line>();
        private string fileName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void DisplayTooltip(object sender, EventArgs e)
        {
            var panel = (Panel) sender;
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.IsBalloon = false;
            tt.Show(string.Empty, panel);
            tt.Show(panel.Name, panel, 0);
        }

        private void HideTooltip(object sender, EventArgs e)
        {
            tt.Dispose();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                start = e.Location;
                redoLines.Clear();      //once you draw a new line
                Redo.Enabled = false;   //"Redo" is no longer possible
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
            Undo.Enabled = true;    //as soon as a line exists we want to be able to undo it.
            DrawPanel.Invalidate();
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

        private void Save(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                SaveAs(sender, e);  //if string is empty it means it's a new project and we need to call save as
            }
            else
            {
                var width = DrawPanel.Width;
                var height = DrawPanel.Height;
                Bitmap bm = new Bitmap(width, height);
                DrawPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                bm.Save(fileName, ImageFormat.Png);
            }
        }

        private void SaveAs(object sender, EventArgs e)
        {
            saveFile.ShowDialog();
        }

        private void SaveAsFileOk(object sender, CancelEventArgs e)
        {
            var width = DrawPanel.Width;
            var height = DrawPanel.Height;
            Bitmap bm = new Bitmap(width, height);
            DrawPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            bm.Save(saveFile.FileName, ImageFormat.Png);
        }

        private void UndoClick(object sender, EventArgs e)
        {
            var line = undoLines.Pop(); //pop line from undoList
            redoLines.Push(line);       //add line to redoList
            Redo.Enabled = true;        //as soon as a line is undone we want to be able to redo it.
            if (!undoLines.Any())
            {
                Undo.Enabled = false;   //if the undo list is empty disable the button
            }
            DrawPanel.Invalidate();     //redraw the Draw Panel
        }

        private void RedoClick(object sender, EventArgs e)
        {
            var line = redoLines.Pop(); //pop line from the redoList
            undoLines.Push(line);       //add line back to the undoList
            Undo.Enabled = true;        //as soon as a line is redone we want to be able to undo it.
            if (!redoLines.Any())
            {
                Redo.Enabled = false;   //if the redo list is empty disable the button
            }
            DrawPanel.Invalidate();     //redraw the Draw Panel
        }

        private void LineRadioSelected(object sender, EventArgs e)
        {
            WidthUpDown.Minimum = 1;
            WidthUpDown.Maximum = 5;
            tool = Tool.Line;
        }

        private void OpenFileClick(object sender, EventArgs e)
        {
            DialogResult response = DialogResult.Cancel;
            if (undoLines.Any() || redoLines.Any())
            {
                response = MessageBox.Show("Would you like to save your changes first?", "Unsaved Changes!", MessageBoxButtons.OKCancel);
            }
            if (response == DialogResult.OK)
            {
                Save(sender, e);
                MessageBox.Show("Your file has been saved!");
            }
            openFile.ShowDialog();
        }

        private void OpenFileOk(object sender, CancelEventArgs e)
        {
            var openFileDialogue = (OpenFileDialog)sender;
            fileName = openFileDialogue.FileName;

            Image img;
            using (var bmpTemp = new Bitmap(fileName))
            {
                img = new Bitmap(bmpTemp);
            }
            
            DrawPanel.BackgroundImage = img;
            undoLines.Clear();
            Undo.Enabled = false;
            redoLines.Clear();
            Redo.Enabled = false;
            DrawPanel.Invalidate();
        }

        private void NewImageClick(object sender, EventArgs e)
        {
            DialogResult response = DialogResult.Cancel;
            if (undoLines.Any() || redoLines.Any())
            {
                response = MessageBox.Show("Would you like to save your changes first?", "Unsaved Changes!", MessageBoxButtons.OKCancel);
            }
            if (response == DialogResult.OK)
            {
                Save(sender, e);
                MessageBox.Show("Your file has been saved!");
            }

            undoLines.Clear();
            Undo.Enabled = false;
            redoLines.Clear();
            Redo.Enabled = false;
            fileName = string.Empty;
            DrawPanel.Invalidate();
        }
    }
}
