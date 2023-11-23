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
        int xpos, ypos;
        public Canvas(Graphics gIn) 
        {
            this.g = gIn;
            xpos = ypos = 0;
            p = new Pen(Color.Black, 1);
            
        }

        public void DrawLine(int toX, int toY) 
        {
            g.DrawLine(p, xpos, ypos, toX, toY);
            xpos = toX;
            ypos = toY;
        }

        public void DrawSquare(int width) 
        {
            g.DrawRectangle(p, xpos, ypos, xpos + width, ypos + width);
        }

        public void DrawCircle(int radius) 
        {
            g.DrawEllipse(p, xpos, ypos, xpos +(radius*2), ypos + (radius * 2));
        }

    }
}
