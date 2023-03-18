namespace HW_circles
{
    public partial class Form1 : Form
    {
        private Painter p;
        public Form1()
        {
            InitializeComponent();
            p = new Painter(mainPanel.CreateGraphics());
            p.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.AddNew();


        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            p.Stop();
            p.MainGraphics = mainPanel.CreateGraphics();
            p.Start();

        }

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            p.Stop();
            p.MainGraphics = mainPanel.CreateGraphics();
            p.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.Stop();
        }
    }
}