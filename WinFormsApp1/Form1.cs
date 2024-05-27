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

                // Draw Rectangle
                g.DrawRectangle(bluePen, new Rectangle(rnd.Next(0, this.Width), rnd.Next(0, this.Height), 20, 20));

                // Draw Triangle
                Point point1 = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
                Point point2 = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
                Point point3 = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
                Point[] trianglePoints = { point1, point2, point3 };

                g.DrawPolygon(bluePen, trianglePoints);
                Thread.Sleep(5);
            }
            MessageBox.Show("completed blue");
        }

        public void threadb()
        {
            for (int i = 0; i < 10; i++)
            {

                Graphics g = this.CreateGraphics();
                g.DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(new Random().Next(0, this.Width), new Random().Next(0, this.Height), 20, 20));
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
