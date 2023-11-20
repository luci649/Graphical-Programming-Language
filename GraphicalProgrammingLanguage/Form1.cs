using System.Windows.Forms.VisualStyles;

namespace GraphicalProgrammingLanguage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] x = MultiCommand.Text.Split("\n");
            

            if (OutputDisplay.Image == null)
            {
                OutputDisplay.Image = new Bitmap(OutputDisplay.Width, OutputDisplay.Height);
            }

            var graphics = Graphics.FromImage(OutputDisplay.Image);

            graphics.Clear(Color.White);

            if ("circle".Equals(SingleCommand.Text) || "circle".Equals(MultiCommand.Text))
            {
                graphics.FillEllipse(Brushes.SteelBlue, 10, 10, 100, 100);
            }
            else if ("rectangle".Equals(SingleCommand.Text) || "rectangle".Equals(MultiCommand.Text))
            {
                graphics.FillRectangle(Brushes.Brown, 10, 10, 10, 20);
            }

            OutputDisplay.Refresh();
        }
    }
}