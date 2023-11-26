﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
        Boolean d;
        Boolean fill = false;
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
                String command = commands[0];

                String[] pars = commands[1].Split(",");

                parNums = new int[pars.Length];

                for (int i = 0; i < pars.Length; i++)
                {
                    d = int.TryParse(pars[i], out parNums[i]);
                }

                if (d == true)
                {
                    if (command.Equals("drawto"))
                    {
                        try
                        {
                            can.DrawLine(parNums[0], parNums[1]);
                        }
                        catch (IndexOutOfRangeException) 
                        {
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing input");
                            throw arg;
                        }                        
                    }
                    else if (command.Equals("moveto"))
                    {
                        try
                        {
                            can.MoveTo(parNums[0], parNums[1]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing input");
                            throw arg;
                        }                        
                    }
                    else if (command.Equals("rectangle"))
                    {
                        try
                        {
                            if (fill == false)
                            {
                                can.DrawRectangle(parNums[0], parNums[1]);
                            }
                            else
                            {
                                can.DrawRectangleFill(parNums[0], parNums[1]);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing input");
                            throw arg;
                        }
                        
                    }
                    else if (command.Equals("circle"))
                    {                        
                        try
                        {
                            if (fill == false)
                            {
                                can.DrawCircle(parNums[0]);
                            }
                            else
                            {
                                can.DrawCircleFill(parNums[0]);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing input");
                            throw arg;
                        }
                    }
                    else if (command.Equals("triangle"))
                    {                       
                        try
                        {
                            can.DrawTriangle(parNums[0]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing input");
                            throw arg;
                        }
                    }
                }
                else if (d == false)
                {
                    if (command.Equals("fill"))
                    {
                        if (commands[1].Equals("on"))
                        {
                            fill = true;
                        }
                        else
                        {
                            fill = false;
                        }
                    }
                    else if (command.Equals("pen"))
                    {
                        if (commands[1].Equals("red"))
                        {
                            can.Pen("red");
                        }
                        else if (commands[1].Equals("green"))
                        {
                            can.Pen("green");
                        }
                        else if (commands[1].Equals("blue"))
                        {
                            can.Pen("blue");
                        }
                    }
                    else
                    {
                        throw new System.ArgumentOutOfRangeException("invalid parameter");
                    }
                }
            }
            else if (commands[0].Equals("clear"))
            {
                can.Clear();
            }
            else if (commands[0].Equals("reset"))
            {
                can.Reset();
            }
            else
            {
                throw new System.ArgumentNullException("invalid command");
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







