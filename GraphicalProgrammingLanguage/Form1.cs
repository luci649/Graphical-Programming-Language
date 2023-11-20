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
            string[] x = richTextBox1.Text.Split("\n");
            

            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }

            var graphics = Graphics.FromImage(pictureBox1.Image);

            graphics.Clear(Color.White);

            if ("circle".Equals(textBox1.Text) || "circle".Equals(richTextBox1.Text))
            {
                graphics.FillEllipse(Brushes.SteelBlue, 10, 10, 100, 100);
            }
            else if ("rectangle".Equals(textBox1.Text) || "rectangle".Equals(richTextBox1.Text))
            {
                graphics.FillRectangle(Brushes.Brown, 10, 10, 10, 20);
            }

            pictureBox1.Refresh();
        }
    }
}