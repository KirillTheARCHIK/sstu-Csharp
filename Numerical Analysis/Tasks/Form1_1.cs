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
    public partial class Form1_1 : Form
    {
        public Form1_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float Sf1 = 0;
            for (int i = 0; i < 1e6; i++)
            {
                Sf1 += (float)1e-6;
            }
            Sf1 = Sf1 + 1;
            textBoxFloat1.Text = (Math.Abs(2-Sf1)/Sf1).ToString();

            float Sf2 = 0;
            for (int i = 0; i < 1e6; i++)
            {
                Sf2 += (float)1e-6;
            }
            Sf2 = Sf2 + 1;
            textBoxFloat2.Text = (Math.Abs(2 - Sf2) / Sf2).ToString();

            double Sd1 = 0;
            for (int i = 0; i < 1e6; i++)
            {
                Sd1 += 1e-6;
            }
            Sd1 = Sd1 + 1;
            textBoxDouble1.Text = (Math.Abs(2 - Sd1) / Sd1).ToString();

            double Sd2 = 0;
            for (int i = 0; i < 1e6; i++)
            {
                Sd2 += 1e-6;
            }
            Sd2 = Sd2 + 1;
            textBoxDouble2.Text = (Math.Abs(2 - Sd2) / Sd2).ToString();
        }
    }
}
