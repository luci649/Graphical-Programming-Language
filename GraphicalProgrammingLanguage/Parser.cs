using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        Boolean loopflag = false;
        Boolean runCommand = true;
        Boolean methodFlag = false;
        Boolean methodExecute = false;
        String dex2S, dex1S;
        int variableCount,  loopCounter, loopSize, iterations,dex1, dex2, methodCounter, saveProgramCounter;
        int programCounter;
        ArrayList variables = new ArrayList();
        ArrayList variableValues = new ArrayList();
        ArrayList methodNames = new ArrayList();
        ArrayList methodPoint = new ArrayList();

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
                if (runCommand == false || methodFlag == true)
                {
                    return;
                }
                if (loopflag == true)
                {
                    loopSize++;
                }
                String command = commands[0];
                               
                String[] pars = commands[1].Split(",");

                if (pars.Length > 2)
                {
                    throw new System.ArgumentOutOfRangeException("to many parameters entered");
                }

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
                    else if (command.Equals("loop"))
                    {
                        iterations = parNums[0];
                        loopflag = true;                        
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
                        if (variableSearch(pars[0]) >= 0)
                        {
                            throw new ArgumentOutOfRangeException("variable already declared");
                        }
                        else
                        {
                            variables.Add(pars[0]);
                            variableValues.Add(0);
                            variableCount++;
                        }
                    }
                    else if (pars[0].Equals("="))
                    {
                        if (commands.Contains("+") || commands.Contains("-") || commands.Contains("%") || commands.Contains("/") || commands.Contains("*"))
                        {
                            int resultInt = variableSearch(commands[0]);
                            int conInt1 = variableSearch(commands[2]);
                            string conStr1 = (string)variableValues[conInt1];
                            string resultStr = (string)variableValues[resultInt];
                            string expression = conStr1 + commands[3] + commands[4];
                            var dt = new DataTable();
                            try 
                            {
                                variableValues[resultInt] = dt.Compute(expression, "");
                                int j = (int)variableValues[resultInt];
                                variableValues[resultInt] = j.ToString();
                                return;
                            }
                            catch(System.Data.EvaluateException) 
                            {
                                throw new ApplicationException("invalid expression");
                            }
                        }
                        int dex = variableSearch(command);
                        if (dex >= 0)
                        {
                            variables[dex] = command;
                            variableValues[dex] = commands[2];
                        }
                        else
                        { 
                            throw new ArgumentNullException("variable not declared"); 
                        }
                    }
                    else if (command.Equals("if"))
                    {
                        int conInt1 = variableSearch(commands[1]);
                        int conInt2 = variableSearch(commands[3]);
                        string conStr1 = (string)variableValues[conInt1];
                        string conStr2 = (string)variableValues[conInt2];
                        string condition = conStr1 + commands[2] + conStr2;
                        var dt = new DataTable();
                        try 
                        {
                            var conF = dt.Compute(condition, "");
                            if (conF.Equals(false))
                            {
                                runCommand = false;                               
                            }
                        }
                        catch(System.Data.EvaluateException) 
                        {
                            throw new ApplicationException("invalid expression");
                        }                      
                    }                   
                    else if (command.Equals("loop"))
                    {
                        dex1 = variableSearch(pars[0]);
                        if (dex1 >= 0)
                        {
                            dex1S = (string)variableValues[dex1];                            
                            iterations = int.Parse(dex1S);
                            loopflag = true;  
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("invalid parameter");
                        }
                    }
                    else if (command.Equals("moveto"))
                    {
                        dex1 = variableSearch(pars[0]);
                        dex2 = variableSearch(pars[1]);
                        if (dex1 >= 0 || dex2 >= 0)
                        {
                            dex1S = (string)variableValues[dex1];
                            dex2S = (string)variableValues[dex2];
                            can.MoveTo(int.Parse(dex1S),int.Parse(dex2S));
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("invalid parameter");
                        }
                    }
                    else if (command.Equals("drawto"))
                    {
                        dex1 = variableSearch(pars[0]);
                        dex2 = variableSearch(pars[1]);
                        if (dex1 >= 0 || dex2 >= 0)
                        {
                            dex1S = (string)variableValues[dex1];
                            dex2S = (string)variableValues[dex2];
                            can.DrawLine(int.Parse(dex1S), int.Parse(dex2S));
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("invalid parameter");
                        }
                    }
                    else if (command.Equals("circle"))
                    {
                        dex1 = variableSearch(pars[0]);
                        if (dex1 >= 0)
                        {                            
                            dex1S = (string)variableValues[dex1];
                            can.DrawCircle(int.Parse(dex1S));                           
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("invalid parameter");
                        }
                    }
                    else if (command.Equals("rectangle"))
                    {
                        dex1 = variableSearch(pars[0]);
                        dex2 = variableSearch(pars[1]);
                        if (dex1 >= 0 || dex2 >= 0)
                        {
                            dex1S = (string)variableValues[dex1];
                            dex2S = (string)variableValues[dex2];
                            can.DrawRectangle(int.Parse(dex1S), int.Parse(dex2S));
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("invalid parameter");
                        }
                    }
                    else if (command.Equals("method"))
                    {
                        if (methodSearch(pars[0]) >= 0)
                        {
                            throw new ArgumentOutOfRangeException("method already declared");
                        }
                        else
                        {
                            methodNames.Add(pars[0]);
                            methodPoint.Add(programCounter);
                            methodCounter++;
                            methodFlag = true;
                        }
                    }
                    else if (command.Equals("call"))
                    {
                        dex1 = methodSearch(pars[0]);
                        if (dex1 >= 0)
                        {
                            saveProgramCounter = programCounter + 1;
                            programCounter = (int)methodPoint[dex1];
                            methodExecute = true;
                        }
                        else
                        {
                            throw new ApplicationException("invalid method");
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
                if (runCommand == false)
                {
                    return;
                }
                can.Clear();
            }
            else if (commands[0].Equals("reset"))
            {
                if (runCommand == false)
                {
                    return;
                }
                can.Reset();
            }
            else if (commands[0].Equals("endmethod"))
            {
                if (methodExecute == false)
                {
                    methodFlag = false;
                }
                else
                {
                    methodExecute = false;
                    programCounter = saveProgramCounter;
                }
            }
            else if (commands[0].Equals("endif"))
            {
                if (runCommand != false)
                {
                    return;
                }

                runCommand = true;
            }
            else if (commands[0].Equals("endloop"))
            {
                loopflag = false;
                if (loopCounter < iterations - 1)
                {
                    loopCounter++;
                    programCounter -= loopSize + 1;
                }
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
           
            while (programCounter < lines.Length)
            {
                CommandParser(lines[programCounter]);
                programCounter++;
            }
        }

        /// <summary>
        /// Property for testing if is currently on or not.
        /// </summary>
        public Boolean Fill 
        {
            get {  return fill; }
        }
        
        /// <summary>
        /// This method is used to search the list of variables to determine if it is in the list of variables.
        /// </summary>
        /// <param name="var">variable that is being searched for.</param>
        /// <returns>Either the index of the passed variable or -1 if not found.</returns>
        public int variableSearch(String var) 
        {
            for (int i = 0; i < variableCount; i++) 
            {
                if (variables[i].Equals(var))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// This method is used to search the list of methods to determine if it is in the list of methods.
        /// </summary>
        /// <param name="meth">method that is being searched for.</param>
        /// <returns>Either the index of the passed method or -1 if not found.</returns>
        public int methodSearch(String meth)
        {
            for (int i = 0; i < methodCounter; i++)
            {
                if (methodNames[i].Equals(meth))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Property for setting the programcounter variable.
        /// </summary>
        public int ProgramCounter 
        {
            set{ programCounter = value; }
        }

        /// <summary>
        ///  Property for setting the loopcounter variable.
        /// </summary>
        public int LoopCounter
        { set { loopCounter = value; } }

        /// <summary>
        ///  Property for setting the loopsize variable.
        /// </summary>
        public int LoopSize
        { set { loopSize = value; } }
    }
}







