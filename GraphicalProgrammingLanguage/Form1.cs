using System.Windows.Forms.VisualStyles;
using System.IO;


namespace GraphicalProgrammingLanguage
{
    public partial class Form1 : Form
    {
        const int screenXsize = 241, screenYsize = 186;
        Bitmap OutDisplayBitmap = new Bitmap(screenXsize,screenYsize);
        Parser pars;
        

        public Form1()
        {
            InitializeComponent();           
        }

        private void Button1_keyDown(object sender, EventArgs e)
        {
            pars = new Parser(OutDisplayBitmap);
            pars.commandParser(SingleCommand.Text);
            OutputDisplay.Refresh();
        }
        private void SingleCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { pars = new Parser(OutDisplayBitmap);
                if (SingleCommand.Text.Equals("run")) 
                {
                    pars.parseProgram(MultiCommand.Text);
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
                    pars.commandParser(SingleCommand.Text);
                }
                SingleCommand.Text = "";
                Refresh();
            }
        }
         private void OutputDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutDisplayBitmap, 0,0);
        }
    }
}