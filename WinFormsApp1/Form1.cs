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
        Thread th2;
        Random rnd = new Random();

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
        }

        public void threadb()
        {
            for (int i = 0; i < 10; i++)
            {

                Graphics g = this.CreateGraphics();
                Color triColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Pen triPen = new Pen(triColor, 4);
                DrawEquilateralTriangle(g, triPen);

                Thread.Sleep(5);
            }
        }
        public void threadc()
        {
            for (int i = 0; i < 10; i++)
            {
                Graphics g = this.CreateGraphics();
                int circleDiameter = rnd.Next(10, 250);
                Color circleColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Pen circlePen = new Pen(circleColor, 4);
                g.DrawEllipse(circlePen, new Rectangle(rnd.Next(0, this.Width - circleDiameter), rnd.Next(0, this.Height - circleDiameter), circleDiameter, circleDiameter));
                Thread.Sleep(5);
            }
        }

        private void DrawEquilateralTriangle(Graphics g, Pen pen)
        {
            int sideLength = rnd.Next(10, 50); // Random length of each side of the equilateral triangle
            Point startPoint = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));

            // Calculate the three vertices of the equilateral triangle
            Point point1 = startPoint;
            Point point2 = new Point(startPoint.X + sideLength, startPoint.Y);
            Point point3 = new Point(startPoint.X + (int)(sideLength / 2.0), startPoint.Y + (int)(sideLength * Math.Sqrt(3) / 2.0));

            Point[] trianglePoints = { point1, point2, point3 };

            // Ensure the triangle is within the drawing area
            if (IsWithinBounds(trianglePoints))
            {
                g.DrawPolygon(pen, trianglePoints);
            }
        }
        private bool IsWithinBounds(Point[] points)
        {
            foreach (Point point in points)
            {
                if (point.X < 0 || point.X > this.Width || point.Y < 0 || point.Y > this.Height)
                {
                    return false;
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th1 = new Thread(threadb);
            th1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (th2 != null && th2.IsAlive)
            {
                th2.Abort();
            }
            th2 = new Thread(threadc);
            th2.Start();
        }
    }
}
