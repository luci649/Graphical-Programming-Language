using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    class Canvas
    {
        Graphics g;
        Pen p;
        Brush b;
        int xpos, ypos;
        public Canvas(Graphics gIn)
        {
            this.g = gIn;
            xpos = ypos = 0;
            p = new Pen(Color.Black, 1);
            b = Brushes.Black;
        }
        /// <summary>
        /// Set the position of the pen and therefore the point where it will draw from.
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        /// <exception cref="ArgumentOutOfRangeException">This is thrown if one of the axes is outside of given range.</exception>
        public void MoveTo(int toX, int toY)
        {
            xpos = toX;
            ypos = toY;
        }
        /// <summary>
        /// Allows for a line to be drawn from current position.
        /// </summary>
        /// <param name="toX">This is represents the X axis of where the line is going end at.</param>
        /// <param name="toY">This is represents the Y axis of where the line is going end at.</param>
        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(p, xpos, ypos, toX, toY);
            xpos = toX;
            ypos = toY;
        }
        /// <summary>
        /// Draws a rectangle based on the width and length pased to it.
        /// </summary>
        /// <param name="width">provides the width of rectangle.</param>
        /// <param name="length">provides the length of rectangle.</param>
        public void DrawRectangle(int width, int length)
        {
            g.DrawRectangle(p, xpos, ypos, xpos + width, ypos + length);
        }
        /// <summary>
        /// Draws a rectangle but not as an outline.
        /// </summary>
        /// <param name="length">provides the length of rectangle.</param>
        /// <param name="width">provides the width of rectangle.</param>
        public void DrawRectangleFill(int width, int length)
        {
            g.FillRectangle(b, xpos, ypos, xpos + width, ypos + length);
        }
        /// <summary>
        /// Draws a circle based on the radius passed to it.
        /// </summary>
        /// <param name="radius">provides the radius of the circle.</param>
        public void DrawCircle(int radius)
        {
            g.DrawEllipse(p, xpos, ypos, radius, radius);
        }
        /// <summary>
        /// Draws a circle but not as an outline.
        /// </summary>
        /// <param name="radius">provides the radius of the circle.</param>
        public void DrawCircleFill(int radius)
        {
            g.FillEllipse(b, xpos, ypos, radius, radius);
        }
        /// <summary>
        /// Draws a triangle starting at pen's current position by drawing lines that are the same length to from a full triangle.
        /// </summary>
        /// <param name="side">This is the length of the sides that make the triangle.</param>
        public void DrawTriangle(int side)
        {
            int x = xpos;
            int y = ypos;
            DrawLine(xpos + side, ypos);
            DrawLine(xpos, ypos + side);
            DrawLine(x, y);
        }
        /// <summary>
        /// Clears the display and makes it white.
        /// </summary>
        public void Clear()
        {
            g.Clear(Color.White);
        }
        /// <summary>
        /// Resets the pen to its initial position.
        /// </summary>
        public void Reset()
        {
            ypos = 0;
            xpos = 0;
        }
        /// <summary>
        /// This allows the user to change the colour of the pen from either red, green, or blue.
        /// </summary>
        /// <param name="pen">This is the colour of the pen.</param>
        public void Pen(string pen)
        {
            if (pen.Equals("red"))
            {
                p.Color = Color.Red;
            }
            else if (pen.Equals("green"))
            {
                p.Color = Color.Green;
            }
            else if (pen.Equals("blue"))
            {
                p.Color = Color.Blue;
            }
        }
    }
}
