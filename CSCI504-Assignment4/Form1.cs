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
        private Pen pen;
        private Point start;
        private Point finish;
        private string fileName = string.Empty;
        private Timer timer;
        private Stack<Line> redoLines;
        private Stack<Line> drawLines;

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 1);
            redoLines = new Stack<Line>();
            drawLines = new Stack<Line>();
            timer = new Timer();
            RecentImages();
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
                if (!LineRadio.Checked)
                {
                    timer.Tick += DrawImage;
                    timer.Interval = 10;
                    timer.Start();
                }
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
            finish = e.Location;
            if (!start.IsEmpty && !finish.IsEmpty)
                if (LineRadio.Checked)
                {
                    drawLines.Push(new Line(new Pen(pen.Color, pen.Width), new Tuple<Point, Point>(start, finish)));
                }
            start = Point.Empty;
            finish = Point.Empty;
            Undo.Enabled = true;    //as soon as a line exists we want to be able to undo it.
            DrawPanel.Invalidate();
        }
        
        private void DrawImage(object sender, EventArgs e)
        {
            finish = DrawPanel.PointToClient(Cursor.Position);
            drawLines.Push(new Line(new Pen(pen.Color, pen.Width), new Tuple<Point, Point>(start, finish)));
            start = finish;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var line in drawLines.Reverse())   //This prints the stack in reverse order so that the most recent line is on top.
                e.Graphics.DrawLine(line.Pen, line.Points.Item1, line.Points.Item2);
            if (!start.IsEmpty && !finish.IsEmpty)
                e.Graphics.DrawLine(pen, start, finish);
            timer.Stop();
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
                MessageBox.Show("Your file has been saved!");
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
            MessageBox.Show("Your file has been saved!");
        }

        private void UndoClick(object sender, EventArgs e)
        {
            var line = drawLines.Pop();     //pop line from drawLines
            redoLines.Push(line);           //add line to redoLines
            Redo.Enabled = true;            //as soon as a line is undone we want to be able to redo it.
            if (!drawLines.Any())
            {
                Undo.Enabled = false;       //if drawLines is empty disable the undo button
            }
            DrawPanel.Invalidate();         //redraw the Draw Panel
        }

        private void RedoClick(object sender, EventArgs e)
        {
            var line = redoLines.Pop();     //pop line from redoLines
            drawLines.Push(line);           //add line back to drawLines
            Undo.Enabled = true;            //as soon as a line is redone we want to be able to undo it.
            if (!redoLines.Any())
            {
                Redo.Enabled = false;       //if redoLines is empty disable the redo button
            }
            DrawPanel.Invalidate();         //redraw the Draw Panel
        }

        private void ToolSelected(object sender, EventArgs e)
        {
            if (LineRadio.Checked)
            {
                WidthUpDown.Minimum = 1;
                WidthUpDown.Maximum = 5;
                pen.Color = SelectedColor.BackColor;
                tool = Tool.Line;
                WidthUpDown.Value = 1;
            }
            else if (PencilRadio.Checked)
            {
                WidthUpDown.Minimum = 1;
                WidthUpDown.Maximum = 3;
                pen.Color = SelectedColor.BackColor;
                tool = Tool.Pencil;
                WidthUpDown.Value = 1;
            }
            else if (BrushRadio.Checked)
            {
                WidthUpDown.Minimum = 5;
                WidthUpDown.Maximum = 8;
                pen.Color = SelectedColor.BackColor;
                tool = Tool.Brush;
                WidthUpDown.Value = 5;
            }
            else if (EraserRadio.Checked)
            {
                WidthUpDown.Minimum = 1;
                WidthUpDown.Maximum = 10;
                pen.Color = DrawPanel.BackColor;
                tool = Tool.Eraser;
                WidthUpDown.Value = 1;
            }
        }

        private void OpenFileClick(object sender, EventArgs e)
        {
            DialogResult response = DialogResult.Cancel;
            if (drawLines.Any() || redoLines.Any())
            {
                ShowUnsavedChangedWarning(sender, e);
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
            drawLines.Clear();
            Undo.Enabled = false;
            redoLines.Clear();
            Redo.Enabled = false;
            DrawPanel.Invalidate();
        }

        private void NewImageClick(object sender, EventArgs e)
        {
            if (drawLines.Any() || redoLines.Any())
            {
                ShowUnsavedChangedWarning(sender, e);
            }

            drawLines.Clear();
            Undo.Enabled = false;
            redoLines.Clear();
            Redo.Enabled = false;
            fileName = string.Empty;
            DrawPanel.BackgroundImage = null;
            DrawPanel.Invalidate();
        }

        private void ShowUnsavedChangedWarning(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Would you like to save your changes first?", "Unsaved Changes!", MessageBoxButtons.YesNo);
            if (response == DialogResult.Yes)
            {
                Save(sender, e);
            }
        }
        
        private void Custom_Click(object sender, EventArgs e)
        {
            if (customColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                pen.Color = customColorDialog.Color;
                SelectedColor.BackColor = customColorDialog.Color;
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                UndoClick(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                RedoClick(sender, e);
            }
        }
        
        private void RecentImages()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"RecentImages.txt"))
                {
                    String image;
                    while ((image = sr.ReadLine()) != null)
                        recentlyOpenedToolStripMenuItem.DropDownItems.Add(image);
                }
            }
            catch
            {
                Console.WriteLine("RecentImages.txt file could not be read.");
            }

            foreach (ToolStripMenuItem images in recentlyOpenedToolStripMenuItem.DropDownItems)
                images.Click += new EventHandler(RecentImagesClick);
        }

        private void RecentImagesClick(object sender, EventArgs e)
        {
            if (drawLines.Any() || redoLines.Any())
            {
                ShowUnsavedChangedWarning(sender, e);
            }

            var images = (ToolStripMenuItem)sender;
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            fileName = projectPath + "/" + images.Text;

            Image img;
            using (var bmpTemp = new Bitmap(fileName))
            {
                img = new Bitmap(bmpTemp);
            }

            DrawPanel.BackgroundImage = img;
            drawLines.Clear();
            Undo.Enabled = false;
            redoLines.Clear();
            Redo.Enabled = false;
            DrawPanel.Invalidate();
        }
    }
}
