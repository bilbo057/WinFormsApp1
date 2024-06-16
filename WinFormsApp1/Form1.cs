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
        Random rnd = new Random(); // variable for random things

        bool drawingRectangle = false; // variable if the rectangles are drawing or not
        bool drawingTriangle = false; // variable if the triangles are drawing or not
        bool drawingCircle = false; // variable if the circles are drawing or not

        // rectangle part

        private void button1_Click(object sender, EventArgs e) // starts the rectangle
        {
            drawingRectangle = true; // changing the value
            th = new Thread(DrawRectangles); // giving it value
            th.Start(); // starting the thread
        }

        private void button4_Click(object sender, EventArgs e) // stops the rectangle
        {
            drawingRectangle = false; // changing the value
        }

        public void DrawRectangles() // thread that draws the rectangles
        {
            while (drawingRectangle) // loop that draws rectangles until the boolean is true
            {
                this.Invoke((MethodInvoker)delegate
                {
                    using (Graphics g = this.CreateGraphics()) // creating the graphics
                    {
                        int rectWidth = rnd.Next(10, 250); // setting the width of the rectangle
                        int rectHeight = rnd.Next(10, 250); // setting the height of the rectangle
                        Color rectColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); // setting the color of the rectangle
                        using (Pen rectPen = new Pen(rectColor, 4)) // setting the width and the color of the pen that draws the rectangle
                        {
                            g.DrawRectangle(rectPen, new Rectangle(rnd.Next(0, this.ClientSize.Width - rectWidth), rnd.Next(0, this.ClientSize.Height - rectHeight), rectWidth, rectHeight)); // actually drawing the rectangle
                        }
                    }
                });
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
                this.Invoke((MethodInvoker)delegate
                {
                    using (Graphics g = this.CreateGraphics()) // creating the graphics
                    {
                        Color triColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); // setting the color of the triangle
                        using (Pen triPen = new Pen(triColor, 4)) // setting the width and the color of the pen that draws the triangle
                        {
                            int sideLength = rnd.Next(10, 350); // setting the side length
                            Point startPoint = new Point(rnd.Next(0, this.ClientSize.Width), rnd.Next(0, this.ClientSize.Height)); // setting the corner points
                            Point point1 = startPoint; // setting the start point
                            Point point2 = new Point(startPoint.X + sideLength, startPoint.Y); // setting the second point
                            Point point3 = new Point(startPoint.X + (int)(sideLength / 2.0), startPoint.Y + (int)(sideLength * Math.Sqrt(3) / 2.0)); // setting the third point

                            Point[] trianglePoints = { point1, point2, point3 }; // array with the points

                            if (IsWithinBounds(trianglePoints)) // checking if within bounds
                            {
                                g.DrawPolygon(triPen, trianglePoints); // drawing the triangle if it is within bounds
                            }
                        }
                    }
                });
                Thread.Sleep(2000); // wait for 2 seconds
            }
        }

        private bool IsWithinBounds(Point[] points) // method that returns if it is within bounds
        {
            foreach (Point point in points) // foreach point
            {
                if (point.X < 0 || point.X > this.ClientSize.Width || point.Y < 0 || point.Y > this.ClientSize.Height)
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
            th2 = new Thread(DrawCircles); // giving the thread value
            th2.Start(); // starts the thread
        }

        private void button6_Click(object sender, EventArgs e) // stops the circle
        {
            drawingCircle = false; // changing the value
        }

        public void DrawCircles() // the thread that draws the circles
        {
            while (drawingCircle) // loop that repeats until the variable is true
            {
                this.Invoke((MethodInvoker)delegate
                {
                    using (Graphics g = this.CreateGraphics()) // creating the graphics
                    {
                        int circleDiameter = rnd.Next(10, 250); // setting the diameter of the circle
                        Color circleColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); // setting the color of the circle
                        using (Pen circlePen = new Pen(circleColor, 4)) // setting the width and the color of the pen that draws the circle
                        {
                            g.DrawEllipse(circlePen, new Rectangle(rnd.Next(0, this.ClientSize.Width - circleDiameter), rnd.Next(0, this.ClientSize.Height - circleDiameter), circleDiameter, circleDiameter)); // actually drawing the circle
                        }
                    }
                });
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