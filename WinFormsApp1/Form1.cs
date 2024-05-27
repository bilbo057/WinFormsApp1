 namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread th;
        Thread th1;
        Random rnd = new Random();
        Pen bluePen = new Pen(Brushes.Blue, 4);
        Pen redPen = new Pen(Brushes.Red, 4);

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(thread);
            th.Start();
        }
        public void thread() 
        {
            for (int i = 0; i < 10; i++)
            {

                Graphics g = this.CreateGraphics();
                int rectWidth = rnd.Next(10, 250);
                int rectHeight = rnd.Next(10, 250);
                Color rectColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); 
                Pen rectPen = new Pen(rectColor, 4);
                g.DrawRectangle(rectPen, new Rectangle(rnd.Next(0, this.Width - rectWidth), rnd.Next(0, this.Height - rectHeight), rectWidth, rectHeight));
                Thread.Sleep(5);
            }
            MessageBox.Show("completed blue");
        }

        public void threadb()
        {
            for (int i = 0; i < 10; i++)
            {

                Graphics g = this.CreateGraphics();
                Point point1 = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
                Point point2 = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
                Point point3 = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
                Point[] trianglePoints = { point1, point2, point3 };

                g.DrawPolygon(redPen, trianglePoints);
                Thread.Sleep(5);
            }
            MessageBox.Show("completed red");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th1 = new Thread(threadb);
            th1.Start();
        }
    }
}
