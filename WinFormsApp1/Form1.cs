namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread th; // rectangle thread
        Thread th1; // triangle thread
        Thread th2; // circle thread
        Random rnd = new Random(); // varriable for random things

        bool drawingRectangle = false; // varriable if the rectangles are drawing or not
        bool drawingTriangle = false; // varriable if the triangle are drawing or not
        bool drawingCircle = false; // varriable if the circle are drawing or not


        // rectangle part


        private void button1_Click(object sender, EventArgs e) // starts the rectangle
        {
            drawingRectangle = true; // changing the value
            th = new Thread(thread); // giving it value
            th.Start(); // starting the thread
        }

        private void button4_Click(object sender, EventArgs e) // stops the rectangle
        {
            drawingRectangle = false; // changing the value
        }

        public void thread() // thread that draws the rectangle
        {
            while (drawingRectangle) // loop that draws rectangles untill the boolien is true
            {
                Graphics g = this.CreateGraphics(); // creating the graphics
                int rectWidth = rnd.Next(10, 250); // setting the witdh of the rectangle
                int rectHeight = rnd.Next(10, 250);  // setting the height of the rectangle
                Color rectColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));  // setting the color of the rectangle
                Pen rectPen = new Pen(rectColor, 4);  // setting the witdh and the color of pen that draws the rectangle the rectangle
                g.DrawRectangle(rectPen, new Rectangle(rnd.Next(0, this.Width - rectWidth), rnd.Next(0, this.Height - rectHeight), rectWidth, rectHeight)); // acctually drawing the rectangle
                Thread.Sleep(300); // wait for 3 seconds
            }
        }


        // triangle part


        private void button2_Click(object sender, EventArgs e) // starts the triangle
        {
            drawingTriangle = true; // changing the value
            th1 = new Thread(DrawTriangles); // giving it value
            th1.Start(); // starting the thread
        }

        private void button5_Click(object sender, EventArgs e) // stops the triangle
        {
            drawingTriangle = false; // changing the value
        }

        public void DrawTriangles() // thread that draws the triangles
        {
            while (drawingTriangle) // loop that draws triangles until the boolean is true
            {
                Graphics g = this.CreateGraphics();
                Color triColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Pen triPen = new Pen(triColor, 4);

                int sideLength = rnd.Next(10, 350);
                Point startPoint = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height));
                Point point1 = startPoint;
                Point point2 = new Point(startPoint.X + sideLength, startPoint.Y);
                Point point3 = new Point(startPoint.X + (int)(sideLength / 2.0), startPoint.Y + (int)(sideLength * Math.Sqrt(3) / 2.0));

                Point[] trianglePoints = { point1, point2, point3 };

                if (IsWithinBounds(trianglePoints))
                {
                    g.DrawPolygon(triPen, trianglePoints);
                }

                Thread.Sleep(200); // wait for 2 seconds
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


        // circle part


        private void button3_Click(object sender, EventArgs e) // starts the circle
        {
            if (th2 != null && th2.IsAlive)
            {
                th2.Abort();
            }
            th2 = new Thread(threadc);
            th2.Start();
        }

        private void button6_Click(object sender, EventArgs e) // stops the circle
        {

        }

        public void threadc()
        {
            for (int i = 0; i < 1; i++)
            {
                Graphics g = this.CreateGraphics();
                int circleDiameter = rnd.Next(10, 250);
                Color circleColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Pen circlePen = new Pen(circleColor, 4);
                g.DrawEllipse(circlePen, new Rectangle(rnd.Next(0, this.Width - circleDiameter), rnd.Next(0, this.Height - circleDiameter), circleDiameter, circleDiameter));
                Thread.Sleep(5);
            }
        }
    }
}
