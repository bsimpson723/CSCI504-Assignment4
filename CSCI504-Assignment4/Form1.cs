/*
 * CSCI 504: Programming principles in .NET
 * Assignment 4
 * Benjamin Simpson - Z100820
 * Xueqiong Li - z1785226
*/

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
        private List<Tuple<Point, Point>> points;
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
            points = new List<Tuple<Point, Point>>();
            RecentImages();
        }

        // displays tool tip
        private void DisplayTooltip(object sender, EventArgs e)
        {
            var panel = (Panel) sender;
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.IsBalloon = false;
            tt.Show(string.Empty, panel);
            tt.Show(panel.Name, panel, 0);
        }

        // hide tool tip 
        private void HideTooltip(object sender, EventArgs e)
        {
            tt.Dispose();
        }

        // record the start location and set timer and redo stack when mouse clicked down
        private void MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                points.Clear();
                start = e.Location;
                redoLines.Clear();      //once you draw a new line
                Redo.Enabled = false;   //"Redo" is no longer possible
                if (tool != Tool.Line)
                {
                    timer.Tick += GetPoints;
                    timer.Interval = 10;
                    timer.Start();
                }
            }
        }

        // add line to drawLines container if Line is selected, set start & finish point emply, and call OnPaint
        private void MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
            finish = e.Location;
            if (!start.IsEmpty && !finish.IsEmpty)
                if (tool == Tool.Line)
                {
                    var points = new List<Tuple<Point, Point>>();
                    points.Add(new Tuple<Point, Point>(start, finish));
                    drawLines.Push(new Line(new Pen(pen.Color, pen.Width), new List<Tuple<Point, Point>>(points)));
                }
                else
                {
                    drawLines.Push(new Line(new Pen(pen.Color, pen.Width), new List<Tuple<Point, Point>>(points)));
                }
            start = Point.Empty;
            finish = Point.Empty;
            Undo.Enabled = true;    //as soon as a line exists we want to be able to undo it.
            DrawPanel.Invalidate();
        }
        
        // add lines to drawLines when mouse is moving with time interval of 10
        private void GetPoints(object sender, EventArgs e)
        {
            finish = DrawPanel.PointToClient(Cursor.Position);
            points.Add(new Tuple<Point, Point>(start, finish));
            start = finish;
        }

        // draw lines saved in drawLines
        private void OnPaint(object sender, PaintEventArgs e)
        {
            foreach (var line in drawLines.Reverse()) //This prints the stack in reverse order so that the most recent line is on top.
            {
                foreach (var tuple in line.Points)
                {
                    e.Graphics.DrawLine(line.Pen, tuple.Item1, tuple.Item2);
                }
            } 
            if (!start.IsEmpty && !finish.IsEmpty)
                e.Graphics.DrawLine(pen, start, finish);
            timer.Stop();
        }

        // set the color when clicking color panels
        private void ColorClick(object sender, EventArgs e)
        {
            var panel = (Panel) sender;
            pen.Color = panel.BackColor;
            SelectedColor.BackColor = panel.BackColor;
        }

        // change the width of pen
        private void WidthChange(object sender, EventArgs e)
        {
            pen.Width = (float)WidthUpDown.Value;
        }

        // save the image and update Recent image tool strip menu item
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

                if (File.Exists(fileName))  // if file name exists, delete the file
                {
                    File.Delete(fileName);
                }

                bm.Save(fileName, ImageFormat.Png);
                MessageBox.Show("Your file has been saved!");
                
                UpdateRecent(saveFile.FileName);
            }
        }

        // show saveFile dialog when save as selected
        private void SaveAs(object sender, EventArgs e)
        {
            saveFile.ShowDialog();
        }

        // save file and update recent image after saveFile dialog
        private void SaveAsFileOk(object sender, CancelEventArgs e)
        {
            var width = DrawPanel.Width;
            var height = DrawPanel.Height;
            Bitmap bm = new Bitmap(width, height);
            DrawPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            bm.Save(saveFile.FileName, ImageFormat.Png);
            MessageBox.Show("Your file has been saved!");
            fileName = saveFile.FileName;

            UpdateRecent(saveFile.FileName);
        }

        // remove the last painted line when undo clicked
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

        // add the last removed line when redo clicked
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

        // set color and width range when tools selected
        private void ToolSelected(object sender, EventArgs e)
        {
            var panel = (Panel) sender;
            if (panel.Name.ToUpper() == "LINE")
            {
                Pencil.BackColor = Color.White;
                Brush.BackColor = Color.White;
                Eraser.BackColor = Color.White;
                Line.BackColor = SystemColors.GradientActiveCaption;
                WidthUpDown.Minimum = 1;
                WidthUpDown.Maximum = 5;
                pen.Color = SelectedColor.BackColor;
                tool = Tool.Line;
                WidthUpDown.Value = 1;
            }
            else if (panel.Name.ToUpper() == "PENCIL")
            {
                Pencil.BackColor = SystemColors.GradientActiveCaption;
                Brush.BackColor = Color.White;
                Eraser.BackColor = Color.White;
                Line.BackColor = Color.White;
                WidthUpDown.Minimum = 1;
                WidthUpDown.Maximum = 3;
                pen.Color = SelectedColor.BackColor;
                tool = Tool.Pencil;
                WidthUpDown.Value = 1;
            }
            else if (panel.Name.ToUpper() == "BRUSH")
            {
                Pencil.BackColor = Color.White;
                Brush.BackColor = SystemColors.GradientActiveCaption;
                Eraser.BackColor = Color.White;
                Line.BackColor = Color.White;
                WidthUpDown.Minimum = 5;
                WidthUpDown.Maximum = 8;
                pen.Color = SelectedColor.BackColor;
                tool = Tool.Brush;
                WidthUpDown.Value = 5;
            }
            else if (panel.Name.ToUpper() == "ERASER")
            {
                Pencil.BackColor = Color.White;
                Brush.BackColor = Color.White;
                Eraser.BackColor = SystemColors.GradientActiveCaption;
                Line.BackColor = Color.White;
                WidthUpDown.Minimum = 1;
                WidthUpDown.Maximum = 10;
                pen.Color = DrawPanel.BackColor;
                tool = Tool.Eraser;
                WidthUpDown.Value = 1;
            }
        }

        // show openFile dialog if open clicked
        private void OpenFileClick(object sender, EventArgs e)
        {
            DialogResult response = DialogResult.Cancel;
            if (drawLines.Any() || redoLines.Any())
            {
                ShowUnsavedChangesWarning(sender, e);
            }

            openFile.ShowDialog();
        }

        // open file after openFile dialog
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

        // call ShowUnsavedChangesWarning and reset everything
        private void NewImageClick(object sender, EventArgs e)
        {
            if (drawLines.Any() || redoLines.Any())
            {
                ShowUnsavedChangesWarning(sender, e);
            }

            drawLines.Clear();
            Undo.Enabled = false;
            redoLines.Clear();
            Redo.Enabled = false;
            fileName = string.Empty;
            DrawPanel.BackgroundImage = null;
            DrawPanel.Invalidate();
        }

        // ask if user want to save current image or not
        private void ShowUnsavedChangesWarning(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Would you like to save your changes first?", "Unsaved Changes!", MessageBoxButtons.YesNo);
            if (response == DialogResult.Yes)
            {
                Save(sender, e);
            }
        }
   
        // show customColorDialog for custom color selector
        private void Custom_Click(object sender, EventArgs e)
        {
            if (customColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                pen.Color = customColorDialog.Color;
                SelectedColor.BackColor = customColorDialog.Color;
            }
        }
        
        // sets short cut for redo and undo
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z && drawLines.Any())
            {
                UndoClick(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.X && redoLines.Any())
            {
                RedoClick(sender, e);
            }
        }
        
        // read RecentImages.txt file and add ToolStripMenuItem based on it
        private void RecentImages()
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string[] lines = File.ReadAllLines(projectPath + "\\RecentImages.txt");
            if (!lines.Any())
            {
                recentlyOpenedToolStripMenuItem.DropDownItems.Add("No recent images");
            }
            else
            {
                foreach (var image in lines)
                {
                    recentlyOpenedToolStripMenuItem.DropDownItems.Add(image);
                }
                foreach (ToolStripMenuItem images in recentlyOpenedToolStripMenuItem.DropDownItems)
                {
                    images.Click += RecentImagesClick;
                }
            }
        }

        // open image when any of recent image clicked
        private void RecentImagesClick(object sender, EventArgs e)
        {
            if (drawLines.Any() || redoLines.Any())
            {
                ShowUnsavedChangesWarning(sender, e);
            }

            var image = (ToolStripMenuItem)sender;

            Image img;
            using (var bmpTemp = new Bitmap(image.Text))
            {
                img = new Bitmap(bmpTemp);
            }

            DrawPanel.BackgroundImage = img;
            drawLines.Clear();
            Undo.Enabled = false;
            redoLines.Clear();
            Redo.Enabled = false;
            DrawPanel.Invalidate();
            UpdateRecent(fileName);
        }

        // update recent image after open any image
        private void UpdateRecent(string fileName)
        {
            List<String> images = new List<String>();
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string[] lines = File.ReadAllLines(projectPath + "\\RecentImages.txt");
            foreach (var image in lines)
                        images.Add(image);

            if (images.Count < 5)
                File.AppendAllText(projectPath + "\\RecentImages.txt", "\n" + fileName);
            else
            {
                File.WriteAllText(projectPath + "\\RecentImages.txt", String.Empty);
                for (int i = 1; i < 5; i++)
                    File.AppendAllText(projectPath + "\\RecentImages.txt", images[i] + "\n");
                File.AppendAllText(projectPath + "\\RecentImages.txt", fileName);
            }

            recentlyOpenedToolStripMenuItem.DropDownItems.Clear();
            RecentImages();
        }
    }
}
