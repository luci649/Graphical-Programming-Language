using System.Windows.Forms.VisualStyles;
using System.IO;


namespace GraphicalProgrammingLanguage
{
    
    public partial class Form1 : Form
    {
        const int screenXsize = 241, screenYsize = 186;

        Canvas can;
        Graphics g;
        Parser pars;
        Bitmap PointerBitmap = new Bitmap(screenXsize, screenYsize);
        Bitmap OutDisplayBitmap = new Bitmap(screenXsize, screenYsize);
        
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
                catch (InvalidOperationException)
                {
                    MultiCommand.Text = "invalid entry";
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MultiCommand.Text = ex.Message;
                }
                catch (ArgumentNullException)
                {
                    MultiCommand.Text = "wrong command\n";
                }
            }
            else if (MultiCommand.Text != "")
            {
                try
                {
                    pars.ParseProgram(MultiCommand.Text);
                }
                catch (InvalidOperationException)
                {
                    MultiCommand.Text = "invalid entry";
                }
                catch (ArgumentOutOfRangeException)
                {
                    MultiCommand.Text = "to many parameters";
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
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (SingleCommand.Text.Equals("run"))
                {
                    try
                    {
                        pars.ParseProgram(MultiCommand.Text);
                    }
                    catch (InvalidOperationException)
                    {
                        MultiCommand.Text = "invalid entry";
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MultiCommand.Text = "wrong parameter";
                    }
                    catch (ArgumentNullException ex)
                    {
                        MultiCommand.Text = ex.Message;
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
                        MultiCommand.Text = "wrong parameter";
                    }
                    catch (ArgumentNullException g)
                    {
                        MultiCommand.Text = g.Message;
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
                MultiCommand.Text = "wrong command";
            }
            catch (ArgumentNullException)
            {
                MultiCommand.Text = "wrong parameter";
            }
        }         
    }
}