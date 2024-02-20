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
    public partial class Form1_2 : Form
    {
        public Form1_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBoxSinX.Text);
            double targetEps = double.Parse(textBoxSinEps.Text);
            double S = 0;
            double prevElem = 0;
            int count = 0;
            for (int k = 0; k < int.MaxValue; k++)
            {
                count++;
                double elem = Math.Pow(-1, k) * (Math.Pow(x, 2 * k + 1) / MyMath.Fact(2 * k + 1));
                S += elem;
                if (Math.Abs(prevElem-elem)<targetEps)
                {
                    break;
                }
            }
            textBoxSinCount.Text = count.ToString();
            textBoxSinAns.Text = S.ToString();
        }
    }
}
