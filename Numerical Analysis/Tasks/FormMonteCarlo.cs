using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical_Analysis.Tasks
{
    public partial class FormMonteCarlo : Form
    {
        Random random = new Random();
        int width;
        int height;
        int center;
        int zoom = 150;
        public FormMonteCarlo()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            center = height / 4;
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Pen axisPen = new Pen(Color.Black, 2);
                g.DrawLine(axisPen, 0, 0, 0, height);
                g.DrawLine(axisPen, 0, height - center, width, height - center);
                for (int i = 0; i < width; i++)
                {
                    float x = (float)i / zoom;
                    g.DrawEllipse(new Pen(Color.Blue, 2), new RectangleF(XYtoPointF(x, (float)Math.Sin(x)), new Size(1, 1)));
                    g.DrawEllipse(new Pen(Color.Green, 2), new RectangleF(XYtoPointF(x, (float)F2(x)), new Size(1, 1)));
                }
                int count = 10000;
                int hits = 0;
                for (int i = 0; i < count; i++)
                {
                    double x = (random.NextDouble() * width) / zoom;
                    double y = (random.NextDouble() * height - center) / zoom;
                    g.DrawEllipse(new Pen(Color.Red, 1), new RectangleF(XYtoPointF((float)x, (float)y), new Size(1, 1)));
                    if (y< (float)Math.Sin(x) && y> (float)F2(x))
                    {
                        hits++;
                    }
                }
                label1.Text = $"S = {(double)hits/count*(width/zoom*height/zoom)}";
            }
            pictureBox1.Image = bmp;
        }

        double F2(double x)
        {
            return Math.Pow(x - Math.PI / 2, 2);
        }

        PointF XYtoPointF(float x, float y)
        {
            return new PointF(x * zoom, height - center - y * zoom);
        }
    }
}
