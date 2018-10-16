using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cay_ley
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private Graphics graphics;


        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
                return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = this.textBox1.Text;
            per1 = Double.Parse(s1);
            string s2 = this.textBox2.Text;
            per2 = Double.Parse(s2);
            string s3 = this.textBox3.Text;
            th1 = Double.Parse(s3) * Math.PI / 180;
            string s4 = this.textBox4.Text;
            th2 = Double.Parse(s4) * Math.PI / 180;
            string s5 = this.textBox5.Text;
            times = Int32.Parse(s5);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(times, 500, 700, 130, -Math.PI / 2);

        }
        double per1;
        double per2;
        double th1;
        double th2;
        int times;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
