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

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(thread);
            th.Start();
        }
        public void thread() 
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
            }
            MessageBox.Show("completed blue");
        }

        public void threadb()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
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
