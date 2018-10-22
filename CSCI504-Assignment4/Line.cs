using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSCI504_Assignment4
{
    public class Line
    {
        public Pen Pen { get; set; }

        public Tuple<Point, Point> Points { get; set; }

        public Line(Pen pen, Tuple<Point, Point> points)
        {
            Pen = pen;
            Points = points;
        }
    }
}
