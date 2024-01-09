using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// This class is for all drawing to be done on to be later displayed.
    /// </summary>
    public class Canvas
    {        
        Pen p;
        Brush b;
        Color penColour;
        Form FormRefresh;
        Graphics g, point;
        int xcanvas, ycanvas;
        private int xpos, ypos;
        Boolean testing = false;
        const int CANX = 241, CANY = 186;

        /// <summary>
        /// Constructor for setting up the graphics for but the regular drawing graphics and graphics to point at the pen's position.
        /// </summary>
        /// <param name="FormRefresh">Takes in the form context.</param>
        /// <param name="gIn">The graphics context that most things are drawn with.</param>
        /// <param name="pointIn">The graphics context that's being used to point at where the pen is.</param>
        public Canvas(Form FormRefresh, Graphics gIn, Graphics pointIn)
        {
            this.g = gIn;
            this.point = pointIn;
            xpos = ypos = 0;
            xcanvas = CANX;
            ycanvas = CANY;
            p = new Pen(Color.Black, 1);
            b = Brushes.Black;
            this.FormRefresh = FormRefresh;
        }

        /// <summary>
        /// Constuctor for unit testing to avoid drawing anything.
        /// </summary>
        public Canvas()
        {
            xcanvas = CANX;
            ycanvas = CANY;
            testing = true;
        }

        /// <summary>
        /// Set the position of the pen and therefore the point where it will draw from.
        /// </summary>
        /// <param name="toX">This is represents the X axis of where the pen is.</param>
        /// <param name="toY">This is represents the X axis of where the pen is.</param>
        /// <exception cref="ArgumentOutOfRangeException">This is thrown if one of the axes is outside of given range.</exception>
        public void MoveTo(int toX, int toY)
        {
            if (toX < 0 || toX > xcanvas || toY < 0 || toY > ycanvas)
            {
                throw new IndexOutOfRangeException("X or Y position is outside of range of display");
            }
            xpos = toX;
            ypos = toY;
            if (testing == false)
            {
                pointer();
            }
        }

        /// <summary>
        /// Allows for a line to be drawn from current position.
        /// </summary>
        /// <param name="toX">This is represents the X axis of where the line is going end at.</param>
        /// <param name="toY">This is represents the Y axis of where the line is going end at.</param>
        public void DrawLine(int toX, int toY)
        {
            if (toX < 0 || toX > xcanvas || toY < 0 || toY > ycanvas)
            {
                throw new IndexOutOfRangeException("X or Y position is outside of range of display");
            }
            if (g != null)
            {
                g.DrawLine(p, xpos, ypos, toX, toY);
            }
            xpos = toX;
            ypos = toY;
            if (testing == false)
            {
                pointer();
            }
        }

        /// <summary>
        /// Draws a rectangle based on the width and length pased to it.
        /// </summary>
        /// <param name="width">provides the width of rectangle.</param>
        /// <param name="length">provides the length of rectangle.</param>
        public void DrawRectangle(int width, int length)
        {
            if (width < 0 || width > xcanvas || length < 0 || length > ycanvas)
            {
                throw new IndexOutOfRangeException("width or length position is outside of range of display");
            }
            if (g != null)
            {
                g.DrawRectangle(p, xpos, ypos, xpos + width, ypos + length);
            }
            if (testing == false)
            {
                pointer();
            }
        }

        /// <summary>
        /// Draws a rectangle but not as an outline.
        /// </summary>
        /// <param name="length">provides the length of rectangle.</param>
        /// <param name="width">provides the width of rectangle.</param>
        public void DrawRectangleFill(int width, int length)
        {
            if (width < 0 || width > xcanvas || length < 0 || length > ycanvas)
            {
                throw new IndexOutOfRangeException("width or length position is outside of range of display");
            }
            if (g != null)
            {
                g.FillRectangle(b, xpos, ypos, xpos + width, ypos + length);
            }
            if (testing == false)
            {
                pointer();
            }
        }

        /// <summary>
        /// Draws a circle based on the radius passed to it.
        /// </summary>
        /// <param name="radius">provides the radius of the circle.</param>
        public void DrawCircle(int radius)
        {
            if (radius < 0 || radius > xcanvas || radius < 0 || radius > ycanvas)
            {
                throw new IndexOutOfRangeException("radius position is outside of range");
            }
            if (g != null)
            {
                g.DrawEllipse(p, xpos, ypos, radius, radius);
            }
            if (testing == false)
            {
                pointer();
            }
        }

        /// <summary>
        /// Draws a circle but not as an outline.
        /// </summary>
        /// <param name="radius">provides the radius of the circle.</param>
        public void DrawCircleFill(int radius)
        {
            if (radius < 0 || radius > xcanvas || radius < 0 || radius > ycanvas)
            {
                throw new IndexOutOfRangeException("radius position is outside of range");
            }
            if (g != null)
            {
                g.FillEllipse(b, xpos, ypos, radius, radius);
            }
            if (testing == false)
            {
                pointer();
            }
        }
        /// <summary>
        /// Draws a triangle starting at pen's current position by drawing lines that are the same length to from a full triangle.
        /// </summary>
        /// <param name="side">This is the length of the sides that make the triangle.</param>
        public void DrawTriangle(int side)
        {
            if (side < 0 || side > xcanvas || side < 0 || side > ycanvas)
            {
                throw new IndexOutOfRangeException("sides of triangle are outside of range");
            }
            int x = xpos;
            int y = ypos;
            DrawLine(xpos + side, ypos);
            DrawLine(xpos, ypos + side);
            DrawLine(x, y);
            if (testing == false)
            {
                pointer();
            }
        }

        /// <summary>
        /// Clears the display and makes it white.
        /// </summary>
        public void Clear()
        {
            if (g != null) 
            {
                g.Clear(Color.White);
            }            
        }

        /// <summary>
        /// Resets the pen to its initial position.
        /// </summary>
        public void Reset()
        {            
            ypos = 0;
            xpos = 0;
            if (testing == false)
            {
                pointer();
            }
        }

        /// <summary>
        /// This allows the user to change the colour of the pen from either red, green, or blue.
        /// </summary>
        /// <param name="pen">This is the colour of the pen.</param>
        public void Pen(string pen)
        {
            if (pen.Equals("red"))
            {
                penColour = Color.Red;
            }
            else if (pen.Equals("green"))
            {
                penColour = Color.Green;
            }
            else if (pen.Equals("blue"))
            {
                penColour = Color.Blue;
            }
            p = new Pen(penColour);
        }

        /// <summary>
        /// This is method that places a small square to indicate where on the display the pen is currently. 
        /// </summary>
        public void pointer() 
        {
            if (testing == true)
            {
                return;
            }
            point.Clear(Color.Transparent);
            Pen pointPen = new Pen(Color.Red, 1);
            point.DrawRectangle(pointPen, xpos - 2, ypos - 2, 4, 4);
            FormRefresh.Refresh();
        }

        /// <summary>
        /// Property for getting the value of the Y position of the pen.
        /// </summary>
        public int Xpos
        { get { return xpos; } }

        /// <summary>
        /// Property for getting the value of the Y position of the pen.
        /// </summary>
        public int Ypos
        { get { return ypos; } }

        /// <summary>
        /// Property for getting the colour of the  pen.
        /// </summary>
        public Color PenColour 
        { get { return penColour; }}
    }
}
