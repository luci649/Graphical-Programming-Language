using System.Windows.Forms.VisualStyles;
using System.IO;
using static GraphicalProgrammingLanguage.Threads;


namespace GraphicalProgrammingLanguage
{
    /// <summary>
    /// Class that represents the form that is going to be used to display the GUI for the user to interact with.
    /// </summary>
    public partial class Form1 : Form
    {
        const int screenXsize = 241, screenYsize = 186;

        Canvas can;
        Graphics g;
        Parser pars;
        Bitmap PointerBitmap = new Bitmap(screenXsize, screenYsize);
        Bitmap OutDisplayBitmap = new Bitmap(screenXsize, screenYsize);
        static SharedResources resources = new SharedResources();

        /// <summary>
        /// Sets up form and bitmaps to draw on to then be displayed on form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(OutDisplayBitmap);
            can = new Canvas(this, Graphics.FromImage(OutDisplayBitmap), Graphics.FromImage(PointerBitmap));
            pars = new Parser(can);
        }

        private void RunButton_keyDown(object sender, EventArgs e)
        {

            if (SingleCommand.Text != "")
            {
                try
                {
                    pars.CommandParser(SingleCommand.Text);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MultiCommand.Text = "to many parameters entered";
                }
                catch (ArgumentNullException)
                {
                    MultiCommand.Text = "Invalid command entered";
                }
                catch (InvalidOperationException)
                {
                    MultiCommand.Text = "missing parameter or X or Y position is outside of range of display";
                }
            }
            else if (MultiCommand.Text != "" && MultiCommand2.Text != "")
            {
                Run();
            }
            else if (MultiCommand.Text != "")
            {
                try
                {
                    pars.ParseProgram(MultiCommand.Text);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MultiCommand.Text = "to many parameters entered";
                }
                catch (ArgumentNullException)
                {
                    MultiCommand.Text = "Invalid command entered";
                }
                catch (InvalidOperationException)
                {
                    MultiCommand.Text = "missing parameter or X or Y position is outside of range of display";
                }
            }
            
            Refresh();
        }
        private void SingleCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (SingleCommand.Text.Equals("run"))
                {
                    if (MultiCommand.Text != "" && MultiCommand2.Text != "")
                    {
                        Run();
                    }
                    else
                    {
                           try
                        {
                            pars.ParseProgram(MultiCommand.Text);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            MultiCommand.Text = "to many parameters entered";
                        }
                        catch (ArgumentNullException)
                        {
                            MultiCommand.Text = "Invalid command entered";
                        }
                        catch (InvalidOperationException)
                        {
                            MultiCommand.Text = "missing parameter or X or Y position is outside of range of display";
                        } 
                    }                    
                }
                else if (SingleCommand.Text.Equals("save"))
                {
                    File.WriteAllText("program.txt", MultiCommand.Text);
                }
                else if (SingleCommand.Text.Equals("load"))
                {
                    MultiCommand.Text = File.ReadAllText("program.txt");
                }
                else
                {
                    try
                    {
                        pars.CommandParser(SingleCommand.Text);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MultiCommand.Text = "to many parameters entered";
                    }
                    catch (ArgumentNullException)
                    {
                        MultiCommand.Text = "Invalid command entered";
                    }
                    catch (InvalidOperationException)
                    {
                        MultiCommand.Text = "missing parameter or X or Y position is outside of range of display";
                    }
                }
                SingleCommand.Text = "";
                Refresh();
            }
        }
        private void OutputDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutDisplayBitmap, 0, 0);
            g.DrawImageUnscaled(PointerBitmap, 0, 0);
        }
        private void SyntxButton_Click(object sender, EventArgs e)
        {
            try
            {
                pars.ParseProgram(MultiCommand.Text);
            }
            catch (ArgumentOutOfRangeException)
            {
                MultiCommand.Text = "to many parameters entered";
            }
            catch (ArgumentNullException)
            {
                MultiCommand.Text = "Invalid command entered";
            }
            catch (InvalidOperationException)
            {
                MultiCommand.Text = "missing parameter or X or Y position is outside of range of display";
            }
        }        

        /// <summary>
        /// Runs the two programs along side eachother.
        /// </summary>
        /// <returns>The output of the two programs running.</returns>
         async Task Run()
        {
            Task program1 = Program1(MultiCommand.Text);
            Task program2 = Program2(MultiCommand2.Text);

            await Task.WhenAll(program1, program2);
        }

        /// <summary>
        /// Task that locks the resource of the parser to prevent interruption from task 2
        /// </summary>
        /// <param name="x">Takes in the strings that will be the program.</param>
        /// <returns>A task that will represent program passed by the user.</returns>
         async Task Program1(string x)
        {
            while (true)
            {
                if (!resources.IsDisplayLocked)
                {
                    resources.IsDisplayLocked = true;
                    pars.ParseProgram(x);
                    pars.ProgramCounter = 0;
                    pars.LoopCounter = 0;
                    pars.LoopSize = 0;
                    await Task.Delay(10000);                    
                    break;
                }
            }
        }

        /// <summary>
        /// Task that locks the resource of the parser to prevent interruption from task 1.
        /// </summary>
        /// <param name="x">Takes in the strings that will be the program.</param>
        /// <returns>A task that will represent program passed by the user.</returns>
        async Task Program2(string x)
        {
            while (true)
            {
                if (resources.IsDisplayLocked)
                {
                    resources.IsDisplayLocked = false;
                    pars.ParseProgram(x);
                    pars.ProgramCounter = 0;
                    pars.LoopCounter = 0;
                    pars.LoopSize = 0;
                    await Task.Delay(10000);                   
                    break;
                }
            }
        }
    }
}