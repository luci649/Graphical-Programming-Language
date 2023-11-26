using System.Windows.Forms.VisualStyles;
using System.IO;


namespace GraphicalProgrammingLanguage
{
    public partial class Form1 : Form
    {
        const int screenXsize = 241, screenYsize = 186;
        Bitmap OutDisplayBitmap = new Bitmap(screenXsize, screenYsize);
        Parser pars;
        Canvas can;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string x)
        {
            pars = new Parser(OutDisplayBitmap);
            pars.commandParser(x);
        }
        private void RunButton_keyDown(object sender, EventArgs e)
        {
            pars = new Parser(OutDisplayBitmap);
            if (SingleCommand.Text != "")
            {
                try
                {
                    pars.commandParser(SingleCommand.Text);
                }
                catch (InvalidOperationException)
                {
                    MultiCommand.Text = "invalid entry";
                }
                catch (ArgumentOutOfRangeException)
                {
                    MultiCommand.Text = "wrong parameter";
                }
                catch (ArgumentNullException)
                {
                    MultiCommand.Text = "wrong command";
                }
            }
            else if (MultiCommand.Text != "")
            {
                try
                {
                    pars.parseProgram(MultiCommand.Text);
                }
                catch (InvalidOperationException)
                {
                    MultiCommand.Text = "invalid entry";
                }
                catch (ArgumentOutOfRangeException)
                {
                    MultiCommand.Text = "wrong parameter";
                }
                catch (ArgumentNullException)
                {
                    MultiCommand.Text = "wrong command";
                }
            }
            Refresh();
        }
        private void SingleCommand_KeyDown(object sender, KeyEventArgs e)
        {
            pars = new Parser(OutDisplayBitmap);

            if (e.KeyCode == Keys.Enter)
            {
                if (SingleCommand.Text.Equals("run"))
                {
                    try
                    {
                        pars.parseProgram(MultiCommand.Text);
                    }
                    catch (InvalidOperationException)
                    {
                        MultiCommand.Text = "invalid entry";
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MultiCommand.Text = "wrong parameter";
                    }
                    catch (ArgumentNullException)
                    {
                        MultiCommand.Text = "wrong command";
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
                        pars.commandParser(SingleCommand.Text);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MultiCommand.Text = "wrong parameter";
                    }
                    catch (ArgumentNullException)
                    {
                        MultiCommand.Text = "wrong command";
                    }
                    catch (InvalidOperationException)
                    {
                        MultiCommand.Text = "invalid entry";
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
        }
        private void SyntxButton_Click(object sender, EventArgs e)
        {
            pars = new Parser(OutDisplayBitmap);
            try
            {
                pars.parseProgram(MultiCommand.Text);
            }
            catch (ArgumentOutOfRangeException)
            {
                MultiCommand.Text = "wrong command";
            }
            catch (ArgumentNullException)
            {
                MultiCommand.Text = "wrong parameter";
            }
        }
    }
}