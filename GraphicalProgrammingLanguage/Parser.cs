using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using GraphicalProgrammingLanguage;

namespace GraphicalProgrammingLanguage
{
    class Parser : Form1
    {
        
        Bitmap g;
        Canvas can;

        public Parser(Bitmap bIn)
        {
            this.g = bIn;
            can = new Canvas(Graphics.FromImage(bIn));
        }

        public void commandParser(string x)
        {
            x = x.ToLower().Trim();
           
            String[] commands = x.Split(" ");

            int[] parNums;

            if (commands.Length > 1)
            {   
                can = new Canvas(Graphics.FromImage(g));
                
                String command = commands[0];

                String[] pars = commands[1].Split(",");

                parNums = new int[pars.Length];
                for (int i = 0; i < pars.Length; i++)
                {
                    parNums[i] = Int32.Parse(pars[i]);
                }
                
                if (command.Equals("drawto")) 
                {
                    can.DrawLine(parNums[0], parNums[1]);
                }
                
            }
        }

        public void parseProgram(string input)
        {
            String[] lines = input.Split("\n");
            foreach (String line in lines)
            {
                commandParser(line);
            }
        }
    }
}


