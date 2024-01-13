using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using GraphicalProgrammingLanguage;

namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// This class is for sorting through user input to call the right commands.
    /// </summary>
    public class Parser
    {
        Canvas can;
        Boolean d;
        Boolean fill = false;
        int varibleCount = 0;
        ArrayList varibles = new ArrayList();
        ArrayList varibleValues = new ArrayList();

        /// <summary>
        /// Takes the canvas context to make the right drawing calls.
        /// </summary>
        /// <param name="bIn">The canvas context.</param>
        public Parser(Canvas bIn)
        {
            this.can = bIn;
        }

        /// <summary>
        /// Takes in commands entered in by users and determines if it contains valid commands or/and parameters to then execute the right
        /// method to draw on the display.
        /// </summary>
        /// <param name="x">commands and/or parameters entered by user.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">This exception is thrown if the wrong command is enter.</exception>
        /// <exception cref="System.ArgumentNullException">This exception is thrown if the wrong parameter is enter.</exception>
        public void CommandParser(string x)
        {
            x = x.ToLower().Trim();

            String[] commands = x.Split(" ");

            int[] parNums;

            if (commands.Length > 1)
            {
                String command = commands[0];

                String[] pars = commands[1].Split(",");
                //if (pars.Length > 2)
                //{
                //    throw new System.ArgumentOutOfRangeException("to many parameters entered");
                //}

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
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing parameter or X or Y position is outside of range of display");
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
                            System.InvalidOperationException arg = new InvalidOperationException("missing parameter or X or Y position is outside of range of display");
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
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing parameter or X or Y position is outside of range of display");
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
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing parameter or X or Y position is outside of range of display");
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
                            System.InvalidOperationException arg = new System.InvalidOperationException("missing parameter or X or Y position is outside of range of display");
                            throw arg;
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("Invalid command entered");
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
                    else if (command.Equals("var"))
                    {
                        if (varibleSearch(pars[0]) >= 0)
                        {
                            throw new ArgumentOutOfRangeException("varible all ready declared");
                        }
                        else
                        {
                            varibles.Add(pars[0]);
                            varibleValues.Add(0);
                            varibleCount++;
                        }
                    }             
                    else
                    {
                        throw new ArgumentOutOfRangeException("invalid parameter");
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
                throw new ArgumentNullException("Invalid command entered");
            }
        }
        /// <summary>
        /// Parses through multiple lines of commands passed through the rich text box by splitting them at their new lines and then have 
        /// each line's individual corresponding method executed one at a time.
        /// </summary>
        /// <param name="input">A string of different commands.</param>
        public void ParseProgram(string input)
        {
            String[] lines = input.Split("\n");
            foreach (String line in lines)
            {
                CommandParser(line);
            }
        }

        /// <summary>
        /// Property for testing if is currently on or not.
        /// </summary>
        public Boolean Fill 
        {
            get {  return fill; }
        }
        
        public int varibleSearch(String var) 
        {
            for (int i = 0; i < varibleCount; i++) 
            {
                if (varibles[i] == var)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}







