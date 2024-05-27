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
                Thread.Sleep(3000); // wait for 3 seconds
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
                Graphics g = this.CreateGraphics(); // creating the graphics
                Color triColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); // setting the color of the triangle
                Pen triPen = new Pen(triColor, 4);   // setting the witdh and the color of pen that draws the triangle

                int sideLength = rnd.Next(10, 350); // setting the side length
                Point startPoint = new Point(rnd.Next(0, this.Width), rnd.Next(0, this.Height)); // setting the corner points
                Point point1 = startPoint; // setting the start point
                Point point2 = new Point(startPoint.X + sideLength, startPoint.Y); // setting the second pount
                Point point3 = new Point(startPoint.X + (int)(sideLength / 2.0), startPoint.Y + (int)(sideLength * Math.Sqrt(3) / 2.0)); // setting the third point

                Point[] trianglePoints = { point1, point2, point3 }; // array with whe points

                if (IsWithinBounds(trianglePoints)) // checking is with in bounds
                {
                    g.DrawPolygon(triPen, trianglePoints); // drawing the triangle if it is with in bounds
                }

                Thread.Sleep(2000); // wait for 2 seconds
            }
        }

        private bool IsWithinBounds(Point[] points) // method that returns if it is with in bounds
        {
            foreach (Point point in points) // foreach that  every point
            {
                if (point.X < 0 || point.X > this.Width || point.Y < 0 || point.Y > this.Height)
                {
                    return false; // return false
                }
            }
            return true; // return true
        }

        // circle part

        private void button3_Click(object sender, EventArgs e) // starts the circle
        {
            drawingCircle = true; // changing the value
            th2 = new Thread(ThreadCircle); // giving the thread value
            th2.Start(); // starts the thread
        }
        private void button6_Click(object sender, EventArgs e) // stops the circle
        {
            drawingCircle = false; // changing the value
        }

        public void ThreadCircle() // the thread that draws the circle
        {
            while (drawingCircle) // loop that repeats untill the varriable is true
            {
                Graphics g = this.CreateGraphics(); // creating the graphics
                int circleDiameter = rnd.Next(10, 250); // setting the diameter of the circle
                Color circleColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); // setting the color of the circle
                Pen circlePen = new Pen(circleColor, 4);  // setting the witdh and the color of pen that draws the circle the triangle
                g.DrawEllipse(circlePen, new Rectangle(rnd.Next(0, this.Width - circleDiameter), rnd.Next(0, this.Height - circleDiameter), circleDiameter, circleDiameter)); // acctually drawing the circle
                Thread.Sleep(4000); // wait for 4 seconds
            }
        }

        // stop all

        private void button7_Click(object sender, EventArgs e) // button that stops all
        {
            drawingRectangle = false; // changing the value
            drawingTriangle = false; // changing the value
            drawingCircle = false; // changing the value
        }
    }
}