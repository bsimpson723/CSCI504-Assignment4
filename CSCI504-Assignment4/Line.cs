/*
 * CSCI 504: Programming principles in .NET
 * Assignment 4
 * Benjamin Simpson - Z100820
 * Xueqiong Li - z1785226
*/

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

        public List<Tuple<Point, Point>> Points { get; set; }

        public Line(Pen pen, List<Tuple<Point, Point>> points)

        {
            Pen = pen;
            Points = points;
        }
    }
}
